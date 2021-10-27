using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Companies
{
    public class ReadModel : PageModel
    {
        public ReadModel(JsonFileCompanyService companyService)
        {
            CompanyService = companyService;
        }
        public CompanyModel Company { get; set; }
        public JsonFileCompanyService CompanyService { get; set; }
        public void OnGet(string id)
        {
            Company = CompanyService.GetAllData().FirstOrDefault(x => x.Id == id);
        }
    }
}
