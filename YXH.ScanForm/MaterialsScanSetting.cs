using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.OuterInterop;
using YXH.Enum;
using YXH.Twain.Structure;
using YXH.Twain.Structure.Enum;
using YXH.ScanBLL;

namespace YXH.ScanForm
{
    /// <summary>
    /// 扫描材料设置
    /// </summary>
    public partial class MaterialsScanSetting : Form, IMessageFilter
    {
        /// <summary>
        /// 扫描完成委托声明
        /// </summary>
        /// <param name="imageFiles">文件列表</param>
        public delegate void ScanFinished(List<string> imageFiles);
        /// <summary>
        /// 扫描完成委托
        /// </summary>
        public MaterialsScanSetting.ScanFinished onScanFinished;
        /// <summary>
        /// 开始扫描句柄委托
        /// </summary>
        private FOnTransfer _fonTransfer;
        /// <summary>
        /// 结束扫描句柄委托
        /// </summary>
        private FOnEndTransfer _fonEndTransfer;
        /// <summary>
        /// 是双面卡
        /// </summary>
        private bool _isDoubleSide;
        /// <summary>
        /// 支持大小
        /// </summary>
        private SuportSize _pageSize;
        /// <summary>
        /// 临时文件路径
        /// </summary>
        private string tempFilePath = string.Empty;
        /// <summary>
        /// 图片路径列表
        /// </summary>
        private List<string> _imageFiles;
        /// <summary>
        /// 扫描图片数量
        /// </summary>
        private int scanimagecount;
        /// <summary>
        /// 扫描材料类型
        /// </summary>
        private int _matirialsType;

        /// <summary>
        /// 是双面
        /// </summary>
        public bool isDoubleSide
        {
            get
            {
                this._isDoubleSide = this.cb_choosePaper.Checked;

                return this._isDoubleSide;
            }
            set
            {
                this._isDoubleSide = value;
                this.cb_choosePaper.Checked = this._isDoubleSide;
            }
        }

        /// <summary>
        /// 纸张大小
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

                if (value <= SuportSize.TWSS_A3)
                {
                    switch (value)
                    {
                        case SuportSize.TWSS_NONE:
                            this.btn_selfDefine.BackColor = Color.LightBlue;
                            this.gb_PaperLayout.Visible = true;

                            break;
                        case SuportSize.TWSS_A4LETTER:
                            this.A4.BackColor = Color.LightBlue;
                            this.gb_PaperLayout.Visible = false;

                            return;
                        case SuportSize.TWSS_B5LETTER:

                            goto IL_64;
                        case SuportSize.TWSS_USLETTER:
                        case SuportSize.TWSS_USLEGAL:
                        case SuportSize.TWSS_A5:

                            break;
                        case SuportSize.TWSS_B4:

                            goto IL_47;
                        default:
                            if (value != SuportSize.TWSS_A3)
                            {
                                return;
                            }

                            this.A3.BackColor = Color.LightBlue;
                            this.gb_PaperLayout.Visible = false;

                            return;
                    }

                    return;
                }
                if (value == SuportSize.TWSS_ISOB5)
                {
                    goto IL_64;
                }
                if (value != SuportSize.TWSS_JISB4)
                {
                    return;
                }

            IL_47:
                this.B4.BackColor = Color.LightBlue;
                this.gb_PaperLayout.Visible = false;

                return;

            IL_64:
                this.B5.BackColor = Color.LightBlue;
                this.gb_PaperLayout.Visible = false;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="mt">材料类型</param>
        public MaterialsScanSetting(MatirialsType mt)
        {
            InitializeComponent();

            _matirialsType = ((int)mt);
        }

        /// <summary>
        /// 重置按钮背景颜色
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
        /// 开始扫描按钮点击事件
        /// </summary>
        private void btnScan_Click(object sender, EventArgs e)
        {
            Application.AddMessageFilter(this);

            if (!Twain_32.SelectSource())
            {
                MessageBox.Show("请选择扫描仪!");

                return;
            }

            IntPtr currentDsIdentify = Twain_32.GetCurrentDsIdentify();

            if (((TwIdentity)Marshal.PtrToStructure(currentDsIdentify, typeof(TwIdentity))).ProductName.ToUpper().Contains("WIA"))
            {
                MessageBox.Show("不支持WIA设备来源进行扫描");

                return;
            }
            if (Twain_32.OpenSource())
            {
                this._imageFiles = new List<string>();
                this.scanimagecount = 0;

                Twain_32.SetCapParam(258, 0u, 4);
                Twain_32.SetCapParam(4376, 200u, 7);
                Twain_32.SetCapParam(4377, 200u, 7);
                Twain_32.SetCapParam(257, 0u, 4);
                Twain_32.SetCapParam(4386, (uint)Twain_32.GetSupportSize(this.paperSize), 4);
                Twain_32.SetCapParam(4115, this.isDoubleSide ? 1u : 0u, 6);
                Twain_32.Acqurie(this.cb_IsShowAdvanceSetting.Checked);

                return;
            }

            MessageBox.Show("请检查是否连接扫描仪，并确认扫描仪是否处于工作状态。");
        }

