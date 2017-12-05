using System;
using System.Drawing;
using System.Windows.Forms;
namespace YXH.TemplateForm
{
    partial class ExamImageForm
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
            this.formPanel = new System.Windows.Forms.Panel();
            this.pictureboxPanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ctMs_rightClickMenu = new System.Windows.Forms.ContextMenuStrip();
            this.ts_currentImageInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_CopyTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelTips = new System.Windows.Forms.Panel();
            this.labelTips = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.returnScan = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.formPanel.SuspendLayout();
            this.pictureboxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.ctMs_rightClickMenu.SuspendLayout();
            this.panelTips.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formPanel.AutoScroll = true;
            this.formPanel.BackColor = System.Drawing.SystemColors.Window;
            this.formPanel.Controls.Add(this.pictureboxPanel);
            this.formPanel.Location = new System.Drawing.Point(0, -76);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(691, 498);
            this.formPanel.TabIndex = 1;
            this.formPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.formPanel_Scroll);
            // 
            // pictureboxPanel
            // 
            this.pictureboxPanel.AutoSize = true;
            this.pictureboxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pictureboxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureboxPanel.Controls.Add(this.pictureBox);
            this.pictureboxPanel.Location = new System.Drawing.Point(0, 0);
            this.pictureboxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pictureboxPanel.Name = "pictureboxPanel";
            this.pictureboxPanel.Size = new System.Drawing.Size(3602, 2402);
            this.pictureboxPanel.TabIndex = 4;
            // 
            // pictureBox
            // 
            this.pictureBox.ContextMenuStrip = this.ctMs_rightClickMenu;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(3600, 2400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // ctMs_rightClickMenu
            // 
            this.ctMs_rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_currentImageInfo,
            this.ts_CopyTemplate});
            this.ctMs_rightClickMenu.Name = "ctMs_rightClickMenu";
            this.ctMs_rightClickMenu.Size = new System.Drawing.Size(137, 48);
            // 
            // ts_currentImageInfo
            // 
            this.ts_currentImageInfo.Name = "ts_currentImageInfo";
            this.ts_currentImageInfo.Size = new System.Drawing.Size(136, 22);
            this.ts_currentImageInfo.Text = "模板信息";
            this.ts_currentImageInfo.Click += new System.EventHandler(this.ts_currentImageInfo_Click);
            // 
            // ts_CopyTemplate
            // 
            this.ts_CopyTemplate.Name = "ts_CopyTemplate";
            this.ts_CopyTemplate.Size = new System.Drawing.Size(136, 22);
            this.ts_CopyTemplate.Text = "复制模板图";
            this.ts_CopyTemplate.Click += new System.EventHandler(this.ts_CopyTemplate_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.BackgroundImage = global::YXH.TemplateForm.CommonRes.OKButton_BackImage;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(18, 328);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(156, 60);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelTips
            // 
            this.panelTips.BackColor = System.Drawing.Color.MistyRose;
            this.panelTips.Controls.Add(this.labelTips);
            this.panelTips.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTips.Location = new System.Drawing.Point(0, 0);
            this.panelTips.Margin = new System.Windows.Forms.Padding(0);
            this.panelTips.Name = "panelTips";
            this.panelTips.Size = new System.Drawing.Size(691, 40);
            this.panelTips.TabIndex = 1;
            // 
            // labelTips
            // 
            this.labelTips.BackColor = System.Drawing.Color.Transparent;
            this.labelTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTips.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTips.ForeColor = System.Drawing.Color.Silver;
            this.labelTips.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTips.Location = new System.Drawing.Point(0, 0);
            this.labelTips.Margin = new System.Windows.Forms.Padding(0);
            this.labelTips.Name = "labelTips";
            this.labelTips.Size = new System.Drawing.Size(691, 40);
            this.labelTips.TabIndex = 1;
            this.labelTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // returnScan
            // 
            this.returnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.returnScan.AutoSize = true;
            this.returnScan.BackColor = System.Drawing.SystemColors.Window;
            this.returnScan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.returnScan.Location = new System.Drawing.Point(194, 348);
            this.returnScan.Name = "returnScan";
            this.returnScan.Size = new System.Drawing.Size(104, 16);
            this.returnScan.TabIndex = 1;
            this.returnScan.TabStop = true;
            this.returnScan.Text = "重新选取图片";
            this.returnScan.Visible = false;
            this.returnScan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.returnScan_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackgroundImage = global::YXH.TemplateForm.CommonRes.OKButton_BackImage;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(18, 328);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 60);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ExamImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(691, 422);
            this.Controls.Add(this.panelTips);
            this.Controls.Add(this.returnScan);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.formPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExamImageForm";
            this.Text = "ExamImageForm";
            this.Load += new System.EventHandler(this.ExamImageForm_Load);
            this.Resize += new System.EventHandler(this.ExamImageForm_Resize);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.pictureboxPanel.ResumeLayout(false);
            this.pictureboxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ctMs_rightClickMenu.ResumeLayout(false);
            this.panelTips.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Panel pictureboxPanel;
        private System.Windows.Forms.Panel panelTips;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.LinkLabel returnScan;
        private System.Windows.Forms.Label labelTips;
        private System.Windows.Forms.ContextMenuStrip ctMs_rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem ts_currentImageInfo;
        private System.Windows.Forms.ToolStripMenuItem ts_CopyTemplate;
        private Button btnOK;
        private Button btnSave;
    }
}