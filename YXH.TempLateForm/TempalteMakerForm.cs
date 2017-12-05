using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YXH.Common;
using YXH.Enum;
using YXH.ScanBLL;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 模板设置
    /// </summary>
    public partial class TempalteMakerForm : Form
    {
        /// <summary>
        /// 扫描仪设置窗体
        /// </summary>
        protected ScannerSettingForm scannerSettingFrom;
        /// <summary>
        /// 考试图片窗体
        /// </summary>
        protected ExamImageForm examImageForm;
        /// <summary>
        /// 前置工具条
        /// </summary>
        private OutlookBar outlookBar;
        /// <summary>
        /// 事件头
        /// </summary>
        protected EventHandler startScanEventHandler;
        /// <summary>
        /// 打开模板模式
        /// </summary>
        public OpenTemplateMode OpenMode;
        /// <summary>
        /// 返回科目设置窗体
        /// </summary>
        public delegate void BackSubjectForm(object obj, OperateStatus status);
        /// <summary>
        /// 返回上一窗体事件定义
        /// </summary>
        public event BackSubjectForm BackLastStep;

        /// <summary>
        /// 构造方法
        /// </summary>
        public TempalteMakerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置按钮点击事件
        /// </summary>
        private void btn_Setting_Click(object sender, EventArgs e)
        {
            if (this.examImageForm != null)
            {
                this.examImageForm.OpenTemplateSetting();
            }
        }

        /// <summary>
        /// 放大按钮点击事件
        /// </summary>
        private void zoomIn_Click(object sender, EventArgs e)
        {
            this.examImageForm.ZoomIn();
        }

        /// <summary>
        /// 缩小按钮点击事件
        /// </summary>
        private void zoomOut_Click(object sender, EventArgs e)
        {
            this.examImageForm.ZoomOut();
        }

        /// <summary>
        /// 左旋点击事件
        /// </summary>
        private void btnUnClockRotate_Click(object sender, EventArgs e)
        {
            this.btnUnClockRotate.Enabled = false;

            this.examImageForm.UnClockRotate();

            this.btnUnClockRotate.Enabled = true;
        }

        /// <summary>
        /// 右旋按钮点击事件
        /// </summary>
        private void btnClockRotate_Click(object sender, EventArgs e)
        {
            this.btnClockRotate.Enabled = false;

            this.examImageForm.ClockRotate();

            this.btnClockRotate.Enabled = true;
        }

        /// <summary>
        /// 设置页面导航状态
        /// </summary>
        private void SetPageNaviState()
        {
            this.previousPage.Enabled = (this.examImageForm.currentPageIndex != 0);
            this.nextPage.Enabled = (this.examImageForm.currentPageIndex != this.examImageForm.imageFilesList.Count - 1);
        }

        /// <summary>
        /// 更新页面索引显示值
        /// </summary>
        private void UpdatePageIndexShownValue()
        {
            this.lbl_PageIndexShown.Text = string.Format("{0}/{1}", this.examImageForm.currentPageIndex + 1, this.examImageForm.imageFilesList.Count);
        }

        /// <summary>
        /// 上一页按钮点击事件
        /// </summary>
        private void previousPage_Click(object sender, EventArgs e)
        {
            this.examImageForm.PreviousPage();
            this.SetPageNaviState();
            this.UpdatePageIndexShownValue();
        }

        /// <summary>
        /// 下一页按钮点击事件
        /// </summary>
        private void nextPage_Click(object sender, EventArgs e)
        {
            this.examImageForm.NextPage();
            this.SetPageNaviState();
            this.UpdatePageIndexShownValue();
        }

        /// <summary>
        /// 模板保存目录按钮点击事件
        /// </summary>
        private void btn_OpenTpFolder_Click(object sender, EventArgs e)
        {
            Process.Start(PathHelper.TpFileDir);
        }

        /// <summary>
        /// 扫描完成事件
        /// </summary>
        protected void OnScanFinished(object sender, ScannerSettingForm.ScanFinishedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.examImageForm.SetImageFiles(e.imageFiles, e.pageSize, e.omrType, e.isDoubleSide);
            this.SetPageNaviState();

            this.examImageForm.CurrentOP = OperationType.DESKEWED_DETECTION;

            this.examImageForm.FitScreen();
            this.outlookBar.HighlightSelection(0, 1);
            this.scannerSettingFrom.Hide();
            this.examImageForm.Show();

            this.Cursor = Cursors.Arrow;
            this.btn_Setting.Visible = true;
            this.btn_OpenTpFolder.Visible = true;

            this.UpdatePageIndexShownValue();
        }

        /// <summary>
        /// 显示放大缩小等工具区域
        /// </summary>
        /// <param name="status">显示状态</param>
        private void ShowToolbar(bool status = true)
        {
            panAction.Visible = status;
            panExamInfo.Visible = !status;
        }

        /// <summary>
        /// 操作变更事件
        /// </summary>
        protected void OnOperationChanged(object sender, ExamImageForm.OpChangedEventArgs e)
        {
            switch (e.op)
            {
                case OperationType.SCAN_SETTING:
                    this.ShowToolbar(false);
                    this.outlookBar.SetSelectedBand(0);
                    this.outlookBar.HighlightSelection(0, 0);
                    this.examImageForm.Hide();
                    this.scannerSettingFrom.Show();

                    return;
                case OperationType.DESKEWED_DETECTION:
                    this.ShowToolbar(true);

                    this.btnUnClockRotate.Enabled = true;
                    this.btnClockRotate.Enabled = true;

                    this.outlookBar.SetSelectedBand(0);
                    this.outlookBar.HighlightSelection(0, 1);

                    return;
                case OperationType.TITLE:
                    this.btnUnClockRotate.Enabled = false;
                    this.btnClockRotate.Enabled = false;

                    this.outlookBar.SetSelectedBand(1);
                    this.outlookBar.HighlightSelection(1, 0);

                    return;
                case OperationType.SCHOOLNUMBER_OMR:
                    this.btnUnClockRotate.Enabled = false;
                    this.btnClockRotate.Enabled = false;

                    this.outlookBar.SetSelectedBand(1);
                    this.outlookBar.HighlightSelection(1, 1);

                    return;
                case OperationType.HIDEACER:
                    btnUnClockRotate.Enabled = false;
                    btnClockRotate.Enabled = false;

                    outlookBar.SetSelectedBand(1);
                    this.outlookBar.HighlightSelection(1, 2);

                    return;
                case OperationType.OBJECTIVE_OMR:
                    this.btnUnClockRotate.Enabled = false;
                    this.btnClockRotate.Enabled = false;

                    this.outlookBar.SetSelectedBand(1);
                    this.outlookBar.HighlightSelection(1, 3);

                    return;
                case OperationType.SUBJECTIVE_OMR:
                    this.btnUnClockRotate.Enabled = false;
                    this.btnClockRotate.Enabled = false;

                    this.outlookBar.SetSelectedBand(1);
                    this.outlookBar.HighlightSelection(1, 4);

                    return;
                case OperationType.FINISHED:
                    this.ShowToolbar(true);

                    this.btnUnClockRotate.Enabled = false;
                    this.btnClockRotate.Enabled = false;

                    this.outlookBar.SetSelectedBand(2);
                    this.outlookBar.HighlightSelection(2, 0);

                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// 绑定加载答题卡事件
        /// </summary>
        protected void OnBandLoadAnswerSheet(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 绑定准备模板事件
        /// </summary>
        protected void OnBandMakeTempalte(object sender, EventArgs e)
        {
            OperationType arg_0B_0 = this.examImageForm.CurrentOP;
        }

        /// <summary>
        /// 绑定模板完成事件
        /// </summary>
        protected void OnBandTemplateComplete(object sender, EventArgs e)
        {
            if (this.examImageForm.CurrentOP == OperationType.SCAN_SETTING)
            {
                return;
            }
            if (this.examImageForm._editType != EditType.NONE)
            {
                return;
            }

            this.outlookBar.SetSelectedBand(2);
            this.outlookBar.HighlightSelection(2, 0);

            this.examImageForm.CurrentOP = OperationType.FINISHED;
        }

        /// <summary>
        /// 标签扫描设置事件
        /// </summary>
        protected void OnLabelScanSetting(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 标签水平调整事件
        /// </summary>
        public void OnLabelHorizonAdjust(object sender, EventArgs e)
        {
            Label label = (sender as Label);
            LabelTagInfo labelTagInfo = label.Tag as LabelTagInfo;

            if (this.examImageForm.CurrentOP == OperationType.SCAN_SETTING)
            {
                return;
            }
            if (this.examImageForm._editType != EditType.NONE)
            {
                return;
            }

            label.Cursor = Cursors.Hand;

            examImageForm.ClearCustomForm();
            this.outlookBar.HighlightSelection(labelTagInfo.bandIndex, labelTagInfo.contentIndex);

            this.examImageForm.CurrentOP = OperationType.DESKEWED_DETECTION;
        }

        /// <summary>
        /// 标签标题选中事件
        /// </summary>
        protected void OnLabelTitleSelection(object sender, EventArgs e)
        {
            Label label = sender as Label;
            LabelTagInfo labelTagInfo = label.Tag as LabelTagInfo;

            if (this.examImageForm.CurrentOP == OperationType.SCAN_SETTING)
            {
                return;
            }
            if (this.examImageForm._editType != EditType.NONE)
            {
                return;
            }

            label.Cursor = Cursors.Hand;
            examImageForm.ClearCustomForm();
            this.outlookBar.HighlightSelection(labelTagInfo.bandIndex, labelTagInfo.contentIndex);

            this.examImageForm.CurrentOP = OperationType.TITLE;
        }

        /// <summary>
        /// 标签学号识别选中事件
        /// </summary>
        protected void OnLabelStudentOmrSelection(object sender, EventArgs e)
        {
            Label label = sender as Label;
            LabelTagInfo labelTagInfo = label.Tag as LabelTagInfo;

            if (this.examImageForm.CurrentOP == OperationType.SCAN_SETTING)
            {
                return;
            }
            if (this.examImageForm._editType != EditType.NONE)
            {
                return;
            }
            if (examImageForm.CurrentOP != OperationType.SCHOOLNUMBER_OMR)
            {
                examImageForm.ClearCustomForm();
            }

            label.Cursor = Cursors.Hand;

            this.outlookBar.HighlightSelection(labelTagInfo.bandIndex, labelTagInfo.contentIndex);

            this.examImageForm.CurrentOP = OperationType.SCHOOLNUMBER_OMR;
        }

        protected void OnLabelHideAreaSelection(object sender, EventArgs e)
        {
            Label lbl = (sender as Label);
            LabelTagInfo labelTagInfo = lbl.Tag as LabelTagInfo;

            if (this.examImageForm.CurrentOP == OperationType.SCAN_SETTING)
            {
                return;
            }
            if (this.examImageForm._editType != EditType.NONE)
            {
                return;
            }

            lbl.Cursor = Cursors.Hand;

            examImageForm.ClearCustomForm();
            this.outlookBar.HighlightSelection(labelTagInfo.bandIndex, labelTagInfo.contentIndex);

            this.examImageForm.CurrentOP = OperationType.HIDEACER;
        }

        /// <summary>
        /// 主观题识别标签选中事件
        /// </summary>
        protected void OnLabelSubjectiveOmrSelection(object sender, EventArgs e)
        {
            Label lbl = (sender as Label);
            LabelTagInfo labelTagInfo = lbl.Tag as LabelTagInfo;

            if (this.examImageForm.CurrentOP == OperationType.SCAN_SETTING)
            {
                return;
            }
            if (this.examImageForm._editType != EditType.NONE)
            {
                return;
            }

            lbl.Cursor = Cursors.Hand;

            examImageForm.ClearCustomForm();
            this.outlookBar.HighlightSelection(labelTagInfo.bandIndex, labelTagInfo.contentIndex);

            this.examImageForm.CurrentOP = OperationType.SUBJECTIVE_OMR;
        }

        /// <summary>
        /// 客观题识别标签选中事件
        /// </summary>
        protected void OnLabelObjectiveOmrSelection(object sender, EventArgs e)
        {
            Label label = sender as Label;
            LabelTagInfo labelTagInfo = label.Tag as LabelTagInfo;

            if (this.examImageForm.CurrentOP == OperationType.SCAN_SETTING)
            {
                return;
            }
            if (this.examImageForm._editType != EditType.NONE)
            {
                return;
            }
            if (examImageForm.CurrentOP != OperationType.OBJECTIVE_OMR)
            {
                examImageForm.ClearCustomForm();
            }

            label.Cursor = Cursors.Hand;

            this.outlookBar.HighlightSelection(labelTagInfo.bandIndex, labelTagInfo.contentIndex);

            this.examImageForm.CurrentOP = OperationType.OBJECTIVE_OMR;
        }

        /// <summary>
        /// 窗体回收事件
        /// </summary>
        private void TemplateMakerForm_Disposed(object sender, EventArgs e)
        {
            if (this.scannerSettingFrom != null)
            {
                this.scannerSettingFrom.Dispose();

                this.scannerSettingFrom = null;
            }
        }

        /// <summary>
        /// 获取存在的模板文件
        /// </summary>
        /// <returns>模板文件路径</returns>
        public static string GetExistedTemplateFile()
        {
            string[] files = Directory.GetFiles(PathHelper.TpFileDir, "*.xml");

            if (files.Length == 1)
            {
                return files[0];
            }
            if (files.Length > 1)
            {
                throw new Exception("模板目录存在该该考试的多个模板文件。");
            }

            throw new Exception("本地没有该考试的模板文件。");
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void TempalteMakerForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.scannerSettingFrom = new ScannerSettingForm
                {
                    onScanFinished = new ScannerSettingForm.ScanFinished(this.OnScanFinished),
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                this.examImageForm = new ExamImageForm
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    onOpChanged = new ExamImageForm.OnOpChanged(this.OnOperationChanged)
                };

                if (this.startScanEventHandler != null)
                {
                    this.examImageForm.AddStartScanEventHandler(this.startScanEventHandler);
                }

                lblExamInfo.Text = string.Format("{0}--{1}{2}", ScanGlobalInfo.ExamGroup.ExamName, ScanGlobalInfo.ExamInfo.GradeName, ScanGlobalInfo.ExamInfo.SubjectName);

                this.splitRight.Panel2.Controls.Add(this.scannerSettingFrom);
                this.splitRight.Panel2.Controls.Add(this.examImageForm);

                this.outlookBar = new OutlookBar();
                this.outlookBar.Location = new Point(0, 0);
                this.outlookBar.Dock = DockStyle.Fill;

                this.splitLeft.Panel2.Controls.Add(this.outlookBar);

                this.splitLeft.Panel1.BackColor = Scheme.UnifiedBackColor;
                this.flpImageAction.BackColor = Scheme.UnifiedBackColor;
                this.splitRight.Panel1.BackColor = Scheme.UnifiedBackColor;

                this.outlookBar.Initialize();

                LabelPanel lblPanUploadAnswerSheet = new LabelPanel();
                LabelPanel lblPanTemplateDesign = new LabelPanel();

                this.outlookBar.AddBand("  上传答题卡", lblPanUploadAnswerSheet, new EventHandler(this.OnBandLoadAnswerSheet));
                this.outlookBar.AddBand("  制作模板", lblPanTemplateDesign, new EventHandler(this.OnBandMakeTempalte));
                this.outlookBar.AddBand("  完成模板", null, new EventHandler(this.OnBandTemplateComplete));
                lblPanUploadAnswerSheet.AddLabel("选取图片", new EventHandler(this.OnLabelScanSetting), new LabelTagInfo(this.outlookBar, 0, 0));
                lblPanUploadAnswerSheet.AddLabel("水平校正", new EventHandler(this.OnLabelHorizonAdjust), new LabelTagInfo(this.outlookBar, 0, 1));
                lblPanTemplateDesign.AddLabel("文字定位", new EventHandler(this.OnLabelTitleSelection), new LabelTagInfo(this.outlookBar, 1, 0));
                lblPanTemplateDesign.AddLabel("选择考号区域", new EventHandler(this.OnLabelStudentOmrSelection), new LabelTagInfo(this.outlookBar, 1, 1));
                lblPanTemplateDesign.AddLabel("选择隐藏区域", new EventHandler(this.OnLabelHideAreaSelection), new LabelTagInfo(this.outlookBar, 1, 2));
                lblPanTemplateDesign.AddLabel("选择客观题区域", new EventHandler(this.OnLabelObjectiveOmrSelection), new LabelTagInfo(this.outlookBar, 1, 3));
                lblPanTemplateDesign.AddLabel("选择主观题区域", new EventHandler(this.OnLabelSubjectiveOmrSelection), new LabelTagInfo(this.outlookBar, 1, 4));
                this.outlookBar.SetSelectedBand(0);
                this.outlookBar.HighlightSelection(0, 0);

                base.Disposed += new EventHandler(this.TemplateMakerForm_Disposed);

                if (this.OpenMode == OpenTemplateMode.New)
                {
                    this.ShowToolbar(false);
                    this.scannerSettingFrom.Show();

                    return;
                }

                this.ShowToolbar(true);

                string existedTemplateFile = GetExistedTemplateFile();

                this.examImageForm.OpenTemplateFile(existedTemplateFile);
                this.examImageForm.Show();

                panExamInfo.Visible = false;
                panAction.Visible = true;
                this.btn_Setting.Visible = true;
                this.btn_OpenTpFolder.Visible = true;

                this.UpdatePageIndexShownValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");

                return;
            }
        }

        /// <summary>
        /// 添加开始扫描事件头
        /// </summary>
        /// <param name="hdr">事件头</param>
        public void AddStartScanEventHandler(EventHandler hdr)
        {
            this.startScanEventHandler = hdr;
        }

        /// <summary>
        /// 返回按钮点击事件
        /// </summary>
        private void lblBackExamList_Click(object sender, EventArgs e)
        {
            BackLastStep("", OperateStatus.SubjectOperate);
        }
    }
}
