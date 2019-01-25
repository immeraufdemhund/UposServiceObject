using Upos.ServiceObject.Base.UposEvents;

namespace Upos.ServiceObject.CashDrawer.StatusEvents
{
    public class CashDrawerClosed : StatusUpdateEventArguments
    {
        private const int CASH_SUE_DRAWERCLOSED = 0;
        public CashDrawerClosed() : base(CASH_SUE_DRAWERCLOSED)
        {
        }
    }
}
