using System.Collections.Generic;
using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 保存学生试卷信息模型
    /// </summary>
    public class StudentItemPaperInfo
    {
        public string SCHOOLID { get; set; }

        public int GRADEID { get; set; }

        public int SUBJECTID { get; set; }
        /// <summary>
        /// 考生考试ID
        /// </summary>
        public string ESID { get; set; }
        /// <summary>
        /// 批次编号
        /// </summary>
        public int BatchNum { get; set; }
        /// <summary>
        /// 试卷原图地址,多个图片用","隔开
        /// </summary>
        public string StuAPPath { get; set; }
        /// <summary>
        /// 试卷类型  0.正常，1.缺考，2.异常 ,
        /// </summary>
        public int PaperStatus { get; set; }
        /// <summary>
        /// 扫描试卷对应客观题答案 
        /// </summary>
        public ObjectItem[] Exam_Student_Score { get; set; }

        /// <summary>
        /// 试卷已处理的错误
        /// </summary>
        public List<ErrorStatus> HistoryErrorStatusList { get; set; }
    }
}
