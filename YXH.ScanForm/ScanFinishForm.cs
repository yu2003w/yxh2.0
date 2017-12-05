using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.Form;
using YXH.Enum;
using YXH.HttpHelper.Response;
using YXH.Model;
using YXH.ScanBLL;
using System.Linq;
using YXH.Common.Enum;

namespace YXH.ScanForm
{
    /// <summary>
    /// 扫描完成窗体
    /// </summary>
    public partial class ScanFinishForm : Form
    {
        /// <summary>
        /// 业务处理实例
        /// </summary>
        BaseDisposeBLL _bdBLL = new BaseDisposeBLL();
        /// <summary>
        /// 开始改变委托定义
        /// </summary>
        /// <param name="nextOpStatus">下一个状态</param>
        public delegate void StateChangeHandle(OperateStatus nextOpStatus);
        /// <summary>
        /// 自动大小形式
        /// </summary>
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        /// <summary>
        /// 状态改变事件定义
        /// </summary>
        public event ScanFinishForm.StateChangeHandle opStateChange;
        /// <summary>
        /// 当前等待上传的图片数
        /// </summary>
        private int curWriteUploadFileCount;
        /// <summary>
        /// 等待上传完成的控制器
        /// </summary>
        private System.Threading.Timer writeUploadTimer;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ScanFinishForm()
        {
            InitializeComponent();
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
                ALiProgressManager.Oss_PutObject(PathHelper.LocalSaveScanrecordXmlPath, PathHelper.LocalSaveScanrecordXmlFileName);
                new FileInfo(PathHelper.LocalSaveScanrecordXmlPath).Delete();
            }
            if (!string.IsNullOrEmpty(PathHelper.ScanStatisticsPath))
            {
                if (File.Exists(PathHelper.ScanSaveStatisticsPath))
                {
                    File.Delete(PathHelper.ScanSaveStatisticsPath);
                }

                new FileInfo(PathHelper.ScanStatisticsPath).CopyTo(PathHelper.ScanSaveStatisticsPath);
                ALiProgressManager.Oss_PutObject(PathHelper.ScanSaveStatisticsPath, PathHelper.ScanSaveStatisticsXmlFileName);
                new FileInfo(PathHelper.ScanSaveStatisticsPath).Delete();
            }
            if (!string.IsNullOrEmpty(PathHelper.NormalExamXmlPath))
            {
                if (File.Exists(PathHelper.NormalSaveExamXmlPath))
                {
                    File.Delete(PathHelper.NormalSaveExamXmlPath);
                }

                new FileInfo(PathHelper.NormalExamXmlPath).CopyTo(PathHelper.NormalSaveExamXmlPath);
                ALiProgressManager.Oss_PutObject(PathHelper.NormalSaveExamXmlPath, PathHelper.NormalSaveExamXmlFileName);
                new FileInfo(PathHelper.NormalSaveExamXmlPath).Delete();
            }
            if (!string.IsNullOrEmpty(PathHelper.IncorrectExamXmlPath))
            {
                if (File.Exists(PathHelper.IncorrectSaveExamXmlPath))
                {
                    File.Delete(PathHelper.IncorrectSaveExamXmlPath);
                }

                new FileInfo(PathHelper.IncorrectExamXmlPath).CopyTo(PathHelper.IncorrectSaveExamXmlPath);
                ALiProgressManager.Oss_PutObject(PathHelper.IncorrectSaveExamXmlPath, PathHelper.IncorrectSaveExamXmlFileName);
                new FileInfo(PathHelper.IncorrectSaveExamXmlPath).Delete();
            }

            return true;
        }

        /// <summary>
        /// 上传所有未上传的学生图片，并递归
        /// </summary>
        /// <param name="notUploadFileNameList">未上传的学生试卷名称集合</param>
        /// <param name="frmProgress">进度窗体对象</param>
        private void CheckUploadFile(List<string> notUploadFileNameList, FormProgress frmProgress)
        {
            int currentCount = 0;

            foreach (string imageName in notUploadFileNameList)
            {
                currentCount++;

                Invoke(new MethodInvoker(delegate
                {
                    frmProgress.SetProgress((int)((((double)currentCount) / ((double)notUploadFileNameList.Count)) * 100d), string.Format("共{0}个试卷未上传，正在上传第{1}张试卷...", notUploadFileNameList.Count, currentCount));
                }));
                ALiProgressManager.Oss_PutObject(PathHelper.LocalVolumneImgDir + imageName, imageName);
            }

            List<string> notUploadFileList = new List<string>();

            foreach (string fileName in notUploadFileNameList)
            {
                if (!ALiProgressManager.Oss_ExistObject(fileName))
                {
                    notUploadFileList.Add(fileName);
                }
            }

            if (notUploadFileList != null && notUploadFileList.Count > 0)
            {
                CheckUploadFile(notUploadFileList, frmProgress);
            }
        }

