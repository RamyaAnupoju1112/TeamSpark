using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Companies;

namespace UnitTests.Pages.Company.Index
{
    /// <summary>
    /// Class containing unit test cases of Index page
    /// </summary>
    public class IndexTests
    {
        // Creating an instance
        #region TestSetup
        public static PageContext pageContext;

        // Creating an instance
        public static IndexModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.CompanyService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// On making a get call the request should return all the companies
        /// </summary>
        #region OnGet
        [Test] 
        public void OnGet_Valid_Should_Return_Companies()
        {
            // Arrange
            pageModel.Search = "Amazon";

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Companies.ToList().Any());
        }

        #endregion OnGet

        /// <summary>
        /// Onpost of sort ascending list of companies should be returned
        /// </summary>
        [Test]
        public void OnPostSortAsc_Valid_Should_Return_Companies()
        {
            // Arrange
            pageModel.Sort = "Asc";

            // Act
            pageModel.OnPostSortAsc(pageModel.Sort);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Companies.ToList().Any());
        }

        /// <summary>
        /// On post of sort descending, list of all companies should be returned
        /// </summary>
        [Test]
        public void OnPostSortDesc_Valid_Should_Return_Companies()
        {
            // Arrange
            pageModel.Sort = "Desc";

            // Act
            pageModel.OnPostSortDesc(pageModel.Sort);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Companies.ToList().Any());
        }

    }
}