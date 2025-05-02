using System.Text.Json;
using System.Text.Json.Serialization;

namespace all_the_beans.Entities.Utilities
{
    internal class CostConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string costString = reader.GetString();

            // Remove currency symbols before parsing
            return decimal.Parse(costString.Replace("£", "").Trim());
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"£{value:F2}"); // Writes cost back with currency formatting
        }
    }
}