using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Queries.V1.GetCoffeeBeansQuery;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;

namespace all_the_beans.Logic.Queries.V1.CoffeeBeanQueries.GetCoffeeBeansQuery
{
    public class GetCoffeeBeansQuery : IGetCoffeeBeansQuery
    {
        private readonly ICoffeeBeanReadRepository coffeeBeanReadRepository;

        public GetCoffeeBeansQuery(ICoffeeBeanReadRepository coffeeBeanReadRepository)
        {
            this.coffeeBeanReadRepository = coffeeBeanReadRepository;
        }

        public async Task<GetCoffeeBeansQueryResponse> ExecuteAsync(GetCoffeeBeansQueryRequest request)
        {
            // considerations: validate page, validate items per page (not negative, not supplying large itemsPerPage)
            //await this.coffeeBeanReadRepository.GetAsync(request.Page, request.ItemsPerPAge);

            return new GetCoffeeBeansQueryResponse
            {
                CoffeeBeans = Enumerable.Empty<CoffeeBean>()
            };
        }
    }
}
