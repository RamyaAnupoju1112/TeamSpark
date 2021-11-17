using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Product.AddRating
{
    /// <summary>
    /// Class containing unit test cases to JsonFileProductService file
    /// </summary>
    public class JsonFileProductServiceTests
    {
        #region TestSetup
        /// <summary>
        /// Test initialize
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        /// <summary>
        /// Testing to check if a invalid product null will return false
        /// </summary>
        #region AddRating
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing AddRating for valid product and valid rating should return true
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// Testing add rating if valid and invalid rating should return false
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_InValid_Rating_Valid_Should_Return_False()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing valid product invalid rating and rating less than zero should return false
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_InValid_Rating_Less_Than_Zero_Valid_Should_Return_False()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing add rating invalid product id should return false
        /// </summary>
        [Test]
        public void AddRating_Invalid_ProductId_Given_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("jenlooper-test12345", 4);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Add rating if no exsisting rating there should be only new rating
        /// </summary>
        [Test]
        public void AddRating_valid_If_No_Existing_Rating_There_Should_Be_Only_New_Rating()
        {
            // Arrange
            var result = TestHelper.ProductService.AddRating("selinazawacki-soi-pins", 4);

            // Act
            var dataNewList = TestHelper.ProductService.GetAllData().Where(x => x.Id == "selinazawacki-soi-pins").FirstOrDefault();

            // Assert
            Assert.AreEqual(1, dataNewList.Ratings.Length);
            Assert.AreEqual(4, dataNewList.Ratings.Last());
        }
        #endregion AddRating

        /// <summary>
        /// Testing invalid product unpated returns null
        /// </summary>
        [Test]
        public void UpdateData_Invalid_Product_Updated_Returns_Null()
        {
            //Arrange
            var data = new ProductModel
            {
                Id = "testId",
                Description = "testDescription",
                Title = "testTitle"
            };

            //Act
            var prod = TestHelper.ProductService.UpdateData(data);

            //Assert
            Assert.AreEqual(null, prod);
        }
    }  
}