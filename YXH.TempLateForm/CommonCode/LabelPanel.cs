using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using YXH.Common;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 标注面板
    /// </summary>
    public class LabelPanel : ContentPanel
    {
        /// <summary>
        /// 标注高度
        /// </summary>
        private const int LABEL_HEIGHT = 58;
        /// <summary>
        /// 标注边缘宽度
        /// </summary>
        private const int LABEL_MARGIN = 0;
        /// <summary>
        /// 标注间隔
        /// </summary>
        protected int lableSpacing;
        /// <summary>
        /// 边缘
        /// </summary>
        protected int margin;
        /// <summary>
        /// 标注间隔
        /// </summary>
        public int LabelSpacing
        {
            get
            {
                return this.lableSpacing;
            }
        }
        /// <summary>
        /// 边缘
        /// </summary>
        public new int Margin
        {
            get
            {
                return this.margin;
            }
        }
        /// <summary>
        /// 内容大小
        /// </summary>
        public Size ContentSize
        {
            get
            {
                return new Size(base.Size.Width, base.Controls.Count * this.lableSpacing);
            }
        }

        private Color _oldColor;

        /// <summary>
        /// 构造方法
        /// </summary>
        public LabelPanel()
        {
            this.margin = 0;
            this.lableSpacing = 58;
            this.AutoScroll = true;
        }

        /// <summary>
        /// 标签鼠标进入事件
        /// </summary>
        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (sender as Label);

            _oldColor = lbl.ForeColor;
            lbl.ForeColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
        }

        /// <summary>
        /// 标签鼠标离开事件
        /// </summary>
        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (sender as Label);

            if (lbl.Cursor == Cursors.Hand)
            {
                lbl.ForeColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
                lbl.Cursor = Cursors.Arrow;

                return;
            }

            lbl.ForeColor = _oldColor;
        }

        /// <summary>
        /// 添加标注
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="onClickEvent">点击事件头</param>
        /// <param name="info">标注标签信息</param>
        public void AddLabel(string caption, EventHandler onClickEvent, LabelTagInfo info)
        {
            int count = base.Controls.Count;
            Label label = new Label();
            label.Text = caption;
            label.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label.Visible = true;
            label.Location = new Point(0, this.margin + count * this.lableSpacing);
            label.Size = new Size(base.Size.Width, 58);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.MouseEnter += new EventHandler(label_MouseEnter);
            label.Click += onClickEvent;
            label.MouseLeave += new EventHandler(label_MouseLeave);
            //label.CompanyName = "false";
            label.Padding = new Padding(50, 0, 0, 0);
            label.BackColor = Scheme.UnifiedBackColor;

            label.Paint += new PaintEventHandler(this.Label_Paint);

            label.Tag = info;

            base.Controls.Add(label);

            base.Size = this.ContentSize;
        }

        /// <summary>
        /// 高亮选中
        /// </summary>
        /// <param name="index">选中索引</param>
        public override void HighlightSelection(int index)
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                Label label = base.Controls[i] as Label;

                label.ForeColor = (i == index) ? Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27))))) : label.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// 重置选中
        /// </summary>
        public override void ResetSelection()
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                Label label = base.Controls[i] as Label;
                label.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// 绘制事件
        /// </summary>
        private void Label_Paint(object sender, PaintEventArgs e)
        {
            Label label = sender as Label;
            Rectangle clientRectangle = label.ClientRectangle;
            Color lightGray = Color.LightGray;
            Pen pen = new Pen(lightGray, 1f);

            pen.DashStyle = DashStyle.Dash;

            e.Graphics.DrawLine(pen, new Point(clientRectangle.Left + 30, clientRectangle.Bottom - 3), new Point(clientRectangle.Right - 30, clientRectangle.Bottom - 3));
        }
    }
}
