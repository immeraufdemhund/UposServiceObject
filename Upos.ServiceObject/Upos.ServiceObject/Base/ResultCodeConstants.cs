namespace Upos.ServiceObject.Base
{
    public enum ResultCodeConstants : int
    {
        OPOSERR = 100, // Base for ResultCode errors.
        OPOSERREXT = 200, // Base for ResultCodeExtendedErrors.

        OPOS_SUCCESS = 0,
        OPOS_E_CLOSED = 1 + OPOSERR,
        OPOS_E_CLAIMED = 2 + OPOSERR,
        OPOS_E_NOTCLAIMED = 3 + OPOSERR,
        OPOS_E_NOSERVICE = 4 + OPOSERR,
        OPOS_E_DISABLED = 5 + OPOSERR,
        OPOS_E_ILLEGAL = 6 + OPOSERR,
        OPOS_E_NOHARDWARE = 7 + OPOSERR,
        OPOS_E_OFFLINE = 8 + OPOSERR,
        OPOS_E_NOEXIST = 9 + OPOSERR,
        OPOS_E_EXISTS = 10 + OPOSERR,
        OPOS_E_FAILURE = 11 + OPOSERR,
        OPOS_E_TIMEOUT = 12 + OPOSERR,
        OPOS_E_BUSY = 13 + OPOSERR,
        OPOS_E_EXTENDED = 14 + OPOSERR,
        OPOS_E_DEPRECATED = 15 + OPOSERR, // (added in 1.11)


        /////////////////////////////////////////////////////////////////////
        // OPOS "ResultCodeExtended" Property Constants
        /////////////////////////////////////////////////////////////////////

        // The following applies to ResetStatistics and UpdateStatistics.
        OPOS_ESTATS_ERROR = 80 + OPOSERREXT, // (added in 1.8)
        OPOS_ESTATS_DEPENDENCY = 82 + OPOSERREXT, // (added in 1.10)
        // The following applies to CompareFirmwareVersion and UpdateFirmware.
        OPOS_EFIRMWARE_BAD_FILE = 81 + OPOSERREXT, // (added in 1.9)
    }
}
