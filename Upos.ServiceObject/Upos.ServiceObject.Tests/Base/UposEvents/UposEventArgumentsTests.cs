using System;
using NUnit.Framework;

namespace Upos.ServiceObject.Base.UposEvents
{
    [TestFixture]
    public class UposEventArgumentsTests
    {
        private delegate void Something(string ass);

        [Test]
        public void TestDelegates()
        {
            Something s = Console.WriteLine;

            s("Hello");

            s += Test;

            s("Robert");

            s = Test;

            s("Berto");
        }

        private void Test(string me)
        {
            Console.WriteLine("Riiiigggghhhttt...'{0}'", me);
        }
    }
}
