using System;

namespace Upos.ServiceObject.Base.UposEvents
{
    internal class UposEventDispatcher : IUposEventDispatcher
    {
        private readonly UposEventArguments _callbacks;

        public UposEventDispatcher(UposEventArguments args)
        {
            _callbacks = args;
        }

        public void EnqueueDirectIOEvent(DirectIOEventArguments args)
        {
            _callbacks.DirectIOEventHandler(args.EventNumber, args.NumericData, args.SringData);
        }

        public void EnqueueErrorEvent(ErrorEventArguments args)
        {
            throw new NotImplementedException();
        }

        public void EnqueueOutputCompleteEvent(OutputCompleteEventArguments args)
        {
            _callbacks.OutputCompleteEventHandler(args.OutputID);
        }

        public void EnqueueStatusUpdateEvent(StatusUpdateEventArguemtns args)
        {
            throw new NotImplementedException();
        }
    }
}
