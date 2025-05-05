
using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.DeleteCoffeeBeanCommand;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;

namespace all_the_beans.Logic.Commands.V1.CoffeeBeanCommands.DeleteCoffeebeanCommand
{
    internal class DeleteCoffeeBeanCommand : IDeleteCoffeeBeanCommand
    {
        private readonly ICoffeeBeanWriteRepository coffeeBeanWriteRepository;

        public DeleteCoffeeBeanCommand(ICoffeeBeanWriteRepository coffeeBeanWriteRepository)
        {
            this.coffeeBeanWriteRepository = coffeeBeanWriteRepository;
        }

        public async Task<DeleteCoffeeBeanCommandResponse> ExecuteAsync(DeleteCoffeeBeanCommandRequest request)
        {
            await this.coffeeBeanWriteRepository.DeleteAsync(request.Id);
            return new DeleteCoffeeBeanCommandResponse();
        }
    }
}
