using System;
using System.Drawing;
using System.Windows.Forms;
using YXH.Common;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 带状按钮
    /// </summary>
    internal class BandButton : Button
    {
        /// <summary>
        /// 声明当前实例
        /// </summary>
        public BandTagInfo bti;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="bti">条状按钮</param>
        public BandButton(string caption, BandTagInfo bti)
        {
            this.Text = caption;
            base.FlatStyle = FlatStyle.Flat;
            base.FlatAppearance.BorderSize = 0;
            this.TextAlign = ContentAlignment.MiddleLeft;
            base.Visible = true;
            this.bti = bti;

            base.Click += new EventHandler(this.SelectBand);

            this.BackColor = Scheme.CommonNormalColor;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="bti">条状按钮</param>
        /// <param name="image">按钮背景图</param>
        public BandButton(string caption, BandTagInfo bti, Image image)
            : this(caption, bti)
        {
            base.Image = image;
            base.ImageAlign = ContentAlignment.MiddleLeft;
            base.Padding = new Padding(20, 0, 0, 0);
        }

        /// <summary>
        /// 选择条事件
        /// </summary>
        private void SelectBand(object sender, EventArgs e)
        {
            this.bti.outlookBar.SetSelectedBand(this.bti.index);
        }
    }
}
