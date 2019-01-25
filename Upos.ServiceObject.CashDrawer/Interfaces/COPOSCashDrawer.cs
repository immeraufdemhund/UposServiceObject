using System.Runtime.InteropServices;
using Upos.ServiceObject.Base;

namespace Upos.ServiceObject.CashDrawer.Interfaces
{
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("CCB91121-B81E-11D2-AB74-0040054C3719")]
    internal interface COPOSCashDrawer : COPOS
    {
    }
}
