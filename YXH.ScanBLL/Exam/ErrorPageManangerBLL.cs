using System;
using System.Collections.Generic;
using System.IO;
using YXH.Common;
using YXH.Enum;
using System.Linq;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 错误页管理处理
    /// </summary>
    public static class ErrorPageManangerBLL
    {
        /// <summary>
        /// 异常试卷集合
        /// </summary>
        private static Dictionary<int, List<VolumnDataRow>> _incorrectDic;
        /// <summary>
        /// 正常试卷集合
        /// </summary>
        private static Dictionary<int, List<VolumnDataRow>> _normalDic;
        /// <summary>
        /// 卷错误集合
        /// </summary>
        private static List<VolumnDataRow> _pagerErrorList;
        /// <summary>
        /// 学生信息错误集合
        /// </summary>
        private static List<VolumnDataRow> _studentInfoErrorList;
        /// <summary>
        /// Omr识别错误集合
        /// </summary>
        private static List<VolumnDataRow> _omErrorList;
        /// <summary>
        /// 是否加载本地zip中的xml
        /// </summary>
        public static bool hasloadLocalZipxml = false;
        /// <summary>
        /// 批次编号
        /// </summary>
        public static int BatchNo { get; set; }
        /// <summary>
        /// 异常卷集合
        /// </summary>
        public static Dictionary<int, List<VolumnDataRow>> IncorrectDic
        {
            get
            {
                return ErrorPageManangerBLL._incorrectDic;
            }
            set
            {
                ErrorPageManangerBLL._incorrectDic = value;
            }
        }
        /// <summary>
        /// 正常卷集合
        /// </summary>
        public static Dictionary<int, List<VolumnDataRow>> NormalDic
        {
            get
            {
                return ErrorPageManangerBLL._normalDic;
            }
            set
            {
                ErrorPageManangerBLL._normalDic = value;
            }
        }
        /// <summary>
        /// 页错误集合
        /// </summary>
        public static List<VolumnDataRow> PagerErrorList
        {
            get
            {
                lock (BatchScan.lockDataModifyObj)
                {
                    ErrorPageManangerBLL._pagerErrorList = ErrorPageManangerBLL.GetOperateErrorList(ErrorPageManangerBLL.BatchNo, ErrorStatus.ExamPaperInfoError);
                }

                return ErrorPageManangerBLL._pagerErrorList;
            }
        }
        /// <summary>
        /// 学生信息错误集合
        /// </summary>
        public static List<VolumnDataRow> StudentInfoErrorList
        {
            get
            {
                lock (BatchScan.lockDataModifyObj)
                {
                    ErrorPageManangerBLL._studentInfoErrorList = ErrorPageManangerBLL.GetOperateErrorList(ErrorPageManangerBLL.BatchNo, ErrorStatus.StudentInfoError);
                }

                return ErrorPageManangerBLL._studentInfoErrorList;
            }
        }
        /// <summary>
        /// omr识别错误集合
        /// </summary>
        public static List<VolumnDataRow> OmrErrorList
        {
            get
            {
                lock (BatchScan.lockDataModifyObj)
                {
                    ErrorPageManangerBLL._omErrorList = ErrorPageManangerBLL.GetOperateErrorList(ErrorPageManangerBLL.BatchNo, ErrorStatus.ObjectiveOmrError);
                }

                return ErrorPageManangerBLL._omErrorList;
            }
        }
        /// <summary>
        /// 所有扫描卷数据
        /// </summary>
        public static List<VolumnDataRow> AllScanVolumnData
        {
            get
            {
                List<VolumnDataRow> list = new List<VolumnDataRow>();

                lock (BatchScan.lockDataModifyObj)
                {
                    if (ErrorPageManangerBLL.IncorrectDic != null && ErrorPageManangerBLL.NormalDic != null)
                    {
                        foreach (List<VolumnDataRow> current in ErrorPageManangerBLL.IncorrectDic.Values)
                        {
                            list.AddRange(current);
                        }
                        foreach (List<VolumnDataRow> current2 in ErrorPageManangerBLL.NormalDic.Values)
                        {
                            list.AddRange(current2);
                        }
                    }
                }

                return list;
            }
        }

        /// <summary>
        /// 获取操作错误列表
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <param name="targetStatus">目标错误状态</param>
        /// <returns>错误列表</returns>
        private static List<VolumnDataRow> GetOperateErrorList(int batchId, ErrorStatus targetStatus)
        {
            List<VolumnDataRow> list = null;

            if (ErrorPageManangerBLL._incorrectDic == null)
            {
                return list;
            }
            if (ErrorPageManangerBLL._incorrectDic.ContainsKey(batchId) && ErrorPageManangerBLL._incorrectDic[batchId].Count > 0)
            {
                lock (BatchScan.lockDataModifyObj)
                {
                    list = ErrorPageManangerBLL._incorrectDic[batchId].FindAll((VolumnDataRow p) => p.ErrorStatusList.Contains(targetStatus));

                    if (list != null && list.Count == 0)
                    {
                        list = null;
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 是否在其它错误列表中
        /// </summary>
        /// <param name="batchId">批次I的</param>
        /// <param name="curRow">当前行</param>
        /// <param name="targetErorStatus">目标错误状态</param>
        /// <returns>检查结果</returns>
        public static bool IsInOtherErrorList(int batchId, VolumnDataRow curRow, ErrorStatus targetErorStatus)
        {
            switch (targetErorStatus)
            {
                case ErrorStatus.ExamPaperInfoError:
                    if (ErrorPageManangerBLL.PagerErrorList != null && ErrorPageManangerBLL.PagerErrorList.Count > 0)
                    {
                        if (ErrorPageManangerBLL.PagerErrorList.Any((VolumnDataRow p) => p.Data.Index == curRow.Data.Index))
                        {
                            return true;
                        }
                    }

                    break;
                case ErrorStatus.StudentInfoError:
                    if (ErrorPageManangerBLL.StudentInfoErrorList != null && ErrorPageManangerBLL.StudentInfoErrorList.Count > 0)
                    {
                        if (ErrorPageManangerBLL.StudentInfoErrorList.Any((VolumnDataRow p) => p.Data.Index == curRow.Data.Index))
                        {
                            return true;
                        }
                    }

                    break;
                case ErrorStatus.ObjectiveOmrError:
                    if (ErrorPageManangerBLL.OmrErrorList != null && ErrorPageManangerBLL.OmrErrorList.Count > 0)
                    {
                        if (ErrorPageManangerBLL.OmrErrorList.Any((VolumnDataRow p) => p.Data.Index == curRow.Data.Index))
                        {
                            return true;
                        }
                    }

                    break;
            }

            return false;
        }

        /// <summary>
        /// 是否有相同的准考证号在正常试卷中
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <param name="curRow">当前试卷</param>
        /// <param name="targetRow">目标试卷</param>
        /// <returns>检查结果</returns>
        public static bool IsHasSameZkzhInNormalList(int batchId, VolumnDataRow curRow, ref VolumnDataRow targetRow)
        {
            lock (BatchScan.lockDataModifyObj)
            {
                if (ErrorPageManangerBLL.NormalDic != null && ErrorPageManangerBLL.NormalDic.ContainsKey(batchId))
                {
                    foreach (int current in ErrorPageManangerBLL.NormalDic.Keys)
                    {
                        List<VolumnDataRow> list = ErrorPageManangerBLL.NormalDic[current];

                        if (list != null && list.Count > 0)
                        {
                            if (list.Any((VolumnDataRow p) => p.Zkzh == curRow.Zkzh))
                            {
                                targetRow = list.Find((VolumnDataRow p) => p.Zkzh == curRow.Zkzh);

                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 是否有相同的准考证号在异常试卷中
        /// </summary>
        /// <param name="curRow">当前试卷</param>
        /// <returns>检查结果</returns>
        public static bool IsHasSameZkzhInAbnormalList(VolumnDataRow curRow)
        {
            lock (BatchScan.lockDataModifyObj)
            {
                if (ErrorPageManangerBLL.IncorrectDic != null)
                {
                    foreach (int current in ErrorPageManangerBLL.IncorrectDic.Keys)
                    {
                        List<VolumnDataRow> list = ErrorPageManangerBLL.IncorrectDic[current];

                        if (list != null && list.Count > 0)
                        {
                            List<VolumnDataRow> list2 = list.FindAll((VolumnDataRow p) => p.Zkzh == curRow.Zkzh);

                            if (list2 != null && list2.Count > 0)
                            {
                                if (list2.Any((VolumnDataRow p) => p.Data.Guid.ToString() != curRow.Data.Guid.ToString()))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 是否有目标的错误状态
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <param name="targetStatus">目标错误状态</param>
        /// <returns>设置状态</returns>
        public static bool IsHasTargetErrorStatus(int batchId, ErrorStatus targetStatus)
        {
            List<VolumnDataRow> operateErrorList = ErrorPageManangerBLL.GetOperateErrorList(batchId, targetStatus);

            return operateErrorList != null && operateErrorList.Count != 0;
        }

        /// <summary>
        /// 初始化字典
        /// </summary>
        public static void InitializeDictionary()
        {
            int batchNo = 0;

            if (!ScanRecordHelper.CheckLocalXml())
            {
                ErrorPageManangerBLL.hasloadLocalZipxml = ScanRecordHelper.LoadZipXmlData(ErrorPageManangerBLL.hasloadLocalZipxml);

                ErrorPageManangerBLL.InitializeDictionary();
            }
            if (File.Exists(PathHelper.NormalExamXmlPath))
            {
                try
                {
                    ErrorPageManangerBLL.NormalDic = FileHelper.DeserializeFromXml<Dictionary<int, List<VolumnDataRow>>>(PathHelper.NormalExamXmlPath);

                    goto IL_71;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteFatalLog(ex.Message.ToString(), ex);

                    ErrorPageManangerBLL.hasloadLocalZipxml = ScanRecordHelper.LoadZipXmlData(ErrorPageManangerBLL.hasloadLocalZipxml);

                    ErrorPageManangerBLL.InitializeDictionary();

                    goto IL_71;
                }
            }

            ErrorPageManangerBLL.NormalDic = BatchScan.GetNormalPaperFromXml(batchNo);

        IL_71:

            if (File.Exists(PathHelper.IncorrectExamXmlPath))
            {
                try
                {
                    ErrorPageManangerBLL.IncorrectDic = FileHelper.DeserializeFromXml<Dictionary<int, List<VolumnDataRow>>>(PathHelper.IncorrectExamXmlPath);

                    return;
                }
                catch (Exception ex2)
                {
                    LogHelper.WriteFatalLog(ex2.Message.ToString(), ex2);

                    ErrorPageManangerBLL.hasloadLocalZipxml = ScanRecordHelper.LoadZipXmlData(ErrorPageManangerBLL.hasloadLocalZipxml);

                    ErrorPageManangerBLL.InitializeDictionary();

                    return;
                }
            }

            ErrorPageManangerBLL.IncorrectDic = BatchScan.GetIncorrectExamPaperFromXml(batchNo);
        }

        /// <summary>
        /// 获取异常卷数量
        /// </summary>
        /// <returns>异常卷数量</returns>
        public static int GetIncorrectPaperCount()
        {
            int result = 0;

            if (ErrorPageManangerBLL.IncorrectDic != null)
            {
                result = ErrorPageManangerBLL.IncorrectDic.Values.Sum((List<VolumnDataRow> l) => l.Count);
            }

            return result;
        }

        /// <summary>
        /// 检查疑问率
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <returns>疑问率</returns>
        public static double CheckDoubtfulRate(int batchId)
        {
            double result = 0.0;
            ErrorPageManangerBLL.BatchNo = batchId;

            if (ErrorPageManangerBLL.NormalDic != null && ErrorPageManangerBLL.IncorrectDic != null && ErrorPageManangerBLL.NormalDic.ContainsKey(batchId) && ErrorPageManangerBLL.IncorrectDic.ContainsKey(batchId))
            {
                List<VolumnDataRow> operateErrorList = ErrorPageManangerBLL.GetOperateErrorList(batchId, ErrorStatus.ObjectiveOmrError);

                if (operateErrorList != null && operateErrorList.Count > 0)
                {
                    int count = operateErrorList.FindAll((VolumnDataRow p) => p.Data.OmrItemTye == OmrValueType.NotConfirm).Count,
                        num = ErrorPageManangerBLL.NormalDic[batchId].Count + ErrorPageManangerBLL.IncorrectDic[batchId].Count;

                    if (count <= num && count > 5)
                    {
                        result = (double)count / (double)num;
                    }
                }
            }

            return result;
        }
    }
}
