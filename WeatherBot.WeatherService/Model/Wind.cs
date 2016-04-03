using Newtonsoft.Json;

namespace WeatherBot.WeatherService.Model
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public double Direction { get; set; }
    }
}
