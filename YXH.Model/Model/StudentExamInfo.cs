namespace YXH.Model
{
    /// <summary>
    /// 学生考试信息
    /// </summary>
    public class StudentExamInfo
    {
        /// <summary>
        /// 同学生ID
        /// </summary>
        public long EsID { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StuName { get; set; }
        /// <summary>
        /// 班级名称，绑定list报错实验
        /// </summary>
        public string ClassName { get { return "1"; } }
        /// <summary>
        /// 考场
        /// </summary>
        public string Room { get; set; }
        /// <summary>
        /// 班级ID，绑定list报错实验
        /// </summary>
        public string ClassId { get { return "1"; } }
        /// <summary>
        /// 学生姓名拼音
        /// </summary>
        public string StudentNamePinYin { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string ExamCode { get; set; }

        /// <summary>
        /// 缺考状态
        /// </summary>
        public int PaperStatus { get; set; }
    }
}
