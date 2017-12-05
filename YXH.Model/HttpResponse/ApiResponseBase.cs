namespace YXH.HttpHelper.Response
{
    /// <summary>
    /// 请求api返回结果的基础类
    /// </summary>
    public abstract class ApiResponseBase
    {
        /// <summary>
        /// 空的构造函数
        /// </summary>
        public ApiResponseBase() { }

        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 当请求失败时返回的消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public ErrorInfo Error { get; set; }
    }
}
