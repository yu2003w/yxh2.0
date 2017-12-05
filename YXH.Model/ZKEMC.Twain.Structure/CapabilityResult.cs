namespace YXH.Twain.Structure
{
    /// <summary>
    /// 容量结果信息
    /// </summary>
    public class CapabilityResult
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string ReturnCode { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 捕获信息
        /// </summary>
        public string Cap { get; set; }
        /// <summary>
        /// 内容类型
        /// </summary>
        public string ConType { get; set; }
        /// <summary>
        /// 容器信息
        /// </summary>
        public hcontainer hContainer { get; set; }
    }
}
