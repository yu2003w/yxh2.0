using System.Drawing;
using System.Windows.Forms;
namespace YXH.Common.Form
{
    partial class DataGridViewShowForm
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.dg_DataShow = new YXH.Common.Form.DataGridViewEx();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_DataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel_top.Controls.Add(this.button1);
            this.panel_top.Controls.Add(this.btn_export);
            this.panel_top.Controls.Add(this.lbl_Title);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(984, 38);
            this.panel_top.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Location = new System.Drawing.Point(12, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_export
            // 
            this.btn_export.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_export.Location = new System.Drawing.Point(74, 9);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(53, 23);
            this.btn_export.TabIndex = 3;
            this.btn_export.Text = "导出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Title.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(984, 38);
            this.lbl_Title.TabIndex = 5;
            this.lbl_Title.Text = "统计查看";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dg_DataShow
            // 
            this.dg_DataShow.AllowUserToAddRows = false;
            this.dg_DataShow.AllowUserToDeleteRows = false;
            this.dg_DataShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_DataShow.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dg_DataShow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dg_DataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_DataShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_DataShow.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dg_DataShow.Location = new System.Drawing.Point(0, 38);
            this.dg_DataShow.Name = "dg_DataShow";
            this.dg_DataShow.ReadOnly = true;
            this.dg_DataShow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dg_DataShow.RowTemplate.Height = 23;
            this.dg_DataShow.Size = new System.Drawing.Size(984, 424);
            this.dg_DataShow.TabIndex = 0;
            // 
            // DataGridViewShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.dg_DataShow);
            this.Controls.Add(this.panel_top);
            this.Name = "DataGridViewShowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "统计查看";
            this.panel_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_DataShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewEx dg_DataShow;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_Title;
    }
}