using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.CreateCoffeeBeanCommand;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.CreateCoffeeBean
{
    /// <summary>
    /// Creates a coffeebean.
    /// </summary>
    [Route("v1/api/coffeebeans")]
    [ApiController]
    public class CreateCoffeeBeanController : ControllerBase
    {
        private readonly ICreateCoffeeBeanCommand command;

        public CreateCoffeeBeanController(ICreateCoffeeBeanCommand command)
        {
            this.command = command;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateCoffeeBeanControllerRequest request)
        {
            await command.ExecuteAsync(CreateCoffeeBeanControllerRequest.ToCommandRequest(request));
            return await Task.FromResult(StatusCode(201, "Created"));
        }
    }
}
