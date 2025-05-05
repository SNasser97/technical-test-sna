using Microsoft.EntityFrameworkCore;
using all_the_beans.Data.Context;
using all_the_beans.Tests.Extensions;
using all_the_beans.Data.Tables.CoffeeBeanTable;

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
            await this.ClearRecordsAsync();
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

        public async Task CreateCoffeeBeanRecordAsync(string id)
        {
            await Setup.factory.Services.PerformDbContextActionAsync<CoffeeBeanDbContext>(async (dbContext) =>
            {
                var coffeeBeanTableRecord = new CoffeeBeanTable
                {
                    Id = id,
                    Name = $"Test Bean {id}",
                    Country = "Test Country",
                    Colour = "Test Colour",
                    Cost = 10.99m,
                    Description = "Test Description",
                    Image = $"http://image-example-{id}.com"
                };

                await dbContext.CoffeeBean.AddAsync(coffeeBeanTableRecord);
                await dbContext.SaveChangesAsync();
            });
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

        private async Task ClearRecordsAsync()
        {
            // Clear test records per scenario
            // Ensures clean state for each test
            // We can spin up the container per scenario however the test execution per scenario will be slower and cause slow build times in github actions with more tests we add.
            await Setup.factory.Services.PerformDbContextActionAsync<CoffeeBeanDbContext>(async (dbContext) =>
            {
                await dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {nameof(dbContext.CoffeeBean)}");
            });
        }

        protected abstract Task OnSendRequestAsync(string httpAction);
    }
}