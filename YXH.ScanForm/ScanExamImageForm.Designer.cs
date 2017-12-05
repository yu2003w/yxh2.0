using DevExpress.Utils;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking.Helpers;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Columns;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class ScanExamImageForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlpic = new System.Windows.Forms.Panel();
            this.picFront = new System.Windows.Forms.PictureBox();
            this.cms_picpanel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_cmsCurrentImageInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_cmsCopyImages = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_cmsAdjustImage = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_ErrorInform = new System.Windows.Forms.Panel();
            this.lbl_ErrorDetails = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlSearchZkzhTop = new System.Windows.Forms.Panel();
            this.btn_Delete_zkzh = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.txtSearchSchoolnumber = new System.Windows.Forms.TextBox();
            this.lblpinyin = new System.Windows.Forms.Label();
            this.lblZkzh = new System.Windows.Forms.Label();
            this.txtSearchPingyin = new System.Windows.Forms.TextBox();
            this.btn_LaterDw_ZkzhTab = new System.Windows.Forms.Button();
            this.lblSearchTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOmrSave = new System.Windows.Forms.Button();
            this.btn_LaterDw_OmrTab = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_AjustImage = new System.Windows.Forms.Button();
            this.btn_DeletePaperError = new System.Windows.Forms.Button();
            this.btn_ManualModify = new System.Windows.Forms.Button();
            this.btn_LaterDw_PEtab = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trlLeakUser = new DevExpress.XtraTreeList.TreeList();
            this.trcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcRoom = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcClassName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcUserID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcClassid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcpingying = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcExamCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.dockModify = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpModify = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.xtcRightDocker = new DevExpress.XtraTab.XtraTabControl();
            this.tabZkzhModify = new DevExpress.XtraTab.XtraTabPage();
            this.ricLeakInfo = new System.Windows.Forms.RichTextBox();
            this.tabOmrModify = new DevExpress.XtraTab.XtraTabPage();
            this.trlOmrList = new DevExpress.XtraTreeList.TreeList();
            this.trcObjectNum = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcAnswer = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcItemCount = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcPageindex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcRect = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcMultiSelect = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcModifyStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcCheckStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcOmrValType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcOmrAnswer = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tabErrorPaperManager = new DevExpress.XtraTab.XtraTabPage();
            this.ricOmrAnswer = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.pnlpic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFront)).BeginInit();
            this.cms_picpanel.SuspendLayout();
            this.panel_ErrorInform.SuspendLayout();
            this.pnlSearchZkzhTop.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlLeakUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockModify)).BeginInit();
            this.dpModify.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcRightDocker)).BeginInit();
            this.xtcRightDocker.SuspendLayout();
            this.tabZkzhModify.SuspendLayout();
            this.tabOmrModify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlOmrList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcOmrAnswer)).BeginInit();
            this.tabErrorPaperManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ricOmrAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlpic
            // 
            this.pnlpic.AutoScroll = true;
            this.pnlpic.BackColor = System.Drawing.Color.White;
            this.pnlpic.Controls.Add(this.picFront);
            this.pnlpic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlpic.Location = new System.Drawing.Point(0, 0);
            this.pnlpic.Name = "pnlpic";
            this.pnlpic.Size = new System.Drawing.Size(424, 402);
            this.pnlpic.TabIndex = 7;
            // 
            // picFront
            // 
            this.picFront.BackColor = System.Drawing.Color.White;
            this.picFront.ContextMenuStrip = this.cms_picpanel;
            this.picFront.Location = new System.Drawing.Point(3, 3);
            this.picFront.Name = "picFront";
            this.picFront.Size = new System.Drawing.Size(817, 463);
            this.picFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFront.TabIndex = 1;
            this.picFront.TabStop = false;
            this.picFront.Click += new System.EventHandler(this.picFront_Click);
            this.picFront.Paint += new System.Windows.Forms.PaintEventHandler(this.picFront_Paint);
            this.picFront.DoubleClick += new System.EventHandler(this.picFront_DoubleClick);
            this.picFront.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picFront_MouseDown);
            this.picFront.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picFront_MouseMove);
            // 
            // cms_picpanel
            // 
            this.cms_picpanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_cmsCurrentImageInfo,
            this.btn_cmsCopyImages,
            this.btn_cmsAdjustImage});
            this.cms_picpanel.Name = "cms_picpanel";
            this.cms_picpanel.Size = new System.Drawing.Size(149, 70);
            // 
            // btn_cmsCurrentImageInfo
            // 
            this.btn_cmsCurrentImageInfo.Name = "btn_cmsCurrentImageInfo";
            this.btn_cmsCurrentImageInfo.Size = new System.Drawing.Size(148, 22);
            this.btn_cmsCurrentImageInfo.Text = "当前图片信息";
            this.btn_cmsCurrentImageInfo.Click += new System.EventHandler(this.btn_cmsCurrentImageInfo_Click);
            // 
            // btn_cmsCopyImages
            // 
            this.btn_cmsCopyImages.Name = "btn_cmsCopyImages";
            this.btn_cmsCopyImages.Size = new System.Drawing.Size(148, 22);
            this.btn_cmsCopyImages.Text = "复制试卷图片";
            this.btn_cmsCopyImages.Click += new System.EventHandler(this.btn_cmsCopyImages_Click);
            // 
            // btn_cmsAdjustImage
            // 
            this.btn_cmsAdjustImage.Name = "btn_cmsAdjustImage";
            this.btn_cmsAdjustImage.Size = new System.Drawing.Size(148, 22);
            this.btn_cmsAdjustImage.Text = "调整图片";
            this.btn_cmsAdjustImage.Click += new System.EventHandler(this.btn_cmsAdjustImage_Click);
            // 
            // panel_ErrorInform
            // 
            this.panel_ErrorInform.Controls.Add(this.lbl_ErrorDetails);
            this.panel_ErrorInform.Controls.Add(this.label7);
            this.panel_ErrorInform.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ErrorInform.Location = new System.Drawing.Point(0, 0);
            this.panel_ErrorInform.Name = "panel_ErrorInform";
            this.panel_ErrorInform.Size = new System.Drawing.Size(200, 32);
            this.panel_ErrorInform.TabIndex = 2;
            // 
            // lbl_ErrorDetails
            // 
            this.lbl_ErrorDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ErrorDetails.AutoSize = true;
            this.lbl_ErrorDetails.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_ErrorDetails.ForeColor = System.Drawing.Color.Red;
            this.lbl_ErrorDetails.Location = new System.Drawing.Point(82, 9);
            this.lbl_ErrorDetails.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_ErrorDetails.Name = "lbl_ErrorDetails";
            this.lbl_ErrorDetails.Size = new System.Drawing.Size(72, 16);
            this.lbl_ErrorDetails.TabIndex = 1;
            this.lbl_ErrorDetails.Text = "详细信息";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "异常原因：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearchZkzhTop
            // 
            this.pnlSearchZkzhTop.Controls.Add(this.btn_Delete_zkzh);
            this.pnlSearchZkzhTop.Controls.Add(this.tableLayoutPanel3);
            this.pnlSearchZkzhTop.Controls.Add(this.btn_LaterDw_ZkzhTab);
            this.pnlSearchZkzhTop.Controls.Add(this.lblSearchTotal);
            this.pnlSearchZkzhTop.Controls.Add(this.label2);
            this.pnlSearchZkzhTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchZkzhTop.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchZkzhTop.Name = "pnlSearchZkzhTop";
            this.pnlSearchZkzhTop.Size = new System.Drawing.Size(279, 186);
            this.pnlSearchZkzhTop.TabIndex = 9;
            // 
            // btn_Delete_zkzh
            // 
            this.btn_Delete_zkzh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete_zkzh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Delete_zkzh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete_zkzh.Location = new System.Drawing.Point(195, 159);
            this.btn_Delete_zkzh.Name = "btn_Delete_zkzh";
            this.btn_Delete_zkzh.Size = new System.Drawing.Size(81, 23);
            this.btn_Delete_zkzh.TabIndex = 9;
            this.btn_Delete_zkzh.Text = "删除";
            this.btn_Delete_zkzh.UseVisualStyleBackColor = true;
            this.btn_Delete_zkzh.Click += new System.EventHandler(this.btn_Delete_zkzh_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSearchName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSearchSchoolnumber, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblpinyin, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblZkzh, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtSearchPingyin, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(279, 75);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "姓名:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchName.Location = new System.Drawing.Point(72, 3);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(147, 21);
            this.txtSearchName.TabIndex = 0;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            this.txtSearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchEnter_KeyDown);
            // 
            // txtSearchSchoolnumber
            // 
            this.txtSearchSchoolnumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchSchoolnumber.Location = new System.Drawing.Point(72, 28);
            this.txtSearchSchoolnumber.Name = "txtSearchSchoolnumber";
            this.txtSearchSchoolnumber.Size = new System.Drawing.Size(147, 21);
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
            this.lblpinyin.Size = new System.Drawing.Size(63, 25);
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
            this.lblZkzh.Size = new System.Drawing.Size(63, 25);
            this.lblZkzh.TabIndex = 5;
            this.lblZkzh.Text = "考号:";
            this.lblZkzh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchPingyin
            // 
            this.txtSearchPingyin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchPingyin.Location = new System.Drawing.Point(72, 53);
            this.txtSearchPingyin.Name = "txtSearchPingyin";
            this.txtSearchPingyin.Size = new System.Drawing.Size(147, 21);
            this.txtSearchPingyin.TabIndex = 2;
            this.txtSearchPingyin.TextChanged += new System.EventHandler(this.txtSearchPingyin_TextChanged);
            this.txtSearchPingyin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchEnter_KeyDown);
            // 
            // btn_LaterDw_ZkzhTab
            // 
            this.btn_LaterDw_ZkzhTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LaterDw_ZkzhTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_LaterDw_ZkzhTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LaterDw_ZkzhTab.Location = new System.Drawing.Point(102, 160);
            this.btn_LaterDw_ZkzhTab.Name = "btn_LaterDw_ZkzhTab";
            this.btn_LaterDw_ZkzhTab.Size = new System.Drawing.Size(81, 23);
            this.btn_LaterDw_ZkzhTab.TabIndex = 8;
            this.btn_LaterDw_ZkzhTab.Text = "稍后处理";
            this.btn_LaterDw_ZkzhTab.UseVisualStyleBackColor = true;
            // 
            // lblSearchTotal
            // 
            this.lblSearchTotal.AutoSize = true;
            this.lblSearchTotal.Location = new System.Drawing.Point(3, 171);
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
            this.label2.Size = new System.Drawing.Size(279, 78);
            this.label2.TabIndex = 7;
            this.label2.Text = "注意：\r\n1.输入拼音首字母可快速搜索(如:周波:ZB)。\r\n2.双击列表考生将自动关联选择的错号。\r\n3.输入名字,考号,拼音简写,找到考生后，\r\n  按回车将" +
    "自动关联选择的错号。";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 176);
            this.panel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 137);
            this.label3.TabIndex = 15;
            this.label3.Text = "温馨提示：\r\n1.红色：没识别到填涂值 \r\n\r\n2.黄色：识别到可疑填涂值\r\n\r\n3.可通过点击图片填涂项或键盘输入A~Z修改答案。\r\n\r\n4.点击”稍后处理“，" +
    "可逐个浏览客观题异常类型的所有试卷。";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnOmrSave, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_LaterDw_OmrTab, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 140);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(279, 36);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // btnOmrSave
            // 
            this.btnOmrSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOmrSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOmrSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOmrSave.Location = new System.Drawing.Point(3, 3);
            this.btnOmrSave.Name = "btnOmrSave";
            this.btnOmrSave.Size = new System.Drawing.Size(133, 30);
            this.btnOmrSave.TabIndex = 13;
            this.btnOmrSave.Text = "保存(Ctrl+S)";
            this.btnOmrSave.UseVisualStyleBackColor = true;
            this.btnOmrSave.Click += new System.EventHandler(this.btnOmrSave_Click);
            // 
            // btn_LaterDw_OmrTab
            // 
            this.btn_LaterDw_OmrTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_LaterDw_OmrTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_LaterDw_OmrTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LaterDw_OmrTab.Location = new System.Drawing.Point(142, 3);
            this.btn_LaterDw_OmrTab.Name = "btn_LaterDw_OmrTab";
            this.btn_LaterDw_OmrTab.Size = new System.Drawing.Size(134, 30);
            this.btn_LaterDw_OmrTab.TabIndex = 14;
            this.btn_LaterDw_OmrTab.Text = "稍后处理";
            this.btn_LaterDw_OmrTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 344);
            this.panel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_AjustImage, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_DeletePaperError, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_ManualModify, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_LaterDw_PEtab, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 261);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(279, 83);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // btn_AjustImage
            // 
            this.btn_AjustImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_AjustImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_AjustImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AjustImage.Location = new System.Drawing.Point(3, 44);
            this.btn_AjustImage.Name = "btn_AjustImage";
            this.btn_AjustImage.Size = new System.Drawing.Size(133, 36);
            this.btn_AjustImage.TabIndex = 17;
            this.btn_AjustImage.Text = "调整图片";
            this.btn_AjustImage.UseVisualStyleBackColor = true;
            this.btn_AjustImage.Click += new System.EventHandler(this.btn_cmsAdjustImage_Click);
            // 
            // btn_DeletePaperError
            // 
            this.btn_DeletePaperError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_DeletePaperError.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_DeletePaperError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeletePaperError.Location = new System.Drawing.Point(142, 44);
            this.btn_DeletePaperError.Name = "btn_DeletePaperError";
            this.btn_DeletePaperError.Size = new System.Drawing.Size(134, 36);
            this.btn_DeletePaperError.TabIndex = 16;
            this.btn_DeletePaperError.Text = "删除";
            this.btn_DeletePaperError.UseVisualStyleBackColor = true;
            // 
            // btn_ManualModify
            // 
            this.btn_ManualModify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ManualModify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_ManualModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ManualModify.Location = new System.Drawing.Point(3, 3);
            this.btn_ManualModify.Name = "btn_ManualModify";
            this.btn_ManualModify.Size = new System.Drawing.Size(133, 35);
            this.btn_ManualModify.TabIndex = 10;
            this.btn_ManualModify.Text = "人工标记";
            this.btn_ManualModify.UseVisualStyleBackColor = true;
            this.btn_ManualModify.Click += new System.EventHandler(this.btn_ManualModifgy_Click);
            // 
            // btn_LaterDw_PEtab
            // 
            this.btn_LaterDw_PEtab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_LaterDw_PEtab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_LaterDw_PEtab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LaterDw_PEtab.Location = new System.Drawing.Point(142, 3);
            this.btn_LaterDw_PEtab.Name = "btn_LaterDw_PEtab";
            this.btn_LaterDw_PEtab.Size = new System.Drawing.Size(134, 35);
            this.btn_LaterDw_PEtab.TabIndex = 12;
            this.btn_LaterDw_PEtab.Text = "稍后处理";
            this.btn_LaterDw_PEtab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(279, 258);
            this.label1.TabIndex = 9;
            // 
            // trlLeakUser
            // 
            this.trlLeakUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.trlLeakUser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trcName,
            this.trcRoom,
            this.trcClassName,
            this.trcUserID,
            this.trcClassid,
            this.trcpingying,
            this.trcExamCode});
            this.trlLeakUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlLeakUser.Location = new System.Drawing.Point(0, 186);
            this.trlLeakUser.Name = "trlLeakUser";
            this.trlLeakUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.trlLeakUser.Size = new System.Drawing.Size(279, 133);
            this.trlLeakUser.TabIndex = 11;
            this.trlLeakUser.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlLeakUser_FocusedNodeChanged);
            this.trlLeakUser.DoubleClick += new System.EventHandler(this.trlLeakUser_DoubleClick);
            this.trlLeakUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trlLeakUser_KeyPress);
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
            this.trcName.Width = 73;
            // 
            // trcRoom
            // 
            this.trcRoom.FieldName = "Room";
            this.trcRoom.Name = "trcRoom";
            // 
            // trcClassName
            // 
            this.trcClassName.FieldName = "ClassName";
            this.trcClassName.Name = "trcClassName";
            // 
            // trcUserID
            // 
            this.trcUserID.FieldName = "id";
            this.trcUserID.Name = "trcUserID";
            // 
            // trcClassid
            // 
            this.trcClassid.FieldName = "ClassID";
            this.trcClassid.Name = "trcClassid";
            // 
            // trcpingying
            // 
            this.trcpingying.FieldName = "pinyinIntial";
            this.trcpingying.Name = "trcpingying";
            this.trcpingying.OptionsColumn.AllowEdit = false;
            this.trcpingying.OptionsColumn.ReadOnly = true;
            // 
            // trcExamCode
            // 
            this.trcExamCode.Caption = "考号";
            this.trcExamCode.FieldName = "ExamCode";
            this.trcExamCode.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
            this.trcExamCode.Name = "trcExamCode";
            this.trcExamCode.OptionsColumn.AllowEdit = false;
            this.trcExamCode.OptionsColumn.ReadOnly = true;
            this.trcExamCode.Visible = true;
            this.trcExamCode.VisibleIndex = 1;
            this.trcExamCode.Width = 79;
            // 
            // dockModify
            // 
            this.dockModify.DockMode = DevExpress.XtraBars.Docking.Helpers.DockMode.Standard;
            this.dockModify.Form = this;
            this.dockModify.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpModify});
            this.dockModify.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            this.dockModify.ValidateFloatFormChildrenOnDeactivate = false;
            // 
            // dpModify
            // 
            this.dpModify.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.dpModify.Appearance.Options.UseBackColor = true;
            this.dpModify.Controls.Add(this.dockPanel1_Container);
            this.dpModify.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpModify.ID = new System.Guid("1f9366ae-ffce-4b58-a44b-ebaaa1fffcc8");
            this.dpModify.Location = new System.Drawing.Point(424, 0);
            this.dpModify.Name = "dpModify";
            this.dpModify.Options.AllowFloating = false;
            this.dpModify.Options.FloatOnDblClick = false;
            this.dpModify.Options.ShowAutoHideButton = false;
            this.dpModify.Options.ShowCloseButton = false;
            this.dpModify.Options.ShowMaximizeButton = false;
            this.dpModify.OriginalSize = new System.Drawing.Size(293, 200);
            this.dpModify.Size = new System.Drawing.Size(293, 402);
            this.dpModify.Text = "异常卷处理面板";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.xtcRightDocker);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(285, 375);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // xtcRightDocker
            // 
            this.xtcRightDocker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcRightDocker.Location = new System.Drawing.Point(0, 0);
            this.xtcRightDocker.Margin = new System.Windows.Forms.Padding(0);
            this.xtcRightDocker.Name = "xtcRightDocker";
            this.xtcRightDocker.SelectedTabPage = this.tabZkzhModify;
            this.xtcRightDocker.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtcRightDocker.Size = new System.Drawing.Size(285, 375);
            this.xtcRightDocker.TabIndex = 11;
            this.xtcRightDocker.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabZkzhModify,
            this.tabOmrModify,
            this.tabErrorPaperManager});
            // 
            // tabZkzhModify
            // 
            this.tabZkzhModify.Controls.Add(this.trlLeakUser);
            this.tabZkzhModify.Controls.Add(this.ricLeakInfo);
            this.tabZkzhModify.Controls.Add(this.pnlSearchZkzhTop);
            this.tabZkzhModify.Name = "tabZkzhModify";
            this.tabZkzhModify.PageVisible = false;
            this.tabZkzhModify.Size = new System.Drawing.Size(279, 346);
            this.tabZkzhModify.Text = "考号问题";
            // 
            // ricLeakInfo
            // 
            this.ricLeakInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ricLeakInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ricLeakInfo.Location = new System.Drawing.Point(0, 319);
            this.ricLeakInfo.Name = "ricLeakInfo";
            this.ricLeakInfo.Size = new System.Drawing.Size(279, 27);
            this.ricLeakInfo.TabIndex = 10;
            this.ricLeakInfo.Text = "";
            // 
            // tabOmrModify
            // 
            this.tabOmrModify.Controls.Add(this.trlOmrList);
            this.tabOmrModify.Controls.Add(this.panel3);
            this.tabOmrModify.Name = "tabOmrModify";
            this.tabOmrModify.PageVisible = false;
            this.tabOmrModify.Size = new System.Drawing.Size(279, 346);
            this.tabOmrModify.Text = "客观题存疑";
            // 
            // trlOmrList
            // 
            this.trlOmrList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trcObjectNum,
            this.trcAnswer,
            this.trcItemCount,
            this.trcPageindex,
            this.trcRect,
            this.trcMultiSelect,
            this.trcModifyStatus,
            this.trcCheckStatus,
            this.trcOmrValType});
            this.trlOmrList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlOmrList.Location = new System.Drawing.Point(0, 176);
            this.trlOmrList.Name = "trlOmrList";
            this.trlOmrList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.trcOmrAnswer});
            this.trlOmrList.Size = new System.Drawing.Size(279, 170);
            this.trlOmrList.TabIndex = 10;
            this.trlOmrList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlOmrList_FocusedNodeChanged);
            this.trlOmrList.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.trlOmrList_CustomDrawNodeIndicator);
            // 
            // trcObjectNum
            // 
            this.trcObjectNum.Caption = "题号";
            this.trcObjectNum.FieldName = "ObjectiveID";
            this.trcObjectNum.Name = "trcObjectNum";
            this.trcObjectNum.OptionsColumn.AllowEdit = false;
            this.trcObjectNum.OptionsColumn.AllowSort = false;
            this.trcObjectNum.OptionsColumn.ReadOnly = true;
            this.trcObjectNum.Visible = true;
            this.trcObjectNum.VisibleIndex = 0;
            this.trcObjectNum.Width = 53;
            // 
            // trcAnswer
            // 
            this.trcAnswer.Caption = "填涂";
            this.trcAnswer.FieldName = "Answer";
            this.trcAnswer.Name = "trcAnswer";
            this.trcAnswer.OptionsColumn.AllowEdit = false;
            this.trcAnswer.OptionsColumn.AllowFocus = false;
            this.trcAnswer.OptionsColumn.AllowSort = false;
            this.trcAnswer.OptionsColumn.ReadOnly = true;
            this.trcAnswer.Visible = true;
            this.trcAnswer.VisibleIndex = 1;
            this.trcAnswer.Width = 172;
            // 
            // trcItemCount
            // 
            this.trcItemCount.FieldName = "ItemCount";
            this.trcItemCount.Name = "trcItemCount";
            // 
            // trcPageindex
            // 
            this.trcPageindex.FieldName = "pageindex";
            this.trcPageindex.Name = "trcPageindex";
            // 
            // trcRect
            // 
            this.trcRect.FieldName = "Rects";
            this.trcRect.Name = "trcRect";
            // 
            // trcMultiSelect
            // 
            this.trcMultiSelect.FieldName = "MultiSelect";
            this.trcMultiSelect.Name = "trcMultiSelect";
            // 
            // trcModifyStatus
            // 
            this.trcModifyStatus.FieldName = "ModifyStatus";
            this.trcModifyStatus.Name = "trcModifyStatus";
            // 
            // trcCheckStatus
            // 
            this.trcCheckStatus.FieldName = "CheckStatus";
            this.trcCheckStatus.Name = "trcCheckStatus";
            // 
            // trcOmrValType
            // 
            this.trcOmrValType.FieldName = "OmrValType";
            this.trcOmrValType.Name = "trcOmrValType";
            // 
            // trcOmrAnswer
            // 
            this.trcOmrAnswer.AutoHeight = false;
            this.trcOmrAnswer.Name = "trcOmrAnswer";
            this.trcOmrAnswer.ValidateOnEnterKey = true;
            // 
            // tabErrorPaperManager
            // 
            this.tabErrorPaperManager.Controls.Add(this.panel1);
            this.tabErrorPaperManager.Name = "tabErrorPaperManager";
            this.tabErrorPaperManager.Size = new System.Drawing.Size(279, 346);
            this.tabErrorPaperManager.Text = "试卷信息异常";
            // 
            // ricOmrAnswer
            // 
            this.ricOmrAnswer.AutoHeight = false;
            this.ricOmrAnswer.Name = "ricOmrAnswer";
            this.ricOmrAnswer.ValidateOnEnterKey = true;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.ValidateOnEnterKey = true;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.ValidateOnEnterKey = true;
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            this.repositoryItemComboBox3.ValidateOnEnterKey = true;
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            this.repositoryItemComboBox4.ValidateOnEnterKey = true;
            // 
            // ScanExamImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 402);
            this.Controls.Add(this.pnlpic);
            this.Controls.Add(this.dpModify);
            this.Name = "ScanExamImageForm";
            this.Text = "ScanExamImageForm";
            this.Load += new System.EventHandler(this.ScanExamImageForm_Load);
            this.pnlpic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFront)).EndInit();
            this.cms_picpanel.ResumeLayout(false);
            this.panel_ErrorInform.ResumeLayout(false);
            this.panel_ErrorInform.PerformLayout();
            this.pnlSearchZkzhTop.ResumeLayout(false);
            this.pnlSearchZkzhTop.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlLeakUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockModify)).EndInit();
            this.dpModify.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtcRightDocker)).EndInit();
            this.xtcRightDocker.ResumeLayout(false);
            this.tabZkzhModify.ResumeLayout(false);
            this.tabOmrModify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlOmrList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcOmrAnswer)).EndInit();
            this.tabErrorPaperManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ricOmrAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlpic;
        private System.Windows.Forms.Panel pnlSearchZkzhTop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_ErrorInform;
        private System.Windows.Forms.PictureBox picFront;
        private DevExpress.XtraBars.Docking.DockManager dockModify;
        private DevExpress.XtraBars.Docking.DockPanel dpModify;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricOmrAnswer;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox trcOmrAnswer;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox4;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraTreeList.TreeList trlLeakUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_ErrorDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblpinyin;
        private System.Windows.Forms.Label lblZkzh;
        private System.Windows.Forms.Label lblSearchTotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtSearchPingyin;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.TextBox txtSearchSchoolnumber;
        private System.Windows.Forms.RichTextBox ricLeakInfo;
        private DevExpress.XtraTreeList.TreeList trlOmrList;

        private DevExpress.XtraTab.XtraTabControl xtcRightDocker;
        private DevExpress.XtraTab.XtraTabPage tabErrorPaperManager;
        private DevExpress.XtraTab.XtraTabPage tabZkzhModify;
        private DevExpress.XtraTab.XtraTabPage tabOmrModify;
        private System.Windows.Forms.Button btn_DeletePaperError;
        private System.Windows.Forms.Button btn_Delete_zkzh;
        private System.Windows.Forms.Button btn_AjustImage;
        private System.Windows.Forms.Button btn_LaterDw_OmrTab;
        private System.Windows.Forms.Button btnOmrSave;
        private System.Windows.Forms.Button btn_LaterDw_ZkzhTab;
        private System.Windows.Forms.Button btn_ManualModify;
        private System.Windows.Forms.Button btn_LaterDw_PEtab;
        private System.Windows.Forms.ContextMenuStrip cms_picpanel;
        private System.Windows.Forms.ToolStripMenuItem btn_cmsCopyImages;
        private System.Windows.Forms.ToolStripMenuItem btn_cmsAdjustImage;
        private System.Windows.Forms.ToolStripMenuItem btn_cmsCurrentImageInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcExamCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcRoom;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcClassName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcUserID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcClassid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcpingying;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcObjectNum;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcAnswer;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcItemCount;
        private TreeListColumn trcPageindex;
        private TreeListColumn trcRect;
        private TreeListColumn trcMultiSelect;
        private TreeListColumn trcModifyStatus;
        private TreeListColumn trcCheckStatus;
        private TreeListColumn trcOmrValType;

    }
}