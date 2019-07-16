using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Upos.ServiceObject.CashDrawer.Interfaces
{
    [ComImport, Guid("CCB94041-B81E-11D2-AB74-0040054C3719"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface ICashDrawerControlObject : ICashDrawerControlObject_1_9
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

    [ComImport, Guid("CCB93041-B81E-11D2-AB74-0040054C3719"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface ICashDrawerControlObject_1_9 : ICashDrawerControlObject_1_8
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

    [ComImport, Guid("CCB92041-B81E-11D2-AB74-0040054C3719"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface ICashDrawerControlObject_1_8 : ICashDrawerControlObject_1_5
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

    [ComImport, Guid("CCB91041-B81E-11D2-AB74-0040054C3719"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface ICashDrawerControlObject_1_5
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
