using System;
using NUnit.Framework;

namespace YOT.Test
{
    [TestFixture]
    public class RunnerTest {

        private Runner runner= new Runner();

        [Test]
        public void Should_Load_Assembly() {
            Assert.IsTrue(runner.LoadDll("YOT.dll"));
            Assert.IsFalse(runner.LoadDll("YOTFAIL.dll"));
        }

    }
}
