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

        public async Task<CoffeeBean> GetBeanOfTheDayAsync()
        {
            long timestampTwentyFourHoursAgo = DateTimeOffset.Now.AddHours(-24).ToUnixTimeMilliseconds();
            CoffeeBeanTable currentBeanOfTheDay = await this.coffeeBeanDbContext.CoffeeBean
                    .SingleAsync(coffeeBeanTable => coffeeBeanTable.IsBeanOfTheDay == true);

            // if the bean of the day is still valid, return it
            if (currentBeanOfTheDay.LastBeanOfTheDayTime.GetValueOrDefault() >= timestampTwentyFourHoursAgo)
            {
                return CoffeeBeanTable.ToCoffeeBeanEntity(currentBeanOfTheDay);
            }

            // if the bean of the day is past the expiry time, set it to null
            if (currentBeanOfTheDay.LastBeanOfTheDayTime < timestampTwentyFourHoursAgo)
            {
                currentBeanOfTheDay.IsBeanOfTheDay = false;
                await this.coffeeBeanDbContext.SaveChangesAsync();
            }

            // get a new bean of the day - check if previous is not 24 hours old
            var newBeanOfTheDay = await this.coffeeBeanDbContext.CoffeeBean
                .Where(coffeeBeanTable => !coffeeBeanTable.LastBeanOfTheDayTime.HasValue || coffeeBeanTable.LastBeanOfTheDayTime < timestampTwentyFourHoursAgo)
                .OrderBy(coffeeBeanTable => EF.Functions.Random())
                .FirstAsync();
            newBeanOfTheDay.IsBeanOfTheDay = true;
            newBeanOfTheDay.LastBeanOfTheDayTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            await this.coffeeBeanDbContext.SaveChangesAsync();

            return CoffeeBeanTable.ToCoffeeBeanEntity(newBeanOfTheDay);
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
