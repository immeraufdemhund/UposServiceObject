using FluentAssertions;
using NUnit.Framework;
using System;

namespace Upos.ServiceObject.Base.Properties
{
    [TestFixture]
    public class IUposPropertiesTests
    {
        private const int FakeIntPropertyIndex = -1;
        private const int FakeIntPropertyValue = 42;
        private const int FakeStringPropertyIndex = -2;
        private const string FakeStringPropertyValue = "Hello World";

        private IUposProperties _props;

        [SetUp]
        public void Setup()
        {
            _props = IUposPropertiesFactory.Create(null);
            _props.AddProperty("FakePropertyInt", FakeIntPropertyIndex, FakeIntPropertyValue);
            _props.AddProperty("FakePropertyString", FakeStringPropertyIndex, FakeStringPropertyValue);
        }

        [Test]
        public void ResultCode_Default_Is_E_Closed()
        {
            _props.ByName.ResultCode
                .Should()
                .Be(ResultCodeConstants.Closed, "because default value before Open is E_Closed (see section A-5)");
        }

        [Test]
        public void State_Default_Is_S_Closed()
        {
            _props.ByName.State
                .Should()
                .Be(ServiceStateConstants.OPOS_S_CLOSED, "because default value before Open is S_Closed (see section A-5)");
        }

        [Test]
        public void WhenSettingIntValue_AndValidationFails_PropertyIsNotSet_And_ResultCodeIsSet_ToIllegal()
        {
            _props.SetPropertyValidator(FakeIntPropertyIndex, x => (int)x > 0);

            _props.SetIntProperty(FakeIntPropertyIndex, -1);

            _props.GetIntProperty(FakeIntPropertyIndex)
                .Should()
                .Be(FakeIntPropertyValue, "because the value should not have been set");

            _props.ByName.ResultCode
                .Should()
                .Be(ResultCodeConstants.Illegal,
                    "because when setting an illegal value to a property, the result code is set to Illegal");
        }

        [Test]
        public void WhenSettingStringValue_AndValidationFails_PropertyIsNotSet_And_ResultCodeIsSet_ToIllegal()
        {
            _props.SetPropertyValidator(FakeStringPropertyIndex, x => ((string)x).Length > 0);

            _props.SetStringProperty(FakeStringPropertyIndex, "");

            _props.GetStringProperty(FakeStringPropertyIndex)
                .Should()
                .Be(FakeStringPropertyValue, "because the value should not have been set");

            _props.ByName.ResultCode
                .Should()
                .Be(ResultCodeConstants.Illegal,
                    "because when setting an illegal value to a property, the result code is set to Illegal");
        }

