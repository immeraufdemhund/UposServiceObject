namespace Upos.ServiceObject.Base.UposEvents
{
    public interface IUposEventDispatcher
    {
        void EnqueueDirectIOEvent(DirectIOEventArguments args);

        void EnqueueErrorEvent(ErrorEventArguments args);

        void EnqueueOutputCompleteEvent(OutputCompleteEventArguments args);

        void EnqueueStatusUpdateEvent(StatusUpdateEventArguemtns args);
    }
}
