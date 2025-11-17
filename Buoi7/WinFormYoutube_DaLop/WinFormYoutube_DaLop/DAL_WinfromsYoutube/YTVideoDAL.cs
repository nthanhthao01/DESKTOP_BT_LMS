using DTO_WinformsYoutube;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Microsoft.Data.SqlClient;

namespace DAL_WinfromsYoutube
{
    public class YTVideoDAL
    {
        private readonly string _connectionString;

        public YTVideoDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool HasTrendingData(string today)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT COUNT(*) FROM TrendingVideos WHERE NgayLay=@ngay", conn);
            cmd.Parameters.AddWithValue("@ngay", today);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        public void SaveTrendingToDatabase(List<YTVideoDTO> videos, string today)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            foreach (var v in videos)
            {
                string sql = @"
                INSERT INTO TrendingVideos 
                (VideoId, Title, ChannelTitle, ViewCount, LikeCount, PublishedAt, Description, ThumbnailUrl, NgayLay)
                VALUES 
                (@id, @title, @channel, @views, @likes, @pub, @desc, @thumb, @ngay)";

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", v.VideoId);
                cmd.Parameters.AddWithValue("@title", v.Title);
                cmd.Parameters.AddWithValue("@channel", v.ChannelTitle);
                cmd.Parameters.AddWithValue("@views", v.ViewCount);
                cmd.Parameters.AddWithValue("@likes", v.LikeCount);
                cmd.Parameters.AddWithValue("@pub", (object?)v.PublishedAt ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@desc", v.Description ?? "");
                cmd.Parameters.AddWithValue("@thumb", v.ThumbnailUrl ?? "");
                cmd.Parameters.AddWithValue("@ngay", today);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
