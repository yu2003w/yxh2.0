using System.Drawing;
using System.Windows.Forms;
namespace YXH.TemplateForm
{
    partial class TempalteMakerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTemplateMakeStep = new System.Windows.Forms.Label();
            this.lbl_PageIndexShown = new System.Windows.Forms.Label();
            this.flpImageAction = new System.Windows.Forms.FlowLayoutPanel();
            this.zoomIn = new System.Windows.Forms.Button();
            this.zoomOut = new System.Windows.Forms.Button();
            this.btnUnClockRotate = new System.Windows.Forms.Button();
            this.btnClockRotate = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.panExamInfo = new System.Windows.Forms.Panel();
            this.lblExamInfo = new System.Windows.Forms.Label();
            this.panAction = new System.Windows.Forms.Panel();
            this.btn_OpenTpFolder = new System.Windows.Forms.Button();
            this.btn_Setting = new System.Windows.Forms.Button();
            this.splitLeft = new System.Windows.Forms.SplitContainer();
            this.splitOutter = new System.Windows.Forms.SplitContainer();
            this.panTop = new System.Windows.Forms.Panel();
            this.lblBackExamList = new System.Windows.Forms.Label();
            this.flpImageAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.SuspendLayout();
            this.panExamInfo.SuspendLayout();
            this.panAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).BeginInit();
            this.splitLeft.Panel1.SuspendLayout();
            this.splitLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitOutter)).BeginInit();
            this.splitOutter.Panel1.SuspendLayout();
            this.splitOutter.Panel2.SuspendLayout();
            this.splitOutter.SuspendLayout();
            this.panTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTemplateMakeStep
            // 
            this.lblTemplateMakeStep.AutoSize = true;
            this.lblTemplateMakeStep.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemplateMakeStep.ForeColor = System.Drawing.Color.Black;
            this.lblTemplateMakeStep.Location = new System.Drawing.Point(60, 15);
            this.lblTemplateMakeStep.Name = "lblTemplateMakeStep";
            this.lblTemplateMakeStep.Size = new System.Drawing.Size(142, 21);
            this.lblTemplateMakeStep.TabIndex = 0;
            this.lblTemplateMakeStep.Text = "模板制作步骤";
            // 
            // lbl_PageIndexShown
            // 
            this.lbl_PageIndexShown.Font = new System.Drawing.Font("宋体", 10F);
            this.lbl_PageIndexShown.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_PageIndexShown.Location = new System.Drawing.Point(343, 0);
            this.lbl_PageIndexShown.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_PageIndexShown.Name = "lbl_PageIndexShown";
            this.lbl_PageIndexShown.Size = new System.Drawing.Size(50, 49);
            this.lbl_PageIndexShown.TabIndex = 8;
            this.lbl_PageIndexShown.Text = "0/0";
            this.lbl_PageIndexShown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpImageAction
            // 
            this.flpImageAction.BackColor = System.Drawing.SystemColors.Control;
            this.flpImageAction.Controls.Add(this.zoomIn);
            this.flpImageAction.Controls.Add(this.zoomOut);
            this.flpImageAction.Controls.Add(this.btnUnClockRotate);
            this.flpImageAction.Controls.Add(this.btnClockRotate);
            this.flpImageAction.Controls.Add(this.previousPage);
            this.flpImageAction.Controls.Add(this.lbl_PageIndexShown);
            this.flpImageAction.Controls.Add(this.nextPage);
            this.flpImageAction.Location = new System.Drawing.Point(169, 4);
            this.flpImageAction.Margin = new System.Windows.Forms.Padding(0);
            this.flpImageAction.Name = "flpImageAction";
            this.flpImageAction.Size = new System.Drawing.Size(518, 49);
            this.flpImageAction.TabIndex = 1;
            // 
            // zoomIn
            // 
            this.zoomIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.zoomIn.FlatAppearance.BorderSize = 0;
            this.zoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomIn.Image = global::YXH.TemplateForm.TempalteMakerFormRes.MagnifyImage;
            this.zoomIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomIn.Location = new System.Drawing.Point(0, 0);
            this.zoomIn.Margin = new System.Windows.Forms.Padding(0);
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(57, 49);
            this.zoomIn.TabIndex = 0;
            this.zoomIn.Text = "放大";
            this.zoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.zoomIn.UseVisualStyleBackColor = true;
            this.zoomIn.Click += new System.EventHandler(this.zoomIn_Click);
            // 
            // zoomOut
            // 
            this.zoomOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.zoomOut.FlatAppearance.BorderSize = 0;
            this.zoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomOut.Image = global::YXH.TemplateForm.TempalteMakerFormRes.ShrinkImage;
            this.zoomOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomOut.Location = new System.Drawing.Point(57, 0);
            this.zoomOut.Margin = new System.Windows.Forms.Padding(0);
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(57, 49);
            this.zoomOut.TabIndex = 1;
            this.zoomOut.Text = "缩小";
            this.zoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.zoomOut.UseVisualStyleBackColor = true;
            this.zoomOut.Click += new System.EventHandler(this.zoomOut_Click);
            // 
            // btnUnClockRotate
            // 
            this.btnUnClockRotate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUnClockRotate.FlatAppearance.BorderSize = 0;
            this.btnUnClockRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnClockRotate.Image = global::YXH.TemplateForm.TempalteMakerFormRes.ContrarotateImage;
            this.btnUnClockRotate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnClockRotate.Location = new System.Drawing.Point(114, 0);
            this.btnUnClockRotate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUnClockRotate.Name = "btnUnClockRotate";
            this.btnUnClockRotate.Size = new System.Drawing.Size(57, 49);
            this.btnUnClockRotate.TabIndex = 7;
            this.btnUnClockRotate.Text = "左旋";
            this.btnUnClockRotate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnClockRotate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnClockRotate.UseVisualStyleBackColor = true;
            this.btnUnClockRotate.Click += new System.EventHandler(this.btnUnClockRotate_Click);
            // 
            // btnClockRotate
            // 
            this.btnClockRotate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClockRotate.FlatAppearance.BorderSize = 0;
            this.btnClockRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClockRotate.Image = global::YXH.TemplateForm.TempalteMakerFormRes.ClockwiseRotationImage;
            this.btnClockRotate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClockRotate.Location = new System.Drawing.Point(171, 0);
            this.btnClockRotate.Margin = new System.Windows.Forms.Padding(0);
            this.btnClockRotate.Name = "btnClockRotate";
            this.btnClockRotate.Size = new System.Drawing.Size(57, 49);
            this.btnClockRotate.TabIndex = 6;
            this.btnClockRotate.Text = "右旋";
            this.btnClockRotate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClockRotate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnClockRotate.UseVisualStyleBackColor = true;
            this.btnClockRotate.Click += new System.EventHandler(this.btnClockRotate_Click);
            // 
            // previousPage
            // 
            this.previousPage.FlatAppearance.BorderSize = 0;
            this.previousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousPage.Image = global::YXH.TemplateForm.TempalteMakerFormRes.PreviousPageImage;
            this.previousPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.previousPage.Location = new System.Drawing.Point(269, 0);
            this.previousPage.Margin = new System.Windows.Forms.Padding(41, 0, 0, 0);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(74, 43);
            this.previousPage.TabIndex = 4;
            this.previousPage.Text = " 上一页";
            this.previousPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.previousPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.previousPage.UseVisualStyleBackColor = true;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.FlatAppearance.BorderSize = 0;
            this.nextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPage.Image = global::YXH.TemplateForm.TempalteMakerFormRes.NextPageImage;
            this.nextPage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nextPage.Location = new System.Drawing.Point(393, 0);
            this.nextPage.Margin = new System.Windows.Forms.Padding(0);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(66, 43);
            this.nextPage.TabIndex = 5;
            this.nextPage.Text = "下一页";
            this.nextPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitRight.IsSplitterFixed = true;
            this.splitRight.Location = new System.Drawing.Point(0, 0);
            this.splitRight.Name = "splitRight";
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRight.Panel1
            // 
            this.splitRight.Panel1.Controls.Add(this.panExamInfo);
            this.splitRight.Panel1.Controls.Add(this.panAction);
            this.splitRight.Size = new System.Drawing.Size(763, 510);
            this.splitRight.SplitterDistance = 49;
            this.splitRight.SplitterWidth = 1;
            this.splitRight.TabIndex = 0;
            // 
            // panExamInfo
            // 
            this.panExamInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panExamInfo.BackColor = System.Drawing.Color.White;
            this.panExamInfo.Controls.Add(this.lblExamInfo);
            this.panExamInfo.Location = new System.Drawing.Point(0, 0);
            this.panExamInfo.Name = "panExamInfo";
            this.panExamInfo.Size = new System.Drawing.Size(763, 48);
            this.panExamInfo.TabIndex = 5;
            // 
            // lblExamInfo
            // 
            this.lblExamInfo.AutoSize = true;
            this.lblExamInfo.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblExamInfo.Location = new System.Drawing.Point(30, 11);
            this.lblExamInfo.Name = "lblExamInfo";
            this.lblExamInfo.Size = new System.Drawing.Size(0, 27);
            this.lblExamInfo.TabIndex = 10;
            // 
            // panAction
            // 
            this.panAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panAction.BackColor = System.Drawing.Color.White;
            this.panAction.Controls.Add(this.btn_OpenTpFolder);
            this.panAction.Controls.Add(this.btn_Setting);
            this.panAction.Controls.Add(this.flpImageAction);
            this.panAction.Location = new System.Drawing.Point(0, 0);
            this.panAction.Name = "panAction";
            this.panAction.Size = new System.Drawing.Size(763, 48);
            this.panAction.TabIndex = 4;
            this.panAction.Visible = false;
            // 
            // btn_OpenTpFolder
            // 
            this.btn_OpenTpFolder.FlatAppearance.BorderSize = 0;
            this.btn_OpenTpFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OpenTpFolder.Image = global::YXH.TemplateForm.TempalteMakerFormRes.OpenFolderImage;
            this.btn_OpenTpFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OpenTpFolder.Location = new System.Drawing.Point(30, 6);
            this.btn_OpenTpFolder.Margin = new System.Windows.Forms.Padding(0);
            this.btn_OpenTpFolder.Name = "btn_OpenTpFolder";
            this.btn_OpenTpFolder.Size = new System.Drawing.Size(109, 39);
            this.btn_OpenTpFolder.TabIndex = 3;
            this.btn_OpenTpFolder.Text = " 模板保存目录";
            this.btn_OpenTpFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_OpenTpFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_OpenTpFolder.UseVisualStyleBackColor = true;
            this.btn_OpenTpFolder.Visible = false;
            this.btn_OpenTpFolder.Click += new System.EventHandler(this.btn_OpenTpFolder_Click);
            // 
            // btn_Setting
            // 
            this.btn_Setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Setting.FlatAppearance.BorderSize = 0;
            this.btn_Setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Setting.Image = global::YXH.TemplateForm.TempalteMakerFormRes.btn_Setting_Image;
            this.btn_Setting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Setting.Location = new System.Drawing.Point(1908, 5);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(57, 39);
            this.btn_Setting.TabIndex = 2;
            this.btn_Setting.Text = "设置";
            this.btn_Setting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Setting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Setting.UseVisualStyleBackColor = true;
            this.btn_Setting.Visible = false;
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // splitLeft
            // 
            this.splitLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitLeft.IsSplitterFixed = true;
            this.splitLeft.Location = new System.Drawing.Point(0, 0);
            this.splitLeft.Margin = new System.Windows.Forms.Padding(0);
            this.splitLeft.Name = "splitLeft";
            this.splitLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeft.Panel1
            // 
            this.splitLeft.Panel1.Controls.Add(this.lblTemplateMakeStep);
            this.splitLeft.Size = new System.Drawing.Size(259, 510);
            this.splitLeft.SplitterWidth = 1;
            this.splitLeft.TabIndex = 0;
            // 
            // splitOutter
            // 
            this.splitOutter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitOutter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitOutter.IsSplitterFixed = true;
            this.splitOutter.Location = new System.Drawing.Point(0, 40);
            this.splitOutter.Margin = new System.Windows.Forms.Padding(0);
            this.splitOutter.Name = "splitOutter";
            // 
            // splitOutter.Panel1
            // 
            this.splitOutter.Panel1.Controls.Add(this.splitLeft);
            // 
            // splitOutter.Panel2
            // 
            this.splitOutter.Panel2.AutoScroll = true;
            this.splitOutter.Panel2.Controls.Add(this.splitRight);
            this.splitOutter.Size = new System.Drawing.Size(1023, 510);
            this.splitOutter.SplitterDistance = 259;
            this.splitOutter.SplitterWidth = 1;
            this.splitOutter.TabIndex = 0;
            // 
            // panTop
            // 
            this.panTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTop.Controls.Add(this.lblBackExamList);
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Margin = new System.Windows.Forms.Padding(0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(1023, 40);
            this.panTop.TabIndex = 1;
            // 
            // lblBackExamList
            // 
            this.lblBackExamList.AutoSize = true;
            this.lblBackExamList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBackExamList.Image = global::YXH.TemplateForm.TempalteMakerFormRes.Back;
            this.lblBackExamList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackExamList.Location = new System.Drawing.Point(9, 9);
            this.lblBackExamList.Margin = new System.Windows.Forms.Padding(0);
            this.lblBackExamList.Name = "lblBackExamList";
            this.lblBackExamList.Size = new System.Drawing.Size(64, 16);
            this.lblBackExamList.TabIndex = 1;
            this.lblBackExamList.Text = "   返回";
            this.lblBackExamList.Click += new System.EventHandler(this.lblBackExamList_Click);
            // 
            // TempalteMakerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1023, 550);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.splitOutter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TempalteMakerForm";
            this.Text = "TempalteMaker";
            this.Load += new System.EventHandler(this.TempalteMakerForm_Load);
            this.flpImageAction.ResumeLayout(false);
            this.splitRight.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            this.panExamInfo.ResumeLayout(false);
            this.panExamInfo.PerformLayout();
            this.panAction.ResumeLayout(false);
            this.splitLeft.Panel1.ResumeLayout(false);
            this.splitLeft.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).EndInit();
            this.splitLeft.ResumeLayout(false);
            this.splitOutter.Panel1.ResumeLayout(false);
            this.splitOutter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitOutter)).EndInit();
            this.splitOutter.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTemplateMakeStep;
        private System.Windows.Forms.Label lbl_PageIndexShown;
        private System.Windows.Forms.Button previousPage;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button btnClockRotate;
        private System.Windows.Forms.Button btn_Setting;
        private System.Windows.Forms.Button btn_OpenTpFolder;
        private System.Windows.Forms.Button btnUnClockRotate;
        private System.Windows.Forms.Button zoomIn;
        private System.Windows.Forms.Button zoomOut;
        private System.Windows.Forms.FlowLayoutPanel flpImageAction;
        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.SplitContainer splitLeft;
        private System.Windows.Forms.SplitContainer splitOutter;
        private Panel panTop;
        private Label lblBackExamList;
        private Panel panAction;
        private Panel panExamInfo;
        private Label lblExamInfo;
    }
}

