using all_the_beans.Api;
using all_the_beans.Data.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Testcontainers.MySql;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common
{
    [Binding]
    public class Setup
    {
        public static MySqlContainer dbContainer;
        public static WebApplicationFactory<Program> factory;
        public static HttpClient httpClient;
        private const string baseAddress = "http://localhost:5053";

        [BeforeTestRun]
        public static async Task InitialiseAsync()
        {
            Console.WriteLine("Initialising up global test environment...");

            // Initialize MySQL Testcontainer
            dbContainer = new MySqlBuilder()
                .WithDatabase("testdb")
                .WithUsername("testuser")
                .WithPassword("testpassword")
                .Build();

            await dbContainer.StartAsync();

            // Initialize WebApplicationFactory
            factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Replace DbContext with one pointing to Testcontainer
                        var serviceDescriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<CoffeeBeanDbContext>));

                        if (serviceDescriptor != null)
                            services.Remove(serviceDescriptor);

                        services.AddDbContext<CoffeeBeanDbContext>(options =>
                            options.UseMySql(dbContainer.GetConnectionString(), ServerVersion.AutoDetect(dbContainer.GetConnectionString())));
                    });
                });
            
            // Initialise database
            using (IServiceScope serviceScope = factory.Services.CreateScope())
            {
                // Ensure the database is created and migrated
                // This will run the migrations against the Testcontainer database
                // This will be the same CoffeeBean Table structure as the local database
                CoffeeBeanDbContext coffeeBeanDbContext = serviceScope.ServiceProvider.GetRequiredService<CoffeeBeanDbContext>();
                await coffeeBeanDbContext.Database.MigrateAsync();
            }

            httpClient = factory.CreateClient();
            httpClient.BaseAddress = new Uri(baseAddress);
        }

        [AfterTestRun]
        public static async Task CleanupAsync()
        {
            Console.WriteLine("Cleaning up test environment...");
            await dbContainer.DisposeAsync();
            factory.Dispose();
            httpClient.Dispose();
        }
    }
}
