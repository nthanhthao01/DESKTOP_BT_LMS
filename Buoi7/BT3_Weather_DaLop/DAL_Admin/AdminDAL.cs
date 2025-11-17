using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DTO_Admin;

namespace DAL_Admin
{
    public class AdminDAL
    {
        private const string API_URL = "https://api.open-meteo.com/v1/forecast?latitude=21.028&longitude=105.834&current_weather=true";

        public async Task<AdminDTO> GetCurrentWeatherAsync()
        {
            HttpClient client = new HttpClient();
            var res = await client.GetAsync(API_URL);
            string result = await res.Content.ReadAsStringAsync();

            dynamic data = JObject.Parse(result);
            double temperatureC = data.current_weather.temperature;

            return new AdminDTO
            {
                TemperatureC = temperatureC
            };
        }
    }
}
