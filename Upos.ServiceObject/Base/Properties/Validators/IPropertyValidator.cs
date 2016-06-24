namespace Upos.ServiceObject.Base.Properties.Validators
{
    public interface IPropertyValidator
    {
        /// <summary>
        /// Accepts a value to be validated against
        /// </summary>
        /// <param name="suggestedValue">The new value that is suggested to be set</param>
        /// <returns>true if the suggested value is acceptable</returns>
        bool Validate(object suggestedValue);
    }

    internal class AlwaysValidPropertyValidator : IPropertyValidator
    {

        public bool Validate(object suggestedValue)
        {
            return true;
        }
    }

}
