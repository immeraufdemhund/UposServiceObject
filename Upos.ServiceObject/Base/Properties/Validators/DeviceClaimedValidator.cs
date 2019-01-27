namespace Upos.ServiceObject.Base.Properties.Validators
{
    public class DeviceClaimedValidator : IPropertyValidator
    {
        private readonly IUposProperties _properties;

        public DeviceClaimedValidator(IUposProperties properties)
        {
            _properties = properties;
        }

        public ResultCodeConstants Validate(object suggestedValue)
        {
            return _properties.ByName.Claimed ?
                ResultCodeConstants.Success :
                ResultCodeConstants.Claimed;
        }
    }
}
