using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.OuterInterop;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;
using YXH.Twain.Structure;
using YXH.Twain.Structure.Enum;
using YXH.HttpHelper.Response;

namespace YXH.ScanForm
{
    /// <summary>
    /// 扫描操作窗体
    /// </summary>
    public partial class ScanOperateForm : Form, IMessageFilter
    {
        /// <summary>
        /// 业务处理层的实例
        /// </summary>
        BaseDisposeBLL _bdBll = new BaseDisposeBLL();
        /// <summary>
        /// 翻页委托定义
        /// </summary>
        public delegate void StateChangeHandle(object obj, OperateStatus nextOpStatus);
        /// <summary>
        /// 统计窗体
        /// </summary>
        private StatisticForm _statisForm;
        /// <summary>
        /// 扫描试卷图片窗体
        /// </summary>
        private ScanExamImageForm _scanExamImageFrm;
        /// <summary>
        /// 扫描完成窗体
        /// </summary>
        private ScanFinishForm _scanFinishFrm;
        /// <summary>
        /// 批次列表封装数据源
        /// </summary>
        private BindingSource _bsBatchList;
        /// <summary>
        /// 标准试卷列表封装数据源
        /// </summary>
        private BindingSource _bsNormalList;
        /// <summary>
        /// 异常卷列表封装数据源
        /// </summary>
        private BindingSource _bsAbnormalList;
        /// <summary>
        /// 批次列表
        /// </summary>
        private List<BatchDataRow> _batchList;
        /// <summary>
        /// 标准列表
        /// </summary>
        private List<VolumnDataRow> _normalList;
        /// <summary>
        /// 异常列表
        /// </summary>
        private List<string> _abnormalList;
        /// <summary>
        /// 当前选中批次
        /// </summary>
        private int _curSelectedBatch;
        /// <summary>
        /// 当前选中索引
        /// </summary>
        private int _curSelectedIndex;
        /// <summary>
        /// 当期恢复批次
        /// </summary>
        private int _curRecoBatch;
        /// <summary>
        /// 是在再次恢复扫描
        /// </summary>
        private bool _isInReRecoScan;
        /// <summary>
        /// 正在扫描
        /// </summary>
        private bool _inFactScanning;
        /// <summary>
        /// 在扫描计划内
        /// </summary>
        private bool _isInScanning;
        /// <summary>
        /// 开始扫描仪委托
        /// </summary>
        private FOnTransfer _fonTransfer;
        /// <summary>
        /// 结束扫描仪委托
        /// </summary>
        private FOnEndTransfer _fonEndTransfer;
        /// <summary>
        /// 扫描仪句柄
        /// </summary>
        private IntPtr _scanner;
        /// <summary>
        /// 模板信息
        /// </summary>
        private TemplateInfo _templateInfo;
        /// <summary>
        /// 批次编号
        /// </summary>
        private int _batchNo;
        /// <summary>
        /// 批次索引
        /// </summary>
        private int _batchIndex;
        /// <summary>
        /// 页数
        /// </summary>
        private int _pageCount = 1;
        /// <summary>
        /// 学生考试信息
        /// </summary>
        private IList<StudentExamInfo> _studentExamInfoList;
        /// <summary>
        /// 标准试卷字典
        /// </summary>
        private Dictionary<int, List<VolumnDataRow>> _normalDic;
        /// <summary>
        /// 异常试卷字典
        /// </summary>
        private Dictionary<int, List<VolumnDataRow>> _incorrectDic;
        /// <summary>
        /// 当前图片列表
        /// </summary>
        private IList<string> _currentImages = new List<string>();
        /// <summary>
        /// 当前点击状态
        /// </summary>
        private ScanOperateForm.ScanPanelClickStatus _curClickStatus;
        /// <summary>
        /// 上传答题卡线程
        /// </summary>
        private Thread _uploadScanrecordTrd;
        /// <summary>
        /// 上传计时器
        /// </summary>
        private System.Timers.Timer _upLoadTicker;
        /// <summary>
        /// 码表
        /// </summary>
        private Stopwatch _stopwatch = new Stopwatch();
        /// <summary>
        /// 是第一个批次的试卷
        /// </summary>
        private bool _isFirstPaperInBatch = true;
        /// <summary>
        /// 是加载本地zip/xml
        /// </summary>
        private bool _hasloadLocalZipxml;
        /// <summary>
        /// 当前标准点击索引
        /// </summary>
        private int _curNormalClickIndex = -1;
        /// <summary>
        /// 实际扫描句柄图片队列
        /// </summary>
        private Queue _factScanIntPtrImgQueue = new Queue();
        /// <summary>
        /// 实际上传图片列表
        /// </summary>
        private List<IntPtr> _factScanImgList = new List<IntPtr>();
        /// <summary>
        /// 原页面索引
        /// </summary>
        private int _rotatePageIndex = 1;
        /// <summary>
        /// 是第一次扫描
        /// </summary>
        private bool _isFirstScan = true;
        /// <summary>
        /// 是测试扫描
        /// </summary>
        private bool _isTestScan;
        /// <summary>
        /// 是关于测试扫描ID
        /// </summary>
        private bool _isAbortTestScanTrd;
        /// <summary>
        /// 测试扫描文件队列
        /// </summary>
        private Queue _testScanFile;
        /// <summary>
        /// 测试线程
        /// </summary>
        private Thread _testTrd;
        /// <summary>
        /// 测试文件集合
        /// </summary>
        private List<string> _testFileArry = new List<string>();
        /// <summary>
        /// 操作状态改变事件定义
        /// </summary>
        public event ScanOperateForm.StateChangeHandle _opStateChange;
        /// <summary>
        /// 扫描开始时间戳
        /// </summary>
        DateTime _testDateClos = DateTime.Now;
        /// <summary>
        /// 返回科目设置窗体
        /// </summary>
        public delegate void BackSubjectForm(object obj, OperateStatus status);
        /// <summary>
        /// 返回上一窗体事件定义
        /// </summary>
        public event BackSubjectForm _backLastStep;

        /// <summary>
        /// 扫描面板点击状态
        /// </summary>
        protected enum ScanPanelClickStatus
        {
            ScanPaper,
            CheckStatis,
            CheckAbnormalPaper,
            CheckNormalPaper,
            ScanFinish
        }

        /// <summary>
        /// 计划类
        /// </summary>
        private static class Scheme
        {
            /// <summary>
            /// 标题高度
            /// </summary>
            public const int TitleHeight = 40;
            /// <summary>
            /// 项高度
            /// </summary>
            public const int ItemHeight = 58;
            /// <summary>
            /// 帮助内容高度
            /// </summary>
            public const int HelpHeight = 40;
            /// <summary>
            /// 统一的背景色
            /// </summary>
            public static Color UnifiedBackColor = Color.FromArgb(255, 252, 252, 252);
            /// <summary>
            /// 列表标题背景色
            /// </summary>
            public static Color ListTtileBackColor = Color.FromArgb(255, 241, 241, 241);
            /// <summary>
            /// 按钮未选中颜色
            /// </summary>
            public static Color ButtonUnselectedColor = Color.FromArgb(255, 0, 0, 0);
            /// <summary>
            /// 按钮选中颜色
            /// </summary>
            public static Color ButtonSelectedColor = Color.DeepSkyBlue;
            /// <summary>
            /// 按钮不可用颜色
            /// </summary>
            public static Color ButtonUnEnable = Color.FromArgb(255, 241, 241, 241);
            /// <summary>
            /// 工具条颜色
            /// </summary>
            public static Color ToolBackColor = Color.FromArgb(255, 255, 251, 242);
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public ScanOperateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 提前过滤消息
        /// </summary>
        /// <param name="m">消息主体</param>
        /// <returns>过滤状态</returns>
        public bool PreFilterMessage(ref Message m)
        {
            return this._inFactScanning && Twain_32.ProcessMessage(ref m);
        }

        /// <summary>
        /// 下一页按钮点事件
        /// </summary>
        private void btn_NextPage_Click(object sender, EventArgs e)
        {
            this._scanExamImageFrm.PicOperate(3);
        }

        /// <summary>
        /// 缩小按钮点击事件
        /// </summary>
        private void btn_ZoomOut_Click(object sender, EventArgs e)
        {
            this._scanExamImageFrm.PicOperate(0);
        }

        /// <summary>
        /// 最后一页按钮点击事件
        /// </summary>
        private void btn_LastPage_Click(object sender, EventArgs e)
        {
            this._scanExamImageFrm.PicOperate(2);
        }

        /// <summary>
        /// 放大按钮点击事件
        /// </summary>
        private void btn_ZoomIn_Click(object sender, EventArgs e)
        {
            this._scanExamImageFrm.PicOperate(1);
        }

        /// <summary>
        /// 扫描设置按钮点击事件
        /// </summary>
        private void btn_scanerSetting_Click(object sender, EventArgs e)
        {
            ScannerSettingForm.Instance.Show();

            ScannerSettingForm.Instance.TopMost = true;
        }

        /// <summary>
        /// 比较文件项
        /// </summary>
        /// <param name="file1">源文件</param>
        /// <param name="file2">目标文件</param>
        /// <returns>比较结果</returns>
        public int CompareFileItem(string file1, string file2)
        {
            int num = 0,
                num2 = 0;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file1),
                fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(file2);

            if (int.TryParse(fileNameWithoutExtension, out num) && int.TryParse(fileNameWithoutExtension2, out num2))
            {
                return num - num2;
            }
            if (num != 0)
            {
                return 1;
            }
            if (num2 != 0)
            {
                return -1;
            }

            return fileNameWithoutExtension.CompareTo(fileNameWithoutExtension2);
        }

