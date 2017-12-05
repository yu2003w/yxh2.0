using System.Windows.Forms;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 内容面板
    /// </summary>
    public abstract class ContentPanel : Panel
    {
        /// <summary>
        /// 前景工具条
        /// </summary>
        public OutlookBar outlookBar;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ContentPanel()
        {
            base.Visible = true;
        }

        /// <summary>
        /// 高亮插件
        /// </summary>
        /// <param name="index">索引</param>
        public virtual void HighlightSelection(int index) { }

        /// <summary>
        /// 重置插件
        /// </summary>
        public virtual void ResetSelection() { }
    }
}
