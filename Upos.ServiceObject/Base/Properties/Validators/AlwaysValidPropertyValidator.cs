namespace Upos.ServiceObject.Base.Properties.Validators
{
    public class AlwaysValidPropertyValidator : IPropertyValidator
    {
        public ResultCodeConstants Validate(object suggestedValue)
        {
            return ResultCodeConstants.Success;
        }
    }
}
