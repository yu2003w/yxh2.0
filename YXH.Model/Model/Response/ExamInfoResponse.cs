using System.Collections.Generic;
using YXH.HttpHelper.Response;

namespace YXH.Model
{
    /// <summary>
    /// 考试信息列表api返回数据
    /// </summary>
    public class ExamInfoResponse : ApiResponse<List<ExamInfo>>
    {
        /// <summary>
        /// 自带解析结果集的构造函数
        /// </summary>
        /// <param name="eiList">需要解析的对象列表</param>
        public ExamInfoResponse(List<ExamInfo> eiList) : base(eiList) { }
        
        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public ExamInfoResponse() { }
    }
}
