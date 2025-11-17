using Microsoft.Web.WebView2.WinForms;

namespace WinFormsApp2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls (Designer)
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnTrending;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.DataGridView dgvVideos;

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox picThumbnail;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelTop = new Panel();
            pictureBox1 = new PictureBox();
            btnTrending = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnPlay = new Button();
            lblStatus = new Label();
            splitContainerMain = new SplitContainer();
            dgvVideos = new DataGridView();
            panelRight = new Panel();
            webView = new WebView2();
            picThumbnail = new PictureBox();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideos).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.Window;
            panelTop.Controls.Add(pictureBox1);
            panelTop.Controls.Add(btnTrending);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(btnPlay);
            panelTop.Controls.Add(lblStatus);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(6);
            panelTop.Size = new Size(1221, 140);
            panelTop.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(124, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnTrending
            // 
            btnTrending.Location = new Point(145, 33);
            btnTrending.Name = "btnTrending";
            btnTrending.Size = new Size(140, 29);
            btnTrending.TabIndex = 0;
            btnTrending.Text = "Load Trending (VN)";
            btnTrending.Click += BtnTrending_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(297, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(420, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(727, 33);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.Click += BtnSearch_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(145, 89);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(140, 29);
            btnPlay.TabIndex = 3;
            btnPlay.Text = "Play Selected";
            btnPlay.Click += BtnPlay_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(297, 93);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Ready";
            // 
            // splitContainerMain
            // 
            splitContainerMain.BackColor = SystemColors.Window;
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 140);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(dgvVideos);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelRight);
            splitContainerMain.Size = new Size(1221, 604);
            splitContainerMain.SplitterDistance = 982;
            splitContainerMain.TabIndex = 0;
            // 
            // dgvVideos
            // 
            dgvVideos.AllowUserToAddRows = false;
            dgvVideos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVideos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVideos.Dock = DockStyle.Fill;
            dgvVideos.Location = new Point(0, 0);
            dgvVideos.MultiSelect = false;
            dgvVideos.Name = "dgvVideos";
            dgvVideos.ReadOnly = true;
            dgvVideos.RowHeadersWidth = 51;
            dgvVideos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVideos.Size = new Size(982, 604);
            dgvVideos.TabIndex = 0;
            dgvVideos.CellDoubleClick += DgvVideos_CellDoubleClick;
            dgvVideos.SelectionChanged += DgvVideos_SelectionChanged;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(webView);
            panelRight.Controls.Add(picThumbnail);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(8);
            panelRight.Size = new Size(235, 604);
            panelRight.TabIndex = 0;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.BackColor = SystemColors.Window;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Dock = DockStyle.Fill;
            webView.Location = new Point(8, 228);
            webView.Name = "webView";
            webView.Size = new Size(219, 368);
            webView.TabIndex = 0;
            webView.ZoomFactor = 1D;
            // 
            // picThumbnail
            // 
            picThumbnail.BackColor = SystemColors.Window;
            picThumbnail.BorderStyle = BorderStyle.FixedSingle;
            picThumbnail.Dock = DockStyle.Top;
            picThumbnail.Location = new Point(8, 8);
            picThumbnail.Margin = new Padding(0, 0, 0, 8);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(219, 220);
            picThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            picThumbnail.TabIndex = 1;
            picThumbnail.TabStop = false;
            // 
            // MainForm
            // 
            ClientSize = new Size(1221, 744);
            Controls.Add(splitContainerMain);
            Controls.Add(panelTop);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YouTube Trending (VN) - Designer Layout";
            Load += Form1_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVideos).EndInit();
            panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
    }
}
