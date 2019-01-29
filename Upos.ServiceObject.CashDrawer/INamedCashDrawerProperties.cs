using Upos.ServiceObject.Base;
using Upos.ServiceObject.Base.Properties;

namespace Upos.ServiceObject.CashDrawer
{
    public interface INamedCashDrawerProperties : INamedUposBaseProperties
    {
        bool CapStatus { get; set; }
        bool CapStatusMultiDrawerDetect { get; set; }
        bool DrawerOpened { get; set; }
    }

    internal class NamedCashDrawerProperties : INamedCashDrawerProperties
    {
        private readonly INamedUposBaseProperties _baseNamedProperties;
        private readonly IUposProperties _baseProperties;

        public NamedCashDrawerProperties(IUposProperties baseProperties)
        {
            _baseProperties = baseProperties;
            _baseNamedProperties = baseProperties.ByName;
        }

        public bool CapStatus
        {
            get => _baseProperties.GetIntProperty(CashDrawerProperties.PIDXCash_CapStatus) > 0;
            set => _baseProperties.SetIntProperty(CashDrawerProperties.PIDXCash_CapStatus, value ? 1 : 0);
        }

        public bool CapStatusMultiDrawerDetect
        {
            get => _baseProperties.GetIntProperty(CashDrawerProperties.PIDXCash_CapStatusMultiDrawerDetect) > 0;
            set => _baseProperties.SetIntProperty(CashDrawerProperties.PIDXCash_CapStatusMultiDrawerDetect, value ? 1 : 0);
        }

        public bool DrawerOpened
        {
            get => _baseProperties.GetIntProperty(CashDrawerProperties.PIDXCash_DrawerOpened) > 0;
            set => _baseProperties.SetIntProperty(CashDrawerProperties.PIDXCash_DrawerOpened, value ? 1 : 0);
        }

        public bool AutoDisable
        {
            get => _baseNamedProperties.AutoDisable;
            set => _baseNamedProperties.AutoDisable = value;
        }

        public bool CapCompareFirmwareVersion
        {
            get => _baseNamedProperties.CapCompareFirmwareVersion;
            set => _baseNamedProperties.CapCompareFirmwareVersion = value;
        }

        public bool CapStatisticsReporting
        {
            get => _baseNamedProperties.CapStatisticsReporting;
            set => _baseNamedProperties.CapStatisticsReporting = value;
        }

        public bool CapUpdateFirmware
        {
            get => _baseNamedProperties.CapUpdateFirmware;
            set => _baseNamedProperties.CapUpdateFirmware = value;
        }

        public bool CapUpdateStatistics
        {
            get => _baseNamedProperties.CapUpdateStatistics;
            set => _baseNamedProperties.CapUpdateStatistics = value;
        }

        public bool Claimed
        {
            get => _baseNamedProperties.Claimed;
            set => _baseNamedProperties.Claimed = value;
        }

        public bool DataEventEnabled
        {
            get => _baseNamedProperties.DataEventEnabled;
            set => _baseNamedProperties.DataEventEnabled = value;
        }

        public bool DeviceEnabled
        {
            get => _baseNamedProperties.DeviceEnabled;
            set => _baseNamedProperties.DeviceEnabled = value;
        }

        public bool FreezeEvents
        {
            get => _baseNamedProperties.FreezeEvents;
            set => _baseNamedProperties.FreezeEvents = value;
        }

        public int OutputID
        {
            get => _baseNamedProperties.OutputID;
            set => _baseNamedProperties.OutputID = value;
        }

        public int ResultCodeExtended
        {
            get => _baseNamedProperties.ResultCodeExtended;
            set => _baseNamedProperties.ResultCodeExtended = value;
        }

        public int ServiceObjectVersion
        {
            get => _baseNamedProperties.ServiceObjectVersion;
            set => _baseNamedProperties.ServiceObjectVersion = value;
        }

        public int BinaryConversion
        {
            get => _baseNamedProperties.BinaryConversion;
            set => _baseNamedProperties.BinaryConversion = value;
        }

        public int DataCount
        {
            get => _baseNamedProperties.DataCount;
            set => _baseNamedProperties.DataCount = value;
        }

        public int PowerNotify
        {
            get => _baseNamedProperties.PowerNotify;
            set => _baseNamedProperties.PowerNotify = value;
        }

        public int PowerState
        {
            get => _baseNamedProperties.PowerState;
            set => _baseNamedProperties.PowerState = value;
        }

        public int CapPowerReporting
        {
            get => _baseNamedProperties.CapPowerReporting;
            set => _baseNamedProperties.CapPowerReporting = value;
        }

        public ResultCodeConstants ResultCode
        {
            get => _baseNamedProperties.ResultCode;
            set => _baseNamedProperties.ResultCode = value;
        }

        public ServiceStateConstants State
        {
            get => _baseNamedProperties.State;
            set => _baseNamedProperties.State = value;
        }

        public string CheckHealthText
        {
            get => _baseNamedProperties.CheckHealthText;
            set => _baseNamedProperties.CheckHealthText = value;
        }

        public string DeviceDescription
        {
            get => _baseNamedProperties.DeviceDescription;
            set => _baseNamedProperties.DeviceDescription = value;
        }

        public string DeviceName
        {
            get => _baseNamedProperties.DeviceName;
            set => _baseNamedProperties.DeviceName = value;
        }

        public string ServiceObjectDescription
        {
            get => _baseNamedProperties.ServiceObjectDescription;
            set => _baseNamedProperties.ServiceObjectDescription = value;
        }
    }
}
