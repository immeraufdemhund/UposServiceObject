namespace Upos.ServiceObject.Base
{
    public enum StatusUpdateEventConstants : int
    {
        /// <summary>
        /// The device is powered on and ready for use.
        /// Can be returned if CapPowerReporting = OPOS_PR_STANDARD or OPOS_PR_ADVANCED.
        /// </summary>
        PowerOnline = 2001,

        /// <summary>
        /// The device is off or detached from the terminal.
        /// Can only be returned if CapPowerReporting = OPOS_PR_ADVANCED.
        /// </summary>
        PowerOff = 2002,

        /// <summary>
        /// The device is powered on but is either not ready or not able to respond to requests.
        /// Can only be returned if CapPowerReporting = OPOS_PR_ADVANCED.
        /// </summary>
        PowerOffline = 2003,

        /// <summary>
        /// The device is either off or offline.
        /// Can only be returned if CapPowerReporting = OPOS_PR_STANDARD.
        /// </summary>
        PowerOff_Offline = 2004,

        /// <summary>
        /// The update firmware process has successfully
        /// completed 1 to 100 percent of the total operation
        /// Add percentage to this number
        /// </summary>
        UpdateFirmwareProgress = 2100,

        /// <summary>
        /// The update firmware process has completed successfully. The value of this constant is identical to OPOS_SUE_UF_PROGRESS + 100
        /// </summary>
        UpdateFirmwareComplete = 2200,

        /// <summary>
        /// The update firmware process succeeded, however the Service
        /// and/or the physical device cannot be returned to
        /// the state they were in before the update firmware
        /// process started. The Service has restored all properties
        /// to their default initialization values.
        /// To ensure consistent Service and physical device states,
        /// the application needs to Close the Service, then Open,
        /// Claim, and enable again, and also restore all custom
        /// application settings.
        /// </summary>
        UpdateFirmwareCompleteDeviceNotRestored = 2205,

        /// <summary>
        /// The update firmware process failed but the device is still operational.
        /// </summary>
        UpdateFirmwareFailedDeviceOk = 2201,

        /// <summary>
        /// The update firmware process failed and the device is 
        /// neither usable nor recoverable through software. The
        /// device requires service to be returned to an operational state.
        /// </summary>
        UpdateFirmwareFailedDeviceUnrecoverable = 2202,

        /// <summary>
        /// The update firmware process failed and the device will not be operational until another attempt to update the firmware is successful.
        /// </summary>
        UpdateFirmwareFailedDeviceNeedsFirmware = 2203,

        /// <summary>
        /// The update firmware process failed and the device is in an indeterminate state
        /// </summary>
        UpdateFirmwareFailedDeviceUnknown = 2204
    }
}
