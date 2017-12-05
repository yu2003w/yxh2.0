using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.Enum;
using YXH.Common.Form;
using YXH.Common.Messages;
using YXH.Enum;
using YXH.HttpHelper;
using YXH.Model;
using YXH.Model.Request;
using YXH.ScanBLL;

namespace YXH.Main
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
        BaseDisposeBLL _bdBLL = new BaseDisposeBLL();
        /// <summary>
        /// 本机配置
        /// </summary>
        private MachineConfig configInfo;
        /// <summary>
        /// 主要操作窗体
        /// </summary>
        private MainScanForm _curMainfrm;
        /// <summary>
        /// 是记住用户名
        /// </summary>
        private bool _isRememberUser = true;
        /// <summary>
        /// 是清空本地数据
        /// </summary>
        private bool _isClearLocaldata = false;

        /// <summary>
        /// 构造方法
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            IntialParam();
            InitialScanSettingFromConfig();

            lblRememberUser.Image = _isRememberUser ? LoginFormRes.LoginForm_CheckBox_Selected : LoginFormRes.LoginForm_CheckBox_Normal;
            ckbRememberAccount.Checked = _isRememberUser;
            lblClearLocaldata.Image = _isClearLocaldata ? LoginFormRes.LoginForm_CheckBox_Selected : LoginFormRes.LoginForm_CheckBox_Normal;

            txtLoginName_Enter();
            txtLoginName_Leave();
            txtPassWord_Enter();
            txtPassWord_Leave();

            base.Icon = CommonRes.Application_Logo256;

            lblTitle.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// 从配置文件初始化扫描设置
        /// </summary>
        private void InitialScanSettingFromConfig()
        {
            string showAdvancedSetting = ConfigurationHelper.GetSetting("IsShowAdvancedSetting");

            if (string.Compare(showAdvancedSetting, "true", true) == 0)
            {
                ScanGlobalInfo.IsShowAdvancedSetting = true;
            }
            else
            {
                ScanGlobalInfo.IsShowAdvancedSetting = false;
            }

            string isOpenCreateTpByImg = ConfigurationHelper.GetSetting("isOpenCreateTpByImg");

            if (string.Compare(isOpenCreateTpByImg, "true", true) == 0)
            {
                ScanGlobalInfo.isOpenCreateTpByImg = true;
            }
            else
            {
                ScanGlobalInfo.isOpenCreateTpByImg = false;
            }

            string isOpenTestScan = ConfigurationHelper.GetSetting("isOpenTestScan");

            if (string.Compare(isOpenTestScan, "true", true) == 0)
            {
                ScanGlobalInfo.isOpenTestScan = true;
            }
            else
            {
                ScanGlobalInfo.isOpenTestScan = false;
            }

            string imgSourceType = ConfigurationHelper.GetSetting("ImgSourceType");

            if (imgSourceType != null)
            {
                if (imgSourceType == "BW")
                {
                    ScanGlobalInfo.scanImgSourceType = ImgSourceType.BW;
                }
                else if (imgSourceType == "GRAY")
                {
                    ScanGlobalInfo.scanImgSourceType = ImgSourceType.GRAY;
                }
                else if (imgSourceType == "RGB")
                {
                    ScanGlobalInfo.scanImgSourceType = ImgSourceType.RGB;
                }
                else
                {
                    ScanGlobalInfo.scanImgSourceType = ImgSourceType.GRAY;
                }
            }
            else
            {
                ScanGlobalInfo.scanImgSourceType = ImgSourceType.GRAY;
            }

            double recoSureValue = 0.26,
                recoNotSureValue = 0.2;

            try
            {
                recoSureValue = double.Parse(ConfigurationHelper.GetSetting("RecoSureValue"));
                recoNotSureValue = double.Parse(ConfigurationHelper.GetSetting("RecoNotSureValue"));
            }
            catch (Exception ex)
            {
                recoSureValue = 0.26;
                recoNotSureValue = 0.2;

                LogHelper.WriteFatalLog(ex.Message, ex);
            }

            ScanGlobalInfo.RecoNotSureValue = recoNotSureValue;
            ScanGlobalInfo.RecoSureValue = recoSureValue;
            string omrErrorStrategy = ConfigurationHelper.GetSetting("omrErrorStrategy");

            if (omrErrorStrategy != null)
            {
                if (omrErrorStrategy == "AUTOSKIP")
                {
                    ScanGlobalInfo.omrErrorStrategy = OmrErrorStrategy.AutoSetToNormal;
                }
                else if (omrErrorStrategy == "ERROR")
                {
                    ScanGlobalInfo.omrErrorStrategy = OmrErrorStrategy.SetToError;
                }
            }
            else
            {
                ScanGlobalInfo.omrErrorStrategy = OmrErrorStrategy.AutoSetToNormal;
            }
        }

        /// <summary>
        /// 初始化执行参数
        /// </summary>
        private void IntialParam()
        {
            GlobalInfo.LocalDataLocation = FileHelper.CreateLocalAppDataLocation();
            GlobalInfo.ApplicationSetupLocation = Application.StartupPath;

            if (!Directory.Exists(GlobalInfo.LocalDataLocation + "\\Config\\"))
            {
                Directory.CreateDirectory(GlobalInfo.LocalDataLocation + "\\Config\\");
            }
            if (File.Exists(GlobalInfo.LocalDataLocation + "\\Config\\MachineConfig.xml"))
            {
                try
                {
                    this.configInfo = FileHelper.DeseriXmlModel<MachineConfig>(GlobalInfo.LocalDataLocation + "\\Config\\MachineConfig.xml");

                    if (!string.IsNullOrEmpty(this.configInfo.ScanAccountName) && !string.IsNullOrEmpty(this.configInfo.ScanAccountPsw))
                    {
                        this.txtLoginName.Text = this.configInfo.ScanAccountName;
                        this.txtPassWord.Text = Crypt.DESDecrypt(this.configInfo.ScanAccountPsw, "aorangeK");
                    }
                }
                catch (Exception ex)
                {
                    this.configInfo = new MachineConfig();
                    this.configInfo.ScanID = Guid.NewGuid().ToString();

                    LogHelper.WriteFatalLog(ex.Message, ex);
                }
            }
            else
            {
                this.configInfo = new MachineConfig();
                this.configInfo.ScanID = Guid.NewGuid().ToString();
            }

            ScanGlobalInfo.LocalScanID = this.configInfo.ScanID;
        }

        /// <summary>
        /// 获取当前登录用户权限
        /// </summary>
        /// <returns>用户是否有权限登录</returns>
        private bool GetUserPermission()
        {
            PermissionResponse pr = new BaseDisposeBLL().User_GetPermission();

            if (pr.Success)
            {
                if (ScanGlobalInfo.loginUser.data.roles.Count > 0)
                {
                    return true;
                }

                MessageBox.Show("当前登录用户没有操作权限", "提示", MessageBoxButtons.OK);
                LogHelper.WriteInfoLog("当前用户没有登录权限");

                picBottom.Image = LoginFormRes.LoginForm_ButtomImage;

                return false;
            }

            MessageBox.Show(pr.Error.Message, "提示", MessageBoxButtons.OK);

            picBottom.Image = LoginFormRes.LoginForm_ButtomImage;

            return false;
        }

        /// <summary>
        /// 请求服务器，查询账户信息
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns>返回服务器处理后的数据集</returns>
        private bool Login(string loginName, string passWord)
        {
            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("账号或密码不能为空！", "提示", MessageBoxButtons.OK);

                return false;
            }

            LoginModel lModel = new LoginModel()
            {
                password = passWord,
                tenancyName = ConfigurationHelper.GetSetting("LoginTenancyName"),
                usernameOrEmailAddress = loginName.Trim()
            };

            try
            {
                UserInfo uiModel = _bdBLL.User_Login(lModel);

                if (uiModel.Success)
                {
                    if (GetUserPermission())
                    {
                        return true;
                    }

                    return false;
                }

                MessageBox.Show(string.Format("登录提示：{0}{1}详细信息：{2}", uiModel.Error.Message, Environment.NewLine, uiModel.Error.Details), "提示", MessageBoxButtons.OK);

                picBottom.Image = LoginFormRes.LoginForm_ButtomImage;

                return false;
            }
            catch (Exception ex)
            {
                string resultmsg = "远程服务暂时无法连接!请尝试以下操作:\n1.检查当前网络是否已断开\n2.检查当前的系统时间是否为正确的北京时间\n错误详情：\n" + ex.Message.ToString() + "\n";

                LogHelper.WriteFatalLog(ex.Message, ex);
                _bdBLL.System_SaveErrorLog(ex, resultmsg);
                MessageBox.Show(resultmsg, "提示", MessageBoxButtons.OK);

                picBottom.Image = LoginFormRes.LoginForm_ButtomImage;

                return false;
            }
        }

        /// <summary>
        /// 创建程序工作位置
        /// </summary>
        private void CreateWorkingPlace()
        {
            LocalSettingConfig localSettingConfig = new LocalSettingConfig();

            if (!File.Exists(GlobalInfo.LocalDataLocation + "\\Config\\LocalSettingConfig.xml"))
            {
                MessageBox.Show("请设置一个工作目录（该目录最好不是系统盘，并且有2G的空间）");

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                folderBrowserDialog.SelectedPath = Path.GetDirectoryName(Application.ExecutablePath);
                folderBrowserDialog.Description = "设置扫描目录（该目录用来存放扫描的图片模板扫描结果等文件）。";

                bool flag;

                do
                {
                    DialogResult dialogResult = folderBrowserDialog.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        localSettingConfig.LocalFileLocation = folderBrowserDialog.SelectedPath.Trim(new char[]
						{
							','
						});
                    }
                    else
                    {
                        localSettingConfig.LocalFileLocation = Application.StartupPath;
                    }

                    flag = FileHelper.HasWritePermission(localSettingConfig.LocalFileLocation);

                    if (!flag)
                    {
                        MessageBox.Show("请选择一个有写权限的文件夹！");
                    }
                }
                while (!flag);

                GlobalInfo.LocalFileLocation = localSettingConfig.LocalFileLocation;

                FileHelper.SeriXmlModel<LocalSettingConfig>(GlobalInfo.LocalDataLocation + "\\Config\\LocalSettingConfig.xml", localSettingConfig);

                return;
            }

            try
            {
                localSettingConfig = FileHelper.DeseriXmlModel<LocalSettingConfig>(GlobalInfo.LocalDataLocation + "\\Config\\LocalSettingConfig.xml");

                if (localSettingConfig.LocalFileLocation == ".\\")
                {
                    localSettingConfig.LocalFileLocation = Application.StartupPath;
                }
                if (Directory.Exists(localSettingConfig.LocalFileLocation))
                {
                    GlobalInfo.LocalFileLocation = localSettingConfig.LocalFileLocation;
                }
                else
                {
                    MessageBox.Show(string.Format("图片保存路径{0}不存在，需要重新选择一个工作目录！", localSettingConfig.LocalFileLocation));
                    LogHelper.WriteInfoLog(string.Format("路径{0}不存在，需要重新选择一个工作目录！", localSettingConfig.LocalFileLocation));

                    if (File.Exists(GlobalInfo.LocalDataLocation + "\\Config\\LocalSettingConfig.xml"))
                    {
                        File.Delete(GlobalInfo.LocalDataLocation + "\\Config\\LocalSettingConfig.xml");
                    }

                    this.CreateWorkingPlace();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);

                if (File.Exists(GlobalInfo.LocalDataLocation + "\\Config\\LocalSettingConfig.xml"))
                {
                    File.Delete(GlobalInfo.LocalDataLocation + "\\Config\\LocalSettingConfig.xml");
                }

                this.CreateWorkingPlace();
            }
        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Test start
            //txtLoginName.Text = "1381134";
            //txtPassWord.Text = "123456";
            //Test end

            GlobalInfo.LoginUserName = txtLoginName.Text;
            GlobalInfo.LoginPassWord = txtPassWord.Text;

            picBottom.Image = LoginFormRes.LoginForm_ButtomImage_Load;

            Application.DoEvents();

            txtLoginName.Enabled = false;
            txtPassWord.Enabled = false;
            lblRememberUser.Enabled = false;
            lblClearLocaldata.Enabled = false;

            if (!Login(this.txtLoginName.Text, this.txtPassWord.Text))
            {
                txtLoginName.Enabled = true;
                txtPassWord.Enabled = true;
                lblRememberUser.Enabled = true;
                lblClearLocaldata.Enabled = true;

                return;
            }

            base.Hide();

            if (_isRememberUser)    //处理记住密码操作
            {
                string text = this.txtLoginName.Text;
                string scanAccountPsw = Crypt.DESEncrypt(this.txtPassWord.Text, "aorangeK");
                this.configInfo.ScanAccountName = text;
                this.configInfo.ScanAccountPsw = scanAccountPsw;
            }
            else
            {
                this.configInfo.ScanAccountName = string.Empty;
                this.configInfo.ScanAccountPsw = string.Empty;
            }

            try
            {
                FileHelper.SeriXmlModel<MachineConfig>(GlobalInfo.LocalDataLocation + "\\Config\\MachineConfig.xml", this.configInfo);
                this.CreateWorkingPlace();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                LogHelper.WriteFatalLog(ex.Message, ex);
            }

            new Thread(new ThreadStart(ScanInfoInDaysBLL.GetScannedCountInDays))
            {
                IsBackground = true
            }.Start();

            this._curMainfrm = new MainScanForm();
            this._curMainfrm.Show();
            this._curMainfrm.SetLoginForm(this);
            this._curMainfrm.StartPosition = FormStartPosition.CenterParent;

            picBottom.Image = LoginFormRes.LoginForm_ButtomImage;

            txtLoginName.Enabled = true;
            txtPassWord.Enabled = true;
            lblRememberUser.Enabled = true;
            lblClearLocaldata.Enabled = true;
        }

        /// <summary>
        /// 检测正在运行的扫描程序并处理
        /// </summary>
        private void DistroyAnotherScanProc()
        {
            try
            {
                Process currentProcess = Process.GetCurrentProcess();
                Process[] processesByName = Process.GetProcessesByName("xscan");

                if (processesByName != null && processesByName.Length >= 2)
                {
                    if (MessageBox.Show("结束其他扫描程序实例才能运行，是否结束?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        int id = currentProcess.Id;
                        Process[] array = processesByName;

                        for (int i = 0; i < array.Length; i++)
                        {
                            Process process = array[i];

                            if (process.Id != id)
                            {
                                process.Kill();
                            }
                        }
                    }
                    else
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 窗体的加载事件
        /// </summary>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            string isMulClients = ConfigurationHelper.GetSetting("IsMulClients");

            if (string.IsNullOrEmpty(isMulClients))
            {
                return;
            }
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["IsMulClients"]))
            {
                this.DistroyAnotherScanProc();
            }
        }

        /// <summary>
        /// 检测程序是否需要更新
        /// </summary>
        private void CheckOfflineUpdate()
        {
            string text = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\offline\\";

            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }

            string updateBaseServiceAddress = ConfigurationHelper.GetSetting("UpdateBaseServiceAddress");

            if (string.IsNullOrWhiteSpace(updateBaseServiceAddress))
            {
                MessageBox.Show("未检测到更新服务器", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                return;
            }

            string publishVersioinFileName = ConfigurationHelper.GetSetting("OnLineVersionSettingFile");

            if (string.IsNullOrWhiteSpace(publishVersioinFileName))
            {
                MessageBox.Show("未检测到版本文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                return;
            }

            try
            {
                string url = string.Concat(updateBaseServiceAddress, publishVersioinFileName);
                HttpWebResponseUtility.HttpDownloadFile(url, text + publishVersioinFileName);
            }
            catch (WebException wex)
            {
                HttpWebResponse hwr = (HttpWebResponse)wex.Response;

                if (hwr == null)
                {
                    MessageBox.Show("当前网络连接异常，或网速过慢。无法请求到服务器,请检查网络后重试...", "提示", MessageBoxButtons.OK);

                    return;
                }
                if (hwr.StatusCode == HttpStatusCode.NotFound || hwr.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    return;
                }
                else
                {
                    MessageBox.Show(wex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    return;
                }
            }

            //PublishVersionInfo publishVersionInfo = SerializerHelper.DeseriXmlModel<PublishVersionInfo>(text + publishVersioinFileName);
            //string version = publishVersionInfo.Version;

            //try
            //{
            //    string versionFileName = ConfigurationHelper.GetSetting("LocalVersionSettingFile");

            //    if (string.IsNullOrWhiteSpace(versionFileName))
            //    {
            //        versionFileName = "Version.xml";
            //    }

            //    VersionInfo versionInfo;

            //    if (File.Exists(versionFileName))
            //    {
            //        versionInfo = SerializerHelper.DeseriXmlModel<VersionInfo>(versionFileName);
            //        string[] serverVersion = versionInfo.Version.Split('.');
            //        string[] locationVersion = version.Split('.');

            //        if (versionInfo.Version == version)
            //        {
            //            return;
            //        }

            //        if (serverVersion.Length > 0 && locationVersion.Length == serverVersion.Length)
            //        {
            //            for (int i = 0; i < serverVersion.Length; i++)
            //            {
            //                if (int.Parse(serverVersion[i]) < int.Parse(locationVersion[i]))
            //                {
            //                    return;
            //                }
            //                if (int.Parse(serverVersion[i]) > int.Parse(locationVersion[i]))
            //                {
            //                    break;
            //                }
            //                if (i == (serverVersion.Length - 1))
            //                {
            //                    return;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        versionInfo = new VersionInfo();
            //        versionInfo.Version = "2.0.0.0";
            //    }

            //    bool isForceUpadte = publishVersionInfo.IsForceUpdate;

            //    if (!isForceUpadte)
            //    {
            //        if (versionInfo.IgnoreVersion.Contains(version))
            //        {
            //            return;
            //        }
            //        if (MessageBox.Show("即将更新到" + version + "版本,是否继续?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
            //        {
            //            versionInfo.IgnoreVersion.Add(version);
            //            SerializerHelper.SeriXmlModel<VersionInfo>(versionFileName, versionInfo);

            //            return;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("即将更新到" + version + "版本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    }

            //    if (!Directory.Exists(string.Format("{0}/NewVersion", text)))
            //    {
            //        Directory.CreateDirectory(string.Format("{0}/NewVersion", text));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _bdBLL.System_SaveErrorLog(ex, "更新信息获取错误");

            //    return;
            //}
            //try
            //{
            //    string updateAppName = ConfigurationHelper.GetSetting("UpdateApplicationName");

            //    updateAppName = string.IsNullOrWhiteSpace(updateAppName) ? Path.Combine(Application.StartupPath, updateAppName) : Path.Combine(Application.StartupPath, "AutoUpdate.exe");

            //    new Process
            //    {
            //        StartInfo = new ProcessStartInfo
            //        {
            //            FileName = updateAppName,
            //            Arguments = string.Format("{0}{1}{2}", publishVersionInfo.PublishVersionPath, ",", string.Format("{0}/NewVersion/{1}", text, publishVersionInfo.SetupFileName))
            //        }
            //    }.Start();
            //}
            //catch (Exception ex)
            //{
            //    _bdBLL.System_SaveErrorLog(ex, "调用更新程序出错");

            //    MessageBox.Show("调用更新程序出现错误,请稍候重试", "提示", MessageBoxButtons.OK);

            //    return;
            //}
        }

        /// <summary>
        /// 窗体的显示事件
        /// </summary>
        private void FormLogin_Shown(object sender, EventArgs e)
        {
            Thread testNetWork = new Thread(new ThreadStart(delegate
            {
                FormProgress frmProgress = new FormProgress();

                Invoke(new MethodInvoker(delegate
                {
                    btnLogin.Enabled = false;
                    frmProgress.Show();
                    frmProgress.SetProgress(30, "正在检测网络连接状态...");
                }));

                LogHelper.WriteInfoLog("检测网络");

                NetWorkStatusEnum nwse = NetWorkHelper.CheckServeStatus();

                switch (nwse)
                {
                    case NetWorkStatusEnum.NotConn:
                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(100, "检测完成，网络未连接...");
                            frmProgress.Close();
                            MessageBox.Show(NetWorkStatusMessage.NOT_CONN_MESSAGE, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Process.GetCurrentProcess().Kill(); ///网络未连接时直接退出出程序
                        }));

                        break;
                    case NetWorkStatusEnum.ConnException:
                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(100, "检测完成，网络连接异常...");
                            frmProgress.Close();
                            MessageBox.Show(NetWorkStatusMessage.CONN_EXCEPTION_MESSAGE, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Process.GetCurrentProcess().Kill(); ///网络连接异常，不能正常使用时直接退出出程序
                        }));

                        break;
                    case NetWorkStatusEnum.ConnInstability:
                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(100, "检测完成，网络连接不稳定...");
                            frmProgress.Close();

                            if (MessageBox.Show(string.Format("{0},{1}", NetWorkStatusMessage.CONN_INSTABILITY_MESSAGE, "是否继续使用，这可能会造成数据丢失或图片丢失！"), "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                Process.GetCurrentProcess().Kill(); ///网络连接不稳定时，用户选择退出程序
                            }
                        }));

                        break;
                    case NetWorkStatusEnum.ConnNormal:
                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(100, "检测完成,网络连接正常");
                            frmProgress.Close();
                        }));

                        break;
                    case NetWorkStatusEnum.NotSettingSecondLevelTest:
                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(100, "检测完成，检测网络连接失败，使用高级检测未检测到配置...");
                            frmProgress.Close();
                            MessageBox.Show(NetWorkStatusMessage.NOT_SETTING_SECOND_LEVEL_TEST, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Process.GetCurrentProcess().Kill(); ///网络连接不稳定时，用户选择退出程序
                        }));

                        break;
                    default:
                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(100, "检测完成");
                            frmProgress.Close();

                            if (MessageBox.Show("检测当前网络状态失败,是否继续操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                Process.GetCurrentProcess().Kill();     //未能成功检测网络连接时，让用户选择是否继续
                            }
                        }));

                        break;
                }
                LogHelper.WriteInfoLog("获取更新模式");
                string setting = ConfigurationHelper.GetSetting("UpdateMode");

                if (setting == "AutoUpdate")
                {
                    string updateAppName = ConfigurationHelper.GetSetting("UpdateApplicationName"),
                        path = string.Empty;
                    LogHelper.WriteInfoLog("启动更新");
                    path = string.IsNullOrWhiteSpace(updateAppName) ? Path.Combine(Application.StartupPath, updateAppName) : Path.Combine(Application.StartupPath, "AutoUpdate.exe");

                    if (File.Exists(path))
                    {
                        this.CheckOfflineUpdate();
                    }
                }

                Invoke(new MethodInvoker(delegate
                {
                    btnLogin.Enabled = true;
                }));
            }));

            testNetWork.Start();
        }

        /// <summary>
        /// 最小化区域鼠标悬浮事件
        /// </summary>
        private void panMinimum_MouseHover(object sender, EventArgs e)
        {
            panMinimum.BackgroundImage = CommonRes.Minimum_Hover;
        }

        /// <summary>
        /// 最小化区域鼠标离开事件
        /// </summary>
        private void panMinimum_MouseLeave(object sender, EventArgs e)
        {
            panMinimum.BackgroundImage = CommonRes.Minimum_Normal;
        }

        /// <summary>
        /// 最小化区域点击事件
        /// </summary>
        private void panMinimum_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 关闭区域点击事件
        /// </summary>
        private void panClose_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// 关闭区域鼠标悬浮事件
        /// </summary>
        private void panClose_MouseHover(object sender, EventArgs e)
        {
            panClose.BackgroundImage = CommonRes.Close_Hover;
        }

        /// <summary>
        /// 关闭区域鼠标离开事件
        /// </summary>
        private void panClose_MouseLeave(object sender, EventArgs e)
        {
            panClose.BackgroundImage = CommonRes.Close_Normal;
        }

        /// <summary>
        /// 记住帐号标签点击事件
        /// </summary>
        private void lblRememberUser_Click(object sender, EventArgs e)
        {
            if (_isRememberUser)
            {
                lblRememberUser.Image = LoginFormRes.LoginForm_CheckBox_Selected;
                ckbRememberAccount.Checked = true;
            }
            else
            {
                lblRememberUser.Image = LoginFormRes.LoginForm_CheckBox_Normal;
                ckbRememberAccount.Checked = false;
            }

            _isRememberUser = !_isRememberUser;

            lblRememberUser.Focus();
        }

        /// <summary>
        /// 清空本地数据标签点击事件
        /// </summary>
        private void lblClearLocaldata_Click(object sender, EventArgs e)
        {
            lblClearLocaldata.Image = _isClearLocaldata ? LoginFormRes.LoginForm_CheckBox_Selected : LoginFormRes.LoginForm_CheckBox_Normal;
            _isClearLocaldata = !_isClearLocaldata;
        }

        /// <summary>
        /// 处理密码框获取焦点
        /// </summary>
        private void txtPassWord_Enter()
        {
            txtPassWord.ForeColor = Color.Black;

            if (txtPassWord.Text.Trim().Equals("请输入密码"))
            {
                txtPassWord.Text = string.Empty;
                txtPassWord.PasswordChar = '*';
            }
        }

        /// <summary>
        /// 密码框获得焦点事件
        /// </summary>
        private void txtPassWord_Enter(object sender, EventArgs e)
        {
            txtPassWord_Enter();
        }

        /// <summary>
        /// 处理密码框失去焦点
        /// </summary>
        private void txtPassWord_Leave()
        {
            if (txtPassWord.Text.Trim().Equals(string.Empty))
            {
                txtPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
                txtPassWord.Text = "请输入密码";
                txtPassWord.PasswordChar = '\0';
            }
        }

        /// <summary>
        /// 密码框失去焦点事件
        /// </summary>
        private void txtPassWord_Leave(object sender, EventArgs e)
        {
            txtPassWord_Leave();
        }

        /// <summary>
        /// 处理用户名框获取焦点
        /// </summary>
        private void txtLoginName_Enter()
        {
            if (txtLoginName.Text.Trim().Equals("请输入用户名"))
            {
                txtLoginName.Text = string.Empty;
            }

            txtLoginName.ForeColor = Color.Black;
        }

        /// <summary>
        /// 文本框获得焦点事件
        /// </summary>
        private void txtLoginName_Enter(object sender, EventArgs e)
        {
            txtLoginName_Enter();
        }

        /// <summary>
        /// 处理用户名框失去焦点
        /// </summary>
        private void txtLoginName_Leave()
        {
            if (txtLoginName.Text.Trim().Equals(string.Empty) || txtLoginName.Text.Trim().Equals("请输入用户名"))
            {
                txtLoginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
                txtLoginName.Text = "请输入用户名";
            }
        }

        /// <summary>
        /// 文本框失去焦点事件
        /// </summary>
        private void txtLoginName_Leave(object sender, EventArgs e)
        {
            txtLoginName_Leave();
        }

        /// <summary>
        /// 窗体顶部标题部分，鼠标按下事件
        /// </summary>
        private void panTopBbar_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture(); //捕获当前窗体
            Win32.SendMessage(base.Handle, 274, 61458, 0);  //发送当前窗体的即时句柄值
        }
    }
}