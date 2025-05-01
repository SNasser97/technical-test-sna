using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.CreateCoffeeBean
{
    public partial record CreateCoffeeBeanControllerRequest()
    {
        [FromBody]
        public CreateCoffeeBeanControllerRequestBody Body { get; set; }
    }
}
