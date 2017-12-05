using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.Form;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.Main
{
    /// <summary>
    /// 对象操作窗体
    /// </summary>
    public partial class SubjectOperateForm : Form
    {
        /// <summary>
        /// 业务处理层的实例
        /// </summary>
        BaseDisposeBLL _bdBLL = new BaseDisposeBLL();
        /// <summary>
        /// 状态改变委托定义
        /// </summary>
        /// <param name="obj">操作对象</param>
        /// <param name="nextOpStatus">下一个状态</param>
        public delegate void StateChangeHandle(object obj, OperateStatus nextOpStatus);
        /// <summary>
        /// 试卷信息
        /// </summary>
        private ExamInfo _curExam;
        /// <summary>
        /// 状态改变委托声明
        /// </summary>
        public event SubjectOperateForm.StateChangeHandle opStateChange;
        /// <summary>
        /// 父级窗体
        /// </summary>
        private MainScanForm _parForm;

        /// <summary>
        /// 是否下载模板文件
        /// </summary>
        public bool isNeedDownLoadTpl { get; set; }
        /// <summary>
        /// 当前考试信息
        /// </summary>
        public ExamInfo CurExam
        {
            get
            {
                return this._curExam;
            }
            set
            {
                this._curExam = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public SubjectOperateForm(MainScanForm parForm)
        {
            InitializeComponent();

            this.isNeedDownLoadTpl = true;
            ErrorPageManangerBLL.hasloadLocalZipxml = false;

            ErrorPageManangerBLL.InitializeDictionary();

            lblDayCompletedNum.Text = ScanGlobalInfo.ScannedCountInDays.ToString();

            ScanStatistics scanStatistics = ScanStatisticsBLL.GetScanStatistics();

            lblScanVelocityNum.Text = scanStatistics.ScanSpeed.ToString();
            lblUntreatedAbnormalStatistics.Text = ErrorPageManangerBLL.GetIncorrectPaperCount().ToString();
            _parForm = parForm;
        }

        /// <summary>
        /// 查看模板按钮点击事件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.opStateChange != null)
            {
                this.opStateChange("", OperateStatus.CheckTemplate);

                return;
            }

            MessageBox.Show("事件未绑定！");
        }

        /// <summary>
        /// 继续扫描按钮点击事件
        /// </summary>
        private void btn_ContinueScan_Click(object sender, EventArgs e)
        {
            TemplateInfoResponse tiResponse = LoadTplFLoadTemplateFile.GetOnlineTemplateInfo();

            if (!tiResponse.Success)
            {
                if (tiResponse.Error != null)
                {
                    _bdBLL.System_SaveErrorLog(new Exception(tiResponse.Error.Message), tiResponse.Error.Details);
                }
                else
                {
                    _bdBLL.System_SaveErrorLog(new Exception("获取在线模板出现异常"), "获取在线模板出现异常，详细信息：无");
                }

                MessageBox.Show(string.Format("未能获取到在线模板{0}这将导致扫描结果不能正常上传{1}请上传模板后再进行扫描操作。", Environment.NewLine, Environment.NewLine), "提示", MessageBoxButtons.OK);

                return;
            }
            else if (tiResponse.Data == null || string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetPicPath)
                || string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetXML) || string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetXMLPath))
            {
                MessageBox.Show(string.Format("未能获取到在线模板{0}这将导致扫描结果不能正常上传{1}请上传模板后再进行扫描操作。", Environment.NewLine, Environment.NewLine), "提示", MessageBoxButtons.OK);

                return;
            }

            if (this.opStateChange != null)
            {
                this.opStateChange("", OperateStatus.ScanOperate);

                return;
            }

            MessageBox.Show("Subject Operate 继续扫描事件未绑定！");
        }

        /// <summary>
        /// 新模板按钮点击事件
        /// </summary>
        private void btn_NewTemplate_Click(object sender, EventArgs e)
        {
            if (this.opStateChange != null)
            {
                this.opStateChange("", OperateStatus.TemplateMake);

                return;
            }

            MessageBox.Show("Subject Operate 新建模板事件未绑定！");

        }

        /// <summary>
        /// 上传资料按钮点击事件
        /// </summary>
        private void btn_ScanEmptyPaper_Click(object sender, EventArgs e)
        {
            if (this.opStateChange == null)
            {
                MessageBox.Show("Subject Operate 扫描上传原卷事件未绑定！");

                return;
            }
            if (ScanGlobalInfo.ExamInfo.CsID > 0)
            {
                this.opStateChange("", OperateStatus.UploadMaterials);

                return;
            }

            MessageBox.Show("请先制作模板，并保存上传后，再上传原卷或其它资料！");
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void SubjectOperateForm_Load(object sender, EventArgs e)
        {
            if (!ScanGlobalInfo.loginUser.data.roles.Contains(PermissionConstant.ORG_OWNER))
            {
                btn_NewTemplate.Enabled = false;
                btn_checkTemplate.Enabled = false;
                btn_UploadMaterial.Enabled = false;
            }

            btn_ContinueScan.Enabled = false;
            lblContinueScanBtnText.ForeColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_checkTemplate.Visible = false;
            lblExamInfo.Text = string.Concat(ScanGlobalInfo.ExamGroup.ExamName, ScanGlobalInfo.ExamInfo.GradeName, ScanGlobalInfo.ExamInfo.SubjectName);
        }

        /// <summary>
        /// 窗体调整大小事件
        /// </summary>
        private void SubjectOperateForm_Resize(object sender, EventArgs e)
        {
            lblBackExamList.Location = new Point((Width - panContent.Width) / 2, lblBackExamList.Location.Y);
            panContent.Location = new Point((Width - panContent.Width) / 2, panContent.Location.Y);

            //  this.asc.controlAutoSize(this); //控件自适应大小
        }

        /// <summary>
        /// 窗体显示事件
        /// </summary>
        private void SubjectOperateForm_Shown(object sender, EventArgs e)
        {
            this.UpdateStuentExamInfoByExaminfo(this._curExam);
        }

        /// <summary>
        /// 根据考试信息更新学生考试信息
        /// </summary>
        /// <param name="exam">考试信息</param>
        private void UpdateStuentExamInfoByExaminfo(ExamInfo exam)
        {
            if (exam != null)
            {
                btn_NewTemplate.Enabled = false;

                ScanGlobalInfo.ExamInfo = exam;
                ScanGlobalInfo.ExamType = ScanGlobalInfo.ExamInfo.ExamType;
                ScanGlobalInfo.FileBatchHead = new Random().Next(0, 99).ToString("D2") + new Random().Next(0, 99999999).ToString("D8");
                FormProgress frmProgress = new FormProgress();
                Thread trd = new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(0, "正在获取学生列表...");
                        }));

                        try
                        {
                            if (ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count == 0)
                            {
                                StudentExamInfoResponse seiResponse = new BaseDisposeBLL().StudentExamInfo_GetList();
                                IList<StudentExamInfo> seiList = (seiResponse.Success) ? seiResponse.Data : null;

                                ScanGlobalInfo.ExamInfo.StudentExamInfoList.Clear();
                                ScanGlobalInfo.ExamInfo.StudentExamInfoList.AddRange(seiList);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteFatalLog(ex.Message.ToString(), ex);
                        }

                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(30, "正在检查是否已有上传的模板文件...");
                        }));

                        string templatecheckresult = "";

                        try
                        {
                            TemplateInfoResponse tiResponse = LoadTplFLoadTemplateFile.GetOnlineTemplateInfo();
                            bool flag = (tiResponse.Success && tiResponse.Data != null && !string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetXMLPath) && !string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetXML) && !string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetPicPath));

                            if (flag && this.isNeedDownLoadTpl)
                            {
                                Invoke(new MethodInvoker(delegate
                                {
                                    frmProgress.SetProgress(60, "正在获取模板信息...");
                                }));

                                ZKTemplateInfo zktiModel = tiResponse.Data;

                                Invoke(new MethodInvoker(delegate
                                {
                                    frmProgress.SetProgress(90, "正在下载已上传的模板文件...");
                                }));

                                if (LoadTplFLoadTemplateFile.LoadTemplateFromALiWithProgress(zktiModel))
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        if (ScanGlobalInfo.loginUser.data.roles.Contains(PermissionConstant.ORG_OWNER))
                                        {
                                            btn_ContinueScan.Enabled = true;
                                            lblContinueScanBtnText.Enabled = true;
                                            lblContinueScanBtnText.ForeColor = Color.Black;
                                        }
                                        else
                                        {
                                            btn_ContinueScan.Enabled = false;
                                            lblContinueScanBtnText.Enabled = false;
                                            lblContinueScanBtnText.ForeColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                                        }

                                        this.btn_checkTemplate.Visible = true;
                                    }));
                                }
                                else
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        frmProgress.SetProgress(100, "模板下载失败");
                                        frmProgress.Close();

                                        this.btn_ContinueScan.Enabled = false;
                                        lblContinueScanBtnText.Enabled = false;
                                        lblContinueScanBtnText.ForeColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                                        this.btn_checkTemplate.Visible = false;
                                    }));
                                }
                            }
                            else
                            {
                                Invoke(new MethodInvoker(delegate
                                    {
                                        frmProgress.SetProgress(50, "正在检测本地模板文件...");
                                    }));

                                if (LoadTplFLoadTemplateFile.CheckLocalTemplate(ref templatecheckresult))
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        if (ScanGlobalInfo.loginUser.data.roles.Contains(PermissionConstant.ORG_OWNER))
                                        {
                                            btn_ContinueScan.Enabled = true;
                                            lblContinueScanBtnText.Enabled = true;
                                            lblContinueScanBtnText.ForeColor = Color.Black;
                                        }
                                        else
                                        {
                                            btn_ContinueScan.Enabled = false;
                                            lblContinueScanBtnText.Enabled = false;
                                            lblContinueScanBtnText.ForeColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                                        }

                                        this.btn_checkTemplate.Visible = true;
                                    }));
                                }
                                else
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        this.btn_ContinueScan.Enabled = false;
                                        lblContinueScanBtnText.Enabled = false;
                                        lblContinueScanBtnText.ForeColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                                        this.btn_checkTemplate.Visible = false;

                                        LogHelper.WriteFatalLog(templatecheckresult);
                                    }));
                                }
                            }

                            this.Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.SetProgress(100, "检查完成");
                                frmProgress.Close();
                                this.Cursor = Cursors.Arrow;
                            }));
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteFatalLog(ex.Message.ToString(), ex);

                            this.Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.Close();
                                MessageBox.Show(ex.Message, "模板下载失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                                this.Cursor = Cursors.Arrow;
                            }));
                        }

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (ThreadAbortException)
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(80, "正在检测本地模板文件...");
                        }));

                        string templatecheckresult = "";

                        if (LoadTplFLoadTemplateFile.CheckLocalTemplate(ref templatecheckresult))
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                if (ScanGlobalInfo.loginUser.data.roles.Contains(PermissionConstant.ORG_OWNER))
                                {
                                    btn_ContinueScan.Enabled = true;
                                    lblContinueScanBtnText.Enabled = true;
                                    lblContinueScanBtnText.ForeColor = Color.Black;
                                }
                                else
                                {
                                    btn_ContinueScan.Enabled = false;
                                    lblContinueScanBtnText.Enabled = false;
                                    lblContinueScanBtnText.ForeColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                                }

                                this.btn_checkTemplate.Visible = true;
                            }));
                        }
                        else
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                this.btn_ContinueScan.Enabled = false;
                                lblContinueScanBtnText.Enabled = false;
                                lblContinueScanBtnText.ForeColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                                this.btn_checkTemplate.Visible = false;

                                LogHelper.WriteFatalLog(templatecheckresult);
                            }));
                        }

                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(100, "检查完成");
                            frmProgress.Close();

                            this.Cursor = Cursors.Arrow;
                        }));

                        this.DialogResult = DialogResult.Cancel;
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.Close();
                                MessageBox.Show(ex.Message, "更新失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                                this.Cursor = Cursors.Arrow;
                            }));

                        this.DialogResult = DialogResult.Cancel;
                    }

                    Invoke(new MethodInvoker(delegate
                    {
                        btn_NewTemplate.Enabled = true;
                    }));
                }));

                trd.Start();
                frmProgress.Show();
            }
        }

        /// <summary>
        /// 返回考试列表按钮鼠标移入事件
        /// </summary>
        private void lblBackExamList_MouseEnter(object sender, EventArgs e)
        {
            lblBackExamList.ForeColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
        }

        /// <summary>
        /// 返回考试列表按钮鼠标离开事件
        /// </summary>
        private void lblBackExamList_MouseLeave(object sender, EventArgs e)
        {
            lblBackExamList.ForeColor = DefaultForeColor;
        }

        /// <summary>
        /// 返回考试列表按钮点击事件
        /// </summary>
        private void lblBackExamList_Click(object sender, EventArgs e)
        {
            _parForm.StateManagement(OperateStatus.SubjectList, OperateStatus.MainPage);
        }

        /// <summary>
        /// 扫描操作区域鼠标移入事件
        /// </summary>
        private void btn_ActionAcer_MouseEnter(object sender, EventArgs e)
        {
            Control ctl = (sender as Control);
            Button btn;

            if (ctl.GetType() == typeof(Label))
            {
                ctl.ForeColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
                btn = (ctl.Parent as Button);
            }
            else
            {
                btn = (sender as Button);
                Control.ControlCollection cc = btn.Controls;

                if (cc.Count > 0)
                {
                    foreach (Control c in cc)
                    {
                        c.ForeColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
                    }
                }
            }

            btn.ForeColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            btn.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
        }

        /// <summary>
        /// 扫描操作区域鼠标离开事件
        /// </summary>
        private void btn_ActionAcer_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (sender as Button);

            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));

            Control.ControlCollection cc = btn.Controls;

            if (cc.Count > 0)
            {
                foreach (Control c in cc)
                {
                    c.ForeColor = Color.Black;
                }
            }
        }

        /// <summary>
        /// 操作面板的绘制事件
        /// </summary>
        private void panActive_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = (sender as Panel).CreateGraphics();
            Pen p = new Pen(Color.FromArgb(((int)((byte)204)), ((int)((byte)204)), ((int)((byte)204))), 1);

            p.DashStyle = DashStyle.Dot;

            gp.DrawLine(p, new Point(0, panActive.Height - 1), new Point(1020, panActive.Height - 1));
            gp.Dispose();
        }

        /// <summary>
        /// 查看日志按钮点击事件
        /// </summary>
        private void btnViewLog_Click(object sender, EventArgs e)
        {
            if (this.opStateChange != null)
            {
                this.opStateChange("", OperateStatus.Statistics);

                return;
            }

            MessageBox.Show("Subject Operate 查看统计详情事件未绑定！");
        }

        /// <summary>
        /// 扫描速度数量控件大小改变事件
        /// </summary>
        private void lblScanVelocityNum_SizeChanged(object sender, EventArgs e)
        {
            lblScanVelocityUnit.Location = new Point(lblScanVelocityNum.Location.X + lblScanVelocityNum.Width, lblScanVelocityUnit.Location.Y);
        }

        /// <summary>
        /// 本日已完成数量控件大小改变事件
        /// </summary>
        private void lblDayCompletedNum_SizeChanged(object sender, EventArgs e)
        {
            lblDayCompletedUnit.Location = new Point(lblDayCompletedNum.Location.X + lblDayCompletedNum.Width, lblDayCompletedUnit.Location.Y);
        }
    }
}