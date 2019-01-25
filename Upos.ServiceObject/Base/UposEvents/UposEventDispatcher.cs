using System;

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
    /// The Following condition that cause event delivery to be delayed until the condition is corrected:
    ///     The application has set the property FreezeEvents to true.
    ///     The event type is a Data Event or an input Error Event, but the property DataEventEnabled is false. (See "Device Input Model" on page 22.)
    /// </summary>
    internal class UposEventDispatcher : IUposEventDispatcher
    {
        private readonly UposEventArguments _callbacks;

        public UposEventDispatcher(UposEventArguments args)
        {
            _callbacks = args;
        }

        public void EnqueueDirectIOEvent(DirectIOEventArguments args)
        {
            _callbacks.DirectIOEventHandler(args.EventNumber, args.NumericData, args.StringData);
        }

        public void EnqueueErrorEvent(ErrorEventArguments args)
        {
            throw new NotImplementedException();
        }

        public void EnqueueOutputCompleteEvent(OutputCompleteEventArguments args)
        {
            _callbacks.OutputCompleteEventHandler(args.OutputID);
        }

        public void EnqueueStatusUpdateEvent(StatusUpdateEventArguments args)
        {
            throw new NotImplementedException();
        }
    }
}
