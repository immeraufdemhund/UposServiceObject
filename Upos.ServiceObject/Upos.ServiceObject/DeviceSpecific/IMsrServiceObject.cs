using System.Runtime.InteropServices;

namespace Upos.ServiceObject.DeviceSpecific
{
    public interface IMsrServiceObject
    {
        [DispId(0x14)]
        int AuthenticateDevice([In, MarshalAs(UnmanagedType.BStr)] string deviceResponse);
        [DispId(0x15)]
        int DeauthenticateDevice([In, MarshalAs(UnmanagedType.BStr)] string deviceResponse);
        [DispId(0x16)]
        int RetrieveCardProperty([In, MarshalAs(UnmanagedType.BStr)] string propertyName, [Out, MarshalAs(UnmanagedType.BStr)] out string cardProperty);
        [DispId(0x17)]
        int RetrieveDeviceAuthenticationData([In, Out, MarshalAs(UnmanagedType.BStr)] ref string challenge);
        [DispId(0x18)]
        int UpdateKey([In, MarshalAs(UnmanagedType.BStr)]string key, [In, MarshalAs(UnmanagedType.BStr)] string keyName);
        [DispId(0x19)]
        int WriteTracks([In] object data, [In] int timeout);
    }
}