        /// <summary>
        /// 根据批次ID从批次列表中获取索引
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <returns>索引值</returns>
        private int GetIndexInBactchListByBatchId(int batchId)
        {
            for (int i = 0; i < this._bsBatchList.Count; i++)
            {
                BatchDataRow batchDataRow = (BatchDataRow)this._bsBatchList[i];

                if (batchDataRow.BatchIndex == batchId)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 刷新标准试卷列表
        /// </summary>
        /// <param name="batchId">批次编号</param>
        /// <param name="curWorkingList">当前工作集试卷列表</param>
        private void refreshNormalList(int batchId, List<VolumnDataRow> curWorkingList)
        {
            if (this._bsNormalList != null && batchId != this._batchNo)
            {
                this._bsNormalList = null;
            }

            this.list_NormalPaper.BeginUpdate();

            if (curWorkingList == null)
            {
                if (this._normalDic != null && this._normalDic.ContainsKey(batchId))
                {
                    this._bsNormalList = new BindingSource(this._normalDic[batchId], null);
                    this.list_NormalPaper.DataSource = this._bsNormalList;
                }
                else
                {
                    this.list_NormalPaper.DataSource = null;
                }
            }
            else if (batchId != this._batchNo)
            {
                this._bsNormalList = new BindingSource(curWorkingList, null);
                this.list_NormalPaper.DataSource = this._bsNormalList;
            }

            this.list_NormalPaper.EndUpdate();
        }

        /// <summary>
        /// 刷新编号到异常列表
        /// </summary>
        /// <param name="batchId">批次编号</param>
        private void refreshNumOfAbnormalList(int batchId)
        {
            if (batchId == -1 || !this._incorrectDic.ContainsKey(batchId) || this._incorrectDic[batchId].Count == 0)
            {
                this._bsAbnormalList[0] = string.Format("试卷信息异常{0,15}份", 0);
                this._bsAbnormalList[1] = string.Format("考号信息异常{0,15}份", 0);
                this._bsAbnormalList[2] = string.Format("客观题信息异常{0,13}份", 0);

                return;
            }
            try
            {
                ErrorPageManangerBLL.IncorrectDic = this._incorrectDic;
                ErrorPageManangerBLL.NormalDic = this._normalDic;
                ErrorPageManangerBLL.BatchNo = batchId;
                this._bsAbnormalList[0] = string.Format("试卷信息异常{0,15}份", (ErrorPageManangerBLL.PagerErrorList == null) ? 0 : ErrorPageManangerBLL.PagerErrorList.Count);
                this._bsAbnormalList[1] = string.Format("考号信息异常{0,15}份", (ErrorPageManangerBLL.StudentInfoErrorList == null) ? 0 : ErrorPageManangerBLL.StudentInfoErrorList.Count);
                this._bsAbnormalList[2] = string.Format("客观题信息异常{0,13}份", (ErrorPageManangerBLL.OmrErrorList == null) ? 0 : ErrorPageManangerBLL.OmrErrorList.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("刷新异常卷列表出错");
                LogHelper.WriteFatalLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 列表批次是退出选中
        /// </summary>
        /// <param name="index">索引</param>
        private void list_batchHasBeenSelected(int index)
        {
            if (this._isInReRecoScan)
            {
                MessageBox.Show("正在重新识别该批次中，请稍后查看其它批次！");

                return;
            }
            if (index > -1)
            {
                this.lbBatch.SelectedIndex = index;
                BatchDataRow batchDataRow = (BatchDataRow)this.lbBatch.Items[index];
                this._curSelectedBatch = batchDataRow.BatchIndex;
                this._curSelectedIndex = index;

                this.refreshNormalList(this._curSelectedBatch, null);
                this.refreshNumOfAbnormalList(this._curSelectedBatch);
                this.list_NormalPaper.ClearSelected();

                this._curNormalClickIndex = -1;

                this.list_Abnormal.ClearSelected();
                this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);
            }
        }

        /// <summary>
        /// 发布图片列表
        /// </summary>
        private void ReleaseListImage()
        {
            if (this._factScanImgList != null && this._factScanImgList.Count > 0)
            {
                for (int i = 0; i < this._factScanImgList.Count; i++)
                {
                    BatchScan.ReleaseImage(this._factScanImgList[i]);

                    this._factScanImgList[i] = IntPtr.Zero;
                }

                this._factScanImgList.Clear();
            }
        }

        /// <summary>
        /// 设置数字标签值
        /// </summary>
        /// <param name="num">数字</param>
        /// <param name="total">总数</param>
        private void SetNumLabelValue(int num, int total)
        {
            this.lbl_Num.Text = string.Format("{0}/{1}", num, total);
        }

        /// <summary>
        /// 设置置顶状态
        /// </summary>
        /// <param name="type">状态值</param>
        private void SetTopStatus(int type)
        {
            switch (type)
            {
                case 0:
                    this.panScanStatusInfo.Visible = true;
                    this.lbl_CurWork.Text = "正在初始化中...";
                    this.lbl_Status.Text = "";
                    this.progress_Scan.Visible = true;
                    this.btn_LeakCheck.Visible = false;
                    this.btn_BackToScanning.Visible = false;

                    return;
                case 1:
                    if (this._isInScanning)
                    {
                        this.panScanStatusInfo.Visible = true;
                        this.progress_Scan.Visible = true;
                        this.btn_BackToScanning.Visible = false;
                        this.btn_LeakCheck.Visible = false;
                        this.panScanStatusInfo.BackColor = Color.White;

                        return;
                    }

                    this.SetTopStatus(7);

                    if (ScanGlobalInfo.ExamInfo.ScanRecordList != null && ScanGlobalInfo.ExamInfo.StudentExamInfoList != null)
                    {
                        this.SetNumLabelValue(ScanGlobalInfo.ExamInfo.ScanRecordList.Count, ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count);

                        return;
                    }

                    break;
                case 2:
                    this.panScanStatusInfo.Visible = true;

                    if (this._isInScanning)
                    {
                        this.progress_Scan.Visible = true;
                        this.btn_BackToScanning.Visible = true;
                        this.btn_LeakCheck.Visible = false;
                        this.panScanStatusInfo.BackColor = ScanOperateForm.Scheme.ToolBackColor;

                        return;
                    }

                    this.SetTopStatus(7);

                    return;
                case 3:
                    if (this._isInScanning)
                    {
                        this.panScanStatusInfo.Visible = true;
                        this.progress_Scan.Visible = true;
                        this.btn_BackToScanning.Visible = true;
                        this.btn_LeakCheck.Visible = false;
                        this.panScanStatusInfo.BackColor = ScanOperateForm.Scheme.ToolBackColor;

                        return;
                    }

                    this.SetTopStatus(7);

                    return;
                case 4:
                    this.panScanStatusInfo.Visible = true;
                    this.lbl_CurWork.Text = "正在上传原图中...";
                    this.lbl_Status.Text = "状态：正常";
                    this.progress_Scan.Visible = true;
                    this.btn_BackToScanning.Visible = false;
                    this.panScanStatusInfo.BackColor = Color.White;

                    return;
                case 5:
                    this.panScanStatusInfo.Visible = true;
                    this.lbl_CurWork.Text = "正在结束考试中...";
                    this.lbl_Status.Text = "状态：正常";
                    this.progress_Scan.Visible = true;
                    this.btn_BackToScanning.Visible = false;
                    this.panScanStatusInfo.BackColor = Color.White;

                    return;
                case 6:
                    this.panScanStatusInfo.Visible = true;
                    this.progress_Scan.Visible = true;
                    this.btn_BackToScanning.Visible = false;
                    this.lbl_CurWork.Text = "正在重新识别中...请耐性等待，退出程序或返回科目列表将会导致数据丢失";
                    this.lbl_Status.Text = "状态：正常";
                    this.panScanStatusInfo.BackColor = Color.White;

                    return;
                case 7:
                    if (ScanGlobalInfo.ExamInfo.ScanRecordList.Count == 0)
                    {
                        this.panScanStatusInfo.Visible = false;

                        return;
                    }
                    if (ScanGlobalInfo.ExamInfo.ScanRecordList.Count == ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count)
                    {
                        this.panScanStatusInfo.Visible = true;
                        this.lbl_CurWork.Text = "扫描已完成,处理完异常卷后，点击“完成扫描”进入结束考试页面";
                        this.lbl_Status.Text = "状态：完成";
                        this.progress_Scan.Visible = false;
                        this.btn_BackToScanning.Visible = false;
                        this.btn_LeakCheck.Visible = false;
                        this.panScanStatusInfo.BackColor = Color.White;

                        return;
                    }

                    this.panScanStatusInfo.Visible = true;
                    this.lbl_CurWork.Text = "当前批次已完成扫描,可通过“继续扫描”或“扫描设置”扫描新的批次";
                    this.lbl_Status.Text = "状态：暂停";
                    this.progress_Scan.Visible = false;
                    this.btn_BackToScanning.Visible = false;
                    this.btn_LeakCheck.Visible = true;
                    this.panScanStatusInfo.BackColor = Color.White;

                    return;
                default:
                    if (type != 99)
                    {
                        return;
                    }

                    this.panScanStatusInfo.Visible = true;
                    this.lbl_CurWork.Text = "扫描已完成";
                    this.lbl_Status.Text = "状态：完成";
                    this.progress_Scan.Visible = false;
                    this.btn_BackToScanning.Visible = false;
                    this.panScanStatusInfo.BackColor = Color.White;

                    break;
            }
        }

        /// <summary>
        /// 初始化开始扫描
        /// </summary>
        private void InitialBeginScan()
        {
            this._batchNo = BatchManagerBLL.Instance.prepareNextBatch(this._batchNo);

            ScanGlobalInfo.ExamInfo.IsScanFinish = false;

            this._isFirstScan = false;
            this._batchIndex = 0;
            this._rotatePageIndex = 1;

            if (this._bsBatchList == null)
            {
                this._bsBatchList = new BindingSource(this._batchList, null);
            }

            int num = this.GetIndexInBactchListByBatchId(this._batchNo);

            if (num == -1)
            {
                this._bsBatchList.Add(new BatchDataRow(this._batchNo, this._batchIndex, this._incorrectDic[this._batchNo].Count));

                num = this._bsBatchList.Count - 1;
            }
            if (num < this._bsBatchList.Count)
            {
                this.lbBatch.SelectedIndex = num;

                this.list_batchHasBeenSelected(num);
            }
            if (ScanGlobalInfo.ExamInfo.StudentExamInfoList != null)
            {
                this.progress_Scan.Visible = true;
                this.progress_Scan.Maximum = ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count;
                this.progress_Scan.Step = 1;

                if (ScanGlobalInfo.ExamInfo.ScanRecordList.Count < this.progress_Scan.Maximum)
                {
                    this.progress_Scan.Value = ScanGlobalInfo.ExamInfo.ScanRecordList.Count;
                }
            }

            this.btnContinueScan.Visible = false;
            this.btnScanFinish.Visible = false;
            ScanGlobalInfo.ExamInfo.IsScanFinish = false;
            this.btnFinish.Enabled = false;
            this._isFirstPaperInBatch = true;
            this._isInReRecoScan = false;
            this._isInScanning = true;

            BatchScan.PrepareToLoadNext(this._scanner);
            this.ReleaseListImage();
            this._currentImages.Clear();
            this.SetTopStatus(1);
        }

        /// <summary>
        /// 刷新批次列表
        /// </summary>
        /// <param name="batchId">批次编号</param>
        private void refreshBatchList(int batchId)
        {
            if (this._bsBatchList != null)
            {
                this.lbBatch.BeginUpdate();

                for (int i = 0; i < this._bsBatchList.Count; i++)
                {
                    BatchDataRow batchDataRow = (BatchDataRow)this._bsBatchList[i];

                    if (batchId == batchDataRow.BatchIndex)
                    {
                        this._bsBatchList[i] = BatchManagerBLL.Instance.UpdateTargetBatchData(batchId);
                    }
                }

                this.lbBatch.EndUpdate();

                if (this._curSelectedIndex < this._bsBatchList.Count)
                {
                    this.lbBatch.SelectedIndex = this._curSelectedIndex;
                }
            }
        }

        /// <summary>
        /// 标准试卷列表退出选中
        /// </summary>
        /// <param name="index">列表索引</param>
        /// <param name="ShowOmrResult">显示识别结果</param>
        private void List_NormalPaperHasBeenSelected(int index, bool ShowOmrResult = false)
        {
            if (index > -1)
            {
                try
                {
                    VolumnDataRow curVolumnRow = (VolumnDataRow)this.list_NormalPaper.Items[index];

                    this._scanExamImageFrm.SetCurVolumnRow(curVolumnRow);

                    this._scanExamImageFrm.ShowCorrectOMRResult = ShowOmrResult;

                    this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Normal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// 刷新所有正在扫描
        /// </summary>
        private void refreshAllWhenScanning()
        {
            if (this._curSelectedIndex < this._bsBatchList.Count)
            {
                this.lbBatch.SelectedIndex = this._curSelectedIndex;
            }
            if (this._isInReRecoScan)
            {
                if (this._curSelectedBatch == this._curRecoBatch)
                {
                    this.refreshNumOfAbnormalList(this._curSelectedBatch);
                    this.refreshNormalList(this._curSelectedBatch, null);
                }
            }
            else
            {
                this.lbl_CurWork.Text = "正在扫描中...";
                this.lbl_Status.Text = "状态：正常";

                if (this._curSelectedBatch == this._batchNo)
                {
                    this.refreshNumOfAbnormalList(this._curSelectedBatch);
                    this.refreshNormalList(this._curSelectedBatch, null);
                }
            }
            if (this._curClickStatus == ScanOperateForm.ScanPanelClickStatus.ScanPaper && this._curSelectedBatch == this._batchNo)
            {
                this.list_NormalPaper.SelectedIndex = this.list_NormalPaper.Items.Count - 1;

                this.List_NormalPaperHasBeenSelected(this.list_NormalPaper.SelectedIndex, false);
            }
            else if (this._curClickStatus == ScanOperateForm.ScanPanelClickStatus.CheckNormalPaper)
            {
                this.list_NormalPaper.SelectedIndex = this._curNormalClickIndex;
            }
            if (this.progress_Scan.Value + this.progress_Scan.Step <= this.progress_Scan.Maximum)
            {
                this.progress_Scan.Value += this.progress_Scan.Step;
            }
            if (this._isInReRecoScan || this._isTestScan)
            {
                this.SetNumLabelValue(this.progress_Scan.Value, this.progress_Scan.Maximum);

                return;
            }
            if (this._inFactScanning && ScanGlobalInfo.ExamInfo.ScanRecordList != null)
            {
                this.SetNumLabelValue(ScanGlobalInfo.ExamInfo.ScanRecordList.Count, this.progress_Scan.Maximum);
            }
        }

        /// <summary>
        /// 处理测试扫描
        /// </summary>
        /// <param name="imgefilename">图片文件名</param>
        private void ProcessTestScan(string imgefilename)
        {
            this._isInScanning = true;

            this._currentImages.Add(Path.GetFileName(imgefilename));

            if (this._currentImages.Count < this._pageCount)
            {
                if (!ScanlibInterop.LoadSourceImageByPath(this._scanner, imgefilename, this._currentImages.Count - 1))
                {
                    LogHelper.WriteFatalLog(imgefilename + ",加载卷失败");

                    return;
                }
            }
            else
            {
                this._batchIndex++;

                bool flag = ScanlibInterop.LoadSourceImageByPath(this._scanner, imgefilename, this._currentImages.Count - 1);

                if (!flag)
                {
                    LogHelper.WriteFatalLog(imgefilename + ",加载卷失败");
                }
                if (this._isInReRecoScan)
                {
                    BatchScan.ScanOneExamPaper(this._templateInfo, this._scanner, this._curRecoBatch, this._currentImages, this._studentExamInfoList, this._normalDic, this._incorrectDic, flag, this._batchIndex);
                }
                else
                {
                    BatchScan.ScanOneExamPaper(this._templateInfo, this._scanner, this._batchNo, this._currentImages, this._studentExamInfoList, this._normalDic, this._incorrectDic, flag, this._batchIndex);
                }

                BatchScan.PrepareToLoadNext(this._scanner);
                this._currentImages.Clear();

                if (base.InvokeRequired)
                {
                    base.Invoke(new MethodInvoker(delegate
                    {
                        try
                        {
                            if (this._isInReRecoScan)
                            {
                                this.refreshBatchList(this._curRecoBatch);
                            }
                            else if (this._isTestScan)
                            {
                                this.refreshBatchList(this._batchNo);
                            }
                            this.refreshAllWhenScanning();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteFatalLog(ex.Message, ex);
                        }
                    }));
                }
            }
        }

        /// <summary>
        /// 刷新完成批次列表
        /// </summary>
        private void refreshTheWholeBatchList()
        {
            try
            {
                if (this._bsBatchList != null)
                {
                    this._bsBatchList = null;

                    BatchManagerBLL.Instance.RefreshBatchList();

                    this._bsBatchList = new BindingSource(this._batchList, null);
                    this.lbBatch.DataSource = this._bsBatchList;

                    if (this._curSelectedIndex < this._bsBatchList.Count)
                    {
                        this.lbBatch.SelectedIndex = this._curSelectedIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 上传保存的扫描xml数据文件
        /// </summary>
        /// <returns>保存操作是否成功</returns>
        private bool UploadExamXmlData()
        {
            if (!string.IsNullOrEmpty(PathHelper.LocalScanrecordXmlPath))
            {
                if (File.Exists(PathHelper.LocalSaveScanrecordXmlPath))
                {
                    File.Delete(PathHelper.LocalSaveScanrecordXmlPath);
                }

                new FileInfo(PathHelper.LocalScanrecordXmlPath).CopyTo(PathHelper.LocalSaveScanrecordXmlPath);
                // ALiProgressManager.Oss_PutObject(PathHelper.LocalSaveScanrecordXmlPath, PathHelper.LocalSaveScanrecordXmlFileName);
                new FileInfo(PathHelper.LocalSaveScanrecordXmlPath).Delete();
            }
            if (!string.IsNullOrEmpty(PathHelper.ScanStatisticsPath))
            {
                if (File.Exists(PathHelper.ScanSaveStatisticsPath))
                {
                    File.Delete(PathHelper.ScanSaveStatisticsPath);
                }

                new FileInfo(PathHelper.ScanStatisticsPath).CopyTo(PathHelper.ScanSaveStatisticsPath);
                //   ALiProgressManager.Oss_PutObject(PathHelper.ScanSaveStatisticsPath, PathHelper.ScanSaveStatisticsXmlFileName);
                new FileInfo(PathHelper.ScanSaveStatisticsPath).Delete();
            }
            if (!string.IsNullOrEmpty(PathHelper.NormalExamXmlPath))
            {
                if (File.Exists(PathHelper.NormalSaveExamXmlPath))
                {
                    File.Delete(PathHelper.NormalSaveExamXmlPath);
                }

                new FileInfo(PathHelper.NormalExamXmlPath).CopyTo(PathHelper.NormalSaveExamXmlPath);
                //    ALiProgressManager.Oss_PutObject(PathHelper.NormalSaveExamXmlPath, PathHelper.NormalSaveExamXmlFileName);
                new FileInfo(PathHelper.NormalSaveExamXmlPath).Delete();
            }
            if (!string.IsNullOrEmpty(PathHelper.IncorrectExamXmlPath))
            {
                if (File.Exists(PathHelper.IncorrectSaveExamXmlPath))
                {
                    File.Delete(PathHelper.IncorrectSaveExamXmlPath);
                }

                new FileInfo(PathHelper.IncorrectExamXmlPath).CopyTo(PathHelper.IncorrectSaveExamXmlPath);
                //    ALiProgressManager.Oss_PutObject(PathHelper.IncorrectSaveExamXmlPath, PathHelper.IncorrectSaveExamXmlFileName);
                new FileInfo(PathHelper.IncorrectSaveExamXmlPath).Delete();
            }

            return true;
        }

        /// <summary>
        /// 保存所有记录到xml文件
        /// </summary>
        private void SaveAllRecordToXML()
        {
            FileHelper.SerializeToXml<Dictionary<int, List<VolumnDataRow>>>(this._normalDic, PathHelper.NormalExamXmlPath);
            FileHelper.SerializeToXml<Dictionary<int, List<VolumnDataRow>>>(this._incorrectDic, PathHelper.IncorrectExamXmlPath);
            ScanRecordHelper.Instance.SaveScanrecordToXml();

            UploadExamXmlData();
        }

        /// <summary>
        /// 运行上传扫描记录
        /// </summary>
        private void RunUploadScanRecord()
        {
            this._uploadScanrecordTrd = new Thread(new ThreadStart(delegate
            {
                string remoteScanrecordZipPath = PathHelper.RemoteScanrecordZipPath;
                List<string> list = new List<string>();

                list.Add(PathHelper.IncorrectExamXmlPath);
                list.Add(PathHelper.NormalExamXmlPath);
                list.Add(PathHelper.LocalScanrecordXmlPath);

                ApiResponse baseResult = new ApiResponse();

                if (!baseResult.Success) { }
            }));

            this._uploadScanrecordTrd.Start();
        }

        /// <summary>
        /// 结束扫描
        /// </summary>
        private void OnEndScan()
        {
            this.SetTopStatus(7);

            if (!this._isInReRecoScan)
            {
                int num = this._normalDic[this._batchNo].Count + this._incorrectDic[this._batchNo].Count;

                ScanStatisticsBLL.SetScanStatistics(num, this._stopwatch.Elapsed);
                ScanGlobalInfo.ScannedCountInDays += num;
                ScanInfoInDaysBLL.SetScannedCountInDays();
            }

            this._isInScanning = false;
            this.btnScanFinish.Visible = true;
            this.btnContinueScan.Visible = true;

            this._scanExamImageFrm.RefreshLeakGrid();
            this.refreshTheWholeBatchList();

            if (this._curSelectedIndex >= this._bsBatchList.Count)
            {
                this._curSelectedIndex = this._bsBatchList.Count - 1;
            }

            this.lbBatch.SelectedIndex = this._curSelectedIndex;

            if (this._isInReRecoScan && this._testScanFile.Count > 0)
            {
                return;
            }

            this.SaveAllRecordToXML();
            this.RunUploadScanRecord();

            if (!this._isInReRecoScan)
            {
                ErrorPageManangerBLL.IncorrectDic = this._incorrectDic;
                ErrorPageManangerBLL.NormalDic = this._normalDic;
                ErrorPageManangerBLL.BatchNo = this._batchNo;
                double num2 = ErrorPageManangerBLL.CheckDoubtfulRate(this._batchNo);

                if (num2 > 0.15)
                {
                    string text = string.Format("温馨提示：当前批次有{0}%的学生试卷客观题被识别为可疑项。\n", (int)(num2 * 100.0));
                    text += "该情况可能由于如下两种原因造成：\n1.学生的填涂不清晰。\n2.扫描仪高级设置中的“亮度”值（或“阈值”，不同扫描仪不一样）需要调整\n";

                    MessageBox.Show(text, "客观题识别异常提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 开始测试扫描
        /// </summary>
        private void StartTestScan()
        {
            if (this._testScanFile != null && this._testScanFile.Count > 0)
            {
                this.progress_Scan.Maximum = this._testScanFile.Count / this._pageCount;
                this.progress_Scan.Step = 1;
                this.progress_Scan.Value = 0;
            }

            this._isAbortTestScanTrd = false;
            this._testTrd = new Thread(new ThreadStart(delegate
            {
                Stopwatch sw = new Stopwatch();

                sw.Start();

                try
                {
                    int curProcessCount = 0;

                    while (this._testScanFile.Count > 0 && !this._isAbortTestScanTrd)
                    {
                        string imgefilename = this._testScanFile.Dequeue() as string;

                        this.ProcessTestScan(imgefilename);

                        curProcessCount++;

                        _bdBll.System_SaveDebugLog(string.Format("已扫描{0}张图片{1},当前图片用时{1}", curProcessCount, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss:fff"), sw.ElapsedTicks.ToString()));
                    }

                    ///当前批次识别完成,上传结果
                }
                finally
                {
                    if (base.InvokeRequired)
                    {
                        base.Invoke(new MethodInvoker(delegate
                        {
                            this.OnEndScan();

                            this.progress_Scan.Value = this.progress_Scan.Maximum;

                            if (this._isTestScan)
                            {
                                sw.Stop();

                                this.refreshNumOfAbnormalList(this._curSelectedBatch);
                                this.refreshNormalList(this._curSelectedBatch, null);

                                this._isTestScan = false;
                                this.btn_ScanTest.Text = "选图识别";
                                this._isAbortTestScanTrd = true;

                                this._testScanFile.Clear();
                                MessageBox.Show("选图识别结束,耗时: " + sw.Elapsed.TotalSeconds + " 秒");
                            }
                            if (this._isInReRecoScan)
                            {
                                this.refreshNumOfAbnormalList(this._curSelectedBatch);
                                this.refreshNormalList(this._curSelectedBatch, null);

                                this._isInReRecoScan = false;

                                this._testScanFile.Clear();
                                MessageBox.Show("重新识别已完成！");
                            }

                            this.btn_ScanTest.Enabled = true;
                        }));
                    }
                }
            }));

            ScanGlobalInfo.ScanMachineModel = "Choose Files To Scan";

            this._testTrd.Start();
        }

        /// <summary>
        /// 选图识别按钮点击事件
        /// </summary>
        private void btn_ScanTest_Click(object sender, EventArgs e)
        {
            if (!this._isTestScan)
            {
                this.progress_Scan.Value = 0;

                if (this._testScanFile == null || this._testScanFile.Count == 0)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();

                    openFileDialog.Multiselect = true;
                    openFileDialog.InitialDirectory = PathHelper.LocalVolumneImgDir;
                    openFileDialog.Title = "请选择文件";
                    openFileDialog.Filter = "图像文件(*.png)|*.png";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this._testFileArry.Clear();
                        this._testFileArry.AddRange(openFileDialog.FileNames);
                        this._testFileArry.Sort(new Comparison<string>(this.CompareFileItem));

                        this._testScanFile = new Queue();

                        if (this._testFileArry.Count <= 0)
                        {
                            MessageBox.Show("不存在扫描文件", "提示");

                            return;
                        }
                        if (this._testFileArry.Count % this._templateInfo.pages.Length != 0)
                        {
                            MessageBox.Show(string.Format("所选的图片数量{0}不是模板图张数{1}的倍数，请重新选图！", this._testFileArry.Count, this._templateInfo.pages.Length), "提示");

                            return;
                        }

                        for (int i = 0; i < this._testFileArry.Count; i++)
                        {
                            this._testScanFile.Enqueue(this._testFileArry[i]);
                        }

                        this.InitialBeginScan();

                        this._isTestScan = true;
                        this.btn_ScanTest.Text = "停止识别";
                        this.lbl_CurWork.Text = "正在选图识别中...";
                        this.lbl_Status.Text = "状态：正常";
                        this.panScanStatusInfo.Visible = true;

                        this.StartTestScan();

                        return;
                    }
                }
            }
            else
            {
                this.btn_ScanTest.Text = "选图识别";
                this._isAbortTestScanTrd = true;
            }
        }

        /// <summary>
        /// 置为客观题异常菜单点击事件
        /// </summary>
        private void cms_SetAsOmrError_Click(object sender, EventArgs e)
        {
            if (this.list_NormalPaper.SelectedItems.Count > 0 && MessageBox.Show("是否确认将当前试卷设置为客观题异常？", "重置为异常卷", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                VolumnDataRow volumnDataRow = (VolumnDataRow)this.list_NormalPaper.Items[this.list_NormalPaper.SelectedIndex];

                volumnDataRow.ErrorStatusList.Add(ErrorStatus.ObjectiveOmrError);
                volumnDataRow.Data.Status.Clear();
                volumnDataRow.Data.Status.Add(VolumeStatus.ErrOmr);

                if (this._normalDic.ContainsKey(this._curSelectedBatch))
                {
                    this._normalDic[this._curSelectedBatch].Remove(volumnDataRow);
                    this._incorrectDic[this._curSelectedBatch].Add(volumnDataRow);
                }

                this.refreshBatchList(this._curSelectedBatch);
                this.refreshNormalList(this._curSelectedBatch, null);
                this.refreshNumOfAbnormalList(this._curSelectedBatch);
                this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);
                ScanRecordHelper.Instance.UpdateScanRecord(volumnDataRow.Data);
            }
        }

        /// <summary>
        /// 置为考号异常菜单点击事件
        /// </summary>
        private void cms_setAsZkzhError_Click(object sender, EventArgs e)
        {
            if (this.list_NormalPaper.SelectedItems.Count > 0 && MessageBox.Show("是否确认将当前试卷设置为考号异常？", "重置为异常卷", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                VolumnDataRow volumnDataRow = (VolumnDataRow)this.list_NormalPaper.Items[this.list_NormalPaper.SelectedIndex];

                volumnDataRow.ErrorStatusList.Add(ErrorStatus.StudentInfoError);
                volumnDataRow.Data.Status.Clear();
                volumnDataRow.Data.Status.Add(VolumeStatus.ErrZkzh);

                volumnDataRow.Data.Userid = 0;

                if (this._normalDic.ContainsKey(this._curSelectedBatch))
                {
                    this._normalDic[this._curSelectedBatch].Remove(volumnDataRow);
                    this._incorrectDic[this._curSelectedBatch].Add(volumnDataRow);
                }

                this.refreshBatchList(this._curSelectedBatch);
                this.refreshNormalList(this._curSelectedBatch, null);
                this.refreshNumOfAbnormalList(this._curSelectedBatch);
                this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);
                ScanRecordHelper.Instance.UpdateScanRecord(volumnDataRow.Data);
            }
        }

        /// <summary>
        /// 设置所有选项卡按钮到默认状态
        /// </summary>
        /// <param name="curBtn">当前按钮</param>
        private void SetAllTabButtonToDefault(Button curBtn)
        {
            this.btnScan.ForeColor = ScanOperateForm.Scheme.ButtonUnselectedColor;
            this.btnStats.ForeColor = ScanOperateForm.Scheme.ButtonUnselectedColor;

            if (ScanGlobalInfo.ExamInfo.IsScanFinish)
            {
                this.btnFinish.BackColor = this.panelTool.BackColor;
                this.btnFinish.ForeColor = ScanOperateForm.Scheme.ButtonUnselectedColor;
            }
            else
            {
                this.btnFinish.Enabled = false;
                this.btnFinish.BackColor = Color.WhiteSmoke;
                this.btnFinish.ForeColor = ScanOperateForm.Scheme.ButtonUnEnable;
            }

            curBtn.ForeColor = ScanOperateForm.Scheme.ButtonSelectedColor;
        }

        /// <summary>
        /// 显示目标窗体
        /// </summary>
        /// <param name="targetCrl">目标控件</param>
        /// <param name="target">目标窗体</param>
        private void ShowTargetForm(Control targetCrl, Form target)
        {
            if (targetCrl != null && target != null)
            {
                targetCrl.Controls.Clear();
                targetCrl.Controls.Add(target);
            }
            if (target != null)
            {
                target.Show();
            }
        }

        /// <summary>
        /// 前进到下一状态
        /// </summary>
        /// <param name="nextStatus">下一状态</param>
        private void GotoNextState(OperateStatus nextStatus)
        {
            if (this._opStateChange != null)
            {
                if (nextStatus == OperateStatus.ScanFinish)
                {
                    this._opStateChange(OperateStatus.SubjectList, OperateStatus.MainPage);

                    return;
                }
                if (nextStatus == OperateStatus.SystemSetting)
                {
                    this._opStateChange(OperateStatus.SystemSetting, OperateStatus.MainPage);

                    return;
                }
                if (nextStatus == OperateStatus.ReUploadMaterials)
                {
                    ExamInfo examInfo = ScanGlobalInfo.ExamInfo;

                    this._opStateChange(examInfo, OperateStatus.ReUploadMaterials);
                }
            }
        }

        /// <summary>
        /// 管理状态
        /// </summary>
        /// <param name="curStatus">当前状态</param>
        private void ManangerStatus(ScanOperateForm.ScanPanelClickStatus curStatus)
        {
            switch (curStatus)
            {
                case ScanOperateForm.ScanPanelClickStatus.ScanPaper:
                    this.SetAllTabButtonToDefault(this.btnScan);
                    this.ShowTargetForm(this.panelRight_Body, this._scanExamImageFrm);
                    this.SetTopStatus(1);

                    break;
                case ScanOperateForm.ScanPanelClickStatus.CheckStatis:
                    this.SetAllTabButtonToDefault(this.btnStats);
                    this.ShowTargetForm(this.panelRight_Body, this._statisForm);

                    if (this._statisForm != null)
                    {
                        this._statisForm.BindStatisticInfo();
                    }

                    this.SetTopStatus(3);

                    break;
                case ScanOperateForm.ScanPanelClickStatus.CheckAbnormalPaper:
                    if (this._curClickStatus == ScanOperateForm.ScanPanelClickStatus.ScanFinish || this._curClickStatus == ScanOperateForm.ScanPanelClickStatus.CheckStatis)
                    {
                        this.SetAllTabButtonToDefault(this.btnScan);
                    }

                    this.ShowTargetForm(this.panelRight_Body, this._scanExamImageFrm);
                    this.SetTopStatus(2);

                    break;
                case ScanOperateForm.ScanPanelClickStatus.CheckNormalPaper:
                    if (this._curClickStatus == ScanOperateForm.ScanPanelClickStatus.ScanFinish || this._curClickStatus == ScanOperateForm.ScanPanelClickStatus.CheckStatis)
                    {
                        this.SetAllTabButtonToDefault(this.btnScan);
                    }

                    this.ShowTargetForm(this.panelRight_Body, this._scanExamImageFrm);
                    this.SetTopStatus(2);

                    break;
                case ScanOperateForm.ScanPanelClickStatus.ScanFinish:
                    this.SetAllTabButtonToDefault(this.btnFinish);

                    this._scanFinishFrm = new ScanFinishForm();
                    this._scanFinishFrm.opStateChange += new ScanFinishForm.StateChangeHandle(this.GotoNextState);
                    this._scanFinishFrm.TopLevel = false;
                    this._scanFinishFrm.FormBorderStyle = FormBorderStyle.None;
                    this._scanFinishFrm.Dock = DockStyle.Fill;

                    this.ShowTargetForm(this.panelRight_Body, this._scanFinishFrm);
                    this.SetTopStatus(99);

                    break;
            }

            this._curClickStatus = curStatus;
        }

        /// <summary>
        /// 标准卷列表点击选中
        /// </summary>
        /// <param name="index">索引</param>
        private void ListNormalPaperClickSelected(int index)
        {
            if (index > -1)
            {
                this.list_NormalPaper.SelectedIndex = index;

                this.list_Abnormal.ClearSelected();
                this.ManangerStatus(ScanOperateForm.ScanPanelClickStatus.CheckNormalPaper);
                this.List_NormalPaperHasBeenSelected(index, true);

                this._curNormalClickIndex = index;
            }
        }

        /// <summary>
        /// 异常卷状态管理
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="targetRow">目标行</param>
        private void AbnormalPagerStateMananger(int index, VolumnDataRow targetRow)
        {
            int curSelectedBatch = this._curSelectedBatch;

            ErrorPageManangerBLL.NormalDic = this._normalDic;
            ErrorPageManangerBLL.IncorrectDic = this._incorrectDic;
            ErrorPageManangerBLL.BatchNo = this._curSelectedBatch;

            if (!this._incorrectDic.ContainsKey(curSelectedBatch) || this._incorrectDic[curSelectedBatch].Count <= 0)
            {
                this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);

                return;
            }

            try
            {
                switch (index)
                {
                    case 0:
                        if (targetRow == null)
                        {
                            List<VolumnDataRow> list = ErrorPageManangerBLL.PagerErrorList;

                            if (list == null || list.Count <= 0)
                            {
                                this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);

                                return;
                            }

                            targetRow = list[0];
                        }

                        this._scanExamImageFrm.SetCurVolumnRow(targetRow);
                        this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.PaperError);

                        return;
                    case 1:
                        if (targetRow == null)
                        {
                            this._scanExamImageFrm.RefreshLeakGrid();

                            List<VolumnDataRow> list = ErrorPageManangerBLL.StudentInfoErrorList;

                            if (list == null || list.Count <= 0)
                            {
                                this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);

                                return;
                            }

                            targetRow = list[0];
                        }

                        this._scanExamImageFrm.SetCurVolumnRow(targetRow);
                        this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Zkzh);

                        return;
                    case 2:
                        if (targetRow == null)
                        {
                            List<VolumnDataRow> list = ErrorPageManangerBLL.OmrErrorList;

                            if (list == null || list.Count <= 0)
                            {
                                this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);

                                return;
                            }

                            targetRow = list[0];
                        }

                        this._scanExamImageFrm.SetCurVolumnRow(targetRow);
                        this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Omr);

                        return;
                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 异常列表点击选中
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="targetRow">目标行</param>
        private void listAbnormalClickHasSelected(int index, VolumnDataRow targetRow = null)
        {
            int selectedIndex = this.lbBatch.SelectedIndex;

            if (index != -1 && selectedIndex != -1)
            {
                this.list_Abnormal.SelectedIndex = index;

                this.list_NormalPaper.ClearSelected();

                this._curNormalClickIndex = -1;

                this.ManangerStatus(ScanOperateForm.ScanPanelClickStatus.CheckAbnormalPaper);

                if (this._incorrectDic.ContainsKey(this._curSelectedBatch))
                {
                    this.AbnormalPagerStateMananger(index, targetRow);
                }
            }
        }

        /// <summary>
        /// 搜索按钮点击事件
        /// </summary>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            FormSearchStuInfo formSearchStuInfo = new FormSearchStuInfo();

            if (formSearchStuInfo.ShowDialog() == DialogResult.OK)
            {
                int selectedBatchId = formSearchStuInfo.SelectedBatchId,
                    targetBatchIndex = formSearchStuInfo.SelectedBatchIndex;
                bool flag = false;

                if (selectedBatchId >= 0 && targetBatchIndex >= 0)
                {
                    int indexInBactchListByBatchId = this.GetIndexInBactchListByBatchId(selectedBatchId);

                    this.list_batchHasBeenSelected(indexInBactchListByBatchId);

                    if (this.list_NormalPaper.Items.Count > 0)
                    {
                        for (int i = 0; i < this.list_NormalPaper.Items.Count; i++)
                        {
                            VolumnDataRow volumnDataRow = (VolumnDataRow)this.list_NormalPaper.Items[i];

                            if (volumnDataRow.Data.Index == targetBatchIndex)
                            {
                                this.ListNormalPaperClickSelected(i);

                                flag = true;

                                break;
                            }
                        }
                    }
                    if (!flag && this._incorrectDic[selectedBatchId].Count > 0)
                    {
                        VolumnDataRow volumnDataRow2 = this._incorrectDic[selectedBatchId].Find((VolumnDataRow p) => p.Data.Index == targetBatchIndex);

                        if (volumnDataRow2 != null)
                        {
                            int index = -1;

                            if (volumnDataRow2.ErrorStatusList.Contains(ErrorStatus.ExamPaperInfoError))
                            {
                                index = 0;
                            }
                            else if (volumnDataRow2.ErrorStatusList.Contains(ErrorStatus.StudentInfoError))
                            {
                                index = 1;
                            }
                            else if (volumnDataRow2.ErrorStatusList.Contains(ErrorStatus.ObjectiveOmrError))
                            {
                                index = 2;
                            }

                            this.listAbnormalClickHasSelected(index, volumnDataRow2);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 漏扫检查按钮点击事件
        /// </summary>
        private void btn_LeakCheck_Click(object sender, EventArgs e)
        {
            FormLeakCheck formLeakCheck = new FormLeakCheck(false);

            formLeakCheck.ShowDialog();
        }

        /// <summary>
        /// 返回扫描按钮点击事件
        /// </summary>
        private void btn_BackToScanning_Click(object sender, EventArgs e)
        {
            this._curClickStatus = ScanOperateForm.ScanPanelClickStatus.ScanPaper;

            this.ManangerStatus(this._curClickStatus);
        }

        /// <summary>
        /// 状态改变触发事件
        /// </summary>
        private void StatusChangeTrigger(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            ScanOperateForm.ScanPanelClickStatus curStatus = (ScanOperateForm.ScanPanelClickStatus)control.Tag;

            this.ManangerStatus(curStatus);
        }

        /// <summary>
        /// 移除目标错误状态列表
        /// </summary>
        /// <returns>操作后列表</returns>
        private List<VolumnDataRow> RemoveTargetErrorStatusList()
        {
            List<VolumnDataRow> list = null;

            if (this.list_Abnormal.SelectedItems.Count > 0)
            {
                ErrorPageManangerBLL.IncorrectDic = this._incorrectDic;
                ErrorPageManangerBLL.BatchNo = this._curSelectedBatch;

                if (this.list_Abnormal.SelectedIndex == 0)
                {
                    list = ErrorPageManangerBLL.PagerErrorList;
                }
                else if (this.list_Abnormal.SelectedIndex == 1)
                {
                    list = ErrorPageManangerBLL.StudentInfoErrorList;
                }
                else if (this.list_Abnormal.SelectedIndex == 2)
                {
                    list = ErrorPageManangerBLL.OmrErrorList;
                }
                if (list != null)
                {
                    foreach (VolumnDataRow current in list)
                    {
                        this._incorrectDic[this._curSelectedBatch].Remove(current);
                        ScanRecordHelper.Instance.DeleteLocalScanRecord(current.Data.Guid.ToString());
                    }
                }

                this.refreshNumOfAbnormalList(this._curSelectedBatch);
                this.refreshBatchList(this._curSelectedBatch);
                this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);
                this.SaveAllRecordToXML();
            }

            return list;
        }

        /// <summary>
        /// 删除该类异常卷菜单点击事件
        /// </summary>
        private void ts_DeleteErrorPages_Click(object sender, EventArgs e)
        {
            if (this.list_Abnormal.SelectedItems.Count > 0 && MessageBox.Show("是否确认删除该类异常卷？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.RemoveTargetErrorStatusList();
                this.SetTopStatus(1);
            }
        }

        /// <summary>
        /// 获取图片像素类型
        /// </summary>
        /// <param name="curType">当前类型</param>
        /// <returns>目标类型编号</returns>
        private uint getImgPixelType(ImgSourceType curType)
        {
            uint result = 0u;

            switch (curType)
            {
                case ImgSourceType.BW:
                    result = 0u;

                    break;
                case ImgSourceType.GRAY:
                    result = 1u;

                    break;
                case ImgSourceType.RGB:
                    result = 2u;

                    break;
            }

            return result;
        }

        /// <summary>
        /// 处理实际扫描
        /// </summary>
        /// <param name="img"></param>
        private void ProcessFactScan(IntPtr img)
        {
            try
            {
                this._isInScanning = true;

                string text = string.Concat(new string[]
				{

					"E",
                    ScanGlobalInfo.ExamInfo.CsID.ToString(),
                    "_",
					ScanGlobalInfo.FileBatchHead,
					this._batchNo.ToString("D3"),
					(this._batchIndex + 1).ToString("D4"),
					(this._currentImages.Count + 1).ToString("D2"),
					".png"
				});

                this._currentImages.Add(text);
                this._factScanImgList.Add(img);

                if (this._currentImages.Count < this._pageCount)
                {
                    if (!BatchScan.LoadSourceImage(img, this._scanner, this._currentImages.Count - 1))
                    {
                        LogHelper.WriteFatalLog(text + ",加载卷失败");
                    }
                }
                else
                {
                    this._batchIndex++;

                    bool flag = BatchScan.LoadSourceImage(img, this._scanner, this._currentImages.Count - 1);

                    if (!flag)
                    {
                        LogHelper.WriteFatalLog(text + ",加载卷失败");
                    }

                    BatchScan.ScanOneExamPaper(this._templateInfo, this._scanner, this._batchNo, this._currentImages, this._studentExamInfoList, this._normalDic, this._incorrectDic, flag, this._batchIndex);
                    BatchScan.PrepareToLoadNext(this._scanner);
                    this._currentImages.Clear();
                    this.ReleaseListImage();

                    try
                    {
                        base.Invoke(new MethodInvoker(delegate
                        {
                            this.lbBatch.BeginUpdate();

                            this._bsBatchList[this._bsBatchList.Count - 1] = BatchManagerBLL.Instance.UpdateTargetBatchData(this._batchNo);

                            this.lbBatch.EndUpdate();
                            this.refreshAllWhenScanning();
                        }));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteFatalLog(ex.Message, ex);
                    }
                }
            }
            catch (Exception ex2)
            {
                LogHelper.WriteFatalLog(ex2.Message, ex2);
                BatchScan.PrepareToLoadNext(this._scanner);
                this.ReleaseListImage();
                this._currentImages.Clear();
            }
        }

        /// <summary>
        /// 接收图像
        /// </summary>
        /// <param name="hBitmap">位图句柄</param>
        /// <param name="nbits">图像大小</param>
        /// <param name="img">目标句柄</param>
        private void ReceiveImage(IntPtr hBitmap, int nbits, IntPtr img)
        {
            if (this._isFirstPaperInBatch)
            {
                this._isFirstPaperInBatch = false;
                this._stopwatch.Start();
            }
            try
            {
                if (!this._isTestScan)
                {
                    DateTime curDate = DateTime.Now;
                    LogHelper.WriteInfoLog((curDate - _testDateClos).TotalMilliseconds.ToString());
                    _testDateClos = curDate;

                    Console.WriteLine((curDate - _testDateClos).TotalMilliseconds.ToString());

                    if (this._rotatePageIndex > this._pageCount)
                    {
                        this._rotatePageIndex = 1;
                    }
                    if (ScannerSettingForm.Instance.paperSize == SuportSize.TWSS_A3 || ScannerSettingForm.Instance.paperSize == SuportSize.TWSS_B4 || ScannerSettingForm.Instance.paperSize == SuportSize.TWSS_JISB4 || (ScanGlobalInfo.ExamInfo.Papersize == SuportSize.TWSS_NONE && ScannerSettingForm.Instance.isHorizontal))
                    {
                        int num = 0,
                            num2 = 0;
                        bool imageSize = ScanlibInterop.GetImageSize(img, ref num2, ref num);

                        if (!imageSize || num2 < num)
                        {
                            if (ScannerSettingForm.Instance.IsDoubleSide)
                            {
                                if (this._rotatePageIndex % 2 == 0)
                                {
                                    IntPtr intPtr = IntPtr.Zero;

                                    intPtr = BatchScan.RotateImage(img, ScanGlobalInfo.ExamInfo.Fdir * 90);

                                    img = intPtr;
                                }
                                else
                                {
                                    IntPtr intPtr2 = IntPtr.Zero;

                                    intPtr2 = BatchScan.RotateImage(img, ScanGlobalInfo.ExamInfo.Bdir * 90);

                                    img = intPtr2;
                                }
                            }
                            else
                            {
                                IntPtr intPtr3 = IntPtr.Zero;

                                intPtr3 = BatchScan.RotateImage(img, ScanGlobalInfo.ExamInfo.Bdir * 90);

                                img = intPtr3;
                            }
                        }
                    }

                    this._rotatePageIndex++;
                }
                if (this._factScanIntPtrImgQueue == null)
                {
                    this._factScanIntPtrImgQueue = new Queue();
                }

                this.ProcessFactScan(img);
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 结束线程
        /// </summary>
        private void onEndTransfer()
        {
            try
            {
                this.OnEndScan();

                this._inFactScanning = false;

                this._stopwatch.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 扫描开始
        /// </summary>
        private void ScanBegin(object sender, ScannerSettingForm.ScanFinishedEventArgs e)
        {
            try
            {
                string hardDiskNameFromFilePath = HardDiskHelpler.GetHardDiskNameFromFilePath(PathHelper.LocalDataDir);
                long hardDiskFreeSpace = HardDiskHelpler.GetHardDiskFreeSpace(hardDiskNameFromFilePath);

                if (hardDiskFreeSpace < 500L)
                {
                    if (MessageBox.Show("保存扫描图片所在的磁盘空间不足500M，请先返回到首页在系统设置中清理掉历史数据再继续扫描！\n确定：跳转到系统设置页面\n取消：停留在本页面", "磁盘空间不足", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        this.GotoNextState(OperateStatus.SystemSetting);
                    }

                    return;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message.ToString(), ex);
            }

            this._inFactScanning = true;

            if (this._factScanIntPtrImgQueue != null && this._factScanIntPtrImgQueue.Count > 0)
            {
                MessageBox.Show("当前还有待识别的试卷，请稍后继续扫描！");

                this._inFactScanning = false;
            }
            else
            {
                if (this._isFirstScan)
                {
                    Twain_32.IntialTwain(base.Handle, 0);

                    if (!Twain_32.SelectSource())
                    {
                        this._inFactScanning = false;

                        return;
                    }

                    IntPtr currentDsIdentify = Twain_32.GetCurrentDsIdentify();
                    TwIdentity twIdentity = (TwIdentity)Marshal.PtrToStructure(currentDsIdentify, typeof(TwIdentity));
                    ScanGlobalInfo.ScanMachineModel = twIdentity.ProductName;

                    if (twIdentity.ProductName.ToUpper().Contains("WIA"))
                    {
                        MessageBox.Show("不支持WIA设备来源进行扫描识别");

                        this._inFactScanning = false;

                        return;
                    }
                }
                if (Twain_32.OpenSource())
                {
                    Twain_32.SetCapParam(258, 0u, 4);
                    Twain_32.SetCapParam(4376, 200u, 7);
                    Twain_32.SetCapParam(4377, 200u, 7);
                    Twain_32.SetCapParam(257, this.getImgPixelType(ScannerSettingForm.Instance.CurImgSourceType), 4);
                    Console.WriteLine(ScannerSettingForm.Instance.CurImgSourceType.ToString());
                    Twain_32.SetCapParam(4386, (uint)Twain_32.GetSupportSize(ScannerSettingForm.Instance.paperSize), 4);
                    Console.WriteLine(ScannerSettingForm.Instance.paperSize.ToString());
                    Twain_32.SetCapParam(4115, ScannerSettingForm.Instance.IsDoubleSide ? 1u : 0u, 6);
                    Console.WriteLine(ScannerSettingForm.Instance.IsDoubleSide);
                    Twain_32.Acqurie(ScannerSettingForm.Instance.isShowSettingFrm);
                    Console.WriteLine(ScannerSettingForm.Instance.isShowSettingFrm);

                    this._fonTransfer = new FOnTransfer(this.ReceiveImage);

                    Twain_32.SetOnTranfer(this._fonTransfer);

                    this._fonEndTransfer = new FOnEndTransfer(this.onEndTransfer);

                    Twain_32.SetOnEnd(this._fonEndTransfer);
                    this.InitialBeginScan();

                    return;
                }

                MessageBox.Show("请先选择扫描仪");

                this._inFactScanning = false;

                return;
            }
        }

        /// <summary>
        /// 继续扫描按钮点击事件
        /// </summary>
        private void btn_continueScan_Click(object sender, EventArgs e)
        {
            if (ScanGlobalInfo.ExamInfo.IsScanFinish)
            {
                this.ManangerStatus(ScanOperateForm.ScanPanelClickStatus.ScanPaper);

                this.btnFinish.Enabled = false;
            }

            this.ScanBegin(null, null);
        }

        /// <summary>
        /// 上传刷新
        /// </summary>
        /// <param name="node">数据行</param>
        private void UploadRefresh(VolumnDataRow node)
        {
            lock (BatchScan.lockDataModifyObj)
            {
                if (node.Data.Status.Contains(VolumeStatus.Normal) || node.Data.Status.Contains(VolumeStatus.ManualHandleomr))
                {
                    node.Data.Status = new List<VolumeStatus>
					{
						VolumeStatus.Finished
					};

                    node.RefreshText();

                    try
                    {
                        ScanRecordHelper.Instance.UpdateScanRecordStatus(node.Data);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteFatalLog(ex.Message, ex);
                    }
                }
            }

            if (!this._isInScanning)
            {
                this.refreshNormalList(this._curSelectedBatch, null);
            }

            Application.DoEvents();
        }

        /// <summary>
        /// 准备上传列表
        /// </summary>
        /// <param name="curUploadMana">当前上传处理</param>
        /// <returns>可以上传的对象列表</returns>
        private List<VolumnDataRow> PrepareUploadList(UploadFileManagerBLL curUploadMana)
        {
            List<VolumnDataRow> list = new List<VolumnDataRow>();

            if (this._normalDic != null && this._normalDic.Count > 0)
            {
                foreach (int current in this._normalDic.Keys)
                {
                    for (int i = 0; i < this._normalDic[current].Count; i++)
                    {
                        VolumnDataRow volumnDataRow = this._normalDic[current][i];

                        if (volumnDataRow.Data.Status.Contains(VolumeStatus.Normal) || volumnDataRow.Data.Status.Contains(VolumeStatus.ManualHandleomr))
                        {
                            list.Add(volumnDataRow);

                            if (curUploadMana != null)
                            {
                                lock (UploadFileManagerBLL.lockDataModifyObj)
                                {
                                    curUploadMana.TargetQueue.Enqueue(volumnDataRow);
                                }
                            }
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 上传计时器标记事件
        /// </summary>
        private void UpLoadTicker_Tick(object sender, EventArgs e)
        {
            try
            {
                if (UploadFileManagerBLL.Instance.CompletedQueue.Count > 0)
                {
                    while (UploadFileManagerBLL.Instance.CompletedQueue.Count > 0)
                    {
                        VolumnDataRow node = null;

                        lock (UploadFileManagerBLL.lockCompletedQModifyObj)
                        {
                            node = (VolumnDataRow)UploadFileManagerBLL.Instance.CompletedQueue.Dequeue();
                        }

                        base.Invoke(new MethodInvoker(delegate
                        {
                            this.UploadRefresh(node);
                        }));
                    }
                }
                if (sender != null && UploadFileManagerBLL.Instance.TargetQueue.Count == 0)
                {
                    this.PrepareUploadList(UploadFileManagerBLL.Instance);

                    UploadFileManagerBLL.Instance.CurUploadParam = new UploadMetaParam(60L, false, UploadType.StudentRecord);

                    UploadFileManagerBLL.Instance.RunUpload(new object());
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);

                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 是扫描完成
        /// </summary>
        /// <returns>判断结果</returns>
        private bool isScanFinish()
        {
            if (this._isInScanning)
            {
                MessageBox.Show("扫描未结束，不能完成扫描！");

                return false;
            }
            if (ScanGlobalInfo.ExamInfo.ScanRecordList == null)
            {
                MessageBox.Show("扫描记录为空，不能结束考试！");

                return false;
            }
            if (ScanGlobalInfo.ExamInfo.ScanRecordList.Count == 0)
            {
                MessageBox.Show("扫描记录为空，不能结束考试！");

                return false;
            }
            if (this._incorrectDic != null)
            {
                foreach (int current in this._incorrectDic.Keys)
                {
                    if (this._incorrectDic[current].Count > 0)
                    {
                        MessageBox.Show("还有待处理的异常卷！");

                        return false;
                    }
                }
            }
            if (this._normalDic != null && this._normalDic.Count > 0)
            {
                if (this._upLoadTicker != null)
                {
                    this._upLoadTicker.Stop();

                    this._upLoadTicker.Enabled = false;
                    this._upLoadTicker.Elapsed -= new ElapsedEventHandler(this.UpLoadTicker_Tick);
                    this._upLoadTicker = null;
                }

                this.UpLoadTicker_Tick(null, null);

                UploadFileManagerBLL.Instance.CancelAllUploadingTask();
            }
            if (ScanGlobalInfo.ExamInfo.StudentExamInfoList == null
                || ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count != ScanGlobalInfo.ExamInfo.ScanRecordList.Count)
            {
                FormLeakCheck formLeakCheck = new FormLeakCheck(true);
                return formLeakCheck.ShowDialog() == DialogResult.OK;
            }
            //if (MessageBox.Show("还有学生试卷没有扫描，是否完成扫描？", "完成扫描", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            //    FormLeakCheck formLeakCheck2 = new FormLeakCheck(true);
            //    return formLeakCheck2.ShowDialog() == DialogResult.OK;
            //}

            return true;    //0.9版本暂用
        }

        /// <summary>
        /// 添加窗体到目标控件
        /// </summary>
        /// <param name="targetCrl">目标控件</param>
        /// <param name="target">目标窗体</param>
        private void addFormToTargetCrl(Control targetCrl, Form target)
        {
            if (targetCrl != null)
            {
                target.TopLevel = false;
                target.FormBorderStyle = FormBorderStyle.None;
                target.Dock = DockStyle.Fill;

                targetCrl.Controls.Add(target);
            }
        }

        /// <summary>
        /// 完成扫描按钮点击事件
        /// </summary>
        private void btn_ScanFinish_Click(object sender, EventArgs e)
        {
            if (this.isScanFinish())
            {
                ScanGlobalInfo.ExamInfo.IsScanFinish = true;
                this.btnFinish.Enabled = true;

                this.SetAllTabButtonToDefault(this.btnFinish);

                this._scanFinishFrm = new ScanFinishForm();
                this._scanFinishFrm.opStateChange += new ScanFinishForm.StateChangeHandle(this.GotoNextState);

                this.addFormToTargetCrl(this.panelRight_Body, this._scanFinishFrm);
                this.ShowTargetForm(this.panelRight_Body, this._scanFinishFrm);
            }
        }

        /// <summary>
        /// 重新识别
        /// </summary>
        /// <param name="curRecoList">档期那重试列表</param>
        private void RecoAgain(List<VolumnDataRow> curRecoList)
        {
            this._testFileArry.Clear();

            if (!this._isInScanning)
            {
                if (curRecoList != null && curRecoList.Count > 0)
                {
                    foreach (VolumnDataRow current in curRecoList)
                    {
                        string[] imagePath = current.Data.ImagePath;

                        for (int i = 0; i < imagePath.Length; i++)
                        {
                            string str = imagePath[i];

                            this._testFileArry.Add(PathHelper.LocalVolumneImgDir + str);
                        }
                    }

                    this._testFileArry.Sort(new Comparison<string>(this.CompareFileItem));

                    this._testScanFile = new Queue();

                    if (this._testFileArry.Count > 0)
                    {
                        for (int j = 0; j < this._testFileArry.Count; j++)
                        {
                            this._testScanFile.Enqueue(this._testFileArry[j]);
                        }
                    }

                    this._isInReRecoScan = true;
                    this._curRecoBatch = this._curSelectedBatch;
                    ScanGlobalInfo.ExamInfo.IsScanFinish = false;
                    this.btnFinish.Enabled = false;

                    this.ManangerStatus(ScanOperateForm.ScanPanelClickStatus.ScanPaper);
                    this.SetTopStatus(6);
                    this.StartTestScan();

                    return;
                }
            }
            else
            {
                MessageBox.Show("正在扫描中，不支持重新识别操作");
            }
        }

        /// <summary>
        /// 重新识别菜单点击事件
        /// </summary>
        private void ts_RecoBatchAgain_Click(object sender, EventArgs e)
        {
            if (this._isInScanning)
            {
                MessageBox.Show("正在扫描中，不支持重新识别该批次");

                return;
            }
            if (this.lbBatch.SelectedItems.Count > 0 && MessageBox.Show("是否确认重新识别批次的所有的试卷？重新识别过程中，请耐性等待，以免数据丢失。", "重新识别批次", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                BatchDataRow batchDataRow = (BatchDataRow)this.lbBatch.SelectedItem;
                int num = batchDataRow.BatchIndex;

                this._curSelectedBatch = num;
                this._curRecoBatch = num;

                List<VolumnDataRow> list = new List<VolumnDataRow>();

                if (this._normalDic != null && this._incorrectDic != null)
                {
                    if (this._normalDic.ContainsKey(num))
                    {
                        foreach (VolumnDataRow current in this._normalDic[num])
                        {
                            list.Add(current);

                            ScanRecordHelper.Instance.DeleteLocalScanRecord(current.Data.Guid.ToString());
                        }

                        this._normalDic[num].Clear();
                    }
                    if (this._incorrectDic.ContainsKey(num))
                    {
                        foreach (VolumnDataRow current2 in this._incorrectDic[num])
                        {
                            list.Add(current2);

                            ScanRecordHelper.Instance.DeleteLocalScanRecord(current2.Data.Guid.ToString());
                        }

                        this._incorrectDic[num].Clear();
                    }

                    this.refreshNormalList(this._curSelectedBatch, null);
                    this.refreshNumOfAbnormalList(this._curSelectedBatch);
                    this.refreshBatchList(num);
                    this.SaveAllRecordToXML();
                    this.RecoAgain(list);
                }
            }
        }

        /// <summary>
        /// 重新识别错误卷菜单点击事件
        /// </summary>
        private void ts_RecoAgainErrorPages_Click(object sender, EventArgs e)
        {
            if (this._isInScanning)
            {
                MessageBox.Show("正在扫描中，不能执行重新识别操作!");

                return;
            }
            if (this.list_Abnormal.SelectedItems.Count > 0 && MessageBox.Show("是否确认重新识别该类的所有异常卷？重新识别过程中，请耐性等待，以免数据丢失。", "重新识别", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                List<VolumnDataRow> curRecoList = this.RemoveTargetErrorStatusList();

                this.RecoAgain(curRecoList);
            }
        }

        /// <summary>
        /// 列表批次鼠标点击事件
        /// </summary>
        private void list_batch_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.lbBatch.IndexFromPoint(e.X, e.Y);

            if (this.lbBatch.SelectedIndex != -1)
            {
                this.list_batchHasBeenSelected(index);
            }
        }

        /// <summary>
        /// 列表异常鼠标点击事件
        /// </summary>
        private void list_Abnormal_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.list_Abnormal.IndexFromPoint(e.X, e.Y);

            this.listAbnormalClickHasSelected(index, null);
        }

        /// <summary>
        /// 列表标准卷鼠标点击事件
        /// </summary>
        private void list_NormalPaper_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.list_NormalPaper.IndexFromPoint(e.X, e.Y);

            if (this.list_NormalPaper.SelectedIndex != -1)
            {
                this.ListNormalPaperClickSelected(index);
            }
        }

        /// <summary>
        /// 窗体回收事件
        /// </summary>
        private void ScanOperateForm_Disposed(object sender, EventArgs e)
        {
            if (!this._isAbortTestScanTrd)
            {
                this._isAbortTestScanTrd = true;

                if (this._testTrd != null && this._testTrd.ThreadState == System.Threading.ThreadState.Running)
                {
                    try
                    {
                        this._testTrd.Abort();
                    }
                    catch (ThreadAbortException) { }

                    this._testTrd = null;
                }
            }

            this.SaveAllRecordToXML();

            if (this._upLoadTicker != null)
            {
                this._upLoadTicker.Stop();

                this._upLoadTicker.Enabled = false;
                this._upLoadTicker.Elapsed -= new ElapsedEventHandler(this.UpLoadTicker_Tick);
                this._upLoadTicker = null;
            }

            UploadFileManagerBLL.Instance.CancelAllUploadingTask();

            if (ScannerSettingForm.Instance != null)
            {
                ScannerSettingForm.Instance.Dispose();

                ScannerSettingForm.Instance = null;
            }

            Application.RemoveMessageFilter(this);

            BatchManagerBLL.Instance = null;
        }

        /// <summary>
        /// 初始化UI
        /// </summary>
        private void InitialUI()
        {
            this.list_Abnormal.BackColor = ScanOperateForm.Scheme.UnifiedBackColor;
            this.lbBatch.BackColor = ScanOperateForm.Scheme.UnifiedBackColor;
            this.list_NormalPaper.BackColor = ScanOperateForm.Scheme.UnifiedBackColor;
            this.panel_LeftTop.BackColor = ScanOperateForm.Scheme.UnifiedBackColor;
            this.panelTool.BackColor = ScanOperateForm.Scheme.UnifiedBackColor;
            this.lbl_AbnormalTitle.BackColor = ScanOperateForm.Scheme.ListTtileBackColor;
            this.lbl_BatchListTitle.BackColor = ScanOperateForm.Scheme.ListTtileBackColor;
            this.lbl_NormalTitle.BackColor = ScanOperateForm.Scheme.ListTtileBackColor;
            this.btnScan.Click += new EventHandler(this.StatusChangeTrigger);
            this.btnScan.Tag = ScanOperateForm.ScanPanelClickStatus.ScanPaper;
            this.btnStats.Click += new EventHandler(this.StatusChangeTrigger);
            this.btnStats.Tag = ScanOperateForm.ScanPanelClickStatus.CheckStatis;
            this.btnFinish.Click += new EventHandler(this.StatusChangeTrigger);
            this.btnFinish.Tag = ScanOperateForm.ScanPanelClickStatus.ScanFinish;
            this.ts_DeleteErrorPages.Click += new EventHandler(this.ts_DeleteErrorPages_Click);
            this.btnContinueScan.Click += new EventHandler(this.btn_continueScan_Click);
            this.btnScanFinish.Click += new EventHandler(this.btn_ScanFinish_Click);
            this.ts_RecoAgain.Click += new EventHandler(this.ts_RecoBatchAgain_Click);
            this.ts_RecoAgainErrorPages.Click += new EventHandler(this.ts_RecoAgainErrorPages_Click);
            this.lbBatch.MouseClick += new MouseEventHandler(this.list_batch_MouseClick);
            this.list_Abnormal.MouseClick += new MouseEventHandler(this.list_Abnormal_MouseClick);
            this.list_NormalPaper.MouseClick += new MouseEventHandler(this.list_NormalPaper_MouseClick);
            base.Disposed += new EventHandler(this.ScanOperateForm_Disposed);

            if (!ScanGlobalInfo.ExamInfo.IsScanFinish)
            {
                this.btnFinish.Enabled = false;
            }
            else
            {
                this.btnFinish.Enabled = true;
            }

            this.btn_BackToScanning.Visible = false;
            this.progress_Scan.Maximum = 100;
            this.progress_Scan.Step = 5;
            this.progress_Scan.Value = 0;
        }

        /// <summary>
        /// 移除目标行
        /// </summary>
        /// <param name="batchid">批次编号</param>
        /// <param name="curRow">当前行</param>
        /// <param name="curDic">当前字典</param>
        /// <returns>操作结果</returns>
        private bool RemoveTargetRow(int batchid, VolumnDataRow curRow, Dictionary<int, List<VolumnDataRow>> curDic)
        {
            if (curDic != null && curDic.ContainsKey(batchid))
            {
                int num = curDic[batchid].FindIndex((VolumnDataRow p) => p.Data.Guid.ToString() == curRow.Data.Guid.ToString());

                if (num >= 0 && num < curDic[batchid].Count)
                {
                    curDic[batchid].RemoveAt(num);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 移除目标标准行
        /// </summary>
        /// <param name="curRow">当前行</param>
        /// <param name="curDic">当前字典</param>
        /// <returns>操作结果</returns>
        private bool RemoveTargetNormalRow(VolumnDataRow curRow, Dictionary<int, List<VolumnDataRow>> curDic)
        {
            if (curDic != null && curDic.Count > 0)
            {
                foreach (int current in curDic.Keys)
                {
                    VolumnDataRow volumnDataRow = curDic[current].Find((VolumnDataRow p) => p.Data.Guid.ToString() == curRow.Data.Guid.ToString());

                    if (volumnDataRow != null)
                    {
                        curDic[current].Remove(volumnDataRow);

                        if (this._incorrectDic != null && this._incorrectDic.ContainsKey(current))
                        {
                            this._incorrectDic[current].Add(volumnDataRow);
                        }

                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// 错误卷更新函数
        /// </summary>
        /// <param name="BatchId">批次ID</param>
        /// <param name="tmpRow">处理行</param>
        /// <param name="otherErrorStatus">其它错误状态</param>
        private void ErrorPageUpdateFnc(int BatchId, VolumnDataRow tmpRow, ErrorStatus otherErrorStatus)
        {
            if (!ErrorPageManangerBLL.IsInOtherErrorList(BatchId, tmpRow, otherErrorStatus))
            {
                VolumnDataRow volumnDataRow = null;

                if (!ErrorPageManangerBLL.IsHasSameZkzhInNormalList(BatchId, tmpRow, ref volumnDataRow))
                {

                    tmpRow.Data.Status = new List<VolumeStatus>
					{
						VolumeStatus.Normal
					};

                    tmpRow.RefreshText();
                    this._bsNormalList.Add(tmpRow);
                    this.RemoveTargetRow(BatchId, tmpRow, this._incorrectDic);
                    ScanRecordHelper.Instance.UpdateScanRecord(tmpRow.Data);
                    this.refreshNumOfAbnormalList(this._curSelectedBatch);
                    this.refreshBatchList(BatchId);
                    this.SaveAllRecordToXML();
                }
                else
                {
                    this.RemoveTargetRow(BatchId, tmpRow, this._incorrectDic);
                    tmpRow.Data.Status.Clear();
                    tmpRow.Data.Status.Add(VolumeStatus.Duplicate);
                    tmpRow.ErrorStatusList.Add(ErrorStatus.StudentInfoError);
                    tmpRow.RefreshText();
                    volumnDataRow.Data.Status.Clear();
                    volumnDataRow.Data.Status.Add(VolumeStatus.Duplicate);
                    volumnDataRow.ErrorStatusList.Add(ErrorStatus.StudentInfoError);
                    volumnDataRow.RefreshText();
                    this.RemoveTargetNormalRow(volumnDataRow, this._normalDic);
                    this._incorrectDic[BatchId].Add(tmpRow);
                    ScanRecordHelper.Instance.UpdateScanRecord(tmpRow.Data);
                    ScanRecordHelper.Instance.UpdateScanRecord(volumnDataRow.Data);
                    this.refreshNumOfAbnormalList(this._curSelectedBatch);
                    this.refreshNormalList(this._curSelectedBatch, null);
                    this.refreshTheWholeBatchList();
                    this.SaveAllRecordToXML();
                }
            }
            else
            {
                ScanRecordHelper.Instance.UpdateScanRecord(tmpRow.Data);
            }

            this._scanExamImageFrm.RefreshLeakGrid();
        }

        /// <summary>
        /// 错误卷操作结果管理
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="curOpStatus">当前操作状态</param>
        /// <param name="curOp">当前操作</param>
        private void ErrorPaperOpResultManager(object obj, PaperOperateStatus curOpStatus, BaseOperation curOp)
        {
            VolumnDataRow volumnDataRow = (VolumnDataRow)obj;

            volumnDataRow.RefreshText();

            int curSelectedBatch = this._curSelectedBatch;

            lock (BatchScan.lockDataModifyObj)
            {
                switch (curOpStatus)
                {
                    case PaperOperateStatus.Omr:

                        if (curOp == BaseOperation.None)
                        {
                            if (this.RemoveTargetRow(curSelectedBatch, volumnDataRow, this._incorrectDic))
                            {
                                this._incorrectDic[curSelectedBatch].Add(volumnDataRow);
                            }

                            this.AbnormalPagerStateMananger(2, null);
                        }
                        else if (curOp == BaseOperation.Update && this._incorrectDic[curSelectedBatch].Count > 0)
                        {
                            ErrorPageManangerBLL.NormalDic = this._normalDic;
                            ErrorPageManangerBLL.IncorrectDic = this._incorrectDic;
                            ErrorPageManangerBLL.BatchNo = this._curSelectedBatch;

                            volumnDataRow.ErrorStatusList.Remove(ErrorStatus.ObjectiveOmrError);

                            if (volumnDataRow.HistoryErrorStatusList == null)
                            {
                                volumnDataRow.HistoryErrorStatusList = new List<ErrorStatus>();
                            }

                            volumnDataRow.HistoryErrorStatusList.Add(ErrorStatus.ObjectiveOmrError);
                            volumnDataRow.Data.Status.Remove(VolumeStatus.ErrOmr);
                            this.refreshNumOfAbnormalList(this._curSelectedBatch);
                            this.ErrorPageUpdateFnc(curSelectedBatch, volumnDataRow, ErrorStatus.StudentInfoError);
                            this.AbnormalPagerStateMananger(this.list_Abnormal.SelectedIndex, null);

                            for (int i = 0; i < _normalDic[_curSelectedBatch].Count; i++)
                            {
                                if (_normalDic[_curSelectedBatch][i].Data.Guid == volumnDataRow.Data.Guid)
                                {
                                    _normalDic[_curSelectedBatch][i] = volumnDataRow;
                                }
                            }

                            ErrorPageManangerBLL.NormalDic = _normalDic;
                        }

                        break;
                    case PaperOperateStatus.Zkzh:
                        ErrorPageManangerBLL.NormalDic = this._normalDic;
                        ErrorPageManangerBLL.IncorrectDic = this._incorrectDic;
                        ErrorPageManangerBLL.BatchNo = this._curSelectedBatch;

                        if (curOp == BaseOperation.None)
                        {
                            if (this.RemoveTargetRow(curSelectedBatch, volumnDataRow, this._incorrectDic))
                            {
                                this._incorrectDic[curSelectedBatch].Add(volumnDataRow);
                            }

                            this.AbnormalPagerStateMananger(1, null);
                        }
                        else if (curOp == BaseOperation.Delete)
                        {
                            string text = "是否确认删除该试卷？";

                            if (volumnDataRow.Data.Status.Contains(VolumeStatus.Duplicate) && !ErrorPageManangerBLL.IsHasSameZkzhInAbnormalList(volumnDataRow))
                            {
                                text = string.Format("所有考号信息异常卷中最后一张考号为:{0}的重号卷,是否确认删除？", volumnDataRow.Zkzh);
                            }
                            if (MessageBox.Show(text, "删除试卷", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                            {
                                ScanRecordHelper.Instance.DeleteLocalScanRecord(volumnDataRow.Data.Guid.ToString());
                                this.RemoveTargetRow(curSelectedBatch, volumnDataRow, this._incorrectDic);
                                this.refreshNumOfAbnormalList(curSelectedBatch);
                                this.refreshBatchList(curSelectedBatch);
                                this.AbnormalPagerStateMananger(1, null);
                            }
                        }
                        else if (curOp == BaseOperation.Update && this._incorrectDic[curSelectedBatch].Count > 0)
                        {
                            volumnDataRow.ErrorStatusList.Remove(ErrorStatus.StudentInfoError);

                            if (volumnDataRow.HistoryErrorStatusList == null)
                            {
                                volumnDataRow.HistoryErrorStatusList = new List<ErrorStatus>();
                            }

                            volumnDataRow.HistoryErrorStatusList.Add(ErrorStatus.StudentInfoError);
                            volumnDataRow.Data.Status.Remove(VolumeStatus.ErrZkzh);
                            this.refreshNumOfAbnormalList(this._curSelectedBatch);
                            this.ErrorPageUpdateFnc(curSelectedBatch, volumnDataRow, ErrorStatus.ObjectiveOmrError);
                            this.AbnormalPagerStateMananger(this.list_Abnormal.SelectedIndex, null);
                            ScanRecordHelper.Instance.UpdateScanRecord(volumnDataRow.Data);
                        }

                        break;
                    case PaperOperateStatus.PaperError:
                        if (curOp == BaseOperation.None)
                        {
                            if (this.RemoveTargetRow(curSelectedBatch, volumnDataRow, this._incorrectDic))
                            {
                                this._incorrectDic[curSelectedBatch].Add(volumnDataRow);
                            }

                            this.AbnormalPagerStateMananger(0, null);
                        }
                        else if (curOp == BaseOperation.Delete)
                        {
                            ScanRecordHelper.Instance.DeleteLocalScanRecord(volumnDataRow.Data.Guid.ToString());
                            this.RemoveTargetRow(curSelectedBatch, volumnDataRow, this._incorrectDic);
                            this.refreshNumOfAbnormalList(curSelectedBatch);
                            this.refreshBatchList(curSelectedBatch);
                            this.AbnormalPagerStateMananger(0, null);
                        }
                        else if (curOp == BaseOperation.Add)
                        {
                            if (this.RemoveTargetRow(curSelectedBatch, volumnDataRow, this._incorrectDic))
                            {
                                this._incorrectDic[curSelectedBatch].Add(volumnDataRow);
                            }

                            this.refreshNumOfAbnormalList(curSelectedBatch);
                            this.AbnormalPagerStateMananger(0, null);
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// 加载本地扫描结果
        /// </summary>
        /// <returns>操作状态</returns>
        private bool LoadLocalScanRecord()
        {
            bool result = true;

            try
            {
                if (!ScanRecordHelper.CheckLocalXml())
                {
                    this._hasloadLocalZipxml = ScanRecordHelper.LoadZipXmlData(this._hasloadLocalZipxml);

                    this.LoadLocalScanRecord();
                }
                if (File.Exists(PathHelper.NormalExamXmlPath))
                {
                    try
                    {
                        this._normalDic = FileHelper.DeserializeFromXml<Dictionary<int, List<VolumnDataRow>>>(PathHelper.NormalExamXmlPath);

                        goto IL_75;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteFatalLog(ex.Message, ex);

                        this._hasloadLocalZipxml = ScanRecordHelper.LoadZipXmlData(this._hasloadLocalZipxml);

                        this.LoadLocalScanRecord();

                        goto IL_75;
                    }
                }

                this._normalDic = new Dictionary<int, List<VolumnDataRow>>();

            IL_75:
                if (File.Exists(PathHelper.IncorrectExamXmlPath))
                {
                    try
                    {
                        this._incorrectDic = FileHelper.DeserializeFromXml<Dictionary<int, List<VolumnDataRow>>>(PathHelper.IncorrectExamXmlPath);

                        goto IL_C5;
                    }
                    catch (Exception ex2)
                    {
                        LogHelper.WriteFatalLog(ex2.Message, ex2);

                        this._hasloadLocalZipxml = ScanRecordHelper.LoadZipXmlData(this._hasloadLocalZipxml);

                        this.LoadLocalScanRecord();

                        goto IL_C5;
                    }
                }

                this._incorrectDic = new Dictionary<int, List<VolumnDataRow>>();

            IL_C5:
                if (File.Exists(PathHelper.LocalScanrecordXmlPath))
                {
                    try
                    {
                        ScanGlobalInfo.ExamInfo.ScanRecordList = FileHelper.DeseriXmlModel<SynchronizedCollection<ScanRecord>>(PathHelper.LocalScanrecordXmlPath);

                        if (ScanGlobalInfo.ExamInfo.ScanRecordList != null && ScanGlobalInfo.ExamInfo.ScanRecordList.Count > 0)
                        {
                            this.btnContinueScan.Visible = true;
                            this.btnScanFinish.Visible = true;
                        }
                        else
                        {
                            this.btnContinueScan.Visible = false;
                            this.btnScanFinish.Visible = false;
                        }

                        goto IL_19D;
                    }
                    catch (Exception ex3)
                    {
                        LogHelper.WriteFatalLog(ex3.Message, ex3);

                        this._hasloadLocalZipxml = ScanRecordHelper.LoadZipXmlData(this._hasloadLocalZipxml);

                        this.LoadLocalScanRecord();

                        goto IL_19D;
                    }
                }

                this.btnContinueScan.Visible = false;
                this.btnScanFinish.Visible = false;
                this._normalDic = new Dictionary<int, List<VolumnDataRow>>();
                this._incorrectDic = new Dictionary<int, List<VolumnDataRow>>();

                ScanGlobalInfo.ExamInfo.ScanRecordList = null;

            IL_19D:
                ErrorPageManangerBLL.NormalDic = this._normalDic;
                ErrorPageManangerBLL.IncorrectDic = this._incorrectDic;
            }
            catch (Exception ex4)
            {
                MessageBox.Show("加载本地数据出错.\n详细错误信息：" + ex4.Message.ToString());
                LogHelper.WriteFatalLog(ex4.Message, ex4);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// 初始化ListBox
        /// </summary>
        private void InitialListBox()
        {
            this._normalList = new List<VolumnDataRow>();
            this._bsNormalList = new BindingSource(this._normalList, null);
            this._abnormalList = new List<string>();

            this._abnormalList.Add(string.Format("试卷信息异常{0,15}份", 0));
            this._abnormalList.Add(string.Format("考号信息异常{0,15}份", 0));
            this._abnormalList.Add(string.Format("客观题信息异常{0,13}份", 0));

            this._bsAbnormalList = new BindingSource(this._abnormalList, null);
            this.list_Abnormal.DataSource = this._bsAbnormalList;
            this._bsBatchList = new BindingSource();
            this._batchList = new List<BatchDataRow>();

            BatchManagerBLL.Instance.InitialBatchData(this._normalDic, this._incorrectDic, this._batchList);

            this._batchNo = BatchManagerBLL.Instance.BatchNo;
            this._bsBatchList = new BindingSource(this._batchList, null);
            this.lbBatch.DataSource = this._bsBatchList;
            this._curSelectedBatch = 0;
            this._curSelectedIndex = 0;
        }

        /// <summary>
        /// 初始化线程
        /// </summary>
        private void IntialTrd()
        {
            try
            {
                base.Invoke(new MethodInvoker(delegate
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.scMain.Panel1.Enabled = false;
                    this.panelTool.Enabled = false;
                    this.progress_Scan.Visible = true;
                    this.progress_Scan.Maximum = 100;
                    this.progress_Scan.Step = 5;
                    this.progress_Scan.Value = 30;
                    this.lbl_CurWork.Text = "加载数据中...";
                    this.lbl_Status.Text = "状态：正常";

                    this.ShowTargetForm(this.panelRight_Body, this._scanExamImageFrm);
                    this.SetAllTabButtonToDefault(this.btnScan);

                    this.btn_LeakCheck.Visible = false;
                }));

                try
                {
                    if (ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count == 0)
                    {
                        StudentExamInfoResponse seiResponse = new BaseDisposeBLL().StudentExamInfo_GetList();

                        _studentExamInfoList = (seiResponse.Success) ? seiResponse.Data : null;

                        ScanGlobalInfo.ExamInfo.StudentExamInfoList.AddRange(this._studentExamInfoList);
                    }
                    if (ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count <= 0)
                    {
                        this._studentExamInfoList = new List<StudentExamInfo>();

                        base.Invoke(new MethodInvoker(delegate
                        {
                            this.lbl_CurWork.Text = "加载完成!请先导入学生数据再进行扫描";
                            this.lbl_Status.Text = "状态：正常";
                            this.progress_Scan.Value = 100;
                        }));

                        return;
                    }

                    this._studentExamInfoList = ScanGlobalInfo.ExamInfo.StudentExamInfoList;
                }
                catch (Exception ex)
                {
                    ScanOperateForm curThis = this;
                    this._studentExamInfoList = new List<StudentExamInfo>();

                    LogHelper.WriteFatalLog(ex.Message, ex);

                    base.Invoke(new MethodInvoker(delegate
                    {
                        MessageBox.Show("加载考生数据失败!\n详细错误信息：" + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                        curThis.progress_Scan.Value = 100;
                        curThis.lbl_CurWork.Text = "加载考生数据失败！请稍后再试";
                        curThis.lbl_Status.Text = "状态：异常";
                    }));

                    return;
                }

                this._upLoadTicker = new System.Timers.Timer(10000.0);
                this._upLoadTicker.Elapsed += new ElapsedEventHandler(this.UpLoadTicker_Tick);
                this._upLoadTicker.AutoReset = true;
                this._upLoadTicker.Enabled = true;

                this._upLoadTicker.Start();

                base.Invoke(new MethodInvoker(delegate
                {
                    this.progress_Scan.Value = 80;

                    try
                    {
                        this._scanExamImageFrm.IntiaLeakGrid();
                        this._scanExamImageFrm.RefreshLeakGrid();
                    }
                    catch (Exception ex4)
                    {
                        LogHelper.WriteFatalLog(ex4.Message, ex4);
                    }

                    this.btn_ScanTest.Visible = ScanGlobalInfo.isOpenTestScan;
                    this.progress_Scan.Value = 100;
                    this.progress_Scan.Visible = false;
                    this.lbl_CurWork.Text = "加载完成";
                    this.lbl_Status.Text = "状态：正常";
                    Cursor.Current = Cursors.Default;
                    this.scMain.Panel1.Enabled = true;
                    this.panelTool.Enabled = true;
                    this._isFirstScan = true;

                    if (ScanGlobalInfo.ExamInfo.ScanRecordList == null || ScanGlobalInfo.ExamInfo.ScanRecordList.Count <= 0)
                    {
                        ScannerSettingForm.Instance.Show();
                    }

                    this.SetTopStatus(1);
                    Application.DoEvents();
                }));
            }
            catch (Exception ex2)
            {
                LogHelper.WriteFatalLog(ex2.Message, ex2);
            }
        }

        /// <summary>
        /// 初始化模板信息
        /// </summary>
        /// <returns>操作结果</returns>
        private bool InitializeTemplateInfo()
        {
            try
            {
                this._templateInfo = LoadTplFLoadTemplateFile.CurTemplateInfo;
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog("模板加载失败" + ex.Message.ToString(), ex);

                bool result = false;

                return result;
            }

            this._pageCount = this._templateInfo.pages.Length;
            this._scanner = BatchScan.CreateScanner(this._templateInfo);

            if (this._scanner == IntPtr.Zero)
            {
                LogHelper.WriteFatalLog("创建扫描识别器失败");

                return false;
            }
            if (!BatchScan.LoadTemplImage(this._scanner, this._templateInfo))
            {
                LogHelper.WriteFatalLog("加载模板图失败");

                return false;
            }
            if (!BatchScan.SetTitleArea(this._scanner, this._templateInfo))
            {
                MessageBox.Show("报模板出错，请重新调整模板。");
                LogHelper.WriteFatalLog("加载文字定位点失败");

                return false;
            }

            ScannerSettingForm.Instance.UpdateInfoByTpInfo(this._templateInfo);
            BatchScan.SetConvincedThreshold(this._scanner, ScanGlobalInfo.RecoSureValue);
            BatchScan.SetDoubtfulThreshold(this._scanner, ScanGlobalInfo.RecoNotSureValue);

            return true;
        }

        /// <summary>
        /// 下载保存的扫描xml数据文件
        /// </summary>
        /// <returns>保存操作是否成功</returns>
        private bool DownloadExamXmlData()
        {
            string saveDir = PathHelper.LocalExamDataDir;

            if (!File.Exists(PathHelper.LocalScanrecordXmlPath))
            {
                if (ALiProgressManager.Oss_ExistObject(PathHelper.LocalSaveScanrecordXmlFileName))
                {
                    ALiProgressManager.Oss_GetObject(PathHelper.LocalSaveScanrecordXmlFileName, saveDir);

                    new FileInfo(PathHelper.LocalSaveScanrecordXmlPath).MoveTo(PathHelper.LocalScanrecordXmlPath);
                    new FileInfo(PathHelper.LocalSaveScanrecordXmlPath).Delete();
                }
            }
            if (!File.Exists(PathHelper.ScanStatisticsPath))
            {
                if (ALiProgressManager.Oss_ExistObject(PathHelper.ScanSaveStatisticsXmlFileName))
                {
                    ALiProgressManager.Oss_GetObject(PathHelper.ScanSaveStatisticsXmlFileName, saveDir);

                    new FileInfo(PathHelper.ScanSaveStatisticsPath).MoveTo(PathHelper.ScanStatisticsPath);
                    new FileInfo(PathHelper.ScanSaveStatisticsPath).Delete();
                }
            }
            if (!File.Exists(PathHelper.NormalExamXmlPath))
            {
                if (ALiProgressManager.Oss_ExistObject(PathHelper.NormalSaveExamXmlFileName))
                {
                    ALiProgressManager.Oss_GetObject(PathHelper.NormalSaveExamXmlFileName, saveDir);

                    new FileInfo(PathHelper.NormalSaveExamXmlPath).MoveTo(PathHelper.NormalExamXmlPath);
                    new FileInfo(PathHelper.NormalSaveExamXmlPath).Delete();
                }
            }
            if (!File.Exists(PathHelper.IncorrectExamXmlPath))
            {
                if (ALiProgressManager.Oss_ExistObject(PathHelper.IncorrectSaveExamXmlFileName))
                {
                    ALiProgressManager.Oss_GetObject(PathHelper.IncorrectSaveExamXmlFileName, saveDir);

                    new FileInfo(PathHelper.IncorrectSaveExamXmlPath).MoveTo(PathHelper.IncorrectExamXmlPath);
                    new FileInfo(PathHelper.IncorrectSaveExamXmlPath).Delete();
                }
            }

            return true;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void ScanOperateForm_Load(object sender, EventArgs e)
        {
            DownloadExamXmlData();
            base.Hide();
            this.InitialUI();
            this.SetTopStatus(0);

            lblExamName.Text = string.Concat(ScanGlobalInfo.ExamGroup.ExamName, ScanGlobalInfo.ExamInfo.GradeName, ScanGlobalInfo.ExamInfo.SubjectName);

            if (this._statisForm == null)
            {
                this._statisForm = new StatisticForm();
            }

            this.addFormToTargetCrl(this.panelRight_Body, this._statisForm);

            if (this._scanExamImageFrm == null)
            {
                this._scanExamImageFrm = new ScanExamImageForm();
                this._scanExamImageFrm.opPaperStateChange += new ScanExamImageForm.PaperOperateResultHandle(this.ErrorPaperOpResultManager);
                ScanExamImageForm expr_71 = this._scanExamImageFrm;
                expr_71.PageIndexShownUpdateHandle = (EventHandler)Delegate.Combine(expr_71.PageIndexShownUpdateHandle, new EventHandler(delegate(object obj, EventArgs args)
                {
                    this.lbl_PageIndex.Text = this._scanExamImageFrm.PageIndexStr;
                }));
            }

            this.addFormToTargetCrl(this.panelRight_Body, this._scanExamImageFrm);

            ScannerSettingForm ssForm = ScannerSettingForm.Instance;
            ssForm.onScanFinished = (ScannerSettingForm.ScanFinished)Delegate.Combine(ssForm.onScanFinished, new ScannerSettingForm.ScanFinished(this.ScanBegin));

            if (!this.LoadLocalScanRecord())
            {
                MessageBox.Show("加载本地扫描记录数据失败,请查看日志", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                return;
            }

            this.InitialListBox();

            Thread thread = new Thread(new ThreadStart(this.IntialTrd));

            thread.Start();

            if (!this.InitializeTemplateInfo() && this._templateInfo != null)
            {
                MessageBox.Show("加载模板失败,请查看日志", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                return;
            }

            this._scanExamImageFrm.InitialOmrGrid(this._templateInfo);
            this.lbBatch.ClearSelected();
            this.list_NormalPaper.ClearSelected();
            this.list_Abnormal.ClearSelected();
            UploadFileManagerBLL.Instance.Initial(3);
            Application.AddMessageFilter(this);
            base.Show();
        }

        /// <summary>
        /// 返回按钮点击事件
        /// </summary>
        private void lblBackExamList_Click(object sender, EventArgs e)
        {
            _backLastStep("", OperateStatus.SubjectOperate);
        }

        /// <summary>
        /// ListBox的重绘事件
        /// </summary>
        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;    //获取当前要进行绘制的行的序号，从0开始

            if (index < 0)
            {
                return;
            }

            Graphics g = e.Graphics;    //获取Graphics对象
            Rectangle bound = e.Bounds; //获取当前要绘制的行的一个矩形范围
            string text = (sender as ListBox).Items[index].ToString();  //获取当前要绘制的行的显示文本

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)   //如果当前行为选中行
            {
                g.DrawRectangle(new Pen(Color.FromArgb(95, 180, 27)), bound.Left, bound.Top, bound.Width - 1, bound.Height - 1);   //绘制选中时要显示的边框

                Rectangle rect = new Rectangle(bound.Left, bound.Top, bound.Width, bound.Height);

                g.FillRectangle(new Pen(Color.FromArgb(95, 180, 27)).Brush, rect);    //绘制选中时要显示的背景
                TextRenderer.DrawText(g, text, this.Font, rect, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);   //绘制显示文本
            }
            else
            {
                using (Brush brush = new Pen(Color.White).Brush) //GetBrush为自定义方法，根据当前的行号来选择Brush进行绘制
                {
                    g.FillRectangle(brush, bound);  //绘制背景色
                }

                TextRenderer.DrawText(g, text, this.Font, bound, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (this.lbBatch.SelectedItems.Count > 0)
            {
                BatchDataRow batchDataRow = (BatchDataRow)this.lbBatch.SelectedItem;

                if (this._isInScanning && batchDataRow.BatchIndex == this._batchNo)
                {
                    MessageBox.Show("该批次正在扫描中，不能删除该批次");

                    return;
                }
                if (MessageBox.Show("是否确认删除该批次所有试卷？", "删除批次", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    int batchId = batchDataRow.BatchIndex;

                    if (BatchManagerBLL.Instance.DeleteBatchByBatchId(batchId))
                    {
                        if (this._curSelectedBatch == this._batchNo)
                        {
                            this._scanExamImageFrm.ErrorOperateStatusManager(PaperOperateStatus.Empty);
                        }
                        if (this._bsBatchList.Count == 1)
                        {
                            this.btnContinueScan.Visible = false;
                            this.btnScanFinish.Visible = false;
                        }

                        this.lbBatch.BeginUpdate();
                        this._bsBatchList.Remove(batchDataRow);
                        this.lbBatch.EndUpdate();

                        BatchDataRow batchDataRow2 = (BatchDataRow)this.lbBatch.SelectedItem;

                        if (batchDataRow2 != null)
                        {
                            this._curSelectedBatch = batchDataRow2.BatchIndex;

                            this.list_batchHasBeenSelected(this.lbBatch.SelectedIndex);
                        }
                        else
                        {
                            this.refreshNormalList(batchId, null);
                            this.refreshNumOfAbnormalList(batchId);
                        }

                        this.SaveAllRecordToXML();
                        this.SetTopStatus(1);
                    }
                }
            }
        }
    }
}
