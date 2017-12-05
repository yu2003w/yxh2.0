using System.Collections.Generic;
using System.Drawing;

namespace YXH.Model
{
    /// <summary>
    /// 点列表
    /// </summary>
    public class Points
    {
        /// <summary>
        /// 点集合
        /// </summary>
        /// <param name="rectangle">矩形类</param>
        /// <returns>返回点集合</returns>
        public static Point[] GetPointsFromRectangle(CvRect rectangle)
        {
            Point item = new Point(rectangle.x, rectangle.y);
            Point item2 = new Point(rectangle.x + rectangle.width, rectangle.y);
            Point item3 = new Point(rectangle.x + rectangle.width, rectangle.y + rectangle.height);
            Point item4 = new Point(rectangle.x, rectangle.y + rectangle.height);

            return new List<Point>
			{
				item,
				item2,
				item3,
				item4,
				item
			}.ToArray();
        }
    }
}
