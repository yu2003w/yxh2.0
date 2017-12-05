using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace YXH.Model
{
    /// <summary>
    /// 主观题识别
    /// </summary>
    [Serializable]
    public class OmrSubjective
    {
        /// <summary>
        /// 创建一个新实例的构造函数
        /// </summary>
        /// <param name="osModel"></param>
        public OmrSubjective(OmrSubjective osModel)
        {
            AreaID = osModel.AreaID;
            regionList = new List<CvRect>(osModel.regionList);
            TopicType = osModel.TopicType;
            StartQid = osModel.StartQid;
            EndQid = osModel.EndQid;
        }

        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public OmrSubjective() { }

        [XmlIgnore]
        public int AreaID { get; set; }
        /// <summary>
        /// 主观题区域组
        /// </summary>
        public List<CvRect> regionList;
        /// <summary>
        /// 试题类型
        /// </summary>
        public int TopicType { get; set; }
        /// <summary>
        /// 开始题号
        /// </summary>
        public int StartQid { get; set; }
        /// <summary>
        /// 结束题号
        /// </summary>
        public int EndQid { get; set; }
    }
}
