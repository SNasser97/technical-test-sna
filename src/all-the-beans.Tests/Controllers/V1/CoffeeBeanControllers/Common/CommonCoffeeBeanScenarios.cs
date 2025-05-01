using all_the_beans.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MySql;
using all_the_beans.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common
{
    internal abstract class CommonCoffeeBeanScenarios
    {
        public const string endpointUrl = "/v1/api/coffeebeans";
        public HttpResponseMessage Response;

        protected IDictionary<string, object> RequestBody = new Dictionary<string, object>();
        
        public string RequestUrl { get; set; } = endpointUrl;

        public async Task CleanupAsync()
        {
            // Dispose of the Testcontainer and WebApplicationFactory
            this.Response.Dispose();
            await Task.CompletedTask;
        }

        public void SetupRequestBody(string condition, string fieldName)
        {
            // Setup request body based on condition and field name
            switch (fieldName)
            {
                case "Name":
                    this.RequestBody["Name"] = this.GenerateTestData(condition, "Test Data");
                    break;
                case "Country":
                    this.RequestBody["Country"] = this.GenerateTestData(condition, "Test Country");
                    break;
                case "Colour":
                    this.RequestBody["Colour"] = this.GenerateTestData(condition, "Test Colour");
                    break;
                case "Cost":
                    this.RequestBody["Cost"] = this.GenerateTestData(condition, 10.99m);
                    break;
                case "Description":
                    this.RequestBody["Description"] = this.GenerateTestData(condition, "Test Description");
                    break;
                case "Image":
                    this.RequestBody["Image"] = this.GenerateTestData(condition, "http://image-example.com");
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown fieldName: {fieldName}");
            }
        }

        public async Task SendRequestAsync(string httpAction)
        {
            await this.OnSendRequestAsync(httpAction);
        }

        private object GenerateTestData(string condition, object testData)
        {
            return condition switch
            {
                "a valid" => testData,
                "an invalid" => "",
                _ => throw new ArgumentOutOfRangeException($"Unknown condition: {condition}")
            };
        }

        protected abstract Task OnSendRequestAsync(string httpAction);
    }
}