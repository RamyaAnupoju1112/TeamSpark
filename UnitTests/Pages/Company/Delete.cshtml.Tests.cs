using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Companies;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Company.Delete
{
    public class DeleteTests
    {
        #region TestSetup
        public static DeleteModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.CompanyService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        //Testing onget valid should return all companies
        public void OnGet_Valid_Should_Return_Companies()
        {
            // Arrange

            // Act
            pageModel.OnGet("111112");

            // Assert
            Assert.AreEqual("Microsoft", pageModel.Company.Name);
        }
        #endregion OnGet

        #region OnPost
        [Test]
        //Testing onget valid should return all products
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