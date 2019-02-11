using System;
using log4net;
using Upos.ServiceObject.Base;
using Upos.ServiceObject.Base.Properties;
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
                Log.Debug("Drawer Opened");
                _props.ByName.DrawerOpened = true;
                if (_device.CanReportStatus)
                {
                    //var opened = _device.GetStatus();
                    //if (openend) {
                    var opened = new StatusEvents.CashDrawerOpened();
                    //_dispatcher.SendStatusUpdate(opened); }
                }

                return SetResultCode(ResultCodeConstants.Success);
            }
            catch (Exception e)
            {
                Log.Error("Error opening CashDrawer", e);
                return SetResultCode(ResultCodeConstants.Failure); //TODO get error codes
            }
        }

        public int WaitForDrawerClose(int beepTimeout, int beepFrequency, int beepDuration, int beepDelay)
        {
            //Assert Drawer Enabled
            try
            {
                _device.WaitForDrawerClose();
                _props.ByName.DrawerOpened = false;
                if (_device.CanReportStatus)
                {
                    //var opened = _device.GetStatus();
                    //if (closed) {
                    var closed = new StatusEvents.CashDrawerClosed();
                    //_dispatcher.SendStatusUpdate(closed); }
                }

                return SetResultCode(ResultCodeConstants.Success);
            }
            catch (Exception e)
            {
                Log.Error("Error waiting for drawer to close", e);
                return SetResultCode(ResultCodeConstants.Failure); //TODO get error codes
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
            return properties;
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
