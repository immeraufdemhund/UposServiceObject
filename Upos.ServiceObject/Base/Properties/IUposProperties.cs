using System;
using System.ComponentModel;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    public interface IUposProperties : INotifyPropertyChanged
    {
        INamedUposBaseProperties ByName { get; }

        void AddProperty(string name, int propertyValue, object value);

        int GetIntProperty(int propertyIndex);
        ResultCodeConstants SetIntProperty(int propertyIndex, int propertyValue);

        string GetStringProperty(int propertyIndex);
        ResultCodeConstants SetStringProperty(int propertyIndex, string propertyValue);

        void SetPropertyValidator(int propertyIndex, IPropertyValidator validatorFunc);
        void SetPropertyValidator(int propertyIndex, Func<object, ResultCodeConstants> validatorFunc);
        void FirePropertyChanged(string propertyName);
        void ClearInputProperties();
    }
}
