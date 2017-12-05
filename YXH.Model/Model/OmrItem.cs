using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 识别项
    /// </summary>
    public class OmrItem
    {
        /// <summary>
        /// 目标ID
        /// </summary>
        public int ObjectiveID { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// 识别值类型
        /// </summary>
        public OmrValueType type { get; set; }
    }
}
