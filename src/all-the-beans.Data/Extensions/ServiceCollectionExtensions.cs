using all_the_beans.Data.Context;
using all_the_beans.Data.Repositories.CoffeeBeanRepository;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;
using Microsoft.Extensions.DependencyInjection;

namespace all_the_beans.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbCoffeeBeanContext(this IServiceCollection services)
        {
            // This allows us to register without exposing the coffee bean Db context class in the api layer.
            // We can use the private extension method for registering any future Db contexts.
            return services.AddDbContext<CoffeeBeanContext>();
        }

        public static IServiceCollection AddCoffeeBeanRepositories(this IServiceCollection services)
        {
            // This allows us to register without exposing the coffee bean Db context class in the api layer.
            // We can use the private extension method for registering any future Db contexts.
            services.AddScoped<ICoffeeBeanReadRepository, CoffeeBeanReadRepository>();
            services.AddScoped<ICoffeeBeanWriteRepository, CoffeeBeanWriteRepository>();

            return services;
        }
    }
}
