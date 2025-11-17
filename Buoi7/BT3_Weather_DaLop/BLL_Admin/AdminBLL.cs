using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using DAL_Admin;
using DTO_Admin;

namespace BLL_Admin
{
    public class AdminBLL
    {
        private readonly AdminDAL _dal;
        private readonly HubConnection _connection;

        public AdminBLL(string hubUrl)
        {
            _dal = new AdminDAL();

            // Khởi tạo SignalR trong BLL
            _connection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();
        }

        public async Task StartConnectionAsync()
        {
            await _connection.StartAsync();
        }

        public async Task<AdminDTO> GetWeatherAsync()
        {
            var dto = await _dal.GetCurrentWeatherAsync();

            dto.Message = dto.TemperatureC >= 35 ? "Cảnh báo nóng!" :
                          dto.TemperatureC <= 20 ? "Trời lạnh, nhớ mặc ấm!" :
                          "Thời tiết dễ chịu.";

            return dto;
        }

        public Color GetTemperatureColor(double temperature)
        {
            if (temperature >= 35) return Color.OrangeRed;
            if (temperature <= 20) return Color.LightBlue;
            return Color.LightGreen;
        }

        public async Task SendWeatherToServerAsync(AdminDTO weather)
        {
            if (_connection.State == HubConnectionState.Connected)
                await _connection.InvokeAsync("UpdateWeather", weather.TemperatureC, weather.Message);
        }
    }
}

