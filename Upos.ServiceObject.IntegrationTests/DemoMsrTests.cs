using DemoServiceObjects;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upos.ServiceObject.IntegrationTests
{
    [TestFixture]
    public class DemoMsrTests
    {
        [Test]
        public void InstanceTest()
        {
            var msr = new DemoMsr();
            //no errors?
            msr.Should().NotBeNull();
            msr.OpenService("Msr", "DemoMsr", null).Should().Be(0);

            msr.CloseService().Should().Be(0);
            msr = null;
        }
    }
}
