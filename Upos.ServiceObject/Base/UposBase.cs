using System;
using System.Collections.Generic;
using log4net;
using Upos.ServiceObject.Base.Properties;
using Upos.ServiceObject.Base.UposEvents;

namespace Upos.ServiceObject.Base
{
    public abstract class UposBase : IUposBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UposBase));

        public IReadWindowsUposRegistry WindowsUposRegistry { get; set; } = new RegistryHelper();

        private EventThreadHelper _eventQueue;
        private IUposDevice _device;
        private IUposProperties _props;
        private OpenResultConstants _openResult;

        protected string OpenServiceDeviceClass = "";
        protected string OpenServiceDeviceName = "";

        public int CheckHealth(int Level)
        {
            return SetResultCode(ResultCodeConstants.Illegal);
        }

        public int ClaimDevice(int Timeout)
        {
            if (_props.ByName.Claimed) return SetResultCode(ResultCodeConstants.Success);
            if (Timeout < -1) return SetResultCode(ResultCodeConstants.Illegal);

            try
            {
                if (_device.CanClaimDevice())
                {
                    if (_device.ClaimDevice(TimeSpan.FromMilliseconds(Timeout)))
                    {
                        _props.SetIntProperty(PropertyConstants.PIDX_Claimed, 1);
                        return SetResultCode(ResultCodeConstants.Success);
                    }

                    return SetResultCode(ResultCodeConstants.Timeout);
                }

                return SetResultCode(ResultCodeConstants.Illegal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return SetResultCode(ResultCodeConstants.Failure);
            }
        }

        public int ClearInput()
        {
            ClearInputProperties();
            _eventQueue.Clear();
            return SetResultCode(ResultCodeConstants.Success);
        }

        public int ClearInputProperties()
        {
            _props.ClearInputProperties();
            return SetResultCode(ResultCodeConstants.Success);
        }

        public int ClearOutput()
        {
            return SetResultCode(ResultCodeConstants.Failure);
        }

        public int CloseService()
        {
            if (_props.ByName.State == ServiceStateConstants.OPOS_S_CLOSED)
            {
                return SetResultCode(ResultCodeConstants.Success);
            }

            if (_props.ByName.DeviceEnabled)
            {
                _props.ByName.DeviceEnabled = false;
            }

            if (_props.ByName.Claimed)
            {
                ReleaseDevice();
            }

            DestroyEventQueue();
            _props.ByName.State = ServiceStateConstants.OPOS_S_CLOSED;
            _device.Dispose();
            _device = null;
            return SetResultCode(ResultCodeConstants.Success);
        }

        public int COFreezeEvents(bool Freeze)
        {
            _props.ByName.FreezeEvents = Freeze;
            return SetResultCode(ResultCodeConstants.Success);
        }

        public int GetOpenResult() => (int)_openResult;

        public int OpenService(string deviceClass, string deviceName, object dispatchObject)
        {
            Log.DebugFormat("OpeningService for deviceClass {0} called {1}", deviceClass, deviceName);
            OpenServiceDeviceClass = deviceClass;
            OpenServiceDeviceName = deviceName;

            if (_props == null)
                _props = GetDeviceSpecifcUposProperties();

            Log.Debug("Creating EventDispatcher");
            _eventQueue = new EventThreadHelper(GetDeviceSpecificControlObjectDispatcher(dispatchObject), _props);

            Log.Debug("Getting configuration options from Registry");
            var registryValues = WindowsUposRegistry.GetRegistryValues(OpenServiceDeviceClass, OpenServiceDeviceName);
            if (VerifyDeviceSettings(registryValues))
            {
                _device = GetDevice();
                _openResult = _device.CanCommunicateWithDevice(deviceClass, deviceName, registryValues);
                if (_openResult == OpenResultConstants.OPOS_SUCCESS)
                {
                    Log.Debug("Communication with device succeeded, Opening service is successful");
                    _props.ByName.Claimed = false;
                    _props.ByName.DeviceEnabled = false;
                    _props.ByName.DataEventEnabled = false;
                    _props.ByName.FreezeEvents = false;
                    _props.ByName.State = ServiceStateConstants.OPOS_S_IDLE;
                    _props.ByName.DeviceDescription = GetDeviceDescription();
                    _props.ByName.ServiceObjectVersion = GetImplementingVersion();
                    return SetResultCode(ResultCodeConstants.Success);
                }
                Log.Error("Device Specific check for communicating with device failed. Check configuration values to verify proper values are set to be able to communicate with device");

                return SetResultCode(ResultCodeConstants.NoHardware);
            }
            Log.Error("Device Specific validation of configuration options failed. Please verify that all settings are correct and in proper location in Windows registry");
            _openResult = OpenResultConstants.OPOS_ORS_CONFIG;

            return SetResultCode(ResultCodeConstants.Failure);
        }

        public int ReleaseDevice()
        {
            if (!_props.ByName.Claimed)
            {
                return SetResultCode(ResultCodeConstants.Illegal);
            }

            if (_device.CanReleaseDevice())
            {
                if (_device.ReleaseDevice())
                {
                    ClearInput();
                    _props.ByName.Claimed = false;
                    return SetResultCode(ResultCodeConstants.Success);
                }
                return SetResultCode(ResultCodeConstants.Failure);
            }

            return SetResultCode(ResultCodeConstants.Success);
        }

        #region Statistics

        public int ResetStatistics(string statisticsBuffer)
        {
            return SetResultCode(ResultCodeConstants.Failure);
        }

        public int RetrieveStatistics(ref string pStatisticsBuffer)
        {
            return SetResultCode(ResultCodeConstants.Failure);
        }

        public int UpdateStatistics(string StatisticsBuffer)
        {
            return SetResultCode(ResultCodeConstants.Failure);
        }

        #endregion

        #region Firmware

        public int CompareFirmwareVersion(string firmwareFileName, out int result)
        {
            result = 0;
            return SetResultCode(ResultCodeConstants.Failure);
        }

        public int UpdateFirmware(string FirmwareFileName)
        {
            return SetResultCode(ResultCodeConstants.Failure);
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
            SetResultCode(_props.SetIntProperty(lPropIndex, nNewValue));
        }

        public void SetPropertyString(int lPropIndex, string StringData)
        {
            SetResultCode(_props.SetStringProperty(lPropIndex, StringData));
        }

        #endregion

        protected int SetResultCode(ResultCodeConstants resultCode)
        {
            _props.ByName.ResultCode = resultCode;
            return (int) resultCode;
        }

        protected abstract IUposDevice GetDevice();

        protected abstract IUposProperties GetDeviceSpecifcUposProperties();

        protected abstract string GetDeviceDescription();

        protected abstract int GetImplementingVersion();

        public abstract int DirectIO(int command, ref int numericData, ref string stringData);

        protected abstract bool VerifyDeviceSettings(Dictionary<string, object> deviceSettings);

        protected abstract COPOS GetDeviceSpecificControlObjectDispatcher(object dispatchObject);

        protected void EnqueueEvent(EventArguments dataEvent)
        {
            _eventQueue.EnqueueEvent(dataEvent);
        }

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
}
