using all_the_beans.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MySql;
using all_the_beans.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Reqnroll;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common
{
    internal class CommonCoffeeBeanScenarios
    {
        private MySqlContainer _dbContainer;
        private WebApplicationFactory<Program> _factory;
        protected HttpClient _httpClient;

        private const string hostUrl = "http://localhost:5053";
        public const string endpointUrl = "/v1/api/coffeebeans";

        protected IDictionary<string, object> RequestBody = new Dictionary<string, object>();
        public HttpResponseMessage Response;
        
        public async Task SetupAsync()
        {
            // Initialize MySQL Testcontainer
            this._dbContainer = new MySqlBuilder()
                .WithDatabase("testdb")
                .WithUsername("testuser")
                .WithPassword("testpassword")
                .Build();

            await _dbContainer.StartAsync();

            // Initialize WebApplicationFactory
            this._factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Replace DbContext with one pointing to the Testcontainer
                        var serviceDescriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<CoffeeBeanDbContext>));
                        if (serviceDescriptor != null)
                        {
                            services.Remove(serviceDescriptor);
                        }
                        
                        services.AddDbContext<CoffeeBeanDbContext>(options =>
                            options.UseMySql(_dbContainer.GetConnectionString(), ServerVersion.AutoDetect(this._dbContainer.GetConnectionString())));
                    });
                });

            //// Create HttpClient for API requests
            this._httpClient = this._factory.CreateClient();
            this._httpClient.BaseAddress = new Uri(hostUrl);
        }
        public async Task CleanupAsync()
        {
            // Dispose of the Testcontainer and WebApplicationFactory
            await _dbContainer.DisposeAsync();
            this._factory.Dispose();
            this._httpClient.Dispose();
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

        private object GenerateTestData(string condition, object testData)
        {
            return condition switch
            {
                "a valid" => testData,
                "an invalid" => "",
                _ => throw new ArgumentOutOfRangeException($"Unknown condition: {condition}")
            };
        }

        public async Task SendRequestAsync(string httpAction)
        {
            if (httpAction.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                var jsonPayload = JsonSerializer.Serialize(this.RequestBody);
                var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                this.Response = await this._httpClient.PostAsync(endpointUrl, content);

                Console.WriteLine($"DEBUG: {JsonSerializer.Serialize(this.Response)}");
                Console.WriteLine($"DEBUG Content: {JsonSerializer.Serialize(await this.Response.Content.ReadAsStringAsync())}");
            }
        }
    }
}