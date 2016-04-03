using System.Linq;
using WeatherBot.Model.Core;
using WeatherBot.WeatherService.Model;

namespace WeatherBot.WeatherService
{
    public static class RootObjectToForecastMapper
    {
        public static Forecast ConvertToForecast(RootObject rootObject)
        {
            if (rootObject == null)
                return null;

            var forecast = new Forecast
            {
                City = ConvertRootObjectToCity(rootObject)
            };

            if (rootObject.MainInformation != null)
            {
                forecast.HighestTemperature = rootObject.MainInformation.HighestTemperature;
                forecast.LowestTemperature = rootObject.MainInformation.LowestTemperature;
            }

            if (rootObject.Weather != null && rootObject.Weather.Any())
            {
                var weather = rootObject.Weather.FirstOrDefault();
                forecast.Weather = weather.Main;
                forecast.WeatherDescription = weather.Description;
            }

            return forecast;
        }

        private static City ConvertRootObjectToCity(RootObject rootObject)
        {
            var city = new City { Name = rootObject.Name };
            if (rootObject.Sys != null)
                city.Country = rootObject.Sys.Country;

            return city;
        }
    }
}
