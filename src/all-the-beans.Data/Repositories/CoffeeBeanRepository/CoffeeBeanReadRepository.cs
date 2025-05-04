using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;

namespace all_the_beans.Data.Repositories.CoffeeBeanRepository
{
    internal class CoffeeBeanReadRepository : ICoffeeBeanReadRepository
    {
        public Task<IEnumerable<CoffeeBean>> GetAsync(int pageNumber, int itemsPerPage)
        {
            throw new NotImplementedException();
        }
    }
}
