namespace YXH.Twain.Structure
{
    /// <summary>
    /// 容器信息
    /// </summary>
    public class hcontainer
    {
        /// <summary>
        /// 项类型
        /// </summary>
        public string Itemtype { get; set; }
        /// <summary>
        /// 项
        /// </summary>
        public string Item { get; set; }
        /// <summary>
        /// 数字项
        /// </summary>
        public string NumItem { get; set; }
        /// <summary>
        /// 当前索引
        /// </summary>
        public string CurrentIndex { get; set; }
        /// <summary>
        /// 默认索引
        /// </summary>
        public string DefaultIndex { get; set; }
        /// <summary>
        /// 项列表
        /// </summary>
        public string ItemList { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public string MinValue { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public string MaxValue { get; set; }
        /// <summary>
        /// 步长
        /// </summary>
        public string StepSize { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// 当前值
        /// </summary>
        public string CurrentValue { get; set; }
    }
}
