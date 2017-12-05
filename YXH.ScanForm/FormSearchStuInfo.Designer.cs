using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class FormSearchStuInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.trlUser = new DevExpress.XtraTreeList.TreeList();
            this.trcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcSchoolNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcBatchId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcBatchIndex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcUserID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcpingying = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcStatusCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pnlSearchZkzhTop = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.txtSearchSchoolnumber = new System.Windows.Forms.TextBox();
            this.lblpinyin = new System.Windows.Forms.Label();
            this.lblZkzh = new System.Windows.Forms.Label();
            this.txtSearchPingyin = new System.Windows.Forms.TextBox();
            this.lblSearchTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trcIsLeakNode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlUser)).BeginInit();
            this.pnlSearchZkzhTop.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.trlUser);
            this.panel1.Controls.Add(this.pnlSearchZkzhTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 462);
            this.panel1.TabIndex = 0;
            // 
            // trlUser
            // 
            this.trlUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.trlUser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trcName,
            this.trcSchoolNumber,
            this.trcBatchId,
            this.trcBatchIndex,
            this.trcUserID,
            this.trcStatus,
            this.trcpingying,
            this.trcStatusCode});
            this.trlUser.CustomizationFormBounds = new System.Drawing.Rectangle(966, 415, 216, 187);
            this.trlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlUser.Location = new System.Drawing.Point(0, 176);
            this.trlUser.Name = "trlUser";
            this.trlUser.OptionsBehavior.PopulateServiceColumns = true;
            this.trlUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.trlUser.Size = new System.Drawing.Size(434, 286);
            this.trlUser.TabIndex = 12;
            this.trlUser.DoubleClick += new System.EventHandler(this.trlUser_DoubleClick);
            // 
            // trcName
            // 
            this.trcName.Caption = "姓名";
            this.trcName.FieldName = "name";
            this.trcName.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
            this.trcName.Name = "trcName";
            this.trcName.OptionsColumn.AllowEdit = false;
            this.trcName.OptionsColumn.ReadOnly = true;
            this.trcName.Visible = true;
            this.trcName.VisibleIndex = 0;
            this.trcName.Width = 61;
            // 
            // trcSchoolNumber
            // 
            this.trcSchoolNumber.Caption = "考号";
            this.trcSchoolNumber.FieldName = "schoolnnumber";
            this.trcSchoolNumber.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
            this.trcSchoolNumber.Name = "trcSchoolNumber";
            this.trcSchoolNumber.OptionsColumn.AllowEdit = false;
            this.trcSchoolNumber.OptionsColumn.ReadOnly = true;
            this.trcSchoolNumber.Visible = true;
            this.trcSchoolNumber.VisibleIndex = 1;
            this.trcSchoolNumber.Width = 63;
            // 
            // trcBatchId
            // 
            this.trcBatchId.Caption = "批次";
            this.trcBatchId.FieldName = "BatchId";
            this.trcBatchId.Name = "trcBatchId";
            this.trcBatchId.OptionsColumn.AllowEdit = false;
            this.trcBatchId.OptionsColumn.ReadOnly = true;
            this.trcBatchId.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.trcBatchId.Visible = true;
            this.trcBatchId.VisibleIndex = 3;
            this.trcBatchId.Width = 70;
            // 
            // trcBatchIndex
            // 
            this.trcBatchIndex.Caption = "序号";
            this.trcBatchIndex.FieldName = "BatchIndex";
            this.trcBatchIndex.Name = "trcBatchIndex";
            this.trcBatchIndex.OptionsColumn.AllowEdit = false;
            this.trcBatchIndex.OptionsColumn.ReadOnly = true;
            this.trcBatchIndex.Visible = true;
            this.trcBatchIndex.VisibleIndex = 4;
            this.trcBatchIndex.Width = 56;
            // 
            // trcUserID
            // 
            this.trcUserID.FieldName = "id";
            this.trcUserID.Name = "trcUserID";
            // 
            // trcStatus
            // 
            this.trcStatus.Caption = "状态";
            this.trcStatus.FieldName = "Status";
            this.trcStatus.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
            this.trcStatus.Name = "trcStatus";
            this.trcStatus.OptionsColumn.AllowEdit = false;
            this.trcStatus.OptionsColumn.ReadOnly = true;
            this.trcStatus.Visible = true;
            this.trcStatus.VisibleIndex = 2;
            this.trcStatus.Width = 68;
            // 
            // trcpingying
            // 
            this.trcpingying.FieldName = "pinyinIntial";
            this.trcpingying.Name = "trcpingying";
            this.trcpingying.OptionsColumn.AllowEdit = false;
            this.trcpingying.OptionsColumn.ReadOnly = true;
            // 
            // trcStatusCode
            // 
            this.trcStatusCode.FieldName = "StatusCode";
            this.trcStatusCode.Name = "trcStatusCode";
            // 
            // pnlSearchZkzhTop
            // 
            this.pnlSearchZkzhTop.Controls.Add(this.btn_Cancel);
            this.pnlSearchZkzhTop.Controls.Add(this.tableLayoutPanel3);
            this.pnlSearchZkzhTop.Controls.Add(this.lblSearchTotal);
            this.pnlSearchZkzhTop.Controls.Add(this.label2);
            this.pnlSearchZkzhTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchZkzhTop.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchZkzhTop.Name = "pnlSearchZkzhTop";
            this.pnlSearchZkzhTop.Size = new System.Drawing.Size(434, 176);
            this.pnlSearchZkzhTop.TabIndex = 10;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 10F);
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Cancel.Image = global::YXH.ScanForm.FormSearchStuInfoRes.btn_Cancel_Image;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.Location = new System.Drawing.Point(360, 130);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(62, 35);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "返回";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel3.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSearchName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSearchSchoolnumber, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblpinyin, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblZkzh, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtSearchPingyin, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(434, 75);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "姓名:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchName.Location = new System.Drawing.Point(73, 3);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(260, 21);
            this.txtSearchName.TabIndex = 0;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            this.txtSearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchEnter_KeyDown);
            // 
            // txtSearchSchoolnumber
            // 
            this.txtSearchSchoolnumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchSchoolnumber.Location = new System.Drawing.Point(73, 28);
            this.txtSearchSchoolnumber.Name = "txtSearchSchoolnumber";
            this.txtSearchSchoolnumber.Size = new System.Drawing.Size(260, 21);
            this.txtSearchSchoolnumber.TabIndex = 1;
            this.txtSearchSchoolnumber.TextChanged += new System.EventHandler(this.txtSearchSchoolnumber_TextChanged);
            this.txtSearchSchoolnumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchEnter_KeyDown);
            // 
            // lblpinyin
            // 
            this.lblpinyin.AutoSize = true;
            this.lblpinyin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblpinyin.Location = new System.Drawing.Point(3, 50);
            this.lblpinyin.Name = "lblpinyin";
            this.lblpinyin.Size = new System.Drawing.Size(64, 25);
            this.lblpinyin.TabIndex = 1;
            this.lblpinyin.Text = "拼音简写:";
            this.lblpinyin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblZkzh
            // 
            this.lblZkzh.AutoSize = true;
            this.lblZkzh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZkzh.Location = new System.Drawing.Point(3, 25);
            this.lblZkzh.Name = "lblZkzh";
            this.lblZkzh.Size = new System.Drawing.Size(64, 25);
            this.lblZkzh.TabIndex = 5;
            this.lblZkzh.Text = "考号:";
            this.lblZkzh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchPingyin
            // 
            this.txtSearchPingyin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchPingyin.Location = new System.Drawing.Point(73, 53);
            this.txtSearchPingyin.Name = "txtSearchPingyin";
            this.txtSearchPingyin.Size = new System.Drawing.Size(260, 21);
            this.txtSearchPingyin.TabIndex = 2;
            this.txtSearchPingyin.TextChanged += new System.EventHandler(this.txtSearchPingyin_TextChanged);
            this.txtSearchPingyin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchEnter_KeyDown);
            // 
            // lblSearchTotal
            // 
            this.lblSearchTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearchTotal.AutoSize = true;
            this.lblSearchTotal.Location = new System.Drawing.Point(3, 157);
            this.lblSearchTotal.Name = "lblSearchTotal";
            this.lblSearchTotal.Size = new System.Drawing.Size(59, 12);
            this.lblSearchTotal.TabIndex = 6;
            this.lblSearchTotal.Text = "合计{0}份";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 49);
            this.label2.TabIndex = 7;
            this.label2.Text = "温馨提示：\r\n1.可通过学生中文姓名，考号或拼音首字母快速查询\r\n2.双击选中的学生，可跳转到该学生已扫描的试卷界面";
            // 
            // trcIsLeakNode
            // 
            this.trcIsLeakNode.FieldName = "trcStatus";
            this.trcIsLeakNode.Name = "trcIsLeakNode";
            // 
            // FormSearchStuInfo
            // 
            this.ClientSize = new System.Drawing.Size(434, 462);
            this.Controls.Add(this.panel1);
            this.Icon = global::YXH.ScanForm.FormSearchStuInfoRes.this_Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 500);
            this.Name = "FormSearchStuInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.FormSearchStuInfo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlUser)).EndInit();
            this.pnlSearchZkzhTop.ResumeLayout(false);
            this.pnlSearchZkzhTop.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel panel1;

        private Panel pnlSearchZkzhTop;

        private Button btn_Cancel;

        private TableLayoutPanel tableLayoutPanel3;

        private Label lblName;

        private TextBox txtSearchName;

        private TextBox txtSearchSchoolnumber;

        private Label lblpinyin;

        private Label lblZkzh;

        private TextBox txtSearchPingyin;

        private Label lblSearchTotal;

        private TreeList trlUser;

        private TreeListColumn trcName;

        private TreeListColumn trcSchoolNumber;

        private TreeListColumn trcBatchId;

        private TreeListColumn trcBatchIndex;

        private TreeListColumn trcUserID;

        private TreeListColumn trcStatus;

        private TreeListColumn trcpingying;

        private TreeListColumn trcIsLeakNode;

        private TreeListColumn trcStatusCode;

        private Label label2;

        #endregion
    }
}