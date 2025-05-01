using all_the_beans.Entities.Commands.Common;

namespace all_the_beans.Entities.Commands.V1.CoffeeBean.CreateCoffeeBeanCommand
{
    public interface ICreateCoffeeBeanCommand : ICommand<CreateCoffeeBeanCommandRequest, CreateCoffeeBeanCommandResponse>
    {
    }
}
