using System;
using System.Drawing;
using System.Windows.Forms;
using YXH.Common.Form;
namespace YXH.ScanForm
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
            this.flpPaperType = new System.Windows.Forms.FlowLayoutPanel();
            this.A3 = new System.Windows.Forms.Button();
            this.A4 = new System.Windows.Forms.Button();
            this.B4 = new System.Windows.Forms.Button();
            this.B5 = new System.Windows.Forms.Button();
            this.btn_selfDefine = new System.Windows.Forms.Button();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panCurScanSource = new System.Windows.Forms.Panel();
            this.lblScanner = new System.Windows.Forms.Label();
            this.lblFileSource = new System.Windows.Forms.Label();
            this.panScanSourceType = new System.Windows.Forms.Panel();
            this.btnAdvancedSetting = new System.Windows.Forms.Button();
            this.lblDeviceSource = new System.Windows.Forms.Label();
            this.lblDeviceSourceText = new System.Windows.Forms.Label();
            this.panPaperType = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panScanType = new System.Windows.Forms.Panel();
            this.lblChoosePaper = new System.Windows.Forms.Label();
            this.lblScanType = new System.Windows.Forms.Label();
            this.panTypeSetting = new System.Windows.Forms.Panel();
            this.lblVertical = new System.Windows.Forms.Label();
            this.lblHorizontal = new System.Windows.Forms.Label();
            this.lblTypeSetting = new System.Windows.Forms.Label();
            this.panTemplateInfo = new System.Windows.Forms.Panel();
            this.lbl_ImgNum = new System.Windows.Forms.Label();
            this.lblTemplateInfo = new System.Windows.Forms.Label();
            this.lbl_ImgeMode = new System.Windows.Forms.Label();
            this.lbl_PageSize = new System.Windows.Forms.Label();
            this.lbl_IsDoubleSize = new System.Windows.Forms.Label();
            this.lbl_ImgSize = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.flpPaperType.SuspendLayout();
            this.flpMain.SuspendLayout();
            this.panCurScanSource.SuspendLayout();
            this.panScanSourceType.SuspendLayout();
            this.panPaperType.SuspendLayout();
            this.panScanType.SuspendLayout();
            this.panTypeSetting.SuspendLayout();
            this.panTemplateInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpPaperType
            // 
            this.flpPaperType.Controls.Add(this.A3);
            this.flpPaperType.Controls.Add(this.A4);
            this.flpPaperType.Controls.Add(this.B4);
            this.flpPaperType.Controls.Add(this.B5);
            this.flpPaperType.Controls.Add(this.btn_selfDefine);
            this.flpPaperType.Enabled = false;
            this.flpPaperType.Location = new System.Drawing.Point(91, 0);
            this.flpPaperType.Margin = new System.Windows.Forms.Padding(0);
            this.flpPaperType.Name = "flpPaperType";
            this.flpPaperType.Size = new System.Drawing.Size(631, 80);
            this.flpPaperType.TabIndex = 6;
            // 
            // A3
            // 
            this.A3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.A3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A3.Location = new System.Drawing.Point(0, 0);
            this.A3.Margin = new System.Windows.Forms.Padding(0);
            this.A3.Name = "A3";
            this.A3.Size = new System.Drawing.Size(120, 80);
            this.A3.TabIndex = 0;
            this.A3.TabStop = false;
            this.A3.Text = "A3";
            this.A3.UseVisualStyleBackColor = true;
            this.A3.Click += new System.EventHandler(this.A3_Click);
            // 
            // A4
            // 
            this.A4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.A4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4.Location = new System.Drawing.Point(123, 0);
            this.A4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.A4.Name = "A4";
            this.A4.Size = new System.Drawing.Size(120, 80);
            this.A4.TabIndex = 1;
            this.A4.TabStop = false;
            this.A4.Text = "A4";
            this.A4.UseVisualStyleBackColor = true;
            this.A4.Click += new System.EventHandler(this.A4_Click);
            // 
            // B4
            // 
            this.B4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B4.Location = new System.Drawing.Point(246, 0);
            this.B4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.B4.Name = "B4";
            this.B4.Size = new System.Drawing.Size(120, 80);
            this.B4.TabIndex = 5;
            this.B4.TabStop = false;
            this.B4.Text = "B4";
            this.B4.UseVisualStyleBackColor = true;
            this.B4.Click += new System.EventHandler(this.B4_Click);
            // 
            // B5
            // 
            this.B5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B5.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B5.Location = new System.Drawing.Point(369, 0);
            this.B5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.B5.Name = "B5";
            this.B5.Size = new System.Drawing.Size(120, 80);
            this.B5.TabIndex = 2;
            this.B5.TabStop = false;
            this.B5.Text = "B5";
            this.B5.UseVisualStyleBackColor = true;
            this.B5.Click += new System.EventHandler(this.B5_Click);
            // 
            // btn_selfDefine
            // 
            this.btn_selfDefine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selfDefine.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selfDefine.Location = new System.Drawing.Point(492, 0);
            this.btn_selfDefine.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btn_selfDefine.Name = "btn_selfDefine";
            this.btn_selfDefine.Size = new System.Drawing.Size(120, 80);
            this.btn_selfDefine.TabIndex = 7;
            this.btn_selfDefine.Text = "自定义";
            this.btn_selfDefine.UseVisualStyleBackColor = true;
            this.btn_selfDefine.Click += new System.EventHandler(this.btn_selfDefine_Click);
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.Controls.Add(this.panCurScanSource);
            this.flpMain.Controls.Add(this.panScanSourceType);
            this.flpMain.Controls.Add(this.panPaperType);
            this.flpMain.Controls.Add(this.panScanType);
            this.flpMain.Controls.Add(this.panTypeSetting);
            this.flpMain.Controls.Add(this.panTemplateInfo);
            this.flpMain.Controls.Add(this.btnScan);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMain.Location = new System.Drawing.Point(0, 0);
            this.flpMain.Margin = new System.Windows.Forms.Padding(0);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(784, 521);
            this.flpMain.TabIndex = 12;
            // 
            // panCurScanSource
            // 
            this.panCurScanSource.Controls.Add(this.lblScanner);
            this.panCurScanSource.Controls.Add(this.lblFileSource);
            this.panCurScanSource.Location = new System.Drawing.Point(30, 40);
            this.panCurScanSource.Margin = new System.Windows.Forms.Padding(30, 40, 0, 0);
            this.panCurScanSource.Name = "panCurScanSource";
            this.panCurScanSource.Size = new System.Drawing.Size(723, 12);
            this.panCurScanSource.TabIndex = 19;
            // 
            // lblScanner
            // 
            this.lblScanner.AutoSize = true;
            this.lblScanner.Image = global::YXH.ScanForm.ScannerSettingFormRes.CheckBox_Selected;
            this.lblScanner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScanner.Location = new System.Drawing.Point(91, 0);
            this.lblScanner.Name = "lblScanner";
            this.lblScanner.Size = new System.Drawing.Size(59, 12);
            this.lblScanner.TabIndex = 17;
            this.lblScanner.Text = "   扫描仪";
            // 
            // lblFileSource
            // 
            this.lblFileSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileSource.AutoSize = true;
            this.lblFileSource.Location = new System.Drawing.Point(0, 0);
            this.lblFileSource.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileSource.Name = "lblFileSource";
            this.lblFileSource.Size = new System.Drawing.Size(89, 12);
            this.lblFileSource.TabIndex = 16;
            this.lblFileSource.Text = "当前扫描来源：";
            this.lblFileSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panScanSourceType
            // 
            this.panScanSourceType.Controls.Add(this.btnAdvancedSetting);
            this.panScanSourceType.Controls.Add(this.lblDeviceSource);
            this.panScanSourceType.Controls.Add(this.lblDeviceSourceText);
            this.panScanSourceType.Location = new System.Drawing.Point(30, 73);
            this.panScanSourceType.Margin = new System.Windows.Forms.Padding(30, 21, 0, 0);
            this.panScanSourceType.Name = "panScanSourceType";
            this.panScanSourceType.Size = new System.Drawing.Size(723, 30);
            this.panScanSourceType.TabIndex = 20;
            // 
            // btnAdvancedSetting
            // 
            this.btnAdvancedSetting.Location = new System.Drawing.Point(623, 0);
            this.btnAdvancedSetting.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdvancedSetting.Name = "btnAdvancedSetting";
            this.btnAdvancedSetting.Size = new System.Drawing.Size(80, 30);
            this.btnAdvancedSetting.TabIndex = 11;
            this.btnAdvancedSetting.Text = "高级设置";
            this.btnAdvancedSetting.UseVisualStyleBackColor = true;
            this.btnAdvancedSetting.Click += new System.EventHandler(this.linklbl_AdvancedSetting_LinkClicked);
            // 
            // lblDeviceSource
            // 
            this.lblDeviceSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeviceSource.AutoSize = true;
            this.lblDeviceSource.Location = new System.Drawing.Point(0, 9);
            this.lblDeviceSource.Margin = new System.Windows.Forms.Padding(55, 0, 3, 0);
            this.lblDeviceSource.Name = "lblDeviceSource";
            this.lblDeviceSource.Size = new System.Drawing.Size(77, 12);
            this.lblDeviceSource.TabIndex = 10;
            this.lblDeviceSource.Text = "扫描源型号：";
            this.lblDeviceSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeviceSourceText
            // 
            this.lblDeviceSourceText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeviceSourceText.AutoSize = true;
            this.lblDeviceSourceText.Location = new System.Drawing.Point(91, 9);
            this.lblDeviceSourceText.Margin = new System.Windows.Forms.Padding(55, 0, 3, 0);
            this.lblDeviceSourceText.Name = "lblDeviceSourceText";
            this.lblDeviceSourceText.Size = new System.Drawing.Size(0, 12);
            this.lblDeviceSourceText.TabIndex = 18;
            this.lblDeviceSourceText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panPaperType
            // 
            this.panPaperType.Controls.Add(this.label1);
            this.panPaperType.Controls.Add(this.flpPaperType);
            this.panPaperType.Location = new System.Drawing.Point(30, 133);
            this.panPaperType.Margin = new System.Windows.Forms.Padding(30, 30, 0, 0);
            this.panPaperType.Name = "panPaperType";
            this.panPaperType.Size = new System.Drawing.Size(723, 80);
            this.panPaperType.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "待扫描纸张：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panScanType
            // 
            this.panScanType.Controls.Add(this.lblChoosePaper);
            this.panScanType.Controls.Add(this.lblScanType);
            this.panScanType.Location = new System.Drawing.Point(30, 243);
            this.panScanType.Margin = new System.Windows.Forms.Padding(30, 30, 0, 0);
            this.panScanType.Name = "panScanType";
            this.panScanType.Size = new System.Drawing.Size(723, 16);
            this.panScanType.TabIndex = 21;
            // 
            // lblChoosePaper
            // 
            this.lblChoosePaper.AutoSize = true;
            this.lblChoosePaper.Image = global::YXH.ScanForm.ScannerSettingFormRes.CheckBox_Selected_Enable;
            this.lblChoosePaper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChoosePaper.Location = new System.Drawing.Point(91, 0);
            this.lblChoosePaper.Margin = new System.Windows.Forms.Padding(0);
            this.lblChoosePaper.Name = "lblChoosePaper";
            this.lblChoosePaper.Size = new System.Drawing.Size(83, 12);
            this.lblChoosePaper.TabIndex = 18;
            this.lblChoosePaper.Text = "   双面答题卡";
            // 
            // lblScanType
            // 
            this.lblScanType.AutoSize = true;
            this.lblScanType.Location = new System.Drawing.Point(0, 0);
            this.lblScanType.Margin = new System.Windows.Forms.Padding(0);
            this.lblScanType.Name = "lblScanType";
            this.lblScanType.Size = new System.Drawing.Size(65, 12);
            this.lblScanType.TabIndex = 17;
            this.lblScanType.Text = "扫描类型：";
            this.lblScanType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panTypeSetting
            // 
            this.panTypeSetting.Controls.Add(this.lblVertical);
            this.panTypeSetting.Controls.Add(this.lblHorizontal);
            this.panTypeSetting.Controls.Add(this.lblTypeSetting);
            this.panTypeSetting.Location = new System.Drawing.Point(30, 289);
            this.panTypeSetting.Margin = new System.Windows.Forms.Padding(30, 30, 0, 0);
            this.panTypeSetting.Name = "panTypeSetting";
            this.panTypeSetting.Size = new System.Drawing.Size(723, 16);
            this.panTypeSetting.TabIndex = 24;
            // 
            // lblVertical
            // 
            this.lblVertical.AutoSize = true;
            this.lblVertical.Image = global::YXH.ScanForm.ScannerSettingFormRes.CheckBox_Normal;
            this.lblVertical.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVertical.Location = new System.Drawing.Point(200, 0);
            this.lblVertical.Name = "lblVertical";
            this.lblVertical.Size = new System.Drawing.Size(101, 12);
            this.lblVertical.TabIndex = 20;
            this.lblVertical.Text = "   竖排(A4样式）";
            this.lblVertical.Click += new System.EventHandler(this.TypeSettingItems_Click);
            // 
            // lblHorizontal
            // 
            this.lblHorizontal.AutoSize = true;
            this.lblHorizontal.Image = global::YXH.ScanForm.ScannerSettingFormRes.CheckBox_Selected;
            this.lblHorizontal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHorizontal.Location = new System.Drawing.Point(91, 0);
            this.lblHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.lblHorizontal.Name = "lblHorizontal";
            this.lblHorizontal.Size = new System.Drawing.Size(101, 12);
            this.lblHorizontal.TabIndex = 19;
            this.lblHorizontal.Text = "   横排(A3样式）";
            this.lblHorizontal.Click += new System.EventHandler(this.TypeSettingItems_Click);
            // 
            // lblTypeSetting
            // 
            this.lblTypeSetting.AutoSize = true;
            this.lblTypeSetting.Location = new System.Drawing.Point(0, 0);
            this.lblTypeSetting.Margin = new System.Windows.Forms.Padding(0);
            this.lblTypeSetting.Name = "lblTypeSetting";
            this.lblTypeSetting.Size = new System.Drawing.Size(77, 12);
            this.lblTypeSetting.TabIndex = 18;
            this.lblTypeSetting.Text = "答题卡排版：";
            this.lblTypeSetting.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panTemplateInfo
            // 
            this.panTemplateInfo.Controls.Add(this.lbl_ImgNum);
            this.panTemplateInfo.Controls.Add(this.lblTemplateInfo);
            this.panTemplateInfo.Controls.Add(this.lbl_ImgeMode);
            this.panTemplateInfo.Controls.Add(this.lbl_PageSize);
            this.panTemplateInfo.Controls.Add(this.lbl_IsDoubleSize);
            this.panTemplateInfo.Controls.Add(this.lbl_ImgSize);
            this.panTemplateInfo.Location = new System.Drawing.Point(30, 335);
            this.panTemplateInfo.Margin = new System.Windows.Forms.Padding(30, 30, 0, 0);
            this.panTemplateInfo.Name = "panTemplateInfo";
            this.panTemplateInfo.Size = new System.Drawing.Size(723, 46);
            this.panTemplateInfo.TabIndex = 23;
            // 
            // lbl_ImgNum
            // 
            this.lbl_ImgNum.AutoSize = true;
            this.lbl_ImgNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbl_ImgNum.Location = new System.Drawing.Point(239, 33);
            this.lbl_ImgNum.Name = "lbl_ImgNum";
            this.lbl_ImgNum.Size = new System.Drawing.Size(77, 12);
            this.lbl_ImgNum.TabIndex = 18;
            this.lbl_ImgNum.Text = "图片数量:{0}";
            // 
            // lblTemplateInfo
            // 
            this.lblTemplateInfo.AutoSize = true;
            this.lblTemplateInfo.Location = new System.Drawing.Point(0, 0);
            this.lblTemplateInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblTemplateInfo.Name = "lblTemplateInfo";
            this.lblTemplateInfo.Size = new System.Drawing.Size(65, 12);
            this.lblTemplateInfo.TabIndex = 19;
            this.lblTemplateInfo.Text = "模板信息：";
            this.lblTemplateInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_ImgeMode
            // 
            this.lbl_ImgeMode.AutoSize = true;
            this.lbl_ImgeMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbl_ImgeMode.Location = new System.Drawing.Point(239, 0);
            this.lbl_ImgeMode.Name = "lbl_ImgeMode";
            this.lbl_ImgeMode.Size = new System.Drawing.Size(77, 12);
            this.lbl_ImgeMode.TabIndex = 17;
            this.lbl_ImgeMode.Text = "图片模式:{0}";
            // 
            // lbl_PageSize
            // 
            this.lbl_PageSize.AutoSize = true;
            this.lbl_PageSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbl_PageSize.Location = new System.Drawing.Point(91, 0);
            this.lbl_PageSize.Name = "lbl_PageSize";
            this.lbl_PageSize.Size = new System.Drawing.Size(77, 12);
            this.lbl_PageSize.TabIndex = 14;
            this.lbl_PageSize.Text = "纸张类型:{0}";
            // 
            // lbl_IsDoubleSize
            // 
            this.lbl_IsDoubleSize.AutoSize = true;
            this.lbl_IsDoubleSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbl_IsDoubleSize.Location = new System.Drawing.Point(392, 0);
            this.lbl_IsDoubleSize.Name = "lbl_IsDoubleSize";
            this.lbl_IsDoubleSize.Size = new System.Drawing.Size(77, 12);
            this.lbl_IsDoubleSize.TabIndex = 16;
            this.lbl_IsDoubleSize.Text = "是否双面:{0}";
            // 
            // lbl_ImgSize
            // 
            this.lbl_ImgSize.AutoSize = true;
            this.lbl_ImgSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbl_ImgSize.Location = new System.Drawing.Point(91, 33);
            this.lbl_ImgSize.Name = "lbl_ImgSize";
            this.lbl_ImgSize.Size = new System.Drawing.Size(101, 12);
            this.lbl_ImgSize.TabIndex = 15;
            this.lbl_ImgSize.Text = "图片尺寸:{0}X{1}";
            // 
            // btnScan
            // 
            this.btnScan.AutoSize = true;
            this.btnScan.BackgroundImage = global::YXH.ScanForm.ScannerSettingFormRes.OKButton_BackImage;
            this.btnScan.FlatAppearance.BorderSize = 0;
            this.btnScan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScan.ForeColor = System.Drawing.Color.White;
            this.btnScan.Location = new System.Drawing.Point(30, 421);
            this.btnScan.Margin = new System.Windows.Forms.Padding(30, 40, 0, 0);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(157, 62);
            this.btnScan.TabIndex = 25;
            this.btnScan.Text = "开始扫描";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // ScannerSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.flpMain);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 714);
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "ScannerSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫描设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScannerSettingForm_Closing);
            this.Load += new System.EventHandler(this.ScannerSettingForm_Load);
            this.flpPaperType.ResumeLayout(false);
            this.flpMain.ResumeLayout(false);
            this.flpMain.PerformLayout();
            this.panCurScanSource.ResumeLayout(false);
            this.panCurScanSource.PerformLayout();
            this.panScanSourceType.ResumeLayout(false);
            this.panScanSourceType.PerformLayout();
            this.panPaperType.ResumeLayout(false);
            this.panPaperType.PerformLayout();
            this.panScanType.ResumeLayout(false);
            this.panScanType.PerformLayout();
            this.panTypeSetting.ResumeLayout(false);
            this.panTypeSetting.PerformLayout();
            this.panTemplateInfo.ResumeLayout(false);
            this.panTemplateInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private FlowLayoutPanel flpPaperType;

        private Button A3;
        private Button btn_selfDefine;
        private Button A4;
        private Button B5;
        private Button B4;

        private FlowLayoutPanel flpMain;

        private Label lbl_PageSize;
        private Label lbl_ImgSize;
        private Label label1;
        private Label lblDeviceSource;
        private Label lbl_ImgeMode;
        private Label lbl_IsDoubleSize;
        private Label lbl_ImgNum;
        private Label lblFileSource;
        private Label lblDeviceSourceText;
        private Label lblScanType;
        private Panel panPaperType;
        private Panel panScanType;
        private Panel panScanSourceType;
        private Panel panCurScanSource;
        private Panel panTypeSetting;
        private Label lblTypeSetting;
        private Panel panTemplateInfo;
        private Label lblTemplateInfo;
        private Button btnScan;
        private Label lblScanner;
        private Label lblChoosePaper;
        private Label lblVertical;
        private Label lblHorizontal;
        private Button btnAdvancedSetting;

    }
}