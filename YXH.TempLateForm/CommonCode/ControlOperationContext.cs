using System;
using System.Drawing;
using System.Windows.Forms;
using YXH.Enum;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 操作内容面板
    /// </summary>
    public class ControlOperationContext
    {
        /// <summary>
        /// 操作功能组
        /// </summary>
        public OperationContext context;
        /// <summary>
        /// 框选区域的矩形
        /// </summary>
        protected Rectangle area;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="oc">操作对象</param>
        /// <param name="areaRect">选中区域</param>
        public ControlOperationContext(OperationContext oc, Rectangle areaRect)
        {
            context = oc;
            area = areaRect;
        }

        /// <summary>
        /// 获取矩形
        /// </summary>
        /// <param name="ratio">操作比例</param>
        /// <returns>获取到的矩形</returns>
        public Rectangle GetRect(float ratio)
        {
            return ResizableRectangle.GetMappedRect(area, ratio);
        }

        /// <summary>
        /// 显示操作内容
        /// </summary>
        /// <param name="ratio">显示比例</param>
        public void ShowContext(float ratio)
        {
            if (this.context != null)
            {
                Rectangle rect = this.GetRect(ratio);

                this.context.Show(rect);
            }
        }

        /// <summary>
        /// 移动操作面板矩形
        /// </summary>
        /// <param name="rect">选中区域</param>
        /// <param name="contextRect">操作区域</param>
        /// <returns>重新计算后的面板位置</returns>
        public Point Move(Rectangle rect, Rectangle contextRect)
        {
            Point location = new Point(rect.Right - contextRect.Width, rect.Bottom + 5);

            if (location.X < 0)
            {
                location.X = 0;
            }

            return location;
        }

        /// <summary>
        /// 隐藏内容区
        /// </summary>
        public void HideContext()
        {
            if (this.context != null)
            {
                this.context.Hide();
            }
        }

    }
}