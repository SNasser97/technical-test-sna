using all_the_beans.Data.Context;
using all_the_beans.Data.Repositories.CoffeeBeanRepository;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using all_the_beans.Data.Constants.ConfigurationConstants;

namespace all_the_beans.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // This allows us to register without exposing the coffee bean Db context class in the api layer.
        // We can use the private extension method for registering any future Db contexts.
        public static IServiceCollection AddDbCoffeeBeanContext(this IServiceCollection services)
        {
            services.AddDbContext<CoffeeBeanDbContext>((serviceProvider, options) =>
            {
                IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
                
                string databaseType = configuration[ConfigurationDatabaseConstants.DatabaseType];
                string databaseVersion = configuration[ConfigurationDatabaseConstants.MySQLVersion];
                switch (databaseType)
                {
                    case "MySQL":
                        options.UseMySql(configuration[ConfigurationDatabaseConstants.MySQLConnectionString], new MySqlServerVersion(databaseVersion));
                        break;
                    default:
                        throw new NotSupportedException($"Database provider '{databaseType}' is not supported.");
                }
            });

            return services;
        }

        public static IServiceCollection AddCoffeeBeanRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeBeanReadRepository, CoffeeBeanReadRepository>();
            services.AddScoped<ICoffeeBeanWriteRepository, CoffeeBeanWriteRepository>();
            return services;
        }
    }
}
