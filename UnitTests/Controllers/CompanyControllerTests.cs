using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
        // Testing If on get the it is returnig all the comapny names
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