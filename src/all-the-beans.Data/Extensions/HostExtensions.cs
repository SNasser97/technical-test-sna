using all_the_beans.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace all_the_beans.Data.Extensions
{
    public static class HostExtensions
    {
        public static IHost RunCoffeeBeanDatabaseMigration(this IHost host)
        {
            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                CoffeeBeanDbContext coffeBeanDbContext = serviceScope.ServiceProvider.GetRequiredService<CoffeeBeanDbContext>();
                // execute migration scripts from Migrations folder
                // this will create the database if it does not exist
                coffeBeanDbContext.Database.Migrate();
            }

            return host; // Ensure the method returns the IHost instance  
        }
    }
}
