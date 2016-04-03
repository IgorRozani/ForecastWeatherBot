using Newtonsoft.Json;

namespace WeatherBot.WeatherService.Model
{
    public class Clouds
    {
        [JsonProperty("all")]
        public double Cloudiness { get; set; }
    }
}
