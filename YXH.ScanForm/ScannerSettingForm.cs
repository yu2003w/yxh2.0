using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YXH.Common;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;
using YXH.Twain.Structure;
using YXH.Twain.Structure.Enum;

namespace YXH.ScanForm
{
    /// <summary>
    /// 扫描设置窗体
    /// </summary>
    public partial class ScannerSettingForm : Form, IMessageFilter
    {
        /// <summary>
        /// 扫描设置事件
        /// </summary>
        public class ScanFinishedEventArgs : EventArgs
        {
            /// <summary>
            /// 文件名
            /// </summary>
            public List<string> filename;

            /// <summary>
            /// 构造方法
            /// </summary>
            public ScanFinishedEventArgs()
            {
                this.filename = new List<string>();
            }
        }
        /// <summary>
        /// 扫描完成事件委托定义
        /// </summary>
        public delegate void ScanFinished(object sender, ScannerSettingForm.ScanFinishedEventArgs e);
        /// <summary>
        /// 扫描完成委托声明
        /// </summary>
        public ScannerSettingForm.ScanFinished onScanFinished;
        /// <summary>
        /// 当前窗体静态实例声明
        /// </summary>
        private static ScannerSettingForm _instance;
        /// <summary>
        /// 是否双面
        /// </summary>
        private bool _isDoubleSide;
        /// <summary>
        /// 支持大小
        /// </summary>
        private SuportSize _pageSize;
        /// <summary>
        /// 是否显示设置窗体
        /// </summary>
        private bool _isShowSettingFrm;
        /// <summary>
        /// 图片源类型
        /// </summary>
        private ImgSourceType _curImgSourceType;
        /// <summary>
        /// 是否选中源
        /// </summary>
        public bool hasSelectedSource;
        /// <summary>
        /// 来源是否为扫描仪
        /// </summary>
        private bool _isScaner = true;
        /// <summary>
        /// 是双面试卷
        /// </summary>
        public bool IsDoubleSide
        {
            get
            {
                return _isDoubleSide;
            }
            set
            {
                this._isDoubleSide = value;
                lblChoosePaper.Image = (_isDoubleSide ? ScannerSettingFormRes.CheckBox_Selected_Enable : ScannerSettingFormRes.CheckBox_Normal);
                ScanGlobalInfo.ExamInfo.IsDoubleSide = this._isDoubleSide;
            }
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
        /// 定义当前静态实例
        /// </summary>
        public static ScannerSettingForm Instance
        {
            get
            {
                if (ScannerSettingForm._instance == null)
                {
                    ScannerSettingForm._instance = new ScannerSettingForm();
                }

                return ScannerSettingForm._instance;
            }
            set
            {
                ScannerSettingForm._instance = value;
            }
        }
        /// <summary>
        /// 是水平
        /// </summary>
        public bool isHorizontal = true;
        /// <summary>
        /// 试卷大小
        /// </summary>
        public SuportSize paperSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;

                ScanGlobalInfo.ExamInfo.Papersize = this._pageSize;

                this.ResetButtonBackColor();

                this._pageSize = value;
                this._isShowSettingFrm = ScanGlobalInfo.IsShowAdvancedSetting;

                if (ScanGlobalInfo.ExamInfo.Papersize == SuportSize.TWSS_A3 || ScanGlobalInfo.ExamInfo.Papersize == SuportSize.TWSS_B4
                    || ScanGlobalInfo.ExamInfo.Papersize == SuportSize.TWSS_JISB4
                    || (ScanGlobalInfo.ExamInfo.Papersize == SuportSize.TWSS_NONE && this.isHorizontal))
                {
                    ScanGlobalInfo.ExamInfo.Fdir = 1;
                    ScanGlobalInfo.ExamInfo.Bdir = 3;
                }
                else
                {
                    ScanGlobalInfo.ExamInfo.Fdir = 0;
                    ScanGlobalInfo.ExamInfo.Bdir = 0;
                }
                if (value <= SuportSize.TWSS_A3)
                {
                    switch (value)
                    {
                        case SuportSize.TWSS_NONE:
                            this.btn_selfDefine.BackColor = Color.LightBlue;
                            panTypeSetting.Visible = true;
                            this._isShowSettingFrm = true;

                            break;
                        case SuportSize.TWSS_A4LETTER:
                            this.A4.BackColor = Color.LightBlue;
                            panTypeSetting.Visible = false;

                            return;
                        case SuportSize.TWSS_B5LETTER:

                            goto IL_F1;
                        case SuportSize.TWSS_USLETTER:
                        case SuportSize.TWSS_USLEGAL:
                        case SuportSize.TWSS_A5:

                            break;
                        case SuportSize.TWSS_B4:

                            goto IL_D4;
                        default:
                            if (value != SuportSize.TWSS_A3)
                            {
                                return;
                            }

                            this.A3.BackColor = Color.LightBlue;
                            panTypeSetting.Visible = false;

                            return;
                    }

                    return;
                }
                if (value == SuportSize.TWSS_ISOB5)
                {
                    goto IL_F1;
                }
                if (value != SuportSize.TWSS_JISB4)
                {
                    return;
                }

            IL_D4:
                this.B4.BackColor = Color.LightBlue;
                panTypeSetting.Visible = false;

                return;

            IL_F1:
                this.B5.BackColor = Color.LightBlue;
                panTypeSetting.Visible = false;
            }
        }
        /// <summary>
        /// 是否显示设置窗体
        /// </summary>
        public bool isShowSettingFrm
        {
            get
            {
                return this._isShowSettingFrm;
            }
            set
            {
                this._isShowSettingFrm = value;
            }
        }
        /// <summary>
        /// 图片源类型
        /// </summary>
        public ImgSourceType CurImgSourceType
        {
            get
            {
                return this._curImgSourceType;
            }
            set
            {
                this._curImgSourceType = value;
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
        /// A3按钮点击事件
        /// </summary>
        private void A3_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_A3;
            panTypeSetting.Visible = false;
        }

        /// <summary>
        /// A4按钮点击事件
        /// </summary>
        private void A4_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_A4LETTER;
            panTypeSetting.Visible = false;
        }

