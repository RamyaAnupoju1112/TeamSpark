using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Service class writte to handle operations related to company model
    /// </summary>
    public class JsonFileCompanyService
    {
        /// <summary>
        /// Setting the the web hosting environment.
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileCompanyService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        //assigned IWebHostEnvironment to the public property
        public IWebHostEnvironment WebHostEnvironment { get; }

        // gets the combined path of JSON file
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "companies.json"); }
        }

        /// <summary>
        /// REST call to read all data from the JSON files
        /// </summary>
        /// <returns>complete data of companies</returns>
        public IEnumerable<CompanyModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<CompanyModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// REST call to search data which is fetched
        /// </summary>
        /// <param name="Search"></param>
        /// <returns>complete list of companies</returns>
        public IEnumerable<CompanyModel> SearchCompany(string Search)
        {
            var companies = GetAllData();
            if (string.IsNullOrEmpty(Search))
            {
                return companies;
            }
            return companies.Where(e => e.Name.ToLowerInvariant().Contains(Search.ToLowerInvariant()));
        }

        /// <summary>
        /// REST call to sort data which is fetched
        /// </summary>
        /// <param name="Sort"></param>
        /// <returns> Sorted list of companies</returns>
        public IEnumerable<CompanyModel> SortCompany(String sortOrder)
        {
            var companies = GetAllData();
            if (sortOrder == "ASC")
            {
                var CompaniesList = companies.OrderBy(e => e.Name);
                return CompaniesList;
            }
            else
            {
                var CompaniesList = companies.OrderByDescending(e => e.Name);
                return CompaniesList;
            }


        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public CompanyModel CreateData()
        {
            var data = new CompanyModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = "",
                H1BSupport = "",
                JobRoleName = "",
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// REST call to update company data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public CompanyModel UpdateData(CompanyModel data)
        {
            var companies = GetAllData();
            var companyData = companies.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (companyData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            companyData.Id = data.Id;
            companyData.Name = data.Name.Trim();
            companyData.JobRoleName = data.JobRoleName;
            companyData.H1BSupport = data.H1BSupport;

            SaveData(companies);

            return companyData;
        }

        /// <summary>
        /// DeleteData is a REST call to delete data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

        /// <summary>
        /// SaveData is a method to save data to the JSON file
        /// </summary>
        /// <param name="companies"></param>
        private void SaveData(IEnumerable<CompanyModel> companies)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<CompanyModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    companies
                );
            }
        }
    }
}