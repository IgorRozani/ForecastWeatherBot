using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherBot.Core;
using WeatherBot.Interface.Core;
using WeatherBot.Interface.WeatherService;

namespace WeatherBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message" && !string.IsNullOrEmpty(message.Text))
            {
                IService service = new WeatherService.Service();
                IWeatherForecastService weatherForescast = new WeatherForecastService(service);
                var responseMessage = weatherForescast.GetWeatherForecast(message.Text);
                return message.CreateReplyMessage(responseMessage);
            }
            else
            {
                return null;
            }
        }
    }
}