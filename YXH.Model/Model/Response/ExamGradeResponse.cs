using System.Collections.Generic;
using YXH.HttpHelper.Response;

namespace YXH.Model
{
    /// <summary>
    /// 考试组api请求返回信息
    /// </summary>
    public class ExamGradeResponse : ApiResponse<List<ExamGrade>>
    {
        /// <summary>
        /// 解析年级班级信息列表
        /// </summary>
        /// <param name="egList">考试组信息列表对象</param>
        public ExamGradeResponse(List<ExamGrade> egList) : base(egList) { }

        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public ExamGradeResponse() { }
    }
}
