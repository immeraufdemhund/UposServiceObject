using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    public abstract class UposBaseProperties : IUposProperties
    {
        public INamedUposBaseProperties ByName { get; }

        protected const int PIDX_NUMBER = 0;
        protected const int PIDX_STRING = 1000000;

        private readonly Dictionary<int, IUposProperty> _propDictionary;

        protected UposBaseProperties()
        {
            _propDictionary = new Dictionary<int, IUposProperty>();
            ByName = new NamedUposBaseProperties(this);

            AddAllBaseProperties();
            AddDeviceSpecificProperties();
            AddGenericValidators();
            ReplaceValidators();
        }

        public int GetIntProperty(int propertyIndex)
        {
            return (int)_propDictionary[propertyIndex].Value;
        }

        public ResultCodeConstants SetIntProperty(int propertyIndex, int propertyValue)
        {
            return SetProperty(propertyIndex, propertyValue);
        }

        public string GetStringProperty(int propertyIndex)
        {
            return (string)_propDictionary[propertyIndex].Value;
        }

        public ResultCodeConstants SetStringProperty(int propertyIndex, string propertyValue)
        {
            return SetProperty(propertyIndex, propertyValue);
        }

        public void SetPropertyValidator(int propertyIndex, IPropertyValidator validatorFunc)
        {
            _propDictionary[propertyIndex].Validator = validatorFunc.Validate;
        }

        public void SetPropertyValidator(int propertyIndex, Func<object, ResultCodeConstants> validatorFunc)
        {
            _propDictionary[propertyIndex].Validator = validatorFunc;
        }

        public void AddProperty(string name, int propertyValue, object value)
        {
            _propDictionary.Add(propertyValue, new UposProperty(name, value));
        }

        public void AddInputProperty(string name, int propertyIndex, object value)
        {
            _propDictionary.Add(propertyIndex, new InputProperty(name, new AlwaysValidPropertyValidator(), value));
        }

        public void ClearInputProperties()
        {
            foreach (var propDictionaryValue in _propDictionary.Values.OfType<InputProperty>())
            {
                propDictionaryValue.ResetValue();
            }
        }

        private ResultCodeConstants SetProperty(int propertyIndex, object propertyValue)
        {
            if (_propDictionary[propertyIndex].Validator(propertyValue) == ResultCodeConstants.Success)
            {
                _propDictionary[propertyIndex].Value = propertyValue;
                FirePropertyChanged(_propDictionary[propertyIndex].Name);
                return ResultCodeConstants.Success;
            }

            return ResultCodeConstants.Illegal;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void FirePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void AddAllBaseProperties()
        {
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

        private void AddGenericValidators()
        {
            SetPropertyValidator(PropertyConstants.PIDX_DeviceEnabled, new DeviceClaimedBooleanValidator(this));
        }

        protected abstract void AddDeviceSpecificProperties();
        protected abstract void ReplaceValidators();
    }
}
