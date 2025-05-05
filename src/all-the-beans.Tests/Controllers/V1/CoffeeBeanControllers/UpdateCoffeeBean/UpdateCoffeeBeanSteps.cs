using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using Reqnroll;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.UpdateCoffeeBean
{
    [Binding]
    [Scope(Feature = "V1 - UpdateCoffeeBean")]
    internal class UpdateCoffeeBeanSteps : CommonCoffeeBeanSteps<UpdateCoffeeBeanScenarios>
    {
        public UpdateCoffeeBeanSteps(UpdateCoffeeBeanScenarios scenarios) : base(scenarios)
        {
        }

        [Then("the CoffeeBean was updated for Id (.*)")]
        public async Task ThenTheCoffeeBeanWasUpdated(string id)
        {
            await this.scenarios.RetrieveRecordAsync(id);
        }

        [Then("the updated CoffeeBean (.*) matches the request body field (.*)")]
        public void ThenTheUpdatedCoffeeBeanMatchesTheRequestBodyField(string entityField, string requestBodyField)
        {
            this.scenarios.ValidateCoffeeBeanRecord(entityField, requestBodyField);
        }
    }
}
