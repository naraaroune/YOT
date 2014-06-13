using System;
using NUnit.Framework;

namespace YOT
{
    [TestFixture]
    public class RunnerTest
    {

        private Runner runner= new Runner(@"YOT.Test.dll");

        [Test]
        public void ShouldLoadDll() 
        {
            Assert.IsTrue(runner.LoadDll("YOT.Test.dll"));
            Assert.IsFalse(runner.LoadDll("STRING.dll"));
        }

    }
}
