using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.OuterInterop;
using YXH.Enum;
using YXH.ScanBLL;
using YXH.Twain.Structure;
using YXH.Twain.Structure.Enum;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 扫描设置
    /// </summary>
    public partial class ScannerSettingForm : Form, IMessageFilter
    {
        /// <summary>
        /// 扫描结束事件
        /// </summary>
        public class ScanFinishedEventArgs : EventArgs
        {
            /// <summary>
            /// 图片列表
            /// </summary>
            public List<string> imageFiles;
            /// <summary>
            /// 页大小
            /// </summary>
            public PageSize pageSize;
            /// <summary>
            /// 识别类型
            /// </summary>
            public OmrType omrType;
            /// <summary>
            /// 是否双面试卷
            /// </summary>
            public bool isDoubleSide;

            /// <summary>
            /// 构造方法
            /// </summary>
            /// <param name="imageFiles">文件列表</param>
            /// <param name="pageSize">大小</param>
            /// <param name="omrType">识别类型</param>
            /// <param name="isDSide">是否双面</param>
            public ScanFinishedEventArgs(List<string> imageFiles, PageSize pageSize, OmrType omrType, bool isDSide)
            {
                this.imageFiles = imageFiles;
                this.pageSize = pageSize;
                this.omrType = omrType;
                this.isDoubleSide = isDSide;
            }
        }

        /// <summary>
        /// 定义扫描完成委托
        /// </summary>
        public delegate void ScanFinished(object sender, ScannerSettingForm.ScanFinishedEventArgs e);
        /// <summary>
        /// 支持大小信息
        /// </summary>
        private SuportSizeInfo SuportSizeMsg;
        /// <summary>
        /// 文件列表
        /// </summary>
        private List<string> imageFiles;
        /// <summary>
        /// 识别类型
        /// </summary>
        private OmrType omrType;
        /// <summary>
        /// 声明扫描完成事件委托
        /// </summary>
        public ScannerSettingForm.ScanFinished onScanFinished;
        /// <summary>
        /// 开始扫描句柄转移委托
        /// </summary>
        private FOnTransfer _fonTransfer;
        /// <summary>
        /// 结束扫描句柄转移委托
        /// </summary>
        private FOnEndTransfer _fonEndTransfer;
        /// <summary>
        /// 是否双面试卷
        /// </summary>
        private bool _isDoubleSide = false;
        /// <summary>
        /// 支持大小
        /// </summary>
        private SuportSize _pageSize;
        /// <summary>
        /// 是创建临时目录
        /// </summary>
        private bool hasCreatedTempDirectory;
        /// <summary>
        /// 临时文件路径
        /// </summary>
        private string tempFilePath;
        /// <summary>
        /// 是否选中源
        /// </summary>
        public bool hasSelectedSource;
        /// <summary>
        /// 是否选中高级设置
        /// </summary>
        private bool _isShowAvancedSetting;
        /// <summary>
        /// 扫描图片数量
        /// </summary>
        private int scanimagecount;
        /// <summary>
        /// 源文件是否来自扫描仪
        /// </summary>
        private bool _isScnaner = true;

        /// <summary>
        /// 是否在真实扫描
        /// </summary>
        public bool _IsInFactScan { get; set; }
        /// <summary>
        /// 支持大小
        /// </summary>
        public SuportSize paperSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                this.ResetButtonBackColor();

                this._pageSize = value;
                this._isShowAvancedSetting = ScanGlobalInfo.IsShowAdvancedSetting;

                if (value <= SuportSize.TWSS_A3)
                {
                    switch (value)
                    {
                        case SuportSize.TWSS_NONE:
                            this.btn_selfDefine.BackColor = Color.LightBlue;
                            this._isShowAvancedSetting = true;
                            this.panComposeType.Visible = true;

                            break;
                        case SuportSize.TWSS_A4LETTER:
                            this.A4.BackColor = Color.LightBlue;
                            this.panComposeType.Visible = false;

                            return;
                        case SuportSize.TWSS_B5LETTER:
                            goto IL_6F;
                        case SuportSize.TWSS_USLETTER:
                        case SuportSize.TWSS_USLEGAL:
                        case SuportSize.TWSS_A5:

                            break;
                        case SuportSize.TWSS_B4:

                            goto IL_52;
                        default:
                            if (value != SuportSize.TWSS_A3)
                            {
                                return;
                            }

                            this.A3.BackColor = Color.LightBlue;
                            this.panComposeType.Visible = false;

                            return;
                    }

                    return;
                }
                if (value == SuportSize.TWSS_ISOB5)
                {
                    goto IL_6F;
                }
                if (value != SuportSize.TWSS_JISB4)
                {
                    return;
                }

            IL_52:
                this.B4.BackColor = Color.LightBlue;
                this.panComposeType.Visible = false;

                return;
            IL_6F:
                this.B5.BackColor = Color.LightBlue;
                this.panComposeType.Visible = false;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public ScannerSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重置按钮背景色
        /// </summary>
        private void ResetButtonBackColor()
        {
            this.A3.BackColor = Color.White;
            this.A4.BackColor = Color.White;
            this.B5.BackColor = Color.White;
            this.B4.BackColor = Color.White;
            this.btn_selfDefine.BackColor = Color.White;
        }

        /// <summary>
        /// 获取图片像素类型
        /// </summary>
        /// <param name="curType">图片源类型</param>
        /// <returns>像素类型</returns>
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
        /// 初始化扫描仪
        /// </summary>
        private void InitializeScanner()
        {
            if (Twain_32.OpenSource())
            {
                this.imageFiles = new List<string>();
                this.scanimagecount = 0;
                this._IsInFactScan = true;

                Twain_32.SetCapParam(258, 0u, 4);
                Twain_32.SetCapParam(4376, 200u, 7);
                Twain_32.SetCapParam(4377, 200u, 7);
                Twain_32.SetCapParam(257, this.getImgPixelType(ScanGlobalInfo.scanImgSourceType), 4);
                Twain_32.SetCapParam(4386, (uint)Twain_32.GetSupportSize(this.paperSize), 4);
                Twain_32.SetCapParam(4115, this._isDoubleSide ? 1u : 0u, 6);
                Twain_32.Acqurie(this._isShowAvancedSetting);

                return;
            }

            this.hasSelectedSource = false;

            MessageBox.Show("请检查是否连接扫描仪，并确认扫描仪是否处于工作状态。");
        }

        /// <summary>
        /// 扫描答题卡
        /// </summary>
        private void ScanAnswerSheet()
        {
            Application.AddMessageFilter(this);

            if (!this.hasSelectedSource)
            {
                if (!Twain_32.SelectSource())
                {
                    MessageBox.Show("请选择扫描仪。");

                    return;
                }

                IntPtr currentDsIdentify = Twain_32.GetCurrentDsIdentify();
                TwIdentity twIdentity = (TwIdentity)Marshal.PtrToStructure(currentDsIdentify, typeof(TwIdentity));

                if (twIdentity.ProductName.ToUpper().Contains("WIA"))
                {
                    MessageBox.Show("不支持WIA设备来源进行扫描");

                    return;
                }

                lblDeviceSourceText.Text = twIdentity.ProductName.ToString();
                this.hasSelectedSource = true;
            }

            this.InitializeScanner();
        }

        /// <summary>
        /// 转换页面大小
        /// </summary>
        /// <param name="size">纸张类型</param>
        /// <returns>页面大小</returns>
        private PageSize ConvertToPageSize(SuportSize size)
        {
            if (size == SuportSize.TWSS_A3)
            {
                return PageSize.A3;
            }
            if (size == SuportSize.TWSS_A4LETTER)
            {
                return PageSize.A4;
            }
            if (size == SuportSize.TWSS_A5)
            {
                return PageSize.A5;
            }
            if (size == SuportSize.TWSS_B4 || size == SuportSize.TWSS_JISB4)
            {
                return PageSize.B4;
            }
            if (size == SuportSize.TWSS_B5LETTER || size == SuportSize.TWSS_ISOB5)
            {
                return PageSize.B5;
            }

            return PageSize.Other;
        }

        /// <summary>
        /// 打开答题卡图片
        /// </summary>
        private void OpenAnswerSheetImage()
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string[] fileNames = this.openFileDialog.FileNames;

            if (this._isDoubleSide && fileNames.Length % 2 != 0)
            {
                MessageBox.Show("您设置了双面答题卡，请选取偶数张图片。");

                return;
            }

            string str = Guid.NewGuid().ToString(),
                text = Path.GetTempPath() + str;

            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }

            this.imageFiles = new List<string>();

            for (int i = 0; i < fileNames.Length; i++)
            {
                string text2 = string.Concat(new object[]
				{
					text,
					"\\tpl",
					string .Format("{0}.{1}", ScanGlobalInfo.ExamInfo.CsID,i),
					".png"
				});

                File.Copy(fileNames[i], text2, true);
                this.imageFiles.Add(text2);
            }
            if (this.imageFiles.Count <= 0)
            {
                return;
            }

            PageSize pageSize = this.ConvertToPageSize(this._pageSize);
            ScannerSettingForm.ScanFinishedEventArgs e = new ScannerSettingForm.ScanFinishedEventArgs(this.imageFiles, pageSize, this.omrType, this._isDoubleSide);

            if (this.onScanFinished != null)
            {
                this.onScanFinished(this, e);
            }
        }

        /// <summary>
        /// 开始扫描按钮点击事件
        /// </summary>
        private void btnScan_Click(object sender, EventArgs e)
        {
            if (_isScnaner)
            {
                this.ScanAnswerSheet();

                return;
            }

            this.OpenAnswerSheetImage();
        }

        /// <summary>
        /// A3按钮点击事件
        /// </summary>
        private void A3_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_A3;
        }

        /// <summary>
        /// A4按钮点击事件
        /// </summary>
        private void A4_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_A4LETTER;
        }

        /// <summary>
        /// B4按钮点击事件
        /// </summary>
        private void B4_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_B4;
        }

        /// <summary>
        /// B5按钮点击事件
        /// </summary>
        private void B5_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_B5LETTER;
        }

        /// <summary>
        /// 自定义按钮点击事件
        /// </summary>
        private void btn_selfDefine_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_NONE;
        }

        /// <summary>
        /// 初始化设置
        /// </summary>
        private void InitialSetting()
        {
            this.paperSize = SuportSize.TWSS_A4LETTER;
        }

        /// <summary>
        /// 创建临时目录
        /// </summary>
        private void CreateTempDirectory()
        {
            if (this.hasCreatedTempDirectory)
            {
                return;
            }

            string str = Guid.NewGuid().ToString();

            this.tempFilePath = Path.GetTempPath() + str;

            if (!Directory.Exists(this.tempFilePath))
            {
                Directory.CreateDirectory(this.tempFilePath);
            }

            this.hasCreatedTempDirectory = true;
        }

        /// <summary>
        /// 旋转图片
        /// </summary>
        /// <param name="src">图片句柄</param>
        /// <param name="degree">选装角度</param>
        /// <returns>旋转后图片句柄</returns>
        public static IntPtr RotateImage(IntPtr src, double degree)
        {
            IntPtr result = ScanlibInterop.RotateImage(src, degree);

            ScanlibInterop.ReleaseImage(src);

            src = IntPtr.Zero;

            return result;
        }

        /// <summary>
        /// 接收图片
        /// </summary>
        /// <param name="hBitmap">位图句柄</param>
        /// <param name="nbits">字节大小</param>
        /// <param name="img">图片句柄</param>
        private void ReceiveImage(IntPtr hBitmap, int nbits, IntPtr img)
        {
            try
            {
                this.scanimagecount++;

                this.CreateTempDirectory();

                bool flag = false;

                if (this._pageSize == SuportSize.TWSS_NONE && lblHorizontal.Image == ScannerSettingFormRes.CheckBox_Selected)
                {
                    flag = true;
                }
                if (this._pageSize == SuportSize.TWSS_A3 || this._pageSize == SuportSize.TWSS_JISB4 || this._pageSize == SuportSize.TWSS_B4 || flag)
                {
                    int num = 0,
                        num2 = 0;
                    bool imageSize = ScanlibInterop.GetImageSize(img, ref num2, ref num);

                    if (!imageSize || num2 < num)
                    {
                        if (this._isDoubleSide)
                        {
                            if (this.scanimagecount % 2 == 1)
                            {
                                img = ScannerSettingForm.RotateImage(img, -90.0);
                            }
                            else
                            {
                                img = ScannerSettingForm.RotateImage(img, 90.0);
                            }
                        }
                        else
                        {
                            img = ScannerSettingForm.RotateImage(img, -90.0);
                        }
                    }
                }

                string text = string.Concat(new object[]
				{
					this.tempFilePath,
					"\\tpl",
                    ScanGlobalInfo.ExamInfo.CsID,
                    ".",
					this.imageFiles.Count,
					".png"
				});

                if (!ScanlibInterop.SaveImage(img, text))
                {
                    MessageBox.Show("不能保持扫描文件" + text);
                }
                else
                {
                    this.imageFiles.Add(text);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);
            }
            finally
            {
                if (img != IntPtr.Zero)
                {
                    ScanlibInterop.ReleaseImage(img);
                }
            }
        }

        /// <summary>
        /// 结束线程
        /// </summary>
        private void OnEndTransfer()
        {
            try
            {
                if (this._IsInFactScan)
                {
                    if (this.imageFiles.Count > 0)
                    {
                        PageSize pageSize = this.ConvertToPageSize(this._pageSize);
                        ScannerSettingForm.ScanFinishedEventArgs e = new ScannerSettingForm.ScanFinishedEventArgs(this.imageFiles, pageSize, this.omrType, this._isDoubleSide);

                        if (this.onScanFinished != null)
                        {
                            this.onScanFinished(this, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有获取图像，请重新扫描答题卡。");
                    }

                    this._IsInFactScan = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog("模板扫描获取图片失败" + ex.Message, ex);
            }
            finally
            {
                Application.RemoveMessageFilter(this);
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void ScannerSettingForm_Load(object sender, EventArgs e)
        {
            this.InitialSetting();
            Twain_32.IntialTwain(base.Handle, 0);

            this._fonTransfer = new FOnTransfer(this.ReceiveImage);

            Twain_32.SetOnTranfer(this._fonTransfer);

            this._fonEndTransfer = new FOnEndTransfer(this.OnEndTransfer);

            Twain_32.SetOnEnd(this._fonEndTransfer);

            //this.radioButtonFile.Visible = ScanGlobalInfo.isOpenCreateTpByImg;
            this._isShowAvancedSetting = ScanGlobalInfo.IsShowAdvancedSetting;
            this.panComposeType.Visible = false;
        }

        /// <summary>
        /// 选取按钮点击事件
        /// </summary>
        private void fromFile_Click(object sender, EventArgs e)
        {
            this.OpenAnswerSheetImage();
        }

        /// <summary>
        /// 前置过滤信息
        /// </summary>
        /// <param name="m">消息体</param>
        /// <returns>过滤状态</returns>
        public bool PreFilterMessage(ref Message m)
        {
            return Twain_32.ProcessMessage(ref m);
        }

        /// <summary>
        /// 选择纸张各个按钮鼠标进入事件
        /// </summary>
        private void SelectPaper_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (sender as Button); ;

            btn.ForeColor = btn.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
        }

        /// <summary>
        /// 选择纸张各个按钮鼠标离开事件
        /// </summary>
        private void SelectPaper_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (sender as Button);

            btn.ForeColor = Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            btn.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        }

        /// <summary>
        /// 双面答题卡点击事件
        /// </summary>
        private void lblDoubleSide_Click(object sender, EventArgs e)
        {
            _isDoubleSide = !_isDoubleSide;

            lblDoubleSide.Image = _isDoubleSide ? ScannerSettingFormRes.CheckBox_Selected : ScannerSettingFormRes.CheckBox_Normal;
        }

        /// <summary>
        /// 点击答题卡填涂类型任意项
        /// </summary>
        private void BlogType_Click(object sender, EventArgs e)
        {
            Label lbl = (sender as Label);

            if (lbl.Image == ScannerSettingFormRes.CheckBox_Selected)
            {
                lbl.Image = ScannerSettingFormRes.CheckBox_Normal;

                if (lbl.Name.Equals("lblBox"))
                {
                    lblBracket.Image = ScannerSettingFormRes.CheckBox_Selected;
                    omrType = OmrType.Bracket;

                    return;
                }

                lblBox.Image = ScannerSettingFormRes.CheckBox_Selected;
                omrType = OmrType.Rect;

                return;
            }

            lbl.Image = ScannerSettingFormRes.CheckBox_Selected;

            if (lbl.Name.Equals("lblBox"))
            {
                lblBracket.Image = ScannerSettingFormRes.CheckBox_Normal;
                omrType = OmrType.Rect;

                return;
            }

            lblBox.Image = ScannerSettingFormRes.CheckBox_Normal;
            omrType = OmrType.Bracket;
        }

        /// <summary>
        /// 点击答题卡排版任意项
        /// </summary>
        private void ComposeType_Click(object sender, EventArgs e)
        {
            if (lblHorizontal.Image == ScannerSettingFormRes.CheckBox_Selected)
            {
                lblHorizontal.Image = ScannerSettingFormRes.CheckBox_Normal;
                lblVertical.Image = ScannerSettingFormRes.CheckBox_Selected;

                return;
            }

            lblHorizontal.Image = ScannerSettingFormRes.CheckBox_Selected;
            lblVertical.Image = ScannerSettingFormRes.CheckBox_Normal;
        }

        /// <summary>
        /// 高级设置按钮点击事件
        /// </summary>
        private void btnAdvancedSetting_Click(object sender, EventArgs e)
        {
            Application.AddMessageFilter(this);

            if (!this.hasSelectedSource)
            {
                if (!Twain_32.SelectSource())
                {
                    MessageBox.Show("请选择扫描仪。");

                    return;
                }

                IntPtr currentDsIdentify = Twain_32.GetCurrentDsIdentify();
                TwIdentity twIdentity = (TwIdentity)Marshal.PtrToStructure(currentDsIdentify, typeof(TwIdentity));

                if (twIdentity.ProductName.ToUpper().Contains("WIA"))
                {
                    MessageBox.Show("不支持WIA设备来源进行扫描");

                    return;
                }

                lblDeviceSourceText.Text = twIdentity.ProductName.ToString();
                this.hasSelectedSource = true;
            }
            if (Twain_32.OpenSource())
            {
                Twain_32.SetCapParam(258, 0u, 4);
                Twain_32.SetCapParam(4376, 200u, 7);
                Twain_32.SetCapParam(4377, 200u, 7);
                Twain_32.SetCapParam(257, this.getImgPixelType(ScanGlobalInfo.scanImgSourceType), 4);
                Twain_32.SetCapParam(4386, (uint)Twain_32.GetSupportSize(this.paperSize), 4);
                Twain_32.SetCapParam(4115, this._isDoubleSide ? 1u : 0u, 6);

                if (!Twain_32.Setup())
                {
                    this.hasSelectedSource = false;

                    return;
                }
            }
            else
            {
                this.hasSelectedSource = false;

                MessageBox.Show("请检查扫描仪是否已开机并正确连接。");
            }
        }
    }
}
