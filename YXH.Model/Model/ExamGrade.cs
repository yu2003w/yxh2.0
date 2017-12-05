namespace YXH.Model
{
    /// <summary>
    /// 考试组信息
    /// </summary>
    public class ExamGrade
    {
        /// <summary>
        /// 年级编码1，2，3，4，5，6，7，8，9
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// 考试年级名称
        /// </summary>
        public string GradeName { get; set; }

        /// <summary>
        /// 考试年级班级名称
        /// </summary>
        public string GradeClassName { get; set; }
    }
}
