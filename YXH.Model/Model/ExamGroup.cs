namespace YXH.Model
{
    /// <summary>
    /// 考试组信息模型
    /// </summary>
    public class ExamGroup
    {
        /// <summary>
        /// 数据ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 考试组名称
        /// </summary>
        public string ExamName { get; set; }

        /// <summary>
        /// 考试时间
        /// </summary>
        public string ExamDate { get; set; }

        /// <summary>
        /// 考试类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 考试状态
        /// </summary>
        public string Status { get; set; }
    }
}
