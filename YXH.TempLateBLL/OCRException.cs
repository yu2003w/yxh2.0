using System;

namespace YXH.TemplateBLL
{
    /// <summary>
    /// 文字识别异常类
    /// </summary>
    public class OCRException : Exception
    {
        /// <summary>
        /// 文字识别异常
        /// </summary>
        /// <param name="message">消息内容</param>  
        public OCRException(string message) : base(message) { }

        /// <summary>
        /// 文字识别异常
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="innerexception">异常信息</param>
        public OCRException(string message, Exception innerexception) : base(message, innerexception) { }
    }
}
