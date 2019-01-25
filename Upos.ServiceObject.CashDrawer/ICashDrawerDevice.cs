using Upos.ServiceObject.Base;

namespace Upos.ServiceObject.CashDrawer
{
    public interface ICashDrawerDevice : IUposDevice
    {
        bool CanReportStatus { get; }
        bool CanDetectMultiDrawerStatus { get; }
        bool DrawerOpened { get; }

        void OpenDrawer();
        void WaitForDrawerClose();
    }
}
