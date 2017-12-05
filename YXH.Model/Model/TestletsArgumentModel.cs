namespace YXH.Model
{
    /// <summary>
    /// 考试参数实体
    /// </summary>
    public class TestletsArgumentModel
    {
        /// <summary>
        /// 选项数量
        /// </summary>
        public int OptionsNumber { get; set; }
        /// <summary>
        /// 题目数量
        /// </summary>
        public int ItemNumber { get; set; }
        /// <summary>
        /// 参数模式
        /// </summary>
        public int ArrangementMode { get; set; }
        /// <summary>
        /// 开始题号
        /// </summary>
        public int StartQID { get; set; }

        /// <summary>
        /// 结束题号
        /// </summary>
        public int EndQID { get; set; }
    }
}