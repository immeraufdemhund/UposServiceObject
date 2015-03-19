using System.Collections.Generic;

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

        int GetIntProperty(int propertyIndex);
        void SetIntProperty(int propertyIndex, int propertyValue);

        string GetStringProperty(int propertyIndex);
        void SetStringProperty(int propertyIndex, string propertyValue);
    }

    internal class UposBaseProperties : IUposProperties
    {
        private readonly Dictionary<int, object> propDictionary;

        public UposBaseProperties()
            : this(new Dictionary<int, object>())
        {
            propDictionary.Add(PropertyConstants.PIDX_ResultCode, 0);
        }

        public UposBaseProperties(Dictionary<int, object> propDictionary)
        {
            this.propDictionary = propDictionary;
        }

        public IUposBase ServiceObject
        {
            get { throw new System.NotImplementedException(); }
        }

        public int GetIntProperty(int propertyIndex)
        {
            if (propDictionary.ContainsKey(propertyIndex))
                return (int)propDictionary[propertyIndex];

            SetIntProperty(PropertyConstants.PIDX_ResultCode, (int)ResultCodeConstants.OPOS_E_FAILURE);
            return -1;
        }

        public void SetIntProperty(int propertyIndex, int propertyValue)
        {
            SetProperty(propertyIndex, propertyValue);
        }

        public string GetStringProperty(int propertyIndex)
        {
            throw new System.NotImplementedException();
        }

        public void SetStringProperty(int propertyIndex, string propertyValue)
        {
            throw new System.NotImplementedException();
        }

        private void SetProperty(int propertyIndex, object propertyValue)
        {
            propDictionary[propertyIndex] = propertyValue;
        }
    }

}
