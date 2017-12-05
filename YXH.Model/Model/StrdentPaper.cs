using System.Collections.Generic;

namespace YXH.Model
{
    /// <summary>
    /// 扫描考卷信息
    /// </summary>
    public class StudentPaper
    {
        /// <summary>
        /// 年级考试科目信息 
        /// </summary>
        public int CsID { get; set; }

        /// <summary>
        /// 考生试卷扫描批次号
        /// </summary>
        public string BatchNum { get; set; }

        /// <summary>
        /// 批次对应的考生试卷数量 
        /// </summary>
        public int SpCnt;

        /// <summary>
        /// 批次下所有考卷列表
        /// </summary>
        public List<StudentPaperPic> StudentPaperPicList { get; set; }
    }
}
