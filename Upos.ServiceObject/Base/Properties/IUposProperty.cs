using System;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    public interface IUposProperty
    {
        string Name { get; set; }

        object Value { get; set; }

        Func<object, bool> Validator { get; set; }
    }

    public class InputProperty : UposProperty
    {
        private readonly object _defaultValue;

        public InputProperty(string name, IPropertyValidator validator, object defaultValue)
            :base(name, validator, defaultValue)
        {
            _defaultValue = defaultValue;
        }
        public void ResetValue()
        {
            Value = _defaultValue;
        }
    }

    public class UposProperty : IUposProperty
    {
        /// <summary>
        /// The Property Name as it is known in the Upos Document
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the property.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Validation rule used to check the value that is suggested to be set
        /// </summary>
        public Func<object, bool> Validator { get; set; }

        public UposProperty()
            : this("", new AlwaysValidPropertyValidator(), null)
        {
        }

        public UposProperty(object defaultValue)
            : this("", new AlwaysValidPropertyValidator(), defaultValue)
        {
        }

        public UposProperty(string name, object defaultValue)
            : this(name, new AlwaysValidPropertyValidator(), defaultValue)
        {
        }

        public UposProperty(string name, IPropertyValidator validator, object defaultValue)
        {
            Name = name;
            Validator = validator.Validate;
            Value = defaultValue;
        }
    }
}
