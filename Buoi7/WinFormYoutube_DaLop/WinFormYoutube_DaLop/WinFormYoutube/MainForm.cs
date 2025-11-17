using BLL_WinformsYoutube;
using DAL_WinfromsYoutube;
using DTO_WinformsYoutube;
using Microsoft.Data.SqlClient;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;


namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        private readonly YTVideoBLL _bll;
        private List<YTVideoDTO> videos = new List<YTVideoDTO>();

        public MainForm()
        {
            InitializeComponent();

            // Khởi tạo DAL + BLL
            var dal = new YTVideoDAL("Data Source=DESKTOP-PANO27V\\SQLEXPRESS;Initial Catalog=YoutubeApp;Integrated Security=True;TrustServerCertificate=True;");
            _bll = new YTVideoBLL(dal);

            InitializeDataGridColumns();
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
            await LoadTrendingFromBLLAsync();
        }
        private async Task LoadTrendingFromBLLAsync()
        {
            SetUiBusy("Loading trending from YouTube...");
            try
            {
                // Gọi BLL để load trending từ YouTube
                videos = await _bll.LoadTrendingAsync();

                // Bind lên DataGridView
                BindGrid(videos);

                SetUiReady($"Trending loaded: {videos.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading trending: " + ex.Message);
                SetUiReady("Error");
            }
        }

        private async void BtnTrending_Click(object sender, EventArgs e)
        {
            try
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd");

                if (_bll.HasTrendingData(today))
                {
                    MessageBox.Show("Đã có dữ liệu trending hôm nay, không cần tải lại.");
                    return;
                }

                SetUiBusy("Loading trending...");
                videos = await _bll.LoadTrendingAsync();
                _bll.SaveTrending(videos, today);
                BindGrid(videos);
                SetUiReady($"Trending loaded: {videos.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                SetUiReady("Error");
            }
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(query)) return;

            try
            {
                SetUiBusy($"Searching \"{query}\"...");
                videos = await _bll.SearchAsync(query);
                BindGrid(videos);
                SetUiReady($"Search results: {videos.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                SetUiReady("Error");
            }
        }

        private void BindGrid(List<YTVideoDTO> list)
        {
            dgvVideos.Rows.Clear();
            foreach (var v in list)
            {
                dgvVideos.Rows.Add(
                    v.Title,
                    v.ChannelTitle,
                    v.ViewCount.ToString("N0"),
                    v.LikeCount.ToString("N0"),
                    v.PublishedAt?.ToString("yyyy-MM-dd"),
                    v.Description,
                    v.VideoId
                );
            }
        }

        private async void DgvVideos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVideos.SelectedRows.Count == 0) return;

            var videoId = dgvVideos.SelectedRows[0].Cells["VideoId"].Value?.ToString();
            if (string.IsNullOrEmpty(videoId)) return;

            var v = videos.FirstOrDefault(x => x.VideoId == videoId);
            if (v == null) return;

            lblStatus.Text = $"Selected: {v.Title}";

            // Hiển thị Thumbnail
            if (!string.IsNullOrEmpty(v.ThumbnailUrl))
            {
                LoadThumbnail(v.ThumbnailUrl);
            }
            else
            {
                picThumbnail.Image = null;
            }
        }

        private async void LoadThumbnail(string url)
        {
            try
            {
                using var http = new System.Net.Http.HttpClient();
                var bytes = await http.GetByteArrayAsync(url);
                using var ms = new MemoryStream(bytes);
                picThumbnail.Image?.Dispose();
                picThumbnail.Image = System.Drawing.Image.FromStream(ms);
                picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                picThumbnail.Image = null;
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            PlaySelected();
        }

        private void DgvVideos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) PlaySelected();
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
    }
}
