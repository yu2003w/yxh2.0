using System;
using System.Drawing;

namespace YXH.Model
{
    /// <summary>
    /// 本地标题
    /// </summary>
    [Serializable]
    public class TitleLocal
    {
        /// <summary>
        /// 矩形
        /// </summary>
        public CvRect matchRegion;
        /// <summary>
        /// 标题点集合
        /// </summary>
        private Point[] _titlePoints;
        /// <summary>
        /// 标题点集合
        /// </summary>
        public Point[] TitlePoints
        {
            get
            {
                if (this._titlePoints == null)
                {
                    this._titlePoints = Points.GetPointsFromRectangle(this.matchRegion);
                }

                return this._titlePoints;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public TitleLocal() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="rect">矩形</param>
        public TitleLocal(CvRect rect)
        {
            this.matchRegion = rect;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <param name="width">区域宽度</param>
        /// <param name="height">区域高度</param>
        public TitleLocal(int x, int y, int width, int height)
        {
            matchRegion.x = x;
            matchRegion.y = y;
            matchRegion.width = width;
            matchRegion.height = height;
        }
    }
}
