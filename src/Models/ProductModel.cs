using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    public class ProductModel
    {
        // get or set the Product ID
        public string Id { get; set; }
        // get or set the Maker of the product
        public string Maker { get; set; }

        //get or set the image URL to JSON
        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string Url { get; set; }

        // Validating the string length of the title to be less than 33 characters
        [StringLength (maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        //get or set the Description of the Product
        public string Description { get; set; }

        //get or set the Ratings of the Product
        public int[] Ratings { get; set; }

        //get or set the Quantity of the Product
        public string Quantity { get; set; }

        // Validating the price of the product to be between -1 and 100
        [Range (-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);


    }
}