using System;
using System.Windows.Forms;
using System.Diagnostics;
using WinFormsApp1;
using WinFormsApp2;
using WeatherAdmin;
using WeatherUser;
using DaLop;

namespace BT_LMS
{
    public partial class MainFormLMS : Form
    {
        private Process? weatherServerProcess;
        private Process? weatherHubProcess;

        public MainFormLMS()
        {
            InitializeComponent();
            IsMdiContainer = true;

            timer1.Tick += timer1_Tick; // đảm bảo timer hoạt động
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tslbTime.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private string GetAppPath(string fileName, string subFolder = null)
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "ExternalApps");

            if (!string.IsNullOrEmpty(subFolder))
                return Path.GetFullPath(Path.Combine(basePath, subFolder, fileName));

            return Path.GetFullPath(Path.Combine(basePath, fileName));
        }


        private void mnsBTVN_BT5_1_AppThoiTiet_Click(object sender, EventArgs e)
        {
            AppThoiTiet frmAppThoiTiet = new AppThoiTiet();
            frmAppThoiTiet.MdiParent = this;
            frmAppThoiTiet.Show();
        }

        private void mnsBTVN_BT5_2_WinformsYoutube_Click(object sender, EventArgs e)
        {
            MainFormYT frmMainFormYT = new MainFormYT();
            frmMainFormYT.MdiParent = this;
            frmMainFormYT.Show();
        }

        private async void mnsBTVN_BT5_3_Weather_Click(object sender, EventArgs e)
        {
            try
            {
                await StartWeatherServerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi chạy WeatherServer: " + ex.Message);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "http://localhost:5000",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được trình duyệt: " + ex.Message);
            }

            AppAdmin frmAdmin = new AppAdmin();
            frmAdmin.MdiParent = this;
            frmAdmin.Show();

            AppUser frmUser = new AppUser();
            frmUser.MdiParent = this;
            frmUser.Show();
        }

        private async Task StartWeatherServerAsync()
        {
            if (weatherServerProcess == null || weatherServerProcess.HasExited)
            {
                string serverPath = GetAppPath("WeatherServer.exe", "WeatherServer_DaLop");

                weatherServerProcess = new Process();
                weatherServerProcess.StartInfo.FileName = serverPath;
                weatherServerProcess.StartInfo.UseShellExecute = true;
                weatherServerProcess.Start();

                await Task.Delay(5000);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (weatherServerProcess != null)
            {
                try
                {
                    if (!weatherServerProcess.HasExited)
                        weatherServerProcess.Kill();
                }
                catch { }

                weatherServerProcess.Dispose();
                weatherServerProcess = null;
            }
        }

        private void mnsBTVN_BT4_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("QLBH.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được QLBH: " + ex.Message);
            }
        }

        private void msBTVN_BT3_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("BT3.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT3: " + ex.Message);
            }
        }

        private void mnsBTVN_BT2_3_DangKySp_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("BT2.3.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT2.3: " + ex.Message);
            }
        }

        private void mnsBTVN_BT2_4_DangNhap_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("BT2.4_DangNhap.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT2.4: " + ex.Message);
            }
        }

        private void mnsBTVN_BT2_5_QuanLy_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("BT2.5_QuanLy.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT2.5: " + ex.Message);
            }
        }

        private void mnsBTVN_BT1_3_Form_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("BT1.3_Form.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT1.3: " + ex.Message);
            }
        }

        private void mnsBTVN_BT1_4_MTBT_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("BT1_4.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT1.4: " + ex.Message);
            }
        }

        private void mnsBTVN_BT1_5_UCBC_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("BT1.5_UCLN_BCNN.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT1.5: " + ex.Message);
            }
        }

        private void mnsLMS_BT4_DaLop_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("DaLop.exe", "BT4_DaLop");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT4: " + ex.Message);
            }
        }

        private void mnsLMS_BT5_1_DaLop_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("PL_AppThoiTiet.exe", "BT5_1_DaLop");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT5_1: " + ex.Message);
            }
        }

        private void mnsLMS_BT5_2_DaLop_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("PL_WinformsYoutube.exe", "BT5_2_DaLop");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT5_2: " + ex.Message);
            }
        }

        private async void mnsLMS_BT5_3_DaLop_Click(object sender, EventArgs e)
        {
            try
            {
                await StartWeatherHubAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi chạy WeatherHub: " + ex.Message);
                return;
            }

            OpenAdminAndUser();
        }

        private async Task StartWeatherHubAsync()
        {
            if (weatherHubProcess == null || weatherHubProcess.HasExited)
            {
                string hubPath = GetAppPath("WeatherServer_DaLop.exe", "WeatherServer_DaLop");

                weatherHubProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = hubPath,
                        UseShellExecute = true
                    }
                };
                weatherHubProcess.Start();
                await Task.Delay(5000);
            }
        }
        private Form FindOpenedForm(Type formType)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == formType)
                    return child;
            }
            return null;
        }

        private void OpenAdminAndUser()
        {
            var frmAdmin = FindOpenedForm(typeof(AppAdmin_DaLop)) ?? new AppAdmin_DaLop();
            frmAdmin.MdiParent = this;
            frmAdmin.Show();

            var frmUser = FindOpenedForm(typeof(AppUser_DaLop)) ?? new AppUser_DaLop();
            frmUser.MdiParent = this;
            frmUser.Show();
        }

        private void tsMTBT_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("BT1_4.exe");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT1.4: " + ex.Message);
            }
        }

        private void tsQLBH_DaLop_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("DaLop.exe", "BT4_DaLop");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT4: " + ex.Message);
            }
        }

        private void tsYoutube_DaLop_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("PL_WinformsYoutube.exe", "BT5_2_DaLop");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT5_2: " + ex.Message);
            }
        }

        private void tsThoiTiet_DaLop_Click(object sender, EventArgs e)
        {
            string exePath = GetAppPath("PL_AppThoiTiet.exe", "BT5_1_DaLop");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được BT5_1: " + ex.Message);
            }
        }
    }
}
