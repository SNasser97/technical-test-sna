using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.CreateCoffeeBeanCommand;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.CreateCoffeeBean
{
    public partial record CreateCoffeeBeanControllerRequest
    {
        public static CreateCoffeeBeanCommandRequest ToCommandRequest(CreateCoffeeBeanControllerRequest request)
        {
            return new CreateCoffeeBeanCommandRequest(
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
