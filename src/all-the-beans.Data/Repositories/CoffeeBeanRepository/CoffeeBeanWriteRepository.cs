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
            await this.coffeeBeanDbContext.CoffeeBean.Where(coffeeBeanTable => coffeeBeanTable.Id == id)
                .ExecuteDeleteAsync();
        }

        /// <inherit doc/>
        public async Task UpdateAsync(CoffeeBean coffeeBean)
        {
            // move to read logic, use read repository
            // validate first if record exists, else null - 404 back to the controller
            CoffeeBeanTable record = await this.coffeeBeanDbContext.CoffeeBean.FindAsync(coffeeBean.Id);
            record.Name = coffeeBean.Name;
            record.Description = coffeeBean.Description;
            record.Cost = coffeeBean.Cost;
            record.Country = coffeeBean.Country;
            record.Colour = coffeeBean.Colour;
            record.Image = coffeeBean.Image;

            await this.coffeeBeanDbContext.SaveChangesAsync();
        }
    }
}
