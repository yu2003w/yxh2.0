namespace YXH.Common.Messages
{
    public class NetWorkStatusMessage
    {
        /// <summary>
        /// 没有网络连接时的提示
        /// </summary>
        public const string NOT_CONN_MESSAGE = "没有网络连接，请检查您的网络";
        /// <summary>
        /// 网络连接异常时的提示
        /// </summary>
        public const string CONN_EXCEPTION_MESSAGE = "网络连接异常，请检查您的网络";
        /// <summary>
        /// 网络连接不稳定时的提示
        /// </summary>
        public const string CONN_INSTABILITY_MESSAGE = "网络连接不稳定";
        /// <summary>
        /// 网络连接正常时的提示
        /// </summary>
        public const string CONN_NORMAL_MESSAGE = "网络已成功连接";
        /// <summary>
        /// 检测网卡未通过，Ping检测未配置地址
        /// </summary>
        public const string NOT_SETTING_SECOND_LEVEL_TEST = "网卡检测未连接，未配置二级检测";
    }
}