        /// <summary>
        /// 完成的扫描
        /// </summary>
        /// <param name="nextStatus">下一个状态</param>
        private void FinisheScan(OperateStatus nextStatus)
        {
            FormProgress formProgress = new FormProgress();

            formProgress.SetProgress(10, "正在检测网络状态，请稍后...");

            NetWorkStatusEnum nwsEnum = NetWorkHelper.CheckServeStatus();

            switch (nwsEnum)
            {
                case NetWorkStatusEnum.NotConn:
                    formProgress.Close();
                    MessageBox.Show("网络处于断开状态，请检查计算机是否已连接网络...", "提示", MessageBoxButtons.OK);

                    return;
                case NetWorkStatusEnum.ConnException:
                    formProgress.Close();
                    MessageBox.Show("网络未连接或应用程序被禁止访问网络，请检查计算机是否已连接网络，如已连接请查看防火墙是否禁止应用程序访问网络...", "提示", MessageBoxButtons.OK);

                    return;
                case NetWorkStatusEnum.ConnInstability:
                    formProgress.Close();
                    if (MessageBox.Show("当前网络环境不稳定，继续操作可能会造成数据丢失，请确认是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        return;
                    }

                    break;
                case NetWorkStatusEnum.NotSettingSecondLevelTest:
                    formProgress.Close();
                    if (MessageBox.Show("未检测到当前网络状态，继续操作有可能造成数据丢失，请确认是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        return;
                    }

                    break;
            }

            Thread trd = new Thread(new ThreadStart(delegate
            {
                try
                {
                    #region 检测模板信息

                    int schedule = 0;
                    TemplateInfoResponse tiResponse = LoadTplFLoadTemplateFile.GetOnlineTemplateInfo();

                    this.Invoke(new MethodInvoker(delegate
                        {
                            formProgress.SetProgress(schedule, "正在检测模板状态");
                        }));

                    if (!tiResponse.Success)
                    {
                        if (tiResponse.Error != null)
                        {
                            _bdBLL.System_SaveErrorLog(new Exception(tiResponse.Error.Message), tiResponse.Error.Details);
                            throw new Exception(tiResponse.Error.Message);
                        }
                        else
                        {
                            _bdBLL.System_SaveErrorLog(new Exception("获取在线模板出现异常"), "获取在线模板出现异常，详细信息：无");
                            throw new Exception("未检测到模板信息，请上传模板后尝试此操作");
                        }
                    }
                    else if (tiResponse.Data == null || string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetPicPath)
                        || string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetXML) || string.IsNullOrWhiteSpace(tiResponse.Data.AnswerSheetXMLPath))
                    {
                        this.Invoke(new MethodInvoker(delegate
                            {
                                formProgress.SetProgress((schedule += 10), "未检测到在线模板，正在检测本地模板文件...");
                            }));

                        string message = string.Empty;

                        if (LoadTplFLoadTemplateFile.CheckLocalTemplate(ref message))   //检查是否存在本地模板
                        {
                            string[] files = Directory.GetFiles(PathHelper.TpFileDir, "*.*");
                            TemplateInfo tiModel = null;

                            foreach (string fileNaem in files)
                            {
                                int lIndex = fileNaem.LastIndexOf('.');
                                string latFileNaem = string.Empty;

                                if (lIndex > 0)
                                {
                                    latFileNaem = fileNaem.Substring(lIndex);

                                    if (latFileNaem.Equals(".xml"))
                                    {
                                        tiModel = SerializerHelper.DeseriXmlModel<TemplateInfo>(fileNaem);

                                        break;
                                    }
                                }
                            }

                            List<string> imageFileList = new List<string>();

                            if (tiModel != null)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                    {
                                        formProgress.SetProgress((schedule += 5), "正在校验本地模板数据...");
                                    }));

                                foreach (Page p in tiModel.pages)
                                {
                                    int lIndex = p.fileName.LastIndexOf('.');

                                    if (lIndex > 0)
                                    {
                                        string latFileNaem = p.fileName.Substring(lIndex);

                                        if (latFileNaem.Equals(".png"))
                                        {
                                            imageFileList.Add(p.fileName);
                                        }
                                    }
                                }

                                int exitFileCount = 0;

                                foreach (string imageFileName in imageFileList)
                                {
                                    foreach (string tempFile in files)
                                    {
                                        int lIndex = tempFile.LastIndexOf('.');
                                        int fIndex = tempFile.LastIndexOf('\\');

                                        if (lIndex > 0 && fIndex > 0)
                                        {
                                            string latFileNaem = tempFile.Substring(lIndex);
                                            string fileName = tempFile.Substring(fIndex + 1);

                                            if (latFileNaem.Equals(".png") && fileName.Equals(imageFileName))
                                            {
                                                exitFileCount++;
                                            }
                                        }
                                    }
                                }

                                if (exitFileCount == imageFileList.Count)
                                {
                                    formProgress.SetProgress((schedule += 10), "正在上传模板文件...");

                                    foreach (string fileName in files)
                                    {
                                        int fIndex = fileName.LastIndexOf('\\');

                                        if (fIndex > 0)
                                        {
                                            string upladeFileName = fileName.Substring(fIndex + 1);
                                            int lIndex = upladeFileName.LastIndexOf('.');
                                            string pfxName = upladeFileName.Substring(lIndex + 1);

                                            if (pfxName.Equals("png") || pfxName.Equals("xml"))
                                            {
                                                ALiProgressManager.Oss_PutObject(fileName, upladeFileName);
                                            }
                                        }
                                    }

                                    this.Invoke(new MethodInvoker(delegate
                                        {
                                            formProgress.SetProgress((schedule += 5), "正在保存模板数据...");
                                        }));
                                    
                                    ApiResponse ar = _bdBLL.SaveTemplateData(tiModel, string.Format("tpl{0}.{1}", ScanGlobalInfo.ExamInfo.CsID, "xml"));

                                    if (!ar.Success)
                                    {
                                        if (ar.Error != null)
                                        {
                                            throw new Exception(ar.Error.Message);
                                        }
                                        else
                                        {
                                            throw new Exception("尝试上传模板失败，请重新制作并上传模板。");
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception("检测到的本地模板有缺失，请重新制作并上传模板");
                                }
                            }
                            else
                            {
                                throw new Exception("未检测到任何模板信息，请制作模板后进行扫描操作");
                            }
                        }
                        else
                        {
                            throw new Exception("未检测到在线模板，请上传模板后再尝试此操作");
                        }
                    }
                    else
                    {
                        schedule = 30;
                    }

                    #endregion

                    #region 检查已扫描的文件是否已上传完成

                    Invoke(new MethodInvoker(delegate
                    {
                        formProgress.SetProgress(schedule, "正在检查上传状态...");
                    }));

                    curWriteUploadFileCount = UploadFileManagerBLL.Instance.TargetQueue.Count;

                    for (int d = 0; d < curWriteUploadFileCount; )
                    {
                        int curUploadFileCount = UploadFileManagerBLL.Instance.TargetQueue.Count;

                        Invoke(new MethodInvoker(delegate
                        {
                            formProgress.SetProgress(((int)(((double)(curWriteUploadFileCount - curUploadFileCount)) / ((double)curWriteUploadFileCount) * 100d)), string.Format("还有{0}张图片待上传，正在上传第{1}张图片...", curWriteUploadFileCount, (curWriteUploadFileCount - curUploadFileCount)));
                        }));

                        if (curUploadFileCount == 0)
                        {
                            break;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }

                    Invoke(new MethodInvoker(delegate
                    {
                        formProgress.SetProgress(schedule, "正在统计本地文件...");
                    }));

                    List<VolumnDataRow> vdrList = ErrorPageManangerBLL.AllScanVolumnData;
                    List<string> localFileNameList = new List<string>();
                    List<string> notUploadFileNameList = new List<string>();

                    foreach (VolumnDataRow vdr in vdrList)
                    {
                        foreach (string imageName in vdr.Data.ImagePath)
                        {
                            localFileNameList.Add(imageName);
                        }
                    }

                    IEnumerable<string> serverFileName = ALiProgressManager.CheckObjectWithPrefix(string.Concat("E", ScanGlobalInfo.ExamInfo.CsID, "_"));

                    localFileNameList.ForEach(a =>
                    {
                        if (!serverFileName.Contains(a))
                        {
                            notUploadFileNameList.Add(a);
                        }
                    });

                    CheckUploadFile(notUploadFileNameList, formProgress);

                    #endregion

                    this.Invoke(new MethodInvoker(delegate
                    {
                        formProgress.SetProgress((schedule += 10), "正在检查并更新数据...");
                    }));

                    UploadExamXmlData();

                    List<StudentItemPaperInfo> sipisModelList = new List<StudentItemPaperInfo>();

                    foreach (VolumnDataRow vdr in vdrList)
                    {
                        StudentItemPaperInfo sipisModel = new StudentItemPaperInfo();

                        foreach (StudentExamInfo se in ScanGlobalInfo.ExamInfo.StudentExamInfoList)
                        {
                            if (se.ID == vdr.Data.Userid)
                            {
                              //  sipisModel.ESID = (int)se.ID;
                                sipisModel.SCHOOLID = ScanGlobalInfo.loginUser.data.orgid;
                                sipisModel.GRADEID = ScanGlobalInfo.ExamGrade.GradeId;
                                sipisModel.SUBJECTID = ScanGlobalInfo.CurrentSubject;
                                break;
                            }
                        }

                        sipisModel.ESID = vdr.Zkzh;
                        sipisModel.PaperStatus = 0;
                        sipisModel.StuAPPath = string.Join(",", vdr.Data.ImagePath);
                        sipisModel.BatchNum = vdr.Data.BatchId;
                        sipisModel.HistoryErrorStatusList = vdr.HistoryErrorStatusList;

                        List<ObjectItem> oiList = new List<ObjectItem>();

                        foreach (OmrItem oi in vdr.Data.OmrItemList)
                        {
                            ObjectItem oiModel = new ObjectItem();

                            oiModel.questNum = oi.ObjectiveID;

                            if (oi.type != OmrValueType.Confirm)
                            {
                                oiModel.answerHas = 0;

                                continue;
                            }

                            foreach (char answerItem in oi.Answer.ToLower().ToCharArray())
                            {
                                oiModel.stuObjectAnswer += answerItem.ToString().ToUpper();

                                switch (answerItem)
                                {
                                    case 'a':
                                        oiModel.answerHas += 1;
                                        break;
                                    case 'b':
                                        oiModel.answerHas += 2;
                                        break;
                                    case 'c':
                                        oiModel.answerHas += 4;
                                        break;
                                    case 'd':
                                        oiModel.answerHas += 8;
                                        break;
                                    case 'e':
                                        oiModel.answerHas += 16;
                                        break;
                                    case 'f':
                                        oiModel.answerHas += 32;
                                        break;
                                    case 'g':
                                        oiModel.answerHas += 64;
                                        break;
                                    default:
                                        oiModel.answerHas += 0;
                                        break;
                                }
                            }

                            oiList.Add(oiModel);
                        }

                        sipisModel.Exam_Student_Score = oiList.ToArray();

                        sipisModelList.Add(sipisModel);
                    }

                    int bacthUpladeInfoCount = 50;

                    object lockObject = new object();

                    for (int i = 0; i < sipisModelList.Count; )
                    {
                        if ((sipisModelList.Count - i) >= bacthUpladeInfoCount)
                        {
                            List<StudentItemPaperInfo> sipiList = new List<StudentItemPaperInfo>();

                            for (int j = 0; j < bacthUpladeInfoCount; j++)
                            {
                                if (sipisModelList[i + j].HistoryErrorStatusList == null) {
                                    sipisModelList[i + j].HistoryErrorStatusList = new List<ErrorStatus>();
                                }

                                sipiList.Add(sipisModelList[i + j]);

                                
                            }

                            i += bacthUpladeInfoCount;

                            bool flag = false;

                            lock (lockObject)
                            {
                                ApiResponse ar = _bdBLL.Student_SaveExamInfo(sipiList);

                                if (!ar.Success)
                                {
                                    if (ar.Error != null)
                                    {
                                        throw new Exception(ar.Error.Message);
                                    }
                                    else
                                    {
                                        throw new Exception("上传试卷期间出现一个未知错误，请尝试重新上传");
                                    }
                                }
                                else
                                {
                                    flag = true;
                                }
                            }
                            if (flag)
                            {
                                Invoke(new MethodInvoker(delegate
                                {
                                    formProgress.SetProgress((((int)((((float)i) / ((float)vdrList.Count)) * 60f)) + schedule), "正在保存学生试卷，请稍等...");
                                }));
                            }
                        }
                        else
                        {
                            List<StudentItemPaperInfo> sipiList = new List<StudentItemPaperInfo>();

                            for (int j = 0; j < sipisModelList.Count - i; j++)
                            {
                                if (sipisModelList[i + j].HistoryErrorStatusList == null)
                                {
                                    sipisModelList[i + j].HistoryErrorStatusList = new List<ErrorStatus>();
                                }

                                sipiList.Add(sipisModelList[i + j]);
                            }

                            bool flag = false;

                            ApiResponse ar = _bdBLL.Student_SaveExamInfo(sipiList);

                            if (!ar.Success)
                            {
                                if (ar.Error != null)
                                {
                                    throw new Exception(ar.Error.Message);
                                }
                                else
                                {
                                    throw new Exception("上传试卷期间出现一个未知错误，请尝试重新上传");
                                }
                            }
                            else
                            {
                                flag = true;
                            }

                            if (flag)
                            {
                                Invoke(new MethodInvoker(delegate
                                {
                                    formProgress.SetProgress(99, "正在保存学生试卷，请稍等...");
                                }));
                            }

                            break;
                        }
                    }

                    this.Invoke(new MethodInvoker(delegate
                    {
                        formProgress.SetProgress(100, "完成");
                        formProgress.Close();
                    }));

                    this.DialogResult = DialogResult.OK;
                }
                catch (ThreadAbortException ex)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        formProgress.Close();
                        MessageBox.Show("保存终止", "提示");

                        this.Cursor = Cursors.Arrow;
                    }));

                    _bdBLL.System_SaveErrorLog(ex, "保存试卷出现异常");

                    this.DialogResult = DialogResult.Cancel;
                }
                catch (Exception ex)
                {
                    _bdBLL.System_SaveErrorLog(ex, "保存试卷出现异常");

                    this.Invoke(new MethodInvoker(delegate
                    {
                        formProgress.Close();

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }));

                    this.DialogResult = DialogResult.Cancel;
                }
            }));

            FormProgress expr_51 = formProgress;

            expr_51.Cancelhandle = (EventHandler)Delegate.Combine(expr_51.Cancelhandle, new EventHandler(delegate(object obj, EventArgs args)
            {
                trd.Abort();
            }));

            trd.Start();
            formProgress.ShowDialog();

            if (base.DialogResult == DialogResult.OK)
            {
                if (nextStatus == OperateStatus.ScanFinish)
                {
                    if (MessageBox.Show("本科考试已结束扫描,是否继续扫描其它科目？\n”确定“:返回考试列表\n”取消“:退出程序", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) != DialogResult.OK)
                    {
                        Process.GetCurrentProcess().Kill();

                        return;
                    }
                    if (this.opStateChange != null)
                    {
                        this.opStateChange(OperateStatus.ScanFinish);

                        return;
                    }
                }
                //else if (MessageBox.Show("本科考试已结束扫描,即将跳转到上传原卷页面！", "结束扫描", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK && this.opStateChange != null)
                //{
                //    this.opStateChange(OperateStatus.ReUploadMaterials);
                //}
            }
        }

        /// <summary>
        /// 完成扫描按钮点击事件
        /// </summary>
        private void btn_Finish_Click(object sender, EventArgs e)
        {
            this.FinisheScan(OperateStatus.ScanFinish);
        }

        /// <summary>
        /// 完成扫描并上传原卷按钮点击事件
        /// </summary>
        private void btn_FinishAndJumpToUploadMaterials_Click(object sender, EventArgs e)
        {
            this.FinisheScan(OperateStatus.ReUploadMaterials);
        }

        /// <summary>
        /// 窗体调整大小事件
        /// </summary>
        private void ScanFinishForm_Resize(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void ScanFinishForm_Load(object sender, EventArgs e)
        {
            base.Resize += new EventHandler(this.ScanFinishForm_Resize);
        }
    }
}
