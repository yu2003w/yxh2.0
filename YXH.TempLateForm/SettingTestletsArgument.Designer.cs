namespace YXH.TemplateForm
{
    partial class SettingTestletsArgument
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
            this.lblOptionsNumber = new System.Windows.Forms.Label();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.cbxOptionsNumber = new System.Windows.Forms.ComboBox();
            this.cbxItemNumber = new System.Windows.Forms.ComboBox();
            this.cbxOptionsOrientation = new System.Windows.Forms.ComboBox();
            this.lblOptionsOrientation = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStartQid = new System.Windows.Forms.Label();
            this.txtStartQid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblOptionsNumber
            // 
            this.lblOptionsNumber.AutoSize = true;
            this.lblOptionsNumber.Location = new System.Drawing.Point(45, 15);
            this.lblOptionsNumber.Name = "lblOptionsNumber";
            this.lblOptionsNumber.Size = new System.Drawing.Size(41, 12);
            this.lblOptionsNumber.TabIndex = 0;
            this.lblOptionsNumber.Text = "列数：";
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Location = new System.Drawing.Point(45, 41);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(41, 12);
            this.lblItemNumber.TabIndex = 1;
            this.lblItemNumber.Text = "行数：";
            // 
            // cbxOptionsNumber
            // 
            this.cbxOptionsNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOptionsNumber.FormattingEnabled = true;
            this.cbxOptionsNumber.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbxOptionsNumber.Location = new System.Drawing.Point(104, 12);
            this.cbxOptionsNumber.Name = "cbxOptionsNumber";
            this.cbxOptionsNumber.Size = new System.Drawing.Size(121, 20);
            this.cbxOptionsNumber.TabIndex = 2;
            // 
            // cbxItemNumber
            // 
            this.cbxItemNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItemNumber.FormattingEnabled = true;
            this.cbxItemNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbxItemNumber.Location = new System.Drawing.Point(104, 38);
            this.cbxItemNumber.Name = "cbxItemNumber";
            this.cbxItemNumber.Size = new System.Drawing.Size(121, 20);
            this.cbxItemNumber.TabIndex = 3;
            // 
            // cbxOptionsOrientation
            // 
            this.cbxOptionsOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOptionsOrientation.FormattingEnabled = true;
            this.cbxOptionsOrientation.Items.AddRange(new object[] {
            "横向",
            "纵向"});
            this.cbxOptionsOrientation.Location = new System.Drawing.Point(104, 64);
            this.cbxOptionsOrientation.Name = "cbxOptionsOrientation";
            this.cbxOptionsOrientation.Size = new System.Drawing.Size(121, 20);
            this.cbxOptionsOrientation.TabIndex = 4;
            // 
            // lblOptionsOrientation
            // 
            this.lblOptionsOrientation.AutoSize = true;
            this.lblOptionsOrientation.Location = new System.Drawing.Point(9, 67);
            this.lblOptionsOrientation.Name = "lblOptionsOrientation";
            this.lblOptionsOrientation.Size = new System.Drawing.Size(89, 12);
            this.lblOptionsOrientation.TabIndex = 5;
            this.lblOptionsOrientation.Text = "选项排列方向：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(69, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStartQid
            // 
            this.lblStartQid.AutoSize = true;
            this.lblStartQid.Location = new System.Drawing.Point(33, 93);
            this.lblStartQid.Name = "lblStartQid";
            this.lblStartQid.Size = new System.Drawing.Size(65, 12);
            this.lblStartQid.TabIndex = 9;
            this.lblStartQid.Text = "开始题号：";
            // 
            // txtStartQid
            // 
            this.txtStartQid.Location = new System.Drawing.Point(104, 90);
            this.txtStartQid.Name = "txtStartQid";
            this.txtStartQid.Size = new System.Drawing.Size(73, 21);
            this.txtStartQid.TabIndex = 10;
            // 
            // SettingTestletsArgument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 152);
            this.Controls.Add(this.txtStartQid);
            this.Controls.Add(this.lblStartQid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblOptionsOrientation);
            this.Controls.Add(this.cbxOptionsOrientation);
            this.Controls.Add(this.cbxItemNumber);
            this.Controls.Add(this.cbxOptionsNumber);
            this.Controls.Add(this.lblItemNumber);
            this.Controls.Add(this.lblOptionsNumber);
            this.Name = "SettingTestletsArgument";
            this.Text = "设置题组参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lblOptionsNumber;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.ComboBox cbxOptionsNumber;
        private System.Windows.Forms.ComboBox cbxItemNumber;
        private System.Windows.Forms.ComboBox cbxOptionsOrientation;
        private System.Windows.Forms.Label lblOptionsOrientation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStartQid;
        private System.Windows.Forms.TextBox txtStartQid;
        #endregion
    }
}