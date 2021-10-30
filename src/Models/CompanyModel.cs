﻿using System;
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
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Please enter a valid company name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter if company supports H1B sponsorship")]
        [RegularExpression(@"true|True|false|False", ErrorMessage = "Value can only be 'True' or 'False'")]
        public string H1BSupport { get; set; }

        [Required(ErrorMessage = "Please enter Job role Name")]
        [RegularExpression(@"^[a-z A-Z]+$")]
        public string JobRoleName { get; set; }
    }
}
