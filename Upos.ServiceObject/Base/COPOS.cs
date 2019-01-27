using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Upos.ServiceObject.Base
{
    /// <summary>
    /// All OPOS devices have these events.
    /// </summary>
    public interface COPOS
    {
        [Description("method SOData"), DispId(1)]
        void SOData([In] int Status);

        [Description("method SODirectIO"), DispId(2)]
        void SODirectIO([In] int EventNumber, [In, Out] ref int pData, [In, Out, MarshalAs(UnmanagedType.BStr)]ref string pString);

        [Description("method SOError"), DispId(3)]
        void SOError([In] int ResultCode, [In] int ResultCodeExtended, [In] int ErrorLocus, [In, Out] ref int pErrorResponse);

        [Description("method SOOutputComplete"), DispId(4)]
        void SOOutputComplete([In] int OutputID);

        [Description("method SOStatusUpdate"), DispId(5)]
        void SOStatusUpdate([In] int Data);

        [Description("method SOProcessID"), DispId(9)]
        void SOProcessID([Out] out int pProcessID);
    }
}
