using all_the_beans.Data.Context;
using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;

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
        public Task<IEnumerable<CoffeeBean>> GetAsync(int pageNumber, int itemsPerPage)
        {
            throw new NotImplementedException();
        }
    }
}
