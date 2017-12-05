using System.Collections.Generic;
using YXH.HttpHelper.Response;

namespace YXH.Model
{
    /// <summary>
    /// 用户权限接口api返回数据
    /// </summary>
    public class PermissionResponse : ApiResponse<List<string>>
    {
        /// <summary>
        /// 解析用户权限请求信息的构造
        /// </summary>
        /// <param name="pList">接口返回的权限信息</param>
        public PermissionResponse(List<string> pList) : base(pList) { }

        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public PermissionResponse() { }
    }
}
