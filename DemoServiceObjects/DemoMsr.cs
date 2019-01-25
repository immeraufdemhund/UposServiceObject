using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Upos.ServiceObject.Base;
using Upos.ServiceObject.Base.Properties;
using Upos.ServiceObject.Base.UposEvents;
using Upos.ServiceObject.DeviceSpecific;

namespace DemoServiceObjects
{
    [ComVisible(true), Guid("928AAE48-14AA-4341-B8FF-D79D584C9FE4"), ClassInterface(ClassInterfaceType.AutoDispatch), ProgId("DemoServiceObject.Msr")]
    public class DemoMsr : UposBase, IMsrServiceObject
    {
        public DemoMsr()
            :base(new UposBaseProperties(), new DemoMsrDevice())
        {
            _props.ByName.ServiceObjectVersion = 1 * 1000000 + 13 * 1000 + 0;
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

        public override int DirectIO(int command, ref int numericData, ref string stringData)
        {
            throw new NotImplementedException();
        }

        protected override void VerifyDeviceSettings(Dictionary<string, object> deviceSettings)
        {
        }

        protected override COPOS GetDeviceSpecificControlObjectDispatcher(object dispatchObject)
        {
            return (MsrControlObject) dispatchObject;
        }
    }

    public class DemoMsrDevice : IUposDevice
    {
        public bool CanCommunicateWithDevice() => true;
        public bool CanClaimDevice() => true;
        public bool CanReleaseDevice() => true;
        public bool CanEnableDevice() => true;
        public bool CanDisableDevice() => true;
        public bool ClaimDevice(TimeSpan timeout) => true;
        public bool ReleaseDevice() => true;
        public bool EnableDevice() => true;
        public bool DisableDevice() => true;
    }
}
