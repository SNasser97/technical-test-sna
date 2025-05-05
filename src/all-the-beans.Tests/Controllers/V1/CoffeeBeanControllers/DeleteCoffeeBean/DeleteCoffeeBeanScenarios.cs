using all_the_beans.Data.Context;
using all_the_beans.Data.Tables.CoffeeBeanTable;
using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using all_the_beans.Tests.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.DeleteCoffeeBean
{
    internal class DeleteCoffeeBeanScenarios : CommonCoffeeBeanScenarios
    {
        protected override async Task OnSendRequestAsync(string httpAction)
        {
            this.Response = await Setup.httpClient.DeleteAsync(this.RequestUrl);
        }

        public async Task ValidateCoffeeBeanRecordAsync(string id, string condition)
        {
            await Setup.factory.Services.PerformDbContextActionAsync<CoffeeBeanDbContext>(async (dbContext) =>
            {
                CoffeeBeanTable record = await dbContext.CoffeeBean.SingleOrDefaultAsync(coffeeBean => coffeeBean.Id == id);
                
                if (condition == "was not")
                {
                    Assert.IsNotNull(record);
                }
                
                if (condition == "was")
                {
                    Assert.IsNull(record);
                }
            });
        }
    }
}
