using System;
using System.Collections.Generic;
using System.Drawing;

namespace YXH.Common.Form
{
    /// <summary>
    /// 图片框显示窗体
    /// </summary>
    public partial class PicBoxViewerForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// 图片文件列表
        /// </summary>
        private List<string> imageFiles;
        /// <summary>
        /// 当前页索引
        /// </summary>
        private int _CurrentPageIndex;
        /// <summary>
        /// 图片显示比例
        /// </summary>
        private float picRatio = 0.15f;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="imgList">图片列表</param>
        /// <param name="beginIndex">开始索引</param>
        public PicBoxViewerForm(List<string> imgList, int beginIndex)
        {
            InitializeComponent();

            this.imageFiles = imgList;
            this._CurrentPageIndex = beginIndex;
        }

        /// <summary>
        /// 缩小按钮点击事件
        /// </summary>
        private void btn_ZoomOut_Click(object sender, EventArgs e)
        {
            if (this.picFront.Image != null && this.picRatio < 1.2f)
            {
                this.picRatio *= 1.13345f;
                this.picFront.Size = new Size((int)((float)this.picFront.Image.Size.Width * this.picRatio), (int)((float)this.picFront.Image.Size.Height * this.picRatio));
            }
        }

        /// <summary>
        /// 放大按钮点击事件
        /// </summary>
        private void btn_ZoomIn_Click(object sender, EventArgs e)
        {
            if (this.picFront.Image != null && this.picRatio > 0.05f)
            {
                this.picRatio *= 0.90234f;
                this.picFront.Size = new Size((int)((float)this.picFront.Image.Size.Width * this.picRatio), (int)((float)this.picFront.Image.Size.Height * this.picRatio));
            }
        }

        /// <summary>
        /// 更新页索引显示
        /// </summary>
        private void UpdatePageIndexShown()
        {
            this.lbl_pageIndex.Text = string.Format("{0}/{1}", this._CurrentPageIndex + 1, this.imageFiles.Count);
        }

        /// <summary>
        /// 更新图片框
        /// </summary>
        /// <param name="img">目标图片</param>
        public void UpdatePicBox(Bitmap img)
        {
            if (img == null && this.picFront.Image != null)
            {
                this.picFront.Image.Dispose();

                this.picFront.Image = null;

                return;
            }
            if (this.picFront.Image != null && img != null)
            {
                this.picFront.Image.Dispose();

                this.picFront.Image = null;
            }

            this.picFront.Image = img;

            if (this.picRatio < 1.2f && this.picFront.Image != null)
            {
                this.picRatio *= 1f;
                this.picFront.Size = new Size((int)((float)this.picFront.Image.Size.Width * this.picRatio), (int)((float)this.picFront.Image.Size.Height * this.picRatio));
            }

            this.UpdatePageIndexShown();
        }

        /// <summary>
        /// 上一页按钮点击事件
        /// </summary>
        private void btn_LastPage_Click(object sender, EventArgs e)
        {
            if (this.imageFiles != null && this._CurrentPageIndex - 1 >= 0)
            {
                this._CurrentPageIndex--;

                Bitmap image = FileHelper.GetImage(this.imageFiles[this._CurrentPageIndex]);

                this.UpdatePicBox(image);
            }
        }

        /// <summary>
        /// 下一页按钮点击事件
        /// </summary>
        private void btn_NextPage_Click(object sender, EventArgs e)
        {
            if (this.imageFiles != null && this._CurrentPageIndex + 1 < this.imageFiles.Count)
            {
                this._CurrentPageIndex++;

                Bitmap image = FileHelper.GetImage(this.imageFiles[this._CurrentPageIndex]);

                this.UpdatePicBox(image);
            }
        }
    }
}
