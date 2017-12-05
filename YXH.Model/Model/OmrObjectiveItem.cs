using System;
using System.Xml.Serialization;

namespace YXH.Model
{
    /// <summary>
    /// 客观题识别项
    /// </summary>
    [Serializable]
    public class OmrObjectiveItem
    {
        /// <summary>
        /// 斑点类型（方括号或矩形框）
        /// </summary>
        public int arrange;
        /// <summary>
        /// 题号信息
        /// </summary>
        public Num num;
        /// <summary>
        /// 当前题目每个斑点的坐标区域
        /// </summary>
        public CvRect[] ItemRects;
        /// <summary>
        /// 识别是否有疑问
        /// </summary>
        [XmlIgnore]
        public bool OcrDoubt;

        /// <summary>
        /// 构造方法
        /// </summary>
        public OmrObjectiveItem() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="num">编号</param>
        /// <param name="ItemRects">识别矩形数组</param>
        public OmrObjectiveItem(Num num, CvRect[] ItemRects)
        {
            this.num = num;
            this.ItemRects = ItemRects;
        }
    }
}
