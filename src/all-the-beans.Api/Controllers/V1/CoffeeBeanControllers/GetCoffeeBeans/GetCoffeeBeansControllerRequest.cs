using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.GetCoffeeBeans
{
    public partial record GetCoffeeBeansControllerRequest
    {
        [FromQuery]
        public int Page { get; set; } = 1;

        [FromQuery]
        public int ItemsPerPage { get; set; } = 25;

        [FromQuery]
        public string Colour { get; set; }

        // additional query parameters can be added here
        // note: for complex filtering queries we're best off using OData filtering
        // if we want to expand on this: ElasticSearch or similar if we want search capabilities against CoffeeBeans.
        // for now, we can use simple query parameters.
    }
}