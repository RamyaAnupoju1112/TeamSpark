using NUnit.Framework;
using System.Linq;

namespace UnitTests.Services
{
    public class JsonFileCompanyServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void SearchCompany_Empty_Search_String_Returns_Companies_List()
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
