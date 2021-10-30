using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public class CompanyModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter Company Name")]
        public string Name { get; set; }
        public string H1BSupport { get; set; }
        public string JobRoleName { get; set; }
    }
}
