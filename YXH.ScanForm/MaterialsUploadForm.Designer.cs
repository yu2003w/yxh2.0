using System;
using System.Drawing;
using System.Windows.Forms;
using YXH.Common.Form;
namespace YXH.ScanForm
{
    partial class MaterialsUploadForm
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
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_SourcePaper = new System.Windows.Forms.Button();
            this.btn_Answer = new System.Windows.Forms.Button();
            this.btn_EmptyPaper = new System.Windows.Forms.Button();
            this.btn_AssignmentPlan = new System.Windows.Forms.Button();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.panel_body = new System.Windows.Forms.Panel();
            this.panel_BodyImgView = new System.Windows.Forms.Panel();
            this.btn_Finish = new YXH.Common.Form.RoundButton();
            this.lv_imglist = new System.Windows.Forms.ListView();
            this.panel_toolTop = new System.Windows.Forms.Panel();
            this.lbl_Restatus = new System.Windows.Forms.Label();
            this.lk_ContinueScan = new System.Windows.Forms.LinkLabel();
            this.lk_ContinueChoose = new System.Windows.Forms.LinkLabel();
            this.linklbl_RechooseFile = new System.Windows.Forms.LinkLabel();
            this.linklbl_Rescan = new System.Windows.Forms.LinkLabel();
            this.panel_BodyStart = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ChooseFile = new System.Windows.Forms.Button();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imglist_thumb = new System.Windows.Forms.ImageList(this.components);
            this.panel_top.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_body.SuspendLayout();
            this.panel_BodyImgView.SuspendLayout();
            this.panel_toolTop.SuspendLayout();
            this.panel_BodyStart.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(100, 414);
            this.panel_left.TabIndex = 0;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.tableLayoutPanel1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(100, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(984, 70);
            this.panel_top.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_SourcePaper, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Answer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_EmptyPaper, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_AssignmentPlan, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_SourcePaper
            // 
            this.btn_SourcePaper.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_SourcePaper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SourcePaper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SourcePaper.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.btn_SourcePaper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_SourcePaper.Location = new System.Drawing.Point(0, 10);
            this.btn_SourcePaper.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btn_SourcePaper.Name = "btn_SourcePaper";
            this.btn_SourcePaper.Size = new System.Drawing.Size(246, 50);
            this.btn_SourcePaper.TabIndex = 3;
            this.btn_SourcePaper.Text = "原卷";
            this.btn_SourcePaper.UseVisualStyleBackColor = false;
            this.btn_SourcePaper.Click += new System.EventHandler(this.btn_SourcePaper_Click);
            // 
            // btn_Answer
            // 
            this.btn_Answer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Answer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Answer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Answer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Answer.Location = new System.Drawing.Point(246, 10);
            this.btn_Answer.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btn_Answer.Name = "btn_Answer";
            this.btn_Answer.Size = new System.Drawing.Size(246, 50);
            this.btn_Answer.TabIndex = 2;
            this.btn_Answer.Text = "试卷答案";
            this.btn_Answer.UseVisualStyleBackColor = false;
            this.btn_Answer.Click += new System.EventHandler(this.btn_Answer_Click);
            // 
            // btn_EmptyPaper
            // 
            this.btn_EmptyPaper.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_EmptyPaper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_EmptyPaper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EmptyPaper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_EmptyPaper.Location = new System.Drawing.Point(738, 10);
            this.btn_EmptyPaper.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btn_EmptyPaper.Name = "btn_EmptyPaper";
            this.btn_EmptyPaper.Size = new System.Drawing.Size(246, 50);
            this.btn_EmptyPaper.TabIndex = 4;
            this.btn_EmptyPaper.Text = "空白答题卡";
            this.btn_EmptyPaper.UseVisualStyleBackColor = false;
            this.btn_EmptyPaper.Visible = false;
            this.btn_EmptyPaper.Click += new System.EventHandler(this.btn_EmptyPaper_Click);
            // 
            // btn_AssignmentPlan
            // 
            this.btn_AssignmentPlan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_AssignmentPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_AssignmentPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AssignmentPlan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_AssignmentPlan.Location = new System.Drawing.Point(492, 10);
            this.btn_AssignmentPlan.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btn_AssignmentPlan.Name = "btn_AssignmentPlan";
            this.btn_AssignmentPlan.Size = new System.Drawing.Size(246, 50);
            this.btn_AssignmentPlan.TabIndex = 6;
            this.btn_AssignmentPlan.Text = "分配方案";
            this.btn_AssignmentPlan.UseVisualStyleBackColor = false;
            this.btn_AssignmentPlan.Visible = false;
            this.btn_AssignmentPlan.Click += new System.EventHandler(this.btn_AssignmentPlan_Click);
            // 
            // panel_Right
            // 
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Right.Location = new System.Drawing.Point(1084, 0);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(100, 414);
            this.panel_Right.TabIndex = 3;
            // 
            // panel_body
            // 
            this.panel_body.Controls.Add(this.panel_BodyImgView);
            this.panel_body.Controls.Add(this.panel_BodyStart);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(100, 70);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(984, 344);
            this.panel_body.TabIndex = 4;
            // 
            // panel_BodyImgView
            // 
            this.panel_BodyImgView.Controls.Add(this.btn_Finish);
            this.panel_BodyImgView.Controls.Add(this.lv_imglist);
            this.panel_BodyImgView.Controls.Add(this.panel_toolTop);
            this.panel_BodyImgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_BodyImgView.Location = new System.Drawing.Point(0, 0);
            this.panel_BodyImgView.Name = "panel_BodyImgView";
            this.panel_BodyImgView.Size = new System.Drawing.Size(984, 344);
            this.panel_BodyImgView.TabIndex = 5;
            // 
            // btn_Finish
            // 
            this.btn_Finish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Finish.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Finish.FlatAppearance.BorderSize = 0;
            this.btn_Finish.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Finish.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_Finish.Location = new System.Drawing.Point(855, 213);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(99, 101);
            this.btn_Finish.TabIndex = 9;
            this.btn_Finish.Text = "完成";
            this.btn_Finish.UseVisualStyleBackColor = false;
            this.btn_Finish.Click += new System.EventHandler(this.btn_Finish_Click);
            // 
            // lv_imglist
            // 
            this.lv_imglist.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lv_imglist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_imglist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_imglist.Location = new System.Drawing.Point(0, 35);
            this.lv_imglist.Name = "lv_imglist";
            this.lv_imglist.Size = new System.Drawing.Size(984, 309);
            this.lv_imglist.TabIndex = 5;
            this.lv_imglist.UseCompatibleStateImageBehavior = false;
            this.lv_imglist.SelectedIndexChanged += new System.EventHandler(this.lv_imglist_SelectedIndexChanged);
            // 
            // panel_toolTop
            // 
            this.panel_toolTop.Controls.Add(this.lbl_Restatus);
            this.panel_toolTop.Controls.Add(this.lk_ContinueScan);
            this.panel_toolTop.Controls.Add(this.lk_ContinueChoose);
            this.panel_toolTop.Controls.Add(this.linklbl_RechooseFile);
            this.panel_toolTop.Controls.Add(this.linklbl_Rescan);
            this.panel_toolTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_toolTop.Location = new System.Drawing.Point(0, 0);
            this.panel_toolTop.Name = "panel_toolTop";
            this.panel_toolTop.Size = new System.Drawing.Size(984, 35);
            this.panel_toolTop.TabIndex = 6;
            // 
            // lbl_Restatus
            // 
            this.lbl_Restatus.AutoSize = true;
            this.lbl_Restatus.Font = new System.Drawing.Font("宋体", 11F);
            this.lbl_Restatus.ForeColor = System.Drawing.Color.Black;
            this.lbl_Restatus.Location = new System.Drawing.Point(25, 11);
            this.lbl_Restatus.Name = "lbl_Restatus";
            this.lbl_Restatus.Size = new System.Drawing.Size(0, 15);
            this.lbl_Restatus.TabIndex = 16;
            // 
            // lk_ContinueScan
            // 
            this.lk_ContinueScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lk_ContinueScan.AutoSize = true;
            this.lk_ContinueScan.Font = new System.Drawing.Font("宋体", 11F);
            this.lk_ContinueScan.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.lk_ContinueScan.Location = new System.Drawing.Point(669, 13);
            this.lk_ContinueScan.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lk_ContinueScan.Name = "lk_ContinueScan";
            this.lk_ContinueScan.Size = new System.Drawing.Size(67, 15);
            this.lk_ContinueScan.TabIndex = 15;
            this.lk_ContinueScan.TabStop = true;
            this.lk_ContinueScan.Text = "继续扫描";
            this.lk_ContinueScan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lk_ContinueScan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_ContinueScan_LinkClicked);
            // 
            // lk_ContinueChoose
            // 
            this.lk_ContinueChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lk_ContinueChoose.AutoSize = true;
            this.lk_ContinueChoose.Font = new System.Drawing.Font("宋体", 11F);
            this.lk_ContinueChoose.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.lk_ContinueChoose.Location = new System.Drawing.Point(748, 13);
            this.lk_ContinueChoose.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lk_ContinueChoose.Name = "lk_ContinueChoose";
            this.lk_ContinueChoose.Size = new System.Drawing.Size(67, 15);
            this.lk_ContinueChoose.TabIndex = 14;
            this.lk_ContinueChoose.TabStop = true;
            this.lk_ContinueChoose.Text = "继续选图";
            this.lk_ContinueChoose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lk_ContinueChoose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_ContinueChoose_LinkClicked);
            // 
            // linklbl_RechooseFile
            // 
            this.linklbl_RechooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklbl_RechooseFile.AutoSize = true;
            this.linklbl_RechooseFile.Font = new System.Drawing.Font("宋体", 11F);
            this.linklbl_RechooseFile.Location = new System.Drawing.Point(911, 13);
            this.linklbl_RechooseFile.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.linklbl_RechooseFile.Name = "linklbl_RechooseFile";
            this.linklbl_RechooseFile.Size = new System.Drawing.Size(67, 15);
            this.linklbl_RechooseFile.TabIndex = 13;
            this.linklbl_RechooseFile.TabStop = true;
            this.linklbl_RechooseFile.Text = "重新选图";
            this.linklbl_RechooseFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linklbl_RechooseFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbl_RechooseFile_LinkClicked);
            // 
            // linklbl_Rescan
            // 
            this.linklbl_Rescan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklbl_Rescan.AutoSize = true;
            this.linklbl_Rescan.Font = new System.Drawing.Font("宋体", 11F);
            this.linklbl_Rescan.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.linklbl_Rescan.Location = new System.Drawing.Point(830, 13);
            this.linklbl_Rescan.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.linklbl_Rescan.Name = "linklbl_Rescan";
            this.linklbl_Rescan.Size = new System.Drawing.Size(67, 15);
            this.linklbl_Rescan.TabIndex = 12;
            this.linklbl_Rescan.TabStop = true;
            this.linklbl_Rescan.Text = "重新扫描";
            this.linklbl_Rescan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linklbl_Rescan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbl_Rescan_LinkClicked);
            // 
            // panel_BodyStart
            // 
            this.panel_BodyStart.Controls.Add(this.tableLayoutPanel2);
            this.panel_BodyStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_BodyStart.Location = new System.Drawing.Point(0, 0);
            this.panel_BodyStart.Name = "panel_BodyStart";
            this.panel_BodyStart.Size = new System.Drawing.Size(984, 344);
            this.panel_BodyStart.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(984, 344);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ChooseFile);
            this.panel1.Controls.Add(this.btn_Scan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(330, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 108);
            this.panel1.TabIndex = 5;
            // 
            // btn_ChooseFile
            // 
            this.btn_ChooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ChooseFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_ChooseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChooseFile.Font = new System.Drawing.Font("宋体", 18F);
            this.btn_ChooseFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ChooseFile.Location = new System.Drawing.Point(324, 0);
            this.btn_ChooseFile.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btn_ChooseFile.Name = "btn_ChooseFile";
            this.btn_ChooseFile.Size = new System.Drawing.Size(120, 108);
            this.btn_ChooseFile.TabIndex = 4;
            this.btn_ChooseFile.Text = "选图上传";
            this.btn_ChooseFile.UseVisualStyleBackColor = false;
            this.btn_ChooseFile.Click += new System.EventHandler(this.btn_ChooseFile_Click);
            // 
            // btn_Scan
            // 
            this.btn_Scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Scan.Font = new System.Drawing.Font("宋体", 18F);
            this.btn_Scan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Scan.Location = new System.Drawing.Point(0, 0);
            this.btn_Scan.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(129, 108);
            this.btn_Scan.TabIndex = 3;
            this.btn_Scan.Text = "扫描上传";
            this.btn_Scan.UseVisualStyleBackColor = false;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "图像|*.jpg;*.png;*.tif";
            this.openFileDialog.Multiselect = true;
            // 
            // imglist_thumb
            // 
            this.imglist_thumb.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglist_thumb.ImageSize = new System.Drawing.Size(16, 16);
            this.imglist_thumb.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MaterialsUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1184, 414);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_Right);
            this.Controls.Add(this.panel_left);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialsUploadForm";
            this.Text = "MaterialsUploadForm";
            this.Load += new System.EventHandler(this.MaterialsUploadForm_Load);
            this.panel_top.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_body.ResumeLayout(false);
            this.panel_BodyImgView.ResumeLayout(false);
            this.panel_toolTop.ResumeLayout(false);
            this.panel_toolTop.PerformLayout();
            this.panel_BodyStart.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Panel panel_left;

        private Panel panel_top;

        private TableLayoutPanel tableLayoutPanel1;

        private Button btn_AssignmentPlan;

        private Button btn_EmptyPaper;

        private Button btn_SourcePaper;

        private Button btn_Answer;

        private Panel panel_Right;

        private Panel panel_body;

        private Panel panel_BodyImgView;

        private Panel panel_BodyStart;

        private OpenFileDialog openFileDialog;

        private ImageList imglist_thumb;

        private ListView lv_imglist;

        private Panel panel_toolTop;

        private LinkLabel linklbl_RechooseFile;

        private LinkLabel linklbl_Rescan;

        private RoundButton btn_Finish;

        private Panel panel1;

        private Button btn_ChooseFile;

        private Button btn_Scan;

        private TableLayoutPanel tableLayoutPanel2;

        private LinkLabel lk_ContinueScan;

        private LinkLabel lk_ContinueChoose;

        private Label lbl_Restatus;

        #endregion
    }
}