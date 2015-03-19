using LONG = System.Int32;

namespace Upos.ServiceObject.Base.Properties
{
    public static class PropertyConstants
    {
        private const LONG PIDX_NUMBER = 0;
        private const LONG PIDX_STRING = 1000000; // 1,000,000

        // * Properties *

        public const LONG PIDX_Claimed = 1 + PIDX_NUMBER;
        public const LONG PIDX_DataEventEnabled = 2 + PIDX_NUMBER;
        public const LONG PIDX_DeviceEnabled = 3 + PIDX_NUMBER;
        public const LONG PIDX_FreezeEvents = 4 + PIDX_NUMBER;
        public const LONG PIDX_OutputID = 5 + PIDX_NUMBER;
        public const LONG PIDX_ResultCode = 6 + PIDX_NUMBER;
        public const LONG PIDX_ResultCodeExtended = 7 + PIDX_NUMBER;
        public const LONG PIDX_ServiceObjectVersion = 8 + PIDX_NUMBER;
        public const LONG PIDX_State = 9 + PIDX_NUMBER;

        //      Added for Release 1.2:
        public const LONG PIDX_AutoDisable = 10 + PIDX_NUMBER;
        public const LONG PIDX_BinaryConversion = 11 + PIDX_NUMBER;
        public const LONG PIDX_DataCount = 12 + PIDX_NUMBER;

        //      Added for Release 1.3:
        public const LONG PIDX_PowerNotify = 13 + PIDX_NUMBER;
        public const LONG PIDX_PowerState = 14 + PIDX_NUMBER;


        // * Capabilities *

        //      Added for Release 1.3:
        public const LONG PIDX_CapPowerReporting = 501 + PIDX_NUMBER;

        //      Added for Release 1.8:
        public const LONG PIDX_CapStatisticsReporting = 502 + PIDX_NUMBER;
        public const LONG PIDX_CapUpdateStatistics = 503 + PIDX_NUMBER;

        //      Added for Release 1.9:
        public const LONG PIDX_CapCompareFirmwareVersion = 504 + PIDX_NUMBER;
        public const LONG PIDX_CapUpdateFirmware = 505 + PIDX_NUMBER;
    }
}
