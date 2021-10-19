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
    public class CompaniesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public CompaniesController(IWebHostEnvironment WebHostEnvironment)
        {
            webHostEnvironment = WebHostEnvironment;
        }
        public IActionResult Index()
        {
            var data = GetAllData();
            return View();
        }
        private string JsonFileName
        {
            get { return Path.Combine(this.webHostEnvironment.WebRootPath, "data", "companies.json"); }
        }
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
