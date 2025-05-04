using all_the_beans.Data.Table.CoffeeBeanTable;

namespace all_the_beans.Entities.Utilities
{
    public partial class CoffeeBeanJson
    {
        public static CoffeeBeanTable ToCoffeeBeanTable(CoffeeBeanJson coffeeBeanJson)
        {
            return new CoffeeBeanTable
            {
                Id = coffeeBeanJson.Id,
                Index = coffeeBeanJson.Index,
                IsBeanOfTheDay = coffeeBeanJson.IsBeanOfTheDay,
                Cost = coffeeBeanJson.Cost,
                Image = coffeeBeanJson.Image,
                Colour = coffeeBeanJson.Colour,
                Name = coffeeBeanJson.Name,
                Description = coffeeBeanJson.Description,
                Country = coffeeBeanJson.Country
            };
        }
    }
}
