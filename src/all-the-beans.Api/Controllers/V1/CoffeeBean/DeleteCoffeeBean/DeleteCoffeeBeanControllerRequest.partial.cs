using all_the_beans.Entities.Commands.V1.CoffeeBean.DeleteCoffeeBeanCommand;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.DeleteCoffeeBean
{
    public partial record DeleteCoffeeBeanControllerRequest
    {
        public static DeleteCoffeeBeanCommandRequest ToCommandRequest(DeleteCoffeeBeanControllerRequest request)
        {
            return new DeleteCoffeeBeanCommandRequest(request.Id);
        }
    }
}
