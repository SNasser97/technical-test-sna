using all_the_beans.Data.Context;
using all_the_beans.Data.Tables.CoffeeBeanTable;
using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;
using Microsoft.EntityFrameworkCore;

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
        public async Task DeleteAsync(string id)
        {
            await this.coffeeBeanDbContext.CoffeeBean.Where(coffeeBean => coffeeBean.Id == id)
                .ExecuteDeleteAsync();
        }

        /// <inherit doc/>
        public Task UpdateAsync(CoffeeBean coffeeBean)
        {
            throw new NotImplementedException();
        }
    }
}
