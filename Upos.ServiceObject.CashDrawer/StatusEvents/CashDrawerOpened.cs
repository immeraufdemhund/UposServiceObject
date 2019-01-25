using Upos.ServiceObject.Base.UposEvents;

namespace Upos.ServiceObject.CashDrawer.StatusEvents
{
    public class CashDrawerOpened : StatusUpdateEventArguments
    {
        private const int CASH_SUE_DRAWEROPEN = 1;
        public CashDrawerOpened() : base(CASH_SUE_DRAWEROPEN)
        {
        }
    }
}
