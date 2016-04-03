using Newtonsoft.Json;

namespace WeatherBot.WeatherService.Model
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double VolumeLast3Hours { get; set; }
    }
}
