using System.Runtime.InteropServices;
namespace Upos.ServiceObject.Base
{
    public interface IUposBase
    {
        /// <summary>
        /// Called to test the state of a device
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        int CheckHealth([In] int level);

        /// <summary>
        /// Called to request exclusive access to the device.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int ClaimDevice([In] int timeout);

        /// <summary>
        /// Called to clear all device input that has been enqueued. 
        /// </summary>
        /// <returns></returns>
        int ClearInput();

        /// <summary>
        /// Called to clear all input properties that have been populated by the last DataEvent or ErrorEvent.
        /// </summary>
        /// <returns></returns>
        int ClearInputProperties();

        /// <summary>
        /// Called to clear all buffered output data, including all asynchronous output. Also, when possible, halts outputs that are in progress.
        /// </summary>
        /// <returns></returns>
        int ClearOutput();

        /// <summary>
        /// Called to release the device and its resources.
        /// </summary>
        /// <returns></returns>
        int CloseService();

        /// <summary>
        /// This method is for internal use by the Control Object.
        /// </summary>
        /// <param name="freeze">The Freeze parameter is TRUE / VARIANT_TRUE when event firing must be frozen, and FALSE / VARIANT_FALSE when event firing is reenabled.</param>
        /// <returns></returns>
        int COFreezeEvents([In, MarshalAs(UnmanagedType.VariantBool)] bool freeze);

        /// <summary>
        /// This method determines whether the version of the firmware contained in the specified file is newer than, older than, or the same as the version of the firmware in the physical device
        /// </summary>
        /// <param name="firmwareFileName"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        int CompareFirmwareVersion([In, MarshalAs(UnmanagedType.BStr)] string firmwareFileName, [Out] out int result);

        /// <summary>
        /// Call to communicate directly with the Service Object
        /// </summary>
        /// <param name="command"></param>
        /// <param name="numericData"></param>
        /// <param name="stringData"></param>
        /// <returns></returns>
        int DirectIO([In] int command, [In, Out] ref int numericData, [In, Out, MarshalAs(UnmanagedType.BStr)]  ref string stringData);

        /// <summary>
        /// This method is for internal use by the Control Object. It is optional.
        /// If a Service Object’s OpenService method returns a status other than
        /// OPOS_SUCCESS, and it has implemented this method, then the Control Object
        /// calls this method to set its OpenResult property.
        /// The Service Object may select one of the values given in the OPOS.H header file,
        /// or return a Service Object-specific value.
        /// </summary>
        /// <returns></returns>
        int GetOpenResult();

        /// <summary>
        /// Call to open a device for subsequent I/O.
        /// </summary>
        /// <param name="deviceClass">Contains the requested device class, which are given in the header file OPOS.HI</param>
        /// <param name="deviceName">Contains the Device Name to be managed by this Service Object. The relationship between the device /// name and physical devices is determined by entries within the operating system registry; a setup or configuration utility maintains these entries. (See the “Application Programmer’s Guide” appendix “OPOS Registry Usage.”)</param>
        /// <param name="dispatchObject">Points to the Control Object’s dispatch interface, which contains the event request methods.</param>
        /// <returns></returns>
        int OpenService([In, MarshalAs(UnmanagedType.BStr)] string deviceClass, [In, MarshalAs(UnmanagedType.BStr)] string deviceName, [In, MarshalAs(UnmanagedType.IDispatch)] object dispatchObject);

        /// <summary>
        /// Called to release exclusive access to the device.
        /// </summary>
        /// <returns></returns>
        int ReleaseDevice();

        /// <summary>
        /// Resets the defined resettable statistics in a device.
        /// </summary>
        /// <param name="statisticsBuffer"></param>
        /// <returns></returns>
        int ResetStatistics([In, MarshalAs(UnmanagedType.BStr)] string statisticsBuffer);

        int RetrieveStatistics([In, Out, MarshalAs(UnmanagedType.BStr)] ref string pStatisticsBuffer);

        int UpdateFirmware([In, MarshalAs(UnmanagedType.BStr)] string firmwareFileName);

        int UpdateStatistics([In, MarshalAs(UnmanagedType.BStr)] string statisticsBuffer);

        int GetPropertyNumber([In] int lPropIndex);

        string GetPropertyString([In] int lPropIndex);

        void SetPropertyNumber([In] int lPropIndex, [In] int nNewValue);

        void SetPropertyString([In] int lPropIndex, [In, MarshalAs(UnmanagedType.BStr)] string stringData);
    }
}
