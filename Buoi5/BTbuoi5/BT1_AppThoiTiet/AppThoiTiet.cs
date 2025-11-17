using Newtonsoft.Json;
using System.Globalization;

namespace WinFormsApp1
{
    public partial class AppThoiTiet : Form
    {
        public AppThoiTiet()
        {
            InitializeComponent();
        }

        private async void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cbThanhPho.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn thành phố trước!");
                return;
            }

            double lat = 0, lon = 0;
            switch (cbThanhPho.SelectedItem.ToString())
            {
                case "TP.HCM":
                    lat = 10.7769;
                    lon = 106.7009;
                    break;
                case "Hà Nội":
                    lat = 21.0285;
                    lon = 105.834;
                    break;
                case "Đà Nẵng":
                    lat = 16.0471;
                    lon = 108.2068;
                    break;
                case "Khác":
                    // Kiểm tra ô nhập có trống không
                    if (string.IsNullOrWhiteSpace(txtViDo.Text) || string.IsNullOrWhiteSpace(txtKinhDo.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ Vĩ độ và Kinh độ!\n\nVí dụ:\nVĩ độ: 10.7769\nKinh độ: 106.7009",
                                        "Thiếu thông tin",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    // Chuẩn hóa chuỗi nhập: thay dấu phẩy thành dấu chấm, bỏ khoảng trắng
                    string viDoText = txtViDo.Text.Trim().Replace(',', '.');
                    string kinhDoText = txtKinhDo.Text.Trim().Replace(',', '.');

                    // Ép parse
                    bool latOk = double.TryParse(viDoText, NumberStyles.Float | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out lat);
                    bool lonOk = double.TryParse(kinhDoText, NumberStyles.Float | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out lon);

                    if (!latOk || !lonOk)
                    {
                        MessageBox.Show($"Định dạng số không hợp lệ!\n\n" +
                                        $"Hãy nhập số thập phân, ví dụ:\n" +
                                        $"• 10.7769 hoặc 10,7769\n" +
                                        $"• -25.6628 (số âm cho Nam/Tây)\n" +
                                        $"• 106.7009",
                                        "Lỗi định dạng",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra phạm vi hợp lệ
                    if (lat < -90 || lat > 90)
                    {
                        MessageBox.Show($"Vĩ độ phải nằm trong khoảng -90 đến 90!\nBạn nhập: {lat}",
                                        "Vĩ độ không hợp lệ",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    if (lon < -180 || lon > 180)
                    {
                        MessageBox.Show($"Kinh độ phải nằm trong khoảng -180 đến 180!\nBạn nhập: {lon}",
                                        "Kinh độ không hợp lệ",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            }

            await LayDuLieuThoiTiet(lat, lon);
        }

        private async Task LayDuLieuThoiTiet(double lat, double lon)
        {
            try
            {
                string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";
                HttpClient client = new HttpClient();
                var res = await client.GetAsync(url);
                string result = await res.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(result);

                if (data == null || data.current_weather == null)
                {
                    MessageBox.Show("Không lấy được dữ liệu thời tiết!");
                    return;
                }

                // Cập nhật nội dung
                double temp = data.current_weather.temperature;
                double wind = data.current_weather.windspeed;
                int weatherCode = data.current_weather.weathercode;
                string time = data.current_weather.time;

                txtNhietDo.Text = $"{temp}°C";
                txtGio.Text = $"{wind} km/h";
                txtThoiGianCapNhat.Text = DateTime.Parse(time).ToString("HH:mm:ss");

                // Ban đầu: ẩn chữ (trong suốt)
                txtNhietDo.ForeColor = Color.Transparent;
                txtGio.ForeColor = Color.Transparent;

                // Reset tất cả icon
                picWeatherIcon.Image = null;
                picWindIcon.Image = null;

                // Chọn icon thời tiết
                if (temp > 35)
                {
                    picWeatherIcon.Image = BT5_1_AppThoiTiet.Properties.Resources.sunico;
                }
                else if (weatherCode >= 61 && weatherCode <= 67)
                {
                    picWeatherIcon.Image = BT5_1_AppThoiTiet.Properties.Resources.rainico;
                }

                // Chọn icon gió
                if (wind > 20)
                {
                    picWindIcon.Image = BT5_1_AppThoiTiet.Properties.Resources.windico;
                }

                // Tạo timer fade-in
                System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
                fadeTimer.Interval = 50;

                double opacity = 0;

                // Tăng dần alpha (độ đậm của chữ)
                fadeTimer.Tick += (s, e) =>
                {
                    opacity += 0.1;
                    if (opacity > 1) opacity = 1;

                    // Chọn màu dựa vào nhiệt độ
                    Color tempColor = temp > 35 ? Color.Red : Color.Black;

                    lbNhietDo.ForeColor = Color.FromArgb((int)(255 * opacity), tempColor);
                    lbGio.ForeColor = Color.FromArgb((int)(255 * opacity), Color.Black);

                    if (opacity >= 1)
                        fadeTimer.Stop();
                };

                // Bắt đầu hiệu ứng
                fadeTimer.Start();

                MessageBox.Show("Cập nhật dữ liệu thời tiết thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu thời tiết: {ex.Message}",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void cbThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThanhPho.SelectedItem == null) return;

            string selected = cbThanhPho.SelectedItem.ToString();

            if (selected == "Khác")
            {
                // Chỉ cho phép nhập kinh độ, vĩ độ
                txtKinhDo.ReadOnly = false;
                txtViDo.ReadOnly = false;
                txtKinhDo.Clear();
                txtViDo.Clear();
            }
            else
            {
                // Còn lại: readonly = true, và tự hiển thị tọa độ cố định
                txtKinhDo.ReadOnly = true;
                txtViDo.ReadOnly = true;

                switch (selected)
                {
                    case "TP.HCM":
                        txtViDo.Text = "10.7769";
                        txtKinhDo.Text = "106.7009";
                        break;
                    case "Hà Nội":
                        txtViDo.Text = "21.0285";
                        txtKinhDo.Text = "105.834";
                        break;
                    case "Đà Nẵng":
                        txtViDo.Text = "16.0471";
                        txtKinhDo.Text = "108.2068";
                        break;
                }
            }
        }
    }
}
