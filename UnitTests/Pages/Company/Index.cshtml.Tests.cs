using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Companies;

namespace UnitTests.Pages.Company.Index
{
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext;

        public static IndexModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.CompanyService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        // On making a get call the request should return all the companies
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