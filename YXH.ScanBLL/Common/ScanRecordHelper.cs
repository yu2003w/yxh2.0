using System;
using System.Collections.Generic;
using System.IO;
using YXH.Common;
using YXH.Enum;
using YXH.Model;
using System.Linq;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 扫描记录信息处理
    /// </summary>
    public class ScanRecordHelper
    {
        /// <summary>
        /// 全局对象锁
        /// </summary>
        private static object _objXmlwriteLocker = new object();
        /// <summary>
        /// 声明当前实例
        /// </summary>
        private static ScanRecordHelper _instance;
        /// <summary>
        /// 定义当前实例
        /// </summary>
        public static ScanRecordHelper Instance
        {
            get
            {
                if (ScanRecordHelper._instance == null)
                {
                    ScanRecordHelper._instance = new ScanRecordHelper();
                }

                return ScanRecordHelper._instance;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        private ScanRecordHelper() { }

        /// <summary>
        /// 保存答题卡到xml
        /// </summary>
        public void SaveScanrecordToXml()
        {
            lock (ScanRecordHelper._objXmlwriteLocker)
            {
                FileHelper.SeriXmlModel<SynchronizedCollection<ScanRecord>>(PathHelper.LocalScanrecordXmlPath, ScanGlobalInfo.ExamInfo.ScanRecordList);
            }
        }

        /// <summary>
        /// 更新扫描记录
        /// </summary>
        /// <param name="examinationPaper">考卷信息</param>
        public void UpdateScanRecord(ExaminationPaper examinationPaper)
        {
            lock (ScanRecordHelper._objXmlwriteLocker)
            {
                if (examinationPaper != null)
                {
                    ScanRecord scanRecord = (from r in ScanGlobalInfo.ExamInfo.ScanRecordList
                                             where r.Guid.Equals(examinationPaper.Guid.ToString())
                                             select r).FirstOrDefault<ScanRecord>();

                    if (scanRecord == null)
                    {
                        scanRecord = new ScanRecord();
                        ScanGlobalInfo.ExamInfo.ScanRecordList.Add(scanRecord);
                    }

                    scanRecord.ExamId = ScanGlobalInfo.ExamInfo.ID;
                    scanRecord.EsId = examinationPaper.Userid;
                    scanRecord.Classid = examinationPaper.Classid;
                    scanRecord.ScanTime = examinationPaper.ScanTime;
                    scanRecord.BatchNo = ScanGlobalInfo.ExamInfo.ExamName;
                    scanRecord.Files = string.Join(",", examinationPaper.ImagePath);
                    scanRecord.OmrStr = examinationPaper.Omr;
                    scanRecord.Zkzh = examinationPaper.Zkzh;
                    scanRecord.VolumnStatus = examinationPaper.StatusString;
                    scanRecord.VolumnStatus_origin = examinationPaper.VolumnStatus_origin;
                    scanRecord.Guid = examinationPaper.Guid.ToString();
                    scanRecord.OmrStr2 = string.Join(" ", examinationPaper.Omrs);
                    scanRecord.Zkzh_origin = examinationPaper.Zkzh_origin;
                    scanRecord.ScanID = examinationPaper.ScanID;
                    scanRecord.cliped = 0;
                    scanRecord.rescanned = false;
                    scanRecord.modified = examinationPaper.ConfirmOmrIsModify;
                    scanRecord.Status = 0;
                    scanRecord.IsB = false;
                    scanRecord.Isqk = false;
                    scanRecord.BatchID = examinationPaper.BatchId;
                    scanRecord.BatchIndex = examinationPaper.Index;

                    if (examinationPaper.Status.Contains(VolumeStatus.ManualHandleomr))
                    {
                        scanRecord.ManualOpFlag = "0";
                    }
                }
            }
        }

        /// <summary>
        /// 更新扫描记录状态
        /// </summary>
        /// <param name="examinationPaper">试卷信息</param>
        public void UpdateScanRecordStatus(ExaminationPaper examinationPaper)
        {
            lock (ScanRecordHelper._objXmlwriteLocker)
            {
                if (examinationPaper != null)
                {
                    try
                    {
                        ScanRecord scanRecord = (from r in ScanGlobalInfo.ExamInfo.ScanRecordList
                                                 where r.Guid.Equals(examinationPaper.Guid.ToString())
                                                 select r).FirstOrDefault<ScanRecord>();

                        if (scanRecord != null && scanRecord.VolumnStatus != examinationPaper.StatusString)
                        {
                            scanRecord.VolumnStatus = examinationPaper.StatusString;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 删除本地扫描记录
        /// </summary>
        /// <param name="guid">GUID</param>
        public void DeleteLocalScanRecord(string guid)
        {
            lock (ScanRecordHelper._objXmlwriteLocker)
            {
                ScanRecord scanRecord = (from r in ScanGlobalInfo.ExamInfo.ScanRecordList
                                         where r.Guid.Equals(guid)
                                         select r).FirstOrDefault<ScanRecord>();

                if (scanRecord != null)
                {
                    ScanGlobalInfo.ExamInfo.ScanRecordList.Remove(scanRecord);
                }
            }
        }

        /// <summary>
        /// 上传考试列表状态
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="status">状态</param>
        public void UpLoadExamListStatus(string userid, string status)
        {
            lock (ScanRecordHelper._objXmlwriteLocker)
            {
                ScanRecord scanRecord = null;

                try
                {
                    scanRecord = (from r in ScanGlobalInfo.ExamInfo.ScanRecordList
                                  where r.EsId.Equals(userid)
                                  select r).FirstOrDefault<ScanRecord>();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteFatalLog(ex.Message.ToString(), ex);
                }

                if (scanRecord != null)
                {
                    scanRecord.Status = StringUtility.ToInt32Default(status, 0);
                }
            }
        }

        /// <summary>
        /// 验证记录是否存在
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <returns>记录状态</returns>
        public bool IsRecordExist(string guid)
        {
            bool result;

            lock (ScanRecordHelper._objXmlwriteLocker)
            {
                try
                {
                    ScanRecord scanRecord = (from r in ScanGlobalInfo.ExamInfo.ScanRecordList
                                             where r.Guid.Equals(guid)
                                             select r).FirstOrDefault<ScanRecord>();

                    if (scanRecord != null)
                    {
                        result = true;

                        return result;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteFatalLog(ex.Message.ToString(), ex);
                }

                result = false;
            }

            return result;
        }

        /// <summary>
        /// 检查本地xml
        /// </summary>
        /// <returns>检查结果</returns>
        public static bool CheckLocalXml()
        {
            bool flag = File.Exists(PathHelper.NormalExamXmlPath),  //正常试卷xml路径
                flag2 = File.Exists(PathHelper.IncorrectExamXmlPath),   //异常试卷xml路径
                flag3 = File.Exists(PathHelper.LocalScanrecordXmlPath); //本地答题卡xml路径

            if (!flag && !flag2)
            {
                return !flag3;
            }
            if (flag && flag2)
            {
                if (!flag3)
                {
                    return false;
                }

                Dictionary<int, List<VolumnDataRow>> dictionary = new Dictionary<int, List<VolumnDataRow>>();
                Dictionary<int, List<VolumnDataRow>> dictionary2 = new Dictionary<int, List<VolumnDataRow>>();

                try
                {
                    dictionary = FileHelper.DeserializeFromXml<Dictionary<int, List<VolumnDataRow>>>(PathHelper.NormalExamXmlPath);
                    dictionary2 = FileHelper.DeserializeFromXml<Dictionary<int, List<VolumnDataRow>>>(PathHelper.IncorrectExamXmlPath);

                    int num = 0;
                    ScanGlobalInfo.ExamInfo.ScanRecordList = FileHelper.DeseriXmlModel<SynchronizedCollection<ScanRecord>>(PathHelper.LocalScanrecordXmlPath);

                    foreach (int current in dictionary.Keys)
                    {
                        if (!dictionary2.ContainsKey(current))
                        {
                            bool result = false;

                            return result;
                        }

                        num += dictionary[current].Count + dictionary2[current].Count;
                    }
                    if (num == ScanGlobalInfo.ExamInfo.ScanRecordList.Count)
                    {
                        bool result = true;

                        return result;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteFatalLog(ex.Message.ToString(), ex);

                    ScanGlobalInfo.ExamInfo.ScanRecordList = null;
                    bool result = false;

                    return result;
                }
            }

            return false;
        }

        /// <summary>
        /// 加载zip中的xml文件数据
        /// </summary>
        /// <param name="hasloadLocalZipxml">是否加载</param>
        /// <returns>加载状态</returns>
        public static bool LoadZipXmlData(bool hasloadLocalZipxml)
        {
            try
            {
                if (!File.Exists(PathHelper.LocalScanrecordXmlZipPath) || hasloadLocalZipxml)
                {
                    ScanRecordHelper.DeleteAllXmlFile();

                    bool result = false;

                    return result;
                }

                FileInfo fileInfo = new FileInfo(PathHelper.LocalScanrecordXmlZipPath);

                if (fileInfo.Extension == ".zip")
                {
                    Compress.ZipExtract(PathHelper.LocalScanrecordXmlZipPath, PathHelper.LocalExamDataDir);

                    bool result = true;

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message.ToString(), ex);
                ScanRecordHelper.DeleteAllXmlFile();

                bool result = true;

                return result;
            }

            return false;
        }

        /// <summary>
        /// 删除所有xml文件
        /// </summary>
        public static void DeleteAllXmlFile()
        {
            if (File.Exists(PathHelper.LocalScanrecordXmlPath))
            {
                File.Delete(PathHelper.LocalScanrecordXmlPath);

                ScanGlobalInfo.ExamInfo.ScanRecordList = null;
            }
            if (File.Exists(PathHelper.NormalExamXmlPath))
            {
                File.Delete(PathHelper.NormalExamXmlPath);
            }
            if (File.Exists(PathHelper.IncorrectExamXmlPath))
            {
                File.Delete(PathHelper.IncorrectExamXmlPath);
            }
        }
    }
}
