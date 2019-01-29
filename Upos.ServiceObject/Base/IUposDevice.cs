using System;
using System.Collections.Generic;

namespace Upos.ServiceObject.Base
{
    public interface IUposDevice
    {
        OpenResultConstants CanCommunicateWithDevice(string deviceClass, string deviceName, Dictionary<string, object> registryValues);
        bool CanClaimDevice();
        bool CanReleaseDevice();
        bool CanEnableDevice();
        bool CanDisableDevice();
        bool ClaimDevice(TimeSpan timeout);
        bool ReleaseDevice();
        bool EnableDevice();
        bool DisableDevice();
    }
}
