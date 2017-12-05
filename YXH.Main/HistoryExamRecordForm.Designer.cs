using System;
using System.Drawing;
using System.Windows.Forms;
namespace YXH.Main
{
    partial class HistoryExamRecordForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_HistoryExam = new System.Windows.Forms.DataGridView();
            this.examid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.examname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.examtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanfinishtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploadmaterials = new System.Windows.Forms.DataGridViewLinkColumn();
            this.scanstatis = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tb_CheckExamId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_body = new System.Windows.Forms.Panel();
            this.panel_BodyBack = new System.Windows.Forms.Panel();
            this.lbl_ShowReuslt = new System.Windows.Forms.Label();
            this.lbl_statis = new System.Windows.Forms.Label();
            this.panel_footer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dg_HistoryExam)).BeginInit();
            this.panel_top.SuspendLayout();
            this.panel_body.SuspendLayout();
            this.panel_BodyBack.SuspendLayout();
            this.panel_footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_HistoryExam
            // 
            this.dg_HistoryExam.AllowUserToAddRows = false;
            this.dg_HistoryExam.AllowUserToDeleteRows = false;
            this.dg_HistoryExam.AllowUserToOrderColumns = true;
            this.dg_HistoryExam.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dg_HistoryExam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_HistoryExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_HistoryExam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.examid,
            this.examname,
            this.subjectname,
            this.examtype,
            this.scanfinishtime,
            this.uploadmaterials,
            this.scanstatis});
            this.dg_HistoryExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_HistoryExam.Location = new System.Drawing.Point(0, 0);
            this.dg_HistoryExam.Name = "dg_HistoryExam";
            this.dg_HistoryExam.ReadOnly = true;
            this.dg_HistoryExam.RowTemplate.Height = 23;
            this.dg_HistoryExam.Size = new System.Drawing.Size(664, 300);
            this.dg_HistoryExam.TabIndex = 0;
            this.dg_HistoryExam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_HistoryExam_CellContentClick);
            // 
            // examid
            // 
            this.examid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.examid.DataPropertyName = "ExamId";
            dataGridViewCellStyle3.NullValue = "0";
            this.examid.DefaultCellStyle = dataGridViewCellStyle3;
            this.examid.HeaderText = "考试ID";
            this.examid.Name = "examid";
            this.examid.ReadOnly = true;
            this.examid.Width = 61;
            // 
            // examname
            // 
            this.examname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.examname.DataPropertyName = "ExamName";
            this.examname.FillWeight = 35F;
            this.examname.HeaderText = "考试名称";
            this.examname.Name = "examname";
            this.examname.ReadOnly = true;
            // 
            // subjectname
            // 
            this.subjectname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subjectname.DataPropertyName = "SubjectName";
            this.subjectname.FillWeight = 15F;
            this.subjectname.HeaderText = "科目名称";
            this.subjectname.Name = "subjectname";
            this.subjectname.ReadOnly = true;
            // 
            // examtype
            // 
            this.examtype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.examtype.DataPropertyName = "ExamType";
            this.examtype.HeaderText = "考试类型";
            this.examtype.Name = "examtype";
            this.examtype.ReadOnly = true;
            this.examtype.Width = 61;
            // 
            // scanfinishtime
            // 
            this.scanfinishtime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.scanfinishtime.DataPropertyName = "ScanFinishTime";
            this.scanfinishtime.FillWeight = 15F;
            this.scanfinishtime.HeaderText = "扫描结束时间";
            this.scanfinishtime.Name = "scanfinishtime";
            this.scanfinishtime.ReadOnly = true;
            // 
            // uploadmaterials
            // 
            this.uploadmaterials.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.uploadmaterials.DataPropertyName = "UploadMaterials";
            this.uploadmaterials.HeaderText = "上传资料";
            this.uploadmaterials.Name = "uploadmaterials";
            this.uploadmaterials.ReadOnly = true;
            this.uploadmaterials.Width = 42;
            // 
            // scanstatis
            // 
            this.scanstatis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.scanstatis.DataPropertyName = "ScanStatis";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.scanstatis.DefaultCellStyle = dataGridViewCellStyle4;
            this.scanstatis.HeaderText = "扫描统计";
            this.scanstatis.Name = "scanstatis";
            this.scanstatis.ReadOnly = true;
            this.scanstatis.Width = 42;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(664, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(120, 362);
            this.panel_right.TabIndex = 1;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.btn_Search);
            this.panel_top.Controls.Add(this.tb_CheckExamId);
            this.panel_top.Controls.Add(this.label1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(664, 35);
            this.panel_top.TabIndex = 2;
            // 
            // btn_Search
            // 
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Search.Location = new System.Drawing.Point(193, 8);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(45, 23);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // tb_CheckExamId
            // 
            this.tb_CheckExamId.Location = new System.Drawing.Point(86, 9);
            this.tb_CheckExamId.Name = "tb_CheckExamId";
            this.tb_CheckExamId.Size = new System.Drawing.Size(100, 21);
            this.tb_CheckExamId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "考试ID：";
            // 
            // panel_body
            // 
            this.panel_body.Controls.Add(this.dg_HistoryExam);
            this.panel_body.Controls.Add(this.panel_BodyBack);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 35);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(664, 300);
            this.panel_body.TabIndex = 3;
            // 
            // panel_BodyBack
            // 
            this.panel_BodyBack.Controls.Add(this.lbl_ShowReuslt);
            this.panel_BodyBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_BodyBack.Location = new System.Drawing.Point(0, 0);
            this.panel_BodyBack.Name = "panel_BodyBack";
            this.panel_BodyBack.Size = new System.Drawing.Size(664, 300);
            this.panel_BodyBack.TabIndex = 1;
            // 
            // lbl_ShowReuslt
            // 
            this.lbl_ShowReuslt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ShowReuslt.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_ShowReuslt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_ShowReuslt.Location = new System.Drawing.Point(0, 0);
            this.lbl_ShowReuslt.Name = "lbl_ShowReuslt";
            this.lbl_ShowReuslt.Size = new System.Drawing.Size(664, 300);
            this.lbl_ShowReuslt.TabIndex = 0;
            this.lbl_ShowReuslt.Text = "刷新失败，请稍后重试！";
            this.lbl_ShowReuslt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_statis
            // 
            this.lbl_statis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_statis.Location = new System.Drawing.Point(3, -68);
            this.lbl_statis.Name = "lbl_statis";
            this.lbl_statis.Size = new System.Drawing.Size(525, 16);
            this.lbl_statis.TabIndex = 3;
            this.lbl_statis.Text = "已完成{0}场考试";
            this.lbl_statis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_footer
            // 
            this.panel_footer.Controls.Add(this.lbl_statis);
            this.panel_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_footer.Location = new System.Drawing.Point(0, 335);
            this.panel_footer.Name = "panel_footer";
            this.panel_footer.Size = new System.Drawing.Size(664, 27);
            this.panel_footer.TabIndex = 1;
            // 
            // HistoryExamRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel_footer);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_right);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryExamRecordForm";
            this.Text = "HistoryExamRecordForm";
            this.Load += new System.EventHandler(this.HistoryExamRecordForm_Load);
            this.Shown += new System.EventHandler(this.HistoryExamRecordForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dg_HistoryExam)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel_body.ResumeLayout(false);
            this.panel_BodyBack.ResumeLayout(false);
            this.panel_footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private DataGridView dg_HistoryExam;

        private Panel panel_right;

        private Panel panel_top;

        private Panel panel_body;

        private Label label1;

        private Button btn_Search;

        private TextBox tb_CheckExamId;

        private Label lbl_statis;

        private Panel panel_BodyBack;

        private Label lbl_ShowReuslt;

        private Panel panel_footer;

        private DataGridViewTextBoxColumn examid;

        private DataGridViewTextBoxColumn examname;

        private DataGridViewTextBoxColumn subjectname;

        private DataGridViewTextBoxColumn examtype;

        private DataGridViewTextBoxColumn scanfinishtime;

        private DataGridViewLinkColumn uploadmaterials;

        private DataGridViewLinkColumn scanstatis;

        

        #endregion
    }
}