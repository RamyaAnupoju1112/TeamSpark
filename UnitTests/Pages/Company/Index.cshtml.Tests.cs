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

        public void test()
        {
            //
        }
        #endregion OnGet
    }
}