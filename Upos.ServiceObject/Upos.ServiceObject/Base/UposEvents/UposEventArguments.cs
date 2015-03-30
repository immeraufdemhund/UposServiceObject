using Upos.ServiceObject.Base.Properties;

namespace Upos.ServiceObject.Base.UposEvents
{
    public class UposEventArguments
    {
        public IUposProperties Properties { get; private set; }
        public DataEventHandler dataHandler { get; set; }
        public ErrorEventHandler errorHandler { get; set; }
        public DirectIOEventHandler directIOHandler { get; set; }
        public OutputCompleteEventHandler outputHandler { get; set; }
        public StatusUpdateEventHandler statusHandler { get; set; }

        public UposEventArguments(IUposProperties properties)
        {
            Properties = properties;
            dataHandler = EmptyData;
            errorHandler = EmptyError;
            statusHandler = EmptyStatus;
            outputHandler = EmptyOutput;
            directIOHandler = EmptyDirectIO;
        }

        private void EmptyData(int status) { }
        private void EmptyError(int resultCode, int resultCodeExtended, int errorLocus, ref int errorResponse) { }
        private void EmptyDirectIO(int eventNumber, ref int numericData, ref string stringData) { }
        private void EmptyOutput(int outputId) { }
        private void EmptyStatus(int status) { }

    }
}
