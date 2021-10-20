using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Companies controller is used to control the CRUDi actions to be performed for companies.
    /// </summary>
    public class CompaniesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public CompaniesController(IWebHostEnvironment WebHostEnvironment)
        {
            webHostEnvironment = WebHostEnvironment;
        }

        /// <summary>
        /// Index action is one of the CRUDi operation, which will get the list of all the companies
        /// It will also have links to Create, Edit, Delete and Update any company record
        /// </summary>
        /// <returns>This action returns a view in which we pass the List of company model to show on view</returns>
        public IActionResult Index()
        {
            var data = GetAllData();
            return View(data);
        }
        private string JsonFileName
        {
            get { return Path.Combine(this.webHostEnvironment.WebRootPath, "data", "companies.json"); }
        }

        /// <summary>
        /// GetAllData method is used to Get the list of all the companies, it parses the JSON file and converts into company model list
        /// </summary>
        /// <returns>List of Company Model</returns>
        private IEnumerable<CompanyModel> GetAllData()
        {
            using (var jsonFileReader = System.IO.File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<CompanyModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
