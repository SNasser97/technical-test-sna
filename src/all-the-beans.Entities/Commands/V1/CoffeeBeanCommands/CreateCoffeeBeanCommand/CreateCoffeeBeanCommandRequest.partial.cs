using all_the_beans.Entities.Entity.CoffeeBean;

namespace all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.CreateCoffeeBeanCommand
{
    public partial record class CreateCoffeeBeanCommandRequest
    {
        public static CoffeeBean ToCoffeeBeanEntity(CreateCoffeeBeanCommandRequest createCoffeeBeanCommandRequest, string generatedId)
        {
            return new CoffeeBean
            {
                Id = generatedId,
                Cost = createCoffeeBeanCommandRequest.Cost,
                Image = createCoffeeBeanCommandRequest.Image,
                Name = createCoffeeBeanCommandRequest.Name,
                Colour = createCoffeeBeanCommandRequest.Colour,
                Description = createCoffeeBeanCommandRequest.Description,
                Country = createCoffeeBeanCommandRequest.Country
            };
        }
    }
}
