using Newtonsoft.Json;

namespace WeatherBot.WeatherService.Model
{
    public class Snow
    {
        [JsonProperty("3h")]
        public double VolumeLast3Hours { get; set; }
    }
}
