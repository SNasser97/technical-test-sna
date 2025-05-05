using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.DeleteCoffeeBeanCommand;

namespace all_the_beans.Logic.Commands.V1.CoffeeBeanCommands.DeleteCoffeebeanCommand
{
    internal class DeleteCoffeeBeanCommand : IDeleteCoffeeBeanCommand
    {
        public Task<DeleteCoffeeBeanCommandResponse> ExecuteAsync(DeleteCoffeeBeanCommandRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