        /// <summary>
        /// B4按钮点击事件
        /// </summary>
        private void B4_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_B4;
            panTypeSetting.Visible = false;
        }

        /// <summary>
        /// B5按钮点击事件
        /// </summary>
        private void B5_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_B5LETTER;
            panTypeSetting.Visible = false;
        }

        /// <summary>
        /// 自定义按钮点击事件
        /// </summary>
        private void btn_selfDefine_Click(object sender, EventArgs e)
        {
            this.paperSize = SuportSize.TWSS_NONE;
            panTypeSetting.Visible = true;
        }

        /// <summary>
        /// 获取图片像素类型
        /// </summary>
        /// <param name="curType">当前类型</param>
        /// <returns>类型编号</returns>
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
        /// 高级设置链接按钮点击事件
        /// </summary>
        private void linklbl_AdvancedSetting_LinkClicked(object sender, EventArgs e)
        {
            base.TopMost = false;

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
                Twain_32.SetCapParam(257, this.getImgPixelType(this.CurImgSourceType), 4);
                Twain_32.SetCapParam(4386, (uint)Twain_32.GetSupportSize(this.paperSize), 4);
                Twain_32.SetCapParam(4115, this.IsDoubleSide ? 1u : 0u, 6);
                IntPtr currentDsIdentify = Twain_32.GetCurrentDsIdentify();
                TwIdentity twIdentity = (TwIdentity)Marshal.PtrToStructure(currentDsIdentify, typeof(TwIdentity));

                lblDeviceSourceText.Text = twIdentity.ProductName.ToString();

                if (twIdentity.ProductName.ToUpper().Contains("WIA"))
                {
                    MessageBox.Show("不支持WIA设备来源进行扫描");

                    return;
                }
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

        /// <summary>
        /// 预过滤消息
        /// </summary>
        /// <param name="m">消息体</param>
        /// <returns>过滤结果</returns>
        public bool PreFilterMessage(ref Message m)
        {
            return Twain_32.ProcessMessage(ref m);
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void ScannerSettingForm_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            Application.RemoveMessageFilter(this);

            base.Hide();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void ScannerSettingForm_Load(object sender, EventArgs e)
        {
            Twain_32.IntialTwain(base.Handle, 0);

            this.IsDoubleSide = ScanGlobalInfo.ExamInfo.IsDoubleSide;
            lblChoosePaper.Enabled = false;
        }

        /// <summary>
        /// 根据模板信息更新信息
        /// </summary>
        /// <param name="templateInfo">模板信息</param>
        public void UpdateInfoByTpInfo(TemplateInfo templateInfo)
        {
            int num = templateInfo.pages.Length;

            this.lbl_ImgNum.Text = string.Format("图片数量:{0}", num);

            if (num > 0)
            {
                Bitmap image = FileHelper.GetImage(templateInfo.pages[0].fileName);

                if (image != null)
                {
                    this.lbl_ImgSize.Text = string.Format("图片尺寸:{0}X{1}", image.Width, image.Height);
                }
                else
                {
                    this.lbl_ImgSize.Text = string.Format("图片尺寸:未知", new object[0]);
                }

                string arg;

                switch (templateInfo.pages[0].Size)
                {
                    case PageSize.A4:
                        ScanGlobalInfo.ExamInfo.Papersize = SuportSize.TWSS_A4LETTER;
                        arg = "A4";

                        goto IL_131;
                    case PageSize.A3:
                        ScanGlobalInfo.ExamInfo.Papersize = SuportSize.TWSS_A3;
                        arg = "A3";

                        goto IL_131;
                    case PageSize.A5:
                        ScanGlobalInfo.ExamInfo.Papersize = SuportSize.TWSS_A5;
                        arg = "A5";

                        goto IL_131;
                    case PageSize.B4:
                        ScanGlobalInfo.ExamInfo.Papersize = SuportSize.TWSS_B4;
                        arg = "B4";

                        goto IL_131;
                    case PageSize.B5:
                        ScanGlobalInfo.ExamInfo.Papersize = SuportSize.TWSS_ISOB5;
                        arg = "B5";

                        goto IL_131;
                }

                ScanGlobalInfo.ExamInfo.Papersize = SuportSize.TWSS_NONE;
                arg = "自定义";

            IL_131:
                this.paperSize = ScanGlobalInfo.ExamInfo.Papersize;
                this.lbl_PageSize.Text = string.Format("纸张类型:{0}", arg);
            }

            bool? isDoubleSide = templateInfo.isDoubleSide;

            _isDoubleSide = (isDoubleSide.HasValue ? isDoubleSide.Value : false);

            if (isDoubleSide.HasValue)
            {
                ScanGlobalInfo.ExamInfo.IsDoubleSide = isDoubleSide.Value;
            }
            else if (num > 1)
            {
                ScanGlobalInfo.ExamInfo.IsDoubleSide = true;
            }
            else
            {
                ScanGlobalInfo.ExamInfo.IsDoubleSide = false;
            }

            this.IsDoubleSide = ScanGlobalInfo.ExamInfo.IsDoubleSide;
            this.lbl_IsDoubleSize.Text = string.Format("是否双面:{0}", this.IsDoubleSide ? "是" : "否");
            this.CurImgSourceType = templateInfo.imgSourceType;

            switch (this.CurImgSourceType)
            {
                case ImgSourceType.BW:
                    this.lbl_ImgeMode.Text = string.Format("图片模式:{0}", "黑白");

                    return;
                case ImgSourceType.GRAY:
                    this.lbl_ImgeMode.Text = string.Format("图片模式:{0}", "灰度图");

                    return;
                case ImgSourceType.RGB:
                    this.lbl_ImgeMode.Text = string.Format("图片模式:{0}", "彩色图");

                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// 答题卡排版选项点击事件
        /// </summary>
        private void TypeSettingItems_Click(object sender, EventArgs e)
        {
            Label lblControl = (sender as Label);

            if (lblControl.Name.Equals(lblHorizontal.Name))
            {
                if (lblControl.Image == ScannerSettingFormRes.CheckBox_Selected)
                {
                    lblControl.Image = ScannerSettingFormRes.CheckBox_Normal;
                    lblVertical.Image = ScannerSettingFormRes.CheckBox_Selected;
                    isHorizontal = false;

                    return;
                }

                lblControl.Image = ScannerSettingFormRes.CheckBox_Selected;
                lblVertical.Image = ScannerSettingFormRes.CheckBox_Normal;
                isHorizontal = true;

                return;
            }

            if (lblControl.Image == ScannerSettingFormRes.CheckBox_Selected)
            {
                lblControl.Image = ScannerSettingFormRes.CheckBox_Normal;
                lblHorizontal.Image = ScannerSettingFormRes.CheckBox_Selected;
                isHorizontal = true;

                return;
            }

            lblControl.Image = ScannerSettingFormRes.CheckBox_Selected;
            lblHorizontal.Image = ScannerSettingFormRes.CheckBox_Normal;
            isHorizontal = false;
        }

        /// <summary>
        /// 开始扫描按钮点击事件
        /// </summary>
        private void btnScan_Click(object sender, EventArgs e)
        {
            Application.RemoveMessageFilter(this);

            base.Hide();

            if (_isScaner)
            {
                ScannerSettingForm.ScanFinishedEventArgs e2 = new ScannerSettingForm.ScanFinishedEventArgs();

                if (this.onScanFinished != null)
                {
                    this.onScanFinished(this, e2);
                }
            }
        }
    }
}
