using Newtonsoft.Json;
using DTO_AppThoiTiet;

namespace DAL_AppThoiTiet
{
    public class WeatherDAL
    {
        public async Task<WeatherDTO?> GetWeatherAsync(double lat, double lon)
        {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";

            HttpClient client = new HttpClient();
            var res = await client.GetAsync(url);
            string result = await res.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(result);

            if (data == null || data.current_weather == null)
                return null;

            return new WeatherDTO
            {
                Temperature = data.current_weather.temperature,
                WindSpeed = data.current_weather.windspeed,
                WeatherCode = data.current_weather.weathercode,
                Time = DateTime.Parse((string)data.current_weather.time)
            };
        }
    }
}
