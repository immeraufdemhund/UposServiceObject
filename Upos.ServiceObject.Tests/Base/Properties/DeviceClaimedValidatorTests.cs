using NUnit.Framework;
using Upos.ServiceObject.Base.Properties.Validators;

namespace Upos.ServiceObject.Base.Properties
{
    [TestFixture]
    public class DeviceClaimedValidatorTests
    {
        private TestableUposBaseProperties _properties;
        private DeviceClaimedBooleanValidator _booleanValidator;

        [SetUp]
        public void Setup()
        {
            _properties = new TestableUposBaseProperties();
            _booleanValidator = new DeviceClaimedBooleanValidator(_properties);
        }

        [Test]
        public void WhenEnabling_DeviceIsNotClaimedReturnsErrorCodeClaimed()
        {
            _properties.ByName.Claimed = false;

            var result = _booleanValidator.Validate(1);

            Assert.That(result, Is.EqualTo(ResultCodeConstants.Claimed));
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
    }
}
