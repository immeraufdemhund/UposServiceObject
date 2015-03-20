using System;
using System.Collections.Generic;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    internal class UposBaseProperties : IUposProperties
    {
        private readonly Dictionary<int, IUposProperty> propDictionary;

        public UposBaseProperties()
            : this(new Dictionary<int, IUposProperty>())
        {
            AddProperty(PropertyConstants.PIDX_ResultCode, ResultCodeConstants.Closed);
            AddProperty(PropertyConstants.PIDX_State, ServiceStateConstants.OPOS_S_CLOSED);
        }

        public UposBaseProperties(Dictionary<int, IUposProperty> propDictionary)
        {
            this.propDictionary = propDictionary;
        }

        public IUposBase ServiceObject
        {
            get { throw new System.NotImplementedException(); }
        }

        public int GetIntProperty(int propertyIndex)
        {
            return (int)propDictionary[propertyIndex].Value;
        }

        public void SetIntProperty(int propertyIndex, int propertyValue)
        {
            SetProperty(propertyIndex, propertyValue);
        }

        public string GetStringProperty(int propertyIndex)
        {
            return (string)propDictionary[propertyIndex].Value;
        }

        public void SetStringProperty(int propertyIndex, string propertyValue)
        {
            SetProperty(propertyIndex, propertyValue);
        }

        public void SetPropertyValidator(int propertyIndex, IPropertyValidator validatorFunc)
        {
            propDictionary[propertyIndex].Validator = validatorFunc.Validate;
        }

        public void SetPropertyValidator(int propertyIndex, Func<object, bool> validatorFunc)
        {
            propDictionary[propertyIndex].Validator = validatorFunc;
        }

        public void AddProperty(int propertyValue, object value)
        {
            propDictionary.Add(propertyValue, new UposProperty(value));
            SetProperty(propertyValue, value);
        }

        private void SetProperty(int propertyIndex, object propertyValue)
        {
            if (propDictionary[propertyIndex].Validator(propertyValue))
                propDictionary[propertyIndex].Value = propertyValue;
            else
                SetResultCode(ResultCodeConstants.Illegal);
        }

        private void SetResultCode(ResultCodeConstants resultCode)
        {
            propDictionary[PropertyConstants.PIDX_ResultCode].Value = resultCode;
        }
    }
}
