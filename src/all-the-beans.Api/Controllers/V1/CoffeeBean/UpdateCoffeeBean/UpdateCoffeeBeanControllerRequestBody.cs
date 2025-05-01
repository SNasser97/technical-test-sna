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
        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        [StringLength(30)]
        public required string Country { get; set; }
    }
}