using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Companies;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Company.Delete
{
    /// <summary>
    /// Class containing unit test cases of Delete companies page
    /// </summary>
    public class DeleteTests
    {
        /// <summary>
        /// Delete model object
        /// </summary>
        #region TestSetup
        public static DeleteModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.CompanyService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Testing onget valid should return all companies
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Companies()
        {
            // Arrange

            // Act
            pageModel.OnGet("111112");

            // Assert
            Assert.AreEqual("Microsoft", pageModel.Company.Name);
        }

        /// <summary>
        /// Testing if OnGet returns companies when bogus id is passed
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

        #region OnPost
        /// <summary>
        /// Testing onget valid should return all products
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product to delete
            pageModel.Company = TestHelper.CompanyService.CreateData();
            pageModel.Company.Name = "Example to Delete";
            TestHelper.CompanyService.UpdateData(pageModel.Company);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.CompanyService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Company.Id)));
        }

        #endregion OnPost
    }
}