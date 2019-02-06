using Microsoft.Win32;
using System.Collections.Generic;
using log4net;

namespace Upos.ServiceObject
{
    public interface IReadWindowsUposRegistry
    {
        Dictionary<string, object> GetRegistryValues(string deviceClass, string deviceName);
    }

    public class RegistryHelper : IReadWindowsUposRegistry
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RegistryHelper));

        public Dictionary<string, object> GetRegistryValues(string deviceClass, string deviceName)
        {
            var dict = new Dictionary<string, object>();
            var regBaseName = $@"SOFTWARE\OLEforRetail\ServiceOPOS\{deviceClass}";
            var reg = Registry.LocalMachine.OpenSubKey(regBaseName);
            if (reg == null)
            {
                Log.WarnFormat("No registry setting was added for device class {0}." +
                               " Please ensure that registry setting exists, if it does exist then the problem might be in the bit level." +
                               " Check if key exists in HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\OLEforRetail\\ServiceOPOS\\{0} Key", deviceClass);
                return dict;
            }

            reg = reg.OpenSubKey(deviceName);
            if (reg == null)
            {
                Log.WarnFormat("No registry setting was added for device class {0} with the name {1}." +
                               " Please ensure that registry setting exists, if it does exist then the problem might be in the bit level." +
                               " Check if key exists in HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\OLEforRetail\\ServiceOPOS\\{0}\\{1} Key", deviceClass, deviceName);
                return dict;
            }

            Log.Debug("Adding configuration settings from Windows registry");
            foreach (var valueName in reg.GetValueNames())
            {
                var key = valueName.ToUpper();
                var value = reg.GetValue(valueName);
                Log.DebugFormat("{0} = {1} type {2}", key, value, value.GetType().Name);
                dict.Add(key, value);
            }
            return dict;
        }
    }
}
