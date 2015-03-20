using System;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    public class IUposPropertiesFactory
    {
        public static IUposProperties Create()
        {
            return new UposBaseProperties();
        }
    }

    public interface IUposProperties
    {
        IUposBase ServiceObject { get; }

        void AddProperty(int propertyValue, object value);

        int GetIntProperty(int propertyIndex);
        void SetIntProperty(int propertyIndex, int propertyValue);

        string GetStringProperty(int propertyIndex);
        void SetStringProperty(int propertyIndex, string propertyValue);

        void SetPropertyValidator(int propertyIndex, IPropertyValidator validatorFunc);
        void SetPropertyValidator(int propertyIndex, Func<object, bool> validatorFunc);
    }
}
