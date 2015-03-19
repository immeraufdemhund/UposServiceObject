using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Upos.ServiceObject.Base.Properties
{
    [TestFixture]
    public class IUposPropertiesTestsNunit
    {
        private Mock<IUposProperties> _mockProps;

        [SetUp]
        public void Setup()
        {
            _mockProps = new Mock<IUposProperties>();

        }

        [Test]
        public void WithInvalidPropertyNumber_ValueReturned_IsNegative()
        {
            _mockProps.Setup(x => x.GetIntProperty(It.IsAny<int>())).Returns(1);

            var propValue = _mockProps.Object.GetIntProperty(0);

            Assert.That(propValue, Is.Negative, "Negative numbers represent an invalid property value in Upos");
        }

        [Test]
        public void WithInvalidPropertyNumber_ValueReturned_IsNegative_WithFluent()
        {
            _mockProps.Setup(x => x.GetIntProperty(It.IsAny<int>())).Returns(1);

            _mockProps.Object.GetIntProperty(0).Should().BeNegative("Negative numbers represent an invalid property value in Upos");
        }

        [Test]
        public void WithInvalidPropertyNumber_ResultCode_IsSetTo_OposEIllegal()
        {
            var props = IUposPropertiesFactory.Create();

            props.GetIntProperty(0);
            var resultCode = props.GetIntProperty(PropertyConstants.PIDX_ResultCode);

            Assert.That((ResultCodeConstants)resultCode, Is.EqualTo(ResultCodeConstants.OPOS_E_ILLEGAL), "Upos spec says to return OPOS_E_ILLEGAL");
        }

        [Test]
        public void WithInvalidPropertyNumber_ResultCode_IsSetTo_OposEIllegal_WithFluent()
        {
            var props = IUposPropertiesFactory.Create();

            props.GetIntProperty(0);
            props.GetIntProperty(PropertyConstants.PIDX_ResultCode)
                .As<ResultCodeConstants>().Should()
                .Be(ResultCodeConstants.OPOS_E_ILLEGAL, "Upos spec says to return OPOS_E_ILLEGAL");
        }
    }
}
