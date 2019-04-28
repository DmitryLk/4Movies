using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Controllers;
using NUnit.Framework;

namespace Movies.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var r = new HomeController();
            Assert.AreEqual(2, 2);
        }
        [Test]
        public void TestMethod2()
        {
            var r = new HomeController();
            Assert.AreEqual(2, 2);
        }
    }
}
