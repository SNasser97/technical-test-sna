using all_the_beans.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using all_the_beans.Data.Utilities;
using all_the_beans.Entities.Utilities;
using all_the_beans.Data.Tables.CoffeeBeanTable;
using System.Text.Json;

namespace all_the_beans.Data.Extensions
{
    public static class HostExtensions
    {
        public static async Task<IHost> RunCoffeeBeanDatabaseMigrationAsync(this IHost host)
        {
            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                CoffeeBeanDbContext coffeeBeanDbContext = serviceScope.ServiceProvider.GetRequiredService<CoffeeBeanDbContext>();
                // execute migration scripts from Migrations folder
                // this will create the database if it does not exist
                await coffeeBeanDbContext.Database.MigrateAsync();
            }

            return host; // Ensure the method returns the IHost instance  
        }

        public static async Task<IHost> SeedCoffeeBeanJsonDataAsync(this IHost host)
        {
            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                CoffeeBeanDbContext coffeeBeanDbContext = serviceScope.ServiceProvider.GetRequiredService<CoffeeBeanDbContext>();
                var coffeeReader = new CoffeeBeanReader();
                IEnumerable<CoffeeBeanJson> json = coffeeReader.GenerateCoffeeBeanFromJson();

                IEnumerable<CoffeeBeanTable> coffeeBeanTableRecords = json.Select(jsonEntity => new CoffeeBeanTable
                {
                    Id = jsonEntity.Id,
                    IsBeanOfTheDay = jsonEntity.IsBeanOfTheDay,
                    Cost = jsonEntity.Cost,
                    Image = jsonEntity.Image,
                    Colour = jsonEntity.Colour,
                    Name = jsonEntity.Name,
                    Description = jsonEntity.Description,
                    Country = jsonEntity.Country,
                    // Assume the its been 24 hours since the last bean of the day
                    LastBeanOfTheDayTime = jsonEntity.IsBeanOfTheDay ? DateTimeOffset.Now.AddHours(-24).ToUnixTimeMilliseconds() : null,
                });

                try
                {
                    await coffeeBeanDbContext.AddRangeAsync(coffeeBeanTableRecords);
                    await coffeeBeanDbContext.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    // Print out the error - this is a placeholder for logging
                    // Exception would be thrown if attempting to seed the same data again.
                    Console.WriteLine("Error Exception: {0}", ex);
                }
            }

            return host; // Ensure the method returns the IHost instance
        }
    }
}
