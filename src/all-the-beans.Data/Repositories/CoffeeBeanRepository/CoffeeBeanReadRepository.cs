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
            // pass empty dictionary to avoid null check in GetAsync(int, int, IDictionary<string,string> filters
            return await this.GetAsync(pageNumber, itemsPerPage);
        }

        public async Task<IEnumerable<CoffeeBean>> GetAsync(int pageNumber, int itemsPerPage, IDictionary<string,string> filters=null)
        {
            filters ??= new Dictionary<string, string>();

            IQueryable<CoffeeBeanTable> query = this.coffeeBeanDbContext.CoffeeBean;

            if (filters.Any())
            {
                query = this.GetFilters(query, filters);
            }

            IEnumerable<CoffeeBeanTable> coffeeBeanTableRecords = await query
               .OrderBy(p => p.Index)
               .Skip((pageNumber - 1) * itemsPerPage)
               .Take(itemsPerPage)
               .AsNoTracking()
               .ToListAsync();

            return coffeeBeanTableRecords.Select(CoffeeBeanTable.ToCoffeeBeanEntity);
        }

        public Task<CoffeeBean> GetBeanOfTheDayAsync()
        {
            throw new NotImplementedException();
        }

        private IQueryable<CoffeeBeanTable> GetFilters(IQueryable<CoffeeBeanTable> query, IDictionary<string, string> filters)
        {
            foreach (KeyValuePair<string,string> filter in filters)
            {
                if (!string.IsNullOrEmpty(filter.Value))
                {
                    query = query.Where(p => EF.Property<string>(p, filter.Key).StartsWith(filter.Value));
                }
            }

            return query;
        }
    }
}
