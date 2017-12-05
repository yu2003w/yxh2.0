using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class FormLeakCheck
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
            this.grvSource = new System.Windows.Forms.DataGridView();
            this.Columnzkzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNotScanReason = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvSource
            // 
            this.grvSource.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.grvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnzkzh,
            this.ColumnName,
            this.classname,
            this.room,
            this.orderID,
            this.ColNotScanReason,
            this.UseID});
            this.grvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvSource.Location = new System.Drawing.Point(0, 29);
            this.grvSource.Name = "grvSource";
            this.grvSource.RowHeadersWidth = 16;
            this.grvSource.RowTemplate.Height = 23;
            this.grvSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grvSource.Size = new System.Drawing.Size(620, 234);
            this.grvSource.TabIndex = 1;
            // 
            // Columnzkzh
            // 
            this.Columnzkzh.DataPropertyName = "zkzh";
            this.Columnzkzh.HeaderText = "考号";
            this.Columnzkzh.Name = "Columnzkzh";
            this.Columnzkzh.ReadOnly = true;
            this.Columnzkzh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "studentname";
            this.ColumnName.HeaderText = "姓名";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // classname
            // 
            this.classname.DataPropertyName = "classname";
            this.classname.HeaderText = "班级";
            this.classname.Name = "classname";
            // 
            // room
            // 
            this.room.DataPropertyName = "room";
            this.room.HeaderText = "考场";
            this.room.Name = "room";
            this.room.ReadOnly = true;
            this.room.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // orderID
            // 
            this.orderID.DataPropertyName = "orderid";
            this.orderID.HeaderText = "考场座号";
            this.orderID.Name = "orderID";
            this.orderID.ReadOnly = true;
            this.orderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColNotScanReason
            // 
            this.ColNotScanReason.AutoComplete = false;
            this.ColNotScanReason.DataPropertyName = "result";
            this.ColNotScanReason.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColNotScanReason.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ColNotScanReason.HeaderText = "未扫原因";
            this.ColNotScanReason.Items.AddRange(new object[] {
            "缺考",
            "人工阅卷"});
            this.ColNotScanReason.Name = "ColNotScanReason";
            this.ColNotScanReason.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // UseID
            // 
            this.UseID.DataPropertyName = "userid";
            this.UseID.HeaderText = "用户ID";
            this.UseID.Name = "UseID";
            this.UseID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UseID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(620, 29);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 263);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(620, 37);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(515, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormLeakCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 300);
            this.Controls.Add(this.grvSource);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Icon = global::YXH.ScanForm.FormLeakCheckRes.formLeakCheck_Icon;
            this.Name = "FormLeakCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "漏扫检查";
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private DataGridView grvSource;

        private Label label1;

        private Panel pnlTop;

        private Panel pnlBottom;

        private Button btnSave;

        private DataGridViewTextBoxColumn Columnzkzh;

        private DataGridViewTextBoxColumn ColumnName;

        private DataGridViewTextBoxColumn classname;

        private DataGridViewTextBoxColumn room;

        private DataGridViewTextBoxColumn orderID;

        private DataGridViewComboBoxColumn ColNotScanReason;

        private DataGridViewTextBoxColumn UseID;

        #endregion
    }
}