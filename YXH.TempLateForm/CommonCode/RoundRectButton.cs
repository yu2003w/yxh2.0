using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 圆角矩形按钮
    /// </summary>
    public class RoundRectButton : Button
    {
        /// <summary>
        /// 声明组件接口
        /// </summary>
        private IContainer components;

        public RoundRectButton()
        {
            this.InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void SetWindowRegion()
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            path = this.GetRoundedRectPath(rect, 4);
            base.Region = new Region(path);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int factor)
        {
            int num = Math.Min(rect.Width, rect.Height) / factor;
            Rectangle rect2 = new Rectangle(rect.Location, new Size(num, num));
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rect2, 180f, 90f);
            rect2.X = rect.Right - num;
            graphicsPath.AddArc(rect2, 270f, 90f);
            rect2.Y = rect.Bottom - num;
            graphicsPath.AddArc(rect2, 0f, 90f);
            rect2.X = rect.Left;
            graphicsPath.AddArc(rect2, 90f, 90f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.SetWindowRegion();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.ResumeLayout(false);
        }
    }
}
