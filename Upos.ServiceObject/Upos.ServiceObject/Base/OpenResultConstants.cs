
namespace Upos.ServiceObject.Base
{
    public enum OpenResultConstants
    {
        /// <summary>
        /// The Service Object tried to access an I/O port (for
        /// example, an RS232 port) during Open processing, but
        /// the port that is configured for the DeviceName is
        /// invalid or inaccessible.
        /// </summary>
        NoPort = 401,

        /// <summary>
        /// The Service Object does not support the specified device.
        /// The SO has determined that it does not have the ability
        /// to control the device it is opening. This determination
        /// may be due to an inspection of the registry entries for
        /// the device, or dynamic querying of the device during
        /// Open processing.
        /// </summary>
        OPOS_ORS_NOTSUPPORTED = 402,

        /// <summary>
        /// Configuration information error.
        /// Usually this is due to incomplete configuration of the
        /// registry, such that the SO does not have sufficient or
        /// valid data to open the device
        /// </summary>
        OPOS_ORS_CONFIG = 403,

        /// <summary>
        /// Errors greater than this value are service objectspecific.
        /// If the previous return values do not apply, then the SO
        /// may define additional OpenResult values.
        /// </summary>
        OPOS_ORS_SPECIFIC = 450,
    }
}
