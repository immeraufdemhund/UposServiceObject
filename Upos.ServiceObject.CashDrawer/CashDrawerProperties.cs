﻿using Upos.ServiceObject.Base.Properties;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.CashDrawer
{
    public class CashDrawerProperties : UposBaseProperties
    {
        private const int PIDX_CASH = 1000;

        public const int PIDXCash_CapStatus = PIDX_CASH + PIDX_NUMBER + 501;
        public const int PIDXCash_CapStatusMultiDrawerDetect = PIDX_CASH + PIDX_NUMBER + 502;
        public const int PIDXCash_DrawerOpened = PIDX_CASH + PIDX_NUMBER + 1;

        protected override void AddDeviceSpecificProperties()
        {
            AddProperty("CapStatus", PIDXCash_CapStatus, 0);
            AddProperty("CapStatusMultiDrawerDetect", PIDXCash_CapStatusMultiDrawerDetect, 0);
            AddProperty("DrawerOpened", PIDXCash_DrawerOpened, 0);
        }

        protected override void ReplaceValidators()
        {
            SetPropertyValidator(PropertyConstants.PIDX_DeviceEnabled, new AlwaysValidPropertyValidator());
        }
    }
}
