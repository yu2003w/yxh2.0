using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace YXH.Common
{
    public class ConfigurationHelper
    {
        /// <summary>
        /// 获取应用程序可执行文件的目录，包含可执行文件名称
        /// </summary>
        public static string fileName = Path.GetFileName(Application.ExecutablePath);

        /// <summary>
        /// 检查AppSetting中是否存在指定key
        /// </summary>
        /// <param name="key">需要检查的key</param>
        /// <returns>存在状态</returns>
        public static bool ExistsAppSettingKey(string key)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationHelper.fileName);

            foreach (string item in configuration.AppSettings.Settings.AllKeys)
            {
                if (item.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 在config文件中添加AppSettings设置项
        /// </summary>
        /// <param name="key">设置项的Key</param>
        /// <param name="value">设置项的Value</param>
        /// <returns>返回操作状态</returns>
        public static bool AddSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationHelper.fileName);

            configuration.AppSettings.Settings.Add(key, value);
            configuration.Save();

            return true;
        }

        /// <summary>
        /// 从Config中获取AppSettings的配置项
        /// </summary>
        /// <param name="key">需要获取的配置项Key</param>
        /// <returns>返回获取到的Value</returns>
        public static string GetSetting(string key)
        {
            if (ExistsAppSettingKey(key))
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationHelper.fileName);

                return configuration.AppSettings.Settings[key].Value;
            }

            return string.Empty;
        }

        /// <summary>
        /// 更新config文件中AppSettings设置项
        /// </summary>
        /// <param name="key">设置项的Key</param>
        /// <param name="value">设置项的Value</param>
        /// <returns>返回操作状态</returns>
        public static bool UpdateSetting(string key, string newValue)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationHelper.fileName);

            configuration.AppSettings.Settings[key].Value = newValue;
            configuration.Save();

            return true;
        }

        /// <summary>
        /// 刷新应用程序设置
        /// </summary>
        public static void RefreshAppSetting()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
