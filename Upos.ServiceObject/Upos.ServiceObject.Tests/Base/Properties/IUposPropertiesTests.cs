using FluentAssertions;
using NUnit.Framework;

namespace Upos.ServiceObject.Base.Properties
{
    [TestFixture]
    public class IUposPropertiesTests
    {
        private const int FakeIntPropertyIndex = 1;
        private const int FakeIntPropertyValue = 42;
        private const int FakeStringPropertyIndex = 2;
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
            _props.GetIntProperty(PropertyConstants.PIDX_ResultCode)
                .Should()
                .Be((int)ResultCodeConstants.Closed, "because default value before Open is E_Closed (see section A-5)");
        }

        [Test]
        public void State_Default_Is_S_Closed()
        {
            _props.GetIntProperty(PropertyConstants.PIDX_State)
                .Should()
                .Be((int)ServiceStateConstants.OPOS_S_CLOSED, "because default value before Open is S_Closed (see section A-5)");
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

            _props.ShouldRaisePropertyChangeFor(x => x.ByName.AutoDisable);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.BinaryConversion);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.CapCompareFirmwareVersion);
            _props.ShouldRaisePropertyChangeFor(x => x.ByName.CapPowerReporting);
        }
    }
}
