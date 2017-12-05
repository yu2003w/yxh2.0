using openCV;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.OuterInterop;

namespace YXH.ScanForm
{
    /// <summary>
    /// 旋转图片窗体
    /// </summary>
    public partial class FormRote : Form
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string filename;
        /// <summary>
        /// 转换句柄
        /// </summary>
        public IntPtr convertImg = IntPtr.Zero;

        /// <summary>
        /// 构造方法
        /// </summary>
        public FormRote()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            ScanlibInterop.SaveImage(this.convertImg, this.filename);
            ScanlibInterop.ReleaseImage(this.convertImg);

            base.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 旋转方法
        /// </summary>
        /// <param name="angle">角度</param>
        /// <returns>旋转后句柄</returns>
        public IntPtr Rotate(int angle)
        {
            return ScanlibInterop.RotateImage(this.convertImg, (double)angle);
        }

        /// <summary>
        /// 转变格式
        /// </summary>
        /// <param name="img">句柄图像</param>
        /// <returns>位图</returns>
        private Bitmap TranferImage(IntPtr img)
        {
            IplImage img2 = (IplImage)Marshal.PtrToStructure(img, typeof(IplImage));

            img2.ptr = img;

            return (Bitmap)img2;
        }

        /// <summary>
        /// 倒转按钮点击事件
        /// </summary>
        private void btnRotateCCW180_Click(object sender, EventArgs e)
        {
            IntPtr intPtr = this.Rotate(180);
            ScanlibInterop.ReleaseImage(this.convertImg);

            this.convertImg = intPtr;

            this.picView.Image.Dispose();

            this.picView.Image = this.TranferImage(this.convertImg);
        }

        /// <summary>
        /// 顺时针旋转90°按钮点击事件
        /// </summary>
        private void btnCWRotate90_Click(object sender, EventArgs e)
        {
            IntPtr intPtr = this.Rotate(90);
            ScanlibInterop.ReleaseImage(this.convertImg);

            this.convertImg = intPtr;

            this.picView.Image.Dispose();

            this.picView.Image = this.TranferImage(this.convertImg);
        }

        /// <summary>
        /// 逆时针旋转90°按钮点击事件
        /// </summary>
        private void btnRotateCCW90_Click(object sender, EventArgs e)
        {
            IntPtr intPtr = this.Rotate(-90);
            ScanlibInterop.ReleaseImage(this.convertImg);

            this.convertImg = intPtr;

            this.picView.Image.Dispose();

            this.picView.Image = this.TranferImage(this.convertImg);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FormRote_Load(object sender, EventArgs e)
        {
            this.picView.Image = FileHelper.GetImage(this.filename);
            this.convertImg = ScanlibInterop.ReadImage(this.filename);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            IntPtr intPtr = ScanlibInterop.RotateImageArbitraryDegree(convertImg, 1d);

            ScanlibInterop.ReleaseImage(convertImg);

            convertImg = intPtr;

            picView.Image.Dispose();

            picView.Image = TranferImage(convertImg);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            IntPtr intPtr = ScanlibInterop.RotateImageArbitraryDegree(convertImg, -1d);

            ScanlibInterop.ReleaseImage(convertImg);

            convertImg = intPtr;

            picView.Image.Dispose();

            picView.Image = TranferImage(convertImg);
        }
    }
}
