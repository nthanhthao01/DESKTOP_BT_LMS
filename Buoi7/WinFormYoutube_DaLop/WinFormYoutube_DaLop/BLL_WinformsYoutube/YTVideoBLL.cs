using DAL_WinfromsYoutube;
using DTO_WinformsYoutube;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using System.Windows.Forms;

namespace BLL_WinformsYoutube
{
    public class YTVideoBLL
    {
        private const string API_KEY = "AIzaSyATxN7Yl87Z0A5P3F7E3F0EoS4hwfIZ2BU"; // thay API key
        private const string REGION_CODE = "VN";
        private const int MAX_RESULTS = 25;
        private readonly YTVideoDAL _dal;
        private readonly HttpClient _httpClient;

        public YTVideoBLL(YTVideoDAL dal)
        {
            _dal = dal;
            _httpClient = new HttpClient();
        }

        public bool HasTrendingData(string today)
        {
            return _dal.HasTrendingData(today);
        }

        public void SaveTrending(List<YTVideoDTO> videos, string today)
        {
            if (videos == null || videos.Count == 0) return;
            _dal.SaveTrendingToDatabase(videos, today);

        }

        // Load trending từ YouTube
        public async Task<List<YTVideoDTO>> LoadTrendingAsync()
        {
            var videos = new List<YTVideoDTO>();
            string url = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&chart=mostPopular&regionCode={REGION_CODE}&maxResults={MAX_RESULTS}&key={API_KEY}";

            var resp = await _httpClient.GetAsync(url);
            resp.EnsureSuccessStatusCode();
            string json = await resp.Content.ReadAsStringAsync();

            var j = JObject.Parse(json);
            var items = (JArray)j["items"];

            foreach (var it in items)
            {
                var snippet = it["snippet"];
                var stats = it["statistics"];
                videos.Add(new YTVideoDTO
                {
                    VideoId = (string)it["id"] ?? "",
                    Title = (string)snippet["title"] ?? "",
                    ChannelTitle = (string)snippet["channelTitle"] ?? "",
                    ViewCount = stats?["viewCount"]?.Value<long>() ?? 0,
                    LikeCount = stats?["likeCount"]?.Value<long>() ?? 0,
                    PublishedAt = DateTime.TryParse((string)snippet["publishedAt"], out var dt) ? dt : null,
                    Description = (string)snippet["description"] ?? "",
                    ThumbnailUrl = (string)snippet["thumbnails"]?["medium"]?["url"] ?? ""
                });
            }

            return videos;
        }

        public async Task<List<YTVideoDTO>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<YTVideoDTO>();

            var videos = new List<YTVideoDTO>();

            // 1. Gọi API search
            string urlSearch = $"https://www.googleapis.com/youtube/v3/search?part=snippet&type=video&maxResults={MAX_RESULTS}&q={Uri.EscapeDataString(query)}&regionCode={REGION_CODE}&key={API_KEY}";
            var resp = await _httpClient.GetAsync(urlSearch);
            resp.EnsureSuccessStatusCode();
            string jsonSearch = await resp.Content.ReadAsStringAsync();

            var jSearch = JObject.Parse(jsonSearch);
            var items = (JArray)jSearch["items"];
            var ids = items.Select(it => (string)it["id"]?["videoId"])
                           .Where(id => !string.IsNullOrEmpty(id))
                           .ToList();

            if (ids.Count == 0) return videos;

            // 2. Gọi API videos lấy đầy đủ info
            string urlVideos = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id={string.Join(",", ids)}&key={API_KEY}";
            var resp2 = await _httpClient.GetAsync(urlVideos);
            resp2.EnsureSuccessStatusCode();
            string jsonVideos = await resp2.Content.ReadAsStringAsync();

            var jVideos = JObject.Parse(jsonVideos);
            var items2 = (JArray)jVideos["items"];

            foreach (var it in items2)
            {
                var snippet = it["snippet"];
                var stats = it["statistics"];
                videos.Add(new YTVideoDTO
                {
                    VideoId = (string)it["id"] ?? "",
                    Title = (string)snippet["title"] ?? "",
                    ChannelTitle = (string)snippet["channelTitle"] ?? "",
                    ViewCount = stats?["viewCount"]?.Value<long>() ?? 0,
                    LikeCount = stats?["likeCount"]?.Value<long>() ?? 0,
                    PublishedAt = DateTime.TryParse((string)snippet["publishedAt"], out var dt) ? dt : null,
                    Description = (string)snippet["description"] ?? "",
                    ThumbnailUrl = (string)snippet["thumbnails"]?["medium"]?["url"] ?? ""
                });
            }
            return videos;
        }
    }
}
