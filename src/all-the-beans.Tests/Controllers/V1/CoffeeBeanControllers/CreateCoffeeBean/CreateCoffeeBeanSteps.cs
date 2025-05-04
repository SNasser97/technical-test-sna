using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using Reqnroll;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.CreateCoffeeBean
{
    [Binding]
    [Scope(Feature = "V1 - CreateCoffeeBean")]
    internal class CreateCoffeeBeanSteps : CommonCoffeeBeanSteps<CreateCoffeeBeanScenarios>
    {
        public CreateCoffeeBeanSteps(CreateCoffeeBeanScenarios scenarios) : base(scenarios)
        {
        }

        [Then("the new CoffeeBean was created")]
        public async Task ThenTheNewCoffeeBeanWasCreated()
        {
            await this.scenarios.ValidateCoffeBeanWasCreatedAsync();
        }

        [Then("the new CoffeeBean (.*) matches the request body field (.*)")]
        public void ThenTheNewCoffeeBeanFieldMatchesTheRequestBodyField(string entityField, string requestBodyField)
        {
            this.scenarios.ValidateCoffeeBeanRecord(entityField, requestBodyField);
        }
    }
}
