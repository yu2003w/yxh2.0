using System.IO;
using YXH.Common;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 路径处理帮助类
    /// </summary>
    public class PathHelper
    {
        /// <summary>
        /// 本地数据目录
        /// </summary>
        public static string LocalDataDir
        {
            get
            {
                string text = Path.Combine(GlobalInfo.LocalFileLocation, "volumeImage");
                string text2 = string.Concat(new object[]
				{
					text,
					"\\",
					ScanGlobalInfo.ExamInfo.ID,
					"\\"
				});

                if (!Directory.Exists(text2))
                {
                    Directory.CreateDirectory(text2);
                }

                return text2;
            }
        }
        /// <summary>
        /// 本地批量图片目录
        /// </summary>
        public static string LocalVolumneImgDir
        {
            get
            {
                string text = PathHelper.LocalDataDir + "Image\\";

                PathHelper.CreateDirectory(text);

                return text;
            }
        }
        /// <summary>
        /// 本地考试信息目录
        /// </summary>
        public static string LocalExamDataDir
        {
            get
            {
                string text = PathHelper.LocalDataDir + "LocalExamData\\";

                PathHelper.CreateDirectory(text);

                return text;
            }
        }

        /// <summary>
        /// 模板文件目录
        /// </summary>
        public static string TpFileDir
        {
            get
            {
                string text = Path.Combine(GlobalInfo.LocalFileLocation, "tplfile");
                string text2 = string.Concat(new object[]
				{
					text,
					"\\",
					ScanGlobalInfo.ExamInfo.ID,
					"\\"
				});

                PathHelper.CreateDirectory(text2);

                return text2;
            }
        }
        /// <summary>
        /// 模板文件压缩路径
        /// </summary>
        public static string TpFileRarPath
        {
            get
            {
                string text = Path.Combine(GlobalInfo.LocalFileLocation, "tplfile\\");

                PathHelper.CreateDirectory(text);

                return text + ScanGlobalInfo.ExamInfo.ID + ".zip";
            }
        }
        /// <summary>
        /// 上传模板文件目录
        /// </summary>
        public static string UploadTpFileDirectory
        {
            get
            {
                return string.Concat(new object[]			
                {
                    "file/v/",						
                    ScanGlobalInfo.ExamInfo.ID,						
                    "/",
                    ScanGlobalInfo.ExamInfo.ID
                });
            }
        }

        /// <summary>
        /// 上传批量文件目录
        /// </summary>
        public static string UpLoadVolumnDir
        {
            get
            {
                return "file/v/" + ScanGlobalInfo.ExamInfo.ID + "/imagesource/";
            }
        }
        /// <summary>
        /// 本地答题卡xml文件路径
        /// </summary>
        public static string LocalScanrecordXmlPath
        {
            get
            {
                return PathHelper.LocalExamDataDir + LocalScanrecordXmlName;
            }
        }

        /// <summary>
        /// 本地答题卡xml文件名称
        /// </summary>
        public static string LocalScanrecordXmlName
        {
            get
            {
                return "scanrecord.xml";
            }
        }

        /// <summary>
        /// 本地答题卡xml待上传文件路径
        /// </summary>
        public static string LocalSaveScanrecordXmlPath
        {
            get
            {
                return PathHelper.LocalExamDataDir + LocalSaveScanrecordXmlFileName;
            }
        }

        /// <summary>
        /// 本地答题卡xml待上传文件名称
        /// </summary>
        public static string LocalSaveScanrecordXmlFileName
        {
            get
            {
                return ScanGlobalInfo.ExamInfo.CsID.ToString() + "." + ScanGlobalInfo.loginUser.data.UID.ToString() + "." + "scanrecord.xml";
            }
        }

        /// <summary>
        /// 本地答题卡xml压缩文件路径
        /// </summary>
        public static string LocalScanrecordXmlZipPath
        {
            get
            {
                return PathHelper.LocalExamDataDir + ScanGlobalInfo.LocalScanID + ".zip";
            }
        }
        /// <summary>
        /// 服务器答题卡压缩文件路径
        /// </summary>
        public static string RemoteScanrecordZipPath
        {
            get
            {
                return "file/v/" + ScanGlobalInfo.ExamInfo.ID + "/LocalData/scanrecord.zip";
            }
        }
        /// <summary>
        /// 正常试卷xml文件路径
        /// </summary>
        public static string NormalExamXmlPath
        {
            get
            {
                return PathHelper.LocalExamDataDir + NormalExamXmlName;
            }
        }

        /// <summary>
        /// 正常试卷xml文件名称
        /// </summary>
        public static string NormalExamXmlName
        {
            get
            {
                return "normalExam.xml";
            }
        }

        /// <summary>
        /// 正常试卷xml待上传文件路径
        /// </summary>
        public static string NormalSaveExamXmlPath
        {
            get
            {
                return PathHelper.LocalExamDataDir + NormalSaveExamXmlFileName;
            }
        }

        /// <summary>
        /// 正常试卷xml待上传文件名称
        /// </summary>
        public static string NormalSaveExamXmlFileName
        {
            get
            {
                return ScanGlobalInfo.ExamInfo.CsID.ToString() + "." + ScanGlobalInfo.loginUser.data.UID.ToString() + "." + "normalExam.xml";
            }
        }

        /// <summary>
        /// 异常试卷xml文件路径
        /// </summary>
        public static string IncorrectExamXmlPath
        {
            get
            {
                return PathHelper.LocalExamDataDir + IncorrectExamXmlName;
            }
        }

        /// <summary>
        /// 异常试卷xml文件名称
        /// </summary>
        public static string IncorrectExamXmlName
        {
            get
            {
                return "incorrectExam.xml";
            }
        }

        /// <summary>
        /// 保存在oss上的异常文件文件路径
        /// </summary>
        public static string IncorrectSaveExamXmlPath
        {
            get
            {
                return PathHelper.LocalExamDataDir + IncorrectSaveExamXmlFileName;
            }
        }

        /// <summary>
        /// 保存在oss上的异常文件名称
        /// </summary>
        public static string IncorrectSaveExamXmlFileName
        {
            get
            {
                return ScanGlobalInfo.ExamInfo.CsID.ToString() + "." + ScanGlobalInfo.loginUser.data.UID.ToString() + "." + "incorrectExam.xml";
            }
        }

        /// <summary>
        /// 扫描统计xml文件路径
        /// </summary>
        public static string ScanStatisticsPath
        {
            get
            {
                string statisticsFilePath = PathHelper.LocalExamDataDir + ScanStatisticsName;

                CreateFile(statisticsFilePath);

                return statisticsFilePath;
            }
        }

        /// <summary>
        /// 扫描统计xml文件名称
        /// </summary>
        public static string ScanStatisticsName
        {
            get
            {
                return "ScanStatistics.xml";
            }
        }

        /// <summary>
        /// 扫描统计xml待上传文件路径
        /// </summary>
        public static string ScanSaveStatisticsPath
        {
            get
            {
                return PathHelper.LocalExamDataDir + ScanSaveStatisticsXmlFileName;
            }
        }


        /// <summary>
        /// 扫描统计xml待上传文件名称
        /// </summary>
        public static string ScanSaveStatisticsXmlFileName
        {
            get
            {
                return ScanGlobalInfo.ExamInfo.CsID.ToString() + "." + ScanGlobalInfo.loginUser.data.UID.ToString() + "." + "ScanStatistics.xml";
            }
        }

        public static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="dir">目录路径</param>
        private static void CreateDirectory(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
