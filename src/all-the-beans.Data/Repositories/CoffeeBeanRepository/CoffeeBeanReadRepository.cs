using all_the_beans.Data.Context;
using all_the_beans.Data.Tables.CoffeeBeanTable;
using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;
using Microsoft.EntityFrameworkCore;

namespace all_the_beans.Data.Repositories.CoffeeBeanRepository
{
    internal class CoffeeBeanReadRepository : ICoffeeBeanReadRepository
    {
        private readonly CoffeeBeanDbContext coffeeBeanDbContext;

        public CoffeeBeanReadRepository(CoffeeBeanDbContext coffeeBeanDbContext)
        {
            this.coffeeBeanDbContext = coffeeBeanDbContext;
        }

        /// <inherit doc/>
        public async Task<IEnumerable<CoffeeBean>> GetAsync(int pageNumber, int itemsPerPage)
        {
   
            IEnumerable<CoffeeBeanTable> coffeeBeanTableRecords = await this.coffeeBeanDbContext.CoffeeBean
                    .OrderBy(p => p.Index)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking()
                    .ToListAsync();

            return coffeeBeanTableRecords.Select(coffeeBeanTableRecord => CoffeeBeanTable.ToCoffeeBeanEntity(coffeeBeanTableRecord));
        }
    }
}
