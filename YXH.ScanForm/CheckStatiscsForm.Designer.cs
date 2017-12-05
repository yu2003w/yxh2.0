using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class CheckStatiscsForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLeft_footer = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.picBox_WaitForDealwith = new System.Windows.Forms.PictureBox();
            this.lblIncorrectCount = new System.Windows.Forms.Label();
            this.panelLeft_mid = new System.Windows.Forms.Panel();
            this.lblScanSpeed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picBox_speed = new System.Windows.Forms.PictureBox();
            this.panelLeft_Top = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_DailyScan = new System.Windows.Forms.Label();
            this.picBox_DailyComoplete = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelLeft_footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_WaitForDealwith)).BeginInit();
            this.panelLeft_mid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_speed)).BeginInit();
            this.panelLeft_Top.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_DailyComoplete)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelLeft_footer);
            this.splitContainer1.Panel1.Controls.Add(this.panelLeft_mid);
            this.splitContainer1.Panel1.Controls.Add(this.panelLeft_Top);
            this.splitContainer1.Size = new System.Drawing.Size(784, 420);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelLeft_footer
            // 
            this.panelLeft_footer.Controls.Add(this.label6);
            this.panelLeft_footer.Controls.Add(this.picBox_WaitForDealwith);
            this.panelLeft_footer.Controls.Add(this.lblIncorrectCount);
            this.panelLeft_footer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeft_footer.Location = new System.Drawing.Point(0, 254);
            this.panelLeft_footer.Name = "panelLeft_footer";
            this.panelLeft_footer.Size = new System.Drawing.Size(158, 163);
            this.panelLeft_footer.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(38, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "待处理问题卷";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBox_WaitForDealwith
            // 
            this.picBox_WaitForDealwith.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox_WaitForDealwith.Image = global::YXH.ScanForm.CheckStatiscsFormRes.picBox_WaitForDealwith_Image;
            this.picBox_WaitForDealwith.Location = new System.Drawing.Point(20, 22);
            this.picBox_WaitForDealwith.Name = "picBox_WaitForDealwith";
            this.picBox_WaitForDealwith.Size = new System.Drawing.Size(76, 161);
            this.picBox_WaitForDealwith.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_WaitForDealwith.TabIndex = 5;
            this.picBox_WaitForDealwith.TabStop = false;
            // 
            // lblIncorrectCount
            // 
            this.lblIncorrectCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIncorrectCount.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIncorrectCount.Location = new System.Drawing.Point(36, 3);
            this.lblIncorrectCount.Name = "lblIncorrectCount";
            this.lblIncorrectCount.Size = new System.Drawing.Size(32, 16);
            this.lblIncorrectCount.TabIndex = 4;
            this.lblIncorrectCount.Text = "12张";
            this.lblIncorrectCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLeft_mid
            // 
            this.panelLeft_mid.Controls.Add(this.lblScanSpeed);
            this.panelLeft_mid.Controls.Add(this.label3);
            this.panelLeft_mid.Controls.Add(this.picBox_speed);
            this.panelLeft_mid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeft_mid.Location = new System.Drawing.Point(0, 124);
            this.panelLeft_mid.Name = "panelLeft_mid";
            this.panelLeft_mid.Size = new System.Drawing.Size(158, 130);
            this.panelLeft_mid.TabIndex = 1;
            // 
            // lblScanSpeed
            // 
            this.lblScanSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScanSpeed.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScanSpeed.Location = new System.Drawing.Point(36, 3);
            this.lblScanSpeed.Name = "lblScanSpeed";
            this.lblScanSpeed.Size = new System.Drawing.Size(32, 16);
            this.lblScanSpeed.TabIndex = 3;
            this.lblScanSpeed.Text = "60张/分钟";
            this.lblScanSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(36, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "扫描速度";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBox_speed
            // 
            this.picBox_speed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox_speed.Image = global::YXH.ScanForm.CheckStatiscsFormRes.picBox_speed_Image;
            this.picBox_speed.Location = new System.Drawing.Point(20, 22);
            this.picBox_speed.Name = "picBox_speed";
            this.picBox_speed.Size = new System.Drawing.Size(76, 112);
            this.picBox_speed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_speed.TabIndex = 1;
            this.picBox_speed.TabStop = false;
            // 
            // panelLeft_Top
            // 
            this.panelLeft_Top.Controls.Add(this.panel1);
            this.panelLeft_Top.Controls.Add(this.label1);
            this.panelLeft_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeft_Top.Location = new System.Drawing.Point(0, 0);
            this.panelLeft_Top.Name = "panelLeft_Top";
            this.panelLeft_Top.Size = new System.Drawing.Size(158, 124);
            this.panelLeft_Top.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.picBox_DailyComoplete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 100);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lbl_DailyScan);
            this.panel2.Location = new System.Drawing.Point(37, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(41, 28);
            this.panel2.TabIndex = 3;
            // 
            // lbl_DailyScan
            // 
            this.lbl_DailyScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DailyScan.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_DailyScan.Location = new System.Drawing.Point(0, 0);
            this.lbl_DailyScan.Name = "lbl_DailyScan";
            this.lbl_DailyScan.Size = new System.Drawing.Size(41, 28);
            this.lbl_DailyScan.TabIndex = 2;
            this.lbl_DailyScan.Text = "12345";
            this.lbl_DailyScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBox_DailyComoplete
            // 
            this.picBox_DailyComoplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_DailyComoplete.Image = global::YXH.ScanForm.CheckStatiscsFormRes.picBox_DailyComoplete_Image;
            this.picBox_DailyComoplete.Location = new System.Drawing.Point(0, 0);
            this.picBox_DailyComoplete.Name = "picBox_DailyComoplete";
            this.picBox_DailyComoplete.Size = new System.Drawing.Size(158, 100);
            this.picBox_DailyComoplete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_DailyComoplete.TabIndex = 0;
            this.picBox_DailyComoplete.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(38, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "本日已完成";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckStatiscsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 420);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckStatiscsForm";
            this.Text = "CheckStatiscsForm";
            this.Load += new System.EventHandler(this.CheckStatiscsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelLeft_footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_WaitForDealwith)).EndInit();
            this.panelLeft_mid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_speed)).EndInit();
            this.panelLeft_Top.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_DailyComoplete)).EndInit();
            this.ResumeLayout(false);

        }

        private SplitContainer splitContainer1;

        private Panel panelLeft_footer;

        private Label label6;

        private PictureBox picBox_WaitForDealwith;

        private Label lblIncorrectCount;

        private Panel panelLeft_mid;

        private Label lblScanSpeed;

        private Label label3;

        private PictureBox picBox_speed;

        private Panel panelLeft_Top;

        private Label lbl_DailyScan;

        private Label label1;

        private PictureBox picBox_DailyComoplete;

        private Panel panel1;

        private Panel panel2;

        #endregion
    }
}