using System.Drawing;
using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class ScanFinishForm
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
            this.btn_Finish = new System.Windows.Forms.Button();
            this.btn_FinishAndJumpToUploadMaterials = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblImportant = new System.Windows.Forms.Label();
            this.lblMessageTitle = new System.Windows.Forms.Label();
            this.lblCongratulationsInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Finish
            // 
            this.btn_Finish.AutoSize = true;
            this.btn_Finish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btn_Finish.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Finish.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Finish.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_Finish.Location = new System.Drawing.Point(215, 251);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(100, 30);
            this.btn_Finish.TabIndex = 1;
            this.btn_Finish.Text = "结束扫描";
            this.btn_Finish.UseVisualStyleBackColor = false;
            this.btn_Finish.Click += new System.EventHandler(this.btn_Finish_Click);
            // 
            // btn_FinishAndJumpToUploadMaterials
            // 
            this.btn_FinishAndJumpToUploadMaterials.AutoSize = true;
            this.btn_FinishAndJumpToUploadMaterials.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.btn_FinishAndJumpToUploadMaterials.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_FinishAndJumpToUploadMaterials.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_FinishAndJumpToUploadMaterials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FinishAndJumpToUploadMaterials.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FinishAndJumpToUploadMaterials.ForeColor = System.Drawing.Color.White;
            this.btn_FinishAndJumpToUploadMaterials.Location = new System.Drawing.Point(0, 251);
            this.btn_FinishAndJumpToUploadMaterials.Name = "btn_FinishAndJumpToUploadMaterials";
            this.btn_FinishAndJumpToUploadMaterials.Size = new System.Drawing.Size(201, 31);
            this.btn_FinishAndJumpToUploadMaterials.TabIndex = 2;
            this.btn_FinishAndJumpToUploadMaterials.Text = "结束扫描并上传原卷";
            this.btn_FinishAndJumpToUploadMaterials.UseVisualStyleBackColor = false;
            this.btn_FinishAndJumpToUploadMaterials.Visible = false;
            this.btn_FinishAndJumpToUploadMaterials.Click += new System.EventHandler(this.btn_FinishAndJumpToUploadMaterials_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCongratulationsInfo);
            this.panel1.Controls.Add(this.btn_FinishAndJumpToUploadMaterials);
            this.panel1.Controls.Add(this.lblImportant);
            this.panel1.Controls.Add(this.btn_Finish);
            this.panel1.Controls.Add(this.lblMessageTitle);
            this.panel1.Font = new System.Drawing.Font("宋体", 12F);
            this.panel1.Location = new System.Drawing.Point(70, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 352);
            this.panel1.TabIndex = 2;
            // 
            // lblImportant
            // 
            this.lblImportant.AutoSize = true;
            this.lblImportant.Location = new System.Drawing.Point(47, 89);
            this.lblImportant.Name = "lblImportant";
            this.lblImportant.Size = new System.Drawing.Size(720, 112);
            this.lblImportant.TabIndex = 1;
            this.lblImportant.Text = "1.我们建议您点击“上传原卷”，以便统计班级考试详情。\r\n\r\n2.只有点击下面按钮后，才能提交本次扫描的学生数据。\r\n\r\n3.当阅卷开始后，本次考试不再显示在考试" +
    "列表中。\r\n\r\n4.如需扫描上传其它类型的资料，可在点击“结束扫描”前返回科目列表—>“上传资料”进行操作。";
            // 
            // lblMessageTitle
            // 
            this.lblMessageTitle.AutoSize = true;
            this.lblMessageTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblMessageTitle.Name = "lblMessageTitle";
            this.lblMessageTitle.Size = new System.Drawing.Size(109, 19);
            this.lblMessageTitle.TabIndex = 0;
            this.lblMessageTitle.Text = "操作提示：";
            // 
            // lblCongratulationsInfo
            // 
            this.lblCongratulationsInfo.AutoSize = true;
            this.lblCongratulationsInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblCongratulationsInfo.Location = new System.Drawing.Point(47, 49);
            this.lblCongratulationsInfo.Name = "lblCongratulationsInfo";
            this.lblCongratulationsInfo.Size = new System.Drawing.Size(248, 16);
            this.lblCongratulationsInfo.TabIndex = 3;
            this.lblCongratulationsInfo.Text = "恭喜您，本科目试卷已扫描完成。";
            // 
            // ScanFinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(837, 436);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanFinishForm";
            this.Text = "ScanFinishForm";
            this.Load += new System.EventHandler(this.ScanFinishForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.Button btn_FinishAndJumpToUploadMaterials;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMessageTitle;
        private System.Windows.Forms.Label lblImportant;
        private Label lblCongratulationsInfo;
    }
}