        /// <summary>
        /// A3按钮点击事件
        /// </summary>
        private void A3_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_A3;
            this.cb_IsShowAdvanceSetting.Checked = false;
        }

        /// <summary>
        /// A4按钮点击事件
        /// </summary>
        private void A4_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_A4LETTER;
            this.cb_IsShowAdvanceSetting.Checked = false;
        }

        /// <summary>
        /// B4按钮点击事件
        /// </summary>
        private void B4_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_B4;
            this.cb_IsShowAdvanceSetting.Checked = false;
        }

        /// <summary>
        /// B5按钮点击事件
        /// </summary>
        private void B5_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_B5LETTER;
            this.cb_IsShowAdvanceSetting.Checked = false;
        }

        /// <summary>
        /// 自定义按钮点击事件
        /// </summary>
        private void btn_SelfDefine_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_NONE;
            this.cb_IsShowAdvanceSetting.Checked = true;
        }

        /// <summary>
        /// 前置消息过滤
        /// </summary>
        /// <param name="m">消息主体</param>
        /// <returns>过滤结果</returns>
        public bool PreFilterMessage(ref Message m)
        {
            return Twain_32.ProcessMessage(ref m);
        }

        /// <summary>
        /// 旋转图片
        /// </summary>
        /// <param name="src">图片句柄</param>
        /// <param name="degree">旋转角度</param>
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
        /// <param name="hBitmap">源位图</param>
        /// <param name="nbits">图片大小</param>
        /// <param name="img">目标句柄</param>
        private void ReceiveImage(IntPtr hBitmap, int nbits, IntPtr img)
        {
            try
            {
                this.scanimagecount++;

                if (string.IsNullOrEmpty(this.tempFilePath))
                {
                    this.tempFilePath = FileHelper.CreateTempDirectory();
                }

                bool flag = false;

                if (this._pageSize == SuportSize.TWSS_NONE && this.rb_horizontal.Checked)
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
                        if (this.isDoubleSide)
                        {
                            if (this.scanimagecount % 2 == 1)
                            {
                                img = MaterialsScanSetting.RotateImage(img, -90.0);
                            }
                            else
                            {
                                img = MaterialsScanSetting.RotateImage(img, 90.0);
                            }
                        }
                        else
                        {
                            img = MaterialsScanSetting.RotateImage(img, -90.0);
                        }
                    }
                }

                string text = string.Concat(new object[]
                {
                    this.tempFilePath,
                    "\\",
                    ScanGlobalInfo.ExamInfo.CsID,
                    "-",
                    _matirialsType,
                    "-",
                    _imageFiles.Count,
                    ".png"
                });

                if (!ScanlibInterop.SaveImage(img, text))
                {
                    MessageBox.Show("不能保持扫描文件" + text);
                }
                else
                {
                    this._imageFiles.Add(text);
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
                if (this._imageFiles.Count > 0)
                {
                    if (this.onScanFinished != null)
                    {
                        this.onScanFinished(this._imageFiles);
                    }
                    if (this._imageFiles.Count > 0)
                    {
                        base.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        base.DialogResult = DialogResult.No;
                    }
                }
                else
                {
                    MessageBox.Show("没有获取图像，请重新扫描。");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog("扫描获取图片失败，请重新扫描！" + ex.Message, ex);
            }
            finally
            {
                Application.RemoveMessageFilter(this);
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void MaterialsScanSetting_Load(object sender, EventArgs e)
        {
            Twain_32.IntialTwain(base.Handle, 0);

            this._fonTransfer = new FOnTransfer(this.ReceiveImage);

            Twain_32.SetOnTranfer(this._fonTransfer);

            this._fonEndTransfer = new FOnEndTransfer(this.OnEndTransfer);

            Twain_32.SetOnEnd(this._fonEndTransfer);

            this.scanimagecount = 0;
            this.tempFilePath = string.Empty;
            this.paperSize = SuportSize.TWSS_A3;
        }
    }
}
