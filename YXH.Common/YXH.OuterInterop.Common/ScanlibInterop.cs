using System;
using System.Runtime.InteropServices;
using YXH.Model;

namespace YXH.Common.OuterInterop
{
    /// <summary>
    /// 外接程序互操作类
    /// </summary>
    public class ScanlibInterop
    {
        /// <summary>
        /// 设置选项宽度
        /// </summary>
        /// <param name="instanse">实例句柄</param>
        /// <param name="width">目标宽度</param>
        /// <returns>设置结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetOptionWidth(IntPtr instanse, int width);

        /// <summary>
        /// 设置选项高度
        /// </summary>
        /// <param name="instanse">实例句柄</param>
        /// <param name="height">目标高度</param>
        /// <returns>设置结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetOptionHeight(IntPtr instanse, int height);

        /// <summary>
        /// 设置区域斑点参数
        /// </summary>
        /// <param name="instanse">实例句柄</param>
        /// <param name="minArea">区域最小值</param>
        /// <param name="maxArea">区域最大值</param>
        /// <returns>设置结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetAreaParamOfBlob(IntPtr instanse, int minArea, int maxArea);

        /// <summary>
        /// 读取图像
        /// </summary>
        /// <param name="imagepath">图像路径</param>
        /// <returns>图像读取后的句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr ReadImage([MarshalAs(UnmanagedType.LPStr)] string imagepath);

        /// <summary>
        /// 释放图像
        /// </summary>
        /// <param name="imgptr">需要释放的图像句柄</param>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void ReleaseImage(IntPtr imgptr);

        /// <summary>
        /// 保存图像
        /// </summary>
        /// <param name="imgptr"图像句柄></param>
        /// <param name="imagepath">保存路径</param>
        /// <returns>操作结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SaveImage(IntPtr imgptr, [MarshalAs(UnmanagedType.LPStr)] string imagepath);

        /// <summary>
        /// 创建识别器
        /// </summary>
        /// <returns>识别器句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr CreateRecognizer();

        /// <summary>
        /// 倾斜校正
        /// </summary>
        /// <param name="pRecognizer">识别器句柄</param>
        /// <param name="src">目标图片句柄</param>
        /// <param name="areaContainOneLine">直线区域</param>
        /// <returns></returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool DeskewedImageByLine(IntPtr pRecognizer, IntPtr src, CvRect areaContainOneLine);

        /// <summary>
        /// 顺时针旋转图像
        /// </summary>
        /// <param name="pRecognizer">识别器句柄</param>
        /// <param name="src">目标图片句柄</param>
        /// <returns>操作后的图片句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr RotateImageClockwise(IntPtr pRecognizer, IntPtr src);

        /// <summary>
        /// 斑点检测
        /// </summary>
        /// <param name="pRecognizer">识别器句柄</param>
        /// <param name="sourceimage">图像句柄</param>
        /// <param name="selectRect">选中区域坐标信息</param>
        /// <param name="minArea">区域最小值</param>
        /// <param name="maxArea">区域最大值</param>
        /// <returns>识别结果句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr BlobDetect(IntPtr pRecognizer, IntPtr sourceimage, CvRect selectRect, int minArea = 200, int maxArea = 10000);

        /// <summary>
        /// 方括号检测
        /// </summary>
        /// <param name="pRecognizer">识别器句柄</param>
        /// <param name="sourceimage">图像句柄</param>
        /// <param name="selectRect">选中区域坐标</param>
        /// <param name="minArea">区域最小值</param>
        /// <param name="maxArea">区域最大值</param>
        /// <returns>处理结果句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr BracketsDetect(IntPtr pRecognizer, IntPtr sourceimage, CvRect selectRect, int minArea = 20, int maxArea = 5000);

        /// <summary>
        /// 识别图像
        /// </summary>
        /// <param name="pRecognizer">识别器句柄</param>
        /// <param name="image">需哟啊识别的图像</param>
        /// <param name="selectRect">识别区域坐标信息</param>
        /// <param name="type">识别类型</param>
        /// <returns>识别结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool RecognizeImage(IntPtr pRecognizer, IntPtr image, CvRect selectRect, int type);

        /// <summary>
        /// 获取OCR信息
        /// </summary>
        /// <param name="pRecognizer">识别器句柄</param>
        /// <returns>识别结果句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetOCRResult(IntPtr pRecognizer);

        /// <summary>
        /// 获得操作斑点
        /// </summary>
        /// <param name="pRecognizer">识别器句柄</param>
        /// <returns>结果句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetOptBlobs(IntPtr pRecognizer);

