﻿using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.CreateCoffeeBeanCommand;
using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.DeleteCoffeeBeanCommand;
using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBeanCommand;
using all_the_beans.Logic.Commands.V1.CoffeeBeanCommands.CreateCoffeeBeanCommand;
using all_the_beans.Logic.Commands.V1.CoffeeBeanCommands.DeleteCoffeebeanCommand;
using all_the_beans.Logic.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBean;
using all_the_beans.Logic.Queries.V1.CoffeeBeanQueries.GetCoffeeBeansQuery;
using Microsoft.Extensions.DependencyInjection;
using all_the_beans.Entities.Queries.V1.GetCoffeeBeansQuery;
using all_the_beans.Entities.Queries.V1.GetBeanOfTheDay;
using all_the_beans.Logic.Queries.V1.CoffeeBeanQueries.GetBeanOfTheDay;

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
            services.AddScoped<IGetBeanOfTheDayQuery, GetBeanOfTheDayQuery>();
            return services;
        }
    }
}
