
using WeatherBot.Model.Core;

namespace WeatherBot.Interface.WeatherService
{
    public interface IService
    {
        Forecast GetWeatherForecast(string city);
    }
}
