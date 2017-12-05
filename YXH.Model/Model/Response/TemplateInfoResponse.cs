using System;
using YXH.HttpHelper.Response;

namespace YXH.Model
{
    /// <summary>
    /// 获取模板信息的api返回数据
    /// </summary>
    public class TemplateInfoResponse : ApiResponse<ZKTemplateInfo>
    {
        public TemplateInfoResponse(ZKTemplateInfo ti) : base(ti) { }
    }
}
