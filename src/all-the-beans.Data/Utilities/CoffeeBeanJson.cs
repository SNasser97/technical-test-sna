﻿using System.Text.Json.Serialization;

namespace all_the_beans.Entities.Utilities
{
    public partial class CoffeeBeanJson
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("isBOTD")]
        public bool IsBeanOfTheDay { get; set; }

        [JsonPropertyName("Cost")]
        [JsonConverter(typeof(CostConverter))]
        public decimal Cost { get; set; }

        [JsonPropertyName("Image")]
        public string Image { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }
    }
}
