using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Companies
{
    /// <summary>
    /// Manage the Update of the data for a single record
    /// </summary>
    public class UpdateModel : PageModel
    {
        // Data middletier
        public JsonFileCompanyService CompanyService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileCompanyService companyService)
        {
            CompanyService = companyService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public CompanyModel Company { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            Company = CompanyService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if (Company == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// It also checks the duplicate company and doesnt allow user to add duplicate company name
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var companies = CompanyService.GetAllData();
            var companyRequired = companies.Where(a => a.Name == Company.Name && a.JobRoleName == Company.JobRoleName)
                        .Select(b => b)
                        .FirstOrDefault();
            if (companyRequired != null && companyRequired.H1BSupport == Company.H1BSupport)
            {
                CompanyService.DeleteData(Company.Id);
                return RedirectToPage("./Index");
            }
            CompanyService.UpdateData(Company);

            return RedirectToPage("./Index");
        }
    }
}