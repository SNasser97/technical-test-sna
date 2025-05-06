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
            this.Response = await Setup.httpClient.GetAsync(this.RequestUrl);
            string content = await this.Response.Content.ReadAsStringAsync();
            Assert.IsNotNull(content);

            this.ResponseContent = JsonSerializer.Deserialize<IEnumerable<CoffeeBean>>(content);
        }

        public async Task CreateCoffeeBeanRecordsAsync(int count, string colour=null)
        {
            await Setup.factory.Services.PerformDbContextActionAsync<CoffeeBeanDbContext>(async (dbContext) =>
            {
                var records = Enumerable.Range(0, count).Select(i =>
                {
                    var record = new CoffeeBeanTable
                    {
                        Id = CoffeeBeanHelper.GenerateId(Guid.NewGuid().ToString()),
                        Name = $"Test Bean {i}",
                        Country = $"Test Country {i}",
                        Colour = colour ?? $"Test Colour {i}",
                        Cost = this.GenerateRandomCost(),
                        Description = $"Test Description {i}",
                        Image = $"http://image-example.com/{i}"
                    };

                    return record;
                });

                await dbContext.CoffeeBean.AddRangeAsync(records);
                await dbContext.SaveChangesAsync();
            });
        }

        public void ValidateResponseItems(int count)
        {
            Console.WriteLine("DEBUG RESP: {0}", JsonSerializer.Serialize(this.Response));
            Console.WriteLine("DEBUG CONTENT RESP: {0}", JsonSerializer.Serialize(this.ResponseContent));
            Assert.IsNotEmpty(this.ResponseContent);
            Assert.AreEqual(count, this.ResponseContent.Count());
        }

        public void ValidateResponseWasEmpty()
        {
            Assert.IsEmpty(this.ResponseContent);
        }

        private decimal GenerateRandomCost()
        {
            var random = new Random();
            return Math.Round((decimal)random.NextDouble() * 100, 2);
        }
    }
}
