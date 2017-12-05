using System.Drawing;
using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class ScanOperateForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanOperateForm));
            this.panelTool = new System.Windows.Forms.Panel();
            this.panScanStatusInfo = new System.Windows.Forms.Panel();
            this.lbl_Num = new System.Windows.Forms.Label();
            this.lbl_CurWork = new System.Windows.Forms.Label();
            this.panPageActin = new System.Windows.Forms.Panel();
            this.flpActionGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_LeakCheck = new System.Windows.Forms.Button();
            this.btn_BackToScanning = new System.Windows.Forms.Button();
            this.tlpCurrentStatus = new System.Windows.Forms.TableLayoutPanel();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.flpPageAction = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ZoomOut = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_ZoomIn = new System.Windows.Forms.Button();
            this.btn_LastPage = new System.Windows.Forms.Button();
            this.lbl_PageIndex = new System.Windows.Forms.Label();
            this.btn_NextPage = new System.Windows.Forms.Button();
            this.btn_ScanTest = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.panelLeft_BatchList = new System.Windows.Forms.Panel();
            this.lbBatch = new System.Windows.Forms.ListBox();
            this.contextMS_batch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_RecoAgain = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_BatchListTitle = new System.Windows.Forms.Label();
            this.progress_Scan = new System.Windows.Forms.ProgressBar();
            this.panel_LeftTop = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.lblScanPaperList = new System.Windows.Forms.Label();
            this.panelRight_Body = new System.Windows.Forms.Panel();
            this.panel_leftfooter = new System.Windows.Forms.Panel();
            this.list_Abnormal = new System.Windows.Forms.ListBox();
            this.contextMS_ErrorPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_DeleteErrorPages = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_RecoAgainErrorPages = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_AbnormalTitle = new System.Windows.Forms.Label();
            this.panel_leftBody = new System.Windows.Forms.Panel();
            this.list_NormalPaper = new System.Windows.Forms.ListBox();
            this.contextMS_NormalPaper = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_SetAsOmrError = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_setAsZkzhError = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_NormalTitle = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.bg_workerForScanner = new System.ComponentModel.BackgroundWorker();
            this.panTop = new System.Windows.Forms.Panel();
            this.flpTopStatusAction = new System.Windows.Forms.FlowLayoutPanel();
            this.btnScanerSetting = new System.Windows.Forms.Button();
            this.btnScanFinish = new System.Windows.Forms.Button();
            this.btnContinueScan = new System.Windows.Forms.Button();
            this.lblExamName = new System.Windows.Forms.Label();
            this.lblBackExamList = new System.Windows.Forms.Label();
            this.panMain = new System.Windows.Forms.Panel();
            this.panelTool.SuspendLayout();
            this.panScanStatusInfo.SuspendLayout();
            this.panPageActin.SuspendLayout();
            this.flpActionGroup.SuspendLayout();
            this.tlpCurrentStatus.SuspendLayout();
            this.flpPageAction.SuspendLayout();
            this.panelLeft_BatchList.SuspendLayout();
            this.contextMS_batch.SuspendLayout();
            this.panel_LeftTop.SuspendLayout();
            this.panel_leftfooter.SuspendLayout();
            this.contextMS_ErrorPage.SuspendLayout();
            this.panel_leftBody.SuspendLayout();
            this.contextMS_NormalPaper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.panTop.SuspendLayout();
            this.flpTopStatusAction.SuspendLayout();
            this.panMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTool
            // 
            this.panelTool.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTool.Controls.Add(this.panScanStatusInfo);
            this.panelTool.Controls.Add(this.panPageActin);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTool.Location = new System.Drawing.Point(0, 0);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(911, 70);
            this.panelTool.TabIndex = 17;
            // 
            // panScanStatusInfo
            // 
            this.panScanStatusInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panScanStatusInfo.Controls.Add(this.lbl_Num);
            this.panScanStatusInfo.Controls.Add(this.lbl_CurWork);
            this.panScanStatusInfo.Location = new System.Drawing.Point(0, 35);
            this.panScanStatusInfo.Name = "panScanStatusInfo";
            this.panScanStatusInfo.Size = new System.Drawing.Size(912, 35);
            this.panScanStatusInfo.TabIndex = 11;
            // 
            // lbl_Num
            // 
            this.lbl_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Num.Location = new System.Drawing.Point(817, 6);
            this.lbl_Num.Name = "lbl_Num";
            this.lbl_Num.Size = new System.Drawing.Size(91, 22);
            this.lbl_Num.TabIndex = 5;
            this.lbl_Num.Text = "0/0";
            this.lbl_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CurWork
            // 
            this.lbl_CurWork.AutoSize = true;
            this.lbl_CurWork.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_CurWork.ForeColor = System.Drawing.Color.Red;
            this.lbl_CurWork.Location = new System.Drawing.Point(0, 9);
            this.lbl_CurWork.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_CurWork.Name = "lbl_CurWork";
            this.lbl_CurWork.Size = new System.Drawing.Size(112, 16);
            this.lbl_CurWork.TabIndex = 2;
            this.lbl_CurWork.Text = "正在扫描中...";
            this.lbl_CurWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panPageActin
            // 
            this.panPageActin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panPageActin.Controls.Add(this.flpActionGroup);
            this.panPageActin.Controls.Add(this.tlpCurrentStatus);
            this.panPageActin.Controls.Add(this.flpPageAction);
            this.panPageActin.Location = new System.Drawing.Point(0, 0);
            this.panPageActin.Name = "panPageActin";
            this.panPageActin.Size = new System.Drawing.Size(913, 35);
            this.panPageActin.TabIndex = 10;
            // 
            // flpActionGroup
            // 
            this.flpActionGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpActionGroup.Controls.Add(this.btn_LeakCheck);
            this.flpActionGroup.Controls.Add(this.btn_BackToScanning);
            this.flpActionGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpActionGroup.Location = new System.Drawing.Point(741, 0);
            this.flpActionGroup.Name = "flpActionGroup";
            this.flpActionGroup.Size = new System.Drawing.Size(167, 34);
            this.flpActionGroup.TabIndex = 12;
            // 
            // btn_LeakCheck
            // 
            this.btn_LeakCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btn_LeakCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_LeakCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LeakCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(66)))), ((int)(((byte)(63)))));
            this.btn_LeakCheck.Location = new System.Drawing.Point(92, 6);
            this.btn_LeakCheck.Margin = new System.Windows.Forms.Padding(5, 6, 0, 6);
            this.btn_LeakCheck.Name = "btn_LeakCheck";
            this.btn_LeakCheck.Size = new System.Drawing.Size(75, 22);
            this.btn_LeakCheck.TabIndex = 4;
            this.btn_LeakCheck.Text = "漏扫检查";
            this.btn_LeakCheck.UseVisualStyleBackColor = false;
            this.btn_LeakCheck.Click += new System.EventHandler(this.btn_LeakCheck_Click);
            // 
            // btn_BackToScanning
            // 
            this.btn_BackToScanning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btn_BackToScanning.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_BackToScanning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BackToScanning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(66)))), ((int)(((byte)(63)))));
            this.btn_BackToScanning.Location = new System.Drawing.Point(10, 6);
            this.btn_BackToScanning.Margin = new System.Windows.Forms.Padding(3, 6, 0, 6);
            this.btn_BackToScanning.Name = "btn_BackToScanning";
            this.btn_BackToScanning.Size = new System.Drawing.Size(77, 22);
            this.btn_BackToScanning.TabIndex = 0;
            this.btn_BackToScanning.Text = "<<返回扫描";
            this.btn_BackToScanning.UseVisualStyleBackColor = false;
            this.btn_BackToScanning.Click += new System.EventHandler(this.btn_BackToScanning_Click);
            // 
            // tlpCurrentStatus
            // 
            this.tlpCurrentStatus.ColumnCount = 3;
            this.tlpCurrentStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCurrentStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCurrentStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCurrentStatus.Controls.Add(this.btnFinish, 2, 0);
            this.tlpCurrentStatus.Controls.Add(this.btnStats, 1, 0);
            this.tlpCurrentStatus.Controls.Add(this.btnScan, 0, 0);
            this.tlpCurrentStatus.Location = new System.Drawing.Point(3, 6);
            this.tlpCurrentStatus.Name = "tlpCurrentStatus";
            this.tlpCurrentStatus.RowCount = 1;
            this.tlpCurrentStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCurrentStatus.Size = new System.Drawing.Size(169, 23);
            this.tlpCurrentStatus.TabIndex = 0;
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinish.FlatAppearance.BorderSize = 0;
            this.btnFinish.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnFinish.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Window;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Location = new System.Drawing.Point(112, 0);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(0);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(57, 23);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = false;
            // 
            // btnStats
            // 
            this.btnStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStats.FlatAppearance.BorderSize = 0;
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.Location = new System.Drawing.Point(56, 0);
            this.btnStats.Margin = new System.Windows.Forms.Padding(0);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(56, 23);
            this.btnStats.TabIndex = 1;
            this.btnStats.Text = "统计";
            this.btnStats.UseVisualStyleBackColor = false;
            // 
            // btnScan
            // 
            this.btnScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScan.FlatAppearance.BorderSize = 0;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnScan.Location = new System.Drawing.Point(0, 0);
            this.btnScan.Margin = new System.Windows.Forms.Padding(0);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(56, 23);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "扫描";
            this.btnScan.UseVisualStyleBackColor = false;
            // 
            // flpPageAction
            // 
            this.flpPageAction.Controls.Add(this.btn_ZoomOut);
            this.flpPageAction.Controls.Add(this.btn_ZoomIn);
            this.flpPageAction.Controls.Add(this.btn_LastPage);
            this.flpPageAction.Controls.Add(this.lbl_PageIndex);
            this.flpPageAction.Controls.Add(this.btn_NextPage);
            this.flpPageAction.Location = new System.Drawing.Point(179, 4);
            this.flpPageAction.Margin = new System.Windows.Forms.Padding(0);
            this.flpPageAction.Name = "flpPageAction";
            this.flpPageAction.Size = new System.Drawing.Size(260, 27);
            this.flpPageAction.TabIndex = 9;
            // 
            // btn_ZoomOut
            // 
            this.btn_ZoomOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ZoomOut.FlatAppearance.BorderSize = 0;
            this.btn_ZoomOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_ZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ZoomOut.ImageIndex = 19;
            this.btn_ZoomOut.ImageList = this.imageList1;
            this.btn_ZoomOut.Location = new System.Drawing.Point(0, 0);
            this.btn_ZoomOut.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ZoomOut.Name = "btn_ZoomOut";
            this.btn_ZoomOut.Size = new System.Drawing.Size(54, 23);
            this.btn_ZoomOut.TabIndex = 3;
            this.btn_ZoomOut.Text = "放大";
            this.btn_ZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ZoomOut.UseVisualStyleBackColor = true;
            this.btn_ZoomOut.Click += new System.EventHandler(this.btn_ZoomOut_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "05.png");
            this.imageList1.Images.SetKeyName(1, "5.png");
            this.imageList1.Images.SetKeyName(2, "06.png");
            this.imageList1.Images.SetKeyName(3, "6.png");
            this.imageList1.Images.SetKeyName(4, "07.png");
            this.imageList1.Images.SetKeyName(5, "7.png");
            this.imageList1.Images.SetKeyName(6, "icon_40.png");
            this.imageList1.Images.SetKeyName(7, "icon_75.png");
            this.imageList1.Images.SetKeyName(8, "icon_76.png");
            this.imageList1.Images.SetKeyName(9, "icon_77.png");
            this.imageList1.Images.SetKeyName(10, "left0.png");
            this.imageList1.Images.SetKeyName(11, "left1.png");
            this.imageList1.Images.SetKeyName(12, "nextpage0.png");
            this.imageList1.Images.SetKeyName(13, "nextpage1.png");
            this.imageList1.Images.SetKeyName(14, "prepage0.png");
            this.imageList1.Images.SetKeyName(15, "prepage1.png");
            this.imageList1.Images.SetKeyName(16, "right0.png");
            this.imageList1.Images.SetKeyName(17, "right1.png");
            this.imageList1.Images.SetKeyName(18, "zoomin0.png");
            this.imageList1.Images.SetKeyName(19, "zoomin1.png");
            this.imageList1.Images.SetKeyName(20, "zoomout0.png");
            this.imageList1.Images.SetKeyName(21, "zoomout1.png");
            // 
            // btn_ZoomIn
            // 
            this.btn_ZoomIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ZoomIn.FlatAppearance.BorderSize = 0;
            this.btn_ZoomIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_ZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ZoomIn.ImageIndex = 21;
            this.btn_ZoomIn.ImageList = this.imageList1;
            this.btn_ZoomIn.Location = new System.Drawing.Point(54, 0);
            this.btn_ZoomIn.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ZoomIn.Name = "btn_ZoomIn";
            this.btn_ZoomIn.Size = new System.Drawing.Size(54, 23);
            this.btn_ZoomIn.TabIndex = 4;
            this.btn_ZoomIn.Text = "缩小";
            this.btn_ZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ZoomIn.UseVisualStyleBackColor = true;
            this.btn_ZoomIn.Click += new System.EventHandler(this.btn_ZoomIn_Click);
            // 
            // btn_LastPage
            // 
            this.btn_LastPage.FlatAppearance.BorderSize = 0;
            this.btn_LastPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_LastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LastPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LastPage.ImageIndex = 15;
            this.btn_LastPage.ImageList = this.imageList1;
            this.btn_LastPage.Location = new System.Drawing.Point(108, 0);
            this.btn_LastPage.Margin = new System.Windows.Forms.Padding(0);
            this.btn_LastPage.Name = "btn_LastPage";
            this.btn_LastPage.Size = new System.Drawing.Size(54, 23);
            this.btn_LastPage.TabIndex = 5;
            this.btn_LastPage.Text = "上页";
            this.btn_LastPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LastPage.UseVisualStyleBackColor = true;
            this.btn_LastPage.Click += new System.EventHandler(this.btn_LastPage_Click);
            // 
            // lbl_PageIndex
            // 
            this.lbl_PageIndex.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_PageIndex.Location = new System.Drawing.Point(165, 0);
            this.lbl_PageIndex.Name = "lbl_PageIndex";
            this.lbl_PageIndex.Size = new System.Drawing.Size(31, 23);
            this.lbl_PageIndex.TabIndex = 9;
            this.lbl_PageIndex.Text = "0/0";
            this.lbl_PageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_NextPage
            // 
            this.btn_NextPage.FlatAppearance.BorderSize = 0;
            this.btn_NextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_NextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NextPage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_NextPage.ImageList = this.imageList1;
            this.btn_NextPage.Location = new System.Drawing.Point(199, 0);
            this.btn_NextPage.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(57, 23);
            this.btn_NextPage.TabIndex = 6;
            this.btn_NextPage.Text = "下页";
            this.btn_NextPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NextPage.UseVisualStyleBackColor = true;
            this.btn_NextPage.Click += new System.EventHandler(this.btn_NextPage_Click);
            // 
            // btn_ScanTest
            // 
            this.btn_ScanTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btn_ScanTest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_ScanTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_ScanTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ScanTest.Location = new System.Drawing.Point(176, 22);
            this.btn_ScanTest.Margin = new System.Windows.Forms.Padding(5, 6, 0, 6);
            this.btn_ScanTest.Name = "btn_ScanTest";
            this.btn_ScanTest.Size = new System.Drawing.Size(80, 22);
            this.btn_ScanTest.TabIndex = 4;
            this.btn_ScanTest.Text = "选图识别";
            this.btn_ScanTest.UseVisualStyleBackColor = false;
            this.btn_ScanTest.Click += new System.EventHandler(this.btn_ScanTest_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Status.Location = new System.Drawing.Point(0, 0);
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(65, 40);
            this.lbl_Status.TabIndex = 3;
            this.lbl_Status.Text = "状态：正常";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLeft_BatchList
            // 
            this.panelLeft_BatchList.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeft_BatchList.Controls.Add(this.lbBatch);
            this.panelLeft_BatchList.Controls.Add(this.lbl_BatchListTitle);
            this.panelLeft_BatchList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeft_BatchList.Location = new System.Drawing.Point(0, 70);
            this.panelLeft_BatchList.Name = "panelLeft_BatchList";
            this.panelLeft_BatchList.Size = new System.Drawing.Size(268, 150);
            this.panelLeft_BatchList.TabIndex = 0;
            // 
            // lbBatch
            // 
            this.lbBatch.BackColor = System.Drawing.SystemColors.Control;
            this.lbBatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbBatch.ContextMenuStrip = this.contextMS_batch;
            this.lbBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBatch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbBatch.Font = new System.Drawing.Font("宋体", 10F);
            this.lbBatch.FormattingEnabled = true;
            this.lbBatch.Location = new System.Drawing.Point(0, 40);
            this.lbBatch.Name = "lbBatch";
            this.lbBatch.Size = new System.Drawing.Size(268, 110);
            this.lbBatch.TabIndex = 1;
            this.lbBatch.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            // 
            // contextMS_batch
            // 
            this.contextMS_batch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete,
            this.ts_RecoAgain});
            this.contextMS_batch.Name = "contextMS_batch";
            this.contextMS_batch.Size = new System.Drawing.Size(137, 48);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(136, 22);
            this.tsmiDelete.Text = "删除本批次";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // ts_RecoAgain
            // 
            this.ts_RecoAgain.Name = "ts_RecoAgain";
            this.ts_RecoAgain.Size = new System.Drawing.Size(136, 22);
            this.ts_RecoAgain.Text = "重新识别";
            // 
            // lbl_BatchListTitle
            // 
            this.lbl_BatchListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.lbl_BatchListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_BatchListTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_BatchListTitle.Location = new System.Drawing.Point(0, 0);
            this.lbl_BatchListTitle.Name = "lbl_BatchListTitle";
            this.lbl_BatchListTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbl_BatchListTitle.Size = new System.Drawing.Size(268, 40);
            this.lbl_BatchListTitle.TabIndex = 0;
            this.lbl_BatchListTitle.Text = "批次列表";
            this.lbl_BatchListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progress_Scan
            // 
            this.progress_Scan.BackColor = System.Drawing.SystemColors.Window;
            this.progress_Scan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progress_Scan.Location = new System.Drawing.Point(65, 12);
            this.progress_Scan.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.progress_Scan.Name = "progress_Scan";
            this.progress_Scan.Size = new System.Drawing.Size(172, 16);
            this.progress_Scan.TabIndex = 1;
            this.progress_Scan.Value = 30;
            // 
            // panel_LeftTop
            // 
            this.panel_LeftTop.BackColor = System.Drawing.Color.White;
            this.panel_LeftTop.Controls.Add(this.btn_ScanTest);
            this.panel_LeftTop.Controls.Add(this.btn_Search);
            this.panel_LeftTop.Controls.Add(this.lblScanPaperList);
            this.panel_LeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_LeftTop.Location = new System.Drawing.Point(0, 0);
            this.panel_LeftTop.Margin = new System.Windows.Forms.Padding(0);
            this.panel_LeftTop.Name = "panel_LeftTop";
            this.panel_LeftTop.Size = new System.Drawing.Size(268, 70);
            this.panel_LeftTop.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Image = ((System.Drawing.Image)(resources.GetObject("btn_Search.Image")));
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.Location = new System.Drawing.Point(278, 11);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(53, 29);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "查询";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lblScanPaperList
            // 
            this.lblScanPaperList.AutoSize = true;
            this.lblScanPaperList.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScanPaperList.ForeColor = System.Drawing.Color.Black;
            this.lblScanPaperList.Location = new System.Drawing.Point(10, 15);
            this.lblScanPaperList.Name = "lblScanPaperList";
            this.lblScanPaperList.Size = new System.Drawing.Size(138, 28);
            this.lblScanPaperList.TabIndex = 1;
            this.lblScanPaperList.Text = "试卷扫描列表";
            // 
            // panelRight_Body
            // 
            this.panelRight_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight_Body.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.panelRight_Body.Location = new System.Drawing.Point(0, 70);
            this.panelRight_Body.Name = "panelRight_Body";
            this.panelRight_Body.Size = new System.Drawing.Size(911, 340);
            this.panelRight_Body.TabIndex = 1;
            // 
            // panel_leftfooter
            // 
            this.panel_leftfooter.Controls.Add(this.list_Abnormal);
            this.panel_leftfooter.Controls.Add(this.lbl_AbnormalTitle);
            this.panel_leftfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_leftfooter.Location = new System.Drawing.Point(0, 260);
            this.panel_leftfooter.Name = "panel_leftfooter";
            this.panel_leftfooter.Size = new System.Drawing.Size(268, 150);
            this.panel_leftfooter.TabIndex = 2;
            // 
            // list_Abnormal
            // 
            this.list_Abnormal.BackColor = System.Drawing.SystemColors.Control;
            this.list_Abnormal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Abnormal.ContextMenuStrip = this.contextMS_ErrorPage;
            this.list_Abnormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Abnormal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.list_Abnormal.Font = new System.Drawing.Font("宋体", 10F);
            this.list_Abnormal.FormattingEnabled = true;
            this.list_Abnormal.Items.AddRange(new object[] {
            "0份试卷信息异常",
            "0份考生信息异常",
            "0份客观题信息异常"});
            this.list_Abnormal.Location = new System.Drawing.Point(0, 40);
            this.list_Abnormal.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.list_Abnormal.Name = "list_Abnormal";
            this.list_Abnormal.Size = new System.Drawing.Size(268, 110);
            this.list_Abnormal.TabIndex = 3;
            this.list_Abnormal.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            // 
            // contextMS_ErrorPage
            // 
            this.contextMS_ErrorPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_DeleteErrorPages,
            this.ts_RecoAgainErrorPages});
            this.contextMS_ErrorPage.Name = "contextMS_batch";
            this.contextMS_ErrorPage.Size = new System.Drawing.Size(161, 48);
            // 
            // ts_DeleteErrorPages
            // 
            this.ts_DeleteErrorPages.Name = "ts_DeleteErrorPages";
            this.ts_DeleteErrorPages.Size = new System.Drawing.Size(160, 22);
            this.ts_DeleteErrorPages.Text = "删除该类异常卷";
            // 
            // ts_RecoAgainErrorPages
            // 
            this.ts_RecoAgainErrorPages.Name = "ts_RecoAgainErrorPages";
            this.ts_RecoAgainErrorPages.Size = new System.Drawing.Size(160, 22);
            this.ts_RecoAgainErrorPages.Text = "重新识别";
            // 
            // lbl_AbnormalTitle
            // 
            this.lbl_AbnormalTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_AbnormalTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_AbnormalTitle.Location = new System.Drawing.Point(0, 0);
            this.lbl_AbnormalTitle.Name = "lbl_AbnormalTitle";
            this.lbl_AbnormalTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbl_AbnormalTitle.Size = new System.Drawing.Size(268, 40);
            this.lbl_AbnormalTitle.TabIndex = 1;
            this.lbl_AbnormalTitle.Text = "异常卷列表";
            this.lbl_AbnormalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_leftBody
            // 
            this.panel_leftBody.Controls.Add(this.list_NormalPaper);
            this.panel_leftBody.Controls.Add(this.lbl_NormalTitle);
            this.panel_leftBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_leftBody.Location = new System.Drawing.Point(0, 220);
            this.panel_leftBody.Name = "panel_leftBody";
            this.panel_leftBody.Size = new System.Drawing.Size(268, 40);
            this.panel_leftBody.TabIndex = 1;
            // 
            // list_NormalPaper
            // 
            this.list_NormalPaper.BackColor = System.Drawing.SystemColors.Control;
            this.list_NormalPaper.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_NormalPaper.ContextMenuStrip = this.contextMS_NormalPaper;
            this.list_NormalPaper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_NormalPaper.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.list_NormalPaper.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_NormalPaper.FormattingEnabled = true;
            this.list_NormalPaper.Location = new System.Drawing.Point(0, 40);
            this.list_NormalPaper.Margin = new System.Windows.Forms.Padding(10);
            this.list_NormalPaper.Name = "list_NormalPaper";
            this.list_NormalPaper.Size = new System.Drawing.Size(268, 0);
            this.list_NormalPaper.TabIndex = 2;
            this.list_NormalPaper.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            // 
            // contextMS_NormalPaper
            // 
            this.contextMS_NormalPaper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_SetAsOmrError,
            this.cms_setAsZkzhError});
            this.contextMS_NormalPaper.Name = "contextMS_batch";
            this.contextMS_NormalPaper.Size = new System.Drawing.Size(161, 48);
            // 
            // cms_SetAsOmrError
            // 
            this.cms_SetAsOmrError.Name = "cms_SetAsOmrError";
            this.cms_SetAsOmrError.Size = new System.Drawing.Size(160, 22);
            this.cms_SetAsOmrError.Text = "置为客观题异常";
            this.cms_SetAsOmrError.Click += new System.EventHandler(this.cms_SetAsOmrError_Click);
            // 
            // cms_setAsZkzhError
            // 
            this.cms_setAsZkzhError.Name = "cms_setAsZkzhError";
            this.cms_setAsZkzhError.Size = new System.Drawing.Size(160, 22);
            this.cms_setAsZkzhError.Text = "置为考号异常";
            this.cms_setAsZkzhError.Click += new System.EventHandler(this.cms_setAsZkzhError_Click);
            // 
            // lbl_NormalTitle
            // 
            this.lbl_NormalTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_NormalTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_NormalTitle.Location = new System.Drawing.Point(0, 0);
            this.lbl_NormalTitle.Name = "lbl_NormalTitle";
            this.lbl_NormalTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbl_NormalTitle.Size = new System.Drawing.Size(268, 40);
            this.lbl_NormalTitle.TabIndex = 1;
            this.lbl_NormalTitle.Text = "正常卷列表";
            this.lbl_NormalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.BackColor = System.Drawing.Color.White;
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, -1);
            this.scMain.Margin = new System.Windows.Forms.Padding(0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.scMain.Panel1.Controls.Add(this.panel_leftBody);
            this.scMain.Panel1.Controls.Add(this.panel_leftfooter);
            this.scMain.Panel1.Controls.Add(this.panelLeft_BatchList);
            this.scMain.Panel1.Controls.Add(this.panel_LeftTop);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.panelRight_Body);
            this.scMain.Panel2.Controls.Add(this.panelTool);
            this.scMain.Size = new System.Drawing.Size(1184, 412);
            this.scMain.SplitterDistance = 270;
            this.scMain.SplitterWidth = 1;
            this.scMain.TabIndex = 18;
            // 
            // panTop
            // 
            this.panTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTop.Controls.Add(this.flpTopStatusAction);
            this.panTop.Controls.Add(this.lblExamName);
            this.panTop.Controls.Add(this.lblBackExamList);
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Margin = new System.Windows.Forms.Padding(0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(1183, 40);
            this.panTop.TabIndex = 19;
            // 
            // flpTopStatusAction
            // 
            this.flpTopStatusAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpTopStatusAction.AutoSize = true;
            this.flpTopStatusAction.Controls.Add(this.btnScanerSetting);
            this.flpTopStatusAction.Controls.Add(this.btnScanFinish);
            this.flpTopStatusAction.Controls.Add(this.btnContinueScan);
            this.flpTopStatusAction.Controls.Add(this.progress_Scan);
            this.flpTopStatusAction.Controls.Add(this.lbl_Status);
            this.flpTopStatusAction.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpTopStatusAction.Location = new System.Drawing.Point(646, 0);
            this.flpTopStatusAction.Name = "flpTopStatusAction";
            this.flpTopStatusAction.Size = new System.Drawing.Size(537, 40);
            this.flpTopStatusAction.TabIndex = 14;
            // 
            // btnScanerSetting
            // 
            this.btnScanerSetting.AutoSize = true;
            this.btnScanerSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnScanerSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScanerSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnScanerSetting.FlatAppearance.BorderSize = 0;
            this.btnScanerSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanerSetting.Font = new System.Drawing.Font("宋体", 12F);
            this.btnScanerSetting.Image = global::YXH.ScanForm.ScanOperateFormRes.Setting_ico;
            this.btnScanerSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScanerSetting.Location = new System.Drawing.Point(437, 0);
            this.btnScanerSetting.Margin = new System.Windows.Forms.Padding(0);
            this.btnScanerSetting.Name = "btnScanerSetting";
            this.btnScanerSetting.Size = new System.Drawing.Size(100, 40);
            this.btnScanerSetting.TabIndex = 3;
            this.btnScanerSetting.Text = "扫描设置";
            this.btnScanerSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScanerSetting.UseVisualStyleBackColor = false;
            this.btnScanerSetting.Click += new System.EventHandler(this.btn_scanerSetting_Click);
            // 
            // btnScanFinish
            // 
            this.btnScanFinish.AutoSize = true;
            this.btnScanFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnScanFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScanFinish.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnScanFinish.FlatAppearance.BorderSize = 0;
            this.btnScanFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanFinish.Font = new System.Drawing.Font("宋体", 12F);
            this.btnScanFinish.Image = global::YXH.ScanForm.ScanOperateFormRes.Button_FinishScan_ico;
            this.btnScanFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScanFinish.Location = new System.Drawing.Point(337, 0);
            this.btnScanFinish.Margin = new System.Windows.Forms.Padding(0);
            this.btnScanFinish.Name = "btnScanFinish";
            this.btnScanFinish.Size = new System.Drawing.Size(100, 40);
            this.btnScanFinish.TabIndex = 10;
            this.btnScanFinish.Text = "完成扫描";
            this.btnScanFinish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScanFinish.UseVisualStyleBackColor = false;
            // 
            // btnContinueScan
            // 
            this.btnContinueScan.AutoSize = true;
            this.btnContinueScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnContinueScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnContinueScan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnContinueScan.FlatAppearance.BorderSize = 0;
            this.btnContinueScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinueScan.Font = new System.Drawing.Font("宋体", 12F);
            this.btnContinueScan.Image = global::YXH.ScanForm.ScanOperateFormRes.Button_ContinueScan_ico;
            this.btnContinueScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinueScan.Location = new System.Drawing.Point(237, 0);
            this.btnContinueScan.Margin = new System.Windows.Forms.Padding(0);
            this.btnContinueScan.Name = "btnContinueScan";
            this.btnContinueScan.Size = new System.Drawing.Size(100, 40);
            this.btnContinueScan.TabIndex = 9;
            this.btnContinueScan.Text = "继续扫描";
            this.btnContinueScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinueScan.UseVisualStyleBackColor = false;
            // 
            // lblExamName
            // 
            this.lblExamName.AutoSize = true;
            this.lblExamName.Font = new System.Drawing.Font("宋体", 12F);
            this.lblExamName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblExamName.Location = new System.Drawing.Point(269, 12);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(72, 16);
            this.lblExamName.TabIndex = 2;
            this.lblExamName.Text = "考试信息";
            // 
            // lblBackExamList
            // 
            this.lblBackExamList.AutoSize = true;
            this.lblBackExamList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBackExamList.Image = global::YXH.ScanForm.ScanOperateFormRes.Back;
            this.lblBackExamList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackExamList.Location = new System.Drawing.Point(9, 12);
            this.lblBackExamList.Margin = new System.Windows.Forms.Padding(0);
            this.lblBackExamList.Name = "lblBackExamList";
            this.lblBackExamList.Size = new System.Drawing.Size(64, 16);
            this.lblBackExamList.TabIndex = 1;
            this.lblBackExamList.Text = "   返回";
            this.lblBackExamList.Click += new System.EventHandler(this.lblBackExamList_Click);
            // 
            // panMain
            // 
            this.panMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panMain.Controls.Add(this.scMain);
            this.panMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(66)))), ((int)(((byte)(63)))));
            this.panMain.Location = new System.Drawing.Point(-1, 40);
            this.panMain.Margin = new System.Windows.Forms.Padding(0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(1186, 414);
            this.panMain.TabIndex = 20;
            // 
            // ScanOperateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 414);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanOperateForm";
            this.Text = "ScanOperateForm";
            this.Load += new System.EventHandler(this.ScanOperateForm_Load);
            this.panelTool.ResumeLayout(false);
            this.panScanStatusInfo.ResumeLayout(false);
            this.panScanStatusInfo.PerformLayout();
            this.panPageActin.ResumeLayout(false);
            this.flpActionGroup.ResumeLayout(false);
            this.tlpCurrentStatus.ResumeLayout(false);
            this.flpPageAction.ResumeLayout(false);
            this.panelLeft_BatchList.ResumeLayout(false);
            this.contextMS_batch.ResumeLayout(false);
            this.panel_LeftTop.ResumeLayout(false);
            this.panel_LeftTop.PerformLayout();
            this.panel_leftfooter.ResumeLayout(false);
            this.contextMS_ErrorPage.ResumeLayout(false);
            this.panel_leftBody.ResumeLayout(false);
            this.contextMS_NormalPaper.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.flpTopStatusAction.ResumeLayout(false);
            this.flpTopStatusAction.PerformLayout();
            this.panMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.Panel panelLeft_BatchList;
        private System.Windows.Forms.Panel panel_LeftTop;
        private System.Windows.Forms.Panel panelRight_Body;
        private System.Windows.Forms.Panel panel_leftfooter;
        private System.Windows.Forms.Panel panel_leftBody;
        private System.Windows.Forms.TableLayoutPanel tlpCurrentStatus;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btn_ScanTest;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Button btn_ZoomOut;
        private System.Windows.Forms.Button btn_ZoomIn;
        private System.Windows.Forms.Button btnContinueScan;
        private System.Windows.Forms.Button btn_LeakCheck;
        private System.Windows.Forms.Button btnScanFinish;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_BackToScanning;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnScanerSetting;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btn_NextPage;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Label lbl_BatchListTitle;
        private System.Windows.Forms.Label lbl_PageIndex;
        private System.Windows.Forms.Label lbl_NormalTitle;
        private System.Windows.Forms.Label lbl_CurWork;
        private System.Windows.Forms.Label lblScanPaperList;
        private System.Windows.Forms.Label lbl_Num;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label lbl_AbnormalTitle;
        private System.Windows.Forms.ProgressBar progress_Scan;
        private System.Windows.Forms.ListBox list_NormalPaper;
        private System.Windows.Forms.ListBox list_Abnormal;
        private System.Windows.Forms.ListBox lbBatch;
        private System.ComponentModel.BackgroundWorker bg_workerForScanner;
        private System.Windows.Forms.ContextMenuStrip contextMS_batch;
        private System.Windows.Forms.ContextMenuStrip contextMS_ErrorPage;
        private System.Windows.Forms.ContextMenuStrip contextMS_NormalPaper;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flpPageAction;
        private ToolStripMenuItem cms_SetAsOmrError;
        private ToolStripMenuItem cms_setAsZkzhError;
        private ToolStripMenuItem ts_DeleteErrorPages;
        private ToolStripMenuItem ts_RecoAgainErrorPages;
        private ToolStripMenuItem tsmiDelete;
        private ToolStripMenuItem ts_RecoAgain;
        private Panel panTop;
        private Label lblBackExamList;
        private Panel panMain;
        private Label lblExamName;
        private Panel panPageActin;
        private Panel panScanStatusInfo;
        private FlowLayoutPanel flpTopStatusAction;
        private FlowLayoutPanel flpActionGroup;
    }
}

