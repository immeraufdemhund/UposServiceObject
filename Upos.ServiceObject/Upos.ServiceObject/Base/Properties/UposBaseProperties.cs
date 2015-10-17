using System;
using System.Collections.Generic;
using System.ComponentModel;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    internal class UposBaseProperties : IUposProperties
    {
        private readonly Dictionary<int, IUposProperty> _propDictionary;
        private readonly IUposBase _uposBase;
        private readonly INamedUposBaseProperties _propertiesByName;

        public UposBaseProperties(IUposBase uposBase)
            : this(new Dictionary<int, IUposProperty>(), uposBase)
        {
        }

        public UposBaseProperties(Dictionary<int, IUposProperty> propDictionary, IUposBase uposBase)
        {
            _propDictionary = propDictionary;
            _uposBase = uposBase;
            _propertiesByName = new NamedUposBaseProperties(this);

            AddProperty("AutoDisable", PropertyConstants.PIDX_AutoDisable, 0);
            AddProperty("BinaryConversion", PropertyConstants.PIDX_BinaryConversion, 0);
            AddProperty("CapCompareFirmwareVersion", PropertyConstants.PIDX_CapCompareFirmwareVersion, 0);
            AddProperty("CapPowerReporting", PropertyConstants.PIDX_CapPowerReporting, 0);
            AddProperty("CapStatisticsReporting", PropertyConstants.PIDX_CapStatisticsReporting, 0);
            AddProperty("CapUpdateFirmware", PropertyConstants.PIDX_CapUpdateFirmware, 0);
            AddProperty("CapUpdateStatistics", PropertyConstants.PIDX_CapUpdateStatistics, 0);
            AddProperty("CheckHealthText", PropertyConstants.PIDX_CheckHealthText, "[Error]");
            AddProperty("Claimed", PropertyConstants.PIDX_Claimed, 0);
            AddProperty("DataCount", PropertyConstants.PIDX_DataCount, 0);
            AddProperty("DataEventEnabled", PropertyConstants.PIDX_DataEventEnabled, 0);
            AddProperty("DeviceDescription", PropertyConstants.PIDX_DeviceDescription, "[Error]");
            AddProperty("DeviceEnabled", PropertyConstants.PIDX_DeviceEnabled, 0);
            AddProperty("DeviceName", PropertyConstants.PIDX_DeviceName, "[Error]");
            AddProperty("FreezeEvents", PropertyConstants.PIDX_FreezeEvents, 0);
            AddProperty("OutputID", PropertyConstants.PIDX_OutputID, 0);
            AddProperty("PowerNotify", PropertyConstants.PIDX_PowerNotify, 0);
            AddProperty("PowerState", PropertyConstants.PIDX_PowerState, 0);
            AddProperty("ResultCode", PropertyConstants.PIDX_ResultCode, ResultCodeConstants.Closed);
            AddProperty("ResultCodeExtended", PropertyConstants.PIDX_ResultCodeExtended, 0);
            AddProperty("ServiceObjectDescription", PropertyConstants.PIDX_ServiceObjectDescription, "[Error]");
            AddProperty("ServiceObjectVersion", PropertyConstants.PIDX_ServiceObjectVersion, 0);
            AddProperty("State", PropertyConstants.PIDX_State, ServiceStateConstants.OPOS_S_CLOSED);
        }

        public IUposBase ServiceObject { get { return _uposBase; } }

        public INamedUposBaseProperties ByName { get { return _propertiesByName; } }

        public int GetIntProperty(int propertyIndex)
        {
            return (int)_propDictionary[propertyIndex].Value;
        }

        public void SetIntProperty(int propertyIndex, int propertyValue)
        {
            SetProperty(propertyIndex, propertyValue);
        }

        public string GetStringProperty(int propertyIndex)
        {
            return (string)_propDictionary[propertyIndex].Value;
        }

        public void SetStringProperty(int propertyIndex, string propertyValue)
        {
            SetProperty(propertyIndex, propertyValue);
        }

        public void SetPropertyValidator(int propertyIndex, IPropertyValidator validatorFunc)
        {
            _propDictionary[propertyIndex].Validator = validatorFunc.Validate;
        }

        public void SetPropertyValidator(int propertyIndex, Func<object, bool> validatorFunc)
        {
            _propDictionary[propertyIndex].Validator = validatorFunc;
        }

        public void AddProperty(string name, int propertyValue, object value)
        {
            _propDictionary.Add(propertyValue, new UposProperty(name, value));
            SetProperty(propertyValue, value);
        }

        private void SetProperty(int propertyIndex, object propertyValue)
        {
            if (_propDictionary[propertyIndex].Validator(propertyValue))
            {
                _propDictionary[propertyIndex].Value = propertyValue;
                FirePropertyChanged(_propDictionary[propertyIndex].Name);
            }
            else
            {
                SetResultCode(ResultCodeConstants.Illegal);
            }
        }

        private void SetResultCode(ResultCodeConstants resultCode)
        {
            _propDictionary[PropertyConstants.PIDX_ResultCode].Value = resultCode;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
