using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 客观题识别
    /// </summary>
    [Serializable]
    public class OmrObjective
    {
        /// <summary>
        /// 题类型（默认选择题）
        /// </summary>
        public int topicType;
        /// <summary>
        /// 客观题区域（整体区域）
        /// </summary>
        public CvRect region;
        /// <summary>
        /// 识别项列表（题列表）
        /// </summary>
        public OmrObjectiveItem[] objectiveItems;
        /// <summary>
        /// 识别斑点排序
        /// </summary>
        [XmlIgnore]
        public int ItemBlobSort;
        /// <summary>
        /// 识别文字排序
        /// </summary>
        [XmlIgnore]
        public int OcrSort;
        /// <summary>
        /// 项间距
        /// </summary>
        [XmlIgnore]
        public int ItemDistance;
        /// <summary>
        /// 项斑点间距
        /// </summary>
        [XmlIgnore]
        public int ItemBlobDistance;
        /// <summary>
        /// 识别题号间距
        /// </summary>
        [XmlIgnore]
        public int OcrBlobDistance;
        /// <summary>
        /// 考号点数组
        /// </summary>
        private Point[] _schoolNumberPoints;
        /// <summary>
        /// 客观题识别字符串
        /// </summary>
        private string _omrObjectiveString;
        /// <summary>
        /// 源编号列表
        /// </summary>
        [XmlIgnore]
        public List<KeyValue<int, Point>> originnumList { get; set; }
        /// <summary>
        /// 源斑点列表
        /// </summary>
        [XmlIgnore]
        public List<CvRect> originblobList { get; set; }
        /// <summary>
        /// 题号列表
        /// </summary>
        [XmlIgnore]
        public List<KeyValue<int, Point>> numList
        {
            get
            {
                List<KeyValue<int, Point>> list = new List<KeyValue<int, Point>>();

                for (int i = 0; i < this.objectiveItems.Length; i++)
                {
                    if (this.objectiveItems[i].num.number > 0)
                    {
                        list.Add(new KeyValue<int, Point>(this.objectiveItems[i].num.number, this.objectiveItems[i].num.pos));
                    }
                }

                return list;
            }
        }
        /// <summary>
        /// 斑点列表
        /// </summary>
        [XmlIgnore]
        public List<CvRect> blobList
        {
            get
            {
                List<CvRect> list = new List<CvRect>();

                for (int i = 0; i < this.objectiveItems.Length; i++)
                {
                    list.AddRange(this.objectiveItems[i].ItemRects);
                }

                return list;
            }
        }
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
        /// 客观题识别字符串
        /// </summary>
        public string OmrObjectiveString
        {
            get
            {
                if (this._omrObjectiveString == null)
                {
                    this._omrObjectiveString = this.ToString();
                }

                return this._omrObjectiveString;
            }
        }

        /// <summary>
        /// 将识别内容转换为字符串
        /// </summary>
        /// <returns>转换后的字符串</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (OmrObjectiveItem current in from i in this.objectiveItems
                                                 orderby i.num
                                                 select i)
            {
                stringBuilder.Append("[");

                CvRect[] itemRects = current.ItemRects;

                for (int j = 0; j < itemRects.Length; j++)
                {
                    CvRect cvRect = itemRects[j];

                    stringBuilder.Append(cvRect.x).Append(",").Append(cvRect.y).Append(",").Append(cvRect.width).Append(",").Append(cvRect.height).Append(";");
                }

                stringBuilder.Append("]");
            }

            return stringBuilder.ToString();
        }
    }
}
