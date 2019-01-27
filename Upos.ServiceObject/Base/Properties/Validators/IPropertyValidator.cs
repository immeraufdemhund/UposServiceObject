namespace Upos.ServiceObject.Base.Properties.Validators
{
    public interface IPropertyValidator
    {
        /// <summary>
        /// Accepts a value to be validated against
        /// </summary>
        /// <param name="suggestedValue">The new value that is suggested to be set</param>
        /// <returns>true if the suggested value is acceptable</returns>
        ResultCodeConstants Validate(object suggestedValue);
    }
}