        [Test]
        public void WhenSettingValue_PropertyChangedEvent_IsFired()
        {
            _props.MonitorEvents();
            _props.ByName.AutoDisable = true;
            _props.ByName.BinaryConversion = 1;
            _props.ByName.CapCompareFirmwareVersion = true;
            _props.ByName.CapPowerReporting = 1;
            _props.ByName.CapStatisticsReporting = true;
            _props.ByName.CapUpdateFirmware = true;
            _props.ByName.CapUpdateStatistics = true;
            _props.ByName.CheckHealthText = "HEALTHY";
            _props.ByName.Claimed = true;
            _props.ByName.DataCount = 1;
            _props.ByName.DataEventEnabled = true;
            _props.ByName.DeviceDescription = "ServiceObject";
            _props.ByName.DeviceEnabled = true;
            _props.ByName.DeviceName = "Name";
            _props.ByName.FreezeEvents = true;
            _props.ByName.OutputID = 1;
            _props.ByName.PowerNotify = 1;
            _props.ByName.PowerState = 1;
            _props.ByName.ResultCode = ResultCodeConstants.Busy;
            _props.ByName.ResultCodeExtended = 1;
            _props.ByName.ServiceObjectDescription = "SO Description";
            _props.ByName.ServiceObjectVersion = 1;
            _props.ByName.State = ServiceStateConstants.OPOS_S_BUSY;

            _props.ShouldRaisePropertyChangeFor(x => x.ByName.AutoDisable);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.BinaryConversion);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.CapCompareFirmwareVersion);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.CapPowerReporting);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.CapStatisticsReporting);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.CapUpdateFirmware);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.CapUpdateStatistics);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.CheckHealthText);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.Claimed);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.DataCount);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.DataEventEnabled);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.DeviceDescription);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.DeviceEnabled);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.DeviceName);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.FreezeEvents);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.OutputID);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.PowerNotify);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.PowerState);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.ResultCode);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.ResultCodeExtended);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.ServiceObjectDescription);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.ServiceObjectVersion);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.State);
        }

        [Test]
        public void WhenSettingValue_CorrectValueIsSetAndReturned()
        {
            CompareSetValue(() => _props.ByName.AutoDisable, x => _props.ByName.AutoDisable = x, false, true, "AutoDisable");
            CompareSetValue(() => _props.ByName.BinaryConversion, x => _props.ByName.BinaryConversion = x, 0, 42, "BinaryConversion");
            CompareSetValue(() => _props.ByName.CapCompareFirmwareVersion, x => _props.ByName.CapCompareFirmwareVersion = x, false, true, "CapCompareFirmwareVersion");
            CompareSetValue(() => _props.ByName.CapPowerReporting, x => _props.ByName.CapPowerReporting = x, 0, 42, "CapPowerReporting");
            CompareSetValue(() => _props.ByName.CapStatisticsReporting, x => _props.ByName.CapStatisticsReporting = x, false, true, "CapStatisticsReporting");
            CompareSetValue(() => _props.ByName.CapUpdateFirmware, x => _props.ByName.CapUpdateFirmware = x, false, true, "CapUpdateFirmware");
            CompareSetValue(() => _props.ByName.CapUpdateStatistics, x => _props.ByName.CapUpdateStatistics = x, false, true, "CapUpdateStatistics");
            CompareSetValue(() => _props.ByName.CheckHealthText, x => _props.ByName.CheckHealthText = x, "[Error]", "42", "CheckHealthText");
            CompareSetValue(() => _props.ByName.Claimed, x => _props.ByName.Claimed = x, false, true, "Claimed");
            CompareSetValue(() => _props.ByName.DataCount, x => _props.ByName.DataCount = x, 0, 42, "DataCount");
            CompareSetValue(() => _props.ByName.DataEventEnabled, x => _props.ByName.DataEventEnabled = x, false, true, "DataEventEnabled");
            CompareSetValue(() => _props.ByName.DeviceDescription, x => _props.ByName.DeviceDescription = x, "[Error]", "42", "DeviceDescription");
            CompareSetValue(() => _props.ByName.DeviceEnabled, x => _props.ByName.DeviceEnabled = x, false, true, "DeviceEnabled");
            CompareSetValue(() => _props.ByName.DeviceName, x => _props.ByName.DeviceName = x, "[Error]", "42", "DeviceName");
            CompareSetValue(() => _props.ByName.FreezeEvents, x => _props.ByName.FreezeEvents = x, false, true, "FreezeEvents");
            CompareSetValue(() => _props.ByName.OutputID, x => _props.ByName.OutputID = x, 0, 42, "OutputID");
            CompareSetValue(() => _props.ByName.PowerNotify, x => _props.ByName.PowerNotify = x, 0, 42, "PowerNotify");
            CompareSetValue(() => _props.ByName.PowerState, x => _props.ByName.PowerState = x, 0, 42, "PowerState");
            CompareSetValue(() => _props.ByName.ResultCode, x => _props.ByName.ResultCode = x, ResultCodeConstants.Closed, ResultCodeConstants.Busy, "ResultCode");
            CompareSetValue(() => _props.ByName.ResultCodeExtended, x => _props.ByName.ResultCodeExtended = x, 0, 42, "ResultCodeExtended");
            CompareSetValue(() => _props.ByName.ServiceObjectDescription, x => _props.ByName.ServiceObjectDescription = x, "[Error]", "42", "ServiceObjectDescription");
            CompareSetValue(() => _props.ByName.ServiceObjectVersion, x => _props.ByName.ServiceObjectVersion = x, 0, 42, "ServiceObjectVersion");
            CompareSetValue(() => _props.ByName.State, x => _props.ByName.State = x, ServiceStateConstants.OPOS_S_CLOSED, ServiceStateConstants.OPOS_S_BUSY, "State");
        }
        private static void CompareSetValue<T>(Func<T> getter, Action<T> setter, T defaultGet, T setValue, string propertyName)
        {
            getter().Should().Be(defaultGet, "because {0} default is {1}", propertyName, defaultGet);
            setter(setValue);

            getter().Should().Be(setValue, "because {0} should have been set to {1}", propertyName, setValue);
            setter(defaultGet);
        }
    }
}
