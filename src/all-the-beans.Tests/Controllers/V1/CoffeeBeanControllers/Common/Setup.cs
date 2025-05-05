using all_the_beans.Api;
using all_the_beans.Data.Context;
using all_the_beans.Tests.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Testcontainers.MySql;
using Microsoft.Extensions.Configuration;
using all_the_beans.Data.Constants.ConfigurationConstants;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common
{
    [Binding]
    public sealed class Setup
    {
        public static MySqlContainer dbContainer;
        public static WebApplicationFactory<Program> factory;
        public static HttpClient httpClient;

        [BeforeTestRun]
        public static async Task InitialiseAsync()
        {
            Console.WriteLine("Initialising up global test environment...");

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

                        IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
                        var mysqlVersion = configuration[ConfigurationDatabaseConstants.MySQLVersion];
                        services.AddDbContext<CoffeeBeanDbContext>(options =>
                            options.UseMySql(dbContainer.GetConnectionString(), new MySqlServerVersion(mysqlVersion)));
                    });
                });

            IConfiguration configuration = factory.Services.GetService<IConfiguration>();

            // Initialize MySQL Testcontainer
            dbContainer = new MySqlBuilder()
                .WithImage($"mysql:{configuration[ConfigurationDatabaseConstants.MySQLVersion]}")
                .WithDatabase("testdb")
                .WithUsername("testuser")
                .WithPassword("testpassword")
                .Build();

            await dbContainer.StartAsync();

            await factory.Services.PerformDbContextActionAsync<CoffeeBeanDbContext>(async (dbContext) =>
            {
                // Initialise database
                // Ensure the database is created and migrated
                // This will run the migrations against the Testcontainer database
                // This will be the same CoffeeBean Table structure as the local database
                await dbContext.Database.MigrateAsync();
            });

            httpClient = factory.CreateClient();
        }

        [AfterTestRun]
        public static async Task CleanupAsync()
        {
            Console.WriteLine("Cleaning up test environment...");
            await dbContainer.DisposeAsync();
            factory.Dispose();
        }
    }
}
