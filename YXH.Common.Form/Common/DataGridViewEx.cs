using System.Drawing;
using System.Windows.Forms;

namespace YXH.Common.Form
{
    /// <summary>
    /// DataGridView扩展类
    /// </summary>
    internal class DataGridViewEx : DataGridView
    {
        /// <summary>
        /// 单色画刷
        /// </summary>
        private SolidBrush solidBrush;

        /// <summary>
        /// 构造方法
        /// </summary>
        public DataGridViewEx()
        {
            this.solidBrush = new SolidBrush(base.RowHeadersDefaultCellStyle.ForeColor);
        }

        /// <summary>
        /// 行改变绘制
        /// </summary>
        /// <param name="e">绘制事件头</param>
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, this.solidBrush, (float)(e.RowBounds.Location.X + 15), (float)(e.RowBounds.Location.Y + 5));

            base.OnRowPostPaint(e);
        }
    }
}
