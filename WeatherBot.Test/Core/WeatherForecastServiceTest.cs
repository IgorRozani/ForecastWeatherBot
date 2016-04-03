using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherBot.Core;
using WeatherBot.Interface.WeatherService;
using WeatherBot.Model.Core;

namespace WeatherBot.Test.Core
{
    [TestFixture]
    public class WeatherForecastServiceTest
    {
        private const string CITY_VALID = "Miami";


        private WeatherForecastService weatherForecastService;
        private IService mockService;

        [SetUp]
        public void InitializeTests()
        {
            mockService = Substitute.For<IService>();
            mockService.GetWeatherForecast(CITY_VALID).Returns(new Forecast { City = new City { Name = CITY_VALID, Country = "USA" }, HighestTemperature = 20, LowestTemperature = 10, Weather = "Sunny", WeatherDescription = "sun" });
            weatherForecastService = new WeatherForecastService(mockService);
        }

        [Test]
        public void BuildMessageForValidCity()
        {
            var message = weatherForecastService.GetWeatherForecast(CITY_VALID);
            message.Should().Be("Miami - USA: Sunny, sun. Lowest temperature: 10ºC. Highest temperature: 20ºC.");
        }

        [Test]
        public void BuildMessageForInvalidCity()
        {
            var message = weatherForecastService.GetWeatherForecast(null);
            message.Should().Be("It was not possible get the weather forecast");
        }
    }
}
