using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using System.Text.Json;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.DeleteCoffeeBean
{
    internal class DeleteCoffeeBeanScenarios : CommonCoffeeBeanScenarios
    {
        protected override async Task OnSendRequestAsync(string httpAction)
        {
            this.Response = await Setup.httpClient.DeleteAsync(this.RequestUrl);

            Console.WriteLine($"DEBUG: {JsonSerializer.Serialize(this.Response)}");
            Console.WriteLine($"DEBUG Content: {JsonSerializer.Serialize(await this.Response.Content.ReadAsStringAsync())}");
        }
    }
}
