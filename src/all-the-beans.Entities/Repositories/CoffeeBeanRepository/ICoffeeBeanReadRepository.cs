using all_the_beans.Entities.Models;

namespace all_the_beans.Entities.Repositories.CoffeeBeanRepository
{
    // We could create generic IWriteRepository<TEntity> but as we're only dealing with CoffeeBeans we'll keep it simple.

    public interface ICoffeeBeanWriteRepository
    {
        /// <summary>
        /// Create a coffee bean record.
        /// </summary>
        /// <param name="coffeeBean">The coffee bean entity</param>
        Task CreateAsync(CoffeeBean coffeeBean);

        /// <summary>
        /// Deletes a coffee bean by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the coffee bean</param>
        Task DeleteAsync(string id);

        /// <summary>
        /// Updates a coffee bean.
        /// </summary>
        /// <param name="coffeeBean">The unique identifier of the coffee bean</param>
        Task UpdateAsync(CoffeeBean coffeeBean);
    }
}
