using all_the_beans.Entities.Commands.V1.CoffeeBeanCommands.CreateCoffeeBeanCommand;
using all_the_beans.Entities.Entity.CoffeeBean;
using all_the_beans.Entities.Repositories.CoffeeBeanRepository;
using all_the_beans.Logic.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace all_the_beans.Logic.Commands.V1.CoffeeBeanCommands.CreateCoffeeBeanCommand
{
    internal class CreateCoffeeBeanCommand : ICreateCoffeeBeanCommand
    {
        private readonly ICoffeeBeanWriteRepository coffeeBeanWriteRepository;

        public CreateCoffeeBeanCommand(ICoffeeBeanWriteRepository coffeeBeanWriteRepository)
        {
            this.coffeeBeanWriteRepository = coffeeBeanWriteRepository;
        }

        public async Task<CreateCoffeeBeanCommandResponse> ExecuteAsync(CreateCoffeeBeanCommandRequest request)
        {
            // Additional checks, considerations that we could consider:
            // - check if the coffee bean already exists
            // - check if the cost is a valid number (non-negative)
            // strip potential html tags from request fields - security consideration
            // validate the image url - either a whitelist (or separate endpoint for uploading image which is verified)
            string id = CoffeeBeanHelper.GenerateId(Guid.NewGuid().ToString());
            CoffeeBean coffeeBean = CreateCoffeeBeanCommandRequest.ToCoffeeBeanEntity(request, id);

            await this.coffeeBeanWriteRepository.CreateAsync(coffeeBean);
            return new CreateCoffeeBeanCommandResponse();
        }
    }
}
