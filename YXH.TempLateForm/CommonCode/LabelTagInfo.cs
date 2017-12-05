namespace YXH.TemplateForm
{
    /// <summary>
    /// 标注标签信息
    /// </summary>
    public class LabelTagInfo
    {
        /// <summary>
        /// 前置工具条
        /// </summary>
        public OutlookBar outlookBar;
        /// <summary>
        /// 条索引
        /// </summary>
        public int bandIndex;
        /// <summary>
        /// 内容索引
        /// </summary>
        public int contentIndex;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="bar">前置工具条</param>
        /// <param name="bandIndex">条索引</param>
        /// <param name="contentIndex">内容索引</param>
        public LabelTagInfo(OutlookBar bar, int bandIndex, int contentIndex)
        {
            this.outlookBar = bar;
            this.bandIndex = bandIndex;
            this.contentIndex = contentIndex;
        }
    }
}
