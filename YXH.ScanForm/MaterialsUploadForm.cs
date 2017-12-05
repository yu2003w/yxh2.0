using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.Form;
using YXH.Enum;
using YXH.HttpHelper.Response;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.ScanForm
{
    /// <summary>
    /// 材料上传
    /// </summary>
    public partial class MaterialsUploadForm : Form
    {
        /// <summary>
        /// 临时文件夹列表
        /// </summary>
        private List<string> tmpfolderList = new List<string>();
        /// <summary>
        /// 当前源记录
        /// </summary>
        private ResourceRecord _curResRecord;
        /// <summary>
        /// 材料类型
        /// </summary>
        private MatirialsType _curOperateMaterialsType;
        /// <summary>
        /// 图片列表
        /// </summary>
        private List<string> imageFiles = new List<string>();
        /// <summary>
        /// 所有高级的
        /// </summary>
        private int totalLimited = 20;
        /// <summary>
        /// 是否继续扫描
        /// </summary>
        private bool IsContinueToScan;
        /// <summary>
        /// 业务操作基础类
        /// </summary>
        private BaseDisposeBLL _bdBll = new BaseDisposeBLL();

        /// <summary>
        /// 当前源记录
        /// </summary>
        public ResourceRecord CurResRecord
        {
            get
            {
                if (this._curResRecord == null)
                {
                    this._curResRecord = new ResourceRecord();
                }

                return this._curResRecord;
            }
            set
            {
                this._curResRecord = value;
            }
        }
        /// <summary>
        /// 材料类型
        /// </summary>
        public MatirialsType CurOperateMaterialsType
        {
            get
            {
                return this._curOperateMaterialsType;
            }
            set
            {
                if (this._curOperateMaterialsType != value)
                {
                    this._curOperateMaterialsType = value;

                    this.InitialBtnStyle();
                    this.imageFiles.Clear();

                    Button button = this.btn_SourcePaper;

                    switch (this._curOperateMaterialsType)
                    {
                        case MatirialsType.EmptyPaper:
                            button = this.btn_EmptyPaper;

                            break;
                        case MatirialsType.AssignMentPlan:
                            button = this.btn_AssignmentPlan;

                            break;
                        case MatirialsType.Answers:
                            button = this.btn_Answer;

                            break;
                        case MatirialsType.SourcePaper:
                            button = this.btn_SourcePaper;

                            break;
                    }

                    this.CurResRecord.examid = ScanGlobalInfo.ExamInfo.ID;
                    this.CurResRecord.tpId = ScanGlobalInfo.ExamInfo.TpFileId;
                    this.CurResRecord.resName = ScanGlobalInfo.ExamInfo.ExamName + button.Text.ToString().Trim() + ".zip";
                    this.CurResRecord.type = (int)this._curOperateMaterialsType;
                    this.CurResRecord.resPath = string.Concat(new object[]
					{
						"TplFile/",
						ScanGlobalInfo.ExamInfo.CsID,
						"/"
					});

                    this.UpdateTargetBtnStyle(button);

                    this.lbl_Restatus.Visible = false;

                    this.RefreshUploadResData(this._curOperateMaterialsType);

                    this.lk_ContinueChoose.Visible = false;
                    this.lk_ContinueScan.Visible = false;
                }
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public MaterialsUploadForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 清除图片列表
        /// </summary>
        private void ClearImageList()
        {
            this.lv_imglist.Items.Clear();
            this.imglist_thumb.Images.Clear();
        }

        /// <summary>
        /// 更新图片列表
        /// </summary>
        /// <param name="imgList">图片列表</param>
        /// <param name="isClearBeforeFile">是否清除缓存的文件</param>
        private void UpdateImageList(List<string> imgList, bool isClearBeforeFile = true)
        {
            this.ClearImageList();

            this.panel_BodyStart.Visible = false;
            this.panel_BodyImgView.Visible = true;
            this.lv_imglist.View = View.LargeIcon;
            this.lv_imglist.MultiSelect = false;

            if (imgList != null && imgList.Count > 0)
            {
                if (this.imageFiles == null)
                {
                    this.imageFiles = new List<string>();
                }
                if (isClearBeforeFile)
                {
                    this.imageFiles.Clear();
                }

                this.imageFiles.AddRange(imgList);

                for (int i = 0; i < this.imageFiles.Count; i++)
                {
                    this.lv_imglist.BeginUpdate();
                    this.lv_imglist.Items.Add(i.ToString());

                    this.lv_imglist.LargeImageList = this.imglist_thumb;
                    this.lv_imglist.LargeImageList.ImageSize = new Size(200, 130);
                    this.lv_imglist.SmallImageList = this.imglist_thumb;

                    this.imglist_thumb.Images.Add(i.ToString(), FileHelper.GetImage(this.imageFiles[i]));

                    this.lv_imglist.Items[i].ImageKey = i.ToString();

                    this.lv_imglist.EndUpdate();
                }

                this.lk_ContinueChoose.Visible = true;
                this.lk_ContinueScan.Visible = true;
            }
        }

        /// <summary>
        /// 刷新上传资源数据
        /// </summary>
        /// <param name="curType">当前材料类型</param>
        private void RefreshUploadResData(MatirialsType curType)
        {
            FormProgress frmProgress = new FormProgress();

            Thread trd = new Thread(new ThreadStart(delegate
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        frmProgress.SetProgress(10, "正在获取已上传资源记录...");
                    }));

                    ZKTemplateInfo zktiModel = ScanGlobalInfo.TemplateInfo;

                    if (zktiModel == null || string.IsNullOrEmpty(zktiModel.AnswerSheetPicPath)
                        || string.IsNullOrEmpty(zktiModel.AnswerSheetXML) || string.IsNullOrEmpty(zktiModel.AnswerSheetXMLPath))
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            this.panel_BodyStart.Visible = true;
                            this.panel_BodyImgView.Visible = false;

                            this.ClearImageList();
                            frmProgress.Close();

                            this.DialogResult = DialogResult.OK;
                            this.lbl_Restatus.Visible = false;
                        }));
                    }
                    else
                    {
                        string text = FileHelper.CreateTempDirectory();

                        this.tmpfolderList.Add(text);

                        List<string> imgFilePaths = new List<string>();
                        string imgFileNameStr = string.Empty;

                        if (_curOperateMaterialsType == MatirialsType.SourcePaper)
                        {
                            imgFileNameStr = zktiModel.ExamPaperPicPath;
                        }
                        else if (_curOperateMaterialsType == MatirialsType.Answers)
                        {
                            imgFileNameStr = zktiModel.ExamQAPicPath;
                        }

                        string[] imageArray = imgFileNameStr.TrimEnd(',').Split(',');
                        int cnt = 0,
                            total = imageArray.Length;

                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.ProgressMaxValue = total;
                            frmProgress.SetProgress(cnt, string.Format("正在下载已上传的图片...{0}/{1}", cnt, total));
                        }));

                        foreach (string current in imageArray)
                        {
                            ALiProgressManager.Oss_GetObject(current, Path.Combine(GlobalInfo.LocalFileLocation, "muban"));
                            imgFilePaths.Add(Path.Combine(Path.Combine(GlobalInfo.LocalFileLocation, "muban"), current));
                            cnt++;
                            this.Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.SetProgress(cnt, string.Format("正在下载已上传的图片...{0}/{1}", cnt, total));
                            }));
                        }

                        this.Invoke(new MethodInvoker(delegate
                        {
                            Application.DoEvents();
                            frmProgress.SetProgress(total, string.Format("已下载完所有图片...{0}/{1}", total, total));

                            this.panel_BodyStart.Visible = false;
                            this.panel_BodyImgView.Visible = true;
                            this.btn_Finish.Visible = false;

                            this.UpdateImageList(imgFilePaths, true);

                            if (curType == MatirialsType.SourcePaper)
                            {
                                this.lbl_Restatus.Visible = true;
                                this.lbl_Restatus.Text = string.Format("原卷状态：{0}", "已上传");

                                if (!string.IsNullOrEmpty(zktiModel.ExamPaperPicPath))
                                {
                                    this.lbl_Restatus.ForeColor = Color.Green;
                                }
                                else
                                {
                                    this.lbl_Restatus.ForeColor = Color.Red;
                                }
                            }

                            frmProgress.Close();

                            this.DialogResult = DialogResult.OK;
                        }));
                    }
                }
                catch (ThreadAbortException)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        frmProgress.Close();
                        MessageBox.Show("下载终止", "提示");

                        this.Cursor = Cursors.Arrow;
                    }));

                    this.DialogResult = DialogResult.Cancel;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteFatalLog(ex.Message, ex);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        frmProgress.Close();
                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }));

                    this.DialogResult = DialogResult.Cancel;
                }
            }));

            FormProgress expr_58 = frmProgress;
            expr_58.Cancelhandle = (EventHandler)Delegate.Combine(expr_58.Cancelhandle, new EventHandler(delegate(object obj, EventArgs args)
            {
                trd.Abort();
            }));

            trd.Start();
            frmProgress.Show();

            if (base.DialogResult == DialogResult.Cancel)
            {
                this.panel_BodyStart.Visible = true;
                this.panel_BodyImgView.Visible = false;
            }
        }

        /// <summary>
        /// 更新目标按钮样式
        /// </summary>
        /// <param name="targetBtn">目标按钮</param>
        private void UpdateTargetBtnStyle(Button targetBtn)
        {
            targetBtn.BackColor = SystemColors.MenuHighlight;
            targetBtn.Font = new Font("宋体", 15f, FontStyle.Bold);
        }

        /// <summary>
        /// 初始化按钮样式
        /// </summary>
        private void InitialBtnStyle()
        {
            this.btn_Answer.BackColor = Color.White;
            this.btn_Answer.Font = new Font("宋体", 9f, FontStyle.Regular);
            this.btn_AssignmentPlan.BackColor = Color.White;
            this.btn_AssignmentPlan.Font = new Font("宋体", 9f, FontStyle.Regular);
            this.btn_EmptyPaper.BackColor = Color.White;
            this.btn_EmptyPaper.Font = new Font("宋体", 9f, FontStyle.Regular);
            this.btn_SourcePaper.BackColor = Color.White;
            this.btn_SourcePaper.Font = new Font("宋体", 9f, FontStyle.Regular);
        }

        /// <summary>
        /// 窗体回收事件
        /// </summary>
        private void MaterialsUploadForm_Disposed(object sender, EventArgs e)
        {
            try
            {
                if (this.tmpfolderList != null && this.tmpfolderList.Count > 0)
                {
                    foreach (string current in this.tmpfolderList)
                    {
                        FileHelper.DeleteDir(current, true);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 初始化按钮可用状态
        /// </summary>
        /// <param name="onlyEnableOthers">可用状态</param>
        private void InitialBtnsEnabled(bool onlyEnableOthers = false)
        {
            this.btn_Answer.Enabled = true;
            this.btn_AssignmentPlan.Enabled = true;
            this.btn_EmptyPaper.Enabled = true;
            this.btn_SourcePaper.Enabled = true;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void MaterialsUploadForm_Load(object sender, EventArgs e)
        {
            if (ScanGlobalInfo.TemplateInfo == null || string.IsNullOrEmpty(ScanGlobalInfo.TemplateInfo.AnswerSheetPicPath) || string.IsNullOrEmpty(ScanGlobalInfo.TemplateInfo.AnswerSheetXML) || string.IsNullOrEmpty(ScanGlobalInfo.TemplateInfo.AnswerSheetXMLPath))
            {
                MessageBox.Show("模板记录有异常，不能执行上传资料操作。请联系客服！");

                return;
            }

            base.Disposed += new EventHandler(this.MaterialsUploadForm_Disposed);

            this.InitialBtnsEnabled(false);

            this.CurOperateMaterialsType = MatirialsType.SourcePaper;
            this.lk_ContinueChoose.Visible = false;
            this.lk_ContinueScan.Visible = false;
        }

        /// <summary>
        /// 分配方案按钮点击事件
        /// </summary>
        private void btn_AssignmentPlan_Click(object sender, EventArgs e)
        {
            this.CurOperateMaterialsType = MatirialsType.AssignMentPlan;
        }

        /// <summary>
        /// 空白答题卡按钮点击事件
        /// </summary>
        private void btn_EmptyPaper_Click(object sender, EventArgs e)
        {
            this.CurOperateMaterialsType = MatirialsType.EmptyPaper;
        }

        /// <summary>
        /// 原卷按钮点击事件
        /// </summary>
        private void btn_SourcePaper_Click(object sender, EventArgs e)
        {
            this.CurOperateMaterialsType = MatirialsType.SourcePaper;
        }

        /// <summary>
        /// 试卷答案按钮点击事件
        /// </summary>
        private void btn_Answer_Click(object sender, EventArgs e)
        {
            this.CurOperateMaterialsType = MatirialsType.Answers;
        }

        /// <summary>
        /// 图片列表退出选中
        /// </summary>
        /// <param name="index">索引</param>
        private void imglistHasBeenSelected(int index)
        {
            FileHelper.GetImage(this.imageFiles[index]);

            PicBoxViewerForm picBoxViewerForm = new PicBoxViewerForm(this.imageFiles, index);

            picBoxViewerForm.ShowDialog();
        }

        /// <summary>
        /// 图片列表选中项事件
        /// </summary>
        private void lv_imglist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lv_imglist.SelectedIndices != null && this.lv_imglist.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection selectedIndices = this.lv_imglist.SelectedIndices;

                this.imglistHasBeenSelected(int.Parse(this.lv_imglist.Items[selectedIndices[0]].ImageKey));
            }
        }

        /// <summary>
        /// 根据扫描更新图片列表
        /// </summary>
        /// <param name="imgFiles">图片文件路径列表</param>
        private void UpdateImageListFromScan(List<string> imgFiles)
        {
            int num = imgFiles.Count;

            if (this.IsContinueToScan)
            {
                num += this.imageFiles.Count;
            }
            if (num > this.totalLimited)
            {
                MessageBox.Show(string.Format("图片总数超过最大{0}张限制，请重试！", this.totalLimited));
                return;
            }

            this.UpdateImageList(imgFiles, !this.IsContinueToScan);

            if (imgFiles != null && imgFiles.Count > 0)
            {
                FileInfo fileInfo = new FileInfo(imgFiles[0]);

                this.tmpfolderList.Add(fileInfo.Directory.FullName);
            }
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        /// <param name="isContinueScan">是否继续扫描</param>
        private void Begin_Scan(bool isContinueScan)
        {
            this.IsContinueToScan = isContinueScan;

            MaterialsScanSetting materialsScanSetting = new MaterialsScanSetting(CurOperateMaterialsType);
            MaterialsScanSetting expr_0E = materialsScanSetting;

            expr_0E.onScanFinished = (MaterialsScanSetting.ScanFinished)Delegate.Combine(expr_0E.onScanFinished, new MaterialsScanSetting.ScanFinished(this.UpdateImageListFromScan));

            if (materialsScanSetting.ShowDialog() == DialogResult.OK && this.imageFiles != null && this.imageFiles.Count > 0)
            {
                this.btn_Finish.Visible = true;
            }
        }

        /// <summary>
        /// 继续扫描链接按钮点击事件
        /// </summary>
        private void lk_ContinueScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.IsContinueToScan = true;

            this.Begin_Scan(true);
        }

        /// <summary>
        /// 继续选择链接按钮点击事件
        /// </summary>
        private void lk_ContinueChoose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.IsContinueToScan = true;

            this.btn_ChooseFile_Click(null, null);
        }

        /// <summary>
        /// 重新选择链接按钮点击事件
        /// </summary>
        private void linklbl_RechooseFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.IsContinueToScan = false;

            this.btn_ChooseFile_Click(null, null);
        }

        /// <summary>
        /// 重新扫描链接按钮点击事件
        /// </summary>
        private void linklbl_Rescan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.IsContinueToScan = false;

            this.btn_Scan_Click(null, null);
        }

        /// <summary>
        /// 选择文件按钮点击事件
        /// </summary>
        private void btn_ChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] fileNames = this.openFileDialog.FileNames;
                    int num = fileNames.Length;

                    if (this.IsContinueToScan)
                    {
                        num += this.imageFiles.Count;
                    }
                    if (num > this.totalLimited)
                    {
                        MessageBox.Show(string.Format("图片总数超过最大{0}张限制，请重试！", this.totalLimited));
                    }
                    else
                    {
                        Array.Sort<string>(fileNames);

                        List<string> list = new List<string>();
                        string text = FileHelper.CreateTempDirectory();

                        this.tmpfolderList.Add(text);

                        for (int i = 0; i < fileNames.Length; i++)
                        {
                            FileInfo fileInfo = new FileInfo(fileNames[i]);
                            string text2 = i + "." + fileInfo.Extension;

                            FileHelper.Copy(fileInfo.FullName, text, text2, true);
                            list.Add(Path.Combine(text, text2));
                        }

                        this.UpdateImageList(list, !this.IsContinueToScan);

                        if (this.imageFiles != null && this.imageFiles.Count > 0)
                        {
                            this.btn_Finish.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常详情：" + ex.Message.ToString());
                LogHelper.WriteFatalLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 扫描上传按钮点击事件
        /// </summary>
        private void btn_Scan_Click(object sender, EventArgs e)
        {
            this.IsContinueToScan = false;

            this.Begin_Scan(false);
        }

        /// <summary>
        /// 上传源数据
        /// </summary>
        /// <param name="targetResRecord">目标源记录</param>
        private void UploadResData(ResourceRecord targetResRecord)
        {
            string localFolder = Path.Combine(GlobalInfo.LocalFileLocation, "muban");

            if (!Directory.Exists(localFolder))
            {
                Directory.CreateDirectory(localFolder);
            }

            FileHelper.DeleteDir(localFolder, false);

            FormProgress frmProgress = new FormProgress();
            Thread trd = new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(0, "正在准备上传...");
                        }));

                        this.CurResRecord.resNames = "";

                        List<string> list = new List<string>();

                        for (int i = 0; i < this.imageFiles.Count; i++)
                        {
                            string text = Path.GetFileName(this.imageFiles[i]),
                                text2 = Path.Combine(localFolder, text);

                            File.Copy(this.imageFiles[i], text2, true);
                            list.Add(text2);

                            this.CurResRecord.resNames = this.CurResRecord.resNames + text + ",";
                        }

                        this.CurResRecord.resNames.TrimEnd(new char[]
                        {
                            ','
                        });

                        int cnt = 0,
                            total = list.Count;

                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.ProgressMaxValue = total;

                            frmProgress.SetProgress(cnt, string.Format("正在上传资料...{0}/{1}", cnt, total));
                        }));

                        foreach (string current in list)
                        {
                            UploadFileManagerBLL.Instance.UploadMaterialsFile(current, Path.GetFileName(current));

                            cnt++;

                            this.Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.SetProgress(cnt, string.Format("正在上传资料...{0}/{1}", cnt, total));
                            }));
                        }

                        ApiResponse ar = null;

                        if (_curOperateMaterialsType == MatirialsType.SourcePaper)
                        {
                            ar = _bdBll.Materials_SaveExamPaperPicPath(targetResRecord.resNames.TrimEnd(','));
                        }
                        else if (_curOperateMaterialsType == MatirialsType.Answers)
                        {
                            ar = _bdBll.Materials_SaveExapQAPicPath(targetResRecord.resNames.TrimEnd(','));
                        }
                        if (ar != null && !ar.Success && ar.Error != null)
                        {
                            throw new Exception(string.Format("{0}{1}{2}", ar.Error.Message, Environment.NewLine, ar.Error.Details));
                        }

                        this.Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.Close();

                                this.DialogResult = DialogResult.OK;
                            }));
                    }
                    catch (ThreadAbortException taEx)
                    {
                        _bdBll.System_SaveErrorLog(taEx, "上传资料线程错误");
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.Close();
                            MessageBox.Show("操作终止", "提示");
                            this.Cursor = Cursors.Arrow;
                        }));

                        this.DialogResult = DialogResult.Cancel;
                    }
                    catch (Exception ex)
                    {
                        _bdBll.System_SaveErrorLog(ex, "上传资料处理错误");
                        this.Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.Close();

                                this.Cursor = Cursors.Arrow;

                                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }));

                        this.DialogResult = DialogResult.Cancel;
                    }
                }));

            FormProgress expr_93 = frmProgress;

            expr_93.Cancelhandle = (EventHandler)Delegate.Combine(expr_93.Cancelhandle, new EventHandler(delegate(object obj, EventArgs args)
            {
                trd.Abort();
            }));

            trd.Start();
            frmProgress.ShowDialog();

            if (base.DialogResult == DialogResult.Cancel)
            {
                this.panel_BodyStart.Visible = true;
                this.panel_BodyImgView.Visible = false;

                return;
            }
            if (base.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("上传资料已完成！");

                this.btn_Finish.Visible = false;
            }
        }

        /// <summary>
        /// 完成按钮点击事件
        /// </summary>
        private void btn_Finish_Click(object sender, EventArgs e)
        {
            this.UploadResData(this.CurResRecord);
        }
    }
}
