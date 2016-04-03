using Newtonsoft.Json;

namespace WeatherBot.WeatherService.Model
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double LowestTemperature { get; set; }
        [JsonProperty("temp_max")]
        public double HighestTemperature { get; set; }
    }
}
