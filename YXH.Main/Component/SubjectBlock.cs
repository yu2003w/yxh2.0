using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.Main.Component
{
    /// <summary>
    /// 块状区域定义类
    /// </summary>
    public class SubjectBlock : UserControl
    {
        /// <summary>
        /// 需要生成的按钮列表via哦
        /// </summary>
        private List<SubjectItem> itemList = new List<SubjectItem>();
        /// <summary>
        /// 考试信息列表
        /// </summary>
        private IList<ExamInfo> _subjectDataList;
        /// <summary>
        /// 元素高度
        /// </summary>
        private int _subjectItemHeight;
        /// <summary>
        /// 是展开状态
        /// </summary>
        private bool _isExpand;
        /// <summary>
        /// 总行数
        /// </summary>
        private int _totalRow;
        /// <summary>
        /// 总列数
        /// </summary>
        private int _totalCol;
        /// <summary>
        /// 元素列表
        /// </summary>
        private IContainer components;
        /// <summary>
        /// 内容面板
        /// </summary>
        private Panel panel1;
        /// <summary>
        /// 更多按钮
        /// </summary>
        private Button btn_more;
        /// <summary>
        /// 内容面板
        /// </summary>
        private Panel panel_body;
        /// <summary>
        /// 标题面板
        /// </summary>
        private Panel panel_title;
        /// <summary>
        /// 考试组标题
        /// </summary>
        private Label lbl_ExamGroupTitle;
        /// <summary>
        /// 子元素列表
        /// </summary>
        private TableLayoutPanel tblPanel_Sbjlist;
        /// <summary>
        /// 总列数
        /// </summary>
        public int totalCol
        {
            get
            {
                return this._totalCol;
            }
        }
        /// <summary>
        /// 子元素数据集合
        /// </summary>
        public IList<ExamInfo> SubjectDataList
        {
            get
            {
                return this._subjectDataList;
            }
            set
            {
                this._subjectDataList = value;

                this.UpdateItemList();
            }
        }

        /// <summary>
        /// 项目列表
        /// </summary>
        public List<SubjectItem> ItemList
        {
            get
            {
                return this.itemList;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public SubjectBlock()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        private void SubjectBlock_Load(object sender, EventArgs e)
        {
            this.Initial();

            for (int i = 0; i < this.itemList.Count; i++)
            {
                int row = i / this.tblPanel_Sbjlist.ColumnCount;
                int column = i % this.tblPanel_Sbjlist.ColumnCount;

                this.itemList[i].Dock = DockStyle.Fill;

                this.tblPanel_Sbjlist.Controls.Add(this.itemList[i], column, row);
            }
            if (this.itemList.Count <= this._totalCol)
            {
                this.btn_more.Visible = false;
            }

            this._totalRow = this.itemList.Count / this._totalCol + 1;

            this.tblPanel_Sbjlist.RowStyles.Clear();

            for (int j = 0; j < this._totalRow; j++)
            {
                this.tblPanel_Sbjlist.RowStyles.Add(new RowStyle(SizeType.Absolute, (float)this._subjectItemHeight));
            }
        }

        /// <summary>
        /// 更多按钮点击事件
        /// </summary>
        private void btn_more_Click(object sender, EventArgs e)
        {
            if (this.itemList.Count > this._totalCol)
            {
                if (this._isExpand)
                {
                    base.Height -= this._subjectItemHeight * (this._totalRow - 1);
                    this.btn_more.Text = "更多...";
                    this._isExpand = false;

                    return;
                }

                base.Height += this._subjectItemHeight * (this._totalRow - 1);
                this.btn_more.Text = "收起";
                this._isExpand = true;
            }
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        private void Initial()
        {
            this._totalCol = this.tblPanel_Sbjlist.ColumnCount;
            this._totalRow = 1;
            this._subjectItemHeight = this.tblPanel_Sbjlist.Width / this._totalCol;
            int arg_3B_0 = this.tblPanel_Sbjlist.Height;
            base.Height = this.panel_title.Height + this._subjectItemHeight;

            this.tblPanel_Sbjlist.RowStyles.Clear();
            this.tblPanel_Sbjlist.RowStyles.Add(new RowStyle(SizeType.Absolute, (float)this._subjectItemHeight));

            this._isExpand = false;
        }

        /// <summary>
        /// 更新项目列表
        /// </summary>
        private void UpdateItemList()
        {
            if (this._subjectDataList != null)
            {
                this.lbl_ExamGroupTitle.Text = ScanGlobalInfo.ExamGroup.ExamName;

                foreach (ExamInfo current in this._subjectDataList)
                {
                    SubjectItem subjectItem = new SubjectItem();
                    subjectItem.Exam = current;

                    this.itemList.Add(subjectItem);
                }
            }
        }

        /// <summary>
        /// 回收方法
        /// </summary>
        /// <param name="disposing">是否回收</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// 初始化组件
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.panel_body = new Panel();
            this.btn_more = new Button();
            this.tblPanel_Sbjlist = new TableLayoutPanel();
            this.panel_title = new Panel();
            this.lbl_ExamGroupTitle = new Label();

            this.panel1.SuspendLayout();
            this.panel_body.SuspendLayout();
            this.panel_title.SuspendLayout();
            base.SuspendLayout();

            this.panel1.Controls.Add(this.panel_body);
            this.panel1.Controls.Add(this.panel_title);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(807, 114);
            this.panel1.TabIndex = 0;

            this.panel_body.Controls.Add(this.btn_more);
            this.panel_body.Controls.Add(this.tblPanel_Sbjlist);
            this.panel_body.Dock = DockStyle.Fill;
            this.panel_body.Location = new Point(0, 41);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new Size(807, 73);
            this.panel_body.TabIndex = 4;

            this.btn_more.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.btn_more.FlatAppearance.BorderSize = 0;
            this.btn_more.FlatStyle = FlatStyle.Flat;
            this.btn_more.ForeColor = Color.DodgerBlue;
            this.btn_more.Location = new Point(694, 50);
            this.btn_more.Margin = new Padding(20, 3, 3, 3);
            this.btn_more.Name = "btn_more";
            this.btn_more.Size = new Size(46, 20);
            this.btn_more.TabIndex = 3;
            this.btn_more.Text = "更多...";
            this.btn_more.UseVisualStyleBackColor = true;
            this.btn_more.Click += new EventHandler(this.btn_more_Click);

            this.tblPanel_Sbjlist.AutoSize = true;
            this.tblPanel_Sbjlist.ColumnCount = 8;
            this.tblPanel_Sbjlist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            this.tblPanel_Sbjlist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            this.tblPanel_Sbjlist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            this.tblPanel_Sbjlist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            this.tblPanel_Sbjlist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            this.tblPanel_Sbjlist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            this.tblPanel_Sbjlist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            this.tblPanel_Sbjlist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            this.tblPanel_Sbjlist.Location = new Point(0, 0);
            this.tblPanel_Sbjlist.Name = "tblPanel_Sbjlist";
            this.tblPanel_Sbjlist.Padding = new Padding(3);
            this.tblPanel_Sbjlist.RowCount = 1;
            this.tblPanel_Sbjlist.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tblPanel_Sbjlist.Size = new Size(671, 73);
            this.tblPanel_Sbjlist.TabIndex = 2;

            this.panel_title.Controls.Add(this.lbl_ExamGroupTitle);
            this.panel_title.Dock = DockStyle.Top;
            this.panel_title.Location = new Point(0, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new Size(807, 41);
            this.panel_title.TabIndex = 3;

            this.lbl_ExamGroupTitle.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            this.lbl_ExamGroupTitle.Font = new Font("宋体", 14f);
            this.lbl_ExamGroupTitle.ForeColor = SystemColors.Highlight;
            this.lbl_ExamGroupTitle.Location = new Point(3, 0);
            this.lbl_ExamGroupTitle.Name = "lbl_ExamGroupTitle";
            this.lbl_ExamGroupTitle.Size = new Size(517, 38);
            this.lbl_ExamGroupTitle.TabIndex = 2;
            this.lbl_ExamGroupTitle.Text = "考试1";
            this.lbl_ExamGroupTitle.TextAlign = ContentAlignment.MiddleLeft;

            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;

            base.Controls.Add(this.panel1);

            this.DoubleBuffered = true;
            base.Name = "SubjectBlock";
            base.Size = new Size(807, 114);
            base.Load += new EventHandler(this.SubjectBlock_Load);

            this.panel1.ResumeLayout(false);
            this.panel_body.ResumeLayout(false);
            this.panel_body.PerformLayout();
            this.panel_title.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}
