using Upos.ServiceObject.Base.Properties;

namespace Upos.ServiceObject.Base.UposEvents
{
    public class UposEventArguments
    {
        public IUposProperties Properties { get; private set; }
        public DataEventHandler DataEventHandler { get; set; }
        public ErrorEventHandler ErrorEventHandler { get; set; }
        public DirectIOEventHandler DirectIOEventHandler { get; set; }
        public OutputCompleteEventHandler OutputCompleteEventHandler { get; set; }
        public StatusUpdateEventHandler StatusUpdateEventHandler { get; set; }

        public UposEventArguments(IUposProperties properties)
        {
            Properties = properties;
            DataEventHandler = EmptyData;
            ErrorEventHandler = EmptyError;
            StatusUpdateEventHandler = EmptyStatus;
            OutputCompleteEventHandler = EmptyOutput;
            DirectIOEventHandler = EmptyDirectIO;
        }

        private void EmptyData(int status) { }
        private void EmptyError(int resultCode, int resultCodeExtended, int errorLocus, ref int errorResponse) { }
        private void EmptyDirectIO(int eventNumber, int numericData, string stringData) { }
        private void EmptyOutput(int outputId) { }
        private void EmptyStatus(int status) { }

    }
}
