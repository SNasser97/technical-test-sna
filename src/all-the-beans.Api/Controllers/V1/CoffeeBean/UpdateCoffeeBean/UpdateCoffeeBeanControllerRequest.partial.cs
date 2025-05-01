using all_the_beans.Entities.Commands.V1.CoffeeBean.UpdateCoffeeBeanCommand;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.UpdateCoffeeBean
{
    public partial record UpdateCoffeeBeanControllerRequest
    {
        public static UpdateCoffeeBeanCommandRequest ToCommandRequest(UpdateCoffeeBeanControllerRequest request)
        {
            return new UpdateCoffeeBeanCommandRequest(
                request.Id,
                request.Body.Cost,
                request.Body.Image,
                request.Body.Colour,
                request.Body.Name,
                request.Body.Description,
                request.Body.Country
            );
        }
    }
}
