
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// Class containing unit test cases for Read page
    /// </summary>
    public class ReadTests
    {
        // creating an instance
        #region TestSetup
        public static ReadModel pageModel;

        /// <summary>
        /// Initializing tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Testing onget valid should return all products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("jenlooper-cactus");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("The Quantified Cactus: An Easy Plant Soil Moisture Sensor", pageModel.Product.Title);
        }

        /// <summary>
        /// Testing onGet Invalid id should return to bogus page
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_Bougs_Should_Return_Products()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("Bogus") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }
        #endregion OnGet
    }
}