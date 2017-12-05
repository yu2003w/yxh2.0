namespace YXH.Main
{
    partial class UpdateExplainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateExplainForm));
            this.txtContext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(15, 12);
            this.txtContext.Multiline = true;
            this.txtContext.Name = "txtContext";
            this.txtContext.ReadOnly = true;
            this.txtContext.Size = new System.Drawing.Size(444, 258);
            this.txtContext.TabIndex = 1;
            // 
            // UpdateExplainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 282);
            this.Controls.Add(this.txtContext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateExplainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "更新说明";
            this.Load += new System.EventHandler(this.UpdateExplainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContext;
    }
}