using all_the_beans.Entities.Queries.V1.GetBeanOfTheDay;

namespace all_the_beans.Api.Controllers.V1.CoffeeBeanControllers.GetBeanOfTheDay
{
    public partial record GetBeanOfTheDayControllerResponse(string Id, decimal Cost, string Image, string Name, string Colour, string Description, string Country)
    {
    }

    public partial record GetBeanOfTheDayControllerResponse
    {
        public static GetBeanOfTheDayControllerResponse FromQueryResponse(GetBeanOfTheDayQueryResponse queryResponse)
        {
            return new GetBeanOfTheDayControllerResponse(
                Id: queryResponse.Id,
                Cost: queryResponse.Cost,
                Image: queryResponse.Image,
                Name: queryResponse.Name,
                Colour: queryResponse.Colour,
                Description: queryResponse.Description,
                Country: queryResponse.Country
            );
        }
    }
}