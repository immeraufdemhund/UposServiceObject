using Microsoft.Win32;
using System.Collections.Generic;

namespace Upos.ServiceObject
{
    public static class RegistryHelper
    {
        public static Dictionary<string, object> GetRegistryValues(string deviceClass, string deviceName)
        {
            var dict = new Dictionary<string, object>();
            string regBaseName = $@"SOFTWARE\OLEforRetail\ServiceOPOS\{deviceClass}";
            var reg = Registry.LocalMachine.OpenSubKey(regBaseName);
            if (reg == null) return dict;
            reg = reg.OpenSubKey(deviceName);
            if (reg == null) return dict;

            foreach (var valueName in reg.GetValueNames())
            {
                dict.Add(valueName.ToUpper(), reg.GetValue(valueName));
            }
            return dict;
        }
    }
}
