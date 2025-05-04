using all_the_beans.Data.Context;
using all_the_beans.Data.Tables.CoffeeBeanTable;
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
        public async Task CreateAsync(CoffeeBean coffeeBean)
        {
            CoffeeBeanTable coffeeBeanTable = CoffeeBeanTable.ToCoffeeBeanTable(coffeeBean);
            await this.coffeeBeanDbContext.CoffeeBean.AddAsync(coffeeBeanTable);
            await this.coffeeBeanDbContext.SaveChangesAsync();
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
