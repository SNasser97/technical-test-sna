using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace all_the_beans.Tests.Extensions
{
    internal static class ServiceProviderExtensions
    {
        /// <summary>
        /// Performs DbContext Action
        /// </summary>
        /// <typeparam name="TDbContext">The db context</typeparam>
        /// <param name="serviceProvider">The service provider</param>
        /// <param name="dbContextAction">The db context action method to execute against the db context</param>
        public static async Task<IServiceProvider> PerformDbContextActionAsync<TDbContext>(this IServiceProvider serviceProvider, Func<TDbContext,Task> dbContextAction)
            where TDbContext : DbContext
        {
            using (IServiceScope serviceScope = serviceProvider.CreateScope())
            {
                TDbContext coffeeBeanDbContext = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();
                await dbContextAction(coffeeBeanDbContext);
            }

            return serviceProvider;
        }
    }
}