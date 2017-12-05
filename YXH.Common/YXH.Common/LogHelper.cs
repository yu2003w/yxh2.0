using log4net;
using System;

namespace YXH.Common
{

    public class ClientLogHelper
    {

    }
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {

        private static LogHelper _instance;
        private static string defaultLogName = "log";
        /// <summary>
        /// 日志前缀
        /// </summary>
        private static string LogPrefix = string.Concat("登录机器名：", GlobalInfo.ComputerName, Environment.NewLine.ToString(), "登录ip：", GlobalInfo.ComputerIp, Environment.NewLine.ToString(), "机器用户名：", GlobalInfo.ComputerLoginUserName, Environment.NewLine.ToString(), "机器mac：", GlobalInfo.ComputerMac, Environment.NewLine.ToString(), "机器操作系统：", GlobalInfo.OsVersion, Environment.NewLine.ToString());

        /// <summary>
        /// 定义静态实例
        /// </summary>
        public static LogHelper Instance
        {
            get
            {
                if (LogHelper._instance == null)
                {
                    LogHelper._instance = new LogHelper();

                    log4net.Config.XmlConfigurator.Configure();
                }

                return LogHelper._instance;
            }
        }

        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="Message">消息主体</param>
        public static void WriteInfoLog(string Message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(defaultLogName);

            if (log.IsInfoEnabled)
            {
                log.Info(LogPrefix + Message);
            }

            log = null;
        }

        /// <summary>
        /// 记录异常信息
        /// </summary>
        /// <param name="Message">消息主体</param>
        /// <param name="ex">异常主体</param>
        public static void WriteInfoLog(string Message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(defaultLogName);

            if (log.IsInfoEnabled)
            {
                log.Info(LogPrefix + Message, ex);
            }

            log = null;
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="Message">消息主体</param>
        public static void WriteErrorLog(string Message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(defaultLogName);

            if (log.IsErrorEnabled)
            {
                log.Error(LogPrefix + Message);
            }

            log = null;
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="Message">消息主体</param>
        /// <param name="ex">异常主体</param>
        public static void WriteErrorLog(string Message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(defaultLogName);

            if (log.IsErrorEnabled)
            {
                log.Error(LogPrefix + Message, ex);
            }

            log = null;
        }

        /// <summary>
        /// 记录致命错误日志
        /// </summary>
        /// <param name="Message">消息主体</param>
        public static void WriteFatalLog(string Message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(defaultLogName);

            if (log.IsInfoEnabled)
            {
                log.Fatal(LogPrefix + Message);
            }

            log = null;
        }

        /// <summary>
        /// 记录致命错误日志
        /// </summary>
        /// <param name="Message">消息主体</param>
        /// <param name="ex">异常主体</param>
        public static void WriteFatalLog(string Message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(defaultLogName);

            if (log.IsInfoEnabled)
            {
                log.Fatal(LogPrefix + Message, ex);
            }

            log = null;
        }
    }
}
