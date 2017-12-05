using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 联考学校信息
    /// </summary>
    public class UnionExamSchoolInfo
    {
        /// <summary>
        /// 考试ID
        /// </summary>
        public long ExamId { get; set; }
        /// <summary>
        /// 学校ID
        /// </summary>
        public int SchoolId { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 学校角色
        /// </summary>
        public UnionExamSchoolRole SchoolRole { get; set; }
        /// <summary>
        /// 是否已上传到阿里云
        /// </summary>
        public bool HasUploadTpl { get; set; }
        /// <summary>
        /// 金山云密钥路径
        /// </summary>
        public string KsTpleKeyPath
        {
            get
            {
                return string.Concat(new object[]
                {
					"file/v/",
					this.ExamId,
					"/",
					this.SchoolId,
					"/",
					this.ExamId,
					"/",
					this.ExamId,
					".zip"
				});
            }
        }
        /// <summary>
        /// 是否已完成扫描
        /// </summary>
        public bool HasFinishedScan { get; set; }
    }
}
