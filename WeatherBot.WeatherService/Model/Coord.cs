using Newtonsoft.Json;

namespace WeatherBot.WeatherService.Model
{
    public class Coord
    {
        [JsonProperty("long")]
        public double Longitude { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
