using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using YXH.Common;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 可调整大小的矩形区域
    /// </summary>
    public class ResizableRectangle
    {
        /// <summary>
        /// 操作点大小
        /// </summary>
        private const int GRIP_SIZE = 5;
        /// <summary>
        /// 框选区域的矩形
        /// </summary>
        protected Rectangle area;
        /// <summary>
        /// 追踪点
        /// </summary>
        protected Point trackingPoint;
        /// <summary>
        /// 当前操作点索引
        /// </summary>
        protected int currentGripIndex;
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isValid;
        /// <summary>
        /// 试卷图片窗体
        /// </summary>
        protected ExamImageForm imageForm;
        /// <summary>
        /// 操作内容控件
        /// </summary>
        public OperationContext context;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="form">试卷图片窗体</param>
        public ResizableRectangle(ExamImageForm form)
        {
            this.imageForm = form;
            this.area = Rectangle.Empty;
            this.trackingPoint = Point.Empty;
            this.currentGripIndex = -1;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="context">操作内容</param>
        public void SetContext(OperationContext context)
        {
            this.context = context;
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
        /// 移动操作内容
        /// </summary>
        /// <param name="ratio">显示比例</param>
        public void MoveContext(float ratio)
        {
            if (this.context != null)
            {
                Rectangle rect = this.GetRect(ratio);

                this.context.Move(rect);
            }
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

        /// <summary>
        /// 是否与选定区重叠
        /// </summary>
        /// <param name="p">内容区坐标</param>
        /// <returns>重叠状态</returns>
        public bool Contains(Point p)
        {
            return this.area.Contains(p);
        }

        /// <summary>
        /// 捕获鼠标坐标
        /// </summary>
        /// <param name="p">鼠标坐标</param>
        /// <param name="ratio">比例</param>
        /// <returns>捕获状态</returns>
        public bool CaptureMousePoint(Point p, float ratio)
        {
            return this.GetMappedGripIndex(p, ratio) != -1;
        }

        /// <summary>
        /// 获取衔接点
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>衔接点</returns>
        public Point GetGripPoint(int index)
        {
            int num = this.area.X + this.area.Width / 2,
                num2 = this.area.Y + this.area.Height / 2,
                x = this.area.X,
                y = this.area.Y;

            switch (index)
            {
                case 1:
                    x = this.area.X;
                    y = this.area.Y;

                    break;
                case 2:
                    x = num;
                    y = this.area.Y;

                    break;
                case 3:
                    x = this.area.Right;
                    y = this.area.Y;

                    break;
                case 4:
                    x = this.area.Right;
                    y = num2;

                    break;
                case 5:
                    x = this.area.Right;
                    y = this.area.Bottom;

                    break;
                case 6:
                    x = num;
                    y = this.area.Bottom;

                    break;
                case 7:
                    x = this.area.X;
                    y = this.area.Bottom;

                    break;
                case 8:
                    x = this.area.X;
                    y = num2;

                    break;
            }

            return new Point(x, y);
        }

        /// <summary>
        /// 获取映射的控制索引
        /// </summary>
        /// <param name="p">当前点</param>
        /// <param name="ratio">操作比例</param>
        /// <returns>控制索引</returns>
        public int GetMappedGripIndex(Point p, float ratio)
        {
            int result = -1;

            for (int i = 1; i <= 8; i++)
            {
                if (this.GetMappedGripRect(i, ratio).Contains(p))
                {
                    return i;
                }
            }
            if (ResizableRectangle.GetMappedRect(this.area, ratio).Contains(p))
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// 获取捕获矩形
        /// </summary>
        /// <param name="index">矩形索引</param>
        /// <returns>矩形数据</returns>
        private Rectangle GetGripRect(int index)
        {
            Point gripPoint = this.GetGripPoint(index);

            return new Rectangle(gripPoint.X - 5, gripPoint.Y - 5, 10, 10);
        }

        /// <summary>
        /// 映射捕获矩形
        /// </summary>
        /// <param name="rect">矩形信息</param>
        /// <param name="ratio">操作比例</param>
        /// <returns>映射到的矩形对象</returns>
        private Rectangle MapGripRect(Rectangle rect, float ratio)
        {
            return new Rectangle
            {
                X = (int)((float)(rect.X + 5) * ratio) - 5,
                Y = (int)((float)(rect.Y + 5) * ratio) - 5,
                Width = 10,
                Height = 10
            };
        }

        /// <summary>
        /// 获取映射到的矩形
        /// </summary>
        /// <param name="index">矩形编号</param>
        /// <param name="ratio">操作比例</param>
        /// <returns></returns>
        private Rectangle GetMappedGripRect(int index, float ratio)
        {
            Rectangle gripRect = this.GetGripRect(index);

            return this.MapGripRect(gripRect, ratio);
        }

        /// <summary>
        /// 获取矩形
        /// </summary>
        /// <param name="ratio">操作比例</param>
        /// <returns>获取到的矩形</returns>
        public Rectangle GetRect(float ratio)
        {
            return ResizableRectangle.GetMappedRect(this.area, ratio);
        }

        /// <summary>
        /// 获取矩形
        /// </summary>
        /// <returns>当前区域</returns>
        public Rectangle GetRect()
        {
            return this.area;
        }

        /// <summary>
        /// 设置矩形
        /// </summary>
        /// <param name="rect">矩形数据</param>
        public void SetRect(Rectangle rect)
        {
            this.area = rect;
        }

        /// <summary>
        /// 获取映射到的矩形
        /// </summary>
        /// <param name="rect">矩形数据</param>
        /// <param name="ratio">操作比例</param>
        /// <returns>映射到的矩形数据</returns>
        public static Rectangle GetMappedRect(Rectangle rect, float ratio)
        {
            return new Rectangle
            {
                X = (int)((float)rect.X * ratio),
                Y = (int)((float)rect.Y * ratio),
                Width = (int)((float)rect.Width * ratio),
                Height = (int)((float)rect.Height * ratio)
            };
        }

        /// <summary>
        /// 获取映射坐标
        /// </summary>
        /// <param name="p">坐标数据</param>
        /// <param name="ratio">操作比例</param>
        /// <returns>映射坐标</returns>
        private Point GetMappedPoint(Point p, float ratio)
        {
            return new Point((int)((float)p.X * ratio), (int)((float)p.Y * ratio));
        }

        /// <summary>
        /// 调整矩形
        /// </summary>
        /// <param name="newTrackingPoint">新坐标点</param>
        public void ResizeRectTo(Point newTrackingPoint)
        {
            int num = this.area.Left,
                num2 = this.area.Top,
                num3 = this.area.Right,
                num4 = this.area.Bottom;

            switch (this.currentGripIndex)
            {
                case 0:
                    this.area.X = this.area.X + (newTrackingPoint.X - this.trackingPoint.X);
                    this.area.Y = this.area.Y + (newTrackingPoint.Y - this.trackingPoint.Y);
                    this.trackingPoint = newTrackingPoint;

                    return;
                case 1:
                    num = newTrackingPoint.X;
                    num2 = newTrackingPoint.Y;

                    break;
                case 2:
                    num2 = newTrackingPoint.Y;

                    break;
                case 3:
                    num3 = newTrackingPoint.X;
                    num2 = newTrackingPoint.Y;

                    break;
                case 4:
                    num3 = newTrackingPoint.X;

                    break;
                case 5:
                    num3 = newTrackingPoint.X;
                    num4 = newTrackingPoint.Y;

                    break;
                case 6:
                    num4 = newTrackingPoint.Y;

                    break;
                case 7:
                    num = newTrackingPoint.X;
                    num4 = newTrackingPoint.Y;

                    break;
                case 8:
                    num = newTrackingPoint.X;

                    break;
            }

            this.trackingPoint = newTrackingPoint;
            this.area.X = num;
            this.area.Y = num2;
            this.area.Width = num3 - num;
            this.area.Height = num4 - num2;
        }

        /// <summary>
        /// 设置光标
        /// </summary>
        /// <param name="index">区域索引</param>
        public void SetCursor(int index)
        {
            Cursor current = Cursors.Default;

            if (index == 1 || index == 5)
            {
                current = Cursors.SizeNWSE;
            }
            else if (index == 2 || index == 6)
            {
                current = Cursors.SizeNS;
            }
            else if (index == 3 || index == 7)
            {
                current = Cursors.SizeNESW;
            }
            else if (index == 4 || index == 8)
            {
                current = Cursors.SizeWE;
            }
            else if (index == 0)
            {
                current = Cursors.SizeAll;
            }

            Cursor.Current = current;
        }

        /// <summary>
        /// 设置起始点
        /// </summary>
        /// <param name="p">起始坐标</param>
        public void SetBeginning(Point p)
        {
            this.area.Location = p;
        }

        /// <summary>
        /// 清理当前区域
        /// </summary>
        public void Clear()
        {
            this.area = Rectangle.Empty;
        }

        /// <summary>
        /// 设置描绘点
        /// </summary>
        /// <param name="p">坐标</param>
        /// <param name="r">操作比例</param>
        /// <param name="showCursor">光标显示状态</param>
        /// <returns>映射点索引</returns>
        public int SetTrackingPoint(Point p, float r, bool showCursor = true)
        {
            int x = (int)((float)p.X / r);
            int y = (int)((float)p.Y / r);
            this.trackingPoint = new Point(x, y);
            int mappedGripIndex = this.GetMappedGripIndex(p, r);
            this.currentGripIndex = mappedGripIndex;

            if (showCursor)
            {
                this.SetCursor(mappedGripIndex);
            }

            return mappedGripIndex;
        }

        /// <summary>
        /// 调整矩位置
        /// </summary>
        public void Adjust()
        {
            int left = this.area.Left;
            int top = this.area.Top;
            int right = this.area.Right;
            int bottom = this.area.Bottom;
            this.area.X = Math.Min(left, right);
            this.area.Y = Math.Min(top, bottom);
            this.area.Width = Math.Abs(left - right);
            this.area.Height = Math.Abs(top - bottom);
        }

        /// <summary>
        /// 调整矩形位置
        /// </summary>
        /// <param name="limited">目标矩形位置</param>
        public void Adjust(Rectangle limited)
        {
            this.Adjust();
            this.area.Intersect(limited);
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="g">画板</param>
        /// <param name="ratio">操作比例</param>
        public void Paint(Graphics g, float ratio)
        {
            bool flag = this == this.imageForm._activeRect;
            Rectangle rect = default(Rectangle);

            rect.X = Math.Min(this.area.Left, this.area.Right);
            rect.Y = Math.Min(this.area.Top, this.area.Bottom);
            rect.Width = Math.Abs(this.area.Left - this.area.Right);
            rect.Height = Math.Abs(this.area.Top - this.area.Bottom);

            Pen pen = new Pen(Color.Red)
            {
                Color = Scheme.CommonHighlightColor,
                DashStyle = DashStyle.Dot,
                Width = 2f
            };
            Rectangle mappedRect = ResizableRectangle.GetMappedRect(rect, ratio);

            g.DrawRectangle(pen, mappedRect);
            this.DrawRectWidAndHeight(g, mappedRect, ratio);

            if (flag)
            {
                for (int i = 1; i <= 8; i++)
                {
                    g.FillEllipse(new SolidBrush(pen.Color), this.GetMappedGripRect(i, ratio));
                }
            }
        }

        /// <summary>
        /// 绘制矩形高度/宽度
        /// </summary>
        /// <param name="g">画板</param>
        /// <param name="rect">矩形数据</param>
        /// <param name="ratio">操作比例</param>
        private void DrawRectWidAndHeight(Graphics g, Rectangle rect, float ratio)
        {
            Font font = new Font("MS Gothic", 9f, FontStyle.Regular);
            Brush brush = new SolidBrush(Color.Blue);

            string s = string.Format("{0}X{1}", Math.Abs(this.area.Width), Math.Abs(this.area.Height));

            g.DrawString(s, font, brush, (float)rect.Left, (float)(rect.Top - 20));
        }

        /// <summary>
        /// 绘制矩形信息
        /// </summary>
        /// <param name="g">画板</param>
        /// <param name="rect">矩形数据</param>
        /// <param name="ratio">操作比例</param>
        private void DrawRectInfo(Graphics g, Rectangle rect, float ratio)
        {
            Font font = new Font(new FontFamily("Comic Sans MS"), 8f, FontStyle.Regular);
            Brush brush = new SolidBrush(Color.CadetBlue);
            Pen pen = new Pen(Color.Red, 2f);
            string s = string.Format("Left: {0}, Rigth: {1}", this.area.Left, this.area.Right);

            g.DrawString(s, font, brush, (float)rect.Left, (float)rect.Bottom);

            s = string.Format("Top: {0}, Bottom: {1}", this.area.Top, this.area.Bottom);

            g.DrawString(s, font, brush, (float)rect.Left, (float)(rect.Bottom + 20));

            s = string.Format("X: {0}, Y: {1}", this.area.X, this.area.Y);

            g.DrawString(s, font, brush, (float)rect.Left, (float)(rect.Bottom + 40));

            s = string.Format("Width: {0}, Height: {1}", this.area.Width, this.area.Height);

            g.DrawString(s, font, brush, (float)rect.Left, (float)(rect.Bottom + 60));

            Point mappedPoint = this.GetMappedPoint(this.trackingPoint, ratio);

            g.DrawEllipse(pen, mappedPoint.X - 10, mappedPoint.Y - 10, 20, 20);

            for (int i = 1; i <= 8; i++)
            {
                mappedPoint = this.GetMappedPoint(this.GetGripPoint(i), ratio);
                s = string.Format("{0}", i);

                g.DrawString(s, font, brush, (float)mappedPoint.X, (float)(mappedPoint.Y - 20));
            }
        }
    }
}
