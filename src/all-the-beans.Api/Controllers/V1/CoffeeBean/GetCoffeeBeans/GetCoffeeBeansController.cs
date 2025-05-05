using all_the_beans.Entities.Queries.V1.GetCoffeeBeansQuery;
using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.GetCoffeeBeans
{
    /// <summary>
    /// Gets all coffeebeans.
    /// </summary>
    [Route("v1/api/coffeebeans")]
    [ApiController]
    public partial class GetCoffeeBeansController : ControllerBase
    {
        private readonly IGetCoffeeBeansQuery query;

        public GetCoffeeBeansController(IGetCoffeeBeansQuery query)
        {
            this.query = query;
        }

        // GET api/<GetCoffeeBeansController>
        [HttpGet]
        public async Task<IActionResult> GetAsync(GetCoffeeBeansControllerRequest request)
        {
            await this.query.ExecuteAsync(GetCoffeeBeansControllerRequest.ToQueryRequest(request));
            return await Task.FromResult(Ok("hello success"));
        }
    }
}
