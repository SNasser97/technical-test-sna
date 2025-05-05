using all_the_beans.Data.Context;
using all_the_beans.Data.Tables.CoffeeBeanTable;
using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using all_the_beans.Tests.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.UpdateCoffeeBean
{
    internal class UpdateCoffeeBeanScenarios : CommonCoffeeBeanScenarios
    {
        public CoffeeBeanTable CoffeeBeanTableRecord { get; private set; }

        protected override async Task OnSendRequestAsync(string httpAction)
        {
            var jsonPayload = JsonSerializer.Serialize(this.RequestBody);
            var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            this.Response = await Setup.httpClient.PutAsync(this.RequestUrl, content);

            Console.WriteLine($"DEBUG: {JsonSerializer.Serialize(this.Response)}");
            Console.WriteLine($"DEBUG Content: {JsonSerializer.Serialize(await this.Response.Content.ReadAsStringAsync())}");
        }

        public async Task RetrieveRecordAsync(string id)
        {
            await Setup.factory.Services.PerformDbContextActionAsync<CoffeeBeanDbContext>(async (dbContext) =>
            {
                this.CoffeeBeanTableRecord = await dbContext.CoffeeBean.SingleOrDefaultAsync(coffeeBean => coffeeBean.Id == id);
            });

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
