using Upos.ServiceObject.Base;
using Upos.ServiceObject.Base.Properties;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.CashDrawer.PropertyValidators
{
    public class CashDrawerDeviceEnabledPropertyValidator : IPropertyValidator
    {
        private readonly IUposProperties _properties;

        public CashDrawerDeviceEnabledPropertyValidator(IUposProperties properties)
        {
            _properties = properties;
        }

        public ResultCodeConstants Validate(object suggestedValue)
        {
            return _properties.ByName.State == ServiceStateConstants.OPOS_S_CLOSED ?
                ResultCodeConstants.Closed :
                ResultCodeConstants.Success;
        }
    }
}
