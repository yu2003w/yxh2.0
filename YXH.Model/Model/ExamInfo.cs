using System.Collections.Generic;
using YXH.Enum;
using YXH.Twain.Structure.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 考试信息
    /// </summary>
    public class ExamInfo
    {
        /// <summary>
        /// 扫描记录列表
        /// </summary>
        private static SynchronizedCollection<ScanRecord> _scanRecordList;
        /// <summary>
        /// 学生考试信息列表
        /// </summary>
        private static List<StudentExamInfo> _studentExamInfoList;
        /// <summary>
        /// 是双面试卷
        /// </summary>
        public bool IsDoubleSide;

        /// <summary>
        /// 支持纸张大小
        /// </summary>
        public SuportSize Papersize;

        /// <summary>
        /// 考试ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 考试关联id
        /// </summary>
        public int CsID { get; set; }
        /// <summary>
        /// 学校编号
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// 学生考试信息列表
        /// </summary>
        public List<StudentExamInfo> StudentExamInfoList
        {
            get
            {
                if (ExamInfo._studentExamInfoList == null)
                {
                    ExamInfo._studentExamInfoList = new List<StudentExamInfo>();
                }

                return ExamInfo._studentExamInfoList;
            }
            set
            {
                ExamInfo._studentExamInfoList = value;
            }
        }

        /// <summary>
        /// 扫描记录列表
        /// </summary>
        public SynchronizedCollection<ScanRecord> ScanRecordList
        {
            get
            {
                if (ExamInfo._scanRecordList == null)
                {
                    ExamInfo._scanRecordList = new SynchronizedCollection<ScanRecord>();
                }

                return ExamInfo._scanRecordList;
            }
            set
            {
                ExamInfo._scanRecordList = value;
            }
        }

        /// <summary>
        /// 考试名称
        /// </summary>
        public string ExamName { get; set; }

        /// <summary>
        /// 文件目录
        /// </summary>
        public int Fdir { get; set; }

        /// <summary>
        /// 缓存目录
        /// </summary>
        public int Bdir { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public int GradeCode { get; set; }

        /// <summary>
        /// 年级名称
        /// </summary>
        public string GradeName { get; set; }

        /// <summary>
        /// 科目ID
        /// </summary>
        public int SubjectID { get; set; }

        /// <summary>
        /// 科目名称
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// 模板文件ID
        /// </summary>
        public string TpFileId { get; set; }

        /// <summary>
        /// 是否扫描完成
        /// </summary>
        public bool IsScanFinish { get; set; }
        /// <summary>
        /// 考试类型
        /// </summary>
        public ExamType ExamType { get; set; }

        /// <summary>
        /// 科目类型
        /// </summary>
        public string SubjectType { get; set; }

        /// <summary>
        /// 扫描完成时间
        /// </summary>
        public string ScanFinishTime { get; set; }

        /// <summary>
        /// 当前科目的模板状态
        /// </summary>
        public int TemplatStatus { get; set; }

        /// <summary>
        /// 已上传的批次数量
        /// </summary>
        public int UploadBathCount { get; set; }
    }
}
