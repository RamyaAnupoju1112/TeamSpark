using ContosoCrafts.WebSite.Pages.Companies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Pages.Company
{
    /// <summary>
    /// Class containing unit test cases of Create page
    /// </summary>
    public class CreateTests
    {
        /// <summary>
        /// CreateModel object
        /// </summary>
        #region TestSetup
        public static CreateModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.CompanyService)
            {
            };
 }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Testing If on get the it is returnig all the comapny names
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Companies()
        {
            // Arrange
            var oldCount = TestHelper.CompanyService.GetAllData().Count();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.CompanyService.GetAllData().Count());
        }
        #endregion OnGet
    }
}