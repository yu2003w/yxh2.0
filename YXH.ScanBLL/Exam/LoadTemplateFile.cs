using System;
using YXH.Model;
using YXH.Common;
using System.IO;
using YXH.Scanner.DALFactory;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 加载模板文件
    /// </summary>
    public static class LoadTplFLoadTemplateFile
    {
        private static BaseFactory _bfDal = new BaseFactory(ScanGlobalInfo.loginUser.data.uname);

        /// <summary>
        /// 当前模板信息
        /// </summary>
        private static TemplateInfo _curTemplateInfo;
        /// <summary>
        /// 模板文件名称
        /// </summary>
        private static string _templateFilename;

        /// <summary>
        /// 当前考试ID
        /// </summary>
        private static long curExamId { get; set; }

        /// <summary>
        /// 当前模板信息
        /// </summary>
        public static TemplateInfo CurTemplateInfo
        {
            get
            {
                if (_curTemplateInfo != null)
                {
                    _curTemplateInfo = null;
                }
                if (_curTemplateInfo == null || curExamId != ScanGlobalInfo.ExamInfo.ID)
                {
                    string text = "";

                    try
                    {
                        if (CheckLocalTemplate(ref text))
                        {
                            string text2 = PathHelper.TpFileDir + _templateFilename;

                            if (File.Exists(text2))
                            {
                                _curTemplateInfo = TemplateHelper.Deserialize(text2);
                                Page[] pages = _curTemplateInfo.pages;

                                for (int i = 0; i < pages.Length; i++)
                                {
                                    Page page = pages[i];
                                    page.fileName = PathHelper.TpFileDir + page.fileName;
                                }

                                curExamId = ScanGlobalInfo.ExamInfo.ID;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _curTemplateInfo = null;

                        LogHelper.WriteFatalLog(ex.Message.ToString(), ex);

                        throw ex;
                    }
                }

                return _curTemplateInfo;
            }
            set
            {
                _curTemplateInfo = value;
                curExamId = ScanGlobalInfo.ExamInfo.ID;
            }
        }

        /// <summary>
        /// 检查本地模板
        /// </summary>
        /// <param name="resMsg">引用消息</param>
        /// <returns>检查结果</returns>
        public static bool CheckLocalTemplate(ref string resMsg)
        {
            string[] files = Directory.GetFiles(PathHelper.TpFileDir, "*.xml");

            if (files.Length == 1)
            {
                _templateFilename = Path.GetFileName(files[0]);

                return true;
            }
            if (files.Length > 1)
            {
                resMsg = "模板目录存在多个模板xml文件。";

                return false;
            }

            resMsg = "本地没有模板文件";

            return false;
        }

        /// <summary>
        /// 获取在线模板信息
        /// </summary>
        /// <returns>在线模板信息数据</returns>
        public static TemplateInfoResponse GetOnlineTemplateInfo()
        {
            TemplateInfoResponse tir = _bfDal.TemplateInfo_GetByCsid(ScanGlobalInfo.ExamInfo.CsID);

            if (tir.Success && tir.Data != null)
            {
                ScanGlobalInfo.TemplateInfo = tir.Data;
            }

            return tir;
        }

        /// <summary>
        /// 从阿里云上加载同步模板
        /// </summary>
        /// <param name="zktiModel">模板信息</param>
        /// <returns>处理结果</returns>
        public static bool LoadTemplateFromALiWithProgress(ZKTemplateInfo zktiModel)
        {
            try
            {
                if (zktiModel != null && zktiModel.AnswerSheetPicPath != null && !string.IsNullOrEmpty(zktiModel.AnswerSheetPicPath))
                {
                    ClearLocalTmpFile(PathHelper.TpFileDir);

                    string[] imageArray = zktiModel.AnswerSheetPicPath.Split(',');

                    foreach (string imageItem in imageArray)
                    {
                        if (!string.IsNullOrWhiteSpace(imageItem))
                        {
                            ALiProgressManager.Oss_GetObject(imageItem, PathHelper.TpFileDir);
                        }
                    }

                    ALiProgressManager.Oss_GetObject(zktiModel.AnswerSheetXMLPath, PathHelper.TpFileDir);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message.ToString(), ex);

                throw ex;
            }
        }

        /// <summary>
        /// 清理本地模板文件
        /// </summary>
        /// <param name="dir">清理目录路径</param>
        private static void ClearLocalTmpFile(string dir)
        {
            string[] files = Directory.GetFiles(dir, "*.*");
            string[] array = files;

            for (int i = 0; i < array.Length; i++)
            {
                string path = array[i];

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
