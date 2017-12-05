using System;
using System.Xml.Serialization;

namespace YXH.Model
{
    /// <summary>
    /// 隐藏区域
    /// </summary>
    [Serializable]
    public class HideArea
    {
        /// <summary>
        /// 区块编号
        /// </summary>
        [XmlIgnore]
        public int AreaID;
        /// <summary>
        /// 是否考号区域
        /// </summary>
        [XmlIgnore]
        public bool IsSchoolNum;
        /// <summary>
        /// 区域坐标信息
        /// </summary>
        public CvRect HideAreaRect;
        /// <summary>
        /// 试题类型
        /// </summary>
        public int TopicType;
    }
}
