namespace Upos.ServiceObject.CashDrawer
{
    internal class CashDrawerControlObject : Base.DynamicControlObject
    {
        private readonly Interfaces.COPOSCashDrawer _controlObject;

        public CashDrawerControlObject(object dispatchObject)
        {
            _controlObject = (Interfaces.COPOSCashDrawer) dispatchObject;
        }

        protected override void FireDataEvent(int status)
        {
            _controlObject.SOData(status);
        }

        protected override void FireDirectIOEvent(int eventNumber, ref int pData, ref string pString)
        {
            _controlObject.SODirectIO(eventNumber, ref pData, ref pString);
        }

        protected override void FireErrorEvent(int resultCode, int resultCodeExtended, int errorLocus, ref int pErrorResponse)
        {
            _controlObject.SOError(resultCode, resultCodeExtended, errorLocus, ref pErrorResponse);
        }

        protected override void FireOutputCompleteEvent(int outputId)
        {
            _controlObject.SOOutputCompleteDummy(outputId);
        }

        protected override void FireStatusUpdateEvent(int data)
        {
            _controlObject.SOStatusUpdate(data);
        }

        protected override void GetProcessId(out int pProcessId)
        {
            pProcessId = _controlObject.SOProcessID();
        }
    }
}