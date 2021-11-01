using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Companies;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Company.Update
{
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.CompanyService)
            {
            };
        }

        #endregion TestSetup

        //unused test case
        #region OnGet
        //[Test]
        //public void OnGet_Valid_Should_Return_Companies()
        //{
        //    // Arrange

        //    // Act
        //    pageModel.OnGet("Microsoft");

        //    // Assert
        //    //Assert.AreEqual(true, pageModel.ModelState.IsValid);
        //    Assert.AreEqual("Microsoft", pageModel.Company.Name);
        //}
        //#endregion OnGet

        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Companies()
        {
            // Arrange
            pageModel.Company = new CompanyModel
            {
                Name = "selinazawacki-moon",
                H1BSupport= "True",
                JobRoleName = "Software Developer"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}