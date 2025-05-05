using all_the_beans.Api.Constants;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace all_the_beans.Api.Controllers.V1.CoffeeBean.UpdateCoffeeBean
{
    public partial record UpdateCoffeeBeanControllerRequest
    {
        [FromRoute]
        [RegularExpression(RegularExpressionConstants.requestIdPattern)]
        public string Id { get; set; }

        [FromBody]
        public UpdateCoffeeBeanControllerRequestBody Body { get; set; }
    }
}
