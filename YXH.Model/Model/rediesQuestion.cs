namespace YXH.Model
{
    /// <summary>
    /// 准备好的问题
    /// </summary>
    public class rediesQuestion
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
        /// 问题ID
        /// </summary>
        public int questionId { get; set; }
        /// <summary>
        /// 是否客观题
        /// </summary>
        public int isObjective { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public int title { get; set; }
        /// <summary>
        /// 选择数量
        /// </summary>
        public int choiceCount { get; set; }
    }
}
