using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;


namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Class containing unit test cases of create page
    /// </summary>
    public class CreateTests
    {
        /// <summary>
        /// Creating insance of the model
        /// </summary>
        #region TestSetup
        public static CreateModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Testing If on get the it is returnig all the comapny names
        /// </summary> 
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet
    }
}