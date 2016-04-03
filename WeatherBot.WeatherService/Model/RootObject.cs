using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherBot.WeatherService.Model
{
    public class RootObject
    {
        [JsonProperty("coord")]
        public Coord Coordinate { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("@base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public Main MainInformation { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("dt")]
        public long TicksDatetimeUTC { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("snow")]
        public Snow Snow { get; set; }
    }
}
