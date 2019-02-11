using System;
using Upos.ServiceObject.Base;
using Upos.ServiceObject.Base.Properties;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.CashDrawer.PropertyValidators
{
    public class CashDrawerDeviceEnabledPropertyValidator : IPropertyValidator
    {
        private readonly IUposProperties _properties;
        private readonly ICashDrawerDevice _device;

        public CashDrawerDeviceEnabledPropertyValidator(IUposProperties properties, ICashDrawerDevice device)
        {
            _properties = properties;
            _device = device;
        }

        public ResultCodeConstants Validate(object suggestedValue)
        {
            if (_properties.ByName.State == ServiceStateConstants.OPOS_S_CLOSED)
                return ResultCodeConstants.Closed;

            var requestEnabled = Convert.ToBoolean(suggestedValue);
            if (requestEnabled)
            {
                if (!_device.CanEnableDevice())
                    return ResultCodeConstants.Failure;

                return _device.EnableDevice() ? ResultCodeConstants.Success : ResultCodeConstants.Failure;
            }

            if (!_device.CanDisableDevice())
                return ResultCodeConstants.Failure;

            return _device.DisableDevice() ? ResultCodeConstants.Success : ResultCodeConstants.Failure;
        }
    }
}
