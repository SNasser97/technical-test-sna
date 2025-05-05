using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.GetCoffeeBeans
{
    public partial record GetCoffeeBeansControllerRequest
    {
        [FromQuery]
        public int Page { get; set; }

        [FromQuery]
        public int ItemsPerPage { get; set; }
    }
}