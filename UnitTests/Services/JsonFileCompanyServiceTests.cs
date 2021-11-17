using NUnit.Framework;
using System.Linq;

namespace UnitTests.Services
{
    /// <summary>
    /// Class that has unit test cases to JsonFileCompanyService.cs file
    /// </summary>
    public class JsonFileCompanyServiceTests
    {
        /// <summary>
        /// Test Initialize
        /// </summary>
        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        /// <summary>
        ///  Empty search string should return list of companies
        /// </summary>
        [Test]
        public void SearchCompany_Valid_Empty_Search_String_Returns_Companies_List()
        {
            //Arrange
            var emptyString = "";
            var companyList = TestHelper.CompanyService.GetAllData();

            //Act
            var companies = TestHelper.CompanyService.SearchCompany(emptyString);

            //Assert
            Assert.AreEqual(companyList.Count(), companies.Count());
        }
    }
}
