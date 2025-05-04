using all_the_beans.Data.Context;
using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;

namespace all_the_beans.Data.Repositories.CoffeeBeanRepository
{
    internal class CoffeeBeanWriteRepository : ICoffeeBeanWriteRepository
    {
        private readonly CoffeeBeanDbContext coffeeBeanDbContext;

        public CoffeeBeanWriteRepository(CoffeeBeanDbContext coffeeBeanDbContext)
        {
            this.coffeeBeanDbContext = coffeeBeanDbContext;
        }

        /// <inherit doc/>
        public Task CreateAsync(CoffeeBean coffeeBean)
        {
            throw new NotImplementedException();
        }

        /// <inherit doc/>
        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <inherit doc/>
        public Task UpdateAsync(CoffeeBean coffeeBean)
        {
            throw new NotImplementedException();
        }
    }
}
