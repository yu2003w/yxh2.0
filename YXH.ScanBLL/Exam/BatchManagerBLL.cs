using System.Collections.Generic;
using YXH.Scanner.DALFactory;
using YXH.Model;
using YXH.Common;
using YXH.HttpHelper.Response;
using System;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 批次管理
    /// </summary>
    public class BatchManagerBLL
    {
        /// <summary>
        /// 数据访问的实例
        /// </summary>
        private BaseFactory _dalFactory = new BaseFactory(ScanGlobalInfo.loginUser.data.uname);
        /// <summary>
        /// 实例声明
        /// </summary>
        private static BatchManagerBLL _instance;
        /// <summary>
        /// 批次编号
        /// </summary>
        private int _batchNo;
        /// <summary>
        /// 选中批次编号
        /// </summary>
        private int _selectedBatchId = -1;
        /// <summary>
        /// 标准卷字典
        /// </summary>
        public Dictionary<int, List<VolumnDataRow>> normalDic { get; set; }
        /// <summary>
        /// 异常卷字典
        /// </summary>
        public Dictionary<int, List<VolumnDataRow>> incorrectDic { get; set; }
        /// <summary>
        /// 是批次列表
        /// </summary>
        public List<BatchDataRow> _lsBatchList { get; set; }
        /// <summary>
        /// 批次编号
        /// </summary>
        public int BatchNo
        {
            get
            {
                return this.GetBatchNo();
            }
            set
            {
                this._batchNo = value;
            }
        }

        /// <summary>
        /// 定义静态实例
        /// </summary>
        public static BatchManagerBLL Instance
        {
            get
            {
                if (BatchManagerBLL._instance == null)
                {
                    BatchManagerBLL._instance = new BatchManagerBLL();
                }

                return BatchManagerBLL._instance;
            }
            set
            {
                BatchManagerBLL._instance = value;
            }
        }

        /// <summary>
        /// 初始化批次数据
        /// </summary>
        /// <param name="norDic">标准卷字典</param>
        /// <param name="incorDic">异常卷字典</param>
        /// <param name="lsBatchList">是批次列表</param>
        /// <returns>初始化状态</returns>
        public bool InitialBatchData(Dictionary<int, List<VolumnDataRow>> norDic, Dictionary<int, List<VolumnDataRow>> incorDic, List<BatchDataRow> lsBatchList)
        {
            if (norDic == null || incorDic == null)
            {
                return false;
            }
            if (lsBatchList == null)
            {
                return false;
            }

            this.normalDic = norDic;
            this.incorrectDic = incorDic;
            this._lsBatchList = lsBatchList;

            foreach (int current in this.normalDic.Keys)
            {
                BatchDataRow batchDataRow = new BatchDataRow();

                batchDataRow.BatchIndex = current;
                batchDataRow.BatchTotal = this.normalDic[current].Count + this.incorrectDic[current].Count;
                batchDataRow.AbnormalNum = this.incorrectDic[current].Count;

                this._lsBatchList.Add(batchDataRow);

                if (this._batchNo < current)
                {
                    this._batchNo = current;
                }
            }

            return true;
        }

        /// <summary>
        /// 获取批次编号
        /// </summary>
        /// <returns>批次编号</returns>
        public int GetBatchNo()
        {
            if (this._lsBatchList != null)
            {
                foreach (BatchDataRow current in this._lsBatchList)
                {
                    if (this._batchNo < current.BatchIndex)
                    {
                        this._batchNo = current.BatchIndex;
                    }
                }

                return this._batchNo;
            }

            return this._batchNo;
        }

        /// <summary>
        /// 准备下一批次
        /// </summary>
        /// <param name="curBatchId">当前批次ID</param>
        /// <returns>下一批次ID</returns>
        public int prepareNextBatch(int curBatchId)
        {
            if (ScanGlobalInfo.ExamInfo.ScanRecordList.Count > 0)
            {
                if (!this.normalDic.ContainsKey(curBatchId))
                {
                    this.normalDic.Add(curBatchId, new List<VolumnDataRow>());
                    this.incorrectDic.Add(curBatchId, new List<VolumnDataRow>());
                }
                else if (this.normalDic[curBatchId].Count + this.incorrectDic[curBatchId].Count > 0)
                {
                    curBatchId++;

                    this.normalDic.Add(curBatchId, new List<VolumnDataRow>());
                    this.incorrectDic.Add(curBatchId, new List<VolumnDataRow>());
                }
            }
            else
            {
                if (this.normalDic.ContainsKey(curBatchId))
                {
                    this.normalDic.Remove(curBatchId);
                    this.incorrectDic.Remove(curBatchId);
                }
                if (!this.normalDic.ContainsKey(curBatchId))
                {
                    this.normalDic.Add(curBatchId, new List<VolumnDataRow>());
                    this.incorrectDic.Add(curBatchId, new List<VolumnDataRow>());
                }
            }

            this._batchNo = curBatchId;

            return curBatchId;
        }

        /// <summary>
        /// 删除批次次
        /// </summary>
        /// <param name="batchId">批次编号</param>
        /// <returns>操作状态</returns>
        public bool DeleteBatchByBatchId(int batchId)
        {
            StudentPaperResponse spResponse = _dalFactory.ExamInfo_GetAllPaperByCsID(ScanGlobalInfo.ExamInfo.CsID);
            List<string> fileNameList = new List<string>();

            if (!spResponse.Success)
            {
                if (spResponse.Error != null)
                {
                    _dalFactory.System_SaveErrorLog(new Exception(
                        string.Format("错误代码：{0}{1}错误信息：{2}{3}详细信息：{4}{5}", spResponse.Error.Code, Environment.NewLine, spResponse.Error.Message
                        , Environment.NewLine, spResponse.Error.Details))
                        , "获取学生考卷对象名称出错");
                }
                else
                {
                    _dalFactory.System_SaveErrorLog(new Exception("获取学生考卷对象名称出错"), "获取学生考卷对象名称出错");
                }

                return false;
            }
            else if (spResponse.Data != null && spResponse.Data.Count > 0)
            {
                foreach (StudentPaper sp in spResponse.Data)
                {
                    if ((!string.IsNullOrEmpty(sp.BatchNum)) && int.Parse(sp.BatchNum) == batchId)
                    {
                        foreach (StudentPaperPic spp in sp.StudentPaperPicList)
                        {
                            if (!string.IsNullOrEmpty(spp.StuAPPath))
                            {
                                string[] fileNameArray = spp.StuAPPath.Split(',');

                                foreach (string fileName in fileNameArray)
                                {
                                    fileNameList.Add(fileName);
                                }
                            }
                        }
                    }
                }
            }

            if (fileNameList.Count > 0)
            {
                ALiProgressManager.Oss_DeleteFilesByList(fileNameList);
            }

            ApiResponse ar = _dalFactory.ExamInfo_DeletePaperByCsIDAndBatchNum(ScanGlobalInfo.ExamInfo.CsID, batchId);

            if (!ar.Success)
            {
                _dalFactory.System_SaveErrorLog(
                    new Exception(string.Format("删除学生考卷信息时出错,csID:{0},batchNumber:{1}", ScanGlobalInfo.ExamInfo.CsID, batchId))
                    , "删除学生考卷信息时出错");

                return false;
            }
            
            if (fileNameList.Count < 1)
            {
                fileNameList = new List<string>();
                lock (BatchScan.lockDataModifyObj)
                {
                    if (this.normalDic != null && this.incorrectDic != null)
                    {
                        if (this.normalDic.ContainsKey(batchId))
                        {
                            foreach (VolumnDataRow current in this.normalDic[batchId])
                            {
                                if (current.Data.ImagePath.Length > 0)
                                {
                                    foreach (string imagePath in current.Data.ImagePath)
                                    {
                                        fileNameList.Add(imagePath);
                                    }
                                }

                                ScanRecordHelper.Instance.DeleteLocalScanRecord(current.Data.Guid.ToString());
                            }

                            this.normalDic[batchId].Clear();
                            this.normalDic.Remove(batchId);
                        }
                        if (this.incorrectDic.ContainsKey(batchId))
                        {
                            foreach (VolumnDataRow current in this.incorrectDic[batchId])
                            {
                                if (current.Data.ImagePath.Length > 0)
                                {
                                    foreach (string imagePath in current.Data.ImagePath)
                                    {
                                        fileNameList.Add(imagePath);
                                    }
                                }

                                ScanRecordHelper.Instance.DeleteLocalScanRecord(current.Data.Guid.ToString());
                            }

                            this.incorrectDic[batchId].Clear();
                            this.incorrectDic.Remove(batchId);
                        }

                        if (fileNameList.Count > 0)
                        {
                            ALiProgressManager.Oss_DeleteFilesByList(fileNameList);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 更新目标批次数据
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <returns>更新后数据</returns>
        public BatchDataRow UpdateTargetBatchData(int batchId)
        {
            BatchDataRow batchDataRow = new BatchDataRow();

            batchDataRow.BatchIndex = batchId;

            if (this.normalDic != null && this.incorrectDic != null && this.normalDic.ContainsKey(batchId) && this.incorrectDic.ContainsKey(batchId))
            {
                lock (BatchScan.lockDataModifyObj)
                {
                    batchDataRow.BatchTotal = this.normalDic[batchId].Count + this.incorrectDic[batchId].Count;
                    batchDataRow.AbnormalNum = this.incorrectDic[batchId].Count;
                }
            }

            return batchDataRow;
        }

        /// <summary>
        /// 刷新批次列表
        /// </summary>
        public void RefreshBatchList()
        {
            lock (BatchScan.lockDataModifyObj)
            {
                for (int i = 0; i < this._lsBatchList.Count; i++)
                {
                    int batchIndex = this._lsBatchList[i].BatchIndex;

                    if (this.normalDic.ContainsKey(batchIndex))
                    {
                        this._lsBatchList[i].AbnormalNum = this.incorrectDic[batchIndex].Count;
                        this._lsBatchList[i].BatchTotal = this.normalDic[batchIndex].Count + this.incorrectDic[batchIndex].Count;
                    }
                }
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public BatchManagerBLL() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="norDic">标准卷字典</param>
        /// <param name="incorDic">异常卷字典</param>
        /// <param name="lsBatchList">是批次列表</param>
        public BatchManagerBLL(Dictionary<int, List<VolumnDataRow>> norDic, Dictionary<int, List<VolumnDataRow>> incorDic, List<BatchDataRow> lsBatchList)
        {
            this.normalDic = norDic;
            this.incorrectDic = incorDic;
            this._lsBatchList = lsBatchList;
        }
    }
}