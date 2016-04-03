using System;
using System.Text;
using WeatherBot.Interface.Core;
using WeatherBot.Interface.WeatherService;
using WeatherBot.Model.Core;

namespace WeatherBot.Core
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private IService _service;

        public WeatherForecastService(IService service)
        {
            _service = service;
        }

        public string GetWeatherForecast(string city)
        {
            var message = string.Empty;
            try
            {
                var forecast = _service.GetWeatherForecast(city);
                message = BuildMessage(forecast);
            }
            catch (Exception)
            {
                message = "It was not possible get the weather forecast";
            }

            return message;
        }

        private string BuildMessage(Forecast forecast)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.Append($"{forecast.City.Name} - {forecast.City.Country}: {forecast.Weather}, {forecast.WeatherDescription}. ");
            messageBuilder.Append($"Lowest temperature: {forecast.LowestTemperature}ºC. ");
            messageBuilder.Append($"Highest temperature: {forecast.HighestTemperature}ºC.");

            return messageBuilder.ToString();
        }
    }
}
