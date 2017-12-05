using System;
using YXH.Common;
using YXH.HttpHelper.Response;
using System.Net;
using System.Text;
using YXH.Model;
using Newtonsoft.Json;
using YXH.HttpHelper;

namespace YXH.Scanner.DALFactory
{
    /// <summary>
    /// 请求api日志记录
    /// </summary>
    public partial class BaseFactory
    {
        private readonly string _longUserInfo = string.Empty;
        private readonly bool _IsSaveDebug = false;

        public BaseFactory(string loginName)
        {
            _longUserInfo = string.Format("用户：{0}", loginName);
            _IsSaveDebugLog = bool.Parse(ConfigurationHelper.GetSetting("IsSaveDebugLog"));
        }

        /// <summary>
        /// 将日志保存到服务器
        /// </summary>
        /// <param name="bodyMsg">日志消息主体</param>
        /// <param name="type">日志类型，1为错误日志，2为调试日志</param>
        public void System_SaveLogToServer(string bodyMsg, string type)
        {
            if ((type.Equals("2") && _IsSaveDebug) || type.Equals("1"))
            {
                try
                {
                    ScanMsg sm = new ScanMsg()
                    {
                        Msg = string.Format("{0}{1}", _longUserInfo, bodyMsg)
                    };

                    //HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.LOG_SAVE, type), JsonConvert.SerializeObject(sm), 30000, string.Empty
                    //    , Encoding.GetEncoding("UTF-8"), null);

                    return;
                }
                catch (WebException ex)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 保存api请求错误日志
        /// </summary>
        /// <param name="responseError">api返回信息</param>
        /// <param name="message">附加消息</param>
        /// <returns>操作状态</returns>
        public void System_SaveResponseErrorLog(ErrorInfo responseError, string message)
        {
            if (responseError != null)
            {
                message = string.Format("{0}{1}{2}{3}", string.Format("操作：{0}{1}", message, Environment.NewLine),
                    string.Format("错误代码：{0}{1}", responseError.Code, Environment.NewLine),
                    string.Format("错误信息：{0}{1}", responseError.Message, Environment.NewLine),
                    string.Format("详细信息：{0}", responseError.Details));

                LogHelper.WriteErrorLog(message);
                System_SaveLogToServer(message, "1");

                return;
            }

            System_SaveLogToServer(string.Format("操作：{0}", message), "2");
        }

        public void System_SaveErrorLog(Exception ex, string message)
        {
            if (ex != null)
            {
                message = string.Format("{0}{1}{2}", string.Format("操作：{0}{1}", message, Environment.NewLine),
                    string.Format("错误信息：{0}{1}", ex.Message, Environment.NewLine),
                    string.Format("详细信息：{0}", ex.ToString()));

                LogHelper.WriteErrorLog(message);
                System_SaveLogToServer(message, "1");

                return;
            }

            System_SaveLogToServer(string.Format("操作：{0}", message), "2");
        }

        /// <summary>
        /// 保存调试日志信息
        /// </summary>
        /// <param name="message">信息主体</param>
        /// <returns>操作状态</returns>
        public void System_SaveDebugLog(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                LogHelper.WriteInfoLog(message);
                System_SaveLogToServer(message, "2");

                return;
            }
        }

        public bool _IsSaveDebugLog { get; set; }
    }
}
