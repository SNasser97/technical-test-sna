using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using Reqnroll;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.GetCoffeeBeans
{
    [Binding]
    [Scope(Feature ="V1 - GetCoffeeBeans")]
    internal class GetCofeeBeansSteps : CommonCoffeeBeanSteps
    {
        private readonly GetCoffeeBeansScenarios scenarios;

        public GetCofeeBeansSteps(GetCoffeeBeansScenarios scenarios)
        {
            this.scenarios = scenarios;
        }

        [Given("the request url contains query parameter (.*) with value (.*)")]
        public void GivenTheRequestUrlContainsQueryParameterWithValue(string queryParameter, object value)
        {
        }

        [Given("(.*) CoffeeBeans exist")]
        public async Task GivenNumberOfCoffeeBeansExist(int count)
        {
            await Task.CompletedTask;
        }

        [Then("the response contains (.*) items")]
        public void ThenTheResponseContainsNumberOfItems(int count)
        {
        }
    }
}
