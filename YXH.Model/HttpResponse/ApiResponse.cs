namespace YXH.HttpHelper.Response
{
    /// <summary>
    /// 请求api返回结果的基础类
    /// </summary>
    public class ApiResponse : ApiResponse<object>
    {
        /// <summary>
        /// 空的构造函数
        /// </summary>
        public ApiResponse() { }

        /// <summary>
        /// 访问是否成功的构造函数
        /// </summary>
        /// <param name="success">访问状态结果</param>
        public ApiResponse(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// 填充错误信息的构造函数
        /// </summary>
        /// <param name="message">错误信息</param>
        public ApiResponse(string message)
        {
            Message = message;
        }

        /// <summary>
        /// 填充返回对象构造函数
        /// </summary>
        /// <param name="result">返回对象</param>
        public ApiResponse(object result)
        {
            Data = result;
        }

        /// <summary>
        /// 填充错误信息的构造函数
        /// </summary>
        /// <param name="error">错误信息</param>
        /// <param name="unAuthorizedRequest">是否授权的请求</param>
        public ApiResponse(ErrorInfo error, bool unAuthorizedRequest = false)
        {
            Error = error;
        }
    }
}
