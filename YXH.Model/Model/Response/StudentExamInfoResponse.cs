using System.Collections.Generic;
using YXH.HttpHelper.Response;

namespace YXH.Model
{
    /// <summary>
    /// 学生考试api返回数据
    /// </summary>
    public class StudentExamInfoResponse : ApiResponse<List<StudentExamInfo>>
    {
        /// <summary>
        /// 解析学生考试信息的构造
        /// </summary>
        /// <param name="seiList">接口学生考试信息</param>
        public StudentExamInfoResponse(List<StudentExamInfo> seiList) : base(seiList) { }

        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public StudentExamInfoResponse() { }
    }
}
