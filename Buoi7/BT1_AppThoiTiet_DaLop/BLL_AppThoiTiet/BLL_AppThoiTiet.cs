using DAL_AppThoiTiet;
using DTO_AppThoiTiet;

namespace BLL_AppThoiTiet
{
    public class WeatherBLL
    {
        private WeatherDAL dal = new WeatherDAL();

        public async Task<WeatherDTO?> LayDuLieuThoiTiet(double lat, double lon)
        {
            return await dal.GetWeatherAsync(lat, lon);
        }

        public bool KiemTraLatLon(double lat, double lon, out string message)
        {
            if (lat < -90 || lat > 90)
            {
                message = "Vĩ độ phải nằm trong khoảng -90 đến 90!";
                return false;
            }
            if (lon < -180 || lon > 180)
            {
                message = "Kinh độ phải nằm trong khoảng -180 đến 180!";
                return false;
            }

            message = "";
            return true;
        }
    }
}
