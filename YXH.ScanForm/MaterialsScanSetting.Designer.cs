using System;
using System.Drawing;
using System.Windows.Forms;
using YXH.Common.Form;
namespace YXH.ScanForm
{
    partial class MaterialsScanSetting
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
            this.panelScan = new System.Windows.Forms.Panel();
            this.cb_IsShowAdvanceSetting = new System.Windows.Forms.CheckBox();
            this.gb_PaperLayout = new System.Windows.Forms.GroupBox();
            this.rb_vertical = new System.Windows.Forms.RadioButton();
            this.rb_horizontal = new System.Windows.Forms.RadioButton();
            this.btnScan = new YXH.Common.Form.RoundButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_choosePaper = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.A3 = new System.Windows.Forms.Button();
            this.A4 = new System.Windows.Forms.Button();
            this.B4 = new System.Windows.Forms.Button();
            this.B5 = new System.Windows.Forms.Button();
            this.btn_selfDefine = new System.Windows.Forms.Button();
            this.panelScan.SuspendLayout();
            this.gb_PaperLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScan
            // 
            this.panelScan.Controls.Add(this.cb_IsShowAdvanceSetting);
            this.panelScan.Controls.Add(this.gb_PaperLayout);
            this.panelScan.Controls.Add(this.btnScan);
            this.panelScan.Controls.Add(this.label2);
            this.panelScan.Controls.Add(this.cb_choosePaper);
            this.panelScan.Controls.Add(this.flowLayoutPanel1);
            this.panelScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScan.Location = new System.Drawing.Point(0, 0);
            this.panelScan.Name = "panelScan";
            this.panelScan.Size = new System.Drawing.Size(655, 290);
            this.panelScan.TabIndex = 5;
            // 
            // cb_IsShowAdvanceSetting
            // 
            this.cb_IsShowAdvanceSetting.AutoSize = true;
            this.cb_IsShowAdvanceSetting.Location = new System.Drawing.Point(155, 151);
            this.cb_IsShowAdvanceSetting.Name = "cb_IsShowAdvanceSetting";
            this.cb_IsShowAdvanceSetting.Size = new System.Drawing.Size(132, 16);
            this.cb_IsShowAdvanceSetting.TabIndex = 9;
            this.cb_IsShowAdvanceSetting.Text = "扫描时显示高级设置";
            this.cb_IsShowAdvanceSetting.UseVisualStyleBackColor = true;
            // 
            // gb_PaperLayout
            // 
            this.gb_PaperLayout.Controls.Add(this.rb_vertical);
            this.gb_PaperLayout.Controls.Add(this.rb_horizontal);
            this.gb_PaperLayout.Location = new System.Drawing.Point(43, 185);
            this.gb_PaperLayout.Name = "gb_PaperLayout";
            this.gb_PaperLayout.Size = new System.Drawing.Size(266, 67);
            this.gb_PaperLayout.TabIndex = 8;
            this.gb_PaperLayout.TabStop = false;
            this.gb_PaperLayout.Text = "试卷排版";
            // 
            // rb_vertical
            // 
            this.rb_vertical.AutoSize = true;
            this.rb_vertical.Location = new System.Drawing.Point(115, 34);
            this.rb_vertical.Name = "rb_vertical";
            this.rb_vertical.Size = new System.Drawing.Size(101, 16);
            this.rb_vertical.TabIndex = 1;
            this.rb_vertical.Text = "竖排(A4样式）";
            this.rb_vertical.UseVisualStyleBackColor = true;
            // 
            // rb_horizontal
            // 
            this.rb_horizontal.AutoSize = true;
            this.rb_horizontal.Checked = true;
            this.rb_horizontal.Location = new System.Drawing.Point(8, 34);
            this.rb_horizontal.Name = "rb_horizontal";
            this.rb_horizontal.Size = new System.Drawing.Size(101, 16);
            this.rb_horizontal.TabIndex = 0;
            this.rb_horizontal.TabStop = true;
            this.rb_horizontal.Text = "横排(A3样式）";
            this.rb_horizontal.UseVisualStyleBackColor = true;
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.SpringGreen;
            this.btnScan.FlatAppearance.BorderSize = 0;
            this.btnScan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnScan.Location = new System.Drawing.Point(491, 160);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(98, 92);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "开始扫描";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择纸张：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cb_choosePaper
            // 
            this.cb_choosePaper.AutoSize = true;
            this.cb_choosePaper.Location = new System.Drawing.Point(43, 151);
            this.cb_choosePaper.Name = "cb_choosePaper";
            this.cb_choosePaper.Size = new System.Drawing.Size(84, 16);
            this.cb_choosePaper.TabIndex = 4;
            this.cb_choosePaper.Text = "双面答题卡";
            this.cb_choosePaper.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.A3);
            this.flowLayoutPanel1.Controls.Add(this.A4);
            this.flowLayoutPanel1.Controls.Add(this.B4);
            this.flowLayoutPanel1.Controls.Add(this.B5);
            this.flowLayoutPanel1.Controls.Add(this.btn_selfDefine);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(40, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(584, 110);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // A3
            // 
            this.A3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.A3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.A3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A3.Location = new System.Drawing.Point(3, 3);
            this.A3.Name = "A3";
            this.A3.Size = new System.Drawing.Size(106, 91);
            this.A3.TabIndex = 0;
            this.A3.Text = "A3";
            this.A3.UseVisualStyleBackColor = false;
            this.A3.Click += new System.EventHandler(this.A3_Click);
            // 
            // A4
            // 
            this.A4.BackColor = System.Drawing.Color.White;
            this.A4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.A4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4.Location = new System.Drawing.Point(115, 3);
            this.A4.Name = "A4";
            this.A4.Size = new System.Drawing.Size(106, 91);
            this.A4.TabIndex = 1;
            this.A4.Text = "A4";
            this.A4.UseVisualStyleBackColor = false;
            this.A4.Click += new System.EventHandler(this.A4_Click);
            // 
            // B4
            // 
            this.B4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B4.Location = new System.Drawing.Point(227, 3);
            this.B4.Name = "B4";
            this.B4.Size = new System.Drawing.Size(106, 91);
            this.B4.TabIndex = 5;
            this.B4.Text = "B4";
            this.B4.UseVisualStyleBackColor = true;
            this.B4.Click += new System.EventHandler(this.B4_Click);
            // 
            // B5
            // 
            this.B5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B5.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B5.Location = new System.Drawing.Point(339, 3);
            this.B5.Name = "B5";
            this.B5.Size = new System.Drawing.Size(106, 91);
            this.B5.TabIndex = 2;
            this.B5.Text = "B5";
            this.B5.UseVisualStyleBackColor = true;
            this.B5.Click += new System.EventHandler(this.B5_Click);
            // 
            // btn_selfDefine
            // 
            this.btn_selfDefine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selfDefine.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selfDefine.Location = new System.Drawing.Point(451, 3);
            this.btn_selfDefine.Name = "btn_selfDefine";
            this.btn_selfDefine.Size = new System.Drawing.Size(106, 91);
            this.btn_selfDefine.TabIndex = 6;
            this.btn_selfDefine.Text = "自定义";
            this.btn_selfDefine.UseVisualStyleBackColor = true;
            this.btn_selfDefine.Click += new System.EventHandler(this.btn_SelfDefine_Click);
            // 
            // MaterialsScanSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(655, 290);
            this.Controls.Add(this.panelScan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialsScanSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫描设置";
            this.Load += new System.EventHandler(this.MaterialsScanSetting_Load);
            this.panelScan.ResumeLayout(false);
            this.panelScan.PerformLayout();
            this.gb_PaperLayout.ResumeLayout(false);
            this.gb_PaperLayout.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Panel panelScan;

        private GroupBox gb_PaperLayout;

        private RadioButton rb_vertical;

        private RadioButton rb_horizontal;

        private RoundButton btnScan;

        private Label label2;

        private CheckBox cb_choosePaper;

        private FlowLayoutPanel flowLayoutPanel1;

        private Button A3;

        private Button A4;

        private Button B4;

        private Button B5;

        private Button btn_selfDefine;

        private CheckBox cb_IsShowAdvanceSetting;
        #endregion
    }
}