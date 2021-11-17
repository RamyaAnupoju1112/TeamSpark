using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
        [RegularExpression(@"^[a-z A-Z 0-9]+$", ErrorMessage = "Please enter a valid company name")]

        //public IEnumerable<CompanyModel> CompaniesList { get; private set; }

        //Getter and setter to Search string
        public string Search { get; set; }
   
        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
            Companies = CompanyService.SearchCompany(Search);

        }

        /// <summary>
        /// REST OnPost, sort all data in ascending order
        /// </summary>
        public void OnPostSortAsc(string SortOrder)
        {
            Companies = CompanyService.SortCompany("ASC");
        }

        /// <summary>
        /// REST OnPost, sort all data in descending order
        /// </summary>
        public void OnPostSortDesc(string SortOrder)
        {
            Companies = CompanyService.SortCompany("DESC");
        }
    }
}