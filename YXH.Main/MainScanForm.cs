using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;
using YXH.ScanForm;
using YXH.TemplateForm;

namespace YXH.Main
{
    public partial class MainScanForm : Form
    {
        /// <summary>
        /// 登录窗体
        /// </summary>
        private LoginForm curLogin;
        /// <summary>
        /// 声明静态的当前窗体
        /// </summary>
        public static MainScanForm mainForm;
        /// <summary>
        /// 当前操作状态
        /// </summary>
        private OperateStatus _curOpStatus;
        /// <summary>
        /// 点击选项卡的状态
        /// </summary>
        public OperateStatus _tabStatus;

        /// <summary>
        /// 构造方法
        /// </summary>
        public MainScanForm()
        {
            MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);    //设置窗体的最大化时大小

            InitializeComponent();

            this.Text = string.Format("中矿阅卷 {0}v{1} ", Global.Instance.GetCurrentEnv(), Global.Instance.GetCurrentProVersion());

            this.InitialIcon();

            lblApplicationTitle.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// 初始化图标
        /// </summary>
        private void InitialIcon()
        {
            string text = ConfigurationManager.AppSettings["VersionEnv"];

            if (text != null)
            {
                if (text == "0")
                {
                    base.Icon = CommonRes.yuetest;

                    return;
                }
                if (text == "1")
                {
                    base.Icon = CommonRes.Application_Logo256;

                    return;
                }
                if (text == "2")
                {
                    base.Icon = CommonRes.yue48;

                    return;
                }
            }

            base.Icon = CommonRes.yue48;
        }

