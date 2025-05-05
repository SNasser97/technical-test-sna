using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using Reqnroll;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.DeleteCoffeeBean
{
    [Binding]
    [Scope(Feature ="V1 - DeleteCoffeeBean")]
    internal class DeleteCoffeeBeanSteps : CommonCoffeeBeanSteps<DeleteCoffeeBeanScenarios>
    {
        public DeleteCoffeeBeanSteps(DeleteCoffeeBeanScenarios scenarios) : base(scenarios)
        {
        }

        [Then("the CoffeeBean with Id (.*) (was|was not) deleted")]
        public async Task ThenTheCoffeeBeanWithIdWasOrWasNotDeleted(string id, string condition)
        {
            await this.scenarios.ValidateCoffeeBeanRecordAsync(id, condition);
        }
    }
}
