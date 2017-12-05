using System;

namespace YXH.Model
{
    /// <summary>
    /// 条形码考号
    /// </summary>
    [Serializable]
    public class BarCodeSchoolNumber
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type;
        /// <summary>
        /// 是水平的
        /// </summary>
        public bool isHorizontal;
        /// <summary>
        /// 条形码考号矩形
        /// </summary>
        public CvRect region;
    }
}
