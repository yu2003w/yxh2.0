using System;

namespace YXH.TemplateBLL
{
    /// <summary>
    /// 斑点异常类
    /// </summary>
    public class BlobException : Exception
    {
        /// <summary>
        /// 斑点异常
        /// </summary>
        /// <param name="message">消息内容</param>
        public BlobException(string message) : base(message) { }

        /// <summary>
        /// 斑点异常
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="innerexception">异常信息</param>
        public BlobException(string message, Exception innerexception) : base(message, innerexception) { }
    }
}
