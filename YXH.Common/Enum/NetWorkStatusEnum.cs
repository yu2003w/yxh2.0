namespace YXH.Common.Enum
{
    public enum NetWorkStatusEnum
    {
        /// <summary>
        /// 没有连接
        /// </summary>
        NotConn,
        /// <summary>
        /// 连接异常或无响应
        /// </summary>
        ConnException,
        /// <summary>
        /// 网络不稳定
        /// </summary>
        ConnInstability,
        /// <summary>
        /// 连接正常
        /// </summary>
        ConnNormal,
        /// <summary>
        /// 未配置二级检测（Ping检测）
        /// </summary>
        NotSettingSecondLevelTest
    }
}
