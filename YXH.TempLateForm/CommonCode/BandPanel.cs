using System;
using System.Drawing;
using System.Windows.Forms;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 条状面板
    /// </summary>
    public class BandPanel : Panel
    {
        /// <summary>
        /// 条状按钮
        /// </summary>
        private BandButton bandButton;
        /// <summary>
        /// 是内容面板
        /// </summary>
        protected bool hasContentPanel;
        /// <summary>
        /// 是选中
        /// </summary>
        public bool selected;
        /// <summary>
        /// 是水平
        /// </summary>
        public bool IsHighlight;
        /// <summary>
        /// 标准图片
        /// </summary>
        public Image NormalImage;
        /// <summary>
        /// 强调图片
        /// </summary>
        public Image HighlightImage;
        /// <summary>
        /// 是内容面板
        /// </summary>
        public bool HasContentPanel
        {
            get
            {
                return this.hasContentPanel;
            }
        }
        private Color _oldForeColor;
        /// <summary>
        /// 按钮鼠标进入事件
        /// </summary>
        private void bandButton_MouseEnter(object sender, EventArgs e)
        {
            BandButton bb = (sender as BandButton);

            _oldForeColor = bb.ForeColor;
            bb.ForeColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
        }

        /// <summary>
        /// 按钮鼠标离开事件
        /// </summary>
        private void bandButton_MouseLeave(object sender, EventArgs e)
        {
            BandButton bb = (sender as BandButton);

            bb.ForeColor = _oldForeColor;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="content">内容面板</param>
        /// <param name="bti">条状提示信息</param>
        /// <param name="onClickEvent">点击事件头</param>
        public BandPanel(string caption, ContentPanel content, BandTagInfo bti, EventHandler onClickEvent)
        {
            this.bandButton = new BandButton(caption, bti);
            bandButton.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandButton.Click += onClickEvent;
            this.bandButton.Paint += new PaintEventHandler(this.bandButton_Paint);
            bandButton.MouseEnter += new EventHandler(bandButton_MouseEnter);
            bandButton.MouseLeave += new EventHandler(bandButton_MouseLeave);

            base.Controls.Add(this.bandButton);

            this.hasContentPanel = (content != null);

            if (this.hasContentPanel)
            {
                base.Controls.Add(content);
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="content">内容面板</param>
        /// <param name="bti">条状提示信息</param>
        /// <param name="onClickEvent">点击事件头</param>
        /// <param name="normal">标准图片</param>
        /// <param name="highlight">强调图片</param>
        public BandPanel(string caption, ContentPanel content, BandTagInfo bti, EventHandler onClickEvent, Image normal, Image highlight)
            : this(caption, content, bti, onClickEvent)
        {
            this.bandButton.Image = normal;
            this.bandButton.ImageAlign = ContentAlignment.MiddleLeft;
            this.bandButton.TextAlign = ContentAlignment.MiddleLeft;
            this.bandButton.Padding = new Padding(10, 0, 0, 0);
            this.bandButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.NormalImage = normal;
            this.HighlightImage = highlight;
        }

        /// <summary>
        /// 条状按钮绘制事件
        /// </summary>
        private void bandButton_Paint(object sender, PaintEventArgs e)
        {
            BandButton bandButton = sender as BandButton;
            Rectangle clientRectangle = bandButton.ClientRectangle;

            if (this.NormalImage != null && this.HighlightImage != null)
            {
                this.bandButton.Image = (this.IsHighlight ? this.HighlightImage : this.NormalImage);
            }
            if (this.hasContentPanel)
            {
                int num = clientRectangle.Right - 30,
                    num2 = clientRectangle.Top + clientRectangle.Height / 2,
                    num3 = 3;
                Color color = this.IsHighlight ? Color.White : Color.Gray;
                Pen pen = new Pen(color, 2f);

                if (this.selected)
                {
                    e.Graphics.DrawLine(pen, new Point(num, num2 - num3), new Point(num - num3 * 2, num2 + num3));
                    e.Graphics.DrawLine(pen, new Point(num, num2 - num3), new Point(num + num3 * 2, num2 + num3));

                    return;
                }

                e.Graphics.DrawLine(pen, new Point(num, num2 + num3), new Point(num - num3 * 2, num2 - num3));
                e.Graphics.DrawLine(pen, new Point(num, num2 + num3), new Point(num + num3 * 2, num2 - num3));
            }
        }

        /// <summary>
        /// 获取内容高度
        /// </summary>
        /// <returns>高度值</returns>
        public int GetContentHeight()
        {
            if (this.hasContentPanel)
            {
                return base.Controls[1].Size.Height;
            }

            return 0;
        }
    }
}
