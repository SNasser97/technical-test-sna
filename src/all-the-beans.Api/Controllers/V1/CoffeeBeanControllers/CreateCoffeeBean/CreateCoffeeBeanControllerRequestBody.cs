using System.ComponentModel.DataAnnotations;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.CreateCoffeeBean
{
    // Will assume that when creating a new coffee bean all fields are required.
    public record CreateCoffeeBeanControllerRequestBody
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