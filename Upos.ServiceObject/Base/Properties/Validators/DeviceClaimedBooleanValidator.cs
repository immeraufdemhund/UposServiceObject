namespace Upos.ServiceObject.Base.Properties.Validators
{
    public class DeviceClaimedBooleanValidator : IPropertyValidator
    {
        private const int FALSE = 0;

        private readonly IUposProperties _properties;

        public DeviceClaimedBooleanValidator(IUposProperties properties)
        {
            _properties = properties;
        }

        public ResultCodeConstants Validate(object suggestedValue)
        {
            if (suggestedValue.Equals(FALSE)) return ResultCodeConstants.Success;

            return _properties.ByName.Claimed ?
                ResultCodeConstants.Success :
                ResultCodeConstants.Claimed;
        }
    }
}
