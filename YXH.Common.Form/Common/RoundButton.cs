using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YXH.Common.Form
{
    /// <summary>
    /// 圆形按钮
    /// </summary>
    public class RoundButton : Button
    {
        /// <summary>
        /// 组件接口
        /// </summary>
        private IContainer components;

        /// <summary>
        /// 构造方法
        /// </summary>
        public RoundButton()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 绘制事件
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        /// <summary>
        /// 设置窗体范围
        /// </summary>
        public void SetWindowRegion()
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);

            path = this.GetCirclePath(rect);

            base.Region = new Region(path);
        }

        /// <summary>
        /// 获取环绕路径
        /// </summary>
        /// <param name="rect">区域</param>
        /// <returns>画板路径</returns>
        private GraphicsPath GetCirclePath(Rectangle rect)
        {
            int num = Math.Min(rect.Width, rect.Height);
            Rectangle rect2 = new Rectangle(rect.Location, new Size(num, num));
            GraphicsPath graphicsPath = new GraphicsPath();

            graphicsPath.AddArc(rect2, 0f, 360f);
            graphicsPath.CloseFigure();

            return graphicsPath;
        }

        /// <summary>
        /// 大小改变事件
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.SetWindowRegion();
        }

        /// <summary>
        /// 回收处理
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
            this.components = new Container();
        }
    }
}

