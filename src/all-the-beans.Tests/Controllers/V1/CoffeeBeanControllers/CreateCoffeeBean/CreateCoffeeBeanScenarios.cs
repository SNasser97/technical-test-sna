using all_the_beans.Data.Context;
using all_the_beans.Data.Tables.CoffeeBeanTable;
using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.CreateCoffeeBean
{
    internal class CreateCoffeeBeanScenarios : CommonCoffeeBeanScenarios
    {
        public CoffeeBeanTable CoffeeBeanTableRecord { get; private set; }

        protected override async Task OnSendRequestAsync(string httpAction)
        {
            var jsonPayload = JsonSerializer.Serialize(this.RequestBody);
            var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            this.Response = await Setup.httpClient.PostAsync(endpointUrl, content);

        }

        public async Task ValidateCoffeBeanWasCreatedAsync()
        {
            using (IServiceScope serviceScope = Setup.factory.Services.CreateScope())
            {
                CoffeeBeanDbContext coffeeBeanDbContext = serviceScope.ServiceProvider.GetRequiredService<CoffeeBeanDbContext>();
                this.CoffeeBeanTableRecord = await coffeeBeanDbContext.CoffeeBean.SingleOrDefaultAsync();
            }

            Assert.IsNotNull(this.CoffeeBeanTableRecord);
        }

        public void ValidateCoffeeBeanRecord(string entityField, string requestBodyField)
        {
            switch (entityField)
            {
                case "Name":
                    Assert.AreEqual(this.RequestBody[requestBodyField], this.CoffeeBeanTableRecord.Name);
                    break;
                case "Country":
                    Assert.AreEqual(this.RequestBody[requestBodyField], this.CoffeeBeanTableRecord.Country);
                    break;
                case "Colour":
                    Assert.AreEqual(this.RequestBody[requestBodyField], this.CoffeeBeanTableRecord.Colour);
                    break;
                case "Cost":
                    Assert.AreEqual(this.RequestBody[requestBodyField], this.CoffeeBeanTableRecord.Cost);
                    break;
                case "Description":
                    Assert.AreEqual(this.RequestBody[requestBodyField], this.CoffeeBeanTableRecord.Description);
                    break;
                case "Image":
                    Assert.AreEqual(this.RequestBody[requestBodyField], this.CoffeeBeanTableRecord.Image);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown fieldName: {entityField}");
            }
        }
    }
}
