namespace all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBeanCommand
{
    public record UpdateCoffeeBeanCommandRequest(string Id, decimal Cost, string Image, string Colour, string Name, string Description, string Country)
    {
    }
}
