using System.Runtime.InteropServices;

namespace Upos.ServiceObject.CashDrawer.Interfaces
{
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("CCB91121-B81E-11D2-AB74-0040054C3719")]
    internal interface COPOSCashDrawer
    {
        [DispId(1)] void SOData(int Status);
        [DispId(2)] void SODirectIO(int EventNumber, ref int pData, ref string pString);
        [DispId(3)] void SOError(int ResultCode, int ResultCodeExtended, int ErrorLocus, ref int pErrorResponse);
        [DispId(4)] void SOOutputCompleteDummy(int OutputID);
        [DispId(5)] void SOStatusUpdate(int Data);

        [DispId(9)]int SOProcessID();
    }
}
