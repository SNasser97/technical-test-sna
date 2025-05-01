using all_the_beans.Entities.Commands.Common;

namespace all_the_beans.Entities.Commands.V1.CoffeeBean.UpdateCoffeeBeanCommand
{
    public interface IUpdateCoffeeBeanCommand : ICommand<UpdateCoffeeBeanCommandRequest, UpdateCoffeeBeanCommandResponse>
    {
    }
}
