using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Class containing unit test cases to CompanyController
    /// </summary>
    public class CompaniesControllerTests
    {
        //Creating an instance
        public static CompaniesController testCompanyController;

        /// <summary>
        /// Test initialize
        /// </summary>
        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
            testCompanyController = new CompaniesController(TestHelper.CompanyService);
        }
        #endregion

        /// <summary>
        /// Testing If on get the it is returnig all the comapny names
        /// </summary>
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