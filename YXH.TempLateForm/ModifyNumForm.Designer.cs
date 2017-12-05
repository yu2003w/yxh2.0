using System.Drawing;
using System.Windows.Forms;
namespace YXH.TemplateForm
{
    partial class ModifyNumForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.rdVarrange = new System.Windows.Forms.RadioButton();
            this.rdHarrange = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(76, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 25);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(144, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(24, 29);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(29, 12);
            this.lblNum.TabIndex = 2;
            this.lblNum.Text = "题号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "高级设置";
            this.label2.Visible = false;
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Location = new System.Drawing.Point(23, 56);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(53, 12);
            this.lblConfig.TabIndex = 7;
            this.lblConfig.Text = "题内设置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "项";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(82, 26);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(99, 21);
            this.txtNum.TabIndex = 4;
            // 
            // txtItemCount
            // 
            this.txtItemCount.Location = new System.Drawing.Point(82, 53);
            this.txtItemCount.Name = "txtItemCount";
            this.txtItemCount.Size = new System.Drawing.Size(99, 21);
            this.txtItemCount.TabIndex = 8;
            // 
            // rdVarrange
            // 
            this.rdVarrange.AutoSize = true;
            this.rdVarrange.Location = new System.Drawing.Point(134, 79);
            this.rdVarrange.Name = "rdVarrange";
            this.rdVarrange.Size = new System.Drawing.Size(47, 16);
            this.rdVarrange.TabIndex = 9;
            this.rdVarrange.TabStop = true;
            this.rdVarrange.Text = "竖排";
            this.rdVarrange.UseVisualStyleBackColor = true;
            this.rdVarrange.CheckedChanged += new System.EventHandler(this.rdVarrange_CheckedChanged);
            // 
            // rdHarrange
            // 
            this.rdHarrange.AutoSize = true;
            this.rdHarrange.Location = new System.Drawing.Point(76, 80);
            this.rdHarrange.Name = "rdHarrange";
            this.rdHarrange.Size = new System.Drawing.Size(47, 16);
            this.rdHarrange.TabIndex = 10;
            this.rdHarrange.TabStop = true;
            this.rdHarrange.Text = "横排";
            this.rdHarrange.UseVisualStyleBackColor = true;
            this.rdHarrange.CheckedChanged += new System.EventHandler(this.rdHarrange_CheckedChanged);
            // 
            // ModifyNumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 171);
            this.Controls.Add(this.rdHarrange);
            this.Controls.Add(this.rdVarrange);
            this.Controls.Add(this.txtItemCount);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyNumForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtItemCount;
        private System.Windows.Forms.RadioButton rdVarrange;
        private System.Windows.Forms.RadioButton rdHarrange;
    }
}