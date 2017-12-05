using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YXH.Main
{
    public class HalfRoundRectButton : Button
    {
        /// <summary>
        /// 是否有变化
        /// </summary>
        private bool _regionChanged;
        /// <summary>
        /// 边框线条宽度
        /// </summary>
        private int _bordersize = 1;

        /// <summary>
        /// 组件
        /// </summary>
        private IContainer components;

        /// <summary>
        /// 边框宽度
        /// </summary>
        public int BorderSize
        {
            get
            {
                return this._bordersize;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("边框大小不能小于0.");
                }
                if (this._bordersize != value)
                {
                    this._bordersize = value;

                    base.Invalidate();
                }
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public HalfRoundRectButton()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 绘制组件
        /// </summary>
        /// <param name="pe">绘制事件参数</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (!this._regionChanged)
            {
                return;
            }

            Rectangle clientRectangle = base.ClientRectangle;
            int num = (int)Math.Ceiling((double)this.BorderSize / 2.0);

            clientRectangle.X += num;
            clientRectangle.Y += num;
            clientRectangle.Width -= num * 2;
            clientRectangle.Height -= num * 2;

            Graphics graphics = pe.Graphics;

            Pen pen = new Pen(this.ForeColor)
            {
                Width = (float)this.BorderSize
            };

            GraphicsPath roundedPath = this.GetRoundedPath(clientRectangle);

            graphics.DrawPath(pen, roundedPath);
        }

        /// <summary>
        /// 设置窗体范围
        /// </summary>
        public void SetWindowRegion()
        {
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            GraphicsPath roundedPath = this.GetRoundedPath(rect);

            base.Region = new Region(roundedPath);
            this._regionChanged = true;
        }

        /// <summary>
        /// 获取圆形路径
        /// </summary>
        /// <param name="rect">目标矩形</param>
        /// <returns>绘制结果</returns>
        private GraphicsPath GetRoundedPath(Rectangle rect)
        {
            int num = Math.Min(rect.Height, rect.Height);
            Rectangle rect2 = new Rectangle(rect.Location, new Size(num, num));
            GraphicsPath graphicsPath = new GraphicsPath();

            graphicsPath.StartFigure();

            if (rect.Width > rect.Height)
            {
                graphicsPath.AddArc(rect2, 90f, 180f);

                rect2.X = rect.Right - num;

                graphicsPath.AddArc(rect2, 270f, 180f);
            }
            else
            {
                graphicsPath.AddArc(rect2, 180f, 180f);

                rect2.Y = rect.Bottom - num;

                graphicsPath.AddArc(rect2, 0f, 180f);
            }

            graphicsPath.CloseFigure();

            return graphicsPath;
        }

        /// <summary>
        /// 大小改变事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.SetWindowRegion();
        }

        /// <summary>
        /// 处理当前控件
        /// </summary>
        /// <param name="disposing">是否处理</param>
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
            base.SuspendLayout();
            base.ResumeLayout(false);
        }
    }
}
