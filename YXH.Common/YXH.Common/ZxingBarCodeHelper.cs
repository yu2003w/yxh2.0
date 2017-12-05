using System.Drawing;
using System.Drawing.Imaging;
using ZXing;

namespace YXH.Common
{
    /// <summary>
    /// 条形码(二维码)处理类
    /// </summary>
    public class ZxingBarCodeHelper
    {
        /// <summary>
        /// 声明当前实例
        /// </summary>
        private static ZxingBarCodeHelper _instance;

        /// <summary>
        /// 定义条形码处理类
        /// </summary>
        public static ZxingBarCodeHelper Instance
        {
            get
            {
                if (ZxingBarCodeHelper._instance == null)
                {
                    ZxingBarCodeHelper._instance = new ZxingBarCodeHelper();
                }

                return ZxingBarCodeHelper._instance;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        private ZxingBarCodeHelper()        {        }

        /// <summary>
        /// 读取条形码
        /// </summary>
        /// <param name="bmg">条形码位图</param>
        /// <param name="isdispose">是否为规范条形码</param>
        /// <returns>条形码信息</returns>
        public string ReadBarCode(Bitmap bmg, bool isdispose)
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(bmg);

            if (isdispose)
            {
                bmg.Dispose();
            }
            if (result != null)
            {
                return result.Text;
            }

            return string.Empty;
        }

        /// <summary>
        /// 读取条形码
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <param name="region">所在矩形区域</param>
        /// <param name="isHorizontal">是否水平粘贴</param>
        /// <returns>条形码信息</returns>
        public string ReadBarCode(string filename, Rectangle region, bool isHorizontal)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(filename);

            region = this.CheckRect(bitmap, region);

            Bitmap bitmap2 = bitmap.Clone(region, PixelFormat.Format24bppRgb);

            if (!isHorizontal)
            {
                bitmap2.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            string result = this.ReadBarCode(bitmap2, true);

            bitmap.Dispose();

            return result;
        }

        /// <summary>
        /// 读取二维码
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="region">二维码所在矩形区域</param>
        /// <returns>二维码信息</returns>
        public string ReadQRCode(string filename, Rectangle region)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(filename);

            region = this.CheckRect(bitmap, region);

            Bitmap bmg = bitmap.Clone(region, PixelFormat.Format24bppRgb);
            string result = this.ReadBarCode(bmg, true);
            
            bitmap.Dispose();
            
            return result;
        }

        /// <summary>
        /// 读取二维码信息
        /// </summary>
        /// <param name="img">位图</param>
        /// <param name="region">二维码所在矩形区域</param>
        /// <returns>二维码信息</returns>
        public string ReadQRCode(Bitmap img, Rectangle region)
        {
            region = this.CheckRect(img, region);

            Bitmap bmg = img.Clone(region, PixelFormat.Format24bppRgb);
            string result = this.ReadBarCode(bmg, true);

            img.Dispose();

            return result;
        }

        /// <summary>
        /// 检查矩形区域
        /// </summary>
        /// <param name="curImageBi">位图</param>
        /// <param name="curRect">矩形区域</param>
        /// <returns>处理后的矩形区域</returns>
        private Rectangle CheckRect(Bitmap curImageBi, Rectangle curRect)
        {
            int num = curRect.Top,
                num2 = curRect.Left,
                num3 = curRect.Width,
                num4 = curRect.Height;

            if (num + num4 > curImageBi.Height)
            {
                num4 = curImageBi.Height - num - 2;
            }
            if (num2 + num3 > curImageBi.Width)
            {
                num3 = curImageBi.Width - num2 - 2;
            }
            if (num < 0)
            {
                num = 1;
            }
            if (num2 < 0)
            {
                num2 = 1;
            }

            return new Rectangle(num2, num, num3, num4);
        }
    }
}
