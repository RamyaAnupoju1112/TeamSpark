using ContosoCrafts.WebSite.Pages.Companies;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Pages.Company
{
    /// <summary>
    /// Class containing unit test cases of Read page
    /// </summary>
    public class ReadTests
    {
        //Creating an instance of the model
        public static ReadModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.CompanyService)
            {
            };
        }

        #region OnGet
        /// <summary>
        /// Testing onget valid should return all Companies
        /// </summary>
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
    }
}