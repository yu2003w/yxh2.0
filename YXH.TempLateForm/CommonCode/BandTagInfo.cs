namespace YXH.TemplateForm
{
    /// <summary>
    /// 带标签的信息
    /// </summary>
    public class BandTagInfo
    {
        /// <summary>
        /// 前景工具条
        /// </summary>
        public OutlookBar outlookBar;

        /// <summary>
        /// 索引
        /// </summary>
        public int index;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ob">前景工具条</param>
        /// <param name="index">索引</param>
        public BandTagInfo(OutlookBar ob, int index)
        {
            this.outlookBar = ob;
            this.index = index;
        }
    }
}
