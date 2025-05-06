using all_the_beans.Entities.Queries.V1.GetBeanOfTheDay;
using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.GetBeanOfTheDay
{
    /// <summary>
    /// Gets BeanOfTheDay coffee bean.
    /// </summary>
    [Route("v1/api/coffeebeans/bean-of-the-day")]
    [ApiController]
    public class GetBeanOfTheDayController : ControllerBase
    {
        private readonly IGetBeanOfTheDayQuery query;

        public GetBeanOfTheDayController(IGetBeanOfTheDayQuery query)
        {
            this.query = query;
        }

        // GET api/<GetBeanOfTheDayController>
        [HttpGet]
        public async Task<GetBeanOfTheDayControllerResponse> GetAsync()
        {
            GetBeanOfTheDayQueryResponse queryResponse = await this.query.ExecuteAsync();
            return GetBeanOfTheDayControllerResponse.FromQueryResponse(queryResponse);
        }
    }
}
