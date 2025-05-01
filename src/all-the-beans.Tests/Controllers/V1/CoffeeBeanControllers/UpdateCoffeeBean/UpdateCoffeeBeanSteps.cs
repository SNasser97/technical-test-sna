using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using Reqnroll;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.UpdateCoffeeBean
{
    [Binding]
    [Scope(Feature = "V1 - UpdateCoffeeBean")]
    internal class UpdateCoffeeBeanSteps : CommonCoffeeBeanSteps
    {
        private readonly UpdateCoffeeBeanScenarios scenarios;

        public UpdateCoffeeBeanSteps(UpdateCoffeeBeanScenarios scenarios)
        {
            this.scenarios = scenarios;
        }

        [Then("the CoffeeBean was updated")]
        public async Task ThenTheCoffeeBeanWasUpdated()
        {
            await Task.CompletedTask;
        }

        [Then("the updated CoffeeBean (.*) matches the request body field (.*)")]
        public void ThenTheUpdatedCoffeeBeanMatchesTheRequestBodyField(string entityField, string requestBodyField)
        {
        }
    }
}
