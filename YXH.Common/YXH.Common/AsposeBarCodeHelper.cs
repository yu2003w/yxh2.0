using Aspose.BarCodeRecognition;
using System.Drawing;
using System.Drawing.Imaging;

namespace YXH.Common
{
    /// <summary>
    /// 关于条形码(二维码)处理类
    /// </summary>
    public class AsposeBarCodeHelper
    {
        /// <summary>
        /// 声明当前实例
        /// </summary>
        private static AsposeBarCodeHelper _instance;
        /// <summary>
        /// 条形码读取类型
        /// </summary>
        public BarCodeReadType curType = BarCodeReadType.AllSupportedTypes;
        /// <summary>
        /// 定义当前实例
        /// </summary>
        public static AsposeBarCodeHelper Instance
        {
            get
            {
                if (AsposeBarCodeHelper._instance == null)
                {
                    AsposeBarCodeHelper._instance = new AsposeBarCodeHelper();
                }

                return AsposeBarCodeHelper._instance;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        private AsposeBarCodeHelper()        {        }

        /// <summary>
        /// 读取条形码，适配所有类型
        /// </summary>
        /// <param name="bmg">条形码位图</param>
        /// <returns>条形码信息</returns>
        public string ReadBarcodeByAllType(Bitmap bmg)
        {
            string result = "";
            BarCodeReader barCodeReader = new BarCodeReader(bmg, BarCodeReadType.AllSupportedTypes);

            while (barCodeReader.Read())
            {
                result = barCodeReader.GetCodeText();
                this.curType = barCodeReader.GetReadType();
            }

            barCodeReader.Close();

            return result;
        }

        /// <summary>
        /// 读取条形码
        /// </summary>
        /// <param name="bmg">位图</param>
        /// <param name="isdispose">是否为标准的条形码</param>
        /// <returns>条形码信息</returns>
        public string ReadBarcode(Bitmap bmg, bool isdispose)
        {
            string result = "";
            bool flag = false;
            BarCodeReader barCodeReader = new BarCodeReader(bmg, this.curType);

            while (barCodeReader.Read())
            {
                result = barCodeReader.GetCodeText();
                this.curType = barCodeReader.GetReadType();
                flag = true;
            }
            if (!flag && this.curType != BarCodeReadType.AllSupportedTypes)
            {
                result = this.ReadBarcodeByAllType(bmg);
            }
            if (isdispose)
            {
                bmg.Dispose();
            }

            barCodeReader.Close();

            return result;
        }

        /// <summary>
        /// 读取条形码
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <param name="region">所在矩形区域</param>
        /// <param name="isHorizontal">是否为水平状态</param>
        /// <returns>识别结果</returns>
        public string ReadBarCode(string filename, Rectangle region, bool isHorizontal)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(filename);

            region = this.CheckRect(bitmap, region);

            Bitmap bitmap2 = bitmap.Clone(region, PixelFormat.Format24bppRgb);

            if (!isHorizontal)
            {
                bitmap2.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            string result = this.ReadBarcode(bitmap2, true);

            bitmap.Dispose();

            return result;
        }

        /// <summary>
        /// 检查矩形区域
        /// </summary>
        /// <param name="curImageBi">位图</param>
        /// <param name="curRect">矩形区域信息</param>
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
