using System;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    public interface IUposProperty
    {
        object Value { get; set; }

        Func<object, bool> Validator { get; set; }
    }

    public class UposProperty : IUposProperty
    {
        /// <summary>
        /// The value of the property.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Validation rule used to check the value that is suggested to be set
        /// </summary>
        public Func<object, bool> Validator { get; set; }

        public UposProperty()
            : this(new AlwaysValidPropertyValidator(), null)
        {
        }

        public UposProperty(object defaultValue)
            : this(new AlwaysValidPropertyValidator(), defaultValue)
        {
        }

        public UposProperty(IPropertyValidator validator, object defaultValue)
        {
            Validator = validator.Validate;
            Value = defaultValue;
        }

    }
}