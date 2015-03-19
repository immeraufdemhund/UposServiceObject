using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Upos.ServiceObject.Base.Properties
{
    [TestClass]
    public class IUposPropertiesTestsMS
    {

        [TestMethod]
        public void WithInvalidPropertyNumber_ResultCode_IsSetTo111_And_ValueReturned_IsNegative_MS()
        {
            IUposProperties props = IUposPropertiesFactory.Create();
            const int invalidPropertyNumber = -1;

            var propvalue = props.GetIntProperty(invalidPropertyNumber);
            var resultCode = props.GetIntProperty(PropertyConstants.PIDX_ResultCode);

            MAssert.IsTrue(propvalue < 0, "returned property value shold be negative");
            MAssert.AreEqual(ResultCodeConstants.OPOS_E_ILLEGAL, resultCode, "Upos spec says to return OPOS_E_ILLEGAL (106)");
        }

        [TestMethod]
        public void WithInvalidPropertyNumber_ResultCode_IsSetTo111_And_ValueReturned_IsNegative_WithFluent()
        {
            IUposProperties props = IUposPropertiesFactory.Create();
            const int invalidPropertyNumber = -1;

            props.GetIntProperty(invalidPropertyNumber).Should().BeNegative();
            props.GetIntProperty(PropertyConstants.PIDX_ResultCode).Should().Be((int)ResultCodeConstants.OPOS_E_ILLEGAL, "Upos spec says to return OPOS_E_ILLEGAL (106)");
        }
    }
}
