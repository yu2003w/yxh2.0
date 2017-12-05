using System.Collections.Generic;
using YXH.HttpHelper.Response;

namespace YXH.Model
{
    /// <summary>
    /// 考试组api请求返回信息
    /// </summary>
    public class ExamGroupResponse : ApiResponse<List<ExamGroup>>
    {
        /// <summary>
        /// 解析考试组信息列表
        /// </summary>
        /// <param name="egList">考试组信息列表对象</param>
        public ExamGroupResponse(List<ExamGroup> egList) : base(egList) { }

        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public ExamGroupResponse() { }
    }
}
