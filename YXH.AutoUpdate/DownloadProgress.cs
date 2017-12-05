using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using YXH.Common;

namespace YXH.AutoUpdate
{
    public partial class DownloadProgress : Form
    {
        /// <summary>
        /// 下载文件的服务器地址
        /// </summary>
        string serviceAddress = string.Empty;
        /// <summary>
        /// 文件的本地存储目录
        /// </summary>
        string locaSavePath = string.Empty;

        /// <summary>
        /// 构造方法
        /// </summary>
        public DownloadProgress()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 确定更新
        /// </summary>
        private void ConfirmUpdate()
        {
            DialogResult dialogResult = MessageBox.Show("有新的更新，您要现在更新吗？", "程序更新", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dialogResult)
            {
                this.BeginUpdate();
                return;
            }
            base.Close();
        }

        /// <summary>
        /// 开始更新
        /// </summary>
        private void BeginUpdate()
        {
            ApplicationDeployment currentDeployment = ApplicationDeployment.CurrentDeployment;
            currentDeployment.UpdateCompleted += new AsyncCompletedEventHandler(this.ad_UpdateCompleted);
            currentDeployment.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(this.ad_UpdateProgressChanged);
            currentDeployment.UpdateAsync();
        }

        /// <summary>
        /// 更新状态事件
        /// </summary>
        private void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("程序更新已被取消！");
                return;
            }
            if (e.Error != null)
            {
                MessageBox.Show("错误: 不能安装最新版程序。原因: \n" + e.Error.Message + "\n请联系管理员。");
                return;
            }
            this.btnRestart.Enabled = true;
            this.lblHeader.Text = "安装完成!新版本重启后才会生效!";
        }

        /// <summary>
        /// 更新处理改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage < 1)
            {
                this.pbar.Value = 1;
                return;
            }
            this.pbar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// 安装按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstall_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        /// <summary>
        /// 窗体显示事件
        /// </summary>
        private void DownloadProgress_Shown(object sender, EventArgs e)
        {
            LogHelper.WriteInfoLog("下载更新");
            HttpDownloadFile();
            LogHelper.WriteInfoLog("安装更新");
            InstallNewVersion();
        }

        /// <summary>
        /// 安装下载的更新程序
        /// </summary>
        private void InstallNewVersion()
        {
            if (!File.Exists(locaSavePath))
            {
                MessageBox.Show("未检测到硬盘上可安装的应用程序文件，请确认下载配置是否正确！");

                return;
            }

            new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = locaSavePath
                }
            }.Start();

            Environment.Exit(0);
        }

        /// <summary>
        /// 重新开始按钮点击事件
        /// </summary>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        /// <summary>
        /// 退出按钮点击事件
        /// </summary>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="URL">服务器地址</param>
        /// <param name="filename">本地保存目录</param>
        /// <param name="prog">进度条</param>
        public void HttpDownloadFile()
        {
            float percent = 0;

            try
            {
                HttpWebRequest Myrq = (HttpWebRequest)HttpWebRequest.Create(serviceAddress);
                HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;

                if (pbar != null)
                {
                    pbar.Maximum = (int)totalBytes;
                }

                Stream st = myrp.GetResponseStream();
                Stream so = new FileStream(locaSavePath, FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[2048];
                int osize = st.Read(by, 0, (int)by.Length);

                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;

                    so.Write(by, 0, osize);

                    if (pbar != null)
                    {
                        pbar.Value = (int)totalDownloadedByte;
                    }

                    osize = st.Read(by, 0, (int)by.Length);
                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;

                    Application.DoEvents();
                }

                so.Close();
                st.Close();
            }
            catch (WebException wex)
            {
                HttpWebResponse hwr = (HttpWebResponse)wex.Response;

                if (hwr.StatusCode == HttpStatusCode.NotFound || hwr.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    MessageBox.Show("未检测到应用程序更新文件，下载失败，请稍后重试或联系管理员。" + Environment.NewLine + "点击确定退出更新程序并继续使用当前版本。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Process.GetCurrentProcess().Kill(); ///网络连接不稳定时，用户选择退出程序

                    return;
                }
                else
                {
                    MessageBox.Show(wex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Process.GetCurrentProcess().Kill(); ///网络连接不稳定时，用户选择退出程序

                    return;
                }
            }
            catch (Exception ex)
            {
                btnRestart.Enabled = false;

                MessageBox.Show(ex.Message);

                return;
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void DownloadProgress_Load(object sender, EventArgs e)
        {
            string[] angers = Environment.GetCommandLineArgs();

            if (angers.Length > 0)
            {
                try
                {
                    string[] addArray = angers[1].Split(',');

                    serviceAddress = addArray[0];
                    locaSavePath = addArray[1];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("调用服务的参数不匹配，请稍后重试", "提示");
                }
            }
        }
    }
}
