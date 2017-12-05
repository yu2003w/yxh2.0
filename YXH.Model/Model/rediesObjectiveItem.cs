namespace YXH.Model
{
    /// <summary>
    /// 准备好的客观题信息
    /// </summary>
    public class rediesObjectiveItem
    {
        /// <summary>
        /// 考试ID
        /// </summary>
        public long examId { get; set; }
        /// <summary>
        /// 项编号
        /// </summary>
        public int itemNo { get; set; }
        /// <summary>
        /// 开始位置
        /// </summary>
        public int start { get; set; }
        /// <summary>
        /// 结束位置
        /// </summary>
        public int end { get; set; }
        /// <summary>
        /// 问题数量
        /// </summary>
        public int questionCount { get; set; }
        /// <summary>
        /// 页数量
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 区域横坐标
        /// </summary>
        public double x { get; set; }
        /// <summary>
        /// 区域纵坐标
        /// </summary>
        public double y { get; set; }
        /// <summary>
        /// 区域宽度
        /// </summary>
        public double width { get; set; }
        /// <summary>
        /// 区域高度
        /// </summary>
        public double height { get; set; }
    }
}
