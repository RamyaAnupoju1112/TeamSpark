using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Companies controller is used to control the CRUDi actions to be performed for companies.
    /// </summary>
    public class CompaniesController : Controller
    {
        /// <summary>
        /// Constructor for Companiescontroller
        /// </summary>
        /// <param name="companyService"></param>
        public CompaniesController(JsonFileCompanyService companyService)
        {
            CompanyService = companyService;
        }

        // Getter for CompanyService
        public JsonFileCompanyService CompanyService { get; }

        /// <summary>
        /// GetAllData method is used to Get the list of all the companies, it parses the JSON file and converts into company model list
        /// </summary>
        /// <returns>List of Company Model</returns>
        [HttpGet]
        public IEnumerable<CompanyModel> Get()
        {
            return CompanyService.GetAllData();
        }
    }
}