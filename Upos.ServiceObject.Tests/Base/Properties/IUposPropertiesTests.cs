using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
            _props = new TestableUposBaseProperties();
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
            _props.SetPropertyValidator(FakeIntPropertyIndex, x => (int)x > 0 ? ResultCodeConstants.Success : ResultCodeConstants.Illegal);

            var resultCode = _props.SetIntProperty(FakeIntPropertyIndex, -1);

            _props.GetIntProperty(FakeIntPropertyIndex)
                .Should()
                .Be(FakeIntPropertyValue, "because the value should not have been set");

            resultCode
                .Should()
                .Be(ResultCodeConstants.Illegal,
                    "because when setting an illegal value to a property, the result code is set to Illegal");
        }

        [Test]
        public void WhenSettingStringValue_AndValidationFails_PropertyIsNotSet_And_ResultCodeIsSet_ToIllegal()
        {
            _props.SetPropertyValidator(FakeStringPropertyIndex, x => ((string)x).Length > 0 ? ResultCodeConstants.Success : ResultCodeConstants.Illegal);

            var resultsCode = _props.SetStringProperty(FakeStringPropertyIndex, "");

            _props.GetStringProperty(FakeStringPropertyIndex)
                .Should()
                .Be(FakeStringPropertyValue, "because the value should not have been set");

            resultsCode
                .Should()
                .Be(ResultCodeConstants.Illegal,
                    "because when setting an illegal value to a property, the result code is set to Illegal");
        }

        [Test]
        public void WhenSettingValue_PropertyChangedEvent_IsFired()
        {
            var propertiesNotifiedAbout = new List<string>();
            _props.PropertyChanged += (sender, args) => propertiesNotifiedAbout.Add(args.PropertyName);
            var listOfProperties = _props.ByName.GetType().GetProperties().Select(x => x.Name).ToList();
            var propertiesToUpdate = new List<Action<INamedUposBaseProperties>>
            {
                namedProperty => namedProperty.AutoDisable = true,
                namedProperty => namedProperty.BinaryConversion = 1,
                namedProperty => namedProperty.CapCompareFirmwareVersion = true,
                namedProperty => namedProperty.CapPowerReporting = 1,
                namedProperty => namedProperty.CapStatisticsReporting = true,
                namedProperty => namedProperty.CapUpdateFirmware = true,
                namedProperty => namedProperty.CapUpdateStatistics = true,
                namedProperty => namedProperty.CheckHealthText = "HEALTHY",
                namedProperty => namedProperty.Claimed = true,
                namedProperty => namedProperty.DataCount = 1,
                namedProperty => namedProperty.DataEventEnabled = true,
                namedProperty => namedProperty.DeviceDescription = "ServiceObject",
                namedProperty => namedProperty.DeviceEnabled = true,
                namedProperty => namedProperty.DeviceName = "Name",
                namedProperty => namedProperty.FreezeEvents = true,
                namedProperty => namedProperty.OutputID = 1,
                namedProperty => namedProperty.PowerNotify = 1,
                namedProperty => namedProperty.PowerState = 1,
                namedProperty => namedProperty.ResultCode = ResultCodeConstants.Busy,
                namedProperty => namedProperty.ResultCodeExtended = 1,
                namedProperty => namedProperty.ServiceObjectDescription = "SO Description",
                namedProperty => namedProperty.ServiceObjectVersion = 1,
                namedProperty => namedProperty.State = ServiceStateConstants.OPOS_S_BUSY
            };

            foreach (var action in propertiesToUpdate)
            {
                action(_props.ByName);
            }

            propertiesNotifiedAbout.Should().BeEquivalentTo(listOfProperties);
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
