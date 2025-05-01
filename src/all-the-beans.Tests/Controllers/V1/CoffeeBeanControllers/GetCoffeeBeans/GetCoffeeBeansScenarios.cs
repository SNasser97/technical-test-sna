using all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.Common;

namespace all_the_beans.Tests.Controllers.V1.CoffeeBeanControllers.GetCoffeeBeans
{
    internal class GetCoffeeBeansScenarios : CommonCoffeeBeanScenarios
    {
        protected override async Task OnSendRequestAsync(string httpAction)
        {
            await Task.CompletedTask;
        }
    }
}
