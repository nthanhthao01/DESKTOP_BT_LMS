using BLL_Admin;
using DAL_Admin;
using DTO_Admin;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAdmin
{
    public partial class AppAdmin_DaLop : Form
    {
        private AdminBLL adminBLL;
        private System.Windows.Forms.Timer timer;   
        private int countdown = 5; 

        public AppAdmin_DaLop()
        {
            InitializeComponent();
        }

        private async void AppAdmin_Load(object sender, EventArgs e)
        {
            adminBLL = new AdminBLL("http://localhost:5000/weatherHub");

            try
            {
                await adminBLL.StartConnectionAsync();
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
            timer.Interval = 1000;
            timer.Tick += async (s, e) =>
            {
                countdown--;
                lblCountdown.Text = $"Cập nhật sau: {countdown} giây";

                if (countdown <= 0)
                {
                    countdown = 5;
                    await UpdateTemperature();
                }
            };
            timer.Start();
        }

        private async Task UpdateTemperature()
        {
            try
            {
                AdminDTO weather = await adminBLL.GetWeatherAsync();

                lblTemp.Text = $"Nhiệt độ Hà Nội: {weather.TemperatureC}°C - {weather.Message}";
                lblTemp.BackColor = adminBLL.GetTemperatureColor(weather.TemperatureC);

                await adminBLL.SendWeatherToServerAsync(weather);
            }
            catch (Exception ex)
            {
                lblTemp.Text = $"Lỗi: {ex.Message}";
            }
        }
    }
}
