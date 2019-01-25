using System;
using System.Collections.Generic;
using Upos.ServiceObject.Base.Properties;
using Upos.ServiceObject.Base.UposEvents;

namespace Upos.ServiceObject.Base
{
    public abstract class UposBase : IUposBase
    {
        private EventThreadHelper _eventQueue;
        protected string OpenServiceDeviceClass = "";
        protected string OpenServiceDeviceName = "";

        protected readonly IUposProperties _props;
        private readonly IUposDevice _device;

        protected UposBase(IUposProperties props, IUposDevice device)
        {
            _props = props;
            _device = device;
        }

        public int CheckHealth(int Level)
        {
            return (int)ResultCodeConstants.Illegal;
        }

        public int ClaimDevice(int Timeout)
        {
            if (_props.ByName.Claimed) return (int) ResultCodeConstants.Success;
            if (Timeout < -1) return (int) ResultCodeConstants.Illegal;

            try
            {
                if (_device.CanClaimDevice())
                {
                    if (_device.ClaimDevice(TimeSpan.FromMilliseconds(Timeout)))
                    {
                        _props.SetIntProperty(PropertyConstants.PIDX_Claimed, 1);
                        return (int)ResultCodeConstants.Success;
                    }

                    return (int) ResultCodeConstants.Timeout;
                }

                return (int)ResultCodeConstants.Illegal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (int)ResultCodeConstants.Failure;
            }
        }

        public int ClearInput()
        {
            ClearInputProperties();
            _eventQueue.Clear();
            return (int) ResultCodeConstants.Success;
        }

        public int ClearInputProperties()
        {
            _props.ClearInputProperties();
            return (int)ResultCodeConstants.Success;
        }

        public int ClearOutput()
        {
            return (int) ResultCodeConstants.Failure;
        }

        public int CloseService()
        {
            if (_props.ByName.State == ServiceStateConstants.OPOS_S_CLOSED)
            {
                return (int) ResultCodeConstants.Success;
            }
            if (_props.GetIntProperty(PropertyConstants.PIDX_Claimed) > 0)
            {
                ReleaseDevice();
            }

            DestroyEventQueue();
            _props.ByName.State = ServiceStateConstants.OPOS_S_CLOSED;
            return (int)ResultCodeConstants.Success;
        }

        public int COFreezeEvents(bool Freeze)
        {
            return (int) ResultCodeConstants.Failure;
        }

        [Obsolete("Check if this is even used, I don't see it in my other code")]
        public int GetOpenResult()
        {
            return 999;
        }

        public int OpenService(string deviceClass, string deviceName, object dispatchObject)
        {
            _eventQueue = new EventThreadHelper(GetDeviceSpecificControlObjectDispatcher(dispatchObject), _props);
            var registryValues = RegistryHelper.GetRegistryValues(OpenServiceDeviceClass, OpenServiceDeviceName);
            VerifyDeviceSettings(registryValues);
            OpenServiceDeviceClass = deviceClass;
            OpenServiceDeviceName = deviceName;
            return 0;
        }

        public int ReleaseDevice()
        {
            if (!_props.ByName.Claimed)
            {
                return (int) ResultCodeConstants.Illegal;
            }

            if (_device.CanReleaseDevice())
            {
                if (_device.ReleaseDevice())
                {
                    ClearInput();
                    _props.ByName.Claimed = false;
                    return (int)ResultCodeConstants.Success;
                }
                return (int)ResultCodeConstants.Failure;
            }

            return (int) ResultCodeConstants.Success;
        }

        #region Statistics

        public int ResetStatistics(string statisticsBuffer)
        {
            return (int) ResultCodeConstants.Failure;
        }

        public int RetrieveStatistics(ref string pStatisticsBuffer)
        {
            return (int)ResultCodeConstants.Failure;
        }

        public int UpdateStatistics(string StatisticsBuffer)
        {
            return (int)ResultCodeConstants.Failure;
        }

        #endregion

        #region Firmware

        public int CompareFirmwareVersion(string firmwareFileName, out int result)
        {
            result = 0;
            return (int)ResultCodeConstants.Failure;
        }

        public int UpdateFirmware(string FirmwareFileName)
        {
            return (int)ResultCodeConstants.Failure;
        }


        #endregion

        #region Properties

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

        #endregion

        public abstract int DirectIO(int command, ref int numericData, ref string stringData);

        protected abstract void VerifyDeviceSettings(Dictionary<string, object> deviceSettings);
        protected abstract COPOS GetDeviceSpecificControlObjectDispatcher(object dispatchObject);

        private void DestroyEventQueue()
        {
            try
            {
                _eventQueue?.Dispose();
            }
            finally
            {
                _eventQueue = null;
            }
        }
    }

    public interface IUposDevice
    {
        bool CanCommunicateWithDevice();
        bool CanClaimDevice();
        bool CanReleaseDevice();
        bool CanEnableDevice();
        bool CanDisableDevice();
        bool ClaimDevice(TimeSpan timeout);
        bool ReleaseDevice();
        bool EnableDevice();
        bool DisableDevice();
    }
}
