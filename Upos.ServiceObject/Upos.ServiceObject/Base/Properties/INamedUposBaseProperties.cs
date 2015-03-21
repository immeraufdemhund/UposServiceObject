
namespace Upos.ServiceObject.Base.Properties
{
    public interface INamedUposBaseProperties
    {
        bool AutoDisable { get; set; }
        bool CapCompareFirmwareVersion { get; set; }
        bool CapStatisticsReporting { get; set; }
        bool CapUpdateFirmware { get; set; }
        bool CapUpdateStatistics { get; set; }
        bool Claimed { get; set; }
        bool DataEventEnabled { get; set; }
        bool DeviceEnabled { get; set; }
        bool FreezeEvents { get; set; }

        int OutputID { get; set; }
        int ResultCodeExtended { get; set; }
        int ServiceObjectVersion { get; set; }
        int BinaryConversion { get; set; }
        int DataCount { get; set; }
        int PowerNotify { get; set; }
        int PowerState { get; set; }
        int CapPowerReporting { get; set; }

        ResultCodeConstants ResultCode { get; set; }
        ServiceStateConstants State { get; set; }

        string CheckHealthText { get; set; }
        string DeviceDescription { get; set; }
        string DeviceName { get; set; }
        string ServiceObjectDescription { get; set; }
    }
}
