using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Pages.Companies
{
    /// <summary>
    /// Index Page will return all the data to show
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="companyService"></param>
        public IndexModel(JsonFileCompanyService companyService)
        {
            CompanyService = companyService;
        }

        // Data Service
        public JsonFileCompanyService CompanyService { get; }
        // Collection of the Data
        public IEnumerable<CompanyModel> Companies { get; private set; }
        
        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Please enter a valid company name")]
        public string Search { get; set; }
        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
            Companies = CompanyService.SearchCompany(Search);
        }
    }
}