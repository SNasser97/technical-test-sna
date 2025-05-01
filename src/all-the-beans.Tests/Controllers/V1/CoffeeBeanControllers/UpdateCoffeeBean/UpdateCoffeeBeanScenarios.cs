using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.UpdateCoffeeBean
{
    internal class UpdateCoffeeBeanScenarios : CommonCoffeeBeanScenarios
    {
        protected override async Task OnSendRequestAsync(string httpAction)
        {
            await Task.CompletedTask;
        }
    }
}
