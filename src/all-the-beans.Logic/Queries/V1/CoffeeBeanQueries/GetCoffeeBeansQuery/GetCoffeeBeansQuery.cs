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
            // Considerations - Pagination<TEntity> model
            // Return TotalItems which can be used by the front end..
            // Return TotalPages which can be used by the front end..
            var filters = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(request.Colour))
            {
                filters.Add(nameof(request.Colour), request.Colour);
            }

            var coffeeBeans = await this.coffeeBeanReadRepository.GetAsync(request.Page, request.ItemsPerPAge, filters);

            return new GetCoffeeBeansQueryResponse
            {
                CoffeeBeans = coffeeBeans
            };
        }
    }
}
