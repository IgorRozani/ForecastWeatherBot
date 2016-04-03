using Newtonsoft.Json;
using System.Net;
using System.Text;
using WeatherBot.Interface.WeatherService;
using WeatherBot.Model.Core;
using WeatherBot.WeatherService.Model;

namespace WeatherBot.WeatherService
{
    public class Service : IService
    {
        public Forecast GetWeatherForecast(string city)
        {
            var rootObject = GetForecast(city);
            return RootObjectToForecastMapper.ConvertToForecast(rootObject);
        }

        private RootObject GetForecast(string city)
        {
            RootObject rootObject = null;
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                var json = wc.DownloadString(UrlBuilder.BuildServiceUrl(city));
                rootObject = JsonConvert.DeserializeObject<RootObject>(json);
            }

            return rootObject;
        }
    }
}
