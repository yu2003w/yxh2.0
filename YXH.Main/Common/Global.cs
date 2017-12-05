using System;
using System.Collections.Generic;
using System.Configuration;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YXH.Main.Common
{
    /// <summary>
    /// 全局设置
    /// </summary>
    public class Global
    {
        /// <summary>
        /// 实例
        /// </summary>
        private static Global _instance;

        /// <summary>
        /// 实例
        /// </summary>
        public static Global Instance
        {
            get
            {
                if (Global._instance == null)
                {
                    Global._instance = new Global();
                }

                return Global._instance;
            }
        }

        /// <summary>
        /// 得到当前版本号
        /// </summary>
        /// <returns>返回当前程序版本号</returns>
        public string GetCurrentProVersion()
        {
            string result;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                result = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                result = Application.ProductVersion;
            }

            return result;
        }

        /// <summary>
        /// 获取当前程序版本类型
        /// </summary>
        /// <returns>返回当前程序版本类型</returns>
        public string GetCurrentEnv()
        {
            string text = "";

            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                text = "离线";
            }

            string text2 = ConfigurationManager.AppSettings["VersionEnv"];

            if (text2 != null)
            {
                if (text2 == "0")
                {
                    text += "测试版";

                    return text;
                }
                if (text2 == "1")
                {
                    text += "演示版";

                    return text;
                }
                if (text2 == "2")
                {
                    text += "正式版";

                    return text;
                }
            }

            text += "正式版";

            return text;
        }
    }
}
