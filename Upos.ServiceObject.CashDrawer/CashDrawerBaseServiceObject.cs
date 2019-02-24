using System;
using log4net;
using Upos.ServiceObject.Base;
using Upos.ServiceObject.Base.Properties;
using Upos.ServiceObject.Base.UposEvents;
using Upos.ServiceObject.CashDrawer.Interfaces;
using Upos.ServiceObject.CashDrawer.PropertyValidators;

namespace Upos.ServiceObject.CashDrawer
{
    public abstract class CashDrawerBaseServiceObject : UposBase, ICashDrawer
    {
        private static ILog Log = LogManager.GetLogger(typeof(CashDrawerBaseServiceObject));

        private ICashDrawerDevice _device;
        protected ICashDrawerProperties _props;

        public int OpenDrawer()
        {
            Log.Debug("Attempting to open cash drawer");
            if (!_props.ByName.DeviceEnabled)
                return SetResultCode(ResultCodeConstants.Disabled);

            try
            {
                _device.OpenDrawer();
                return SetResultCode(ResultCodeConstants.Success);
            }
            catch (Exception e)
            {
                Log.Error("Error opening CashDrawer", e);
                return SetResultCode(ResultCodeConstants.Failure);
            }
        }

        public int WaitForDrawerClose(int beepTimeout, int beepFrequency, int beepDuration, int beepDelay)
        {
            Log.Debug("Waiting for cash drawer to be closed");
            if (!_props.ByName.DeviceEnabled)
                return SetResultCode(ResultCodeConstants.Disabled);

            try
            {
                _device.WaitForDrawerClose();
                return SetResultCode(ResultCodeConstants.Success);
            }
            catch (Exception e)
            {
                Log.Error("Error waiting for drawer to close", e);
                return SetResultCode(ResultCodeConstants.Failure);
            }
        }

        protected override COPOS GetDeviceSpecificControlObjectDispatcher(object dispatchObject)
        {
            return new CashDrawerControlObject(dispatchObject);
        }

        protected override IUposProperties GetDeviceSpecifcUposProperties()
        {
            var properties = new CashDrawerProperties();
            _props = properties;
            _props.PropertyChanged += _props_PropertyChanged;
            return properties;
        }

        private void _props_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CashDrawerProperties.DrawerOpenedPropertyName)
            {
                if (!_device.CanReportStatus) return;
                var newStatus = _props.ByName.DrawerOpened ?
                     (StatusUpdateEventArguments)new StatusEvents.CashDrawerOpened() :
                     (StatusUpdateEventArguments)new StatusEvents.CashDrawerClosed();

                EnqueueEvent(newStatus);
            }
        }

        protected override IUposDevice GetDevice()
        {
            _device = GetCashDrawerDevice();
            var cashDrawerDeviceEnabledPropertyValidator = new CashDrawerDeviceEnabledPropertyValidator(_props, _device);
            _props.SetPropertyValidator(PropertyConstants.PIDX_DeviceEnabled, cashDrawerDeviceEnabledPropertyValidator);

            return _device;
        }

        protected override int GetImplementingVersion() => 1 * 1000000 + 9 * 1000 + 0;

        protected abstract ICashDrawerDevice GetCashDrawerDevice();
    }
}
