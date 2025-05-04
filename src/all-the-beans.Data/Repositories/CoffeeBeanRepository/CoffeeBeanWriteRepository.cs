using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;

namespace all_the_beans.Data.Repositories.CoffeeBeanRepository
{
    internal class CoffeeBeanWriteRepository : ICoffeeBeanWriteRepository
    {
        public Task CreateAsync(CoffeeBean coffeeBean)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CoffeeBean coffeeBean)
        {
            throw new NotImplementedException();
        }
    }
}
