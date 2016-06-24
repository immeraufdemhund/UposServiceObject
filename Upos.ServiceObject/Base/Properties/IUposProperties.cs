using System;
using System.ComponentModel;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    public class IUposPropertiesFactory
    {
        public static IUposProperties Create(IUposBase uposBase)
        {
            return new UposBaseProperties(uposBase);
        }
    }

    public interface IUposProperties : INotifyPropertyChanged
    {
        IUposBase ServiceObject { get; }
        INamedUposBaseProperties ByName { get; }

        void AddProperty(string name, int propertyValue, object value);

        int GetIntProperty(int propertyIndex);
        void SetIntProperty(int propertyIndex, int propertyValue);

        string GetStringProperty(int propertyIndex);
        void SetStringProperty(int propertyIndex, string propertyValue);

        void SetPropertyValidator(int propertyIndex, IPropertyValidator validatorFunc);
        void SetPropertyValidator(int propertyIndex, Func<object, bool> validatorFunc);
    }
}
