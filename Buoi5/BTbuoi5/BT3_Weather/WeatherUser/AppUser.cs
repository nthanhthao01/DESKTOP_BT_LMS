using System;
using System.Media;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace WeatherUser
{
    public partial class AppUser : Form
    {
        private HubConnection connection;
        private SoundPlayer player;

        public AppUser()
        {
            InitializeComponent();

            player = new SoundPlayer("ding.wav");
        }

        private async void AppUser_Load(object sender, EventArgs e)
        {
            // Kết nối tới SignalR Hub trên server
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/weatherHub") 
                .WithAutomaticReconnect()
                .Build();

            // Lắng nghe sự kiện "ReceiveWeather" do server gửi
            connection.On<double, string>("ReceiveWeather", (temp, message) =>
            {
                // Đảm bảo cập nhật UI trong thread chính
                lstMessages.Invoke(() =>
                {
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    string msg = $"{time} | Nhiệt độ: {temp}°C | {message}";

                    // Thêm thông điệp mới lên đầu danh sách
                    lstMessages.Items.Insert(0, msg);

                    // Giới hạn tối đa 50 dòng
                    if (lstMessages.Items.Count > 50)
                        lstMessages.Items.RemoveAt(lstMessages.Items.Count - 1);

                    // Đổi màu chữ nếu nóng trên 35°C
                    if (temp > 35)
                        lstMessages.ForeColor = Color.Red;
                    else
                        lstMessages.ForeColor = Color.Blue;

                    // Phát âm thanh khi có thông báo mới
                    try
                    {
                        player.Play();
                    }
                    catch
                    {
                        // Bỏ qua lỗi nếu không có file âm thanh
                    }
                });
            });

            try
            {
                await connection.StartAsync();
                lstMessages.Items.Insert(0, "Đã kết nối tới server thời tiết!");
            }
            catch (Exception ex)
            {
                lstMessages.Items.Insert(0, $"Lỗi kết nối: {ex.Message}");
            }
        }
    }
}
