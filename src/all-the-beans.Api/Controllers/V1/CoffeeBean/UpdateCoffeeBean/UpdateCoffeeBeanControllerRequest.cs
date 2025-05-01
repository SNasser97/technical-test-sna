using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.UpdateCoffeeBean
{
    public partial record UpdateCoffeeBeanControllerRequest
    {
        [FromRoute]
        public string Id { get; set; }

        [FromBody]
        public UpdateCoffeeBeanControllerRequestBody Body { get; set; }
    }
}
