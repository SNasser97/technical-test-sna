
using all_the_beans.Data.Extensions;
using all_the_beans.Data.Utilities;
using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Utilities;
using System.Text.Json;

namespace all_the_beans.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await host.RunCoffeeBeanDatabaseMigrationAsync();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}