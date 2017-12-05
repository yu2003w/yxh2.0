using System.Drawing;
using System.Windows.Forms;
namespace YXH.TemplateForm
{
    partial class ScannerSettingForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelScan = new System.Windows.Forms.Panel();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.btnAdvancedSetting = new System.Windows.Forms.Button();
            this.panComposeType = new System.Windows.Forms.Panel();
            this.lblComposingTitle = new System.Windows.Forms.Label();
            this.lblVertical = new System.Windows.Forms.Label();
            this.lblHorizontal = new System.Windows.Forms.Label();
            this.lblBracket = new System.Windows.Forms.Label();
            this.lblBox = new System.Windows.Forms.Label();
            this.lblDoubleSide = new System.Windows.Forms.Label();
            this.lblDoubleSideTitle = new System.Windows.Forms.Label();
            this.lblBlobPaintTypeTitle = new System.Windows.Forms.Label();
            this.lblSelectPaper = new System.Windows.Forms.Label();
            this.flpPaperType = new System.Windows.Forms.FlowLayoutPanel();
            this.A3 = new System.Windows.Forms.Button();
            this.A4 = new System.Windows.Forms.Button();
            this.B4 = new System.Windows.Forms.Button();
            this.B5 = new System.Windows.Forms.Button();
            this.btn_selfDefine = new System.Windows.Forms.Button();
            this.flpAnswerSheetSource = new System.Windows.Forms.Panel();
            this.lblDeviceSource = new System.Windows.Forms.Label();
            this.lblAnswerSheetSource = new System.Windows.Forms.Label();
            this.lblScanner = new System.Windows.Forms.Label();
            this.panelFile = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lblDeviceSourceText = new System.Windows.Forms.Label();
            this.fromFile = new YXH.TemplateForm.RoundRectButton();
            this.panelScan.SuspendLayout();
            this.panComposeType.SuspendLayout();
            this.flpPaperType.SuspendLayout();
            this.flpAnswerSheetSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "图像|*.png";
            this.openFileDialog.Multiselect = true;
            // 
            // panelScan
            // 
            this.panelScan.Controls.Add(this.btnStartScan);
            this.panelScan.Controls.Add(this.btnAdvancedSetting);
            this.panelScan.Controls.Add(this.panComposeType);
            this.panelScan.Controls.Add(this.lblBracket);
            this.panelScan.Controls.Add(this.lblBox);
            this.panelScan.Controls.Add(this.lblDoubleSide);
            this.panelScan.Controls.Add(this.lblDoubleSideTitle);
            this.panelScan.Controls.Add(this.lblBlobPaintTypeTitle);
            this.panelScan.Controls.Add(this.lblSelectPaper);
            this.panelScan.Controls.Add(this.flpPaperType);
            this.panelScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScan.Location = new System.Drawing.Point(0, 0);
            this.panelScan.Name = "panelScan";
            this.panelScan.Size = new System.Drawing.Size(830, 418);
            this.panelScan.TabIndex = 4;
            // 
            // btnStartScan
            // 
            this.btnStartScan.AutoSize = true;
            this.btnStartScan.BackgroundImage = global::YXH.TemplateForm.CommonRes.OKButton_BackImage;
            this.btnStartScan.FlatAppearance.BorderSize = 0;
            this.btnStartScan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnStartScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartScan.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartScan.ForeColor = System.Drawing.Color.White;
            this.btnStartScan.Location = new System.Drawing.Point(30, 262);
            this.btnStartScan.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(157, 62);
            this.btnStartScan.TabIndex = 19;
            this.btnStartScan.Text = "开始扫描";
            this.btnStartScan.UseVisualStyleBackColor = true;
            this.btnStartScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnAdvancedSetting
            // 
            this.btnAdvancedSetting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdvancedSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAdvancedSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvancedSetting.Location = new System.Drawing.Point(704, 192);
            this.btnAdvancedSetting.Name = "btnAdvancedSetting";
            this.btnAdvancedSetting.Size = new System.Drawing.Size(78, 30);
            this.btnAdvancedSetting.TabIndex = 18;
            this.btnAdvancedSetting.Text = "高级设置";
            this.btnAdvancedSetting.UseVisualStyleBackColor = false;
            this.btnAdvancedSetting.Click += new System.EventHandler(this.btnAdvancedSetting_Click);
            // 
            // panComposeType
            // 
            this.panComposeType.Controls.Add(this.lblComposingTitle);
            this.panComposeType.Controls.Add(this.lblVertical);
            this.panComposeType.Controls.Add(this.lblHorizontal);
            this.panComposeType.Location = new System.Drawing.Point(30, 209);
            this.panComposeType.Margin = new System.Windows.Forms.Padding(0);
            this.panComposeType.Name = "panComposeType";
            this.panComposeType.Size = new System.Drawing.Size(340, 13);
            this.panComposeType.TabIndex = 17;
            // 
            // lblComposingTitle
            // 
            this.lblComposingTitle.AutoSize = true;
            this.lblComposingTitle.Location = new System.Drawing.Point(0, 0);
            this.lblComposingTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblComposingTitle.Name = "lblComposingTitle";
            this.lblComposingTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblComposingTitle.Size = new System.Drawing.Size(77, 12);
            this.lblComposingTitle.TabIndex = 9;
            this.lblComposingTitle.Text = "答题卡排版：";
            this.lblComposingTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVertical
            // 
            this.lblVertical.AutoSize = true;
            this.lblVertical.Image = global::YXH.TemplateForm.ScannerSettingFormRes.CheckBox_Selected;
            this.lblVertical.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVertical.Location = new System.Drawing.Point(230, 0);
            this.lblVertical.Margin = new System.Windows.Forms.Padding(0);
            this.lblVertical.Name = "lblVertical";
            this.lblVertical.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVertical.Size = new System.Drawing.Size(95, 12);
            this.lblVertical.TabIndex = 16;
            this.lblVertical.Text = "   竖排(A4样式)";
            this.lblVertical.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblVertical.Click += new System.EventHandler(this.ComposeType_Click);
            // 
            // lblHorizontal
            // 
            this.lblHorizontal.AutoSize = true;
            this.lblHorizontal.Image = global::YXH.TemplateForm.ScannerSettingFormRes.CheckBox_Normal;
            this.lblHorizontal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHorizontal.Location = new System.Drawing.Point(95, 0);
            this.lblHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.lblHorizontal.Name = "lblHorizontal";
            this.lblHorizontal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblHorizontal.Size = new System.Drawing.Size(95, 12);
            this.lblHorizontal.TabIndex = 15;
            this.lblHorizontal.Text = "   横排(A3样式)";
            this.lblHorizontal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblHorizontal.Click += new System.EventHandler(this.ComposeType_Click);
            // 
            // lblBracket
            // 
            this.lblBracket.AutoSize = true;
            this.lblBracket.Image = global::YXH.TemplateForm.ScannerSettingFormRes.CheckBox_Selected;
            this.lblBracket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBracket.Location = new System.Drawing.Point(236, 167);
            this.lblBracket.Margin = new System.Windows.Forms.Padding(0);
            this.lblBracket.Name = "lblBracket";
            this.lblBracket.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBracket.Size = new System.Drawing.Size(71, 12);
            this.lblBracket.TabIndex = 14;
            this.lblBracket.Text = "   中括号框";
            this.lblBracket.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblBracket.Click += new System.EventHandler(this.BlogType_Click);
            // 
            // lblBox
            // 
            this.lblBox.AutoSize = true;
            this.lblBox.Image = global::YXH.TemplateForm.ScannerSettingFormRes.CheckBox_Normal;
            this.lblBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBox.Location = new System.Drawing.Point(149, 167);
            this.lblBox.Margin = new System.Windows.Forms.Padding(0);
            this.lblBox.Name = "lblBox";
            this.lblBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBox.Size = new System.Drawing.Size(47, 12);
            this.lblBox.TabIndex = 13;
            this.lblBox.Text = "   方框";
            this.lblBox.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblBox.Click += new System.EventHandler(this.BlogType_Click);
            // 
            // lblDoubleSide
            // 
            this.lblDoubleSide.AutoSize = true;
            this.lblDoubleSide.Image = global::YXH.TemplateForm.ScannerSettingFormRes.CheckBox_Normal;
            this.lblDoubleSide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDoubleSide.Location = new System.Drawing.Point(113, 125);
            this.lblDoubleSide.Margin = new System.Windows.Forms.Padding(0);
            this.lblDoubleSide.Name = "lblDoubleSide";
            this.lblDoubleSide.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDoubleSide.Size = new System.Drawing.Size(83, 12);
            this.lblDoubleSide.TabIndex = 12;
            this.lblDoubleSide.Text = "   双面答题卡";
            this.lblDoubleSide.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDoubleSide.Click += new System.EventHandler(this.lblDoubleSide_Click);
            // 
            // lblDoubleSideTitle
            // 
            this.lblDoubleSideTitle.AutoSize = true;
            this.lblDoubleSideTitle.Location = new System.Drawing.Point(30, 125);
            this.lblDoubleSideTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblDoubleSideTitle.Name = "lblDoubleSideTitle";
            this.lblDoubleSideTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDoubleSideTitle.Size = new System.Drawing.Size(65, 12);
            this.lblDoubleSideTitle.TabIndex = 11;
            this.lblDoubleSideTitle.Text = "扫描类型：";
            this.lblDoubleSideTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBlobPaintTypeTitle
            // 
            this.lblBlobPaintTypeTitle.AutoSize = true;
            this.lblBlobPaintTypeTitle.Location = new System.Drawing.Point(30, 167);
            this.lblBlobPaintTypeTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlobPaintTypeTitle.Name = "lblBlobPaintTypeTitle";
            this.lblBlobPaintTypeTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBlobPaintTypeTitle.Size = new System.Drawing.Size(101, 12);
            this.lblBlobPaintTypeTitle.TabIndex = 10;
            this.lblBlobPaintTypeTitle.Text = "答题卡填涂类型：";
            this.lblBlobPaintTypeTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSelectPaper
            // 
            this.lblSelectPaper.AutoSize = true;
            this.lblSelectPaper.Location = new System.Drawing.Point(30, 5);
            this.lblSelectPaper.Margin = new System.Windows.Forms.Padding(0);
            this.lblSelectPaper.Name = "lblSelectPaper";
            this.lblSelectPaper.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSelectPaper.Size = new System.Drawing.Size(65, 12);
            this.lblSelectPaper.TabIndex = 1;
            this.lblSelectPaper.Text = "选择纸张：";
            this.lblSelectPaper.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // flpPaperType
            // 
            this.flpPaperType.Controls.Add(this.A3);
            this.flpPaperType.Controls.Add(this.A4);
            this.flpPaperType.Controls.Add(this.B4);
            this.flpPaperType.Controls.Add(this.B5);
            this.flpPaperType.Controls.Add(this.btn_selfDefine);
            this.flpPaperType.Location = new System.Drawing.Point(109, 5);
            this.flpPaperType.Margin = new System.Windows.Forms.Padding(0);
            this.flpPaperType.Name = "flpPaperType";
            this.flpPaperType.Size = new System.Drawing.Size(712, 80);
            this.flpPaperType.TabIndex = 6;
            // 
            // A3
            // 
            this.A3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.A3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.A3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.A3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.A3.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.A3.Location = new System.Drawing.Point(0, 0);
            this.A3.Margin = new System.Windows.Forms.Padding(0);
            this.A3.Name = "A3";
            this.A3.Size = new System.Drawing.Size(120, 80);
            this.A3.TabIndex = 0;
            this.A3.Text = "A3";
            this.A3.UseVisualStyleBackColor = false;
            this.A3.Click += new System.EventHandler(this.A3_Click);
            this.A3.MouseEnter += new System.EventHandler(this.SelectPaper_MouseEnter);
            this.A3.MouseLeave += new System.EventHandler(this.SelectPaper_MouseLeave);
            // 
            // A4
            // 
            this.A4.BackColor = System.Drawing.Color.White;
            this.A4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.A4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.A4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.A4.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.A4.Location = new System.Drawing.Point(138, 0);
            this.A4.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.A4.Name = "A4";
            this.A4.Size = new System.Drawing.Size(120, 80);
            this.A4.TabIndex = 1;
            this.A4.Text = "A4";
            this.A4.UseVisualStyleBackColor = false;
            this.A4.Click += new System.EventHandler(this.A4_Click);
            this.A4.MouseEnter += new System.EventHandler(this.SelectPaper_MouseEnter);
            this.A4.MouseLeave += new System.EventHandler(this.SelectPaper_MouseLeave);
            // 
            // B4
            // 
            this.B4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.B4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.B4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B4.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.B4.Location = new System.Drawing.Point(276, 0);
            this.B4.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.B4.Name = "B4";
            this.B4.Size = new System.Drawing.Size(120, 80);
            this.B4.TabIndex = 5;
            this.B4.Text = "B4";
            this.B4.UseVisualStyleBackColor = true;
            this.B4.Click += new System.EventHandler(this.B4_Click);
            this.B4.MouseEnter += new System.EventHandler(this.SelectPaper_MouseEnter);
            this.B4.MouseLeave += new System.EventHandler(this.SelectPaper_MouseLeave);
            // 
            // B5
            // 
            this.B5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.B5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.B5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B5.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.B5.Location = new System.Drawing.Point(414, 0);
            this.B5.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.B5.Name = "B5";
            this.B5.Size = new System.Drawing.Size(120, 80);
            this.B5.TabIndex = 2;
            this.B5.Text = "B5";
            this.B5.UseVisualStyleBackColor = true;
            this.B5.Click += new System.EventHandler(this.B5_Click);
            this.B5.MouseEnter += new System.EventHandler(this.SelectPaper_MouseEnter);
            this.B5.MouseLeave += new System.EventHandler(this.SelectPaper_MouseLeave);
            // 
            // btn_selfDefine
            // 
            this.btn_selfDefine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_selfDefine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_selfDefine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selfDefine.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selfDefine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.btn_selfDefine.Location = new System.Drawing.Point(552, 0);
            this.btn_selfDefine.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btn_selfDefine.Name = "btn_selfDefine";
            this.btn_selfDefine.Size = new System.Drawing.Size(120, 80);
            this.btn_selfDefine.TabIndex = 6;
            this.btn_selfDefine.Text = "自定义";
            this.btn_selfDefine.UseVisualStyleBackColor = true;
            this.btn_selfDefine.Click += new System.EventHandler(this.btn_selfDefine_Click);
            this.btn_selfDefine.MouseEnter += new System.EventHandler(this.SelectPaper_MouseEnter);
            this.btn_selfDefine.MouseLeave += new System.EventHandler(this.SelectPaper_MouseLeave);
            // 
            // flpAnswerSheetSource
            // 
            this.flpAnswerSheetSource.Controls.Add(this.lblDeviceSourceText);
            this.flpAnswerSheetSource.Controls.Add(this.lblDeviceSource);
            this.flpAnswerSheetSource.Controls.Add(this.lblAnswerSheetSource);
            this.flpAnswerSheetSource.Controls.Add(this.lblScanner);
            this.flpAnswerSheetSource.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpAnswerSheetSource.Location = new System.Drawing.Point(0, 0);
            this.flpAnswerSheetSource.Name = "flpAnswerSheetSource";
            this.flpAnswerSheetSource.Size = new System.Drawing.Size(830, 80);
            this.flpAnswerSheetSource.TabIndex = 0;
            // 
            // lblDeviceSource
            // 
            this.lblDeviceSource.AutoSize = true;
            this.lblDeviceSource.Location = new System.Drawing.Point(30, 51);
            this.lblDeviceSource.Margin = new System.Windows.Forms.Padding(0);
            this.lblDeviceSource.Name = "lblDeviceSource";
            this.lblDeviceSource.Size = new System.Drawing.Size(77, 12);
            this.lblDeviceSource.TabIndex = 8;
            this.lblDeviceSource.Text = "当前扫描源：";
            this.lblDeviceSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAnswerSheetSource
            // 
            this.lblAnswerSheetSource.AutoSize = true;
            this.lblAnswerSheetSource.Location = new System.Drawing.Point(30, 11);
            this.lblAnswerSheetSource.Margin = new System.Windows.Forms.Padding(0);
            this.lblAnswerSheetSource.Name = "lblAnswerSheetSource";
            this.lblAnswerSheetSource.Size = new System.Drawing.Size(77, 12);
            this.lblAnswerSheetSource.TabIndex = 7;
            this.lblAnswerSheetSource.Text = "答题卡来源：";
            this.lblAnswerSheetSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScanner
            // 
            this.lblScanner.AutoSize = true;
            this.lblScanner.Image = global::YXH.TemplateForm.ScannerSettingFormRes.CheckBox_Selected;
            this.lblScanner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScanner.Location = new System.Drawing.Point(109, 11);
            this.lblScanner.Name = "lblScanner";
            this.lblScanner.Size = new System.Drawing.Size(83, 12);
            this.lblScanner.TabIndex = 10;
            this.lblScanner.Text = "   通过扫描仪";
            // 
            // panelFile
            // 
            this.panelFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFile.Location = new System.Drawing.Point(0, 0);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(830, 418);
            this.panelFile.TabIndex = 5;
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 15);
            this.scMain.Margin = new System.Windows.Forms.Padding(0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.flpAnswerSheetSource);
            this.scMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.panelScan);
            this.scMain.Panel2.Controls.Add(this.panelFile);
            this.scMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scMain.Size = new System.Drawing.Size(830, 502);
            this.scMain.SplitterDistance = 80;
            this.scMain.TabIndex = 8;
            // 
            // lblDeviceSourceText
            // 
            this.lblDeviceSourceText.AutoSize = true;
            this.lblDeviceSourceText.Location = new System.Drawing.Point(109, 51);
            this.lblDeviceSourceText.Name = "lblDeviceSourceText";
            this.lblDeviceSourceText.Size = new System.Drawing.Size(0, 12);
            this.lblDeviceSourceText.TabIndex = 11;
            // 
            // fromFile
            // 
            this.fromFile.BackColor = System.Drawing.SystemColors.Control;
            this.fromFile.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.fromFile.FlatAppearance.BorderSize = 0;
            this.fromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fromFile.Location = new System.Drawing.Point(159, 49);
            this.fromFile.Name = "fromFile";
            this.fromFile.Size = new System.Drawing.Size(102, 41);
            this.fromFile.TabIndex = 3;
            this.fromFile.Text = "选取...";
            this.fromFile.UseVisualStyleBackColor = false;
            this.fromFile.Click += new System.EventHandler(this.fromFile_Click);
            // 
            // ScannerSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(830, 517);
            this.Controls.Add(this.scMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScannerSettingForm";
            this.Text = "扫描设置";
            this.Load += new System.EventHandler(this.ScannerSettingForm_Load);
            this.panelScan.ResumeLayout(false);
            this.panelScan.PerformLayout();
            this.panComposeType.ResumeLayout(false);
            this.panComposeType.PerformLayout();
            this.flpPaperType.ResumeLayout(false);
            this.flpAnswerSheetSource.ResumeLayout(false);
            this.flpAnswerSheetSource.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;

        private System.Windows.Forms.Panel panelScan;
        private System.Windows.Forms.Panel panelFile;
        private System.Windows.Forms.Label lblAnswerSheetSource;
        private System.Windows.Forms.Label lblSelectPaper;
        private System.Windows.Forms.Label lblDeviceSource;
        private System.Windows.Forms.FlowLayoutPanel flpPaperType;
        private System.Windows.Forms.Panel flpAnswerSheetSource;
        private System.Windows.Forms.Button A3;
        private System.Windows.Forms.Button btn_selfDefine;
        private System.Windows.Forms.Button A4;
        private System.Windows.Forms.Button B5;
        private System.Windows.Forms.Button B4;
        private System.Windows.Forms.SplitContainer scMain;
        private RoundRectButton fromFile;
        private Label lblScanner;
        private Label lblVertical;
        private Label lblHorizontal;
        private Label lblBracket;
        private Label lblBox;
        private Label lblDoubleSide;
        private Label lblDoubleSideTitle;
        private Label lblBlobPaintTypeTitle;
        private Label lblComposingTitle;
        private Button btnAdvancedSetting;
        private Panel panComposeType;
        private Button btnStartScan;
        private Label lblDeviceSourceText;
    }
}