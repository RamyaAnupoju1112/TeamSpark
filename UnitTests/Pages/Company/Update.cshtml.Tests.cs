using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Companies;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Company.Update
{
    /// <summary>
    /// Class containing unit test cases for Update page
    /// </summary>
    public class UpdateTests
    {
        //Creating instance of the model
        #region TestSetup
        public static UpdateModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.CompanyService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Testing If on GET the it is returnig all the comapany names
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Companies()
        {
            // Arrange

            // Act
            pageModel.OnGet("111112");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Microsoft", pageModel.Company.Name);
        }

        /// <summary>
        /// Testing OnGet if it redirects to Index page when a bogus id is passed
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_Bogus_Should_Return_Companies()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("Bogus") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }
        #endregion OnGet

        /// <summary>
        /// Testing If on POST the it is returnig all the company names
        /// </summary>
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

        /// <summary>
        /// Onpost invalid model should return error page
        /// </summary>
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