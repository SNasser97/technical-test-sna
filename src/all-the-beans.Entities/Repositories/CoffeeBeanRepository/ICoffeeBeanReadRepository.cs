using all_the_beans.Entities.Entity.CoffeeBean;

namespace all_the_beans.Entities.Repositories.CoffeeBeanRepository
{
    // We could create generic IReadRepository<TEntity> but as we're only dealing with CoffeeBeans we'll keep it simple.

    public interface ICoffeeBeanReadRepository
    {
        /// <summary>
        /// Retrieves coffee beans.
        /// </summary>
        /// <param name="pageNumber">The page number to specify</param>
        /// <param name="itemsPerPage">The items per page to specify</param>
        Task<IEnumerable<CoffeeBean>> GetAsync(int pageNumber, int itemsPerPage);

        /// <summary>
        /// Retrieves coffee beans.
        /// </summary>
        /// <param name="pageNumber">The page number to specify</param>
        /// <param name="itemsPerPage">The items per page to specify</param>
        /// <param name="filters">The query filters to specify</param>
        Task<IEnumerable<CoffeeBean>> GetAsync(int pageNumber, int itemsPerPage, IDictionary<string,string> filters);

        /// <summary>
        /// Retrieves bean of the day.
        /// </summary>
        Task<CoffeeBean> GetBeanOfTheDayAsync();
    }
}
