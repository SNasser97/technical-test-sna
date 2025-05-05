using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.CreateCoffeeBean
{
    public partial record CreateCoffeeBeanControllerRequest()
    {
        [FromBody]
        public CreateCoffeeBeanControllerRequestBody Body { get; set; }
    }
}
