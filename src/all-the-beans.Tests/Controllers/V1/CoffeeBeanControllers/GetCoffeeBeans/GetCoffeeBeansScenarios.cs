using all_the_beans.Data.Context;
using all_the_beans.Data.Tables.CoffeeBeanTable;
using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using all_the_beans.Tests.Extensions;
using System.Text.Json;
using all_the_beans.Logic.Helpers;
using all_the_beans.Entities.Entity.CoffeeBean;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.GetCoffeeBeans
{
    internal class GetCoffeeBeansScenarios : CommonCoffeeBeanScenarios
    {
        public IEnumerable<CoffeeBean> ResponseContent = new List<CoffeeBean>();

        protected override async Task OnSendRequestAsync(string httpAction)
        {
            this.Response = await Setup.httpClient.GetAsync(endpointUrl);
            string content = await this.Response.Content.ReadAsStringAsync();
            Assert.IsNotNull(content);

            this.ResponseContent = JsonSerializer.Deserialize<IEnumerable<CoffeeBean>>(content);
        }

        public async Task CreateCoffeeBeanRecordsAsync(int count)
        {
            await Setup.factory.Services.PerformDbContextActionAsync<CoffeeBeanDbContext>(async (dbContext) =>
            {
                var records = Enumerable.Range(0, count).Select(i => new CoffeeBeanTable
                {
                    Id = CoffeeBeanHelper.GenerateId(Guid.NewGuid().ToString()),
                    Name = $"Test Bean {i}",
                    Country = $"Test Country {i}",
                    Colour = $"Test Colour {i}",
                    Cost = this.GenerateRandomCost(),
                    Description = $"Test Description {i}",
                    Image = $"http://image-example.com/{i}"
                });

                await dbContext.CoffeeBean.AddRangeAsync(records);
            });
        }

        public void ValidateResponseItems(int count)
        {
            Console.WriteLine("JSON DATA: {0}", JsonSerializer.Serialize(this.ResponseContent));
            Assert.IsNotEmpty(this.ResponseContent);
            Assert.AreEqual(count, this.ResponseContent.Count());
        }

        private decimal GenerateRandomCost()
        {
            var random = new Random();
            return Math.Round((decimal)random.NextDouble() * 100, 2);
        }
    }
}
