using Upos.ServiceObject.Base.Properties;

namespace Upos.ServiceObject.Base
{
    public abstract class UposBase : IUposBase
    {
        protected readonly IUposProperties _props;

        protected UposBase()
        {
            _props = IUposPropertiesFactory.Create(this);
        }

        public int CheckHealth(int Level)
        {
            throw new System.NotImplementedException();
        }

        public int ClaimDevice(int Timeout)
        {
            throw new System.NotImplementedException();
        }

        public int ClearInput()
        {
            throw new System.NotImplementedException();
        }

        public int ClearInputProperties()
        {
            throw new System.NotImplementedException();
        }

        public int ClearOutput()
        {
            throw new System.NotImplementedException();
        }

        public int CloseService()
        {
            return 0;
        }

        public int COFreezeEvents(bool Freeze)
        {
            throw new System.NotImplementedException();
        }

        public int CompareFirmwareVersion(string firmwareFileName, out int result)
        {
            throw new System.NotImplementedException();
        }

        public int DirectIO(int command, ref int numericData, ref string stringData)
        {
            throw new System.NotImplementedException();
        }

        public int GetOpenResult()
        {
            return 0;
        }

        public int OpenService(string deviceClass, string deviceName, object dispatchObject)
        {
            return 0;
        }

        public int ReleaseDevice()
        {
            throw new System.NotImplementedException();
        }

        public int ResetStatistics(string statisticsBuffer)
        {
            throw new System.NotImplementedException();
        }

        public int RetrieveStatistics(ref string pStatisticsBuffer)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateFirmware(string FirmwareFileName)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateStatistics(string StatisticsBuffer)
        {
            throw new System.NotImplementedException();
        }

        public int GetPropertyNumber(int lPropIndex)
        {
            return _props.GetIntProperty(lPropIndex);
        }

        public string GetPropertyString(int lPropIndex)
        {
            return _props.GetStringProperty(lPropIndex);
        }

        public void SetPropertyNumber(int lPropIndex, int nNewValue)
        {
            _props.SetIntProperty(lPropIndex, nNewValue);
        }

        public void SetPropertyString(int lPropIndex, string StringData)
        {
            _props.SetStringProperty(lPropIndex, StringData);
        }
    }
}
