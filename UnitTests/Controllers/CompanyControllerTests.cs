using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ContosoCrafts.WebSite.Controllers.CompaniesController;

namespace UnitTests.Controllers
{
    public class CompaniesControllerTests
    {
        public static CompaniesController testCompanyController;

        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
            testCompanyController = new CompaniesController(TestHelper.CompanyService);
        }
        #endregion

        [Test]
        public void Get_Valid_Should_Return_List_Of_Companies()
        {
            //Arrange
            var data = testCompanyController.Get().ToList();

            //Act

            //Assert
            Assert.AreEqual(typeof(List<CompanyModel>), data.GetType());
        } 
    }
}
