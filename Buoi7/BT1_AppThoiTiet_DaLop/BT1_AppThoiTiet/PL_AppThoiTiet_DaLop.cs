using DAL_AppThoiTiet;
using Newtonsoft.Json;
using System.Globalization;
using BLL_AppThoiTiet;
using DTO_AppThoiTiet;

namespace PL_AppThoiTiet_DaLop
{
    public partial class PL_AppThoiTiet_DaLop : Form
    {
        WeatherBLL bll = new WeatherBLL();
        WeatherDTO dto = null;

        public PL_AppThoiTiet_DaLop()
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
                    break;
            }

            // Gọi BLL
            dto = await bll.LayDuLieuThoiTiet(lat, lon);

            if (dto == null)
            {
                MessageBox.Show("Không lấy được dữ liệu!");
                return;
            }

            // Hiển thị lên giao diện
            txtNhietDo.Text = dto.Temperature + "°C";
            txtGio.Text = dto.WindSpeed + " km/h";
            txtThoiGianCapNhat.Text = dto.Time.ToString("HH:mm:ss");

            // Chọn icon
            picWeatherIcon.Image = null;
            picWindIcon.Image = null;

            if (dto.Temperature > 35)
                picWeatherIcon.Image = Properties.Resources.sunico;
            else if (dto.WeatherCode >= 61 && dto.WeatherCode <= 67)
                picWeatherIcon.Image = Properties.Resources.rainico;

            if (dto.WindSpeed > 20)
                picWindIcon.Image = Properties.Resources.windico;
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
