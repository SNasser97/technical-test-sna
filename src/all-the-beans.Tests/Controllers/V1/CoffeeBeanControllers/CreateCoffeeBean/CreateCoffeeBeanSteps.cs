using Reqnroll;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.CreateCoffeeBean
{
    [Binding]
    [Scope(Feature = "V1 - CreateCoffeeBean")]
    internal class CreateCoffeeBeanSteps
    {
        private readonly CreateCoffeeBeanScenarios scenarios;

        public CreateCoffeeBeanSteps(CreateCoffeeBeanScenarios scenarios)
        {
            this.scenarios = scenarios;
        }

        [Then("the new CoffeeBean was created")]
        public async Task ThenTheNewCoffeeBeanWasCreated()
        {
            await Task.CompletedTask;
        }

        [Then("the new CoffeeBean (.*) matches the request body field (.*)")]
        public void ThenTheNewCoffeeBeanFieldMatchesTheRequestBodyField(string entityField, string requestBodyField)
        {
        }
    }
}
