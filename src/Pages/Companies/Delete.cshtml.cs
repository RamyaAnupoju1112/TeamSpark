using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
namespace ContosoCrafts.WebSite.Pages.Companies
{

    /// <summary>
    /// Manage the Delete of the data for a single record
    /// </summary>
    public class DeleteModel : PageModel
    {

        // Data middletier
        public JsonFileCompanyService CompanyService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public DeleteModel(JsonFileCompanyService companyService)
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
            if(Company == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Delete that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            var company = CompanyService.DeleteData(Company.Id);

            return RedirectToPage("./Index");
        }

    }

}