using System.Drawing;
using System.Windows.Forms;
namespace YXH.Main
{
    partial class MainScanForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScanForm));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panTableCan = new System.Windows.Forms.Panel();
            this.picExamList = new System.Windows.Forms.PictureBox();
            this.lblEximList = new System.Windows.Forms.Label();
            this.picHistoryRecord = new System.Windows.Forms.PictureBox();
            this.lblHistoryRecord = new System.Windows.Forms.Label();
            this.picSystemSetting = new System.Windows.Forms.PictureBox();
            this.lblSystemSetting = new System.Windows.Forms.Label();
            this.lblServiceCall = new System.Windows.Forms.Label();
            this.picExitSystem = new System.Windows.Forms.PictureBox();
            this.lblExitSystem = new System.Windows.Forms.Label();
            this.lbl_SubjectName = new System.Windows.Forms.Label();
            this.panTopBar = new System.Windows.Forms.Panel();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimum = new System.Windows.Forms.PictureBox();
            this.picMaximum = new System.Windows.Forms.PictureBox();
            this.lblApplicationTitle = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdateExplain = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTitle.SuspendLayout();
            this.panTableCan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExamList)).BeginInit();
            this.picExamList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHistoryRecord)).BeginInit();
            this.picHistoryRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSystemSetting)).BeginInit();
            this.picSystemSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExitSystem)).BeginInit();
            this.picExitSystem.SuspendLayout();
            this.panTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximum)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.panelTitle.Controls.Add(this.panTableCan);
            this.panelTitle.Controls.Add(this.lblServiceCall);
            this.panelTitle.Controls.Add(this.picExitSystem);
            this.panelTitle.Controls.Add(this.lbl_SubjectName);
            this.panelTitle.Controls.Add(this.panTopBar);
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1200, 100);
            this.panelTitle.TabIndex = 15;
            // 
            // panTableCan
            // 
            this.panTableCan.Controls.Add(this.picExamList);
            this.panTableCan.Controls.Add(this.picHistoryRecord);
            this.panTableCan.Controls.Add(this.picSystemSetting);
            this.panTableCan.Location = new System.Drawing.Point(365, 41);
            this.panTableCan.Name = "panTableCan";
            this.panTableCan.Size = new System.Drawing.Size(364, 60);
            this.panTableCan.TabIndex = 7;
            // 
            // picExamList
            // 
            this.picExamList.Controls.Add(this.lblEximList);
            this.picExamList.Location = new System.Drawing.Point(0, 10);
            this.picExamList.Margin = new System.Windows.Forms.Padding(0);
            this.picExamList.Name = "picExamList";
            this.picExamList.Size = new System.Drawing.Size(121, 40);
            this.picExamList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picExamList.TabIndex = 4;
            this.picExamList.TabStop = false;
            this.picExamList.MouseLeave += new System.EventHandler(this.picExamList_MouseLeave);
            this.picExamList.MouseHover += new System.EventHandler(this.picExamList_MouseHover);
            // 
            // lblEximList
            // 
            this.lblEximList.AutoSize = true;
            this.lblEximList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEximList.ForeColor = System.Drawing.Color.White;
            this.lblEximList.Image = global::YXH.Main.MainScanFormRes.ExamList;
            this.lblEximList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEximList.Location = new System.Drawing.Point(19, 13);
            this.lblEximList.Name = "lblEximList";
            this.lblEximList.Size = new System.Drawing.Size(88, 16);
            this.lblEximList.TabIndex = 7;
            this.lblEximList.Text = "  考试列表";
            this.lblEximList.MouseHover += new System.EventHandler(this.picExamList_MouseHover);
            // 
            // picHistoryRecord
            // 
            this.picHistoryRecord.Controls.Add(this.lblHistoryRecord);
            this.picHistoryRecord.Location = new System.Drawing.Point(122, 10);
            this.picHistoryRecord.Margin = new System.Windows.Forms.Padding(0);
            this.picHistoryRecord.Name = "picHistoryRecord";
            this.picHistoryRecord.Size = new System.Drawing.Size(121, 40);
            this.picHistoryRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHistoryRecord.TabIndex = 6;
            this.picHistoryRecord.TabStop = false;
            this.picHistoryRecord.Visible = false;
            this.picHistoryRecord.MouseLeave += new System.EventHandler(this.picHistoryRecord_MouseLeave);
            this.picHistoryRecord.MouseHover += new System.EventHandler(this.picHistoryRecord_MouseHover);
            // 
            // lblHistoryRecord
            // 
            this.lblHistoryRecord.AutoSize = true;
            this.lblHistoryRecord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHistoryRecord.ForeColor = System.Drawing.Color.White;
            this.lblHistoryRecord.Image = global::YXH.Main.MainScanFormRes.HistoryRecord;
            this.lblHistoryRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHistoryRecord.Location = new System.Drawing.Point(19, 13);
            this.lblHistoryRecord.Name = "lblHistoryRecord";
            this.lblHistoryRecord.Size = new System.Drawing.Size(88, 16);
            this.lblHistoryRecord.TabIndex = 8;
            this.lblHistoryRecord.Text = "  历史记录";
            this.lblHistoryRecord.MouseHover += new System.EventHandler(this.picHistoryRecord_MouseHover);
            // 
            // picSystemSetting
            // 
            this.picSystemSetting.Controls.Add(this.lblSystemSetting);
            this.picSystemSetting.Location = new System.Drawing.Point(243, 10);
            this.picSystemSetting.Margin = new System.Windows.Forms.Padding(0);
            this.picSystemSetting.Name = "picSystemSetting";
            this.picSystemSetting.Size = new System.Drawing.Size(121, 40);
            this.picSystemSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSystemSetting.TabIndex = 5;
            this.picSystemSetting.TabStop = false;
            this.picSystemSetting.Visible = false;
            this.picSystemSetting.MouseLeave += new System.EventHandler(this.picSystemSetting_MouseLeave);
            this.picSystemSetting.MouseHover += new System.EventHandler(this.picSystemSetting_MouseHover);
            // 
            // lblSystemSetting
            // 
            this.lblSystemSetting.AutoSize = true;
            this.lblSystemSetting.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSystemSetting.ForeColor = System.Drawing.Color.White;
            this.lblSystemSetting.Image = global::YXH.Main.MainScanFormRes.SystemSetting;
            this.lblSystemSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSystemSetting.Location = new System.Drawing.Point(19, 13);
            this.lblSystemSetting.Name = "lblSystemSetting";
            this.lblSystemSetting.Size = new System.Drawing.Size(88, 16);
            this.lblSystemSetting.TabIndex = 9;
            this.lblSystemSetting.Text = "  系统设置";
            this.lblSystemSetting.MouseHover += new System.EventHandler(this.picSystemSetting_MouseHover);
            // 
            // lblServiceCall
            // 
            this.lblServiceCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceCall.AutoSize = true;
            this.lblServiceCall.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceCall.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblServiceCall.ForeColor = System.Drawing.Color.White;
            this.lblServiceCall.Location = new System.Drawing.Point(871, 63);
            this.lblServiceCall.Name = "lblServiceCall";
            this.lblServiceCall.Size = new System.Drawing.Size(215, 19);
            this.lblServiceCall.TabIndex = 3;
            this.lblServiceCall.Text = "服务热线:029-27222222";
            this.lblServiceCall.Visible = false;
            // 
            // picExitSystem
            // 
            this.picExitSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picExitSystem.BackColor = System.Drawing.Color.Transparent;
            this.picExitSystem.BackgroundImage = global::YXH.Main.MainScanFormRes.ExitSystem_Normal;
            this.picExitSystem.Controls.Add(this.lblExitSystem);
            this.picExitSystem.Location = new System.Drawing.Point(1098, 56);
            this.picExitSystem.Name = "picExitSystem";
            this.picExitSystem.Size = new System.Drawing.Size(90, 30);
            this.picExitSystem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picExitSystem.TabIndex = 2;
            this.picExitSystem.TabStop = false;
            this.picExitSystem.Click += new System.EventHandler(this.picExitSystem_Click);
            // 
            // lblExitSystem
            // 
            this.lblExitSystem.AutoSize = true;
            this.lblExitSystem.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExitSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblExitSystem.Location = new System.Drawing.Point(9, 7);
            this.lblExitSystem.Name = "lblExitSystem";
            this.lblExitSystem.Size = new System.Drawing.Size(72, 16);
            this.lblExitSystem.TabIndex = 3;
            this.lblExitSystem.Text = "退出系统";
            this.lblExitSystem.Click += new System.EventHandler(this.picExitSystem_Click);
            // 
            // lbl_SubjectName
            // 
            this.lbl_SubjectName.AutoSize = true;
            this.lbl_SubjectName.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_SubjectName.ForeColor = System.Drawing.Color.White;
            this.lbl_SubjectName.Location = new System.Drawing.Point(15, 56);
            this.lbl_SubjectName.Name = "lbl_SubjectName";
            this.lbl_SubjectName.Size = new System.Drawing.Size(0, 27);
            this.lbl_SubjectName.TabIndex = 1;
            // 
            // panTopBar
            // 
            this.panTopBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTopBar.Controls.Add(this.pbMenu);
            this.panTopBar.Controls.Add(this.picClose);
            this.panTopBar.Controls.Add(this.picMinimum);
            this.panTopBar.Controls.Add(this.picMaximum);
            this.panTopBar.Controls.Add(this.lblApplicationTitle);
            this.panTopBar.Location = new System.Drawing.Point(0, 0);
            this.panTopBar.Name = "panTopBar";
            this.panTopBar.Size = new System.Drawing.Size(1200, 40);
            this.panTopBar.TabIndex = 0;
            this.panTopBar.DoubleClick += new System.EventHandler(this.panTopBar_DoubleClick);
            // 
            // pbMenu
            // 
            this.pbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.pbMenu.Image = ((System.Drawing.Image)(resources.GetObject("pbMenu.Image")));
            this.pbMenu.Location = new System.Drawing.Point(1091, 3);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(24, 24);
            this.pbMenu.TabIndex = 4;
            this.pbMenu.TabStop = false;
            this.pbMenu.Click += new System.EventHandler(this.pbMenu_Click);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Image = global::YXH.Main.CommonRes.Close_Normal;
            this.picClose.Location = new System.Drawing.Point(1164, 3);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(24, 24);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClose.TabIndex = 3;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            this.picClose.MouseHover += new System.EventHandler(this.picClose_MouseHover);
            // 
            // picMinimum
            // 
            this.picMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimum.Image = global::YXH.Main.CommonRes.Minimum_Normal;
            this.picMinimum.Location = new System.Drawing.Point(1116, 3);
            this.picMinimum.Name = "picMinimum";
            this.picMinimum.Size = new System.Drawing.Size(24, 24);
            this.picMinimum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMinimum.TabIndex = 2;
            this.picMinimum.TabStop = false;
            this.picMinimum.Click += new System.EventHandler(this.picMinimum_Click);
            this.picMinimum.MouseLeave += new System.EventHandler(this.picMinimum_MouseLeave);
            this.picMinimum.MouseHover += new System.EventHandler(this.picMinimum_MouseHover);
            // 
            // picMaximum
            // 
            this.picMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMaximum.Image = global::YXH.Main.CommonRes.Maximum_Normal;
            this.picMaximum.Location = new System.Drawing.Point(1140, 3);
            this.picMaximum.Name = "picMaximum";
            this.picMaximum.Size = new System.Drawing.Size(24, 24);
            this.picMaximum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMaximum.TabIndex = 1;
            this.picMaximum.TabStop = false;
            this.picMaximum.Click += new System.EventHandler(this.picMaximum_Click);
            this.picMaximum.MouseLeave += new System.EventHandler(this.picMaximum_MouseLeave);
            this.picMaximum.MouseHover += new System.EventHandler(this.picMaximum_MouseHover);
            // 
            // lblApplicationTitle
            // 
            this.lblApplicationTitle.AutoSize = true;
            this.lblApplicationTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplicationTitle.ForeColor = System.Drawing.Color.White;
            this.lblApplicationTitle.Location = new System.Drawing.Point(15, 11);
            this.lblApplicationTitle.Name = "lblApplicationTitle";
            this.lblApplicationTitle.Size = new System.Drawing.Size(104, 16);
            this.lblApplicationTitle.TabIndex = 0;
            this.lblApplicationTitle.Text = "蘑菇云客户端";
            // 
            // panelBody
            // 
            this.panelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBody.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelBody.Location = new System.Drawing.Point(0, 100);
            this.panelBody.Margin = new System.Windows.Forms.Padding(0);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1200, 500);
            this.panelBody.TabIndex = 19;
            // 
            // cmsMenu
            // 
            this.cmsMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmsMenu.BackgroundImage")));
            this.cmsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdateExplain});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(125, 26);
            this.cmsMenu.Text = "这是一朵花";
            // 
            // tsmiUpdateExplain
            // 
            this.tsmiUpdateExplain.Name = "tsmiUpdateExplain";
            this.tsmiUpdateExplain.Size = new System.Drawing.Size(124, 22);
            this.tsmiUpdateExplain.Text = "更新说明";
            this.tsmiUpdateExplain.Click += new System.EventHandler(this.tsmiUpdateExplain_Click);
            // 
            // MainScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "MainScanForm";
            this.Text = "中矿阅卷";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainScanForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainScanForm_SizeChanged);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panTableCan.ResumeLayout(false);
            this.panTableCan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExamList)).EndInit();
            this.picExamList.ResumeLayout(false);
            this.picExamList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHistoryRecord)).EndInit();
            this.picHistoryRecord.ResumeLayout(false);
            this.picHistoryRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSystemSetting)).EndInit();
            this.picSystemSetting.ResumeLayout(false);
            this.picSystemSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExitSystem)).EndInit();
            this.picExitSystem.ResumeLayout(false);
            this.picExitSystem.PerformLayout();
            this.panTopBar.ResumeLayout(false);
            this.panTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximum)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelBody;
        private Label lbl_SubjectName;
        private Panel panTopBar;
        private Label lblApplicationTitle;
        private PictureBox picClose;
        private PictureBox picMinimum;
        private PictureBox picMaximum;
        private Label lblExitSystem;
        private PictureBox picExitSystem;
        private Label lblServiceCall;
        private PictureBox picHistoryRecord;
        private PictureBox picSystemSetting;
        private PictureBox picExamList;
        private Label lblSystemSetting;
        private Label lblHistoryRecord;
        private Label lblEximList;
        private Panel panTableCan;
        private PictureBox pbMenu;
        private ContextMenuStrip cmsMenu;
        private ToolStripMenuItem tsmiUpdateExplain;
    }
}