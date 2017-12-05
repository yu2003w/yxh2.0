using System;
using System.Collections.Generic;
using System.IO;
using YXH.Common;
using YXH.Common.OuterInterop;
using YXH.Enum;
using YXH.Model;
using System.Linq;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 批次扫描
    /// </summary>
    public class BatchScan
    {
        /// <summary>
        /// 执行对象锁
        /// </summary>
        public static object lockDataModifyObj = new object();

        /// <summary>
        /// 扫描单人试卷
        /// </summary>
        /// <param name="templateInfo">模板信息</param>
        /// <param name="scanner">扫描仪句柄</param>
        /// <param name="batchNo">批次编号</param>
        /// <param name="currentImages">当前图片路径列表</param>
        /// <param name="studentExamInfoList">学生试卷信息列表</param>
        /// <param name="normalDic">正确试卷集合</param>
        /// <param name="incorrectDic">异常试卷集合</param>
        /// <param name="loadSourceSucceed">加载源状态</param>
        /// <param name="index">页码</param>
        public static void ScanOneExamPaper(TemplateInfo templateInfo, IntPtr scanner, int batchNo, IList<string> currentImages
            , IList<StudentExamInfo> studentExamInfoList, Dictionary<int, List<VolumnDataRow>> normalDic, Dictionary<int, List<VolumnDataRow>> incorrectDic
            , bool loadSourceSucceed, int index)
        {
            CurrentExamPaper currentExamPaper = new CurrentExamPaper(scanner);

            currentExamPaper.VolumnDataRow.Data.ImagePath = currentImages.ToArray<string>();
            currentExamPaper.VolumnDataRow.Data.IsWaitToUpload = true;
            currentExamPaper.VolumnDataRow.Data.IsWaitSave = true;
            currentExamPaper.VolumnDataRow.Data.Index = index;
            currentExamPaper.VolumnDataRow.Data.BatchId = batchNo;

            if (!loadSourceSucceed)
            {
                currentExamPaper.IsOK = false;

                currentExamPaper.VolumnDataRow.Data.Status.Add(VolumeStatus.LoadingFailed);
                currentExamPaper.VolumnDataRow.Data.Status.Add(VolumeStatus.ErrorPage);

                currentExamPaper.VolumnDataRow.Data.Zkzh = string.Empty;
            }
            else
            {
                currentExamPaper.PaperScan = new PageNumCheck(currentExamPaper);

                currentExamPaper.RequestScan();

                if (currentExamPaper.IsOK)
                {
                    currentExamPaper.PaperScan = new TitleCheck(currentExamPaper, templateInfo);

                    currentExamPaper.RequestScan();

                    for (int i = 0; i < currentImages.Count; i++)
                    {
                        IntPtr adjustedImage = ScanlibInterop.GetAdjustedImage(scanner, i);

                        ScanlibInterop.SaveImage(adjustedImage, PathHelper.LocalVolumneImgDir + currentImages[i]);
                        BatchScan.ReleaseImage(adjustedImage);
                    }
                    if (currentExamPaper.IsOK)
                    {
                        currentExamPaper.PaperScan = new ExamNumberCheck(currentExamPaper, templateInfo, normalDic, incorrectDic);

                        currentExamPaper.RequestScan();

                        currentExamPaper.PaperScan = new AnswerCheck(currentExamPaper, templateInfo.pages);

                        currentExamPaper.RequestScan();
                    }
                    else
                    {
                        currentExamPaper.VolumnDataRow.Data.Zkzh = string.Empty;
                    }
                }
                else
                {
                    currentExamPaper.VolumnDataRow.Data.Zkzh = string.Empty;
                }
            }
            if (!string.IsNullOrEmpty(currentExamPaper.VolumnDataRow.Data.Zkzh))
            {
                StudentExamInfo studentExamInfo = (from s in studentExamInfoList
                                                   where s.ExamCode.Equals(currentExamPaper.VolumnDataRow.Data.Zkzh)
                                                   select s).FirstOrDefault<StudentExamInfo>();

                if (studentExamInfo != null)
                {
                    currentExamPaper.VolumnDataRow.Data.Userid = studentExamInfo.ID;
                    currentExamPaper.VolumnDataRow.Data.StudentName = studentExamInfo.StuName;
                }
                else if (!currentExamPaper.VolumnDataRow.Data.Status.Contains(VolumeStatus.ErrZkzh))
                {
                    currentExamPaper.IsOK = false;

                    currentExamPaper.VolumnDataRow.Data.Status.Add(VolumeStatus.ErrZkzh);
                }
            }
            else
            {
                currentExamPaper.IsOK = false;
            }
            if (ScanGlobalInfo.ScanMode == ScanMode.Room && !(currentExamPaper.VolumnDataRow.Data.Userid > 0))
            {
                StudentExamInfo studentExamInfo2 = (from s in studentExamInfoList
                                                    where s.ID.ToString().Equals(currentExamPaper.VolumnDataRow.Data.Userid)
                                                    select s).FirstOrDefault<StudentExamInfo>();

                if (studentExamInfo2 != null)
                {
                    currentExamPaper.VolumnDataRow.Data.MatchStatus = RoomMatchStatus.Match;
                }
                else
                {
                    currentExamPaper.VolumnDataRow.Data.Room = string.Empty;
                    currentExamPaper.VolumnDataRow.Data.MatchStatus = RoomMatchStatus.UnMatch;
                }
            }
            if (!currentExamPaper.IsOK || currentExamPaper.VolumnDataRow.Data.Status.Count > 0)
            {
                if (currentExamPaper.VolumnDataRow.Data.Status.Contains(VolumeStatus.Ambiguous) || currentExamPaper.VolumnDataRow.Data.Status.Contains(VolumeStatus.Duplicate) || currentExamPaper.VolumnDataRow.Data.Status.Contains(VolumeStatus.ErrZkzh))
                {
                    currentExamPaper.VolumnDataRow.ErrorStatusList.Add(ErrorStatus.StudentInfoError);
                }
                if (currentExamPaper.VolumnDataRow.Data.Status.Contains(VolumeStatus.ErrorPage) || currentExamPaper.VolumnDataRow.Data.Status.Contains(VolumeStatus.MissingPage))
                {
                    currentExamPaper.VolumnDataRow.ErrorStatusList.Add(ErrorStatus.ExamPaperInfoError);
                }
                if (currentExamPaper.VolumnDataRow.Data.Status.Contains(VolumeStatus.ErrOmr) || currentExamPaper.VolumnDataRow.Data.Status.Contains(VolumeStatus.ManualHandleomr))
                {
                    currentExamPaper.VolumnDataRow.ErrorStatusList.Add(ErrorStatus.ObjectiveOmrError);
                }
                if (!incorrectDic.ContainsKey(batchNo))
                {
                    incorrectDic.Add(batchNo, new List<VolumnDataRow>());
                }

                incorrectDic[batchNo].Add(currentExamPaper.VolumnDataRow);
                currentExamPaper.VolumnDataRow.RefreshText();
            }
            else
            {
                currentExamPaper.VolumnDataRow.Data.Status = new List<VolumeStatus>
				{
					VolumeStatus.Normal
				};

                if (!normalDic.ContainsKey(batchNo))
                {
                    normalDic.Add(batchNo, new List<VolumnDataRow>());
                }

                normalDic[batchNo].Add(currentExamPaper.VolumnDataRow);
                currentExamPaper.VolumnDataRow.RefreshText();
            }

            currentExamPaper.VolumnDataRow.Data.VolumnStatus_origin = currentExamPaper.VolumnDataRow.Data.StatusString;

            ScanRecordHelper.Instance.UpdateScanRecord(currentExamPaper.VolumnDataRow.Data);
        }

        /// <summary>
        /// 释放图片
        /// </summary>
        /// <param name="ptr"></param>
        public static void ReleaseImage(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                ScanlibInterop.ReleaseImage(ptr);

                ptr = IntPtr.Zero;
            }
        }

        /// <summary>
        /// 从xml获取正常试卷信息
        /// </summary>
        /// <param name="batchNo">批次编号</param>
        /// <returns>正常试卷集合</returns>
        public static Dictionary<int, List<VolumnDataRow>> GetNormalPaperFromXml(int batchNo)
        {
            Dictionary<int, List<VolumnDataRow>> dictionary = new Dictionary<int, List<VolumnDataRow>>();

            if (File.Exists(PathHelper.NormalExamXmlPath))
            {
                dictionary = FileHelper.DeserializeFromXml<Dictionary<int, List<VolumnDataRow>>>(PathHelper.NormalExamXmlPath);
            }
            if (!dictionary.Keys.Contains(batchNo))
            {
                dictionary.Add(batchNo, new List<VolumnDataRow>());
            }

            return dictionary;
        }

        /// <summary>
        /// 从xml文件中获取异常卷信息
        /// </summary>
        /// <param name="batchNo">批次编号</param>
        /// <returns>异常卷列表</returns>
        public static Dictionary<int, List<VolumnDataRow>> GetIncorrectExamPaperFromXml(int batchNo)
        {
            Dictionary<int, List<VolumnDataRow>> dictionary = new Dictionary<int, List<VolumnDataRow>>();

            if (File.Exists(PathHelper.IncorrectExamXmlPath))
            {
                dictionary = FileHelper.DeserializeFromXml<Dictionary<int, List<VolumnDataRow>>>(PathHelper.IncorrectExamXmlPath);
            }
            if (!dictionary.Keys.Contains(batchNo))
            {
                dictionary.Add(batchNo, new List<VolumnDataRow>());
            }

            return dictionary;
        }

        /// <summary>
        /// 创建扫描器
        /// </summary>
        /// <param name="templateInfo">模板信息</param>
        /// <returns>扫描器句柄</returns>
        public static IntPtr CreateScanner(TemplateInfo templateInfo)
        {
            IntPtr intPtr = ScanlibInterop.CreateScanner();

            if (intPtr == IntPtr.Zero)
            {
                throw new Exception("创建识别器失败！");
            }

            ScanlibInterop.SetPageNum(intPtr, templateInfo.pages.Length);

            if (templateInfo.pages.Length > 1 && (!templateInfo.isDoubleSide.HasValue || templateInfo.isDoubleSide == true))
            {
                string text = "";

                for (int i = 0; i < templateInfo.pages.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        text = text + i + ":";
                    }
                    else
                    {
                        text = text + i + ";";
                    }
                }

                ScanlibInterop.SetPagePair(intPtr, text);
            }

            return intPtr;
        }

        /// <summary>
        /// 准备加载下一页
        /// </summary>
        /// <param name="scanner">扫描器句柄</param>
        public static void PrepareToLoadNext(IntPtr scanner)
        {
            ScanlibInterop.PrepareToLoadNext(scanner);
        }

        /// <summary>
        /// 加载模板图片
        /// </summary>
        /// <param name="scanner">扫描器句柄</param>
        /// <param name="templateInfo">模板信息</param>
        /// <returns>加载状态</returns>
        public static bool LoadTemplImage(IntPtr scanner, TemplateInfo templateInfo)
        {
            bool flag = true;

            for (int i = 0; i < templateInfo.pages.Length; i++)
            {
                Page page = templateInfo.pages[i];

                if (page != null)
                {
                    flag = ScanlibInterop.LoadTmplImage(scanner, page.fileName, page.pageIndex);

                    if (!flag)
                    {
                        break;
                    }
                }
            }

            return flag;
        }

        /// <summary>
        /// 设置标题区域
        /// </summary>
        /// <param name="scanner">扫描器句柄</param>
        /// <param name="templateInfo">模板信息</param>
        /// <returns>设置结果</returns>
        public static bool SetTitleArea(IntPtr scanner, TemplateInfo templateInfo)
        {
            bool flag = true;
            Page[] pages = templateInfo.pages;

            for (int i = 0; i < pages.Length; i++)
            {
                Page page = pages[i];

                if (page.localRegion != null)
                {
                    CvRect matchRegion = page.localRegion.matchRegion;

                    flag = ScanlibInterop.SetTitleArea(scanner, matchRegion, page.pageIndex);

                    if (!flag)
                    {
                        break;
                    }
                }
            }

            return flag;
        }

        /// <summary>
        /// 旋转图片
        /// </summary>
        /// <param name="src">源图片句柄</param>
        /// <param name="degree">旋转角度</param>
        /// <returns>目标图片句柄</returns>
        public static IntPtr RotateImage(IntPtr src, int degree)
        {
            IntPtr result = ScanlibInterop.RotateImage(src, (double)degree);

            ScanlibInterop.ReleaseImage(src);

            src = IntPtr.Zero;

            return result;
        }

        /// <summary>
        /// 加载源图
        /// </summary>
        /// <param name="img">源图句柄</param>
        /// <param name="scanner">扫描器句柄</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>加载结果</returns>
        public static bool LoadSourceImage(IntPtr img, IntPtr scanner, int pageIndex)
        {
            return ScanlibInterop.LoadSourceImage(scanner, img, pageIndex);
        }

        /// <summary>
        /// 设置确定阈值
        /// </summary>
        /// <param name="pScanner">扫描器句柄</param>
        /// <param name="t">阈值大小</param>
        /// <returns>设置结果</returns>
        public static bool SetConvincedThreshold(IntPtr pScanner, double t)
        {
            return ScanlibInterop.SetConvincedThreshold(pScanner, t);
        }

        /// <summary>
        /// 设置异常阈值
        /// </summary>
        /// <param name="pScanner">扫描器句柄</param>
        /// <param name="t">阈值大小</param>
        /// <returns>设置结果</returns>
        public static bool SetDoubtfulThreshold(IntPtr pScanner, double t)
        {
            return ScanlibInterop.SetDoubtfulThreshold(pScanner, t);
        }
    }
}
