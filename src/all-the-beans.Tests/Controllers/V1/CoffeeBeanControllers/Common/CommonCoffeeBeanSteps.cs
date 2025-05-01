using Reqnroll;


namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common
{
    [Binding]
    internal class CommonCoffeeBeanSteps
    {
        public CommonCoffeeBeanSteps()
        {
            
        }

        [Given("the request body contains (.*) (.*)")]
        public void GivenTheRequestBodyContains(string condition, string fieldName)
        {
        }

        [Given("the request url contains (.*) field with (.*)")]
        public void GivenTheRequestUrlContainsFieldWithValue(string requestUrlField, string value)
        {
        }

        [Given("a CoffeeBean exists with Id (.*)")]
        [Given("another CoffeeBean exists with Id (.*)")]
        public async Task GivenACoffeeBeanExistsWithId(string id)
        {
            await Task.CompletedTask;
        }

        [When("a (.*) request is made")]
        public async Task WhenARequestIsMade(string httpAction)
        {
            await Task.CompletedTask;
        }


        [Then("the response was (.*) Created")]
        public void ThenTheResponseWasCreated(int statusCode)
        {
        }

        [Then("the response was (.*) OK")]
        public void ThenTheResponseWasOK(int statusCode)
        {
        }

        [Then("the response was (.*) NoContent")]
        public void ThenTheResponseWasNoContent(int statusCode)
        {
        }
    }
}
