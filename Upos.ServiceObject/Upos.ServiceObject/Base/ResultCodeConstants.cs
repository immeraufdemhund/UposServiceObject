
namespace Upos.ServiceObject.Base
{
    public enum ResultCodeConstants : int
    {
        /// <summary>
        /// Success
        /// </summary>
        Success = 0,

        /// <summary>
        /// Base number for all error values. Do not use
        /// </summary>
        Oposerr = 100,

        /// <summary>
        /// An attempt was made to access a closed Device
        /// </summary>
        Closed = 1 + Oposerr,

        /// <summary>
        /// An attempt was made to access a Physical Device that is claimed by another Control instance.
        /// The other Control must release the Physical Device before this access may be made.
        /// For exclusive-use devices, the application will also need to claim the Physical Device before the access is legal.
        /// </summary>
        Claimed = 2 + Oposerr,

        /// <summary>
        /// An attempt was made to access an exclusive-use device that must be claimed before the method or property set action can be used.
        /// If the Physical Device is already claimed by another Control instance, then the status E_CLAIMED is returned instead
        /// </summary>
        NotClaimed = 3 + Oposerr,

        /// <summary>
        /// The Control cannot communicate with the Service, normally because of a setup or configuration error.
        /// </summary>
        NoService = 4 + Oposerr,

        /// <summary>
        /// Cannot perform this operation while the Device is disabled
        /// </summary>
        Disabled = 5 + Oposerr,

        /// <summary>
        /// An attempt was made to perform an illegal or unsupported operation with the Device, or an invalid parameter value was used
        /// </summary>
        Illegal = 6 + Oposerr,

        /// <summary>
        /// The Physical Device is not connected to the system or is not powered on
        /// </summary>
        NoHardware = 7 + Oposerr,

        /// <summary>
        /// The Physical Device is off-line.
        /// </summary>
        Offline = 8 + Oposerr,

        /// <summary>
        /// The file name (or other specified value) does not exist.
        /// </summary>
        NoExist = 9 + Oposerr,

        /// <summary>
        /// The file name (or other specified value) already exists.
        /// </summary>
        Exists = 10 + Oposerr,

        /// <summary>
        /// The Device cannot perform the requested procedure, even though the Physical Device is connected to the system, powered on, and on-line
        /// </summary>
        Failure = 11 + Oposerr,

        /// <summary>
        /// The Service timed out waiting for a response from the Physical Device, or the Control timed out waiting for a response from the Service.
        /// </summary>
        Timeout = 12 + Oposerr,

        /// <summary>
        /// The current Service state does not allow this request. For example, if asynchronous output is in progress, certain methods may not be allowed.
        /// </summary>
        Busy = 13 + Oposerr,

        /// <summary>
        /// A device category-specific error condition occured. The error condition code is held in an extended error code.
        /// </summary>
        Extended = 14 + Oposerr,

        /// <summary>
        /// The requested operation can not be performed since it has been deprecated.
        /// </summary>
        Deprecated = 15 + Oposerr,

        /// <summary>
        /// Base for ResultCodeExtendedErrors. Do not use
        /// </summary>
        OposErrExt = 200,

        /// <summary>
        /// At least one of the specified statistics could not be updated
        /// The following applies to ResetStatistics and UpdateStatistics.
        /// </summary>
        EStatsError = 80 + OposErrExt,

        /// <summary>
        /// At least one other statistic is required to be updated in addition to a requested statistic.
        /// The following applies to ResetStatistics and UpdateStatistics.
        /// </summary>
        EStatsDependency = 82 + OposErrExt,

        /// <summary>
        /// The specified firmware file(s) exist, but one or more are either not in the correct format or are corrupt.
        /// The following applies to CompareFirmwareVersion and UpdateFirmware.
        /// </summary>
        EFirmwareBadFile = 81 + OposErrExt,
    }
}
