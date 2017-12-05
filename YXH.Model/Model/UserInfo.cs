using System.Collections.Generic;
using YXH.HttpHelper.Response;

namespace YXH.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo : ApiResponse
    {
        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public UserInfo() { }

        /// <summary>
        /// 需要填充result的构造函数
        /// </summary>
        /// <param name="result">需要填充result的值</param>
        public UserInfo(object result) : base(result) { }

        public Teacher data { get; set; }
    }
}
