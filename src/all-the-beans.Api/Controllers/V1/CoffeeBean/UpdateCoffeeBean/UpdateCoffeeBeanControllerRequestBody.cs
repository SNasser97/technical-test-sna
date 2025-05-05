using System.ComponentModel.DataAnnotations;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.UpdateCoffeeBean
{
    // Will assume that when updating a coffee bean all fields are mandatory for updating.
    public record UpdateCoffeeBeanControllerRequestBody
    {
        [Required]
        public decimal Cost { get; set; }

        [Required]
        [Url]
        public string Image { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Colour { get; set; }

        [Required]
        [StringLength(65535)]
        // Note: maximum length in correlation to the database column. Though this can be reduced to a smaller value.
        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        public string Country { get; set; }
    }
}