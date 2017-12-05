using System;

namespace YXH.Model
{
    /// <summary>
    /// 试卷信息实体
    /// </summary>
    public class ExamPaper
    {
        /// <summary>
        /// 试卷ID
        /// </summary>
        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set { }
        }
        /// <summary>
        /// 试卷编号
        /// </summary>
        public string ExamNumber { get; set; }
        /// <summary>
        /// 扫描时间
        /// </summary>
        public DateTime ScanTime { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 是正常状态
        /// </summary>
        public bool IsOK { get; set; }
        /// <summary>
        /// 分页信息
        /// </summary>
        public Page PageInfo { get; set; }
    }
}
