using System.Drawing;
using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class StatisticForm
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
            this.panel_body = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_CheckOmrManualSave = new System.Windows.Forms.Button();
            this.lblOmrErrorManualSaveNum = new System.Windows.Forms.Label();
            this.cb_OmrErrorSave = new System.Windows.Forms.CheckBox();
            this.btn_CheckZkzhError = new System.Windows.Forms.Button();
            this.lblZkzhErrorNum = new System.Windows.Forms.Label();
            this.cb_zkzhErrorNum = new System.Windows.Forms.CheckBox();
            this.btn_ScanRecord = new System.Windows.Forms.Button();
            this.btnErrorPaper = new System.Windows.Forms.Button();
            this.btnAbsentStudent = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblErrorExamPaperCount = new System.Windows.Forms.Label();
            this.lblScannedStudentCount = new System.Windows.Forms.Label();
            this.lblAbsentStudentCount = new System.Windows.Forms.Label();
            this.lblStudentCount = new System.Windows.Forms.Label();
            this.ckbIncorrect = new System.Windows.Forms.CheckBox();
            this.ckbScanRecord = new System.Windows.Forms.CheckBox();
            this.ckbAbsent = new System.Windows.Forms.CheckBox();
            this.ckbEnrollment = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.link_CheckLog = new System.Windows.Forms.LinkLabel();
            this.btn_SelectedToExport = new System.Windows.Forms.Button();
            this.btnExamPaperImage = new System.Windows.Forms.Button();
            this.btn_CheckSrFolder = new System.Windows.Forms.Button();
            this.panel_body.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_body
            // 
            this.panel_body.Controls.Add(this.panel1);
            this.panel_body.Controls.Add(this.panel3);
            this.panel_body.Controls.Add(this.btn_SelectedToExport);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 0);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(700, 435);
            this.panel_body.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_CheckOmrManualSave);
            this.panel1.Controls.Add(this.lblOmrErrorManualSaveNum);
            this.panel1.Controls.Add(this.cb_OmrErrorSave);
            this.panel1.Controls.Add(this.btn_CheckZkzhError);
            this.panel1.Controls.Add(this.lblZkzhErrorNum);
            this.panel1.Controls.Add(this.cb_zkzhErrorNum);
            this.panel1.Controls.Add(this.btn_ScanRecord);
            this.panel1.Controls.Add(this.btnErrorPaper);
            this.panel1.Controls.Add(this.btnAbsentStudent);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblErrorExamPaperCount);
            this.panel1.Controls.Add(this.lblScannedStudentCount);
            this.panel1.Controls.Add(this.lblAbsentStudentCount);
            this.panel1.Controls.Add(this.lblStudentCount);
            this.panel1.Controls.Add(this.ckbIncorrect);
            this.panel1.Controls.Add(this.ckbScanRecord);
            this.panel1.Controls.Add(this.ckbAbsent);
            this.panel1.Controls.Add(this.ckbEnrollment);
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(103, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 294);
            this.panel1.TabIndex = 4;
            // 
            // btn_CheckOmrManualSave
            // 
            this.btn_CheckOmrManualSave.FlatAppearance.BorderSize = 0;
            this.btn_CheckOmrManualSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btn_CheckOmrManualSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_CheckOmrManualSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CheckOmrManualSave.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_CheckOmrManualSave.Location = new System.Drawing.Point(451, 259);
            this.btn_CheckOmrManualSave.Name = "btn_CheckOmrManualSave";
            this.btn_CheckOmrManualSave.Size = new System.Drawing.Size(45, 23);
            this.btn_CheckOmrManualSave.TabIndex = 23;
            this.btn_CheckOmrManualSave.Text = "查看";
            this.btn_CheckOmrManualSave.UseVisualStyleBackColor = true;
            this.btn_CheckOmrManualSave.Click += new System.EventHandler(this.btn_CheckOmrManualSave_Click);
            // 
            // lblOmrErrorManualSaveNum
            // 
            this.lblOmrErrorManualSaveNum.AutoSize = true;
            this.lblOmrErrorManualSaveNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOmrErrorManualSaveNum.ForeColor = System.Drawing.Color.Red;
            this.lblOmrErrorManualSaveNum.Location = new System.Drawing.Point(308, 262);
            this.lblOmrErrorManualSaveNum.Name = "lblOmrErrorManualSaveNum";
            this.lblOmrErrorManualSaveNum.Size = new System.Drawing.Size(35, 16);
            this.lblOmrErrorManualSaveNum.TabIndex = 22;
            this.lblOmrErrorManualSaveNum.Text = "445";
            // 
            // cb_OmrErrorSave
            // 
            this.cb_OmrErrorSave.AutoSize = true;
            this.cb_OmrErrorSave.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_OmrErrorSave.Location = new System.Drawing.Point(14, 259);
            this.cb_OmrErrorSave.Name = "cb_OmrErrorSave";
            this.cb_OmrErrorSave.Size = new System.Drawing.Size(218, 23);
            this.cb_OmrErrorSave.TabIndex = 21;
            this.cb_OmrErrorSave.Text = "客观题异常已处理份数";
            this.cb_OmrErrorSave.UseVisualStyleBackColor = true;
            // 
            // btn_CheckZkzhError
            // 
            this.btn_CheckZkzhError.FlatAppearance.BorderSize = 0;
            this.btn_CheckZkzhError.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btn_CheckZkzhError.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_CheckZkzhError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CheckZkzhError.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_CheckZkzhError.Location = new System.Drawing.Point(451, 211);
            this.btn_CheckZkzhError.Name = "btn_CheckZkzhError";
            this.btn_CheckZkzhError.Size = new System.Drawing.Size(45, 23);
            this.btn_CheckZkzhError.TabIndex = 20;
            this.btn_CheckZkzhError.Text = "查看";
            this.btn_CheckZkzhError.UseVisualStyleBackColor = true;
            this.btn_CheckZkzhError.Click += new System.EventHandler(this.btn_CheckZkzhError_Click);
            // 
            // lblZkzhErrorNum
            // 
            this.lblZkzhErrorNum.AutoSize = true;
            this.lblZkzhErrorNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZkzhErrorNum.ForeColor = System.Drawing.Color.Red;
            this.lblZkzhErrorNum.Location = new System.Drawing.Point(308, 214);
            this.lblZkzhErrorNum.Name = "lblZkzhErrorNum";
            this.lblZkzhErrorNum.Size = new System.Drawing.Size(35, 16);
            this.lblZkzhErrorNum.TabIndex = 19;
            this.lblZkzhErrorNum.Text = "445";
            // 
            // cb_zkzhErrorNum
            // 
            this.cb_zkzhErrorNum.AutoSize = true;
            this.cb_zkzhErrorNum.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_zkzhErrorNum.Location = new System.Drawing.Point(14, 211);
            this.cb_zkzhErrorNum.Name = "cb_zkzhErrorNum";
            this.cb_zkzhErrorNum.Size = new System.Drawing.Size(199, 23);
            this.cb_zkzhErrorNum.TabIndex = 18;
            this.cb_zkzhErrorNum.Text = "考号异常已处理份数";
            this.cb_zkzhErrorNum.UseVisualStyleBackColor = true;
            // 
            // btn_ScanRecord
            // 
            this.btn_ScanRecord.FlatAppearance.BorderSize = 0;
            this.btn_ScanRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btn_ScanRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_ScanRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ScanRecord.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_ScanRecord.Location = new System.Drawing.Point(451, 123);
            this.btn_ScanRecord.Name = "btn_ScanRecord";
            this.btn_ScanRecord.Size = new System.Drawing.Size(45, 23);
            this.btn_ScanRecord.TabIndex = 17;
            this.btn_ScanRecord.Text = "查看";
            this.btn_ScanRecord.UseVisualStyleBackColor = true;
            this.btn_ScanRecord.Click += new System.EventHandler(this.btn_ScanRecord_Click);
            // 
            // btnErrorPaper
            // 
            this.btnErrorPaper.FlatAppearance.BorderSize = 0;
            this.btnErrorPaper.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnErrorPaper.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnErrorPaper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorPaper.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnErrorPaper.Location = new System.Drawing.Point(451, 168);
            this.btnErrorPaper.Name = "btnErrorPaper";
            this.btnErrorPaper.Size = new System.Drawing.Size(45, 23);
            this.btnErrorPaper.TabIndex = 11;
            this.btnErrorPaper.Text = "查看";
            this.btnErrorPaper.UseVisualStyleBackColor = true;
            this.btnErrorPaper.Click += new System.EventHandler(this.btnErrorPaper_Click);
            // 
            // btnAbsentStudent
            // 
            this.btnAbsentStudent.FlatAppearance.BorderSize = 0;
            this.btnAbsentStudent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnAbsentStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAbsentStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbsentStudent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAbsentStudent.Location = new System.Drawing.Point(451, 76);
            this.btnAbsentStudent.Name = "btnAbsentStudent";
            this.btnAbsentStudent.Size = new System.Drawing.Size(45, 23);
            this.btnAbsentStudent.TabIndex = 9;
            this.btnAbsentStudent.Text = "查看";
            this.btnAbsentStudent.UseVisualStyleBackColor = true;
            this.btnAbsentStudent.Click += new System.EventHandler(this.btnAbsentStudent_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button1.Location = new System.Drawing.Point(451, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "查看";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblErrorExamPaperCount
            // 
            this.lblErrorExamPaperCount.AutoSize = true;
            this.lblErrorExamPaperCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblErrorExamPaperCount.ForeColor = System.Drawing.Color.Red;
            this.lblErrorExamPaperCount.Location = new System.Drawing.Point(308, 169);
            this.lblErrorExamPaperCount.Name = "lblErrorExamPaperCount";
            this.lblErrorExamPaperCount.Size = new System.Drawing.Size(35, 16);
            this.lblErrorExamPaperCount.TabIndex = 7;
            this.lblErrorExamPaperCount.Text = "445";
            // 
            // lblScannedStudentCount
            // 
            this.lblScannedStudentCount.AutoSize = true;
            this.lblScannedStudentCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScannedStudentCount.ForeColor = System.Drawing.Color.Red;
            this.lblScannedStudentCount.Location = new System.Drawing.Point(308, 124);
            this.lblScannedStudentCount.Name = "lblScannedStudentCount";
            this.lblScannedStudentCount.Size = new System.Drawing.Size(35, 16);
            this.lblScannedStudentCount.TabIndex = 6;
            this.lblScannedStudentCount.Text = "789";
            // 
            // lblAbsentStudentCount
            // 
            this.lblAbsentStudentCount.AutoSize = true;
            this.lblAbsentStudentCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbsentStudentCount.ForeColor = System.Drawing.Color.Red;
            this.lblAbsentStudentCount.Location = new System.Drawing.Point(308, 79);
            this.lblAbsentStudentCount.Name = "lblAbsentStudentCount";
            this.lblAbsentStudentCount.Size = new System.Drawing.Size(17, 16);
            this.lblAbsentStudentCount.TabIndex = 5;
            this.lblAbsentStudentCount.Text = "5";
            // 
            // lblStudentCount
            // 
            this.lblStudentCount.AutoSize = true;
            this.lblStudentCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStudentCount.ForeColor = System.Drawing.Color.Red;
            this.lblStudentCount.Location = new System.Drawing.Point(308, 37);
            this.lblStudentCount.Name = "lblStudentCount";
            this.lblStudentCount.Size = new System.Drawing.Size(44, 16);
            this.lblStudentCount.TabIndex = 4;
            this.lblStudentCount.Text = "1234";
            // 
            // ckbIncorrect
            // 
            this.ckbIncorrect.AutoSize = true;
            this.ckbIncorrect.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbIncorrect.Location = new System.Drawing.Point(14, 166);
            this.ckbIncorrect.Name = "ckbIncorrect";
            this.ckbIncorrect.Size = new System.Drawing.Size(180, 23);
            this.ckbIncorrect.TabIndex = 3;
            this.ckbIncorrect.Text = "待处理异常卷份数";
            this.ckbIncorrect.UseVisualStyleBackColor = true;
            // 
            // ckbScanRecord
            // 
            this.ckbScanRecord.AutoSize = true;
            this.ckbScanRecord.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbScanRecord.Location = new System.Drawing.Point(14, 121);
            this.ckbScanRecord.Name = "ckbScanRecord";
            this.ckbScanRecord.Size = new System.Drawing.Size(104, 23);
            this.ckbScanRecord.TabIndex = 2;
            this.ckbScanRecord.Text = "已扫份数";
            this.ckbScanRecord.UseVisualStyleBackColor = true;
            // 
            // ckbAbsent
            // 
            this.ckbAbsent.AutoSize = true;
            this.ckbAbsent.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbAbsent.Location = new System.Drawing.Point(14, 76);
            this.ckbAbsent.Name = "ckbAbsent";
            this.ckbAbsent.Size = new System.Drawing.Size(104, 23);
            this.ckbAbsent.TabIndex = 1;
            this.ckbAbsent.Text = "缺考人数";
            this.ckbAbsent.UseVisualStyleBackColor = true;
            // 
            // ckbEnrollment
            // 
            this.ckbEnrollment.AutoSize = true;
            this.ckbEnrollment.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbEnrollment.Location = new System.Drawing.Point(14, 34);
            this.ckbEnrollment.Name = "ckbEnrollment";
            this.ckbEnrollment.Size = new System.Drawing.Size(104, 23);
            this.ckbEnrollment.TabIndex = 0;
            this.ckbEnrollment.Text = "报名人数";
            this.ckbEnrollment.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExamPaperImage);
            this.panel3.Controls.Add(this.link_CheckLog);
            this.panel3.Controls.Add(this.btn_CheckSrFolder);
            this.panel3.Location = new System.Drawing.Point(216, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 47);
            this.panel3.TabIndex = 16;
            // 
            // link_CheckLog
            // 
            this.link_CheckLog.AutoSize = true;
            this.link_CheckLog.Location = new System.Drawing.Point(336, 17);
            this.link_CheckLog.Name = "link_CheckLog";
            this.link_CheckLog.Size = new System.Drawing.Size(53, 12);
            this.link_CheckLog.TabIndex = 15;
            this.link_CheckLog.TabStop = true;
            this.link_CheckLog.Text = "查看日志";
            this.link_CheckLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_CheckLog_LinkClicked);
            // 
            // btn_SelectedToExport
            // 
            this.btn_SelectedToExport.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_SelectedToExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectedToExport.Location = new System.Drawing.Point(117, 40);
            this.btn_SelectedToExport.Name = "btn_SelectedToExport";
            this.btn_SelectedToExport.Size = new System.Drawing.Size(88, 34);
            this.btn_SelectedToExport.TabIndex = 12;
            this.btn_SelectedToExport.Text = "批量导出";
            this.btn_SelectedToExport.UseVisualStyleBackColor = true;
            this.btn_SelectedToExport.Click += new System.EventHandler(this.btn_SelectedToExport_Click);
            // 
            // btnExamPaperImage
            // 
            this.btnExamPaperImage.FlatAppearance.BorderSize = 0;
            this.btnExamPaperImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnExamPaperImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExamPaperImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamPaperImage.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnExamPaperImage.Image = global::YXH.ScanForm.StatisticFormRes.btnExamPaperImage_Image;
            this.btnExamPaperImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExamPaperImage.Location = new System.Drawing.Point(16, 12);
            this.btnExamPaperImage.Name = "btnExamPaperImage";
            this.btnExamPaperImage.Size = new System.Drawing.Size(106, 23);
            this.btnExamPaperImage.TabIndex = 10;
            this.btnExamPaperImage.Text = "图片保存目录";
            this.btnExamPaperImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExamPaperImage.UseVisualStyleBackColor = true;
            this.btnExamPaperImage.Click += new System.EventHandler(this.btnExamPaperImage_Click);
            // 
            // btn_CheckSrFolder
            // 
            this.btn_CheckSrFolder.FlatAppearance.BorderSize = 0;
            this.btn_CheckSrFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btn_CheckSrFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_CheckSrFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CheckSrFolder.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_CheckSrFolder.Image = global::YXH.ScanForm.StatisticFormRes.btn_CheckSrFolder_Image;
            this.btn_CheckSrFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CheckSrFolder.Location = new System.Drawing.Point(157, 12);
            this.btn_CheckSrFolder.Name = "btn_CheckSrFolder";
            this.btn_CheckSrFolder.Size = new System.Drawing.Size(127, 23);
            this.btn_CheckSrFolder.TabIndex = 14;
            this.btn_CheckSrFolder.Text = "扫描记录保存目录";
            this.btn_CheckSrFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CheckSrFolder.UseVisualStyleBackColor = true;
            this.btn_CheckSrFolder.Click += new System.EventHandler(this.btn_CheckSrFolder_Click);
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(700, 435);
            this.Controls.Add(this.panel_body);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "统计";
            this.panel_body.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ckbScanRecord;
        private System.Windows.Forms.CheckBox ckbIncorrect;
        private System.Windows.Forms.CheckBox ckbAbsent;
        private System.Windows.Forms.CheckBox cb_zkzhErrorNum;
        private System.Windows.Forms.CheckBox cb_OmrErrorSave;
        private System.Windows.Forms.CheckBox ckbEnrollment;
        private System.Windows.Forms.Button btnErrorPaper;
        private System.Windows.Forms.Button btn_SelectedToExport;
        private System.Windows.Forms.Button btn_CheckOmrManualSave;
        private System.Windows.Forms.Button btn_CheckSrFolder;
        private System.Windows.Forms.Button btnExamPaperImage;
        private System.Windows.Forms.Button btn_ScanRecord;
        private System.Windows.Forms.Button btn_CheckZkzhError;
        private System.Windows.Forms.Button btnAbsentStudent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblErrorExamPaperCount;
        private System.Windows.Forms.Label lblZkzhErrorNum;
        private System.Windows.Forms.Label lblOmrErrorManualSaveNum;
        private System.Windows.Forms.Label lblScannedStudentCount;
        private System.Windows.Forms.Label lblAbsentStudentCount;
        private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.LinkLabel link_CheckLog;
    }
}