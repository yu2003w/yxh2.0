using System;
using System.Drawing;
using System.Windows.Forms;
namespace YXH.Main
{
    partial class SubjectOperateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panActive = new System.Windows.Forms.Panel();
            this.btn_checkTemplate = new System.Windows.Forms.Button();
            this.btn_UploadMaterial = new System.Windows.Forms.Button();
            this.btn_ContinueScan = new System.Windows.Forms.Button();
            this.lblContinueScanBtnText = new System.Windows.Forms.Label();
            this.btn_NewTemplate = new System.Windows.Forms.Button();
            this.panActionDetails = new System.Windows.Forms.Panel();
            this.panActionResutl = new System.Windows.Forms.Panel();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.btnScanRecordSaveDir = new System.Windows.Forms.Button();
            this.btnImageSaveDir = new System.Windows.Forms.Button();
            this.btnBatchExport = new System.Windows.Forms.Button();
            this.lblActionDetails = new System.Windows.Forms.Label();
            this.panel_footer = new System.Windows.Forms.Panel();
            this.picExaminationNumberAbnormal = new System.Windows.Forms.PictureBox();
            this.lblExaminationNumberAbnormal = new System.Windows.Forms.Label();
            this.ExaminationNumberAbnormalCount = new System.Windows.Forms.Label();
            this.picProcessedAbnormal = new System.Windows.Forms.PictureBox();
            this.lblProcessedAbnormal = new System.Windows.Forms.Label();
            this.lblProcessedAbnormalStatistics = new System.Windows.Forms.Label();
            this.picUntreatedAbnormal = new System.Windows.Forms.PictureBox();
            this.lblUntreatedAbnormal = new System.Windows.Forms.Label();
            this.lblUntreatedAbnormalStatistics = new System.Windows.Forms.Label();
            this.picLockNumber = new System.Windows.Forms.PictureBox();
            this.lblLockNumber = new System.Windows.Forms.Label();
            this.lblLockNumberStatistics = new System.Windows.Forms.Label();
            this.picScanned = new System.Windows.Forms.PictureBox();
            this.lblScanned = new System.Windows.Forms.Label();
            this.lblScannedStatistics = new System.Windows.Forms.Label();
            this.picWillnum = new System.Windows.Forms.PictureBox();
            this.lblWillnumText = new System.Windows.Forms.Label();
            this.lblWillnumStatistics = new System.Windows.Forms.Label();
            this.panScanInfo = new System.Windows.Forms.Panel();
            this.lblDayCompletedNum = new System.Windows.Forms.Label();
            this.lblScanVelocityNum = new System.Windows.Forms.Label();
            this.lblDayCompleted = new System.Windows.Forms.Label();
            this.lblDayCompletedUnit = new System.Windows.Forms.Label();
            this.lblScanVelocity = new System.Windows.Forms.Label();
            this.lblScanVelocityUnit = new System.Windows.Forms.Label();
            this.panBackupBar = new System.Windows.Forms.Panel();
            this.lblBackExamList = new System.Windows.Forms.Label();
            this.panExamTitleBar = new System.Windows.Forms.Panel();
            this.lblExamInfo = new System.Windows.Forms.Label();
            this.panExport = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panContent = new System.Windows.Forms.Panel();
            this.panActive.SuspendLayout();
            this.btn_ContinueScan.SuspendLayout();
            this.panActionDetails.SuspendLayout();
            this.panActionResutl.SuspendLayout();
            this.panel_footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExaminationNumberAbnormal)).BeginInit();
            this.picExaminationNumberAbnormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessedAbnormal)).BeginInit();
            this.picProcessedAbnormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUntreatedAbnormal)).BeginInit();
            this.picUntreatedAbnormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLockNumber)).BeginInit();
            this.picLockNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScanned)).BeginInit();
            this.picScanned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWillnum)).BeginInit();
            this.picWillnum.SuspendLayout();
            this.panScanInfo.SuspendLayout();
            this.panBackupBar.SuspendLayout();
            this.panExamTitleBar.SuspendLayout();
            this.panExport.SuspendLayout();
            this.panContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panActive
            // 
            this.panActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panActive.BackColor = System.Drawing.Color.White;
            this.panActive.Controls.Add(this.btn_checkTemplate);
            this.panActive.Controls.Add(this.btn_UploadMaterial);
            this.panActive.Controls.Add(this.btn_ContinueScan);
            this.panActive.Controls.Add(this.btn_NewTemplate);
            this.panActive.Location = new System.Drawing.Point(0, 102);
            this.panActive.Margin = new System.Windows.Forms.Padding(0);
            this.panActive.Name = "panActive";
            this.panActive.Size = new System.Drawing.Size(1020, 208);
            this.panActive.TabIndex = 0;
            this.panActive.Paint += new System.Windows.Forms.PaintEventHandler(this.panActive_Paint);
            // 
            // btn_checkTemplate
            // 
            this.btn_checkTemplate.AutoSize = true;
            this.btn_checkTemplate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_checkTemplate.FlatAppearance.BorderSize = 0;
            this.btn_checkTemplate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_checkTemplate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_checkTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_checkTemplate.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_checkTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.btn_checkTemplate.Location = new System.Drawing.Point(100, 134);
            this.btn_checkTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_checkTemplate.Name = "btn_checkTemplate";
            this.btn_checkTemplate.Size = new System.Drawing.Size(99, 29);
            this.btn_checkTemplate.TabIndex = 8;
            this.btn_checkTemplate.Text = "查看模板";
            this.btn_checkTemplate.UseVisualStyleBackColor = true;
            this.btn_checkTemplate.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_UploadMaterial
            // 
            this.btn_UploadMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UploadMaterial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_UploadMaterial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_UploadMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_UploadMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UploadMaterial.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_UploadMaterial.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_UploadMaterial.Location = new System.Drawing.Point(720, 0);
            this.btn_UploadMaterial.Name = "btn_UploadMaterial";
            this.btn_UploadMaterial.Size = new System.Drawing.Size(300, 122);
            this.btn_UploadMaterial.TabIndex = 5;
            this.btn_UploadMaterial.Text = "上传资料";
            this.btn_UploadMaterial.UseVisualStyleBackColor = true;
            this.btn_UploadMaterial.Visible = false;
            this.btn_UploadMaterial.Click += new System.EventHandler(this.btn_ScanEmptyPaper_Click);
            this.btn_UploadMaterial.MouseEnter += new System.EventHandler(this.btn_ActionAcer_MouseEnter);
            this.btn_UploadMaterial.MouseLeave += new System.EventHandler(this.btn_ActionAcer_MouseLeave);
            // 
            // btn_ContinueScan
            // 
            this.btn_ContinueScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ContinueScan.BackColor = System.Drawing.Color.White;
            this.btn_ContinueScan.Controls.Add(this.lblContinueScanBtnText);
            this.btn_ContinueScan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_ContinueScan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_ContinueScan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_ContinueScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ContinueScan.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ContinueScan.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_ContinueScan.Location = new System.Drawing.Point(360, 0);
            this.btn_ContinueScan.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ContinueScan.Name = "btn_ContinueScan";
            this.btn_ContinueScan.Size = new System.Drawing.Size(300, 122);
            this.btn_ContinueScan.TabIndex = 5;
            this.btn_ContinueScan.UseVisualStyleBackColor = false;
            this.btn_ContinueScan.Click += new System.EventHandler(this.btn_ContinueScan_Click);
            this.btn_ContinueScan.MouseEnter += new System.EventHandler(this.btn_ActionAcer_MouseEnter);
            this.btn_ContinueScan.MouseLeave += new System.EventHandler(this.btn_ActionAcer_MouseLeave);
            // 
            // lblContinueScanBtnText
            // 
            this.lblContinueScanBtnText.AutoSize = true;
            this.lblContinueScanBtnText.Location = new System.Drawing.Point(95, 50);
            this.lblContinueScanBtnText.Margin = new System.Windows.Forms.Padding(0);
            this.lblContinueScanBtnText.Name = "lblContinueScanBtnText";
            this.lblContinueScanBtnText.Size = new System.Drawing.Size(109, 19);
            this.lblContinueScanBtnText.TabIndex = 9;
            this.lblContinueScanBtnText.Text = "扫描答题卡";
            this.lblContinueScanBtnText.Click += new System.EventHandler(this.btn_ContinueScan_Click);
            this.lblContinueScanBtnText.MouseEnter += new System.EventHandler(this.btn_ActionAcer_MouseEnter);
            // 
            // btn_NewTemplate
            // 
            this.btn_NewTemplate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_NewTemplate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_NewTemplate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_NewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewTemplate.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NewTemplate.ForeColor = System.Drawing.Color.Black;
            this.btn_NewTemplate.Location = new System.Drawing.Point(0, 0);
            this.btn_NewTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NewTemplate.Name = "btn_NewTemplate";
            this.btn_NewTemplate.Size = new System.Drawing.Size(300, 122);
            this.btn_NewTemplate.TabIndex = 4;
            this.btn_NewTemplate.Text = "添加模板";
            this.btn_NewTemplate.UseVisualStyleBackColor = true;
            this.btn_NewTemplate.Click += new System.EventHandler(this.btn_NewTemplate_Click);
            this.btn_NewTemplate.MouseEnter += new System.EventHandler(this.btn_ActionAcer_MouseEnter);
            this.btn_NewTemplate.MouseLeave += new System.EventHandler(this.btn_ActionAcer_MouseLeave);
            // 
            // panActionDetails
            // 
            this.panActionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panActionDetails.BackColor = System.Drawing.Color.White;
            this.panActionDetails.Controls.Add(this.panActionResutl);
            this.panActionDetails.Controls.Add(this.lblActionDetails);
            this.panActionDetails.Controls.Add(this.panel_footer);
            this.panActionDetails.Controls.Add(this.panScanInfo);
            this.panActionDetails.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panActionDetails.Location = new System.Drawing.Point(0, 310);
            this.panActionDetails.Name = "panActionDetails";
            this.panActionDetails.Size = new System.Drawing.Size(1020, 287);
            this.panActionDetails.TabIndex = 1;
            // 
            // panActionResutl
            // 
            this.panActionResutl.Controls.Add(this.btnViewLog);
            this.panActionResutl.Controls.Add(this.btnScanRecordSaveDir);
            this.panActionResutl.Controls.Add(this.btnImageSaveDir);
            this.panActionResutl.Controls.Add(this.btnBatchExport);
            this.panActionResutl.Location = new System.Drawing.Point(510, 72);
            this.panActionResutl.Margin = new System.Windows.Forms.Padding(0);
            this.panActionResutl.Name = "panActionResutl";
            this.panActionResutl.Size = new System.Drawing.Size(510, 40);
            this.panActionResutl.TabIndex = 1;
            this.panActionResutl.Visible = false;
            // 
            // btnViewLog
            // 
            this.btnViewLog.AutoSize = true;
            this.btnViewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnViewLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLog.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnViewLog.Location = new System.Drawing.Point(414, 0);
            this.btnViewLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(95, 40);
            this.btnViewLog.TabIndex = 3;
            this.btnViewLog.Text = "查看日志";
            this.btnViewLog.UseVisualStyleBackColor = false;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // btnScanRecordSaveDir
            // 
            this.btnScanRecordSaveDir.AutoSize = true;
            this.btnScanRecordSaveDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnScanRecordSaveDir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnScanRecordSaveDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanRecordSaveDir.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanRecordSaveDir.Location = new System.Drawing.Point(238, 0);
            this.btnScanRecordSaveDir.Margin = new System.Windows.Forms.Padding(0);
            this.btnScanRecordSaveDir.Name = "btnScanRecordSaveDir";
            this.btnScanRecordSaveDir.Size = new System.Drawing.Size(171, 40);
            this.btnScanRecordSaveDir.TabIndex = 2;
            this.btnScanRecordSaveDir.Text = "扫描记录保存目录";
            this.btnScanRecordSaveDir.UseVisualStyleBackColor = false;
            // 
            // btnImageSaveDir
            // 
            this.btnImageSaveDir.AutoSize = true;
            this.btnImageSaveDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnImageSaveDir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnImageSaveDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImageSaveDir.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImageSaveDir.Location = new System.Drawing.Point(100, 0);
            this.btnImageSaveDir.Margin = new System.Windows.Forms.Padding(0);
            this.btnImageSaveDir.Name = "btnImageSaveDir";
            this.btnImageSaveDir.Size = new System.Drawing.Size(133, 40);
            this.btnImageSaveDir.TabIndex = 1;
            this.btnImageSaveDir.Text = "图片保存目录";
            this.btnImageSaveDir.UseVisualStyleBackColor = false;
            // 
            // btnBatchExport
            // 
            this.btnBatchExport.AutoSize = true;
            this.btnBatchExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnBatchExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBatchExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchExport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBatchExport.Location = new System.Drawing.Point(0, 0);
            this.btnBatchExport.Margin = new System.Windows.Forms.Padding(0);
            this.btnBatchExport.Name = "btnBatchExport";
            this.btnBatchExport.Size = new System.Drawing.Size(95, 40);
            this.btnBatchExport.TabIndex = 0;
            this.btnBatchExport.Text = "批量导出";
            this.btnBatchExport.UseVisualStyleBackColor = false;
            // 
            // lblActionDetails
            // 
            this.lblActionDetails.AutoSize = true;
            this.lblActionDetails.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblActionDetails.Location = new System.Drawing.Point(0, 45);
            this.lblActionDetails.Margin = new System.Windows.Forms.Padding(0);
            this.lblActionDetails.Name = "lblActionDetails";
            this.lblActionDetails.Size = new System.Drawing.Size(98, 21);
            this.lblActionDetails.TabIndex = 0;
            this.lblActionDetails.Text = "操作详情";
            // 
            // panel_footer
            // 
            this.panel_footer.Controls.Add(this.picExaminationNumberAbnormal);
            this.panel_footer.Controls.Add(this.picProcessedAbnormal);
            this.panel_footer.Controls.Add(this.picUntreatedAbnormal);
            this.panel_footer.Controls.Add(this.picLockNumber);
            this.panel_footer.Controls.Add(this.picScanned);
            this.panel_footer.Controls.Add(this.picWillnum);
            this.panel_footer.Location = new System.Drawing.Point(0, 157);
            this.panel_footer.Margin = new System.Windows.Forms.Padding(0);
            this.panel_footer.Name = "panel_footer";
            this.panel_footer.Size = new System.Drawing.Size(1020, 130);
            this.panel_footer.TabIndex = 2;
            this.panel_footer.Visible = false;
            // 
            // picExaminationNumberAbnormal
            // 
            this.picExaminationNumberAbnormal.Controls.Add(this.lblExaminationNumberAbnormal);
            this.picExaminationNumberAbnormal.Controls.Add(this.ExaminationNumberAbnormalCount);
            this.picExaminationNumberAbnormal.Location = new System.Drawing.Point(684, 0);
            this.picExaminationNumberAbnormal.Margin = new System.Windows.Forms.Padding(0);
            this.picExaminationNumberAbnormal.Name = "picExaminationNumberAbnormal";
            this.picExaminationNumberAbnormal.Size = new System.Drawing.Size(164, 130);
            this.picExaminationNumberAbnormal.TabIndex = 5;
            this.picExaminationNumberAbnormal.TabStop = false;
            // 
            // lblExaminationNumberAbnormal
            // 
            this.lblExaminationNumberAbnormal.AutoSize = true;
            this.lblExaminationNumberAbnormal.Location = new System.Drawing.Point(25, 85);
            this.lblExaminationNumberAbnormal.Name = "lblExaminationNumberAbnormal";
            this.lblExaminationNumberAbnormal.Size = new System.Drawing.Size(113, 12);
            this.lblExaminationNumberAbnormal.TabIndex = 2;
            this.lblExaminationNumberAbnormal.Text = "考号异常已处理份数";
            // 
            // ExaminationNumberAbnormalCount
            // 
            this.ExaminationNumberAbnormalCount.AutoSize = true;
            this.ExaminationNumberAbnormalCount.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExaminationNumberAbnormalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.ExaminationNumberAbnormalCount.Location = new System.Drawing.Point(60, 23);
            this.ExaminationNumberAbnormalCount.Margin = new System.Windows.Forms.Padding(0);
            this.ExaminationNumberAbnormalCount.Name = "ExaminationNumberAbnormalCount";
            this.ExaminationNumberAbnormalCount.Size = new System.Drawing.Size(44, 48);
            this.ExaminationNumberAbnormalCount.TabIndex = 1;
            this.ExaminationNumberAbnormalCount.Text = "0";
            // 
            // picProcessedAbnormal
            // 
            this.picProcessedAbnormal.Controls.Add(this.lblProcessedAbnormal);
            this.picProcessedAbnormal.Controls.Add(this.lblProcessedAbnormalStatistics);
            this.picProcessedAbnormal.Location = new System.Drawing.Point(855, 0);
            this.picProcessedAbnormal.Margin = new System.Windows.Forms.Padding(0);
            this.picProcessedAbnormal.Name = "picProcessedAbnormal";
            this.picProcessedAbnormal.Size = new System.Drawing.Size(164, 130);
            this.picProcessedAbnormal.TabIndex = 4;
            this.picProcessedAbnormal.TabStop = false;
            // 
            // lblProcessedAbnormal
            // 
            this.lblProcessedAbnormal.AutoSize = true;
            this.lblProcessedAbnormal.Location = new System.Drawing.Point(20, 85);
            this.lblProcessedAbnormal.Name = "lblProcessedAbnormal";
            this.lblProcessedAbnormal.Size = new System.Drawing.Size(125, 12);
            this.lblProcessedAbnormal.TabIndex = 2;
            this.lblProcessedAbnormal.Text = "客观题异常已处理份数";
            // 
            // lblProcessedAbnormalStatistics
            // 
            this.lblProcessedAbnormalStatistics.AutoSize = true;
            this.lblProcessedAbnormalStatistics.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProcessedAbnormalStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblProcessedAbnormalStatistics.Location = new System.Drawing.Point(60, 23);
            this.lblProcessedAbnormalStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.lblProcessedAbnormalStatistics.Name = "lblProcessedAbnormalStatistics";
            this.lblProcessedAbnormalStatistics.Size = new System.Drawing.Size(44, 48);
            this.lblProcessedAbnormalStatistics.TabIndex = 1;
            this.lblProcessedAbnormalStatistics.Text = "0";
            // 
            // picUntreatedAbnormal
            // 
            this.picUntreatedAbnormal.Controls.Add(this.lblUntreatedAbnormal);
            this.picUntreatedAbnormal.Controls.Add(this.lblUntreatedAbnormalStatistics);
            this.picUntreatedAbnormal.Location = new System.Drawing.Point(513, 0);
            this.picUntreatedAbnormal.Margin = new System.Windows.Forms.Padding(0);
            this.picUntreatedAbnormal.Name = "picUntreatedAbnormal";
            this.picUntreatedAbnormal.Size = new System.Drawing.Size(164, 130);
            this.picUntreatedAbnormal.TabIndex = 3;
            this.picUntreatedAbnormal.TabStop = false;
            // 
            // lblUntreatedAbnormal
            // 
            this.lblUntreatedAbnormal.AutoSize = true;
            this.lblUntreatedAbnormal.Location = new System.Drawing.Point(31, 85);
            this.lblUntreatedAbnormal.Name = "lblUntreatedAbnormal";
            this.lblUntreatedAbnormal.Size = new System.Drawing.Size(101, 12);
            this.lblUntreatedAbnormal.TabIndex = 2;
            this.lblUntreatedAbnormal.Text = "待处理异常卷份数";
            // 
            // lblUntreatedAbnormalStatistics
            // 
            this.lblUntreatedAbnormalStatistics.AutoSize = true;
            this.lblUntreatedAbnormalStatistics.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUntreatedAbnormalStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblUntreatedAbnormalStatistics.Location = new System.Drawing.Point(60, 23);
            this.lblUntreatedAbnormalStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.lblUntreatedAbnormalStatistics.Name = "lblUntreatedAbnormalStatistics";
            this.lblUntreatedAbnormalStatistics.Size = new System.Drawing.Size(44, 48);
            this.lblUntreatedAbnormalStatistics.TabIndex = 1;
            this.lblUntreatedAbnormalStatistics.Text = "0";
            // 
            // picLockNumber
            // 
            this.picLockNumber.Controls.Add(this.lblLockNumber);
            this.picLockNumber.Controls.Add(this.lblLockNumberStatistics);
            this.picLockNumber.Location = new System.Drawing.Point(171, 0);
            this.picLockNumber.Margin = new System.Windows.Forms.Padding(0);
            this.picLockNumber.Name = "picLockNumber";
            this.picLockNumber.Size = new System.Drawing.Size(164, 130);
            this.picLockNumber.TabIndex = 2;
            this.picLockNumber.TabStop = false;
            // 
            // lblLockNumber
            // 
            this.lblLockNumber.AutoSize = true;
            this.lblLockNumber.Location = new System.Drawing.Point(55, 85);
            this.lblLockNumber.Name = "lblLockNumber";
            this.lblLockNumber.Size = new System.Drawing.Size(53, 12);
            this.lblLockNumber.TabIndex = 2;
            this.lblLockNumber.Text = "缺考人数";
            // 
            // lblLockNumberStatistics
            // 
            this.lblLockNumberStatistics.AutoSize = true;
            this.lblLockNumberStatistics.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLockNumberStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblLockNumberStatistics.Location = new System.Drawing.Point(60, 23);
            this.lblLockNumberStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.lblLockNumberStatistics.Name = "lblLockNumberStatistics";
            this.lblLockNumberStatistics.Size = new System.Drawing.Size(44, 48);
            this.lblLockNumberStatistics.TabIndex = 1;
            this.lblLockNumberStatistics.Text = "0";
            // 
            // picScanned
            // 
            this.picScanned.Controls.Add(this.lblScanned);
            this.picScanned.Controls.Add(this.lblScannedStatistics);
            this.picScanned.Location = new System.Drawing.Point(342, 0);
            this.picScanned.Margin = new System.Windows.Forms.Padding(0);
            this.picScanned.Name = "picScanned";
            this.picScanned.Size = new System.Drawing.Size(164, 130);
            this.picScanned.TabIndex = 1;
            this.picScanned.TabStop = false;
            // 
            // lblScanned
            // 
            this.lblScanned.AutoSize = true;
            this.lblScanned.Location = new System.Drawing.Point(55, 85);
            this.lblScanned.Name = "lblScanned";
            this.lblScanned.Size = new System.Drawing.Size(53, 12);
            this.lblScanned.TabIndex = 2;
            this.lblScanned.Text = "已扫人数";
            // 
            // lblScannedStatistics
            // 
            this.lblScannedStatistics.AutoSize = true;
            this.lblScannedStatistics.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScannedStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblScannedStatistics.Location = new System.Drawing.Point(60, 23);
            this.lblScannedStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.lblScannedStatistics.Name = "lblScannedStatistics";
            this.lblScannedStatistics.Size = new System.Drawing.Size(44, 48);
            this.lblScannedStatistics.TabIndex = 1;
            this.lblScannedStatistics.Text = "0";
            // 
            // picWillnum
            // 
            this.picWillnum.Controls.Add(this.lblWillnumText);
            this.picWillnum.Controls.Add(this.lblWillnumStatistics);
            this.picWillnum.Location = new System.Drawing.Point(0, 0);
            this.picWillnum.Margin = new System.Windows.Forms.Padding(0);
            this.picWillnum.Name = "picWillnum";
            this.picWillnum.Size = new System.Drawing.Size(164, 130);
            this.picWillnum.TabIndex = 0;
            this.picWillnum.TabStop = false;
            // 
            // lblWillnumText
            // 
            this.lblWillnumText.AutoSize = true;
            this.lblWillnumText.Location = new System.Drawing.Point(55, 85);
            this.lblWillnumText.Name = "lblWillnumText";
            this.lblWillnumText.Size = new System.Drawing.Size(53, 12);
            this.lblWillnumText.TabIndex = 2;
            this.lblWillnumText.Text = "报名人数";
            // 
            // lblWillnumStatistics
            // 
            this.lblWillnumStatistics.AutoSize = true;
            this.lblWillnumStatistics.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWillnumStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblWillnumStatistics.Location = new System.Drawing.Point(60, 23);
            this.lblWillnumStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.lblWillnumStatistics.Name = "lblWillnumStatistics";
            this.lblWillnumStatistics.Size = new System.Drawing.Size(44, 48);
            this.lblWillnumStatistics.TabIndex = 1;
            this.lblWillnumStatistics.Text = "0";
            // 
            // panScanInfo
            // 
            this.panScanInfo.Controls.Add(this.lblDayCompletedNum);
            this.panScanInfo.Controls.Add(this.lblScanVelocityNum);
            this.panScanInfo.Controls.Add(this.lblDayCompleted);
            this.panScanInfo.Controls.Add(this.lblDayCompletedUnit);
            this.panScanInfo.Controls.Add(this.lblScanVelocity);
            this.panScanInfo.Controls.Add(this.lblScanVelocityUnit);
            this.panScanInfo.Location = new System.Drawing.Point(0, 72);
            this.panScanInfo.Name = "panScanInfo";
            this.panScanInfo.Size = new System.Drawing.Size(510, 40);
            this.panScanInfo.TabIndex = 0;
            // 
            // lblDayCompletedNum
            // 
            this.lblDayCompletedNum.AutoSize = true;
            this.lblDayCompletedNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDayCompletedNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblDayCompletedNum.Location = new System.Drawing.Point(87, 11);
            this.lblDayCompletedNum.Margin = new System.Windows.Forms.Padding(0);
            this.lblDayCompletedNum.Name = "lblDayCompletedNum";
            this.lblDayCompletedNum.Size = new System.Drawing.Size(20, 19);
            this.lblDayCompletedNum.TabIndex = 8;
            this.lblDayCompletedNum.Text = "0";
            this.lblDayCompletedNum.SizeChanged += new System.EventHandler(this.lblDayCompletedNum_SizeChanged);
            // 
            // lblScanVelocityNum
            // 
            this.lblScanVelocityNum.AutoSize = true;
            this.lblScanVelocityNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScanVelocityNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblScanVelocityNum.Location = new System.Drawing.Point(228, 11);
            this.lblScanVelocityNum.Margin = new System.Windows.Forms.Padding(0);
            this.lblScanVelocityNum.Name = "lblScanVelocityNum";
            this.lblScanVelocityNum.Size = new System.Drawing.Size(20, 19);
            this.lblScanVelocityNum.TabIndex = 7;
            this.lblScanVelocityNum.Text = "0";
            this.lblScanVelocityNum.SizeChanged += new System.EventHandler(this.lblScanVelocityNum_SizeChanged);
            // 
            // lblDayCompleted
            // 
            this.lblDayCompleted.AutoSize = true;
            this.lblDayCompleted.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDayCompleted.Location = new System.Drawing.Point(0, 12);
            this.lblDayCompleted.Margin = new System.Windows.Forms.Padding(0);
            this.lblDayCompleted.Name = "lblDayCompleted";
            this.lblDayCompleted.Size = new System.Drawing.Size(88, 16);
            this.lblDayCompleted.TabIndex = 6;
            this.lblDayCompleted.Text = "本日已完成";
            // 
            // lblDayCompletedUnit
            // 
            this.lblDayCompletedUnit.AutoSize = true;
            this.lblDayCompletedUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblDayCompletedUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDayCompletedUnit.Location = new System.Drawing.Point(113, 12);
            this.lblDayCompletedUnit.Margin = new System.Windows.Forms.Padding(0);
            this.lblDayCompletedUnit.Name = "lblDayCompletedUnit";
            this.lblDayCompletedUnit.Size = new System.Drawing.Size(24, 16);
            this.lblDayCompletedUnit.TabIndex = 5;
            this.lblDayCompletedUnit.Text = "份";
            // 
            // lblScanVelocity
            // 
            this.lblScanVelocity.AutoSize = true;
            this.lblScanVelocity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScanVelocity.Location = new System.Drawing.Point(162, 12);
            this.lblScanVelocity.Margin = new System.Windows.Forms.Padding(0);
            this.lblScanVelocity.Name = "lblScanVelocity";
            this.lblScanVelocity.Size = new System.Drawing.Size(72, 16);
            this.lblScanVelocity.TabIndex = 4;
            this.lblScanVelocity.Text = "扫描速度";
            // 
            // lblScanVelocityUnit
            // 
            this.lblScanVelocityUnit.AutoSize = true;
            this.lblScanVelocityUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScanVelocityUnit.Location = new System.Drawing.Point(258, 12);
            this.lblScanVelocityUnit.Margin = new System.Windows.Forms.Padding(0);
            this.lblScanVelocityUnit.Name = "lblScanVelocityUnit";
            this.lblScanVelocityUnit.Size = new System.Drawing.Size(64, 16);
            this.lblScanVelocityUnit.TabIndex = 3;
            this.lblScanVelocityUnit.Text = "张/分钟";
            // 
            // panBackupBar
            // 
            this.panBackupBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBackupBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panBackupBar.Controls.Add(this.lblBackExamList);
            this.panBackupBar.Location = new System.Drawing.Point(0, 0);
            this.panBackupBar.Margin = new System.Windows.Forms.Padding(0);
            this.panBackupBar.Name = "panBackupBar";
            this.panBackupBar.Size = new System.Drawing.Size(1020, 40);
            this.panBackupBar.TabIndex = 3;
            // 
            // lblBackExamList
            // 
            this.lblBackExamList.AutoSize = true;
            this.lblBackExamList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBackExamList.Image = global::YXH.Main.SubjectOperateFormRes.Back;
            this.lblBackExamList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackExamList.Location = new System.Drawing.Point(0, 12);
            this.lblBackExamList.Margin = new System.Windows.Forms.Padding(0);
            this.lblBackExamList.Name = "lblBackExamList";
            this.lblBackExamList.Size = new System.Drawing.Size(128, 16);
            this.lblBackExamList.TabIndex = 0;
            this.lblBackExamList.Text = "   返回考试列表";
            this.lblBackExamList.Click += new System.EventHandler(this.lblBackExamList_Click);
            this.lblBackExamList.MouseEnter += new System.EventHandler(this.lblBackExamList_MouseEnter);
            this.lblBackExamList.MouseLeave += new System.EventHandler(this.lblBackExamList_MouseLeave);
            // 
            // panExamTitleBar
            // 
            this.panExamTitleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panExamTitleBar.Controls.Add(this.lblExamInfo);
            this.panExamTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panExamTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.panExamTitleBar.Name = "panExamTitleBar";
            this.panExamTitleBar.Size = new System.Drawing.Size(1020, 102);
            this.panExamTitleBar.TabIndex = 4;
            // 
            // lblExamInfo
            // 
            this.lblExamInfo.AutoSize = true;
            this.lblExamInfo.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblExamInfo.Location = new System.Drawing.Point(0, 45);
            this.lblExamInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblExamInfo.Name = "lblExamInfo";
            this.lblExamInfo.Size = new System.Drawing.Size(0, 27);
            this.lblExamInfo.TabIndex = 0;
            // 
            // panExport
            // 
            this.panExport.BackColor = System.Drawing.Color.White;
            this.panExport.Controls.Add(this.btnCancel);
            this.panExport.Controls.Add(this.btnExport);
            this.panExport.Location = new System.Drawing.Point(0, 642);
            this.panExport.Name = "panExport";
            this.panExport.Size = new System.Drawing.Size(1020, 62);
            this.panExport.TabIndex = 5;
            this.panExport.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::YXH.Main.SubjectOperateFormRes.CancelButton_BackImage;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(522, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(157, 62);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImage = global::YXH.Main.SubjectOperateFormRes.ExportButton_BackImage;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(341, 0);
            this.btnExport.Margin = new System.Windows.Forms.Padding(0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(157, 62);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // panContent
            // 
            this.panContent.Controls.Add(this.panActionDetails);
            this.panContent.Controls.Add(this.panActive);
            this.panContent.Controls.Add(this.panExport);
            this.panContent.Controls.Add(this.panExamTitleBar);
            this.panContent.Location = new System.Drawing.Point(0, 40);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(1020, 704);
            this.panContent.TabIndex = 1;
            // 
            // SubjectOperateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1020, 744);
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.panBackupBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "SubjectOperateForm";
            this.Text = "SubjectOperateForm";
            this.Load += new System.EventHandler(this.SubjectOperateForm_Load);
            this.Shown += new System.EventHandler(this.SubjectOperateForm_Shown);
            this.Resize += new System.EventHandler(this.SubjectOperateForm_Resize);
            this.panActive.ResumeLayout(false);
            this.panActive.PerformLayout();
            this.btn_ContinueScan.ResumeLayout(false);
            this.btn_ContinueScan.PerformLayout();
            this.panActionDetails.ResumeLayout(false);
            this.panActionDetails.PerformLayout();
            this.panActionResutl.ResumeLayout(false);
            this.panActionResutl.PerformLayout();
            this.panel_footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExaminationNumberAbnormal)).EndInit();
            this.picExaminationNumberAbnormal.ResumeLayout(false);
            this.picExaminationNumberAbnormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessedAbnormal)).EndInit();
            this.picProcessedAbnormal.ResumeLayout(false);
            this.picProcessedAbnormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUntreatedAbnormal)).EndInit();
            this.picUntreatedAbnormal.ResumeLayout(false);
            this.picUntreatedAbnormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLockNumber)).EndInit();
            this.picLockNumber.ResumeLayout(false);
            this.picLockNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScanned)).EndInit();
            this.picScanned.ResumeLayout(false);
            this.picScanned.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWillnum)).EndInit();
            this.picWillnum.ResumeLayout(false);
            this.picWillnum.PerformLayout();
            this.panScanInfo.ResumeLayout(false);
            this.panScanInfo.PerformLayout();
            this.panBackupBar.ResumeLayout(false);
            this.panBackupBar.PerformLayout();
            this.panExamTitleBar.ResumeLayout(false);
            this.panExamTitleBar.PerformLayout();
            this.panExport.ResumeLayout(false);
            this.panContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panActive;
        private System.Windows.Forms.Panel panActionDetails;
        private System.Windows.Forms.Panel panel_footer;
        private System.Windows.Forms.Button btn_ContinueScan;
        private System.Windows.Forms.Button btn_UploadMaterial;
        private System.Windows.Forms.Button btn_NewTemplate;
        private System.Windows.Forms.Button btn_checkTemplate;
        private Panel panBackupBar;
        private Label lblBackExamList;
        private Panel panExamTitleBar;
        private Label lblExamInfo;
        private Label lblContinueScanBtnText;
        private Panel panActionResutl;
        private Button btnViewLog;
        private Button btnScanRecordSaveDir;
        private Button btnImageSaveDir;
        private Button btnBatchExport;
        private Label lblActionDetails;
        private Panel panScanInfo;
        private Label lblDayCompletedNum;
        private Label lblScanVelocityNum;
        private Label lblDayCompleted;
        private Label lblDayCompletedUnit;
        private Label lblScanVelocity;
        private Label lblScanVelocityUnit;
        private Label lblWillnumText;
        private Label lblWillnumStatistics;
        private PictureBox picWillnum;
        private PictureBox picProcessedAbnormal;
        private Label lblProcessedAbnormal;
        private Label lblProcessedAbnormalStatistics;
        private PictureBox picUntreatedAbnormal;
        private Label lblUntreatedAbnormal;
        private Label lblUntreatedAbnormalStatistics;
        private PictureBox picLockNumber;
        private Label lblLockNumber;
        private Label lblLockNumberStatistics;
        private PictureBox picScanned;
        private Label lblScanned;
        private Label lblScannedStatistics;
        private Panel panExport;
        private Button btnCancel;
        private Button btnExport;
        private Panel panContent;
        private PictureBox picExaminationNumberAbnormal;
        private Label lblExaminationNumberAbnormal;
        private Label ExaminationNumberAbnormalCount;
    }
}