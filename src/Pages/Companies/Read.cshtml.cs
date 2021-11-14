using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Companies
{
    /// <summary>
    /// Read page will read the data related to particular company
    /// </summary>
    public class ReadModel : PageModel
    {
        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="companyService"></param>
        public ReadModel(JsonFileCompanyService companyService)
        {
            CompanyService = companyService;
        }

        // Data to show
        public CompanyModel Company { get; set; }

        // Data middletier
        public JsonFileCompanyService CompanyService { get; set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            Company = CompanyService.GetAllData().FirstOrDefault(x => x.Id == id);
            if (Company == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}