using System.Drawing;
namespace YXH.TemplateForm
{
    partial class TemplateSettingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRect = new System.Windows.Forms.RadioButton();
            this.rbBracket = new System.Windows.Forms.RadioButton();
            this.gb_RectIno = new System.Windows.Forms.GroupBox();
            this.tb_RectHeight = new System.Windows.Forms.TextBox();
            this.tb_RectWid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_RectIno.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRect);
            this.groupBox1.Controls.Add(this.rbBracket);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 59);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前填涂块样式";
            // 
            // rbRect
            // 
            this.rbRect.AutoSize = true;
            this.rbRect.Checked = true;
            this.rbRect.Location = new System.Drawing.Point(21, 24);
            this.rbRect.Name = "rbRect";
            this.rbRect.Size = new System.Drawing.Size(47, 16);
            this.rbRect.TabIndex = 0;
            this.rbRect.TabStop = true;
            this.rbRect.Text = "方框";
            this.rbRect.UseVisualStyleBackColor = true;
            this.rbRect.CheckedChanged += new System.EventHandler(this.rbRect_CheckedChanged);
            // 
            // rbBracket
            // 
            this.rbBracket.AutoSize = true;
            this.rbBracket.Location = new System.Drawing.Point(99, 24);
            this.rbBracket.Name = "rbBracket";
            this.rbBracket.Size = new System.Drawing.Size(59, 16);
            this.rbBracket.TabIndex = 1;
            this.rbBracket.TabStop = true;
            this.rbBracket.Text = "中括号";
            this.rbBracket.UseVisualStyleBackColor = true;
            // 
            // gb_RectIno
            // 
            this.gb_RectIno.Controls.Add(this.tb_RectHeight);
            this.gb_RectIno.Controls.Add(this.tb_RectWid);
            this.gb_RectIno.Controls.Add(this.label2);
            this.gb_RectIno.Controls.Add(this.label1);
            this.gb_RectIno.Location = new System.Drawing.Point(12, 86);
            this.gb_RectIno.Name = "gb_RectIno";
            this.gb_RectIno.Size = new System.Drawing.Size(195, 97);
            this.gb_RectIno.TabIndex = 6;
            this.gb_RectIno.TabStop = false;
            this.gb_RectIno.Text = "当前填涂块大小";
            // 
            // tb_RectHeight
            // 
            this.tb_RectHeight.Location = new System.Drawing.Point(30, 56);
            this.tb_RectHeight.Name = "tb_RectHeight";
            this.tb_RectHeight.Size = new System.Drawing.Size(100, 21);
            this.tb_RectHeight.TabIndex = 3;
            // 
            // tb_RectWid
            // 
            this.tb_RectWid.Location = new System.Drawing.Point(30, 23);
            this.tb_RectWid.Name = "tb_RectWid";
            this.tb_RectWid.Size = new System.Drawing.Size(100, 21);
            this.tb_RectWid.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "高";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "宽";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(13, 212);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "确认";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(132, 212);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // TemplateSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 262);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gb_RectIno);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateSettingForm";
            this.Text = "设置面板";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_RectIno.ResumeLayout(false);
            this.gb_RectIno.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gb_RectIno;
        private System.Windows.Forms.RadioButton rbRect;
        private System.Windows.Forms.RadioButton rbBracket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_RectHeight;
        private System.Windows.Forms.TextBox tb_RectWid;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}