using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.GetCoffeeBeans
{
    public record GetCoffeeBeansControllerRequest
    {
        [FromQuery]
        public int Page { get; set; }

        [FromQuery]
        public int ItemsPerPage { get; set; }
    }
}
