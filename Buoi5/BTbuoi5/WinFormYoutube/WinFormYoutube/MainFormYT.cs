using System;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Microsoft.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class MainFormYT : Form
    {
        // ======= CONFIG =======
        private const string API_KEY = "AIzaSyATxN7Yl87Z0A5P3F7E3F0EoS4hwfIZ2BU"; // <-- thay API key của bạn vào đây
        private const string REGION_CODE = "VN";
        private const int MAX_RESULTS = 25;
        //Chuỗi kết nối
        string strConnectionString = "Data Source=DESKTOP-PANO27V\\SQLEXPRESS; Initial Catalog=YoutubeApp; Integrated Security=True; TrustServerCertificate=True;";
        // =======================

        private HttpClient httpClient = new HttpClient();
        private List<YTVideo> videos = new List<YTVideo>();

        public MainFormYT()
        {
            InitializeComponent(); // gọi method trong Designer
            InitializeDataGridColumns();
            this.Load += Form1_Load;
        }

        private void InitializeDataGridColumns()
        {
            dgvVideos.Columns.Clear();

            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Title" });
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Channel", HeaderText = "Channel", FillWeight = 60 });
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Views", HeaderText = "Views", FillWeight = 45 });
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Likes", HeaderText = "Likes", FillWeight = 45 });          
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "PublishedAt", HeaderText = "Published", FillWeight = 60 }); 
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", FillWeight = 60 }); 
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "VideoId", HeaderText = "VideoId", Visible = false });
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Initializing WebView...";
            try
            {
                await webView.EnsureCoreWebView2Async();
                lblStatus.Text = "Ready";
            }
            catch
            {
                lblStatus.Text = "WebView2 not available - will open browser on Play";
            }

            // Optionally auto load trending
            await LoadTrendingAsync();
        }

        #region Data model
        private class YTVideo
        {
            public required string VideoId { get; set; }
            public required string Title { get; set; }
            public required string ChannelTitle { get; set; }
            public long ViewCount { get; set; }
            public required string ThumbnailUrl { get; set; }
            public long LikeCount { get; set; }
            public DateTime? PublishedAt { get; set; }
            public required string Description { get; set; }
        }
        #endregion

        #region API logic
        private async Task LoadTrendingAsync()
        {
            try
            {
                SetUiBusy("Loading trending...");
                videos.Clear();
                dgvVideos.Rows.Clear();

                string url = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&chart=mostPopular&regionCode={REGION_CODE}&maxResults={MAX_RESULTS}&key={API_KEY}";
                var resp = await httpClient.GetAsync(url);
                if (!resp.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error fetching trending: {resp.StatusCode}\n{await resp.Content.ReadAsStringAsync()}");
                    SetUiReady("Error loading trending");
                    return;
                }

                string json = await resp.Content.ReadAsStringAsync();
                var j = JObject.Parse(json);
                var items = (JArray)j["items"];

                foreach (var it in items)
                {
                    var id = (string)it["id"];
                    var snippet = it["snippet"];
                    var stats = it["statistics"];
                    var vid = new YTVideo
                    {
                        VideoId = id,
                        Title = (string)snippet["title"] ?? "",
                        ChannelTitle = (string)snippet["channelTitle"] ?? "",
                        ViewCount = stats != null && stats["viewCount"] != null ? (long)(stats.Value<long?>("viewCount") ?? 0) : 0,
                        ThumbnailUrl = (string)snippet["thumbnails"]?["medium"]?["url"] ?? (string)snippet["thumbnails"]?["default"]?["url"],
                        LikeCount = stats != null && stats["likeCount"] != null ? (long)(stats.Value<long?>("likeCount") ?? 0) : 0,
                        PublishedAt = DateTime.TryParse((string)snippet["publishedAt"],
                                        System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                                        System.Globalization.DateTimeStyles.None, out var dt) ? dt : null,
                        Description = (string)snippet["description"] ?? ""
                    };
                    videos.Add(vid);
                    dgvVideos.Rows.Add(vid.Title, vid.ChannelTitle, vid.ViewCount.ToString("N0"),vid.LikeCount, vid.PublishedAt, vid.Description ,vid.VideoId);
                }

                SetUiReady($"Loaded trending: {videos.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                SetUiReady("Error");
            }
        }

        private async Task SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) { MessageBox.Show("Please enter search terms."); return; }

            try
            {
                SetUiBusy($"Searching \"{query}\"...");
                videos.Clear();
                dgvVideos.Rows.Clear();

                string urlSearch = $"https://www.googleapis.com/youtube/v3/search?part=snippet&type=video&maxResults={MAX_RESULTS}&q={Uri.EscapeDataString(query)}&regionCode={REGION_CODE}&key={API_KEY}";
                var resp = await httpClient.GetAsync(urlSearch);
                if (!resp.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Search error: {resp.StatusCode}\n{await resp.Content.ReadAsStringAsync()}");
                    SetUiReady("Search error");
                    return;
                }

                string jsonSearch = await resp.Content.ReadAsStringAsync();
                var jSearch = JObject.Parse(jsonSearch);
                var items = (JArray)jSearch["items"];
                var ids = items.Select(it => (string)it["id"]?["videoId"]).Where(id => !string.IsNullOrEmpty(id)).ToList();
                if (ids.Count == 0) { SetUiReady("No results"); return; }

                string idsParam = string.Join(",", ids);
                string urlVideos = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id={idsParam}&key={API_KEY}";
                var resp2 = await httpClient.GetAsync(urlVideos);
                if (!resp2.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Videos error: {resp2.StatusCode}\n{await resp2.Content.ReadAsStringAsync()}");
                    SetUiReady("Error");
                    return;
                }

                string jsonVideos = await resp2.Content.ReadAsStringAsync();
                var jVideos = JObject.Parse(jsonVideos);
                var items2 = (JArray)jVideos["items"];
                foreach (var it in items2)
                {
                    var id = (string)it["id"];
                    var snippet = it["snippet"];
                    var stats = it["statistics"];
                    var vid = new YTVideo
                    {
                        VideoId = id,
                        Title = (string)snippet["title"] ?? "",
                        ChannelTitle = (string)snippet["channelTitle"] ?? "",
                        ViewCount = stats != null && stats["viewCount"] != null ? (long)(stats.Value<long?>("viewCount") ?? 0) : 0,
                        ThumbnailUrl = (string)snippet["thumbnails"]?["medium"]?["url"] ?? (string)snippet["thumbnails"]?["default"]?["url"],
                        LikeCount = stats != null && stats["likeCount"] != null ? (long)(stats.Value<long?>("likeCount") ?? 0) : 0,
                        PublishedAt = DateTime.TryParse((string)snippet["publishedAt"],
                                    System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                                    System.Globalization.DateTimeStyles.None, out var dt) ? dt : null,
                        Description = (string)snippet["description"] ?? ""
                    };
                    videos.Add(vid);
                    dgvVideos.Rows.Add(vid.Title, vid.ChannelTitle, vid.ViewCount.ToString("N0"), vid.LikeCount, vid.PublishedAt, vid.Description ,vid.VideoId);
                }

                SetUiReady($"Search results: {videos.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                SetUiReady("Error");
            }
        }
        #endregion

        #region UI Helpers & Handlers
        private void SetUiBusy(string text)
        {
            lblStatus.Text = text;
            btnTrending.Enabled = btnSearch.Enabled = btnPlay.Enabled = false;
        }

        private void SetUiReady(string text)
        {
            lblStatus.Text = text;
            btnTrending.Enabled = btnSearch.Enabled = btnPlay.Enabled = true;
        }

        private async void BtnTrending_Click(object sender, EventArgs e)
        {
            try
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd");

                if (HasTrendingData(today))
                {
                    MessageBox.Show("Đã có dữ liệu trending hôm nay, không cần tải lại.");
                    return; 
                }

                // Nếu chưa có thì load từ YouTube và lưu vào CSDL
                SetUiBusy("Đang tải trending từ YouTube...");
                await LoadTrendingAsync();
                SaveTrendingToDatabase(videos, today);
                MessageBox.Show("Đã tải trending mới và lưu vào CSDL!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải trending: " + ex.Message);
            }
            finally
            {
                SetUiReady("Sẵn sàng");
            }
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await SearchAsync(txtSearch.Text.Trim());
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            PlaySelected();
        }

        private void DgvVideos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) PlaySelected();
        }

        private async void DgvVideos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVideos.SelectedRows.Count == 0) return;

            var videoId = dgvVideos.SelectedRows[0].Cells["VideoId"].Value?.ToString();
            if (string.IsNullOrEmpty(videoId)) return;

            var v = videos.FirstOrDefault(x => x.VideoId == videoId);
            if (v == null) return;

            lblStatus.Text = $"Selected: {v.Title}";

            if (!string.IsNullOrEmpty(v.ThumbnailUrl))
            {
                try
                {
                    var imageBytes = await httpClient.GetByteArrayAsync(v.ThumbnailUrl);
                    using var ms = new MemoryStream(imageBytes);
                    picThumbnail.Image?.Dispose();
                    picThumbnail.Image = Image.FromStream(ms);
                    picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
                    picThumbnail.Visible = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading thumbnail: {ex.Message}");
                    picThumbnail.Image = null;
                }
            }
            else
            {
                picThumbnail.Image = null;
            }
        }

        private void PlaySelected()
        {
            if (dgvVideos.SelectedRows.Count == 0) { MessageBox.Show("Please select a video first."); return; }
            string id = dgvVideos.SelectedRows[0].Cells["VideoId"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            string url = $"https://www.youtube.com/watch?v={id}";

            if (webView?.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(url);
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = url, UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot open browser: " + ex.Message);
                }
            }
        }
        #endregion    

        #region CSDL

        private bool HasTrendingData(string today)
        {
            using (var conn = new SqlConnection(strConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM TrendingVideos WHERE NgayLay = @ngay";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ngay", today);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        private void SaveTrendingToDatabase(List<YTVideo> videos, string today)
        {
            using (var conn = new SqlConnection(strConnectionString))
            {
                conn.Open();

                foreach (var v in videos)
                {
                    string sql = @"
                INSERT INTO TrendingVideos 
                (VideoId, Title, ChannelTitle, ViewCount, LikeCount, PublishedAt, Description, ThumbnailUrl, NgayLay)
                VALUES 
                (@id, @title, @channel, @views, @likes, @pub, @desc, @thumb, @ngay)";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
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
        #endregion
    }
}
