namespace WeatherBot.Model.Core
{
    public class City
    {
        public City() { }
        public City(string name, string county)
        {
            Name = name;
            Country = county;
        }

        public string Name { get; set; }
        public string Country { get; set; }
    }
}
