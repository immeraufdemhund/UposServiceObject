using log4net;
using Upos.ServiceObject.CashDrawer.Interfaces;

namespace Upos.ServiceObject.CashDrawer
{
    public class CashDrawerControlObject : Base.DynamicControlObject
    {
        private static ILog Log = LogManager.GetLogger(typeof(CashDrawerControlObject));

        private readonly ICashDrawerControlObject _controlObject;

        public CashDrawerControlObject(object dispatchObject)
        {
            _controlObject = (ICashDrawerControlObject)dispatchObject;
        }

        protected override void FireDataEvent(int status) { }
        protected override void FireDirectIOEvent(int eventNumber, ref int pData, ref string pString) { }
        protected override void FireOutputCompleteEvent(int outputId) { }

        protected override void FireErrorEvent(int resultCode, int resultCodeExtended, int errorLocus, ref int pErrorResponse)
        {
            //_controlObject.SOError(resultCode, resultCodeExtended, errorLocus, ref pErrorResponse);
        }

        protected override void FireStatusUpdateEvent(int data)
        {
            Log.DebugFormat("+Fire StatusUpdateEvent({0})", data);
            _controlObject.SOStatusUpdate(data);
            Log.Debug("-Fire StatusUpdateEvent()");
        }

        protected override void GetProcessId(out int pProcessId)
        {
            Log.DebugFormat("+Fire GetProcessId");
            _controlObject.SOProcessID(out pProcessId);
            Log.DebugFormat("-Fire StatusUpdateEvent. set processId to {0}", pProcessId);
        }
    }
}
