using System.Configuration;

namespace WeatherBot.WeatherService
{
    public static class UrlBuilder
    {
        public static string BuildServiceUrl(string city)
        {
            var appId = GetAppId();
            return string.Format(GetUrl(), city, appId);
        }

        private static string GetAppId()
        {
            return ConfigurationManager.AppSettings["WeatherAppId"];
        }

        private static string GetUrl()
        {
            return ConfigurationManager.AppSettings["WeatherUrl"];
        }
    }
}
