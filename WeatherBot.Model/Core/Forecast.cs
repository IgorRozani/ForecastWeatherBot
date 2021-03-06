﻿namespace WeatherBot.Model.Core
{
    public class Forecast
    {
        public Forecast()
        {
            City = new City();
        }

        public City City { get; set; }
        public double LowestTemperature { get; set; }
        public double HighestTemperature { get; set; }
        public string Weather { get; set; }
        public string WeatherDescription { get; set; }
    }
}
