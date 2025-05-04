namespace all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.CreateCoffeeBeanCommand
{
    public partial record CreateCoffeeBeanCommandRequest(decimal Cost, string Image, string Colour, string Name, string Description, string Country)
    {
    }
}
