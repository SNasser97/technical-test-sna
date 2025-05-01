using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;
using System.Text.Json;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.CreateCoffeeBean
{
    internal class CreateCoffeeBeanScenarios : CommonCoffeeBeanScenarios
    {
        protected override async Task OnSendRequestAsync(string httpAction)
        {
            var jsonPayload = JsonSerializer.Serialize(this.RequestBody);
            var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            this.Response = await this._httpClient.PostAsync(endpointUrl, content);

            Console.WriteLine($"DEBUG: {JsonSerializer.Serialize(this.Response)}");
            Console.WriteLine($"DEBUG Content: {JsonSerializer.Serialize(await this.Response.Content.ReadAsStringAsync())}");
        }
    }
}
