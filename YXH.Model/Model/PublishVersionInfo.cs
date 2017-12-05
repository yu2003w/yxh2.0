namespace YXH.Model
{
    /// <summary>
    /// 程序发布的版本信息
    /// </summary>
    public class PublishVersionInfo
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version;
        /// <summary>
        /// 发布的下载路径
        /// </summary>
        public string PublishVersionPath;
        /// <summary>
        /// 是否强制更新
        /// </summary>
        public bool IsForceUpdate;
        /// <summary>
        /// 安装文件名称
        /// </summary>
        public string SetupFileName;
    }
}
