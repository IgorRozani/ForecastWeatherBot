using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherBot.Model.Core;
using WeatherBot.WeatherService;
using WeatherBot.WeatherService.Model;

namespace WeatherBot.Test.WeatherService
{
    [TestFixture]
    public class RootObjectToForecastMapperTest
    {
        private const string CITY = "Auckland";
        private const string COUNTRY = "NZ";
        private const string WEATHER = "Cloud";
        private const string WEATHER_DESCRIPTION = "really cloud";
        private const double HIGHEST_TEMPERATURE = 35;
        private const double LOWEST_TEMPERATURE = 5;

        private Forecast _expectedForecast;
        private RootObject _rootObject;

        [SetUp]
        public void InitializeTests()
        {
            _rootObject = new RootObject();
            _expectedForecast = new Forecast();
        }

        private void CompareObjects()
        {
            var forecast = RootObjectToForecastMapper.ConvertToForecast(_rootObject);
            forecast.ShouldBeEquivalentTo(_expectedForecast);
        }

        [Test]
        public void MapFullRootObjectToForecast()
        {
            _rootObject.Name = CITY;
            _rootObject.Sys = new Sys { Country = COUNTRY };
            _rootObject.Weather = new List<Weather> { new Weather { Main = WEATHER, Description = WEATHER_DESCRIPTION } };
            _rootObject.MainInformation = new Main { HighestTemperature = HIGHEST_TEMPERATURE, LowestTemperature = LOWEST_TEMPERATURE };

            _expectedForecast.City = new City { Name = CITY, Country = COUNTRY };
            _expectedForecast.HighestTemperature = HIGHEST_TEMPERATURE;
            _expectedForecast.LowestTemperature = LOWEST_TEMPERATURE;
            _expectedForecast.Weather = WEATHER;
            _expectedForecast.WeatherDescription = WEATHER_DESCRIPTION;

            CompareObjects();
        }

        [Test]
        public void MapRootObjectWithoutWeatherToForecast()
        {
            _rootObject.Name = CITY;
            _rootObject.Sys = new Sys { Country = COUNTRY };
            _rootObject.MainInformation = new Main { HighestTemperature = HIGHEST_TEMPERATURE, LowestTemperature = LOWEST_TEMPERATURE };

            _expectedForecast.City = new City { Name = CITY, Country = COUNTRY };
            _expectedForecast.HighestTemperature = HIGHEST_TEMPERATURE;
            _expectedForecast.LowestTemperature = LOWEST_TEMPERATURE;

            CompareObjects();
        }

        [Test]
        public void MapRootObjectWithoutMainToForecast()
        {
            _rootObject.Name = CITY;
            _rootObject.Sys = new Sys { Country = COUNTRY };
            _rootObject.Weather = new List<Weather> { new Weather { Main = WEATHER, Description = WEATHER_DESCRIPTION } };

            _expectedForecast.City = new City { Name = CITY, Country = COUNTRY };
            _expectedForecast.Weather = WEATHER;
            _expectedForecast.WeatherDescription = WEATHER_DESCRIPTION;

            CompareObjects();
        }

        [Test]
        public void MapRootObjectWithoutSysToForecast()
        {
            _rootObject.Name = CITY;
            _rootObject.Weather = new List<Weather> { new Weather { Main = WEATHER, Description = WEATHER_DESCRIPTION } };
            _rootObject.MainInformation = new Main { HighestTemperature = HIGHEST_TEMPERATURE, LowestTemperature = LOWEST_TEMPERATURE };

            _expectedForecast.City = new City { Name = CITY };
            _expectedForecast.HighestTemperature = HIGHEST_TEMPERATURE;
            _expectedForecast.LowestTemperature = LOWEST_TEMPERATURE;
            _expectedForecast.Weather = WEATHER;
            _expectedForecast.WeatherDescription = WEATHER_DESCRIPTION;

            CompareObjects();
        }

        [Test]
        public void MapEmptyRootObjectToForecast()
        {
            CompareObjects();
        }

        [Test]
        public void MapNullRootObjectToForecast()
        {
            _rootObject = null;
            _expectedForecast = null;

            CompareObjects();
        }
    }
}
