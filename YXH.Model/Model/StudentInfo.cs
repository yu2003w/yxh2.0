namespace YXH.Model
{
    /// <summary>
    /// 学生信息实体
    /// </summary>
    public class StudentInfo
    {
        /// <summary>
        /// 考试ID
        /// </summary>
        public long ExamId { get; set; }
        /// <summary>
        /// 考试名称
        /// </summary>
        public string ExamName { get; set; }
        /// <summary>
        /// 主题名称
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// 批次ID
        /// </summary>
        public int BatchID { get; set; }
        /// <summary>
        /// 考场
        /// </summary>
        public string Room { get; set; }
        /// <summary>
        /// 考试座位号
        /// </summary>
        public string ExamSeatNumber { get; set; }
        /// <summary>
        /// 学生名称
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// 错误
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// 原错误
        /// </summary>
        public string Error_Origin { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string Schoolnumber { get; set; }
        /// <summary>
        /// 源学号
        /// </summary>
        public string Schoolnumber_Origin { get; set; }
        /// <summary>
        /// 是学号错误
        /// </summary>
        public string IsSchoolNumberError { get; set; }
        /// <summary>
        /// 学号错误类型
        /// </summary>
        public string SchoolNumberErrorType { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 识别内容
        /// </summary>
        public string Omr { get; set; }
        /// <summary>
        /// 源识别内容
        /// </summary>
        public string Omr_origin { get; set; }
        /// <summary>
        /// 识别内容手动保存
        /// </summary>
        public string Omr_ManualSave { get; set; }
        /// <summary>
        /// 识别内容错误类型
        /// </summary>
        public string OMr_ErrorType { get; set; }
        /// <summary>
        /// 扫描时间
        /// </summary>
        public string ScanTime { get; set; }
        /// <summary>
        /// 卷标状态
        /// </summary>
        public string VolumnStatus { get; set; }
        /// <summary>
        /// 源卷标状态
        /// </summary>
        public string VolumnStatus_Origin { get; set; }
    }
}
