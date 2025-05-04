using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBeanCommand;

namespace all_the_beans.Logic.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBean
{
    internal class UpdateCoffeeBeanCommand : IUpdateCoffeeBeanCommand
    {
        public Task<UpdateCoffeeBeanCommandResponse> ExecuteAsync(UpdateCoffeeBeanCommandRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
