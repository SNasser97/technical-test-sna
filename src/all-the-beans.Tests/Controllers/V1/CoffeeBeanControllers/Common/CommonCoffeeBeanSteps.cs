using Reqnroll;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common
{
    internal class CommonCoffeeBeanSteps<TScenario>
        where TScenario : CommonCoffeeBeanScenarios
    {
        protected readonly TScenario scenarios;

        public CommonCoffeeBeanSteps(TScenario scenarios)
        {
            this.scenarios = scenarios;
        }

        [AfterScenario]
        public async Task After()
        {
            await this.scenarios.CleanupAsync();
        }

        [Given("the request body contains (.*) (.*)")]
        public void GivenTheRequestBodyContains(string condition, string fieldName)
        {
            scenarios.SetupRequestBody(condition, fieldName);
        }

        [Given("the request url contains (.*) field with (.*)")]
        public void GivenTheRequestUrlContainsFieldWithValue(string requestUrlField, string value)
        {
            if (requestUrlField == "Id")
            {
                this.scenarios.RequestUrl += $"/{value}";
            }
        }

        [Given("the request body is valid except the (.*) has (.*) value")]
        public void GivenTheRequestBodyIsValidExceptTheFieldNameHasValue(string fieldName, string condition)
        {
            this.scenarios.SetupRequestBody("a valid", "Name");
            this.scenarios.SetupRequestBody("a valid", "Country");
            this.scenarios.SetupRequestBody("a valid", "Colour");
            this.scenarios.SetupRequestBody("a valid", "Cost");
            this.scenarios.SetupRequestBody("a valid", "Description");
            this.scenarios.SetupRequestBody("a valid", "Image");
            this.scenarios.SetupRequestBody(condition, fieldName);
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
            await scenarios.SendRequestAsync(httpAction);
        }

        [Then("the response was (.*) Created")]
        public void ThenTheResponseWasCreated(int statusCode)
        {
            Assert.AreEqual(statusCode, (int) this.scenarios.Response.StatusCode, "Status code does not match expected value.");
        }

        [Then("the response was (.*) OK")]
        public void ThenTheResponseWasOK(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)this.scenarios.Response.StatusCode, "Status code does not match expected value.");
        }

        [Then("the response was (.*) NoContent")]
        public void ThenTheResponseWasNoContent(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)this.scenarios.Response.StatusCode, "Status code does not match expected value.");
        }

        [Then("the response was (.*) Bad Request")]
        public void ThenTheResponseWasBadRequest(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)this.scenarios.Response.StatusCode, "Status code does not match expected value.");
        }
    }
}
