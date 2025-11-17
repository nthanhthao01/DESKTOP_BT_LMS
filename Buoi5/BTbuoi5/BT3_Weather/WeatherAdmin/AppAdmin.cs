using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json.Linq;

namespace WeatherAdmin
{
    public partial class AppAdmin : Form
    {
        private HubConnection connection;
        private System.Windows.Forms.Timer timer;   
        private int countdown = 5; 

        public AppAdmin()
        {
            InitializeComponent();
        }

        private async void AppAdmin_Load(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/weatherHub") 
                .Build();

            try
            {
                await connection.StartAsync();
                lblTemp.Text = "Đã kết nối WeatherServer thành công!";
                StartCountdown();
            }
            catch (Exception ex)
            {
                lblTemp.Text = $"Lỗi kết nối: {ex.Message}";
            }
        }

        private void StartCountdown()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 giây
            timer.Tick += async (s, e) =>
            {
                countdown--;
                lblCountdown.Text = $"Cập nhật sau: {countdown} giây";

                if (countdown <= 0)
                {
                    countdown = 5; // reset lại 5s
                    await UpdateTemperature();
                }
            };
            timer.Start();
        }

        private async Task UpdateTemperature()
        {
            try
            {
                string url = "https://api.open-meteo.com/v1/forecast?latitude=21.028&longitude=105.834&current_weather=true";
                HttpClient client = new HttpClient();
                var res = await client.GetAsync(url);
                string result = await res.Content.ReadAsStringAsync();

                dynamic data = JObject.Parse(result);
                double temperatureC = data.current_weather.temperature;

                // Xây dựng thông điệp cảnh báo
                string message = temperatureC >= 35 ? "Cảnh báo nóng!" :
                                 temperatureC <= 20 ? "Trời lạnh, nhớ mặc ấm!" :
                                 "Thời tiết dễ chịu.";

                // Hiển thị trên giao diện
                lblTemp.Text = $"Nhiệt độ Hà Nội: {temperatureC}°C - {message}";

                // Hiệu ứng đổi màu label theo nhiệt độ
                if (temperatureC >= 35)
                    lblTemp.BackColor = System.Drawing.Color.OrangeRed;
                else if (temperatureC <= 20)
                    lblTemp.BackColor = System.Drawing.Color.LightBlue;
                else
                    lblTemp.BackColor = System.Drawing.Color.LightGreen;

                // Gửi dữ liệu lên server
                await connection.InvokeAsync("UpdateWeather", temperatureC, message);
            }
            catch (Exception ex)
            {
                lblTemp.Text = $"Lỗi: {ex.Message}";
            }
        }
    }
}
