using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using DTO_User;

namespace BLL_User
{
    public class UserBLL
    {
        private readonly HubConnection _connection;

        // Sự kiện để GUI đăng ký nhận dữ liệu
        public event Action<UserDTO>? OnWeatherReceived;

        public UserBLL(string hubUrl)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

            // Đăng ký lắng nghe sự kiện từ server
            _connection.On<double, string>("ReceiveWeather", (temp, message) =>
            {
                var data = new UserDTO
                {
                    TemperatureC = temp,
                    Message = message,
                    Timestamp = DateTime.Now
                };
                OnWeatherReceived?.Invoke(data);
            });
        }

        public async Task StartConnectionAsync()
        {
            await _connection.StartAsync();
        }

        public HubConnectionState ConnectionState => _connection.State;
    }
}
