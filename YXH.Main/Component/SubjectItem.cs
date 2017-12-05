using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using YXH.Model;

namespace YXH.Main.Component
{
    /// <summary>
    /// 块状按钮定义
    /// </summary>
    public class SubjectItem : UserControl
    {
        /// <summary>
        /// 需要声明的事件委托
        /// </summary>
        /// <param name="obj"></param>
        public delegate void SubjectItemClickHandle(object obj);
        /// <summary>
        /// 元素标题
        /// </summary>
        private string _subjectTitle;
        /// <summary>
        /// 鼠标悬浮文本
        /// </summary>
        private string _mouseHoverTxt;
        /// <summary>
        /// 鼠标悬浮颜色
        /// </summary>
        private Color _mouseHoverColor;
        /// <summary>
        /// 默认背景颜色
        /// </summary>
        private Color _defaultBackGroundColor;
        /// <summary>
        /// 考试ID
        /// </summary>
        private string _examId;
        /// <summary>
        /// 考试信息
        /// </summary>
        private ExamInfo _exam;
        /// <summary>
        /// 元素对象
        /// </summary>
        private IContainer components;
        /// <summary>
        /// 按钮载体
        /// </summary>
        private Panel panel1;
        /// <summary>
        /// 内容载体
        /// </summary>
        private Label lbl_content;
        /// <summary>
        /// 点击事件头
        /// </summary>
        public event SubjectItem.SubjectItemClickHandle onClick;
        /// <summary>
        /// 考试信息
        /// </summary>
        public ExamInfo Exam
        {
            get
            {
                return this._exam;
            }
            set
            {
                this._exam = value;
                this.subjectTitle = this._exam.GradeName + this._exam.SubjectName + this._exam.SubjectType;
                this.mouseHoverTxt = "点击进入" + this._exam.ID;
            }
        }
        /// <summary>
        /// 按钮标题
        /// </summary>
        public string subjectTitle
        {
            get
            {
                return this._subjectTitle;
            }
            set
            {
                this._subjectTitle = value;
                this.lbl_content.Text = this._subjectTitle;
            }
        }
        /// <summary>
        /// 鼠标悬浮文本
        /// </summary>
        public string mouseHoverTxt
        {
            get
            {
                return this._mouseHoverTxt;
            }
            set
            {
                this._mouseHoverTxt = value;
            }
        }
        /// <summary>
        /// 鼠标悬浮颜色
        /// </summary>
        public Color mouseHoverColor
        {
            get
            {
                return this._mouseHoverColor;
            }
            set
            {
                this._mouseHoverColor = value;
            }
        }
        /// <summary>
        /// 默认背景颜色
        /// </summary>
        public Color defaultBackGroundColor
        {
            get
            {
                return this._defaultBackGroundColor;
            }
            set
            {
                this._defaultBackGroundColor = value;
            }
        }
        /// <summary>
        /// 考试ID
        /// </summary>
        public string examId
        {
            get
            {
                return this._examId;
            }
            set
            {
                this._examId = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public SubjectItem()
        {
            this.InitializeComponent();
            this.Inital();
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        public void Inital()
        {
            this._examId = "000000";
            this._subjectTitle = "未知科目";
            this._mouseHoverTxt = "点击进入";
            this._mouseHoverColor = Color.Red;
            this._defaultBackGroundColor = Color.Orange;
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        private void SubjectItem_Load(object sender, EventArgs e)
        {
            this.lbl_content.Text = this.subjectTitle;
            this.panel1.BackColor = this.defaultBackGroundColor;
        }

        /// <summary>
        /// 文字鼠标离开事件
        /// </summary>
        private void lbl_content_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackColor = this.defaultBackGroundColor;
            this.panel1.Cursor = Cursors.Default;
            this.lbl_content.Text = this.subjectTitle;
        }

        /// <summary>
        /// 文字鼠标悬浮事件
        /// </summary>
        private void lbl_content_MouseHover(object sender, EventArgs e)
        {
            this.panel1.BackColor = this.mouseHoverColor;
            this.panel1.Cursor = Cursors.Hand;
            this.lbl_content.Text = this.mouseHoverTxt;
        }

        /// <summary>
        /// 文字点击事件
        /// </summary>
        private void lbl_content_Click(object sender, EventArgs e)
        {
            if (this.onClick != null)
            {
                this.onClick(this._exam);

                return;
            }

            MessageBox.Show("Click 事件没有绑定具体的操作");
        }

        /// <summary>
        /// 回收处理方法
        /// </summary>
        /// <param name="disposing">是否正在处理</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// 初始化组件方法
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.lbl_content = new Label();

            this.panel1.SuspendLayout();
            base.SuspendLayout();

            this.panel1.BackColor = Color.FromArgb(255, 192, 192);
            this.panel1.Controls.Add(this.lbl_content);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(80, 80);
            this.panel1.TabIndex = 0;

            this.lbl_content.Dock = DockStyle.Fill;
            this.lbl_content.Font = new Font("宋体", 9f, FontStyle.Bold);
            this.lbl_content.Location = new Point(0, 0);
            this.lbl_content.Margin = new Padding(5, 0, 5, 0);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new Size(80, 80);
            this.lbl_content.TabIndex = 0;
            this.lbl_content.Text = "初一数学";
            this.lbl_content.TextAlign = ContentAlignment.MiddleCenter;
            this.lbl_content.Click += new EventHandler(this.lbl_content_Click);
            this.lbl_content.MouseLeave += new EventHandler(this.lbl_content_MouseLeave);
            this.lbl_content.MouseHover += new EventHandler(this.lbl_content_MouseHover);

            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;

            base.Controls.Add(this.panel1);

            this.DoubleBuffered = true;
            base.Name = "SubjectItem";
            base.Size = new Size(80, 80);
            base.Load += new EventHandler(this.SubjectItem_Load);

            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}