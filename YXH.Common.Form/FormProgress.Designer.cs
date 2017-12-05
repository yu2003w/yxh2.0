using System.Drawing;
using System.Windows.Forms;
namespace YXH.Common.Form
{
    partial class FormProgress
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRateOfProgress = new System.Windows.Forms.Label();
            this.lblMsgInfo = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblRateOfProgress
            // 
            this.lblRateOfProgress.AutoSize = true;
            this.lblRateOfProgress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRateOfProgress.Image = global::YXH.Common.Form.FormProgressRes.label1_Image;
            this.lblRateOfProgress.Location = new System.Drawing.Point(13, 20);
            this.lblRateOfProgress.Name = "lblRateOfProgress";
            this.lblRateOfProgress.Size = new System.Drawing.Size(0, 16);
            this.lblRateOfProgress.TabIndex = 0;
            // 
            // lblMsgInfo
            // 
            this.lblMsgInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMsgInfo.AutoSize = true;
            this.lblMsgInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblMsgInfo.Location = new System.Drawing.Point(14, 45);
            this.lblMsgInfo.Name = "lblMsgInfo";
            this.lblMsgInfo.Size = new System.Drawing.Size(0, 12);
            this.lblMsgInfo.TabIndex = 3;
            this.lblMsgInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.progressBar.Location = new System.Drawing.Point(12, 16);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(361, 20);
            this.progressBar.TabIndex = 1;
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 81);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblRateOfProgress);
            this.Controls.Add(this.lblMsgInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProgress";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMsg_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRateOfProgress;
        private System.Windows.Forms.Label lblMsgInfo;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

