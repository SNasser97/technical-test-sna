using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBeanCommand;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;

namespace all_the_beans.Logic.Commands.V1.CoffeeBeanCommands.UpdateCoffeeBean
{
    internal class UpdateCoffeeBeanCommand : IUpdateCoffeeBeanCommand
    {
        private readonly ICoffeeBeanWriteRepository coffeeBeanWriteRepository;

        public UpdateCoffeeBeanCommand(ICoffeeBeanWriteRepository coffeeBeanWriteRepository)
        {
            this.coffeeBeanWriteRepository = coffeeBeanWriteRepository;
        }

        public async Task<UpdateCoffeeBeanCommandResponse> ExecuteAsync(UpdateCoffeeBeanCommandRequest request)
        {
            await this.coffeeBeanWriteRepository.UpdateAsync(UpdateCoffeeBeanCommandRequest.ToCoffeeBeanEntity(request));
            return new UpdateCoffeeBeanCommandResponse();
        }
    }
}
