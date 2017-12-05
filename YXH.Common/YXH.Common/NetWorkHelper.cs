using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using YXH.Common.Enum;

namespace YXH.Common
{
    /// <summary>
    /// 网络状况处理中心
    /// </summary>
    public class NetWorkHelper
    {
        private const int INTERNET_CONNECTION_MODEM = 1;    //联网状态为调制解调器
        private const int INTERNET_CONNECTION_LAN = 2;  //联网状态为网卡

        /// <summary>
        /// 检测网络连接状态
        /// </summary>
        /// <param name="urls">用来进行Ping检测的url地址集</param>
        public static NetWorkStatusEnum CheckServeStatus()
        {
            int errCount = 0;//ping时连接失败个数

            if (!LocalConnectionStatus())
            {
                return NetWorkStatusEnum.NotConn;
            }
            else
            {
                string urlStr = ConfigurationHelper.GetSetting("NetWorkBaseSites");

                if (string.IsNullOrEmpty(urlStr))
                {
                    return NetWorkStatusEnum.NotSettingSecondLevelTest;
                }

                string[] urls = urlStr.Split(';');

                if (!PingNetWork(urls, out errCount))
                {
                    if (errCount == urls.Length)
                    {
                        return NetWorkStatusEnum.ConnException;
                    }
                    if (errCount < urls.Length && errCount > 0)
                    {
                        return NetWorkStatusEnum.ConnInstability;
                    }

                    return NetWorkStatusEnum.ConnNormal;
                }
                else
                {
                    return NetWorkStatusEnum.ConnNormal;
                }
            }
        }

        #region 网络检测

        /// <summary>
        /// 获取系统的网络连接状态
        /// </summary>
        /// <param name="dwFlag">连接状态码</param>
        /// <param name="dwReserved">保留状态</param>
        /// <returns>联网状态</returns>
        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);

        /// <summary>
        /// 判断本地的连接状态
        /// </summary>
        /// <returns>网络连接状态,可附带类型</returns>
        private static bool LocalConnectionStatus()
        {
            Int32 dwFlag = new Int32();

            if (!InternetGetConnectedState(ref dwFlag, 0))  //未联网
            {
                return false;
            }
            else
            {
                if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)  //是否调制解调器上网
                {
                    return true;
                }
                else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)   //是否网卡上网
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Ping命令检测网络是否畅通
        /// </summary>
        /// <param name="urls">URL数据</param>
        /// <param name="errorCount">ping时连接失败个数</param>
        /// <returns>网络连接状态</returns>
        public static bool PingNetWork(string[] urls, out int errorCount)
        {
            bool isconn = true;
            Ping ping = new Ping();

            errorCount = 0;

            try
            {
                PingReply pr;

                for (int i = 0; i < urls.Length; i++)
                {
                    pr = ping.Send(urls[i]);

                    if (pr.Status != IPStatus.Success)
                    {
                        isconn = false;

                        errorCount++;
                    }
                }
            }
            catch
            {
                isconn = false;
                errorCount = urls.Length;
            }

            return isconn;
        }

        #endregion
    }
}
