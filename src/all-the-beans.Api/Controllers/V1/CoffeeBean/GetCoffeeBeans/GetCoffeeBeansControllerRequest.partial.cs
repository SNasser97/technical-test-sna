using all_the_beans.Entities.Queries.V1.GetCoffeeBeansQuery;
using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.GetCoffeeBeans
{
    public partial record GetCoffeeBeansControllerRequest
    {
        public static GetCoffeeBeansQueryRequest ToQueryRequest(GetCoffeeBeansControllerRequest request)
        {
            return new GetCoffeeBeansQueryRequest(request.Page, request.ItemsPerPage);
        }
    }
}
