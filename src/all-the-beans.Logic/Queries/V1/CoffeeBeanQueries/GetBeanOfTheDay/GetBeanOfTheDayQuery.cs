using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Queries.V1.GetBeanOfTheDay;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;

namespace all_the_beans.Logic.Queries.V1.CoffeeBeanQueries.GetBeanOfTheDay
{
    public class GetBeanOfTheDayQuery : IGetBeanOfTheDayQuery
    {
        private readonly ICoffeeBeanReadRepository coffeeBeanReadRepository;

        public GetBeanOfTheDayQuery(ICoffeeBeanReadRepository coffeeBeanReadRepository)
        {
            this.coffeeBeanReadRepository = coffeeBeanReadRepository;
        }

        public async Task<GetBeanOfTheDayQueryResponse> ExecuteAsync()
        {
            CoffeeBean coffeeBean =  await this.coffeeBeanReadRepository.GetBeanOfTheDayAsync();

            return new GetBeanOfTheDayQueryResponse
            {
                Id = coffeeBean.Id,
                Name = coffeeBean.Name,
                Cost = coffeeBean.Cost,
                Image = coffeeBean.Image,
                Colour = coffeeBean.Colour,
                Description = coffeeBean.Description,
                Country = coffeeBean.Country
            };
        }
    }
}
