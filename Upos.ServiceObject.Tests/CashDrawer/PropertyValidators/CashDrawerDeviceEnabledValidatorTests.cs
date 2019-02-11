using Moq;
using NUnit.Framework;
using Upos.ServiceObject.Base;
using Upos.ServiceObject.Base.Properties;

namespace Upos.ServiceObject.CashDrawer.PropertyValidators
{
    [TestFixture]
    public class CashDrawerDeviceEnabledValidatorTests
    {
        private TestableUposBaseProperties _properties;
        private CashDrawerDeviceEnabledPropertyValidator _booleanValidator;
        private Mock<ICashDrawerDevice> _fakeDevice;

        [SetUp]
        public void Setup()
        {
            _properties = new TestableUposBaseProperties();
            _fakeDevice = new Mock<ICashDrawerDevice>();
            _booleanValidator = new CashDrawerDeviceEnabledPropertyValidator(_properties, _fakeDevice.Object);
            SetServiceObjectStateToOpen();
        }

        [Test]
        public void FailsValidationIfServiceObjectIsClosed()
        {
            _properties.ByName.State = ServiceStateConstants.OPOS_S_CLOSED;

            var result = GetEnableDeviceResult();
            Assert.That(result, Is.EqualTo(ResultCodeConstants.Closed));
            result = GetDisableDeviceResult();
            Assert.That(result, Is.EqualTo(ResultCodeConstants.Closed));
        }

        [Test]
        public void WhenEnabling_AndDeviceCanEnable_SuccessReturned()
        {
            _fakeDevice.Setup(x => x.CanEnableDevice()).Returns(true);
            _fakeDevice.Setup(x => x.EnableDevice()).Returns(true);

            var result = GetEnableDeviceResult();

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Success));
        }

        [Test]
        public void WhenEnabling_AndDeviceCanNOTEnable_FailureReturned()
        {
            _fakeDevice.Setup(x => x.CanEnableDevice()).Returns(false);

            var result = GetEnableDeviceResult();

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Failure));
        }

        [Test]
        public void WhenEnabling_AndDeviceCanEnable_ButFailsToEnable_FailureReturned()
        {
            _fakeDevice.Setup(x => x.CanEnableDevice()).Returns(true);
            _fakeDevice.Setup(x => x.EnableDevice()).Returns(false);

            var result = GetEnableDeviceResult();

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Failure));
        }

        [Test]
        public void WhenDisabling_AndDeviceCanDisable_SuccessReturned()
        {
            _fakeDevice.Setup(x => x.CanDisableDevice()).Returns(true);
            _fakeDevice.Setup(x => x.DisableDevice()).Returns(true);

            var result = GetDisableDeviceResult();

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Success));
        }

        [Test]
        public void WhenDisabling_AndDeviceCanNOTDisable_FailureReturned()
        {
            _fakeDevice.Setup(x => x.CanDisableDevice()).Returns(false);

            var result = GetDisableDeviceResult();

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Failure));
        }

        [Test]
        public void WhenDisabling_AndDeviceCanDisable_ButFailsToDisable_FailureReturned()
        {
            _fakeDevice.Setup(x => x.CanDisableDevice()).Returns(true);
            _fakeDevice.Setup(x => x.DisableDevice()).Returns(false);

            var result = GetDisableDeviceResult();

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Failure));
        }

        private void SetServiceObjectStateToOpen() => _properties.ByName.State = ServiceStateConstants.OPOS_S_IDLE;

        private ResultCodeConstants GetDisableDeviceResult() => ValidateResult(0);

        private ResultCodeConstants GetEnableDeviceResult() => ValidateResult(1);

        private ResultCodeConstants ValidateResult(int suggestedValue) => _booleanValidator.Validate(suggestedValue);
    }
}
