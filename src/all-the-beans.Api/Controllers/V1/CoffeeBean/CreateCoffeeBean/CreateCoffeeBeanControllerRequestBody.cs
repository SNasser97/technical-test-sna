using System.ComponentModel.DataAnnotations;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.CreateCoffeeBean
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
        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }
    }
}