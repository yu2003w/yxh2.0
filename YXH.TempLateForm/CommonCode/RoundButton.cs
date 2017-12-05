using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YXH.TemplateForm
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
        /// 重绘事件
        /// </summary>
        /// <param name="pe">重绘事件头</param>
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
            Rectangle rect = new Rectangle(2, 2, base.Width - 4, base.Height - 4);
            path = this.GetCirclePath(rect);
            base.Region = new Region(path);
        }

        /// <summary>
        /// 获取圆形线条路径
        /// </summary>
        /// <param name="rect">矩形信息</param>
        /// <returns>绘制路径</returns>
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
        /// <param name="e">事件头</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.SetWindowRegion();
        }

        /// <summary>
        /// 清理方法
        /// </summary>
        /// <param name="disposing">清理状态</param>
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
