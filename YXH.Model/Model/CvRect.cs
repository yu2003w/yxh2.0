using System.Drawing;

namespace YXH.Model
{
    /// <summary>
    /// 视觉库矩形
    /// </summary>
    public struct CvRect
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public int x;
        /// <summary>
        /// Y坐标
        /// </summary>
        public int y;
        /// <summary>
        /// 矩形宽度
        /// </summary>
        public int width;
        /// <summary>
        /// 矩形高度
        /// </summary>
        public int height;
        /// <summary>
        /// 矩形底边位置
        /// </summary>
        public int bottom
        {
            get
            {
                return this.y + this.height;
            }
        }
        /// <summary>
        /// 矩形右边框位置
        /// </summary>
        public int right
        {
            get
            {
                return this.x + this.width;
            }
        }

        /// <summary>
        /// 带参数的构造方法
        /// </summary>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public CvRect(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public CvRect(CvRect cr)
        {
            x = cr.x;
            y = cr.y;
            width = cr.width;
            height = cr.height;
        }

        public CvRect(Rectangle r)
        {
            x = r.X;
            y = r.Y;
            width = r.Width;
            height = r.Height;
        }

        /// <summary>
        /// 声明操作
        /// </summary>
        /// <param name="r1">操作参数1</param>
        /// <param name="r2">操作参数2</param>
        /// <returns>操作结果</returns>
        public static bool operator ==(CvRect r1, CvRect r2)
        {
            return r1.x == r2.x && r1.y == r2.y && r1.width == r2.width && r1.height == r2.height;
        }

        /// <summary>
        /// 声明操作
        /// </summary>
        /// <param name="r1">操作参数1</param>
        /// <param name="r2">操作参数2</param>
        /// <returns>操作结果</returns>
        public static bool operator !=(CvRect r1, CvRect r2)
        {
            return !(r1 == r2);
        }
    }
}
