using InventoryService.Contracts;
using InventoryService.Controllers;
using InventoryService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject2
{
    [TestClass]
    public class TestInvoke
    {
        [TestInitialize]
        public void Setup()
        {
            //TODO
        }

        [TestMethod]
        public void TestMethod2()
        {
            var mock = new Mock<IPackagingSlip<PackageSlip>>();
            mock.Setup(p => p.GeneratePackagingSlip(null)).Returns(false);
            PackagingController packagingController = new PackagingController();
            bool result = false; //packagingController.Get(1);
            Assert.AreEqual(false, result);
        }
    }
}
