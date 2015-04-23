using System;
using System.Runtime.InteropServices;
using Upos.ServiceObject.Base;
using Upos.ServiceObject.DeviceSpecific;

namespace DemoServiceObjects
{
    [ComVisible(true), Guid("928AAE48-14AA-4341-B8FF-D79D584C9FE4"), ClassInterface(ClassInterfaceType.AutoDual), ProgId("DemoServiceObject.Msr")]
    public class DemoMsr : UposBase, IMsrServiceObject
    {
        public DemoMsr()
        {
            //_props.ByName.ServiceObjectVersion = 1 * 1000000 + 13 * 1000 + 0;
        }

        public int AuthenticateDevice(string deviceResponse)
        {
            throw new System.NotImplementedException();
        }

        public int DeauthenticateDevice(string deviceResponse)
        {
            throw new System.NotImplementedException();
        }

        public int RetrieveCardProperty(string propertyName, out string cardProperty)
        {
            throw new System.NotImplementedException();
        }

        public int RetrieveDeviceAuthenticationData(ref string challenge)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateKey(string key, string keyName)
        {
            throw new System.NotImplementedException();
        }

        public int WriteTracks(object data, int timeout)
        {
            throw new System.NotImplementedException();
        }
    }
}
