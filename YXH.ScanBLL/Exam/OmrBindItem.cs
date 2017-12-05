using System.Collections.Generic;
using System.Drawing;
using YXH.Enum;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 识别绑定项
    /// </summary>
    public class OmrBindItem
    {
        /// <summary>
        /// 客观题编号
        /// </summary>
        public int ObjectiveID { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// 修改状态
        /// </summary>
        public int ModifyStatus { get; set; }
        /// <summary>
        /// 项数量
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// 是多选
        /// </summary>
        public bool MultiSelect { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int pageindex { get; set; }
        /// <summary>
        /// 检查状态
        /// </summary>
        public List<bool> CheckStatus { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public List<Rectangle> Rects { get; set; }
        /// <summary>
        /// 识别值类型
        /// </summary>
        public OmrValueType omrValType { get; set; }

        public OmrBindItem()
        {
            this.Rects = new List<Rectangle>();
            this.CheckStatus = new List<bool>();
        }
    }
}