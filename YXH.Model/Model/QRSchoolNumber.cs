using System.Drawing;

namespace YXH.Model
{
    /// <summary>
    /// 二维码类型的考号
    /// </summary>
    public class QRSchoolNumber
    {
        /// <summary>
        /// 类别
        /// </summary>
        public int Type;
        /// <summary>
        /// 二维码区域
        /// </summary>
        public CvRect region;
        /// <summary>
        /// 二维码考号点集合
        /// </summary>
        private Point[] _schoolNumberPoints;
        /// <summary>
        /// 二维码考号点集合
        /// </summary>
        public Point[] SchoolNumberPoints
        {
            get
            {
                if (this._schoolNumberPoints == null)
                {
                    this._schoolNumberPoints = Points.GetPointsFromRectangle(this.region);
                }

                return this._schoolNumberPoints;
            }
        }
    }
}
