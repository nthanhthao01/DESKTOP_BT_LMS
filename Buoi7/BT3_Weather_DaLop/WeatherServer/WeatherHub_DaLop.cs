using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WeatherServer
{
    public class WeatherHub_DaLop : Hub
    {
        public async Task UpdateWeather(double temperatureC, string message)
        {
            await Clients.All.SendAsync("ReceiveWeather", temperatureC, message);
        }
    }
}
