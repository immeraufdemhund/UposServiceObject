using System.ComponentModel;
using System.Runtime.InteropServices;
using Upos.ServiceObject.Base;

namespace Upos.ServiceObject.CashDrawer.Interfaces
{
    /// <summary>
    /// don't remove methods, for some reason COM wants them explicitly defined. even though it is defined in base COPOS interface (shrug)
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual)]
    //[Guid("CCB90040-B81E-11D2-AB74-0040054C3719")]//helpstring("OPOS CashDrawer Control 1.14.001 [Public, by CRM/MCS]") nope
    [Guid("CCB91041-B81E-11D2-AB74-0040054C3719")] //helpstring("IOPOSCashDrawer 1.5 Interface"),
    internal interface COPOSCashDrawer : COPOS
    {
        [Description("method SOData"), DispId(1)]
        void SODataDummy([In] int Status);

        [Description("method SODirectIO"), DispId(2)]
        void SODirectIO([In] int EventNumber, [In, Out] ref int pData, [In, Out, MarshalAs(UnmanagedType.BStr)]ref string pString);

        [Description("method SOError"), DispId(3)]
        void SOErrorDummy([In] int ResultCode, [In] int ResultCodeExtended, [In] int ErrorLocus, [In, Out] ref int pErrorResponse);

        [Description("method SOOutputComplete"), DispId(4)]
        void SOOutputCompleteDummy([In] int OutputID);

        [Description("method SOStatusUpdate"), DispId(5)]
        void SOStatusUpdate([In] int Data);

        [Description("method SOProcessID"), DispId(9)]
        void SOProcessID([Out] out int pProcessID);
    }
}
