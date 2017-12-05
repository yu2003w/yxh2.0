using System;
using System.Management;
using System.Net;
using System.Reflection;

namespace YXH.Common
{
    /// <summary>
    /// 系统信息帮助类
    /// </summary>
    public static class SystemInfoHelper
    {
        /// <summary>
        /// 初始化应用程序当前运行环境相关信息信息
        /// </summary>
        public static void InitApplicationInfo()
        {
            IPHostEntry currentEntry = Dns.GetHostEntry(Dns.GetHostName());

            if (currentEntry.AddressList.Length > 0)
            {
                GlobalInfo.ComputerIp = currentEntry.AddressList[0].ToString();
            }
            else
            {
                GlobalInfo.ComputerIp = "未联网";
            }

            GlobalInfo.ComputerLoginUserName = Environment.UserName;
            GlobalInfo.ComputerMac = GetMacAddres();
            GlobalInfo.ComputerName = Dns.GetHostName();
            GlobalInfo.OsVersion = Environment.OSVersion.ToString();
        }

        /// <summary>
        /// 获取当前网卡的Mac地址
        /// </summary>
        /// <returns>获取到的网卡地址</returns>
        private static string GetMacAddres()
        {
            try
            {
                string stringMAC = "";
                ManagementClass MC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection MOC = MC.GetInstances();

                foreach (ManagementObject MO in MOC)
                {
                    if ((bool)MO["IPEnabled"] == true)
                    {
                        stringMAC += MO["MACAddress"].ToString();
                    }
                }
                return stringMAC;
            }
            catch
            {
                return "";
            }
        }
    }
}
