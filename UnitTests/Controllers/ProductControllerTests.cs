using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ContosoCrafts.WebSite.Controllers.ProductsController;

namespace UnitTests.Controllers
{
    public class ProductControllerTests
    {
        public static ProductsController testProductController;

        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
            testProductController = new ProductsController(TestHelper.ProductService);
        }
        #endregion

        [Test]
        public void Get_Valid_Should_Return_List_Of_Products()
        {
            //Arrange
            var data = testProductController.Get().ToList();

            //Act

            //Assert
            Assert.AreEqual(typeof(List<ProductModel>), data.GetType());
        }

    }
}
