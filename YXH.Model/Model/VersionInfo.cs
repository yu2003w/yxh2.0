using System.Collections.Generic;

namespace YXH.Model
{
    /// <summary>
    /// 程序版本信息
    /// </summary>
    public class VersionInfo
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version;
        /// <summary>
        /// 开始主程序
        /// </summary>
        public string StartEXE;
        /// <summary>
        /// 文件的版本信息
        /// </summary>
        public List<FileVersionInfo> Files = new List<FileVersionInfo>();
        /// <summary>
        /// 忽略版本列表
        /// </summary>
        public List<string> IgnoreVersion = new List<string>();
    }
}
