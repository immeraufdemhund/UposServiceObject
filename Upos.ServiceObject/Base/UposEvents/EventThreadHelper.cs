using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Upos.ServiceObject.Base.Properties;

namespace Upos.ServiceObject.Base.UposEvents
{
    /// <summary>
    /// #Taken from page 59 on UPOS1.14#
    /// The Service must enqueue events on an internally created and managed queue.
    /// All events are delivered in a first-in, first-out mannger.
    /// (The only exceptions is that a special input error event is delivered early if
    /// some data events are also enqueued. See "Device Input Model" on page 22.)
    /// Events are delivered by an internally created and managed Service thread.
    /// The Service causes event delivery by calling an event firing callback method in the Control, which then delivers the event to the application.
    ///
    /// The Following conditionat cause event delivery to be delayed until the condition is corrected:
    ///     The application has set the property FreezeEvents to true.
    ///     The event type is a Data Event or an input Error Event, but the property DataEventEnabled is false. (See "Device Input Model" on page 22.)
    /// </summary>
    [Obsolete("To be replaced by UposEventDispatcher")]
    public class EventThreadHelper : IDisposable
    {
        public int DataCount { get { return _eventQueue.Count(f => f is DataEventArguments); } }

        private Thread _eventThread;
        private bool _eventsFrozen = false;
        private bool _dataEventEnabled = false;
        private readonly object locker = new object();
        private readonly Queue<EventArguments> _eventQueue = new Queue<EventArguments>();

        private readonly COPOS _oposDevice;
        private readonly IUposProperties _uposProperties;

        public EventThreadHelper(COPOS oposDevice, IUposProperties uposProperties)
        {
            _oposDevice = oposDevice;
            _uposProperties = uposProperties;
            _uposProperties.PropertyChanged += oposDevice_PropertyChanged;
        }

        private void oposDevice_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "DataEventEnabled":
                    lock (locker)
                    {
                        _dataEventEnabled = _uposProperties.ByName.DataEventEnabled;
                        if (_dataEventEnabled && (_eventThread == null || !_eventThread.IsAlive))
                        {
                            _eventThread = new Thread(MonitorOposEventQueue);
                            _eventThread.Start();
                        }
                        Monitor.Pulse(locker);
                    }
                    break;

                case "FreezeEvents":
                    lock (locker)
                    {
                        _eventsFrozen = _uposProperties.ByName.FreezeEvents;
                        Monitor.Pulse(locker);
                    }
                    break;
            }
        }

        /// <summary>
        /// Enqueues an event to be fired. Use only from OPOSBase
        /// </summary>
        /// <param name="dataEvent">The event to enqueue</param>
        internal void EnqueueEvent(EventArguments dataEvent)
        {
            if (!dataEvent.IsImmediate)
            {
                EnqueueItem(dataEvent);
            }
            else
            {
                FireEvent(dataEvent);
            }
        }

        private void EnqueueItem(EventArguments dataEvent)
        {
            lock (locker)
            {
                _eventQueue.Enqueue(dataEvent);
                Monitor.Pulse(locker);
            }
            _uposProperties.FirePropertyChanged("DataCount");
        }

        /// <summary>
        /// Clears both the queues of all events
        /// </summary>
        internal void Clear()
        {
            _eventQueue.Clear();
        }

        public void Dispose()
        {
            if (_eventThread != null && _eventThread.IsAlive)
            {
                _eventsFrozen = false;
                _dataEventEnabled = true;
                EnqueueItem(null);

                _eventThread.Join();
            }
        }

        private void MonitorOposEventQueue()
        {
            while (true)
            {
                EventArguments oposEvent;
                lock (locker)
                {
                    while (_eventQueue.Count == 0 || _eventsFrozen || !_dataEventEnabled)
                    {
                        Monitor.Wait(locker);
                    }
                    oposEvent = _eventQueue.Dequeue();
                }
                if (oposEvent == null) { break; }
                FireEvent(oposEvent);
            }
        }

        private void FireEvent(EventArguments enqueuedEvent)
        {
            if (enqueuedEvent is DataEventArguments arguments)
            {
                _uposProperties.FirePropertyChanged("DataCount");
                _oposDevice.SOData(arguments.Status);
            }
            else if (enqueuedEvent is DirectIOEventArguments directIoEventArguments)
            {
                _oposDevice.SODirectIO(directIoEventArguments.EventNumber, ref directIoEventArguments.NumericData, ref directIoEventArguments.StringData);
            }
            else if (enqueuedEvent is ErrorEventArguments errorEventArguments)
            {
                _oposDevice.SOError((int)errorEventArguments.ResultCode, errorEventArguments.ResultCodeExtended, (int)errorEventArguments.ErrorLocus, ref errorEventArguments.ErrorResponse);
            }
            else if (enqueuedEvent is OutputCompleteEventArguments outputCompleteEventArguments)
            {
                _oposDevice.SOOutputComplete(outputCompleteEventArguments.OutputID);
            }
            else if (enqueuedEvent is StatusUpdateEventArguments statusUpdateEventArguments)
            {
                _oposDevice.SOStatusUpdate(statusUpdateEventArguments.Status);
            }
        }
    }
}
