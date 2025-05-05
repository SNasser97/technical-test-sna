using System.Text.Json;
using all_the_beans.Entities.Utilities;

namespace all_the_beans.Data.Utilities
{
    public class CoffeeBeanReader
    {
        // Note: for simplicity will read the json file directly from the file system.
        // in a real world application, this would be read from a database or an API
        // best approach would be a controller endpoint which allows for importing coffeebeans
        // either supported file formats such as: json, csv
        // the data would be read and then saved to the database
        // some considerations: maximum filesize, validating supported files are uploaded only, verifying contents (virus scan..)
        public IEnumerable<CoffeeBeanJson> GenerateCoffeeBeanFromJson()
        {
            //Console.WriteLine("DIR {0}", JsonSerializer.Serialize(Directory.GetFiles(Directory.GetCurrentDirectory())));
            var json = File.ReadAllText(Path.Combine("../all-the-beans.Data/", "Utilities/AllTheBeans.json"));

            json.Replace("£", "");

            Console.WriteLine("DATA: {0}", json);

            IEnumerable<CoffeeBeanJson> coffeebean = JsonSerializer.Deserialize<IEnumerable<CoffeeBeanJson>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return coffeebean;
        }
    }
}

