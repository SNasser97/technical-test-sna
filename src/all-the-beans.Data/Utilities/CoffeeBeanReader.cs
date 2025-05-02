using System.Text.Json;
using all_the_beans.Entities.Utilities;

namespace all_the_beans.Data.Utilities
{
    public class CoffeeBeanReader
    {
        // Note: for simplicity will read the json file directly from the file system.
        // in a real world application, this would be read from a database or an API
        // best approach would be a controller endpoint which allows for importing coffeebeans
        // either supported file formats such as: json
        // the data would be read and then saved to the database
        // some considerations: maximum filesize, validating supported files, verifying contents (virus scan..)
        public IEnumerable<CoffeeBean> GenerateCoffeeBeanFromJson()
        {
            var json = File.ReadAllText("AllTheBeans.json");
            
            json.Replace("£", "");

            IEnumerable<CoffeeBean> coffeebean = JsonSerializer.Deserialize<IEnumerable<CoffeeBean>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });


            return coffeebean;
        }
    }
}