using all_the_beans.Entities.Commands.Common;

namespace all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.DeleteCoffeeBeanCommand
{
    public interface IDeleteCoffeeBeanCommand : ICommand<DeleteCoffeeBeanCommandRequest, DeleteCoffeeBeanCommandResponse>
    {
    }
}
