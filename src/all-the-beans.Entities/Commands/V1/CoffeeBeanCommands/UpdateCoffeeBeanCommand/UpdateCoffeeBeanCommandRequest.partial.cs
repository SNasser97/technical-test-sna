using all_the_beans.Entities.Entity.CoffeeBean;

namespace all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBeanCommand
{
    public partial record UpdateCoffeeBeanCommandRequest
    {
        public static CoffeeBean ToCoffeeBeanEntity(UpdateCoffeeBeanCommandRequest updateCoffeeBeanCommandRequest)
        {
            return new CoffeeBean
            {
                Id = updateCoffeeBeanCommandRequest.Id,
                Cost = updateCoffeeBeanCommandRequest.Cost,
                Image = updateCoffeeBeanCommandRequest.Image,
                Name = updateCoffeeBeanCommandRequest.Name,
                Colour = updateCoffeeBeanCommandRequest.Colour,
                Description = updateCoffeeBeanCommandRequest.Description,
                Country = updateCoffeeBeanCommandRequest.Country
            };
        }
    }
}
