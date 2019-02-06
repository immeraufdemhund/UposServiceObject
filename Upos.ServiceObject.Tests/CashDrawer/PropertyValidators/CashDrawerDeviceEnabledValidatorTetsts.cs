using NUnit.Framework;
using Upos.ServiceObject.Base;
using Upos.ServiceObject.Base.Properties;

namespace Upos.ServiceObject.CashDrawer.PropertyValidators
{
    [TestFixture]
    public class CashDrawerDeviceEnabledValidatorTetsts
    {
        private TestableUposBaseProperties _properties;
        private CashDrawerDeviceEnabledPropertyValidator _booleanValidator;

        [SetUp]
        public void Setup()
        {
            _properties = new TestableUposBaseProperties();
            _booleanValidator = new CashDrawerDeviceEnabledPropertyValidator(_properties);
            _properties.ByName.State = ServiceStateConstants.OPOS_S_IDLE;
        }

        [Test]
        public void FailsValidationIfServiceObjectIsClosed()
        {
            _properties.ByName.State = ServiceStateConstants.OPOS_S_CLOSED;

            var result = _booleanValidator.Validate(1);
            Assert.That(result, Is.EqualTo(ResultCodeConstants.Closed));
            result = _booleanValidator.Validate(0);
            Assert.That(result, Is.EqualTo(ResultCodeConstants.Closed));
        }

        [Test]
        public void WhenEnabling_DeviceDoesNotNeedToBeClaimed()
        {
            _properties.ByName.Claimed = false;

            var result = _booleanValidator.Validate(1);

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Success));
        }

        [Test]
        public void WhenEnabling_DeviceIsClaimedReturnsSuccess()
        {
            _properties.ByName.Claimed = true;

            var result = _booleanValidator.Validate(1);

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Success));
        }

        [Test]
        public void WhenDisabling_DeviceClaimedReturnsSuccess()
        {
            _properties.ByName.Claimed = true;

            var result = _booleanValidator.Validate(0);

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Success));
        }

        [Test]
        public void WhenDisabling_DeviceNotClaimedReturnsSuccess()
        {
            _properties.ByName.Claimed = false;

            var result = _booleanValidator.Validate(0);

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Success));
        }

        [Test]
        public void WhenDisabling_AndDeviceCanDisable_SuccessReturned()
        {

        }

        [Test]
        public void WhenDisabling_AndDeviceCanNOTDisable_SuccessReturned()
        {

        }
    }
}
