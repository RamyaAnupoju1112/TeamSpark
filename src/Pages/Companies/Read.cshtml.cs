using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Companies
{
    public class ReadModel : PageModel
    {

        /// Defualt Construtor
        public ReadModel(JsonFileCompanyService companyService)
        {
            CompanyService = companyService;
        }

        /// Data to show
        public CompanyModel Company { get; set; }

        // Data middletier
        public JsonFileCompanyService CompanyService { get; set; }

        /// REST Get request
        public void OnGet(string id)
        {
            Company = CompanyService.GetAllData().FirstOrDefault(x => x.Id == id);
        }
    }
}