        /// <summary>
        /// 返回/退出 按钮点击事件
        /// </summary>
        private void picExitSystem_Click(object sender, EventArgs e)
        {
            if (this.curLogin != null
                && MessageBox.Show("是否确认退出登录？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.curLogin.Show();
                base.Dispose();

                return;
            }

            return;

            if (this._curOpStatus == OperateStatus.MainPage)
            {
            }
            else
            {
                if (this._curOpStatus == OperateStatus.ReUploadMaterials)
                {
                    this.StateManagement(OperateStatus.HistoryExamRecord, OperateStatus.MainPage);

                    return;
                }

                this.StateManagement("", OperateStatus.SubjectOperate);
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void MainScanForm_Load(object sender, EventArgs e)
        {
            this._curOpStatus = OperateStatus.MainPage;

            this.picExitSystem.SuspendLayout();

            this.picExitSystem.Text = "退出登录";
            this.picExitSystem.ForeColor = Color.Red;
            this.picExitSystem.Image = null;

            this.picExitSystem.ResumeLayout();
            this.StateManagement(OperateStatus.SubjectList, OperateStatus.MainPage);

            base.FormClosing += new FormClosingEventHandler(this.MainScanForm_Closing);
            MainScanForm.mainForm = this;
            Control.ControlCollection tabControlCollection = panTableCan.Controls;
            int panTableGoalWidth = 0;

            foreach (Control c in tabControlCollection)
            {
                if (c.Visible)
                {
                    panTableGoalWidth += c.Width;
                }
            }

            panTableCan.Location = new Point((Width - panTableGoalWidth) / 2, 41);
            picExamList.Tag = lblEximList.Tag = OperateStatus.SubjectList;
            picHistoryRecord.Tag = lblHistoryRecord.Tag = OperateStatus.HistoryExamRecord;
            picSystemSetting.Tag = lblSystemSetting.Tag = OperateStatus.SystemSetting;
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void MainScanForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                base.Dispose();
                Process.GetCurrentProcess().Kill();

                return;
            }

            e.Cancel = true;
        }

        /// <summary>
        /// 处理所有退出窗体
        /// </summary>
        private void DisposeAllExitForm()
        {
            if (this.panelBody.Controls.Count > 0)
            {
                foreach (Control control in this.panelBody.Controls)
                {
                    this.panelBody.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }

        /// <summary>
        /// 添加窗体到目标控件
        /// </summary>
        /// <param name="targetCtrl">目标控件</param>
        /// <param name="target">目标窗体</param>
        private void addFormToPanelBody(Control targetCtrl, Form target, DockStyle dockStyle)
        {
            target.TopLevel = false;
            target.FormBorderStyle = FormBorderStyle.None;
            target.Dock = dockStyle;

            targetCtrl.Controls.Clear();
            targetCtrl.Controls.Add(target);
            target.Show();
        }

        /// <summary>
        /// 显示操作主题名称
        /// </summary>
        /// <param name="type">操作类型</param>
        private void ShowOperateSubjectName(int type)
        {
            lbl_SubjectName.Text = string.IsNullOrEmpty(ScanGlobalInfo.loginUser.data.orgname) ? "未获取到学校名称" : ScanGlobalInfo.loginUser.data.orgname.Trim();
        }

        /// <summary>
        /// 获得主题名称
        /// </summary>
        /// <param name="curOpStatus">当前操作状态</param>
        /// <returns>主题名称</returns>
        private string GetSubjectName(OperateStatus curOpStatus)
        {
            string result = "";

            if (curOpStatus != OperateStatus.MainPage && ScanGlobalInfo.ExamInfo != null)
            {
                result = ScanGlobalInfo.ExamInfo.GradeName + ScanGlobalInfo.ExamInfo.SubjectName + ScanGlobalInfo.ExamInfo.SubjectType;
            }

            return result;
        }

        /// <summary>
        /// 改变状态到扫描准备
        /// </summary>
        private void ChangeStateToScanPrepare(object sender, EventArgs e)
        {
            this.StateManagement("", OperateStatus.ScannerSetting);
        }

        /// <summary>
        /// 状态管理
        /// </summary>
        /// <param name="obj">当前状态</param>
        /// <param name="nextOpStatus">目标状态</param>
        public void StateManagement(object obj, OperateStatus nextOpStatus)
        {
            try
            {
                this.DisposeAllExitForm();

                OperateStatus curOpStatus = this._curOpStatus;
                this._curOpStatus = nextOpStatus;

                switch (nextOpStatus)
                {
                    case OperateStatus.MainPage:
                        {
                            MainBodyForm mainBodyForm = new MainBodyForm(this);

                            mainBodyForm.opStateChange += new MainBodyForm.StateChangeHandle(this.StateManagement);

                            OperateStatus curOperateStatus = OperateStatus.SubjectList;

                            if (typeof(OperateStatus) == obj.GetType())
                            {
                                curOperateStatus = (OperateStatus)obj;
                            }

                            mainBodyForm.CurOperateStatus = curOperateStatus;
                            picExamList.Click += mainBodyForm.StatusChangeTrigger;
                            lblEximList.Click += mainBodyForm.StatusChangeTrigger;
                            picHistoryRecord.Click += mainBodyForm.StatusChangeTrigger;
                            lblHistoryRecord.Click += mainBodyForm.StatusChangeTrigger;
                            picSystemSetting.Click += mainBodyForm.StatusChangeTrigger;
                            lblSystemSetting.Click += mainBodyForm.StatusChangeTrigger;

                            this.addFormToPanelBody(this.panelBody, mainBodyForm, DockStyle.Fill);
                            this.picExitSystem.SuspendLayout();

                            this.picExitSystem.Text = "退出登录";

                            this.picExitSystem.ForeColor = Color.Red;
                            this.picExitSystem.Image = null;

                            this.picExitSystem.ResumeLayout();
                            this.ShowOperateSubjectName(0);

                            break;
                        }
                    case OperateStatus.SubjectOperate:
                        {
                            if (curOpStatus == OperateStatus.MainPage)
                            {
                                ScanGlobalInfo.ExamInfo = (ExamInfo)obj;
                                ScanGlobalInfo.ExamInfo.IsScanFinish = false;
                            }

                            SubjectOperateForm subjectOperateForm = new SubjectOperateForm(this);

                            if (curOpStatus == OperateStatus.CheckTemplate || curOpStatus == OperateStatus.TemplateMake)
                            {
                                subjectOperateForm.isNeedDownLoadTpl = false;
                            }

                            subjectOperateForm.opStateChange += new SubjectOperateForm.StateChangeHandle(this.StateManagement);
                            subjectOperateForm.CurExam = ScanGlobalInfo.ExamInfo;
                            subjectOperateForm.Size = new Size(1020, panelBody.Height);
                            subjectOperateForm.Location = new Point((panelBody.Width - subjectOperateForm.Width) / 2, 0);

                            this.addFormToPanelBody(this.panelBody, subjectOperateForm, DockStyle.Fill);
                            this.ShowOperateSubjectName(1);

                            break;
                        }
                    case OperateStatus.TemplateMake:
                        {
                            TempalteMakerForm tempalteMakerForm = new TempalteMakerForm();

                            tempalteMakerForm.AddStartScanEventHandler(new EventHandler(this.ChangeStateToScanPrepare));

                            tempalteMakerForm.BackLastStep += new TempalteMakerForm.BackSubjectForm(StateManagement);
                            tempalteMakerForm.OpenMode = OpenTemplateMode.New;

                            this.addFormToPanelBody(this.panelBody, tempalteMakerForm, DockStyle.Fill);
                            this.ShowOperateSubjectName(1);

                            break;
                        }
                    case OperateStatus.CheckTemplate:
                        {
                            TempalteMakerForm tmForm = new TempalteMakerForm();

                            tmForm.AddStartScanEventHandler(new EventHandler(this.ChangeStateToScanPrepare));

                            tmForm.BackLastStep += new TempalteMakerForm.BackSubjectForm(StateManagement);
                            tmForm.OpenMode = OpenTemplateMode.Open;

                            this.addFormToPanelBody(this.panelBody, tmForm, DockStyle.Fill);
                            this.ShowOperateSubjectName(1);

                            break;
                        }
                    case OperateStatus.ScanOperate:
                    case OperateStatus.ScannerSetting:
                        {
                            ScanOperateForm soForm = new ScanOperateForm();

                            soForm._opStateChange += new ScanOperateForm.StateChangeHandle(this.StateManagement);
                            soForm._backLastStep += new ScanOperateForm.BackSubjectForm(StateManagement);

                            this.addFormToPanelBody(this.panelBody, soForm, DockStyle.Fill);
                            this.ShowOperateSubjectName(1);

                            break;
                        }
                    case OperateStatus.UploadMaterials:
                    case OperateStatus.ReUploadMaterials:
                        {
                            MaterialsUploadForm target = new MaterialsUploadForm();

                            this.addFormToPanelBody(this.panelBody, target, DockStyle.Fill);


                            this.picExitSystem.Text = "返回科目列表";

                            if (nextOpStatus == OperateStatus.ReUploadMaterials)
                            {
                                this.picExitSystem.Text = "返回历史记录";
                            }

                            this.picExitSystem.ForeColor = Color.Gray;
                            this.picExitSystem.Image = CommonRes.return0;

                            this.ShowOperateSubjectName(1);

                            break;
                        }
                    case OperateStatus.Statistics:
                        {
                            CheckStatiscsForm target2 = new CheckStatiscsForm();

                            this.addFormToPanelBody(this.panelBody, target2, DockStyle.Fill);


                            this.picExitSystem.Text = "返回科目列表";
                            this.picExitSystem.ForeColor = Color.Gray;
                            this.picExitSystem.Image = CommonRes.return0;

                            this.ShowOperateSubjectName(1);

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("状态转换出错：" + ex.ToString());
            }
        }

        /// <summary>
        /// 设置登录窗体
        /// </summary>
        /// <param name="target">目标窗体</param>
        public void SetLoginForm(LoginForm target)
        {
            this.curLogin = target;
        }

        /// <summary>
        /// 最小化按钮点击事件
        /// </summary>
        private void picMinimum_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 最小化按钮鼠标悬浮事件
        /// </summary>
        private void picMinimum_MouseHover(object sender, EventArgs e)
        {
            picMinimum.Image = CommonRes.Minimum_Hover;
        }

        /// <summary>
        /// 最小化按钮鼠标离开事件
        /// </summary>
        private void picMinimum_MouseLeave(object sender, EventArgs e)
        {
            picMinimum.Image = CommonRes.Minimum_Normal;
        }

        /// <summary>
        /// 最大化按钮点击事件
        /// </summary>
        private void picMaximum_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// 最大化按钮鼠标悬浮件
        /// </summary>
        private void picMaximum_MouseHover(object sender, EventArgs e)
        {
            picMaximum.Image = CommonRes.Maximum_Hover;
        }

        /// <summary>
        /// 最大化按钮鼠标离开事件
        /// </summary>
        private void picMaximum_MouseLeave(object sender, EventArgs e)
        {
            picMaximum.Image = CommonRes.Maximum_Normal;
        }

        /// <summary>
        /// 关闭按钮点击事件
        /// </summary>
        private void picClose_Click(object sender, EventArgs e)
        {
            if (ScanGlobalInfo.IsScaning)
            {
                MessageBox.Show("正在扫描，不能退出系统");

                return;
            }

            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// 关闭按钮鼠标悬浮事件
        /// </summary>
        private void picClose_MouseHover(object sender, EventArgs e)
        {
            picClose.Image = CommonRes.Close_Hover;
        }

        /// <summary>
        /// 关闭按钮鼠标离开事件
        /// </summary>
        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = CommonRes.Close_Normal;
        }

        /// <summary>
        /// 窗体大小改变事件
        /// </summary>
        private void MainScanForm_SizeChanged(object sender, EventArgs e)
        {
            panTableCan.Location = new Point((Width - panTableCan.Width) / 2, 41);
        }

        /// <summary>
        /// 考试列表区域鼠标悬浮事件
        /// </summary>
        private void picExamList_MouseHover(object sender, EventArgs e)
        {
            if (picExamList.Image == ((Image)MainScanFormRes.TabImage))
            {
                return;
            }

            picExamList.Image = MainScanFormRes.TabImage;
        }

        /// <summary>
        /// 历史记录区域鼠标悬浮事件
        /// </summary>
        private void picHistoryRecord_MouseHover(object sender, EventArgs e)
        {
            if (picHistoryRecord.Image == ((Image)MainScanFormRes.TabImage))
            {
                return;
            }

            picHistoryRecord.Image = MainScanFormRes.TabImage;
        }

        /// <summary>
        /// 系统设置区域鼠标悬浮事件
        /// </summary>
        private void picSystemSetting_MouseHover(object sender, EventArgs e)
        {
            if (picSystemSetting.Image == ((Image)MainScanFormRes.TabImage))
            {
                return;
            }

            picSystemSetting.Image = MainScanFormRes.TabImage;
        }

        /// <summary>
        /// 考试列表区域鼠标离开事件
        /// </summary>
        private void picExamList_MouseLeave(object sender, EventArgs e)
        {
            if (_tabStatus != OperateStatus.SubjectList)
            {
                picExamList.Image = null;
            }
        }

        /// <summary>
        /// 历史记录区域鼠标离开事件
        /// </summary>
        private void picHistoryRecord_MouseLeave(object sender, EventArgs e)
        {
            if (_tabStatus != OperateStatus.HistoryExamRecord)
            {
                picHistoryRecord.Image = null;
            }
        }

        /// <summary>
        /// 系统设置区域鼠标离开事件
        /// </summary>
        private void picSystemSetting_MouseLeave(object sender, EventArgs e)
        {
            if (_tabStatus != OperateStatus.SystemSetting)
            {
                picSystemSetting.Image = null;
            }
        }

        private void panTopBar_DoubleClick(object sender, EventArgs e)
        {
            picMaximum_Click(sender, e);
        }

        /// <summary>
        /// 角菜单点击事件
        /// </summary>
        private void pbMenu_Click(object sender, EventArgs e)
        {
            cmsMenu.Show(pbMenu, new Point(0, pbMenu.Size.Height));
        }

        /// <summary>
        /// 更新说明按钮点击事件
        /// </summary>
        private void tsmiUpdateExplain_Click(object sender, EventArgs e)
        {
            UpdateExplainForm ueForm = new UpdateExplainForm();

            ueForm.StartPosition = FormStartPosition.CenterParent;

            ueForm.ShowDialog();
        }
    }
}
