using all_the_beans.Entities.Entity.CoffeeBean;

namespace all_the_beans.Entities.Queries.V1.GetCoffeeBeansQuery
{
    public record GetCoffeeBeansQueryResponse()
    {
        public IEnumerable<CoffeeBean> CoffeeBeans { get; set; }
    }
}