using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace YXH.Model
{
    /// <summary>
    /// 考号识别内容
    /// </summary>
    [Serializable]
    public class OmrSchoolNumber
    {
        /// <summary>
        /// 考号矩形区域
        /// </summary>
        public CvRect region;
        /// <summary>
        /// 考号矩形区域集合
        /// </summary>
        public List<CvRect[]> omrs = new List<CvRect[]>();
        /// <summary>
        /// 考号点集合
        /// </summary>
        private Point[] _schoolNumberPoints;
        /// <summary>
        /// 考号识别字符串
        /// </summary>
        private string _omrSchoolNumberString;
        /// <summary>
        /// 考号点集合
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
        /// <summary>
        /// 考号识别内容字符串
        /// </summary>
        public string OmrSchoolNumberString
        {
            get
            {
                if (this._omrSchoolNumberString == null)
                {
                    this._omrSchoolNumberString = this.ToString();
                }

                return this._omrSchoolNumberString;
            }
        }
        /// <summary>
        /// 将矩形集合转化为字符串
        /// </summary>
        /// <returns>返回转化后的字符串</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (CvRect[] current in this.omrs)
            {
                stringBuilder.Append("[");

                CvRect[] array = current;

                for (int i = 0; i < array.Length; i++)
                {
                    CvRect cvRect = array[i];

                    stringBuilder.Append(cvRect.x).Append(",").Append(cvRect.y).Append(",").Append(cvRect.width).Append(",").Append(cvRect.height).Append(";");
                }

                stringBuilder.Append("]");
            }

            return stringBuilder.ToString();
        }
    }
}
