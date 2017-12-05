using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YXH.Common;
using YXH.ScanBLL;

namespace YXH.ScanForm
{
    /// <summary>
    /// 调整扫描窗体
    /// </summary>
    public partial class FormAdjustScanImg : Form
    {
        /// <summary>
        /// 图片源类
        /// </summary>
        private class ImageSource
        {
            /// <summary>
            /// ID 
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// 图片路径
            /// </summary>
            public string ImagePath { get; set; }
            /// <summary>
            /// 图片内存值
            /// </summary>
            public Image ImageByte { get; set; }
        }
        /// <summary>
        /// 卷数据
        /// </summary>
        public VolumnDataRow VolData { get; set; }
        /// <summary>
        /// 源图片信息列表
        /// </summary>
        private List<FormAdjustScanImg.ImageSource> source = new List<FormAdjustScanImg.ImageSource>();

        /// <summary>
        /// 构造方法
        /// </summary>
        public FormAdjustScanImg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 调换链接按钮点击事件
        /// </summary>
        private void rLinkSwap_Click(object sender, EventArgs e)
        {
            FormAdjustScanImg.ImageSource imageSource = this.grvShow.GetFocusedRow() as FormAdjustScanImg.ImageSource;
            FormSwapVolumn formSwapVolumn = new FormSwapVolumn();

            formSwapVolumn.PageCount = this.source.Count;
            formSwapVolumn.FirstPage = imageSource.ID;

            if (formSwapVolumn.ShowDialog() == DialogResult.OK)
            {
                FormAdjustScanImg.ImageSource imageSource2 = this.grvShow.GetRow(formSwapVolumn.SecondPage - 1) as FormAdjustScanImg.ImageSource;
                Image imageByte = imageSource.ImageByte;

                imageSource.ImageByte = imageSource2.ImageByte;
                imageSource2.ImageByte = imageByte;

                imageSource.ImageByte.Save(PathHelper.LocalVolumneImgDir + imageSource.ImagePath);
                imageSource2.ImageByte.Save(PathHelper.LocalVolumneImgDir + imageSource2.ImagePath);

                this.grvShow.RefreshData();
            }
        }

        /// <summary>
        /// 旋转按钮点击事件
        /// </summary>
        private void rLinkRotate_Click(object sender, EventArgs e)
        {
            FormAdjustScanImg.ImageSource imageSource = this.grvShow.GetFocusedRow() as FormAdjustScanImg.ImageSource;
            FormRote formRote = new FormRote();

            formRote.filename = PathHelper.LocalVolumneImgDir + imageSource.ImagePath;

            if (formRote.ShowDialog() == DialogResult.OK)
            {
                imageSource.ImageByte = FileHelper.GetImage(formRote.filename);

                this.grvShow.RefreshData();
            }

            formRote.Dispose();
        }

        /// <summary>
        /// 关闭按钮点击事件
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void FormAdjustScanImg_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < this.source.Count; i++)
            {
                if (this.source[i] != null)
                {
                    this.source[i] = null;
                }
            }

            this.source.Clear();

            this.grdShow.DataSource = null;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FormAdjustScanImg_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= this.VolData.Data.ImagePath.Length; i++)
            {
                this.source.Add(new FormAdjustScanImg.ImageSource
                {
                    ID = i,
                    ImagePath = this.VolData.Data.ImagePath[i - 1],
                    ImageByte = FileHelper.GetImage(PathHelper.LocalVolumneImgDir + this.VolData.Data.ImagePath[i - 1])
                });
            }

            this.grdShow.DataSource = this.source;
        }
    }
}
