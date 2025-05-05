using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.GetCoffeeBeans
{
    public partial record GetCoffeeBeansControllerRequest
    {
        [FromQuery]
        public int Page { get; set; } = 1;

        [FromQuery]
        public int ItemsPerPage { get; set; } = 25;

        [FromQuery]
        public string Name { get; set; }
    }
}