using System;
using YXH.ScanBLL;
using YXH.Scanner.DALFactory;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 业务处理基础类
    /// </summary>
    public partial class BaseDisposeBLL
    {
        internal BaseFactory _dalFactory = null;

        public BaseDisposeBLL()
        {
            if (!string.IsNullOrEmpty(ScanGlobalInfo.loginUser.data.uname))
            {
                _dalFactory = new BaseFactory(ScanGlobalInfo.loginUser.data.uname);
            }
            else
            {
                _dalFactory = new BaseFactory(string.Empty);
            }
        }

        public void System_SaveErrorLog(Exception ex, string message)
        {
            _dalFactory.System_SaveErrorLog(ex, message);
        }

        /// <summary>
        /// 保存调试日志信息
        /// </summary>
        /// <param name="message">信息主体</param>
        /// <returns>操作状态</returns>
        public void System_SaveDebugLog(string message)
        {
            _dalFactory.System_SaveDebugLog(message);
        }
    }
}