        /// <summary>
        /// 获得操作斑点
        /// </summary>
        /// <param name="pRecognizer">识别器句柄</param>
        /// <param name="image">图像句柄</param>
        /// <param name="selectarea">选中区域左边信息</param>
        /// <returns>结果句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetOptionBlobs(IntPtr pRecognizer, IntPtr image, CvRect selectarea);

        /// <summary>
        /// 根据设置值旋转图像
        /// </summary>
        /// <param name="image">图像句柄</param>
        /// <param name="degree">旋转角度</param>
        /// <returns>旋转后的图像句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern IntPtr RotateImageArbitraryDegree(IntPtr image, double degree);

        /// <summary>
        /// 创建扫描仪
        /// </summary>
        /// <returns>扫描仪句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr CreateScanner();

        /// <summary>
        /// 缩小矩形区域
        /// </summary>
        /// <param name="imagesoure">图像句柄</param>
        /// <param name="rect">源区域信息</param>
        /// <returns>目标区域信息</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CvRect ReduceRectArea(IntPtr imagesoure, CvRect rect);

        /// <summary>
        /// 匹配模板数组
        /// </summary>
        /// <param name="instance">实例句柄</param>
        /// <param name="imagesoure">图像句柄</param>
        /// <param name="selectArea">选中区域</param>
        /// <param name="templateArea">模板区域</param>
        /// <param name="threshold">匹配极限值</param>
        /// <returns>匹配结果句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr MatchTemplateArray(IntPtr instance, IntPtr imagesoure, CvRect selectArea, CvRect templateArea, double threshold);

        /// <summary>
        /// 设置页码
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="pageNum">页码</param>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetPageNum(IntPtr pScanner, int pageNum);

        /// <summary>
        /// 设置双面试卷
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="pagePairs">双面试卷字符</param>
        /// <returns>设置结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetPagePair(IntPtr pScanner, [MarshalAs(UnmanagedType.LPStr)] string pagePairs);

        /// <summary>
        /// 加载模板图片
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="tmplImagePath">模板图片路径</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>加载结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool LoadTmplImage(IntPtr pScanner, [MarshalAs(UnmanagedType.LPStr)] string tmplImagePath, int pageIndex);

        /// <summary>
        /// 设置标题区域
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="area">区域信息</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>设置结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetTitleArea(IntPtr pScanner, CvRect area, int pageIndex);

        /// <summary>
        /// 加载源图像
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="srcImagePath">图像路径</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>加载结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool LoadSourceImageByPath(IntPtr pScanner, [MarshalAs(UnmanagedType.LPStr)] string srcImagePath, int pageIndex);

        /// <summary>
        /// 加载源图像
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="srcImage">图像句柄</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>加载结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool LoadSourceImage(IntPtr pScanner, IntPtr srcImage, int pageIndex);

        /// <summary>
        /// 准备扫描
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <returns>准备状态</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ReadyToScan(IntPtr pScanner);

        /// <summary>
        /// 标题匹配
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <returns>匹配状态</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool MatchTitle(IntPtr pScanner);

        /// <summary>
        /// 获取调整后图像
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>目标图像句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetAdjustedImage(IntPtr pScanner, int pageIndex);

        /// <summary>
        /// 旋转图像
        /// </summary>
        /// <param name="src">图像句柄</param>
        /// <param name="degree">旋转角度</param>
        /// <returns>目标图像句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr RotateImage(IntPtr src, double degree);

        /// <summary>
        /// 预备下一图像
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void PrepareToLoadNext(IntPtr pScanner);

        /// <summary>
        /// 识别图像
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="optRects">操作区域</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>结果句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr Recognize(IntPtr pScanner, [MarshalAs(UnmanagedType.LPStr)] string optRects, int pageIndex);

        /// <summary>
        /// 识别考号
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="optRects">操作区域</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>结果句柄</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr RecognizeStudentID(IntPtr pScanner, [MarshalAs(UnmanagedType.LPStr)] string optRects, int pageIndex);

        /// <summary>
        /// 设置确定阈值
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="t">阈值</param>
        /// <returns>设置结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetConvincedThreshold(IntPtr pScanner, double t);

        /// <summary>
        /// 设置疑问（异常）识别阈值
        /// </summary>
        /// <param name="pScanner">扫描仪句柄</param>
        /// <param name="t">阈值</param>
        /// <returns>设置结果</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetDoubtfulThreshold(IntPtr pScanner, double t);

        /// <summary>
        /// 获取图像大小
        /// </summary>
        /// <param name="srcImg">图像句柄</param>
        /// <param name="imgW">图像宽度</param>
        /// <param name="imgH">图像高度</param>
        /// <returns>操作状态</returns>
        [DllImport("scanlib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GetImageSize(IntPtr srcImg, ref int imgW, ref int imgH);
    }
}
