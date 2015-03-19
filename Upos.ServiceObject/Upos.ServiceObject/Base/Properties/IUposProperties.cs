namespace Upos.ServiceObject.Base.Properties
{
    public interface IUposProperties
    {
        IUposBase ServiceObject { get; }

        int GetIntProperty(int propertyIndex);
        void SetIntProperty(int propertyIndex, int propertyValue);

        string GetStringProperty(int propertyIndex);
        void SetStringProperty(int propertyIndex, string propertyValue);
    }
}
