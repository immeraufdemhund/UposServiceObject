using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Upos.ServiceObject.Base
{
    /// <summary>
    /// All OPOS devices have these events.
    /// </summary>
    public interface COPOS
    {
        [Description("method SOData")]
        void SOData([In] int Status);

        [Description("method SODirectIO")]
        void SODirectIO([In] int EventNumber, [In, Out] ref int pData, [In, Out, MarshalAs(UnmanagedType.BStr)]ref string pString);

        [Description("method SOError")]
        void SOError([In] int ResultCode, [In] int ResultCodeExtended, [In] int ErrorLocus, [In, Out] ref int pErrorResponse);

        [Description("method SOOutputComplete")]
        void SOOutputComplete([In] int OutputID);

        [Description("method SOStatusUpdate")]
        void SOStatusUpdate([In] int Data);

        [Description("method SOProcessID")]
        void SOProcessID([Out] out int pProcessID);
    }
}
