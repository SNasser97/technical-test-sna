﻿using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.DeleteCoffeeBeanCommand;
using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.DeleteCoffeeBean
{
    /// <summary>
    /// Deletes a specific coffeebean.
    /// </summary>
    [Route("v1/api/coffeebeans/{id}")]
    [ApiController]
    public class DeleteCoffeeBeanController : ControllerBase
    {
        private readonly IDeleteCoffeeBeanCommand command;

        public DeleteCoffeeBeanController(IDeleteCoffeeBeanCommand command)
        {
            this.command = command;
        }

        // DELETE api/<DeleteCoffeeBeanController>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteCoffeeBeanControllerRequest request)
        {
            await this.command.ExecuteAsync(DeleteCoffeeBeanControllerRequest.ToCommandRequest(request));
            return await Task.FromResult(NoContent());
        }
    }
}
