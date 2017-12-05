using System.Collections.Generic;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 异常试卷信息
    /// </summary>
    public class IncorrectExamPaperInfo
    {
        /// <summary>
        /// 学生信息错误列表
        /// </summary>
        public List<VolumnDataRow> StudentInfoErrorList { get; set; }
        /// <summary>
        /// 试卷信息错误列表
        /// </summary>
        public List<VolumnDataRow> ExamPaperInfoErrorList { get; set; }
        /// <summary>
        /// 客观题信息错误列表
        /// </summary>
        public List<VolumnDataRow> ObjectiveOmrErrorList { get; set; }

        /// <summary>
        /// 学生信息错误列表
        /// </summary>
        public int StudentInfoErrorCount
        {
            get
            {
                if (this.StudentInfoErrorList != null)
                {
                    return this.StudentInfoErrorList.Count;
                }

                return 0;
            }
        }
        /// <summary>
        /// 试卷信息错误列表
        /// </summary>
        public int ExamPaperInfoErrorCount
        {
            get
            {
                if (this.ExamPaperInfoErrorList != null)
                {
                    return this.ExamPaperInfoErrorList.Count;
                }

                return 0;
            }
        }
        /// <summary>
        /// 客观题信息错误列表
        /// </summary>
        public int ObjectiveOmrErrorCount
        {
            get
            {
                if (this.ObjectiveOmrErrorList != null)
                {
                    return this.ObjectiveOmrErrorList.Count;
                }

                return 0;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public IncorrectExamPaperInfo()
        {
            this.StudentInfoErrorList = new List<VolumnDataRow>();
            this.ExamPaperInfoErrorList = new List<VolumnDataRow>();
            this.ObjectiveOmrErrorList = new List<VolumnDataRow>();
        }
    }
}
