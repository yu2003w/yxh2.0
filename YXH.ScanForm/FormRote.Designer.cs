using System.Drawing;
using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class FormRote
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRotateCCW90 = new System.Windows.Forms.Button();
            this.btnCWRotate90 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picView = new System.Windows.Forms.PictureBox();
            this.btnRotateCCW180 = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(52, 227);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(126, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRotateCCW90
            // 
            this.btnRotateCCW90.BackgroundImage = global::YXH.ScanForm.FormRoteRes.btnRotateCCW90_BackgroundImage;
            this.btnRotateCCW90.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRotateCCW90.Location = new System.Drawing.Point(125, 12);
            this.btnRotateCCW90.Name = "btnRotateCCW90";
            this.btnRotateCCW90.Size = new System.Drawing.Size(50, 40);
            this.btnRotateCCW90.TabIndex = 3;
            this.btnRotateCCW90.UseVisualStyleBackColor = true;
            this.btnRotateCCW90.Click += new System.EventHandler(this.btnRotateCCW90_Click);
            // 
            // btnCWRotate90
            // 
            this.btnCWRotate90.BackgroundImage = global::YXH.ScanForm.FormRoteRes.btnCWRotate90_BackgroundImage;
            this.btnCWRotate90.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCWRotate90.Location = new System.Drawing.Point(192, 12);
            this.btnCWRotate90.Name = "btnCWRotate90";
            this.btnCWRotate90.Size = new System.Drawing.Size(50, 40);
            this.btnCWRotate90.TabIndex = 4;
            this.btnCWRotate90.UseVisualStyleBackColor = true;
            this.btnCWRotate90.Click += new System.EventHandler(this.btnCWRotate90_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.picView);
            this.groupBox1.Location = new System.Drawing.Point(18, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 149);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // picView
            // 
            this.picView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picView.Location = new System.Drawing.Point(19, 20);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(230, 122);
            this.picView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picView.TabIndex = 0;
            this.picView.TabStop = false;
            // 
            // btnRotateCCW180
            // 
            this.btnRotateCCW180.BackgroundImage = global::YXH.ScanForm.FormRoteRes.btnRotateCCW180_BackgroundImage;
            this.btnRotateCCW180.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRotateCCW180.Location = new System.Drawing.Point(258, 12);
            this.btnRotateCCW180.Name = "btnRotateCCW180";
            this.btnRotateCCW180.Size = new System.Drawing.Size(50, 40);
            this.btnRotateCCW180.TabIndex = 8;
            this.btnRotateCCW180.UseVisualStyleBackColor = true;
            this.btnRotateCCW180.Click += new System.EventHandler(this.btnRotateCCW180_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(25, 25);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(40, 23);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.Text = "左旋";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(71, 25);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(40, 23);
            this.btnRight.TabIndex = 10;
            this.btnRight.Text = "右旋";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // FormRote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 262);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRotateCCW180);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCWRotate90);
            this.Controls.Add(this.btnRotateCCW90);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "旋转";
            this.Load += new System.EventHandler(this.FormRote_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRotateCCW90;
        private System.Windows.Forms.Button btnCWRotate90;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.Button btnRotateCCW180;
        private Button btnLeft;
        private Button btnRight;
    }
}