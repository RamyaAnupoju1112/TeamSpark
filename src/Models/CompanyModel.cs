using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model class for company
    /// </summary>
    public class CompanyModel
    {
        public string Id { get; set; }
        // Valiating the company name to allow only alphanumaric characters 
        [Required(ErrorMessage = "Please enter Company Name")]
        [RegularExpression(@"^[a-z A-Z 0-9]+$", ErrorMessage = "Please enter a valid company name")]
        public string Name { get; set; }

        // Validating the input for H1B status
        [Required(ErrorMessage = "Please enter if company supports H1B sponsorship")]
        [RegularExpression(@"true|True|false|False", ErrorMessage = "Value can only be 'True' or 'False'")]
        public string H1BSupport { get; set; }

        // Validating the job role to not have any special characters or dummy values.
        [Required(ErrorMessage = "Please enter Job role Name")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Please enter a valid job role name")]
        public string JobRoleName { get; set; }
    }
}