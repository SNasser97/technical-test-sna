using Microsoft.AspNetCore.Mvc;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.DeleteCoffeeBean
{
    public partial record DeleteCoffeeBeanControllerRequest
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
