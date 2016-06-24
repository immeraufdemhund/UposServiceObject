namespace Upos.ServiceObject.Base.Properties
{
    internal class NamedUposBaseProperties : INamedUposBaseProperties
    {
        private readonly IUposProperties _uposBaseProperties;

        public NamedUposBaseProperties(UposBaseProperties uposBaseProperties)
        {
            _uposBaseProperties = uposBaseProperties;
        }

        public bool AutoDisable
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_AutoDisable) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_AutoDisable, value ? 1 : 0); }
        }

        public bool CapStatisticsReporting
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_CapStatisticsReporting) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_CapStatisticsReporting, value ? 1 : 0); }
        }

        public bool CapUpdateStatistics
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_CapUpdateStatistics) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_CapUpdateStatistics, value ? 1 : 0); }
        }

        public bool CapCompareFirmwareVersion
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_CapCompareFirmwareVersion) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_CapCompareFirmwareVersion, value ? 1 : 0); }
        }

        public bool CapUpdateFirmware
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_CapUpdateFirmware) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_CapUpdateFirmware, value ? 1 : 0); }
        }

        public bool Claimed
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_Claimed) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_Claimed, value ? 1 : 0); }
        }

        public bool DataEventEnabled
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_DataEventEnabled) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_DataEventEnabled, value ? 1 : 0); }
        }

        public bool DeviceEnabled
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_DeviceEnabled) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_DeviceEnabled, value ? 1 : 0); }
        }

        public bool FreezeEvents
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_FreezeEvents) > 0; }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_FreezeEvents, value ? 1 : 0); }
        }

        public int OutputID
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_OutputID); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_OutputID, value); }
        }

        public int ResultCodeExtended
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_ResultCodeExtended); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_ResultCodeExtended, value); }
        }

        public int ServiceObjectVersion
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_ServiceObjectVersion); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_ServiceObjectVersion, value); }
        }

        public int BinaryConversion
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_BinaryConversion); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_BinaryConversion, value); }
        }

        public int DataCount
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_DataCount); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_DataCount, value); }
        }

        public int PowerNotify
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_PowerNotify); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_PowerNotify, value); }
        }

        public int PowerState
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_PowerState); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_PowerState, value); }
        }

        public int CapPowerReporting
        {
            get { return _uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_CapPowerReporting); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_CapPowerReporting, value); }
        }

        public ResultCodeConstants ResultCode
        {
            get { return (ResultCodeConstants)_uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_ResultCode); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_ResultCode, (int)value); }
        }

        public ServiceStateConstants State
        {
            get { return (ServiceStateConstants)_uposBaseProperties.GetIntProperty(PropertyConstants.PIDX_State); }
            set { _uposBaseProperties.SetIntProperty(PropertyConstants.PIDX_State, (int)value); }
        }

        public string CheckHealthText
        {
            get { return _uposBaseProperties.GetStringProperty(PropertyConstants.PIDX_CheckHealthText); }
            set { _uposBaseProperties.SetStringProperty(PropertyConstants.PIDX_CheckHealthText, value); }
        }

        public string DeviceDescription
        {
            get { return _uposBaseProperties.GetStringProperty(PropertyConstants.PIDX_DeviceDescription); }
            set { _uposBaseProperties.SetStringProperty(PropertyConstants.PIDX_DeviceDescription, value); }
        }

        public string DeviceName
        {
            get { return _uposBaseProperties.GetStringProperty(PropertyConstants.PIDX_DeviceName); }
            set { _uposBaseProperties.SetStringProperty(PropertyConstants.PIDX_DeviceName, value); }
        }

        public string ServiceObjectDescription
        {
            get { return _uposBaseProperties.GetStringProperty(PropertyConstants.PIDX_ServiceObjectDescription); }
            set { _uposBaseProperties.SetStringProperty(PropertyConstants.PIDX_ServiceObjectDescription, value); }
        }
    }
}
