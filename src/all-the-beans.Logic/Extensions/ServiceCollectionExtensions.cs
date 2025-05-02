using all_the_beans.Entities.Commands.V1.CoffeeBean.CreateCoffeeBeanCommand;
using all_the_beans.Entities.Commands.V1.CoffeeBean.DeleteCoffeeBeanCommand;
using all_the_beans.Entities.Commands.V1.CoffeeBean.UpdateCoffeeBeanCommand;
using all_the_beans.Logic.Commands.V1.CoffeeBean.CreateCoffeeBeanCommand;
using all_the_beans.Logic.Commands.V1.CoffeeBean.DeleteCoffeebeanCommand;
using all_the_beans.Logic.Commands.V1.CoffeeBean.UpdateCoffeeBean;
using all_the_beans.Logic.Queries.V1.CoffeeBeanQueries.GetCoffeeBeansQuery;
using Microsoft.Extensions.DependencyInjection;
using all_the_beans.Entities.Queries.V1.GetCoffeeBeansQuery;

namespace all_the_beans.Logic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoffeeBeanCommands(this IServiceCollection services)
        {
            services.AddScoped<ICreateCoffeeBeanCommand, CreateCoffeeBeanCommand>();
            services.AddScoped<IUpdateCoffeeBeanCommand, UpdateCoffeeBeanCommand>();
            services.AddScoped<IDeleteCoffeeBeanCommand, DeleteCoffeeBeanCommand>();
            return services;
        }

        public static IServiceCollection AddCoffeeBeanQueries(this IServiceCollection services)
        {
            services.AddScoped<IGetCoffeeBeansQuery, GetCoffeeBeansQuery>();
            return services;
        }
    }
}
