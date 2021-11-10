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
    public class JsonFileCompanyService
    {
        // Setting the the web hosting environment.
        public JsonFileCompanyService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "companies.json"); }
        }

        // REST call to read all data from the JSON files
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

        // REST call to search data which is fetched
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

        public CompanyModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

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
