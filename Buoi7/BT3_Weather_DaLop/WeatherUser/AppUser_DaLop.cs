using System;
using System.Media;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using DTO_User;
using BLL_User;

namespace WeatherUser
{
    public partial class AppUser_DaLop : Form
    {
        private UserBLL userBLL;
        private SoundPlayer player;

        public AppUser_DaLop()
        {
            InitializeComponent();

            player = new SoundPlayer("ding.wav");
        }

        private async void AppUser_Load(object sender, EventArgs e)
        {
            userBLL = new UserBLL("http://localhost:5000/weatherHub");

            // GUI đăng ký sự kiện nhận dữ liệu từ BLL
            userBLL.OnWeatherReceived += UpdateUI;

            try
            {
                await userBLL.StartConnectionAsync();
                lstMessages.Items.Insert(0, "Đã kết nối tới server thời tiết!");
            }
            catch (Exception ex)
            {
                lstMessages.Items.Insert(0, $"Lỗi kết nối: {ex.Message}");
            }
        }

        private void UpdateUI(UserDTO data)
        {
            if (lstMessages.InvokeRequired)
            {
                lstMessages.Invoke(() => UpdateUI(data));
                return;
            }

            string time = data.Timestamp.ToString("HH:mm:ss");
            string msg = $"{time} | Nhiệt độ: {data.TemperatureC}°C | {data.Message}";
            lstMessages.Items.Insert(0, msg);

            if (lstMessages.Items.Count > 50)
                lstMessages.Items.RemoveAt(lstMessages.Items.Count - 1);

            lstMessages.ForeColor = data.TemperatureC > 35 ? Color.Red : Color.Blue;

            try { player.Play(); } catch { }
        }
    }
}
