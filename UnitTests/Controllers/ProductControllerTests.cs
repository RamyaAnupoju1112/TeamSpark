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

        [Test]
        public void Patch_Valid_Should_Return_Ok()
        {
            //Arrange
            var data = new RatingRequest
            {
                ProductId = "jenlooper-cactus",
                Rating = 5
            };
            var result = testProductController.Patch(data);

            //Act
            var okResult = result as OkResult;

            //Assert
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
