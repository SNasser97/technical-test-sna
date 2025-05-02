
using all_the_beans.Data.Utilities;
using all_the_beans.Entities.Utilities;

namespace all_the_beans.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var coffeeBeanReader = new CoffeeBeanReader();

            IEnumerable<CoffeeBeanJson> coffeeBeanJsonCollection = coffeeBeanReader.GenerateCoffeeBeanFromJson();
            
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