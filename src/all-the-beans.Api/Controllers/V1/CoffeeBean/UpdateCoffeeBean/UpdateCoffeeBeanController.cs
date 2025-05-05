using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBeanCommand;
using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.UpdateCoffeeBean
{
    /// <summary>
    /// Updates a specific coffeebean.
    /// </summary>
    [Route("v1/api/coffeebeans/{id}")]
    [ApiController]
    public partial class UpdateCoffeeBeansController : ControllerBase
    {
        private readonly IUpdateCoffeeBeanCommand command;

        public UpdateCoffeeBeansController(IUpdateCoffeeBeanCommand command)
        {
            this.command = command;
        }

        // PUT api/<UpdateCoffeeBeansController>
        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateCoffeeBeanControllerRequest request)
        {
            await this.command.ExecuteAsync(UpdateCoffeeBeanControllerRequest.ToCommandRequest(request));
            return await Task.FromResult(Ok("updated."));
        }
    }
}