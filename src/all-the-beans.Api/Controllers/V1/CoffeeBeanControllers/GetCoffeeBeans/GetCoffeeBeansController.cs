﻿using all_the_beans.Data.Tables.CoffeeBeanTable;
using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Queries.V1.GetCoffeeBeansQuery;
using all_the_beans.Logic.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.GetCoffeeBeans
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
        public async Task<ActionResult<IEnumerable<CoffeeBean>>> GetAsync(GetCoffeeBeansControllerRequest request)
        {
            GetCoffeeBeansQueryResponse response = await this.query.ExecuteAsync(GetCoffeeBeansControllerRequest.ToQueryRequest(request));
            return this.Ok(response.CoffeeBeans);
        }
    }
}
