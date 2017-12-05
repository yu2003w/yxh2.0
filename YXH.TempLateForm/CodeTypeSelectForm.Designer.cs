using System.Drawing;
using System.Windows.Forms;
namespace YXH.TemplateForm
{
    partial class CodeTypeSelectForm
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
            this.rbBarCode = new System.Windows.Forms.RadioButton();
            this.rbQRcode = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBarCodeIsvertical = new System.Windows.Forms.CheckBox();
            this.rbOmr = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbBarCode
            // 
            this.rbBarCode.AutoSize = true;
            this.rbBarCode.Checked = true;
            this.rbBarCode.Location = new System.Drawing.Point(21, 24);
            this.rbBarCode.Name = "rbBarCode";
            this.rbBarCode.Size = new System.Drawing.Size(59, 16);
            this.rbBarCode.TabIndex = 0;
            this.rbBarCode.TabStop = true;
            this.rbBarCode.Text = "条形码";
            this.rbBarCode.UseVisualStyleBackColor = true;
            this.rbBarCode.CheckedChanged += new System.EventHandler(this.rbBarCode_CheckedChanged);
            // 
            // rbQRcode
            // 
            this.rbQRcode.AutoSize = true;
            this.rbQRcode.Location = new System.Drawing.Point(21, 46);
            this.rbQRcode.Name = "rbQRcode";
            this.rbQRcode.Size = new System.Drawing.Size(59, 16);
            this.rbQRcode.TabIndex = 1;
            this.rbQRcode.TabStop = true;
            this.rbQRcode.Text = "二维码";
            this.rbQRcode.UseVisualStyleBackColor = true;
            this.rbQRcode.CheckedChanged += new System.EventHandler(this.rbQRcode_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(115, 113);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(63, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(184, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOmr);
            this.groupBox1.Controls.Add(this.chkBarCodeIsvertical);
            this.groupBox1.Controls.Add(this.rbBarCode);
            this.groupBox1.Controls.Add(this.rbQRcode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 95);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "未检测出填涂框，请指定考号区域类型";
            // 
            // chkBarCodeIsvertical
            // 
            this.chkBarCodeIsvertical.AutoSize = true;
            this.chkBarCodeIsvertical.Location = new System.Drawing.Point(88, 25);
            this.chkBarCodeIsvertical.Name = "chkBarCodeIsvertical";
            this.chkBarCodeIsvertical.Size = new System.Drawing.Size(48, 16);
            this.chkBarCodeIsvertical.TabIndex = 2;
            this.chkBarCodeIsvertical.Text = "竖贴";
            this.chkBarCodeIsvertical.UseVisualStyleBackColor = true;
            // 
            // rbOmr
            // 
            this.rbOmr.AutoSize = true;
            this.rbOmr.Location = new System.Drawing.Point(21, 68);
            this.rbOmr.Name = "rbOmr";
            this.rbOmr.Size = new System.Drawing.Size(59, 16);
            this.rbOmr.TabIndex = 3;
            this.rbOmr.TabStop = true;
            this.rbOmr.Text = "自定义";
            this.rbOmr.UseVisualStyleBackColor = true;
            // 
            // CodeTypeSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 155);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CodeTypeSelectForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbBarCode;
        private System.Windows.Forms.RadioButton rbQRcode;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBarCodeIsvertical;
        private RadioButton rbOmr;
    }
}