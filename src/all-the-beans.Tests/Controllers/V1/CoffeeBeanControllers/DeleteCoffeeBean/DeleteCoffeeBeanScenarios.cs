using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.DeleteCoffeeBean
{
    internal class DeleteCoffeeBeanScenarios : CommonCoffeeBeanScenarios
    {
        protected override async Task OnSendRequestAsync(string httpAction)
        {
            await Task.CompletedTask;
        }
    }
}
