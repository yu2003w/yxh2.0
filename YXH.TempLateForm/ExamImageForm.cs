using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.Form;
using YXH.Enum;
using YXH.HttpHelper.Response;
using YXH.Model;
using YXH.ScanBLL;
using YXH.TemplateBLL;

namespace YXH.TemplateForm
{
    public partial class ExamImageForm : Form
    {
        /// <summary>
        /// 操作改变事件委托
        /// </summary>
        public delegate void OnOpChanged(object sender, ExamImageForm.OpChangedEventArgs e);
        /// <summary>
        /// 操作改变事件声明
        /// </summary>
        public ExamImageForm.OnOpChanged onOpChanged;
        /// <summary>
        /// 操作类型
        /// </summary>
        private OperationType opType;
        /// <summary>
        /// 操作离开
        /// </summary>
        private Dictionary<OperationType, Action> operationLeave;
        /// <summary>
        /// 操作进入
        /// </summary>
        private Dictionary<OperationType, Action> operationEnter;
        /// <summary>
        /// 操作不显示提示贴
        /// </summary>
        private Dictionary<OperationType, bool> operationNotShowTips;
        /// <summary>
        /// 编辑类型
        /// </summary>
        public EditType _editType;
        /// <summary>
        /// 开始扫描事件头
        /// </summary>
        protected EventHandler _startScanEventHandler;
        /// <summary>
        /// 鼠标按下坐标点
        /// </summary>
        private Point _downPoint;
        /// <summary>
        /// 可调整大小的矩形
        /// </summary>
        public ResizableRectangle _activeRect;
        /// <summary>
        /// 自定义内容的操作窗体
        /// </summary>
        private CustomForm _cusForm;
        /// <summary>
        /// 自定义区域的面板
        /// </summary>
        private Panel _cusAreaPanel;
        /// <summary>
        /// 自定义区域的操作内容
        /// </summary>
        public ControlOperationContext _cusOptContext;
        /// <summary>  n
        /// 识别类型
        /// </summary>
        private OmrType omrType;
        /// <summary>
        /// 考号类型
        /// </summary>
        private SchoolNumberType temSchoolNumType;
        /// <summary>
        /// 考号二维码
        /// </summary>
        private QRSchoolNumber temQR;
        /// <summary>
        /// 考号条形码
        /// </summary>
        private BarCodeSchoolNumber temBarcode;
        /// <summary>
        /// 自定义考号区域斑点列表
        /// </summary>
        private OmrSchoolNumber temSchoolomrList;
        /// <summary>
        /// 隐藏区域框选列表
        /// </summary>
        private List<HideArea> _tempHideAcer;
        /// <summary>
        /// 客观题列表
        /// </summary>
        private OmrObjective temObjectiveList;
        /// <summary>
        /// 主观题区域列表
        /// </summary>
        private List<OmrSubjective> _temSubjectiveList;
        /// <summary>
        /// 操作选中区域
        /// </summary>
        private CvRect activeSelectRect;
        /// <summary>
        /// 操作按下标记
        /// </summary>
        private bool activeDownFlag;
        /// <summary>
        /// 编辑模板数组
        /// </summary>
        private OmrArray _editTemplate;
        /// <summary>
        /// omr项斑点排列
        /// </summary>
        private int omritemblobarrange;
        /// <summary>
        /// 项间距
        /// </summary>
        private int itemdistance;
        /// <summary>
        /// 文字识别项间距
        /// </summary>
        private int ocritemdistance;
        /// <summary>
        /// 项大小
        /// </summary>
        private CvRect itemsize;
        /// <summary>
        /// 斑点列表
        /// </summary>
        private List<CvRect> blobList = new List<CvRect>();
        /// <summary>
        /// 题号列表
        /// </summary>
        private List<KeyValue<int, Point>> numList = new List<KeyValue<int, Point>>();
        /// <summary>
        /// 修改对象
        /// </summary>
        private object modifyObject;
        /// <summary>
        /// 修改主观题区域索引(用户一题多框)
        /// </summary>
        private int _modifySubjcetiveAreaIndex;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int currentPageIndex;
        /// <summary>
        /// 模板信息
        /// </summary>
        private TemplateInfo _templateInfo;
        /// <summary>
        /// 图片路径列表
        /// </summary>
        public List<string> imageFilesList = new List<string>();
        /// <summary>
        /// 图片列表
        /// </summary>
        private List<Image> imagesList = new List<Image>();
        /// <summary>
        /// 纸张大小
        /// </summary>
        public PageSize pageSize;
        /// <summary>
        /// 图片分页信息
        /// </summary>
        private List<ImagePage> pages;
        /// <summary>
        /// 当前显示比例
        /// </summary>
        private float zoomRatio = 1f;
        /// <summary>
        /// 无效的按下动作
        /// </summary>
        private bool _invalidDownPoint;
        /// <summary>
        /// 矩形高度
        /// </summary>
        private int rect_height = 20;
        /// <summary>
        /// 矩形宽度
        /// </summary>
        private int rect_wid = 30;
        /// <summary>
        /// 业务层基础类
        /// </summary>
        private BaseDisposeBLL _bdBLL = new BaseDisposeBLL();
        /// <summary>
        /// 处理无效识别项内部类
        /// </summary>
        public class DisplayClass
        {
            public List<int> validNums { get; set; }
        }

        /// <summary>
        /// 操作改变处理
        /// </summary>
        public class OpChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 操作类型
            /// </summary>
            public OperationType op;

            /// <summary>
            /// 操作改变处理
            /// </summary>
            /// <param name="type"></param>
            public OpChangedEventArgs(OperationType type)
            {
                this.op = type;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperationType CurrentOP
        {
            get
            {
                return this.opType;
            }
            set
            {
                if (this.opType != value)
                {
                    if (this.operationLeave.ContainsKey(this.opType) && this.operationLeave[this.opType] != null)
                    {
                        this.operationLeave[this.opType]();
                    }
                    if (this._activeRect != null)
                    {
                        this._activeRect.HideContext();

                        this._activeRect = null;
                        this.modifyObject = null;
                        this._editType = EditType.NONE;

                        this.numList.Clear();
                        this.blobList.Clear();

                        this.temSchoolomrList = null;
                        this.temBarcode = null;
                        this.temQR = null;
                    }

                    this.opType = value;

                    if (this.operationEnter.ContainsKey(value) && this.operationEnter[value] != null)
                    {
                        this.operationEnter[value]();
                    }
                    if (this.onOpChanged != null)
                    {
                        this.onOpChanged(this, new ExamImageForm.OpChangedEventArgs(this.opType));
                    }

                    this.ShowTips();
                    this.pictureBox.Invalidate();
                }
            }
        }

        /// <summary>
        /// 当前考试ID
        /// </summary>
        private string CurrentExamId
        {
            get
            {
                ExamInfo examInfo = ScanGlobalInfo.ExamInfo;

                if (examInfo != null)
                {
                    return examInfo.ID.ToString();
                }

                return "test";
            }
        }

        /// <summary>
        /// 模板本地路径
        /// </summary>
        private string TemplateLocalDir
        {
            get
            {
                return PathHelper.TpFileDir;
            }
        }

        /// <summary>
        /// 自定义的斑点信息
        /// </summary>
        public string _cusBlobInfoStr = string.Empty;
        /// <summary>
        /// 自定义的题号信息
        /// </summary>
        public string _cusNumInfoStr = string.Empty;
        /// <summary>
        /// 是自定义考号
        /// </summary>
        public bool _isCustomAction = false;
        /// <summary>
        /// 编辑类型
        /// </summary>
        public EditType editType;
        /// <summary>
        /// 框选主观题时用来控制输入选项的中继变量
        /// </summary>
        private ResizableRectangle _tempSubjectiveRect;
        /// <summary>
        /// 当前选中的题类型
        /// </summary>
        private int _curTopicType;
        /// <summary>
        /// 当前开始题号
        /// </summary>
        private int _startQid;
        /// <summary>
        /// 当前结束题号
        /// </summary>
        private int _endQid;
        /// <summary>
        /// 客观题区域位图
        /// </summary>
        private Bitmap _cusRegion;
        /// <summary>
        /// 当前选中区域坐标
        /// </summary>
        private CvRect _selectedAreaPoint;
        /// <summary>
        /// 模板的xml文件名称
        /// </summary>
        private string _xmlFileName = string.Empty;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ExamImageForm()
        {
            InitializeComponent();

            this._templateInfo = new TemplateInfo();
            this._activeRect = null;

            this.InitOperationAction();
        }

        /// <summary>
        /// 显示提示贴
        /// </summary>
        private void ShowTips()
        {
            OperationType currentOP = this.CurrentOP;

            if (currentOP != OperationType.DESKEWED_DETECTION || currentOP != OperationType.TITLE || currentOP != OperationType.SCHOOLNUMBER_OMR
                || currentOP != OperationType.HIDEACER || currentOP != OperationType.OBJECTIVE_OMR || currentOP != OperationType.SUBJECTIVE_OMR || currentOP != OperationType.FINISHED)
            {
                return;
            }

            string strMessageLabel = "操作提示：",
                strMessage = string.Empty;

            switch (currentOP)
            {
                case OperationType.DESKEWED_DETECTION:
                    strMessageLabel = "操作提示：请检查预览的图像是否为正立图像";
                    strMessage = "若图像正立，请点击“确认”，进入下一步； 否则可以使用左旋/右旋进行小角度调整，或框选一段水平直线进行水平校正，也可以返回重新选取图片。";

                    break;
                case OperationType.TITLE:
                    strMessage = "请使用鼠标框选试卷的标题，字数最好不少于6个字。";

                    break;
                case OperationType.SCHOOLNUMBER_OMR:
                    strMessage = "请使用鼠标框选考号区域，区域内不要包含汉字。考号区域默认为隐藏区域";

                    break;
                case OperationType.HIDEACER:
                    strMessage = "请使用鼠标框选隐藏区域，隐藏区域在阅卷时将对阅卷人不可见。";

                    break;
                case OperationType.OBJECTIVE_OMR:
                    strMessage = "请使用鼠标框选客观题的题号和选项，区域内不要包含汉字。";

                    break;
                case OperationType.SUBJECTIVE_OMR:
                    strMessage = "请使用鼠标框选主观题区域，每次框选只能包含一个大题。";

                    break;
                case OperationType.FINISHED:
                    strMessage = "请确认模板是否制作完成。请若完成，点击“保存”按钮上传网络。如果您是直接打开现有模板并且修改了模板，也要点击“保存”按键保存模板";

                    break;
            }

            this.labelTips.Text = strMessageLabel + strMessage;
        }

        /// <summary>
        /// 显示提示贴
        /// </summary>
        /// <param name="tips">提示贴信息</param>
        public void ShowTips(string tips)
        {
            this.labelTips.Text = tips;
        }

        /// <summary>
        /// 参数调整
        /// </summary>
        private void OnLeaveAdjust()
        {
            this.btnOK.Visible = false;
            this.returnScan.Visible = false;
        }

        /// <summary>
        /// 客观题识别完成
        /// </summary>
        private void OnLeaveObjectiveOmr()
        {
            this.temObjectiveList = null;
        }

        /// <summary>
        /// 离开主观题识别区域
        /// </summary>
        private void OnLeaveSubjectiveOmr()
        {
            _temSubjectiveList = null;
        }

        /// <summary>
        /// 输入完成
        /// </summary>
        private void OnEnterFinished()
        {
            this.btnSave.Visible = true;
        }

        /// <summary>
        /// 离开完成
        /// </summary>
        private void OnLeaveFinished()
        {
            this.btnSave.Visible = false;
        }

        /// <summary>
        /// 输入调整
        /// </summary>
        private void OnEnterAdjust()
        {
            this.returnScan.Visible = true;
            this.btnOK.Visible = true;
        }

        /// <summary>
        /// 初始化操作参数
        /// </summary>
        private void InitOperationAction()
        {
            this.operationLeave = new Dictionary<OperationType, Action>();
            this.operationEnter = new Dictionary<OperationType, Action>();
            this.operationNotShowTips = new Dictionary<OperationType, bool>();
            this.operationLeave[OperationType.DESKEWED_DETECTION] = new Action(this.OnLeaveAdjust);
            this.operationLeave[OperationType.OBJECTIVE_OMR] = new Action(this.OnLeaveObjectiveOmr);
            operationLeave[OperationType.SUBJECTIVE_OMR] = new Action(OnLeaveSubjectiveOmr);
            this.operationLeave[OperationType.FINISHED] = new Action(this.OnLeaveFinished);
            this.operationEnter[OperationType.DESKEWED_DETECTION] = new Action(this.OnEnterAdjust);
            this.operationEnter[OperationType.FINISHED] = new Action(this.OnEnterFinished);
            this.operationNotShowTips[OperationType.DESKEWED_DETECTION] = false;
            this.operationNotShowTips[OperationType.TITLE] = false;
            this.operationNotShowTips[OperationType.SCHOOLNUMBER_OMR] = false;
            operationNotShowTips[OperationType.FINISHED] = false;
            this.operationNotShowTips[OperationType.OBJECTIVE_OMR] = false;
            operationNotShowTips[OperationType.SUBJECTIVE_OMR] = false;
            this.operationNotShowTips[OperationType.FINISHED] = false;
        }

        /// <summary>
        /// 打底Panel滚动事件
        /// </summary>
        private void formPanel_Scroll(object sender, ScrollEventArgs e)
        {
            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 绘制数字
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="numList">数字列表</param>
        /// <param name="color">画笔颜色</param>
        private void PaintNum(Graphics Graphics, List<KeyValue<int, Point>> numList, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            Font font = new Font(this.Font.FontFamily, 20f * this.zoomRatio, FontStyle.Bold);

            foreach (KeyValue<int, Point> current in numList)
            {
                Graphics.DrawString(current.Key.ToString(), font, brush, (float)current.Value.X * this.zoomRatio, (float)current.Value.Y * this.zoomRatio);
            }
        }

        /// <summary>
        /// 绘制斑点
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="blobList">斑点列表</param>
        /// <param name="color">画笔颜色</param>
        private void PaintBlobs(Graphics Graphics, List<CvRect> blobList, Color color)
        {
            SolidBrush brush = new SolidBrush(color);

            foreach (CvRect current in blobList)
            {
                Graphics.DrawRectangle(new Pen(brush, 2f), (float)current.x * this.zoomRatio, (float)current.y * this.zoomRatio, (float)current.width * this.zoomRatio, (float)current.height * this.zoomRatio);
            }
        }

        /// <summary>
        /// 绘制标题区域
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="temTitleMatch">标题匹配区域</param>
        /// <param name="color">画笔颜色</param>
        private void PaintTitle(Graphics Graphics, TitleLocal temTitleMatch, Color color)
        {
            float x = (float)temTitleMatch.matchRegion.x * this.zoomRatio,
                y = (float)temTitleMatch.matchRegion.y * this.zoomRatio,
                num = (float)temTitleMatch.matchRegion.width * this.zoomRatio,
                num2 = (float)temTitleMatch.matchRegion.height * this.zoomRatio;

            if (num > 0f && num2 > 0f)
            {
                Graphics.DrawRectangle(new Pen(color), x, y, num, num2);
            }
        }

        /// <summary>
        /// 绘制二维码学号
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="QRSchoolNumBlob">二维码学号斑点信息</param>
        /// <param name="color">画笔颜色</param>
        private void PaintQRSchoolNum(Graphics Graphics, QRSchoolNumber QRSchoolNumBlob, Color color)
        {
            float x = (float)QRSchoolNumBlob.region.x * this.zoomRatio,
                y = (float)QRSchoolNumBlob.region.y * this.zoomRatio,
                num = (float)QRSchoolNumBlob.region.width * this.zoomRatio,
                num2 = (float)QRSchoolNumBlob.region.height * this.zoomRatio;

            if (num > 0f && num2 > 0f)
            {
                Graphics.DrawRectangle(new Pen(color), x, y, num, num2);
            }
        }

        /// <summary>
        /// 绘制条形码学号
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="BarCodeSchoolNumBlob">条形码学号斑点信息</param>
        /// <param name="color">画笔颜色</param>
        private void PaintBarCodeSchoolNum(Graphics Graphics, BarCodeSchoolNumber BarCodeSchoolNumBlob, Color color)
        {
            float x = (float)BarCodeSchoolNumBlob.region.x * this.zoomRatio,
                y = (float)BarCodeSchoolNumBlob.region.y * this.zoomRatio,
                num = (float)BarCodeSchoolNumBlob.region.width * this.zoomRatio,
                num2 = (float)BarCodeSchoolNumBlob.region.height * this.zoomRatio;

            if (num > 0f && num2 > 0f)
            {
                Graphics.DrawRectangle(new Pen(color), x, y, num, num2);
            }
        }

        /// <summary>
        /// 绘制自定义考号区域
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="OmrSchoolNumBlob">自定义考号区域信息</param>
        /// <param name="color">画笔颜色</param>
        private void PaintOmrSchoolNum(Graphics Graphics, OmrSchoolNumber OmrSchoolNumBlob, Color color)
        {
            Font font = new Font(this.Font.FontFamily, 20f * this.zoomRatio, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(color);

            Graphics.DrawRectangle(new Pen(color, 2f)
            {
                DashStyle = DashStyle.Dot
            },
            (float)OmrSchoolNumBlob.region.x * this.zoomRatio,
            (float)OmrSchoolNumBlob.region.y * this.zoomRatio,
            (float)OmrSchoolNumBlob.region.width * this.zoomRatio,
            (float)OmrSchoolNumBlob.region.height * this.zoomRatio);

            for (int i = 0; i < OmrSchoolNumBlob.omrs.Count; i++)
            {
                for (int j = 0; j < OmrSchoolNumBlob.omrs[i].Length; j++)
                {
                    CvRect cvRect = OmrSchoolNumBlob.omrs[i][j];

                    Graphics.DrawString(j.ToString(), font, brush, ((float)cvRect.x + (float)(cvRect.width - cvRect.height) * 0.5f) * this.zoomRatio, (float)cvRect.y * this.zoomRatio);
                    Graphics.DrawRectangle(new Pen(brush, 2f), (float)cvRect.x * this.zoomRatio, (float)cvRect.y * this.zoomRatio, (float)cvRect.width * this.zoomRatio, (float)cvRect.height * this.zoomRatio);
                }

                CvRect cvRect2 = OmrSchoolNumBlob.omrs[i][0];
                float x = ((float)cvRect2.x + (float)(cvRect2.width - cvRect2.height) * 0.5f) * this.zoomRatio,
                    y = (float)(cvRect2.y - cvRect2.height * 2) * this.zoomRatio;

                Graphics.DrawString(i.ToString(), font, brush, x, y);
            }
        }

        /// <summary>
        /// 绘制主观题区域
        /// </summary>
        /// <param name="gps">画板</param>
        /// <param name="cr">主观题区域信息</param>
        /// <param name="color">画笔颜色</param>
        private void PaintOmrSubjective(Graphics gps, CvRect cr, Color color)
        {
            float x = (float)cr.x * this.zoomRatio,
                y = (float)cr.y * this.zoomRatio,
                num = (float)cr.width * this.zoomRatio,
                num2 = (float)cr.height * this.zoomRatio;

            if (num > 0f && num2 > 0f)
            {
                gps.DrawRectangle(new Pen(color), x, y, num, num2);
            }
        }

        /// <summary>
        /// 绘制隐藏区域
        /// </summary>
        /// <param name="gps">画板</param>
        /// <param name="cr">主观题区域信息</param>
        /// <param name="color">画笔颜色</param>
        private void PaintHideArea(Graphics gps, CvRect cr, Color color)
        {
            float x = (float)cr.x * this.zoomRatio,
                y = (float)cr.y * this.zoomRatio,
                num = (float)cr.width * this.zoomRatio,
                num2 = (float)cr.height * this.zoomRatio;

            if (num > 0f && num2 > 0f)
            {
                gps.DrawRectangle(new Pen(color), x, y, num, num2);
            }
        }

        /// <summary>
        /// 绘制客观题区域
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="obeItem">客观题区域信息</param>
        /// <param name="color">画笔颜色</param>
        private void PaintOmrObjective(Graphics Graphics, OmrObjective obeItem, Color color)
        {
            Font font = new Font(this.Font.FontFamily, 20f * this.zoomRatio, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(color);
            OmrObjectiveItem[] objectiveItems = obeItem.objectiveItems;

            for (int i = 0; i < objectiveItems.Length; i++)
            {
                OmrObjectiveItem omrObjectiveItem = objectiveItems[i];
                CvRect cvRect = default(CvRect);
                Num num = omrObjectiveItem.num;
                List<CvRect> list = omrObjectiveItem.ItemRects.ToList<CvRect>();
                Point point = (this.omritemblobarrange == 0) ? new Point(num.pos.X, num.pos.Y) : new Point(num.pos.X, num.pos.Y);

                cvRect.x = point.X - 5;
                cvRect.y = point.Y - 5;

                Graphics.DrawString(num.number.ToString(), font, brush, (float)point.X * this.zoomRatio, (float)point.Y * this.zoomRatio);

                foreach (CvRect current in list)
                {
                    if (cvRect.x >= current.x)
                    {
                        cvRect.x = current.x - 5;
                    }
                    if (cvRect.y >= current.y)
                    {
                        cvRect.y = current.y - 5;
                    }
                    if (cvRect.y + cvRect.height <= current.y + current.height)
                    {
                        cvRect.height = current.y + current.height - cvRect.y + 5;
                    }
                    if (cvRect.x + cvRect.width <= current.x + current.width)
                    {
                        cvRect.width = current.x + current.width - cvRect.x + 5;
                    }

                    Graphics.DrawRectangle(new Pen(brush, 2f), (float)current.x * this.zoomRatio, (float)current.y * this.zoomRatio, (float)current.width * this.zoomRatio, (float)current.height * this.zoomRatio);
                }

                Graphics.DrawRectangle(new Pen(brush, 2f)
                {
                    DashStyle = DashStyle.Dot
                },
                (float)cvRect.x * this.zoomRatio,
                (float)cvRect.y * this.zoomRatio,
                (float)cvRect.width * this.zoomRatio,
                (float)cvRect.height * this.zoomRatio);
            }
        }

        /// <summary>
        /// 绘制模板信息
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="model">模板信息</param>
        /// <param name="color">画笔颜色</param>
        private void PaintTemplateInfo(Graphics Graphics, TemplateInfo model, Color color)
        {
            Page curPage = model.pages[this.currentPageIndex];

            if (curPage.localRegion != null && (this.modifyObject == null || !this.modifyObject.Equals(curPage.localRegion)))
            {
                this.PaintTitle(Graphics, curPage.localRegion, color);
            }
            if (curPage.QRSchoolNumBlob != null && (this.modifyObject == null || !this.modifyObject.Equals(curPage.QRSchoolNumBlob)))
            {
                this.PaintQRSchoolNum(Graphics, curPage.QRSchoolNumBlob, color);
            }
            if (curPage.BarCodeSchoolNumBlob != null && (this.modifyObject == null || !this.modifyObject.Equals(curPage.BarCodeSchoolNumBlob)))
            {
                this.PaintBarCodeSchoolNum(Graphics, curPage.BarCodeSchoolNumBlob, color);
            }
            if (curPage.OmrSchoolNumBlob != null && (this.modifyObject == null || !this.modifyObject.Equals(curPage.OmrSchoolNumBlob)))
            {
                this.PaintOmrSchoolNum(Graphics, curPage.OmrSchoolNumBlob, color);
            }
            if (curPage.HideAreaList != null && curPage.HideAreaList.Count > 0)
            {
                foreach (HideArea ha in curPage.HideAreaList)
                {
                    if (modifyObject == null || !modifyObject.Equals(ha))
                    {
                        PaintHideArea(Graphics, ha.HideAreaRect, color);
                    }
                }
            }
            if (curPage.OmrObjectives != null && curPage.OmrObjectives.Length > 0)
            {
                for (int i = 0; i < curPage.OmrObjectives.Length; i++)
                {
                    if (this.modifyObject == null || !this.modifyObject.Equals(curPage.OmrObjectives[i]))
                    {
                        this.PaintOmrObjective(Graphics, curPage.OmrObjectives[i], color);
                    }
                }
            }
            if (curPage.OmrSubjectiveList != null && curPage.OmrSubjectiveList.Count > 0)
            {
                for (int i = 0; i < curPage.OmrSubjectiveList.Count; i++)
                {
                    if (modifyObject == null || !modifyObject.Equals(curPage.OmrSubjectiveList[i]))
                    {
                        foreach (CvRect cr in curPage.OmrSubjectiveList[i].regionList)
                        {
                            PaintOmrSubjective(Graphics, cr, color);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绘制编辑模板
        /// </summary>
        /// <param name="Graphics">画板</param>
        /// <param name="info">识别列表</param>
        /// <param name="color">画笔颜色</param>
        private void PaintEditTemplate(Graphics Graphics, OmrArray info, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            Font font = new Font(this.Font.FontFamily, 20f * this.zoomRatio, FontStyle.Bold);

            Graphics.DrawRectangle(new Pen(brush, 2f)
            {
                DashStyle = DashStyle.DashDot
            },
            (float)info.SelectRegion.x * this.zoomRatio,
            (float)info.SelectRegion.y * this.zoomRatio,
            (float)info.SelectRegion.width * this.zoomRatio,
            (float)info.SelectRegion.height * this.zoomRatio);

            if (info.num != null)
            {
                Graphics.DrawString(info.num.number.ToString(), font, brush, (float)info.num.pos.X * this.zoomRatio, (float)info.num.pos.Y * this.zoomRatio);
            }
            if (info.Items != null)
            {
                for (int i = 0; i < info.Items.Length; i++)
                {
                    Graphics.DrawRectangle(new Pen(brush, 2f), (float)info.Items[i].x * this.zoomRatio, (float)info.Items[i].y * this.zoomRatio, (float)info.Items[i].width * this.zoomRatio, (float)info.Items[i].height * this.zoomRatio);
                }
            }
        }

        /// <summary>
        /// 绘制操作矩形区域
        /// </summary>
        /// <param name="g">画板</param>
        private void DrawActiveRect(Graphics g)
        {
            if (this._activeRect == null)
            {
                return;
            }

            Rectangle rect = this._activeRect.GetRect(),
                mappedRect = ResizableRectangle.GetMappedRect(new Rectangle
                {
                    X = Math.Min(rect.Left, rect.Right),
                    Y = Math.Min(rect.Top, rect.Bottom),
                    Width = Math.Abs(rect.Left - rect.Right),
                    Height = Math.Abs(rect.Top - rect.Bottom)
                }, this.zoomRatio);

            if (mappedRect.Width > 0 && mappedRect.Height > 0)
            {
                PictureBox pictureBox = this.pictureBox;
                Rectangle rect2 = new Rectangle(0, 0, pictureBox.Width, mappedRect.Y),
                    rect3 = new Rectangle(0, mappedRect.Bottom, pictureBox.Width, pictureBox.Height - mappedRect.Bottom),
                    rect4 = new Rectangle(0, mappedRect.Y, mappedRect.X, mappedRect.Height),
                    rect5 = new Rectangle(mappedRect.Right, mappedRect.Y, pictureBox.Width - mappedRect.Right, mappedRect.Height);
                SolidBrush brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0));

                g.FillRectangle(brush, rect2);
                g.FillRectangle(brush, rect3);
                g.FillRectangle(brush, rect4);
                g.FillRectangle(brush, rect5);
            }

            this._activeRect.Paint(g, this.zoomRatio);
        }

        /// <summary>
        /// 图片框绘制事件
        /// </summary>
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.activeSelectRect.height > 0 && this.activeSelectRect.width > 0)
            {
                e.Graphics.DrawRectangle(new Pen(Brushes.Red, 2f), (float)this.activeSelectRect.x * this.zoomRatio, (float)this.activeSelectRect.y * this.zoomRatio, (float)this.activeSelectRect.width * this.zoomRatio, (float)this.activeSelectRect.height * this.zoomRatio);
            }
            if (this.numList.Count > 0)
            {
                this.PaintNum(e.Graphics, this.numList, Color.Red);
            }
            if (this.blobList.Count > 0)
            {
                this.PaintBlobs(e.Graphics, this.blobList, Color.Red);
            }
            if (this._templateInfo != null)
            {
                this.PaintTemplateInfo(e.Graphics, this._templateInfo, Color.Blue);
            }
            if (this._editTemplate != null)
            {
                this.PaintEditTemplate(e.Graphics, this._editTemplate, Color.Blue);
            }

            this.DrawActiveRect(e.Graphics);
        }

        /// <summary>
        /// 调整操作类型
        /// </summary>
        /// <returns>操作结果</returns>
        private bool IsResizeOperaitonType()
        {
            bool flag = CurrentOP == OperationType.DESKEWED_DETECTION || CurrentOP == OperationType.TITLE || CurrentOP == OperationType.SCHOOLNUMBER_OMR
                || CurrentOP == OperationType.HIDEACER || CurrentOP == OperationType.OBJECTIVE_OMR || CurrentOP == OperationType.SUBJECTIVE_OMR
                || CurrentOP == OperationType.FINISHED;

            return flag && this._editType == EditType.NONE;
        }

        /// <summary>
        /// 获取修改对象
        /// </summary>
        /// <param name="clikpoint">点击坐标</param>
        /// <returns>选中对象</returns>
        private object GetModifyObject(Point clikpoint)
        {
            if (this._templateInfo != null)
            {
                Page modifyPage = this._templateInfo.pages[this.currentPageIndex];

                if (modifyPage.localRegion != null && TemplateInfoGenerater.Instance.CheckPosInRect(clikpoint, modifyPage.localRegion.matchRegion))
                {
                    return modifyPage.localRegion;
                }
                if (modifyPage.QRSchoolNumBlob != null && TemplateInfoGenerater.Instance.CheckPosInRect(clikpoint, modifyPage.QRSchoolNumBlob.region))
                {
                    return modifyPage.QRSchoolNumBlob;
                }
                if (modifyPage.BarCodeSchoolNumBlob != null && TemplateInfoGenerater.Instance.CheckPosInRect(clikpoint, modifyPage.BarCodeSchoolNumBlob.region))
                {
                    return modifyPage.BarCodeSchoolNumBlob;
                }
                if (modifyPage.OmrSchoolNumBlob != null && TemplateInfoGenerater.Instance.CheckPosInRect(clikpoint, modifyPage.OmrSchoolNumBlob.region))
                {
                    return modifyPage.OmrSchoolNumBlob;
                }
                if (modifyPage.HideAreaList != null)
                {
                    for (int a = 0; a < modifyPage.HideAreaList.Count; a++)
                    {
                        if (TemplateInfoGenerater.Instance.CheckPosInRect(clikpoint, modifyPage.HideAreaList[a].HideAreaRect))
                        {
                            return modifyPage.HideAreaList[a];
                        }
                    }
                }
                if (modifyPage.OmrObjectives != null && modifyPage.OmrObjectives.Length > 0)
                {
                    for (int i = 0; i < modifyPage.OmrObjectives.Length; i++)
                    {
                        if (TemplateInfoGenerater.Instance.CheckPosInRect(clikpoint, modifyPage.OmrObjectives[i].region))
                        {
                            return modifyPage.OmrObjectives[i];
                        }
                    }
                }
                if (modifyPage.OmrSubjectiveList != null && modifyPage.OmrSubjectiveList.Count > 0)
                {
                    for (int i = 0; i < modifyPage.OmrSubjectiveList.Count; i++)
                    {
                        bool isInclude = false;

                        for (int a = 0; a < modifyPage.OmrSubjectiveList[i].regionList.Count; a++)
                        {
                            if (TemplateInfoGenerater.Instance.CheckPosInRect(clikpoint, modifyPage.OmrSubjectiveList[i].regionList[a]))
                            {
                                isInclude = true;
                                _modifySubjcetiveAreaIndex = a;

                                break;
                            }
                        }

                        if (isInclude)
                        {
                            return modifyPage.OmrSubjectiveList[i];
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 平衡卷面
        /// </summary>
        /// <param name="sender">事件对象</param>
        private void BalancePage(object sender)
        {
            ResizableRectangle resizableRectangle = (sender as Button).Tag as ResizableRectangle;
            Rectangle rect = resizableRectangle.GetRect();
            CvRect selectArea = new CvRect(rect.X, rect.Y, rect.Width, rect.Height);

            _activeRect.HideContext();
            _activeRect = null;
            modifyObject = null;

            if (selectArea.width == 0 || selectArea.height == 0)
            {
                MessageBox.Show("请选择框选区域");

                return;
            }

            try
            {
                TemplateInfoGenerater.Instance.DeskewedImageByLine(selectArea, this.currentPageIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("倾斜纠正失败");
                LogHelper.WriteFatalLog(ex.Message, ex);
            }

            pictureBox.Image.Dispose();

            pictureBox.Image = FileHelper.GetImage(imageFilesList[currentPageIndex]);
            imagesList[currentPageIndex] = pictureBox.Image;

            pictureBox.Invalidate();

            if (imageFilesList.Count > 1)
            {
                ShowTips("已对页面进行校正，请使用“上一页/下一页”切换到别的页面进行校正操作，确保所有的页面都调成水平。");
            }
        }

        /// <summary>
        /// 根据水平直线调平页面按钮点击事件
        /// </summary>
        private void OnAdjust_DoAdjust(object sender, EventArgs e)
        {
            BalancePage(sender);
        }

        /// <summary>
        /// 调平区删除按钮点击事件
        /// </summary>
        private void OnAdjust_Delete(object sender, EventArgs e)
        {
            Button button = sender as Button;
            object arg_0D_0 = button.Tag;

            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;

            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 创建调平可调区域
        /// </summary>
        /// <param name="rect">可调矩形</param>
        /// <returns>操作内容</returns>
        private OperationContext CreateAdjustContext(ResizableRectangle rect)
        {
            OperationContext operationContext = new OperationContext(OperationType.DESKEWED_DETECTION, this.pictureboxPanel, rect, "");

            operationContext.AddVOperation(new OperationContext.Operation[]
			{
				new OperationContext.Operation
				{
					Title = "水平线校正",
					Click = new EventHandler(this.OnAdjust_DoAdjust),
					image =ExamImageFormRes.ConfirmButtonImage
				},
				new OperationContext.Operation
				{
					Title = "删除",
					Click = new EventHandler(this.OnAdjust_Delete),
					image = ExamImageFormRes.CloseButtonImage
				}
			});

            return operationContext;
        }

        /// <summary>
        /// 标题区域保存按钮点击事件
        /// </summary>
        private void OnTitle_Save(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ResizableRectangle resizableRectangle = button.Tag as ResizableRectangle;
            Rectangle rect = resizableRectangle.GetRect();
            CvRect titleMatch = new CvRect(rect.X, rect.Y, rect.Width, rect.Height);

            if (titleMatch.width == 0 || titleMatch.height == 0 || titleMatch.width <= 5)
            {
                MessageBox.Show("文字定位点长度或宽度不足");

                return;
            }

            try
            {
                titleMatch = TemplateInfoGenerater.Instance.GetTitleMatch(titleMatch, this.currentPageIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("文字定位点识别失败:" + ex.Message);

                return;
            }

            this._templateInfo.pages[this.currentPageIndex].localRegion = new TitleLocal(titleMatch);
            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            this.CurrentOP = OperationType.SCHOOLNUMBER_OMR;

            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 标题区域删除按钮点击事件
        /// </summary>
        private void OnTitle_Delete(object sender, EventArgs e)
        {
            Button button = sender as Button;
            object arg_0D_0 = button.Tag;
            this._activeRect.HideContext();
            this._activeRect = null;
            this.modifyObject = null;
            this._editType = EditType.NONE;
            this._templateInfo.pages[this.currentPageIndex].localRegion = null;
            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 创建标题可调区域
        /// </summary>
        /// <param name="rect">可调矩形</param>
        /// <returns>操作内容</returns>
        private OperationContext CreateTitleContext(ResizableRectangle rect)
        {
            OperationContext operationContext = new OperationContext(OperationType.TITLE, this.pictureboxPanel, rect, "");

            operationContext.AddVOperation(new OperationContext.Operation[]
			{
				new OperationContext.Operation
				{
					Title = "保存",
					Click = new EventHandler(this.OnTitle_Save),
					image = ExamImageFormRes.ConfirmButtonImage
				},
				new OperationContext.Operation
				{
					Title = "删除",
					Click = new EventHandler(this.OnTitle_Delete),
					image = ExamImageFormRes.CloseButtonImage
				}
			});

            return operationContext;
        }

        /// <summary>
        /// 自定义区域取消按钮点击事件
        /// </summary>
        private void OnCustomOmr_Cancel(object sender, EventArgs e)
        {
            _cusOptContext.HideContext();
            _activeRect.ShowContext(zoomRatio);
            pictureBox.Controls.Remove(_cusAreaPanel);

            _isCustomAction = false;
            _cusForm = null;
            _cusAreaPanel = null;
        }

        /// <summary>
        /// 自定义区域完成按钮点击事件
        /// </summary>
        private void OnCustomOmr_Save(object sender, EventArgs e)
        {
            _cusForm.CompleteCustomBlobs();
            _cusOptContext.HideContext();
            _activeRect.ShowContext(zoomRatio);
            pictureBox.Controls.Remove(_cusAreaPanel);

            _cusForm = null;
            _cusAreaPanel = null;

            blobList.Clear();

            if (CurrentOP == OperationType.SCHOOLNUMBER_OMR)
            {
                temSchoolomrList = TemplateInfoGenerater.Instance.GetSchoolNumberOmr(_selectedAreaPoint, currentPageIndex, omrType, _cusBlobInfoStr, 1);
                _isCustomAction = true;

                if (this.temSchoolomrList == null)
                {
                    return;
                }

                this.temSchoolomrList.region = _selectedAreaPoint;

                this.temSchoolomrList.omrs.ForEach(delegate(CvRect[] p)
                {
                    this.blobList.AddRange(p);
                });
            }
            else if (CurrentOP == OperationType.OBJECTIVE_OMR)
            {
                _isCustomAction = true;
                temObjectiveList = null;

                MouseUp_RecognizeObjectiveOmr(_selectedAreaPoint, true);
            }
        }

        /// <summary>
        /// 自定义区域调整按钮点击事件
        /// </summary>
        private void OnCustomOmr_Adjust(object sender, EventArgs e)
        {
            _cusForm.OpenAdjust();
        }

        /// <summary>
        /// 创佳自定义区域操作内容
        /// </summary>
        /// <param name="rect">自定义区域容器坐标</param>
        private OperationContext CreateCustomContext(ResizableRectangle rect, OperationType oType)
        {
            OperationContext operationContext = new OperationContext(oType, this.pictureboxPanel, rect, "");

            operationContext.AddHOperation(new OperationContext.Operation[]
            {
                new OperationContext.Operation
                {
                    Title="调整",
                    Click=new EventHandler(OnCustomOmr_Adjust)
                }
            });
            operationContext.AddVOperation(new OperationContext.Operation[]
            {
				new OperationContext.Operation
				{
					Title = "完成",
					Click = new EventHandler(OnCustomOmr_Save),
					image =ExamImageFormRes.ConfirmButtonImage
				},
				new OperationContext.Operation
				{
					Title = "取消",
					Click = new EventHandler(OnCustomOmr_Cancel),
					image = ExamImageFormRes.CloseButtonImage
				}
			});

            return operationContext;
        }

        /// <summary>
        /// 创建自定义面板
        /// </summary>
        private void CreateCustomPanel(OperationType opType)
        {
            Size controlsSize = new Size((int)((float)_activeRect.GetRect().Width * zoomRatio), (int)((float)_activeRect.GetRect().Height * zoomRatio));

            _cusAreaPanel = new Panel();
            _cusAreaPanel.Visible = true;
            _cusAreaPanel.Size = controlsSize;
            _cusAreaPanel.Location = new Point((int)((float)_activeRect.GetRect().Location.X * zoomRatio), (int)((float)_activeRect.GetRect().Location.Y * zoomRatio));
            _cusAreaPanel.BackColor = Color.Transparent;
            _cusAreaPanel.Margin = new Padding(0);
            _cusAreaPanel.Padding = new Padding(0);

            _activeRect.HideContext();

            _cusOptContext = new ControlOperationContext(CreateCustomContext(_activeRect, CurrentOP), _activeRect.GetRect());

            _cusOptContext.ShowContext(zoomRatio);
            pictureBox.Controls.Add(_cusAreaPanel);

            _cusForm = new CustomForm(_cusRegion, opType, zoomRatio);
            _cusForm.Size = controlsSize;
            _cusForm.TopLevel = false;
            _cusForm.Dock = System.Windows.Forms.DockStyle.Fill;
            _cusForm.Opacity = 0.01d;
            _cusForm.ParentForm = this;

            _cusAreaPanel.Show();
            _cusAreaPanel.BringToFront();
            _cusAreaPanel.Controls.Add(_cusForm);
            _cusForm.Show();
        }

        #region 隐藏区域相关操作

        /// <summary>
        /// 添加隐藏区域信息
        /// </summary>
        /// <param name="tagCvRect">目标区域信息</param>
        private void AddTempHideArea(CvRect tagCvRect, bool isSchoolNum = false)
        {
            if (_templateInfo.pages[this.currentPageIndex].HideAreaList == null)
            {
                _templateInfo.pages[this.currentPageIndex].HideAreaList = new List<HideArea>();
            }
            else
            {
                _tempHideAcer = _templateInfo.pages[currentPageIndex].HideAreaList;
            }
            if (_tempHideAcer == null)
            {
                _tempHideAcer = new List<HideArea>();

                _tempHideAcer.Add(new HideArea()
                {
                    AreaID = 1,
                    IsSchoolNum = isSchoolNum,
                    TopicType = ((int)TopicType.HideArea),
                    HideAreaRect = tagCvRect
                });

                _templateInfo.pages[this.currentPageIndex].HideAreaList = _tempHideAcer;

                return;
            }
            if (isSchoolNum)
            {
                if (_tempHideAcer.Count(a => a.IsSchoolNum == true) > 0)
                {
                    _tempHideAcer.Where(a => a.IsSchoolNum == isSchoolNum).FirstOrDefault().HideAreaRect = tagCvRect;
                    _templateInfo.pages[this.currentPageIndex].HideAreaList = _tempHideAcer;

                    return;
                }
            }
            if (modifyObject != null)
            {
                if (modifyObject.GetType() == typeof(HideArea))
                {
                    HideArea ha = (modifyObject as HideArea);

                    _tempHideAcer.Where(a => a.AreaID == ha.AreaID).FirstOrDefault().HideAreaRect = tagCvRect;
                    _templateInfo.pages[this.currentPageIndex].HideAreaList = _tempHideAcer;

                    return;
                }
            }

            _tempHideAcer.Add(new HideArea()
            {
                AreaID = _tempHideAcer.OrderByDescending(a => a.AreaID).FirstOrDefault().AreaID + 1,
                IsSchoolNum = isSchoolNum,
                TopicType = ((int)TopicType.HideArea),
                HideAreaRect = tagCvRect
            });
        }

        /// <summary>
        /// 隐藏区域删除按钮点击事件
        /// </summary>
        private void OnHideAcerOmr_Delete(object sender, EventArgs e)
        {
            List<HideArea> hideAreaList = new List<HideArea>();

            if (this._templateInfo.pages[this.currentPageIndex].HideAreaList != null)
            {
                hideAreaList = this._templateInfo.pages[this.currentPageIndex].HideAreaList;
            }
            if (this.modifyObject != null)
            {
                HideArea item = (modifyObject as HideArea);

                hideAreaList.Remove(item);
            }

            this._templateInfo.pages[this.currentPageIndex].HideAreaList = hideAreaList;
            _tempHideAcer = hideAreaList;

            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            this._editType = EditType.NONE;
            this._editTemplate = null;
            this.Cursor = Cursors.Arrow;

            this.pictureBox.Invalidate();

            this.CurrentOP = OperationType.HIDEACER;
        }

        /// <summary>
        /// 隐藏区域保存按钮点击事件
        /// </summary>
        private void OnHideAcerOmr_Save(object sender, EventArgs e)
        {
            Rectangle rect = (((Button)sender).Tag as ResizableRectangle).GetRect();
            CvRect hideAreaMatch = new CvRect(rect.X, rect.Y, rect.Width, rect.Height);

            if (hideAreaMatch.height == 0 || hideAreaMatch.width <= 5)
            {
                MessageBox.Show("隐藏区域长度或宽度不足");

                return;
            }

            AddTempHideArea(hideAreaMatch);

            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            this._editType = EditType.NONE;
            this._editTemplate = null;
            this.Cursor = Cursors.Arrow;
            _tempHideAcer = null;

            this.pictureBox.Invalidate();

            if (MessageBox.Show("是否继续添加隐藏区域？选择是，继续添加；选择否，完成隐藏区域框选", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.CurrentOP = OperationType.HIDEACER;

                return;
            }

            this.CurrentOP = OperationType.OBJECTIVE_OMR;
        }

        /// <summary>
        /// 创建隐藏区域操作面板
        /// </summary>
        /// <param name="rect">可调矩形</param>
        /// <returns>操作内容</returns>
        private OperationContext CreateHideAcerContext(ResizableRectangle rect)
        {
            OperationContext operationContext = new OperationContext(OperationType.HIDEACER, this.pictureboxPanel, rect, "");

            operationContext.AddVOperation(new OperationContext.Operation[]
			{
				new OperationContext.Operation
				{
					Title = "保存",
					Click = new EventHandler(this.OnHideAcerOmr_Save),
					image =ExamImageFormRes.ConfirmButtonImage
				},
				new OperationContext.Operation
				{
					Title = "删除",
					Click = new EventHandler(this.OnHideAcerOmr_Delete),
					image = ExamImageFormRes.CloseButtonImage
				}
			});

            return operationContext;
        }

        /// <summary>
        /// 鼠标抬起，定位隐藏区域信息
        /// </summary>
        /// <param name="cvselectArea">隐藏区域信息</param>
        private void MouseUp_RecognizeHideArea(CvRect cvselectArea)
        {
            try
            {
                if (modifyObject != null)
                {
                    //if (modifyObject.GetType() == typeof(HideArea)) { 
                    //_tempHideAcer (modifyObject as HideArea)
                    //}
                    HideArea ha = (modifyObject as HideArea);

                    if (ha != null && ha.HideAreaRect.Equals(cvselectArea) && _tempHideAcer == null)
                    {
                        _tempHideAcer = new List<HideArea>() { ha };
                    }
                    else if (_tempHideAcer != null && _tempHideAcer.Count > 0 && ha != null)
                    {
                        for (int i = 0; i < _tempHideAcer.Count; i++)
                        {
                            if (_tempHideAcer[i] == ha)
                            {
                                _tempHideAcer[i].HideAreaRect = cvselectArea;

                                break;
                            }
                        }
                    }

                    //if (this.modifyObject.GetType() == typeof(BarCodeSchoolNumber))
                    //{
                    //    this.temBarcode = (this.modifyObject as BarCodeSchoolNumber);

                    //    return;
                    //}
                    //if (this.modifyObject.GetType() == typeof(QRSchoolNumber))
                    //{
                    //    this.temQR = (this.modifyObject as QRSchoolNumber);

                    //    return;
                    //}

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                this.numList.Clear();
                this.blobList.Clear();
                this.pictureBox.Invalidate();

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 学号区域相关操作

        /// <summary>
        /// 考号区域自定义按钮点击事件
        /// </summary>
        private void OnStudentOmr_Custom(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ResizableRectangle rr = btn.Tag as ResizableRectangle;

            if (btn.Text == "自定义")
            {
                this.itemsize.x = (_selectedAreaPoint.x + _selectedAreaPoint.right) / 2;
                this.itemsize.y = _selectedAreaPoint.y + 20;
                _cusRegion = new Bitmap(_selectedAreaPoint.width, _selectedAreaPoint.height);

                Rectangle rectAcea = new Rectangle()
                {
                    X = _selectedAreaPoint.x,
                    Y = _selectedAreaPoint.y,
                    Width = _selectedAreaPoint.width,
                    Height = _selectedAreaPoint.height
                };

                Graphics g = Graphics.FromImage(_cusRegion);

                g.DrawImage((Bitmap)pictureBox.Image, new Rectangle(0, 0, rectAcea.Width, rectAcea.Height), rectAcea, GraphicsUnit.Pixel);

                CreateCustomPanel(OperationType.SCHOOLNUMBER_OMR);
            }
        }

        /// <summary>
        /// 学号区域添加行按钮点击事件
        /// </summary>
        private void OnStudentOmr_AddRow(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ResizableRectangle resizableRectangle = button.Tag as ResizableRectangle;

            if (this.temSchoolomrList == null)
            {
                MessageBox.Show("没有识别出任何填涂框，不能根据填涂框的信息生成行。");

                return;
            }

            resizableRectangle.GetRect();

            if (button.Text == "添加行")
            {
                CvRect[] array = new CvRect[this.temSchoolomrList.omrs.Count];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i].x = this.temSchoolomrList.omrs[i][0].x;
                    array[i].y = this.temSchoolomrList.omrs[i][0].y - this.temSchoolomrList.omrs[i][0].height * 2;
                    array[i].width = this.temSchoolomrList.omrs[i][0].width;
                    array[i].height = this.temSchoolomrList.omrs[i][0].height;
                }

                this._editTemplate = new OmrArray(null, array);
                this._editType = EditType.SCHOOLNUMBER_OMR_ADDROW;

                this.pictureBox.Invalidate();

                button.Text = "完成";

                resizableRectangle.context.HideOperation();
                resizableRectangle.context.EnableEditButtonOnly(button);

                return;
            }
            if (button.Text == "完成")
            {
                this.blobList.RemoveAll((CvRect p) => TemplateInfoGenerater.Instance.CheckRectInRect(p, this._editTemplate.SelectRegion, true));
                this.blobList.AddRange(this._editTemplate.Items);

                this._editTemplate = null;
                this._editType = EditType.NONE;
                this.Cursor = Cursors.Arrow;

                this.pictureBox.Invalidate();

                button.Text = "添加行";

                resizableRectangle.context.ShowOperation();
                resizableRectangle.context.EnableEditButtonAll();
            }
        }

        /// <summary>
        /// 学号区域添加列按钮点击事件
        /// </summary>
        private void OnStudentOmr_AddCol(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ResizableRectangle resizableRectangle = button.Tag as ResizableRectangle;

            if (this.temSchoolomrList == null)
            {
                MessageBox.Show("没有识别出任何填涂框，不能根据填涂框的信息生成列。");

                return;
            }

            resizableRectangle.GetRect();

            if (button.Text == "添加列")
            {
                CvRect[] array = new CvRect[10];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i].x = this.temSchoolomrList.omrs[0][0].x - this.temSchoolomrList.omrs[0][0].width * 2;
                    array[i].y = this.temSchoolomrList.omrs[0][i].y;
                    array[i].width = this.temSchoolomrList.omrs[0][0].width;
                    array[i].height = this.temSchoolomrList.omrs[0][0].height;
                }

                this._editTemplate = new OmrArray(null, array);
                this._editType = EditType.SCHOOLNUMBER_OMR_ADDCOL;

                this.pictureBox.Invalidate();

                button.Text = "完成";

                resizableRectangle.context.HideOperation();
                resizableRectangle.context.EnableEditButtonOnly(button);

                return;
            }
            if (button.Text == "完成")
            {
                this.blobList.RemoveAll((CvRect p) => TemplateInfoGenerater.Instance.CheckRectInRect(p, this._editTemplate.SelectRegion, true));
                this.blobList.AddRange(this._editTemplate.Items);

                this._editTemplate = null;
                this._editType = EditType.NONE;
                this.Cursor = Cursors.Arrow;

                this.pictureBox.Invalidate();

                button.Text = "添加列";

                resizableRectangle.context.ShowOperation();
                resizableRectangle.context.EnableEditButtonAll();
            }
        }

        /// <summary>
        /// 学号区域删除错误按钮点击事件
        /// </summary>
        private void OnStudentOmr_Remove(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ResizableRectangle resizableRectangle = button.Tag as ResizableRectangle;

            resizableRectangle.GetRect();

            if (button.Text == "删除错误")
            {
                this.activeSelectRect.height = (this.activeSelectRect.width = 0);
                this._editType = EditType.SCHOOLNUMBER_OMR_DELETECONTENT;
                this.Cursor = Cursors.Cross;
                button.Text = "完成";

                resizableRectangle.context.HideOperation();
                resizableRectangle.context.EnableEditButtonOnly(button);

                return;
            }

            this.activeSelectRect.height = (this.activeSelectRect.width = 0);
            this._editType = EditType.NONE;
            this.Cursor = Cursors.Arrow;
            button.Text = "删除错误";

            resizableRectangle.context.ShowOperation();
            resizableRectangle.context.EnableEditButtonAll();
        }

        /// <summary>
        /// 学号区域保存按钮点击事件
        /// </summary>
        /// <param name="cvSelectrea">选中的考号区域</param>
        private void SaveOmrSchoolNumber(CvRect cvSelectrea)
        {
            OmrSchoolNumber omrSchoolNumber = TemplateInfoGenerater.Instance.ComposeSchoolNumberOmrList(this.blobList);

            for (int i = 0; i < omrSchoolNumber.omrs.Count; i++)
            {
                if (omrSchoolNumber.omrs[i].Length != 10)
                {
                    throw new Exception("考号区域存在项数不为10的列");
                }
            }

            omrSchoolNumber.region = cvSelectrea;
            _templateInfo.pages[this.currentPageIndex].OmrSchoolNumBlob = omrSchoolNumber;
            _templateInfo.pages[this.currentPageIndex].SchoolNumType = SchoolNumberType.Omr;

            this.blobList.Clear();
        }

        /// <summary>
        /// 考号区域保存按钮点击事件
        /// </summary>
        private void OnStudentOmr_Save(object sender, EventArgs e)
        {
            Rectangle rect = ((sender as Button).Tag as ResizableRectangle).GetRect();
            CvRect cvRect = new CvRect(rect.X, rect.Y, rect.Width, rect.Height);

            if (this.temSchoolNumType == SchoolNumberType.BarCcode)
            {
                this._templateInfo.pages[this.currentPageIndex].SchoolNumType = SchoolNumberType.BarCcode;
                this.temBarcode.region = cvRect;
                this._templateInfo.pages[this.currentPageIndex].BarCodeSchoolNumBlob = this.temBarcode;
            }
            else if (this.temSchoolNumType == SchoolNumberType.QR)
            {
                this._templateInfo.pages[this.currentPageIndex].SchoolNumType = SchoolNumberType.QR;
                this.temQR.region = cvRect;
                this._templateInfo.pages[this.currentPageIndex].QRSchoolNumBlob = this.temQR;
            }
            else
            {
                this.SaveOmrSchoolNumber(cvRect);
            }

            AddTempHideArea(cvRect, true);

            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            this._editType = EditType.NONE;
            this._editTemplate = null;
            this.Cursor = Cursors.Arrow;
            this.temQR = null;
            this.temBarcode = null;
            this.temSchoolomrList = null;
            CurrentOP = OperationType.HIDEACER;

            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 考号区域删除按钮点击事件
        /// </summary>
        private void OnStudentOmr_Delete(object sender, EventArgs e)
        {
            this._templateInfo.pages[this.currentPageIndex].BarCodeSchoolNumBlob = null;
            this._templateInfo.pages[this.currentPageIndex].OmrSchoolNumBlob = null;
            this._templateInfo.pages[this.currentPageIndex].QRSchoolNumBlob = null;
            this.temBarcode = null;
            this.temSchoolomrList = null;
            this.temQR = null;

            this.blobList.Clear();
            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            this._editType = EditType.NONE;
            this.CurrentOP = OperationType.SCHOOLNUMBER_OMR;
            this._editTemplate = null;
            this.Cursor = Cursors.Arrow;
            _isCustomAction = false;

            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 创建考号操作区域
        /// </summary>
        /// <param name="rect">可调矩形</param>
        /// <returns>操作内容</returns>
        private OperationContext CreateStudentOmrContext(ResizableRectangle rect)
        {
            OperationContext operationContext = new OperationContext(OperationType.SCHOOLNUMBER_OMR, this.pictureboxPanel, rect, "");

            operationContext.AddHOperation(new OperationContext.Operation[]
			{
                new OperationContext.Operation
                {
                    Title = "自定义",
                    Click = new EventHandler(OnStudentOmr_Custom)
                },
                //new OperationContext.Operation
                //{
                //    Title = "添加行",
                //    Click = new EventHandler(this.OnStudentOmr_AddRow)
                //},
                //new OperationContext.Operation
                //{
                //    Title = "添加列",
                //    Click = new EventHandler(this.OnStudentOmr_AddCol)
                //},
                //new OperationContext.Operation
                //{
                //    Title = "删除错误",
                //    Click = new EventHandler(this.OnStudentOmr_Remove)
                //}
			});
            operationContext.AddVOperation(new OperationContext.Operation[]
			{
				new OperationContext.Operation
				{
					Title = "保存",
					Click = new EventHandler(this.OnStudentOmr_Save),
					image =ExamImageFormRes.ConfirmButtonImage
				},
				new OperationContext.Operation
				{
					Title = "删除",
					Click = new EventHandler(this.OnStudentOmr_Delete),
					image = ExamImageFormRes.CloseButtonImage
				}
			});

            return operationContext;
        }

        /// <summary>
        /// 鼠标抬起，识别学号
        /// </summary>
        /// <param name="cvselectArea">选中区域</param>
        private void MouseUp_RecognizeStudentId(CvRect cvselectArea)
        {
            if (this.modifyObject != null)
            {
                if (this.modifyObject.GetType() == typeof(OmrSchoolNumber))
                {
                    if (this.temSchoolomrList == null)
                    {
                        this.temSchoolomrList = (this.modifyObject as OmrSchoolNumber);

                        this.blobList.Clear();

                        this.temSchoolomrList.omrs.ForEach(delegate(CvRect[] p)
                        {
                            this.blobList.AddRange(p);
                        });

                        return;
                    }

                    this.ReflushSchoolomrList(cvselectArea);

                    return;
                }
                else
                {
                    if (this.modifyObject.GetType() == typeof(BarCodeSchoolNumber))
                    {
                        this.temBarcode = (this.modifyObject as BarCodeSchoolNumber);

                        return;
                    }
                    if (this.modifyObject.GetType() == typeof(QRSchoolNumber))
                    {
                        this.temQR = (this.modifyObject as QRSchoolNumber);

                        return;
                    }
                }
            }
            else if (this.temSchoolomrList == null && this.temBarcode == null && this.temQR == null)
            {
                if (!this.RecognizeSchoolNumberType(cvselectArea))
                {
                    this._activeRect = null;

                    this.pictureBox.Invalidate();

                    return;
                }
            }
            else if (this.temSchoolomrList != null)
            {
                this.ReflushSchoolomrList(cvselectArea);
            }
        }

        /// <summary>
        /// 刷新学号列表
        /// </summary>
        /// <param name="cvselectArea">选中区域</param>
        private void ReflushSchoolomrList(CvRect cvselectArea)
        {
            if (cvselectArea == this.temSchoolomrList.region)
            {
                return;
            }
            if (!this.RecognizeSchoolOmr(cvselectArea))
            {
                MessageBox.Show("没有识别出任何填涂框, 请把该框移到考号填涂区域。");
            }
        }

        /// <summary>
        /// 识别学号类型
        /// </summary>
        /// <param name="cvselectarea">选中区域</param>
        /// <returns>识别状态</returns>
        private bool RecognizeSchoolNumberType(CvRect cvselectarea)
        {
            if (this.RecognizeSchoolOmr(cvselectarea))
            {
                this.temSchoolNumType = SchoolNumberType.Omr;

                return true;
            }

            CodeTypeSelectForm codeTypeSelectForm = new CodeTypeSelectForm();

            if (codeTypeSelectForm.ShowDialog() == DialogResult.OK)
            {
                this.temSchoolNumType = codeTypeSelectForm.type;

                if (this.temSchoolNumType == SchoolNumberType.BarCcode)
                {
                    bool barCodeIsHorizontal = codeTypeSelectForm.BarCodeIsHorizontal;
                    this.temBarcode = new BarCodeSchoolNumber();
                    this.temBarcode.isHorizontal = barCodeIsHorizontal;
                }
                else if (this.temSchoolNumType == SchoolNumberType.QR)
                {
                    this.temQR = new QRSchoolNumber();
                }
                else if (temSchoolNumType == SchoolNumberType.Omr)
                {
                    return true;
                }

                this._activeRect.context.RemoveHOperatoin();

                return true;
            }

            return false;
        }

        /// <summary>
        /// 识别自定义考号区域
        /// </summary>
        /// <param name="cvselectarea">考号区域</param>
        /// <returns>识别状态</returns>
        private bool RecognizeSchoolOmr(CvRect cvselectarea)
        {
            this.blobList.Clear();

            if (!_isCustomAction)
            {
                this.temSchoolomrList = TemplateInfoGenerater.Instance.GetSchoolNumberOmr(cvselectarea, this.currentPageIndex, this.omrType, string.Empty, 0);
            }
            else
            {
                temSchoolomrList = TemplateInfoGenerater.Instance.GetSchoolNumberOmr(cvselectarea, currentPageIndex, omrType, _cusBlobInfoStr, 1);
            }
            if (this.temSchoolomrList == null)
            {
                return false;
            }

            this.temSchoolomrList.region = cvselectarea;

            this.temSchoolomrList.omrs.ForEach(delegate(CvRect[] p)
            {
                this.blobList.AddRange(p);
            });

            return true;
        }

        #endregion

        /// <summary>
        /// 客观题自定义按钮点击事件
        /// </summary>
        private void Custom_BlobArea(object sender, EventArgs e)
        {
            this.itemsize.x = (_selectedAreaPoint.x + _selectedAreaPoint.right) / 2;
            this.itemsize.y = _selectedAreaPoint.y + 20;
            _cusRegion = new Bitmap(_selectedAreaPoint.width, _selectedAreaPoint.height);

            Rectangle rectAcea = new Rectangle()
            {
                X = _selectedAreaPoint.x,
                Y = _selectedAreaPoint.y,
                Width = _selectedAreaPoint.width,
                Height = _selectedAreaPoint.height
            };

            Graphics g = Graphics.FromImage(_cusRegion);

            g.DrawImage((Bitmap)pictureBox.Image, new Rectangle(0, 0, rectAcea.Width, rectAcea.Height), rectAcea, GraphicsUnit.Pixel);

            CreateCustomPanel(OperationType.OBJECTIVE_OMR);
        }

        /// <summary>
        /// 检查无效题
        /// </summary>
        /// <param name="newObj">新识别的题信息</param>
        /// <returns>有效状态</returns>
        private bool CheckValidQid(OmrObjective newObj)
        {
            ExamImageForm.DisplayClass displayCalss = new ExamImageForm.DisplayClass();
            List<int> source = (from j in newObj.objectiveItems
                                select j.num.number).ToList<int>(),
                                list = (from i in source
                                        where i <= 0
                                        select i).ToList<int>();

            if (list.Count > 0)
            {
                MessageBox.Show("共有" + list.Count + "道题没有正确的识别出来，请移动矩形框重新识别或手动编辑题号。", "提示");

                return false;
            }

            displayCalss.validNums = (from i in source
                                      where i > 0
                                      select i).ToList<int>();
            List<int> list2 = displayCalss.validNums.ToList<int>(),
                list3 = displayCalss.validNums.Distinct<int>().ToList<int>();

            for (int i = displayCalss.validNums.Count - 1; i >= 0; i--)
            {
                int num = list3.FindIndex((int element) => element == displayCalss.validNums[i]);

                if (num >= 0)
                {
                    list2.RemoveAt(i);
                    list3.RemoveAt(num);
                }
            }

            if (list2.Count > 0)
            {
                list2 = list2.Distinct<int>().ToList<int>();

                string str = string.Join(",", list2.ConvertAll<string>((int i) => i.ToString()).ToArray());

                MessageBox.Show("不能保存，存在重复的题号：" + str + "。请移动矩形框重新识别。", "提示");

                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查指定题
        /// </summary>
        /// <param name="newObj">指定题信息</param>
        /// <returns>检查结果</returns>
        private bool CheckTargetObjectOmr(OmrObjective newObj)
        {
            string text = "";
            bool flag = false;

            if (newObj.objectiveItems.Length > 2)
            {
                for (int i = 1; i < newObj.objectiveItems.Length - 1; i++)
                {
                    int num = newObj.objectiveItems[i - 1].ItemRects.Length,
                        num2 = newObj.objectiveItems[i].ItemRects.Length,
                        num3 = newObj.objectiveItems[i + 1].ItemRects.Length;

                    if (num == num3 && num2 != num)
                    {
                        text = text + newObj.objectiveItems[i].num.number + ",";
                        flag = true;
                    }
                }

                if (flag)
                {
                    text = text.TrimEnd(new char[]
					{
						','
					});

                    return MessageBox.Show(string.Format("温馨提示：题号{0}的选项数跟上下题目不一致，请检查是否有误.\n确认保存：点击确认按键\n返回修改：点击取消按键", text), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.OK;
                }
            }

            return true;
        }

        /// <summary>
        /// 获取重复的题
        /// </summary>
        /// <param name="newObj">当前题</param>
        /// <param name="list">对比题列表</param>
        /// <returns>题号列表</returns>
        private List<int> GetDuplicatedQid(OmrObjective newObj, List<OmrObjective> list)
        {
            List<int> allQNums = (from i in list
                                  from j in i.objectiveItems
                                  select j.num.number).ToList<int>();

            return (from i in newObj.objectiveItems
                    where allQNums.Any((int item) => item == i.num.number)
                    select i.num.number).ToList<int>();
        }

        #region 客观题相关操作

        /// <summary>
        /// 鼠标抬起，识别客观题信息
        /// </summary>
        /// <param name="cvselectArea">选中区域</param>
        private void MouseUp_RecognizeObjectiveOmr(CvRect cvselectArea, bool isCustom)
        {
            try
            {
                OmrObjective omrObjective = this.modifyObject as OmrObjective;

                if (omrObjective != null && cvselectArea == omrObjective.region && this.temObjectiveList == null)
                {
                    this.numList = omrObjective.numList;
                    this.blobList = omrObjective.blobList;
                    this.omritemblobarrange = TemplateInfoGenerater.Instance.CheckObjectiveOmrArrange(this.numList, this.blobList);
                    this.itemsize = TemplateInfoGenerater.Instance.CheckBlobItemSize(this.blobList, 3);
                    this.ocritemdistance = TemplateInfoGenerater.Instance.CheckOcrBlobDistance(this.numList, this.blobList, this.omritemblobarrange, 3);
                    this.itemdistance = TemplateInfoGenerater.Instance.CheckBlobItemDistance(this.blobList, this.omritemblobarrange, 3);
                    this.temObjectiveList = new OmrObjective();
                    this.temObjectiveList.region = omrObjective.region;
                }
                else if (this.temObjectiveList == null || !(cvselectArea == this.temObjectiveList.region))
                {
                    if (isCustom)
                    {
                        this.temObjectiveList = TemplateInfoGenerater.Instance.GetOmrObjective(cvselectArea, _cusNumInfoStr, _cusBlobInfoStr);
                    }
                    else
                    {
                        this.temObjectiveList = TemplateInfoGenerater.Instance.GetOmrObjective(cvselectArea, this.currentPageIndex, this.omrType);
                    }

                    if (this.temObjectiveList.objectiveItems != null)
                    {
                        this.numList = this.temObjectiveList.numList;
                        this.blobList = this.temObjectiveList.blobList;
                        this.omritemblobarrange = TemplateInfoGenerater.Instance.CheckObjectiveOmrArrange(this.numList, this.blobList);
                        this.itemsize = TemplateInfoGenerater.Instance.CheckBlobItemSize(this.blobList, 3);
                        this.itemdistance = TemplateInfoGenerater.Instance.CheckBlobItemDistance(this.blobList, this.omritemblobarrange, 3);
                        this.ocritemdistance = TemplateInfoGenerater.Instance.CheckOcrBlobDistance(this.numList, this.blobList, this.omritemblobarrange, 3);
                    }
                    else if (this.temObjectiveList.originnumList != null)
                    {
                        this.omritemblobarrange = -1;
                        this.ocritemdistance = -1;
                        this.itemsize.width = 32;
                        this.itemsize.height = 15;
                        this.numList = this.temObjectiveList.originnumList;
                    }
                    else if (this.temObjectiveList.originblobList != null)
                    {
                        this.omritemblobarrange = -1;
                        this.ocritemdistance = -1;
                        this.itemsize = TemplateInfoGenerater.Instance.CheckBlobItemSize(this.temObjectiveList.originblobList, 3);
                        this.blobList = this.temObjectiveList.originblobList;
                    }
                }
            }
            catch (Exception)
            {
                this.numList.Clear();
                this.blobList.Clear();
                this.pictureBox.Invalidate();
                MessageBox.Show("客观题识别失败: 请确保您框选的客观题区域包含清晰的数字题号。");
            }
        }

        /// <summary>
        /// 保存客观题识别结果
        /// </summary>
        /// <param name="selectRect">选中矩形区域</param>
        /// <returns>操作结果</returns>
        private bool SaveObjectiveOmr(Rectangle selectRect)
        {
            if (this.numList.Count <= 0 || this.blobList.Count <= 0)
            {
                MessageBox.Show("客观题区域识别不完全，请确定所选的客观题区域是否正确。", "提示");

                return false;
            }

            CvRect region = new CvRect(selectRect.X, selectRect.Y, selectRect.Width, selectRect.Height);
            int num = TemplateInfoGenerater.Instance.CheckObjectiveOmrArrange(this.numList, this.blobList);
            List<OmrObjectiveItem> list = TemplateInfoGenerater.Instance.ComposeObjectiveOmrList(this.numList, this.blobList, num);

            list.Sort((OmrObjectiveItem one, OmrObjectiveItem tow) => one.num.number - tow.num.number);

            OmrObjective omrObjective = new OmrObjective();

            omrObjective.topicType = 0;
            omrObjective.ItemBlobSort = num;
            omrObjective.region = region;
            omrObjective.objectiveItems = list.ToArray();

            if (!this.CheckValidQid(omrObjective) || !this.CheckTargetObjectOmr(omrObjective))
            {
                this.numList = omrObjective.numList;
                this.blobList = omrObjective.blobList;

                this.pictureBox.Invalidate();

                return false;
            }

            List<OmrObjective> list2 = new List<OmrObjective>();

            if (this._templateInfo.pages[this.currentPageIndex].OmrObjectives != null)
            {
                list2.AddRange(this._templateInfo.pages[this.currentPageIndex].OmrObjectives);
            }
            if (this.modifyObject != null)
            {
                OmrObjective item = this.modifyObject as OmrObjective;

                list2.Remove(item);
            }

            List<OmrObjective> list3 = new List<OmrObjective>();

            for (int j = 0; j < this._templateInfo.pages.Length; j++)
            {
                if (j == this.currentPageIndex)
                {
                    list3.AddRange(list2);
                }
                else if (this._templateInfo.pages[j].OmrObjectives != null)
                {
                    list3.AddRange(this._templateInfo.pages[j].OmrObjectives);
                }
            }

            List<int> duplicatedQid = this.GetDuplicatedQid(omrObjective, list3);

            if (duplicatedQid.Count == 0)
            {
                list2.Add(omrObjective);

                this._templateInfo.pages[this.currentPageIndex].OmrObjectives = list2.ToArray();

                return true;
            }

            string str = string.Join(",", duplicatedQid.ConvertAll<string>((int i) => i.ToString()).ToArray());

            MessageBox.Show("题号" + str + "重复，不能保存。请确定所选的客观题区域是否有重叠。", "提示");

            return false;
        }

        /// <summary>
        /// 客观题区域保存按钮点击事件
        /// </summary>
        private void OnObjectiveOmr_Save(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ResizableRectangle resizableRectangle = button.Tag as ResizableRectangle;

            if (!this.SaveObjectiveOmr(resizableRectangle.GetRect()))
            {
                return;
            }

            this.numList.Clear();
            this.blobList.Clear();
            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            this.temObjectiveList = null;
            this._editType = EditType.NONE;
            this._editTemplate = null;
            this.Cursor = Cursors.Arrow;

            this.pictureBox.Invalidate();

            if (MessageBox.Show("是否继续添加客观题区域？选择是，则继续添加；选择否，则完成客观题框选", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.CurrentOP = OperationType.OBJECTIVE_OMR;

                return;
            }

            CurrentOP = OperationType.SUBJECTIVE_OMR;
        }

        /// <summary>
        /// 客观题区域删除按钮点击事件
        /// </summary>
        private void OnObjectiveOmr_Delete(object sender, EventArgs e)
        {
            List<OmrObjective> list = new List<OmrObjective>();

            if (this._templateInfo.pages[this.currentPageIndex].OmrObjectives != null)
            {
                list.AddRange(this._templateInfo.pages[this.currentPageIndex].OmrObjectives);
            }
            if (this.modifyObject != null)
            {
                OmrObjective item = this.modifyObject as OmrObjective;

                list.Remove(item);
            }

            this._templateInfo.pages[this.currentPageIndex].OmrObjectives = list.ToArray();

            this.numList.Clear();
            this.blobList.Clear();
            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            this.temObjectiveList = null;
            this._editType = EditType.NONE;
            this._editTemplate = null;
            this.Cursor = Cursors.Arrow;

            this.pictureBox.Invalidate();

            this.CurrentOP = OperationType.OBJECTIVE_OMR;
        }

        /// <summary>
        /// 创建客观题识别区域
        /// </summary>
        /// <param name="rect">可调矩形</param>
        /// <returns>区域内容</returns>
        private OperationContext CreateObjectiveOmrContext(ResizableRectangle rect)
        {
            OperationContext operationContext = new OperationContext(OperationType.OBJECTIVE_OMR, this.pictureboxPanel, rect, "");

            operationContext.AddHOperation(new OperationContext.Operation[]
			{
                new OperationContext.Operation
				{
					Title = "定位选项",
					Click = new EventHandler(this.Custom_BlobArea)
                }
			});
            operationContext.AddVOperation(new OperationContext.Operation[]
			{
				new OperationContext.Operation
				{
					Title = "保存",
					Click = new EventHandler(this.OnObjectiveOmr_Save),
					image =ExamImageFormRes.ConfirmButtonImage
				},
				new OperationContext.Operation
				{
					Title = "删除",
					Click = new EventHandler(this.OnObjectiveOmr_Delete),
					image = ExamImageFormRes.CloseButtonImage
				}
			});

            return operationContext;
        }

        #endregion

        #region 主观题相关操作

        /// <summary>
        /// 鼠标抬起，识别主观题信息
        /// </summary>
        /// <param name="cvselectArea">选中区域</param>
        private void MouseUp_RecognizeSubjectiveOmr(CvRect cvselectArea)
        {
            try
            {
                OmrSubjective omrSubjective = modifyObject as OmrSubjective;

                if (omrSubjective != null && omrSubjective.regionList.Contains(cvselectArea) && _temSubjectiveList == null)
                {
                    _temSubjectiveList = new List<OmrSubjective>()
                    {
                        new OmrSubjective()
                        {
                           regionList =new List<CvRect>()
                           { 
                               new CvRect( cvselectArea)
                           }
                        }
                    };
                }
                else if (_temSubjectiveList != null && _temSubjectiveList.Count > 0 && omrSubjective != null)
                {
                    for (int i = 0; i < _temSubjectiveList.Count; i++)
                    {
                        if (_temSubjectiveList[i] == omrSubjective)
                        {
                            _temSubjectiveList[i].regionList[_modifySubjcetiveAreaIndex] = cvselectArea;

                            break;
                        }
                    }
                }
                else if (_temSubjectiveList == null || !(_temSubjectiveList[_temSubjectiveList.Count - 1].regionList.Contains(cvselectArea)))
                {
                    _temSubjectiveList = new List<OmrSubjective>()
                    {
                        new OmrSubjective()
                        {
                            regionList=new List<CvRect>()
                            {
                                new CvRect(cvselectArea)
                            }                             
                        }
                    };
                }
            }
            catch (Exception)
            {
                this.numList.Clear();
                this.blobList.Clear();
                this.pictureBox.Invalidate();
                MessageBox.Show("主观题识别失败: 请确保您框选的主观题区域在有效的试卷区域内。");
            }
        }

        /// <summary>
        /// 框选主观题添加题号
        /// </summary>
        private void OnSubjcetiveOmr_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int textNumber = 0;

            if (!int.TryParse(tb.Text, out textNumber))
            {
                if (tb.Text.Length > 0)
                {
                    tb.Text = tb.Text.Length == 1 ? string.Empty : tb.Text.Substring(0, tb.Text.Length - 2);
                }

                return;
            }
            if (tb.Name.Equals("StartQid"))
            {
                _startQid = int.Parse(tb.Text);
            }
            else if (tb.Name.Equals("EndQid"))
            {
                _endQid = int.Parse(tb.Text);
            }
            else if (tb.Name.Equals("Qid"))
            {
                _startQid = _endQid = int.Parse(tb.Text);
            }
            if (modifyObject != null)
            {
                OmrSubjective item = modifyObject as OmrSubjective;

                for (int i = 0; i < _templateInfo.pages[currentPageIndex].OmrSubjectiveList.Count; i++)
                {
                    if (_templateInfo.pages[currentPageIndex].OmrSubjectiveList[i].Equals(item))
                    {
                        ResizableRectangle resizableRectangle = ((TextBox)sender).Tag as ResizableRectangle;
                        Rectangle rect = resizableRectangle.GetRect();
                        CvRect subjectiveMatch = new CvRect(rect.X, rect.Y, rect.Width, rect.Height);

                        _templateInfo.pages[currentPageIndex].OmrSubjectiveList[i].regionList[_modifySubjcetiveAreaIndex] = new CvRect(((ResizableRectangle)tb.Tag).GetRect());
                        _templateInfo.pages[currentPageIndex].OmrSubjectiveList[i].StartQid = _startQid;
                        _templateInfo.pages[currentPageIndex].OmrSubjectiveList[i].EndQid = _endQid;

                        break;
                    }
                }
            }
            else
            {
                int subjectListIndex = _temSubjectiveList.Count;
                _temSubjectiveList[subjectListIndex - 1].StartQid = _startQid;

                if (_endQid > 0)
                {
                    _temSubjectiveList[subjectListIndex - 1].EndQid = _endQid;
                }
            }
        }

        /// <summary>
        /// 主观题区域保存按钮点击事件
        /// </summary>
        private void OnSubjectiveOmr_Save(object sender, EventArgs e)
        {
            ResizableRectangle resizableRectangle = ((Button)sender).Tag as ResizableRectangle;
            Rectangle rect = resizableRectangle.GetRect();
            CvRect subjectiveMatch = new CvRect(rect.X, rect.Y, rect.Width, rect.Height);

            if (subjectiveMatch.height == 0 || subjectiveMatch.width <= 5)
            {
                MessageBox.Show("主观题区域长度或宽度不足");

                return;
            }
            if (_curTopicType == 0)
            {
                MessageBox.Show("请选择题类型", "提示");

                return;
            }
            // if (_curTopicType == TopicType.GapFilling && _startQid > _endQid)
            if (_startQid > _endQid)
            {
                MessageBox.Show("结束题号不能小于开始题号", "提示");

                return;
            }
            if (_templateInfo.pages != null)
            {
                int gapFillingMsgCount = 0;
                int subjectItemMsgCount = 0;

                foreach (Page p in _templateInfo.pages)
                {
                    if (p.OmrObjectives != null)
                    {
                        foreach (OmrObjective oo in p.OmrObjectives)
                        {
                            if (oo.objectiveItems != null)
                            {
                                foreach (OmrObjectiveItem ooi in oo.objectiveItems)
                                {
                                    if (ooi.num.number == _startQid)
                                    {
                                        MessageBox.Show(string.Format("您定义的开始题号{0}在客观题中已存在", _startQid), "提示");

                                        return;
                                    }
                                }
                            }
                        }
                    }
                    if (p.OmrSubjectiveList != null)
                    {
                        foreach (OmrSubjective os in p.OmrSubjectiveList)
                        {
                            if (os.TopicType == (int)TopicType.GapFilling)
                            {
                                if (_startQid == os.StartQid && _endQid == os.EndQid)
                                {
                                    if (gapFillingMsgCount == 0 && DialogResult.No == MessageBox.Show(string.Format("您定义的填空题{0}-{1}和已有题块重复,点击确定与已有题块合并，点击取消可修改题号。", _startQid, _endQid), "提示", MessageBoxButtons.YesNo))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        gapFillingMsgCount++;
                                    }
                                }
                                else if (_startQid == os.StartQid || _startQid == os.EndQid || (_startQid > os.StartQid && _startQid < os.EndQid))
                                {
                                    MessageBox.Show(string.Format("您定义的开始题号{0}在填空题中已存在", _startQid));

                                    return;
                                }
                            }
                            if (os.TopicType == (int)TopicType.SubjectiveItem && _startQid == os.StartQid)
                            {
                                if (subjectItemMsgCount == 0 && DialogResult.No == MessageBox.Show(string.Format("您定义的题号{0}在主观题中已存在,点击确定与已有题块合并，点击取消可修改题号。", _startQid), "提示", MessageBoxButtons.YesNo))
                                {
                                    return;
                                }
                                else
                                {
                                    subjectItemMsgCount++;
                                }
                            }
                        }
                    }
                }
            }

            _temSubjectiveList[_temSubjectiveList.Count - 1].TopicType = _curTopicType;
            _temSubjectiveList[_temSubjectiveList.Count - 1].StartQid = _startQid;
            _temSubjectiveList[_temSubjectiveList.Count - 1].EndQid = _endQid;

            if (_templateInfo.pages[this.currentPageIndex].OmrSubjectiveList == null)
            {
                _templateInfo.pages[this.currentPageIndex].OmrSubjectiveList = new List<OmrSubjective>();
            }
            if (modifyObject == null)
            {
                _templateInfo.pages[currentPageIndex].OmrSubjectiveList.AddRange(_temSubjectiveList);
            }

            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            this.CurrentOP = OperationType.SUBJECTIVE_OMR;
            _curTopicType = 0;
            _startQid = _endQid = 0;

            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 从新的填空题块中删除已包含的主观题块
        /// </summary>
        private void DeleteSubjectiveItemAreaForNewGapFillingArea()
        {
            for (int i = 0; i < _templateInfo.pages.Count(); i++)
            {
                if (_templateInfo.pages[i].OmrSubjectiveList != null && _templateInfo.pages[i].OmrSubjectiveList.Count > 0)
                {
                    List<OmrSubjective> omrModelList = new List<OmrSubjective>();

                    for (int j = 0; j < _templateInfo.pages[i].OmrSubjectiveList.Count; j++)
                    {
                        OmrSubjective omrModel = _templateInfo.pages[i].OmrSubjectiveList[j];

                        if (omrModel.TopicType == ((int)TopicType.SubjectiveItem) && !(omrModel.StartQid >= _startQid && omrModel.StartQid <= _endQid))
                        {
                            omrModelList.Add(omrModel);
                        }

                        _templateInfo.pages[i].OmrSubjectiveList = omrModelList;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 删除主观题框选区域
        /// </summary>
        private void OnSubjectiveOmr_Delete(object sender, EventArgs e)
        {
            List<OmrSubjective> subjectiveList = new List<OmrSubjective>();

            if (this._templateInfo.pages[currentPageIndex].OmrSubjectiveList != null)
            {
                subjectiveList.AddRange(_templateInfo.pages[currentPageIndex].OmrSubjectiveList);
            }
            if (this.modifyObject != null)
            {
                OmrSubjective item = modifyObject as OmrSubjective;

                subjectiveList.Remove(item);
            }

            _templateInfo.pages[this.currentPageIndex].OmrSubjectiveList = subjectiveList;

            this._activeRect.HideContext();

            this._activeRect = null;
            this.modifyObject = null;
            _temSubjectiveList = null;
            this._editType = EditType.NONE;
            this._editTemplate = null;
            this.Cursor = Cursors.Arrow;
            _curTopicType = 0;
            _startQid = _endQid = 0;

            this.pictureBox.Invalidate();

            CurrentOP = OperationType.SUBJECTIVE_OMR;
        }

        /// <summary>
        /// 题类型下拉框改变事件
        /// </summary>
        private void OnSubjectiveOmr_SelectIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (_activeRect.context == null || cb.SelectedIndex == -1)
            {
                return;
            }

            int index = 0;

            if (cb != null && cb.SelectedIndex > 0)
            {
                index = cb.SelectedIndex;
            }

            KeyValue<int, string> kv = cb.Items[cb.SelectedIndex] as KeyValue<int, string>;

            _curTopicType = (int)kv.Key;

            _activeRect.context.Hide();

            _activeRect.context = CreateSubjectiveOmrContext(_tempSubjectiveRect, index, true);

            Rectangle r = _tempSubjectiveRect.GetRect();

            _activeRect.context.Show(new Rectangle(((int)(((float)r.X) * zoomRatio)), ((int)(((float)r.Y) * zoomRatio)), ((int)(((float)r.Width) * zoomRatio)), ((int)(((float)r.Height) * zoomRatio))));
        }

        /// <summary>
        /// 题号文本框获得焦点事件
        /// </summary>
        private void SubjectiveOmrTextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox tbControl = sender as TextBox;

            if (tbControl.Text.Equals("开始题号") || tbControl.Text.Equals("结束题号") || tbControl.Text.Equals("题号"))
            {
                tbControl.ForeColor = Color.Black;
                tbControl.Text = string.Empty;
            }
        }

        /// <summary>
        /// 文本框焦点离开事件
        /// </summary>
        private void SubjectiveOmrTextBox_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim().Equals(string.Empty))
            {
                tb.ForeColor = Color.Black;

                if (tb.Name.Equals("StartQid"))
                {
                    tb.Text = "开始题号";
                }
                else if (tb.Name.Equals("EndQid"))
                {
                    tb.Text = "结束题号";
                }
                else if (tb.Name.Equals("Qid"))
                {
                    tb.Text = "题号";
                }
            }
        }

        /// <summary>
        /// 创建主观题区域操作区
        /// </summary>
        /// <param name="rect">主观题已选择区域</param>
        /// <returns>返回创建的操作区</returns>
        private OperationContext CreateSubjectiveOmrContext(ResizableRectangle rect, int index = 0, bool selectChange = false)
        {
            _tempSubjectiveRect = rect;

            string startQid = string.Empty,
             endQid = string.Empty;

            if (modifyObject != null && !selectChange)
            {
                OmrSubjective os = (modifyObject as OmrSubjective);

                _curTopicType = os.TopicType;
                //    index = (_curTopicType == TopicType.GapFilling) ? 1 : 2;
                index = _curTopicType;
                startQid = os.StartQid.ToString();
                endQid = os.EndQid.ToString();
            }

            OperationContext subjectiveOmrContext = new OperationContext(OperationType.SUBJECTIVE_OMR, this.pictureboxPanel, rect, "");

            subjectiveOmrContext.AddCOperation(new OperationContext.Operation[]
            {
                new OperationContext.Operation
                {
                    Title = "题类型",
                    DefaultSelectedIndex = index,
                    SelectedIndexChanged = new EventHandler(OnSubjectiveOmr_SelectIndexChanged)
                }
            });

            if (_curTopicType == 3)
            {
                subjectiveOmrContext.AddTOperation(new OperationContext.Operation[]
                {
                    new OperationContext.Operation
                    {
                        Name = "StartQid",
                        DefaultText = string.IsNullOrEmpty(startQid)? "开始题号":startQid,
                        ForeColor=string.IsNullOrEmpty(startQid)?Color.Gray:Color.Black,
                        GotFocus=new EventHandler(SubjectiveOmrTextBox_GotFocus),
                        LostFocus=new EventHandler(SubjectiveOmrTextBox_LostFocus),
                        TextChanged = new EventHandler(OnSubjcetiveOmr_TextChanged)
                    },
                    new  OperationContext.Operation
                    {
                        Name = "EndQid",
                        DefaultText = string.IsNullOrEmpty(endQid)? "结束题号":endQid,
                        ForeColor=string.IsNullOrEmpty(endQid)?Color.Gray:Color.Black,
                        GotFocus=new EventHandler(SubjectiveOmrTextBox_GotFocus),
                        LostFocus=new EventHandler(SubjectiveOmrTextBox_LostFocus),
                        TextChanged = new EventHandler(OnSubjcetiveOmr_TextChanged)
                    }
                });
            }
            else if (_curTopicType == 4)
            {
                subjectiveOmrContext.AddTOperation(new OperationContext.Operation[]
                {
                    new OperationContext.Operation
                    {
                        Name = "Qid",
                        DefaultText = string.IsNullOrEmpty(startQid)? "题号":startQid,
                        ForeColor=string.IsNullOrEmpty(startQid)?Color.Gray:Color.Black,
                        GotFocus=new EventHandler(SubjectiveOmrTextBox_GotFocus),
                        LostFocus=new EventHandler(SubjectiveOmrTextBox_LostFocus),
                        TextChanged = new EventHandler(OnSubjcetiveOmr_TextChanged)
                    }
                });
            }

            subjectiveOmrContext.AddVOperation(new OperationContext.Operation[]
                {
                    new OperationContext.Operation
                    {
                        Title = "保存",
                        Click = new EventHandler(OnSubjectiveOmr_Save),
                        image = ExamImageFormRes.ConfirmButtonImage
                    },
                    new OperationContext.Operation
                    {
                        Title="删除",
                        Click=new EventHandler(OnSubjectiveOmr_Delete),
                        image=ExamImageFormRes.CloseButtonImage
                    }
                });

            return subjectiveOmrContext;
        }

        #endregion

        /// <summary>
        /// 创建操作面板
        /// </summary>
        /// <param name="rect">框选区域</param>
        /// <returns>操作面板对象</returns>
        private OperationContext CreateContext(ResizableRectangle rect)
        {
            switch (this.CurrentOP)
            {
                case OperationType.DESKEWED_DETECTION:

                    return this.CreateAdjustContext(rect);
                case OperationType.TITLE:

                    return this.CreateTitleContext(rect);
                case OperationType.SCHOOLNUMBER_OMR:

                    return this.CreateStudentOmrContext(rect);
                case OperationType.HIDEACER:

                    return CreateHideAcerContext(rect);
                case OperationType.OBJECTIVE_OMR:

                    return this.CreateObjectiveOmrContext(rect);
                case OperationType.SUBJECTIVE_OMR:

                    return CreateSubjectiveOmrContext(rect);
                default:

                    return null;
            }
        }

        /// <summary>
        /// 恢复保存的对象
        /// </summary>
        /// <param name="currentPoint">当前点</param>
        /// <returns>操作结果</returns>
        private bool RecoverSavedObject(Point currentPoint)
        {
            object obj = this.GetModifyObject(currentPoint);

            if (obj != null)
            {
                Type type = obj.GetType();
                CvRect cvRect = new CvRect(0, 0, 0, 0);

                if (type == typeof(TitleLocal))
                {
                    this.CurrentOP = OperationType.TITLE;
                    cvRect = ((TitleLocal)obj).matchRegion;
                }
                else if (type == typeof(BarCodeSchoolNumber))
                {
                    this.CurrentOP = OperationType.SCHOOLNUMBER_OMR;
                    this.temSchoolNumType = SchoolNumberType.BarCcode;
                    cvRect = ((BarCodeSchoolNumber)obj).region;
                }
                else if (type == typeof(QRSchoolNumber))
                {
                    this.CurrentOP = OperationType.SCHOOLNUMBER_OMR;
                    this.temSchoolNumType = SchoolNumberType.QR;
                    cvRect = ((QRSchoolNumber)obj).region;
                }
                else if (type == typeof(OmrSchoolNumber))
                {
                    this.CurrentOP = OperationType.SCHOOLNUMBER_OMR;
                    this.temSchoolNumType = SchoolNumberType.Omr;
                    cvRect = ((OmrSchoolNumber)obj).region;
                }
                else if (type == typeof(HideArea))
                {
                    CurrentOP = OperationType.HIDEACER;
                    cvRect = ((HideArea)obj).HideAreaRect;
                }
                else if (type == typeof(OmrObjective))
                {
                    this.CurrentOP = OperationType.OBJECTIVE_OMR;
                    cvRect = ((OmrObjective)obj).region;
                    this.temObjectiveList = null;
                }
                else if (type == typeof(OmrSubjective))
                {
                    CurrentOP = OperationType.SUBJECTIVE_OMR;
                    OmrSubjective osModel = ((OmrSubjective)obj);
                    cvRect = osModel.regionList[_modifySubjcetiveAreaIndex];
                    _startQid = osModel.StartQid;
                    _endQid = osModel.EndQid;
                    _temSubjectiveList = null;
                }

                this.modifyObject = obj;

                if (this._activeRect != null)
                {
                    this._activeRect.HideContext();
                }

                this._activeRect = new ResizableRectangle(this);

                OperationContext operationContext = this.CreateContext(this._activeRect);

                operationContext.type = this.CurrentOP;

                this._activeRect.SetRect(new Rectangle(cvRect.x, cvRect.y, cvRect.width, cvRect.height));

                if (type == typeof(QRSchoolNumber) || type == typeof(BarCodeSchoolNumber))
                {
                    operationContext.RemoveHOperatoin();
                }

                this._activeRect.SetContext(operationContext);

                return true;
            }

            return false;
        }

        /// <summary>
        /// 图片框鼠标按下事件处理逻辑
        /// </summary>
        private void pictureBox_MouseDown_Boxing(object sender, MouseEventArgs e)
        {
            int x = (int)((float)e.X / this.zoomRatio),
                y = (int)((float)e.Y / this.zoomRatio);
            Point point = new Point(x, y);

            if (e.Button == MouseButtons.Left)
            {
                if (this._activeRect != null)
                {
                    if (this._activeRect.CaptureMousePoint(e.Location, this.zoomRatio))
                    {
                        this._activeRect.SetTrackingPoint(e.Location, this.zoomRatio, true);
                        this._activeRect.HideContext();
                        this.pictureBox.Invalidate();

                        return;
                    }
                    if (this.RecoverSavedObject(point))
                    {
                        this._activeRect.SetTrackingPoint(e.Location, this.zoomRatio, true);
                        this._activeRect.HideContext();
                        this.pictureBox.Invalidate();

                        return;
                    }

                    this._invalidDownPoint = true;

                    return;
                }
                else
                {
                    if (this.RecoverSavedObject(point))
                    {
                        return;
                    }

                    this._activeRect = new ResizableRectangle(this);

                    OperationContext context = this.CreateContext(this._activeRect);

                    this._activeRect.SetContext(context);
                    this._activeRect.SetBeginning(point);
                    this._activeRect.SetTrackingPoint(e.Location, this.zoomRatio, true);
                    this._activeRect.HideContext();
                    this.pictureBox.Invalidate();
                }
            }
        }

        /// <summary>
        /// 图片框鼠标按下事件
        /// </summary>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.IsResizeOperaitonType())
            {
                this.pictureBox_MouseDown_Boxing(sender, e);
            }
            if (this._editType == EditType.OBJECTIVE_OMR_ADDBLOB || this._editType == EditType.OBJECTIVE_OMR_DELETECONTENT || this._editType == EditType.SCHOOLNUMBER_OMR_DELETECONTENT)
            {
                this.activeDownFlag = true;
                this._downPoint = new Point((int)((float)e.X / this.zoomRatio), (int)((float)e.Y / this.zoomRatio));
                this.activeSelectRect.height = (this.activeSelectRect.width = 0);
            }
            if (this._editType == EditType.OBJECTIVE_OMR_ADDSUBJECT || this._editType == EditType.OBJECTIVE_OMR_ADDBLOB || this._editType == EditType.SCHOOLNUMBER_OMR_ADDROW || this._editType == EditType.SCHOOLNUMBER_OMR_ADDCOL || this._editType == EditType.OBJECTIVE_OMR_ADDNUM)
            {
                this._downPoint = new Point((int)((float)e.X / this.zoomRatio), (int)((float)e.Y / this.zoomRatio));

                if (TemplateInfoGenerater.Instance.CheckPosInRect(new Point(this._downPoint.X, this._downPoint.Y), this._editTemplate.SelectRegion))
                {
                    this.activeDownFlag = true;
                }
            }
        }

        /// <summary>
        /// 图片框鼠标移动事件处理逻辑
        /// </summary>
        private void pictureBox_MouseMove_Boxing(object sender, MouseEventArgs e)
        {
            int x = (int)((float)e.X / this.zoomRatio),
                y = (int)((float)e.Y / this.zoomRatio);

            if (this._activeRect != null)
            {
                Point newTrackingPoint = new Point(x, y);

                if (this.pictureBox.Capture)
                {
                    this._activeRect.ResizeRectTo(newTrackingPoint);
                }
                else
                {
                    this._activeRect.SetTrackingPoint(e.Location, this.zoomRatio, true);
                }

                this.pictureBox.Invalidate();
            }
        }

        /// <summary>
        /// 图片框鼠标移动事件
        /// </summary>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsResizeOperaitonType())
            {
                this.pictureBox_MouseMove_Boxing(sender, e);
            }
            if (this._editType == EditType.OBJECTIVE_OMR_DELETECONTENT || this._editType == EditType.SCHOOLNUMBER_OMR_DELETECONTENT)
            {
                int num = (int)((float)e.X / this.zoomRatio),
                    num2 = (int)((float)e.Y / this.zoomRatio);

                if (this.activeDownFlag)
                {
                    if (this._downPoint.X < num)
                    {
                        this.activeSelectRect.x = this._downPoint.X;
                    }
                    else
                    {
                        this.activeSelectRect.x = num;
                    }
                    if (this._downPoint.Y < num2)
                    {
                        this.activeSelectRect.y = this._downPoint.Y;
                    }
                    else
                    {
                        this.activeSelectRect.y = num2;
                    }

                    this.activeSelectRect.width = Math.Abs(this._downPoint.X - num);
                    this.activeSelectRect.height = Math.Abs(this._downPoint.Y - num2);
                }

                this.pictureBox.Invalidate();
            }
            if (this._editType == EditType.OBJECTIVE_OMR_ADDSUBJECT || this._editType == EditType.OBJECTIVE_OMR_ADDBLOB || this._editType == EditType.SCHOOLNUMBER_OMR_ADDROW || this._editType == EditType.SCHOOLNUMBER_OMR_ADDCOL || this._editType == EditType.OBJECTIVE_OMR_ADDNUM)
            {
                int x = (int)((float)e.X / this.zoomRatio),
                    y = (int)((float)e.Y / this.zoomRatio);
                Point point = new Point(x, y);

                if (TemplateInfoGenerater.Instance.CheckPosInRect(point, this._editTemplate.SelectRegion))
                {
                    this.Cursor = Cursors.SizeAll;
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                }
                if (this._editTemplate != null)
                {
                    Rectangle rect = this._activeRect.GetRect();

                    if (this.activeDownFlag)
                    {
                        this._editTemplate.Move(this._downPoint, point);
                    }
                }

                this.pictureBox.Invalidate();
            }
        }

        /// <summary>
        /// 画框鼠标抬起事件处理逻辑
        /// </summary>
        private void pictureBox_MouseUp_Boxing(object sender, MouseEventArgs e)
        {
            if (this._activeRect == null)
            {
                return;
            }
            if (e.Button != MouseButtons.Right)
            {
                this._activeRect.Adjust(new Rectangle(0, 0, (int)((float)this.pictureBox.Width / this.zoomRatio), (int)((float)this.pictureBox.Height / this.zoomRatio)));

                Rectangle rect = this._activeRect.GetRect();
                CvRect cvselectArea = _selectedAreaPoint = new CvRect(rect.X, rect.Y, rect.Width, rect.Height);

                if (rect.Width < 20 || rect.Height < 20)
                {
                    this._activeRect = null;

                    this.pictureBox.Invalidate();

                    return;
                }
                if (this._invalidDownPoint)
                {
                    this._invalidDownPoint = false;

                    return;
                }
                switch (this.CurrentOP)
                {
                    case OperationType.SCHOOLNUMBER_OMR:
                        this.MouseUp_RecognizeStudentId(cvselectArea);

                        break;
                    case OperationType.HIDEACER:
                        MouseUp_RecognizeHideArea(cvselectArea);

                        break;
                    case OperationType.OBJECTIVE_OMR:
                        this.MouseUp_RecognizeObjectiveOmr(cvselectArea, false);

                        break;
                    case OperationType.SUBJECTIVE_OMR:
                        MouseUp_RecognizeSubjectiveOmr(cvselectArea);

                        break;

                }
                if (this.CurrentOP == OperationType.FINISHED)
                {
                    this._activeRect = null;
                }
                else if (this._activeRect != null)
                {
                    this._activeRect.Adjust();
                    this._activeRect.ShowContext(this.zoomRatio);
                }
            }

            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 画框鼠标抬起事件
        /// </summary>
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.IsResizeOperaitonType())
            {
                this.pictureBox_MouseUp_Boxing(sender, e);
            }
            if ((this._editType == EditType.OBJECTIVE_OMR_ADDSUBJECT && this.activeDownFlag)
                || (this._editType == EditType.OBJECTIVE_OMR_ADDBLOB && this.activeDownFlag)
                || (this._editType == EditType.SCHOOLNUMBER_OMR_ADDROW && this.activeDownFlag)
                || (this._editType == EditType.SCHOOLNUMBER_OMR_ADDCOL && this.activeDownFlag)
                || (this._editType == EditType.OBJECTIVE_OMR_ADDNUM && this.activeDownFlag))
            {
                this.activeDownFlag = false;

                if (this._editTemplate != null)
                {
                    this._editTemplate = new OmrArray(this._editTemplate.num, this._editTemplate.Items);

                    Rectangle rect = this._activeRect.GetRect();
                    CvRect zone = new CvRect(rect.X, rect.Y, rect.Width, rect.Height);

                    if (this._editTemplate.Items != null && !TemplateInfoGenerater.Instance.CheckRectInRect(this._editTemplate.ItemRectRegion, zone, true))
                    {
                        MessageBox.Show("请不要移出框选界外", "提示");
                    }
                    else if (this._editTemplate.num != null && !TemplateInfoGenerater.Instance.CheckRectInRect(this._editTemplate.SelectRegion, zone, true))
                    {
                        MessageBox.Show("请不要移出框选界外", "提示");
                    }
                }
            }
            if ((this._editType == EditType.OBJECTIVE_OMR_DELETECONTENT || this._editType == EditType.SCHOOLNUMBER_OMR_DELETECONTENT) && this.activeDownFlag)
            {
                this.activeDownFlag = false;

                Rectangle rect2 = this._activeRect.GetRect();
                CvRect zone2 = new CvRect(rect2.X, rect2.Y, rect2.Width, rect2.Height);

                if (!TemplateInfoGenerater.Instance.CheckRectInRect(this.activeSelectRect, zone2, true))
                {
                    MessageBox.Show("框选区域不正确", "提示");

                    return;
                }

                this.numList.RemoveAll((KeyValue<int, Point> p) => TemplateInfoGenerater.Instance.CheckPosInRect(p.Value, this.activeSelectRect));
                this.blobList.RemoveAll((CvRect p) => TemplateInfoGenerater.Instance.CheckRectInRect(p, this.activeSelectRect, false));

                this.activeSelectRect.height = (this.activeSelectRect.width = 0);

                this.pictureBox.Invalidate();
            }
        }

        /// <summary>
        /// 右键，当前图片信息按钮点击事件
        /// </summary>
        private void ts_currentImageInfo_Click(object sender, EventArgs e)
        {
            if (this.pictureBox.Image != null)
            {
                string text = "黑白图",
                    text2 = "单面";

                switch (this._templateInfo.imgSourceType)
                {
                    case ImgSourceType.BW:
                        text = "黑白图";

                        break;
                    case ImgSourceType.GRAY:
                        text = "灰度图";

                        break;
                    case ImgSourceType.RGB:
                        text = "彩色图";

                        break;
                }

                if (this._templateInfo.isDoubleSide == true)
                {
                    text2 = "双面";
                }

                Image image = this.pictureBox.Image;

                MessageBox.Show(string.Format("单双面：{0}\n图像尺寸：{1}X{2}\n图像模式：{3}", new object[]
				{
					text2,
					image.Width,
					image.Height,
					text
				}), "模板信息");
            }
        }

        /// <summary>
        /// 复制模板菜单按钮点击事件
        /// </summary>
        private void ts_CopyTemplate_Click(object sender, EventArgs e)
        {
            if (this.imageFilesList != null)
            {
                StringCollection stringCollection = new StringCollection();

                for (int i = 0; i < this.imageFilesList.Count; i++)
                {
                    stringCollection.Add(Path.GetFullPath(this.imageFilesList[i]));
                }

                Clipboard.SetFileDropList(stringCollection);
                MessageBox.Show("已复制到粘贴板", "提示");
            }
        }

        /// <summary>
        /// 重新选取图片超链接按钮点击事件
        /// </summary>
        private void returnScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this._activeRect != null)
            {
                this._activeRect.HideContext();
            }

            this._activeRect = null;
            this.modifyObject = null;
            this.CurrentOP = OperationType.SCAN_SETTING;

            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 确认按钮点击事件
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.btnOK.Visible = false;
            this.returnScan.Visible = false;

            if (this._activeRect != null)
            {
                this._activeRect.HideContext();
            }

            this._activeRect = null;
            this.modifyObject = null;
            this.CurrentOP = OperationType.TITLE;

            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 检查答题卡设置
        /// </summary>
        private void CheckTemplate()
        {
            string text = string.Empty;
            List<int> list = new List<int>();

            for (int j = 0; j < this._templateInfo.pages.Length; j++)
            {
                Page page = this._templateInfo.pages[j];

                if (j == 0)
                {
                    if (page.localRegion == null)
                    {
                        text += "答题卡第1页必须设置文字定位区域。\n";
                    }
                    if ((page.SchoolNumType == SchoolNumberType.Omr && page.OmrSchoolNumBlob == null) || (page.SchoolNumType == SchoolNumberType.QR && page.QRSchoolNumBlob == null) || (page.SchoolNumType == SchoolNumberType.BarCcode && page.BarCodeSchoolNumBlob == null))
                    {
                        text += "答题卡第1页必须设置学生考号区域。\n";
                    }
                }
                else if (page.OmrObjectives != null && page.OmrObjectives.Length > 0 && page.localRegion == null)
                {
                    list.Add(j + 1);
                }
            }
            if (list.Count > 0)
            {
                string str = string.Join(",", list.ConvertAll<string>((int i) => i.ToString()).ToArray());

                text = text + "答题卡" + str + "页设置了客观题区域，也必须要设置文字定位区域。\n";
            }
            if (text != string.Empty)
            {
                text += "\n模板尚未完成制作，不能上传网络。";

                throw new Exception(text);
            }
        }

        /// <summary>
        /// 保存模板文件
        /// </summary>
        private void SaveTemplateFile()
        {
            if (!Directory.Exists(this.TemplateLocalDir))
            {
                Directory.CreateDirectory(this.TemplateLocalDir);
            }

            for (int i = 0; i < this.imageFilesList.Count; i++)
            {
                File.Copy(this.imageFilesList[i], this.TemplateLocalDir + "\\" + Path.GetFileName(this.imageFilesList[i]), true);
            }
            for (int j = 0; j < this._templateInfo.pages.Length; j++)
            {
                if (this._templateInfo.pages[j].OmrObjectives != null)
                {
                    List<OmrObjective> list = this._templateInfo.pages[j].OmrObjectives.ToList<OmrObjective>();

                    list.Sort((OmrObjective one, OmrObjective tow) => one.objectiveItems[0].num.number - tow.objectiveItems[0].num.number);

                    this._templateInfo.pages[j].OmrObjectives = list.ToArray();
                }
            }

            _xmlFileName = string.Format("tpl{0}.{1}", ScanGlobalInfo.ExamInfo.CsID, "xml");

            SerializerHelper.SeriXmlModel<TemplateInfo>(TemplateLocalDir + _xmlFileName, this._templateInfo);
            List<string> list2 = new List<string>();

            list2.AddRange(this.imageFilesList);
            list2.Add(TemplateLocalDir + _xmlFileName);

            string outputzipfile = this.TemplateLocalDir + "\\" + this.CurrentExamId + ".zip";

            Compress.ZipFiles(list2.ToArray(), outputzipfile);
        }

        /// <summary>
        /// 上传到阿里云
        /// </summary>
        /// <returns></returns>
        private List<string> UploadImageToALiyun()
        {
            string templateLocalDir = this.TemplateLocalDir,
                uploadTpFileDirectory = PathHelper.UploadTpFileDirectory;
            List<string> list = new List<string>();

            foreach (string current in this.imageFilesList)
            {
                string fileName = Path.GetFileName(current);

                ALiProgressManager.Oss_PutObject(templateLocalDir + fileName, fileName);

                list.Add(fileName);
            }

            return list;
        }

        /// <summary>
        /// 上传xml文件到阿里云
        /// </summary>
        /// <returns>返回上传是否成功</returns>
        private bool UploadXmlFileToALiyun()
        {
            string fileMD5Code = ALiProgressManager.Oss_PutObject(TemplateLocalDir + _xmlFileName, _xmlFileName);

            if (fileMD5Code.Trim().Length > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                FormProgress frmProgress = new FormProgress();

                Thread trd = new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        this.CheckTemplate();
                        frmProgress.SetProgress(25, "正在保存模板文件...");
                        this.SaveTemplateFile();
                        frmProgress.SetProgress(50, "正在上传模板文件...");
                        UploadImageToALiyun();
                        UploadXmlFileToALiyun();
                        frmProgress.SetProgress(75, "正在保存数据...");

                        ApiResponse ar = _bdBLL.SaveTemplateData(_templateInfo, _xmlFileName);

                        if (ar.Success)
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.Close();
                                frmProgress.SetProgress(100, "完成");

                                this.Cursor = Cursors.Arrow;
                            }));

                            this.DialogResult = DialogResult.OK;
                        }
                        else if (ar.Error != null)
                        {
                            throw new Exception(ar.Error.Message);
                        }
                        else
                        {
                            throw new Exception("模板保存失败，请稍后重试。");
                        }
                    }
                    catch (ThreadAbortException taex)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.Close();
                            MessageBox.Show("保存终止", "提示");

                            this.Cursor = Cursors.Arrow;
                        }));
                        new BaseDisposeBLL().System_SaveErrorLog(taex, "上传模板出现异常");

                        this.DialogResult = DialogResult.Cancel;
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.Close();

                            this.Cursor = Cursors.Arrow;

                            MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }));
                        new BaseDisposeBLL().System_SaveErrorLog(ex, "上传模板出现异常");

                        this.DialogResult = DialogResult.Cancel;
                    }
                }));

                FormProgress expr_67 = frmProgress;

                expr_67.Completedhandle = (EventHandler)Delegate.Combine(expr_67.Completedhandle, new EventHandler(delegate(object obj, EventArgs args)
                {
                }));
                trd.Start();
                frmProgress.ShowDialog();

                if (base.DialogResult == DialogResult.OK && MessageBox.Show("模板文件已经保存并上传网络，是否立即进行扫描？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && this._startScanEventHandler != null)
                {
                    this._startScanEventHandler(sender, e);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;

                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                new BaseDisposeBLL().System_SaveErrorLog(ex, "保存模板过程中出现异常");
            }
        }

        /// <summary>
        /// 当前窗体释放操作
        /// </summary>
        private void ExamImageForm_Disposed(object sender, EventArgs e)
        {
            base.Dispose();

            try
            {
                if (TemplateInfoGenerater.Instance != null)
                {
                    TemplateInfoGenerater.Instance.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 容器面板鼠标滚轮事件
        /// </summary>
        private void formPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// 当前窗体加载事件
        /// </summary>
        private void ExamImageForm_Load(object sender, EventArgs e)
        {
            base.Disposed += new EventHandler(this.ExamImageForm_Disposed);
            this.formPanel.MouseWheel += new MouseEventHandler(this.formPanel_MouseWheel);
            this.panelTips.Height = 40;
            this.panelTips.BackColor = Scheme.HelpBackColor;
        }

        /// <summary>
        /// 建议的布局
        /// </summary>
        private void TipsLayout()
        {
            base.SuspendLayout();

            this.labelTips.Width = this.panelTips.Width;
            this.formPanel.Location = new Point(0, this.panelTips.Height);
            this.formPanel.Height = base.Height - this.panelTips.Height;

            base.ResumeLayout();
        }

        /// <summary>
        /// 当前窗体调整大小事件
        /// </summary>
        private void ExamImageForm_Resize(object sender, EventArgs e)
        {
            this.TipsLayout();
        }

        /// <summary>
        /// 打开模板设置
        /// </summary>
        public void OpenTemplateSetting()
        {
            TemplateSettingForm templateSettingForm = new TemplateSettingForm();
            templateSettingForm.RectWid = this.rect_wid;
            templateSettingForm.RectHeight = this.rect_height;
            templateSettingForm.CurOmrType = this.omrType;
            if (templateSettingForm.ShowDialog() == DialogResult.OK)
            {
                this.omrType = templateSettingForm.CurOmrType;
                bool flag = TemplateInfoGenerater.Instance.UpdateRectParam(templateSettingForm.RectHeight, templateSettingForm.RectWid);
                if (flag)
                {
                    this.rect_height = templateSettingForm.RectHeight;
                    this.rect_wid = templateSettingForm.RectWid;
                }
            }
        }

        /// <summary>
        /// 设置显示比例
        /// </summary>
        /// <param name="ratio">比例值</param>
        public void SetZoomRatio(float ratio)
        {
            this.zoomRatio = ratio;
            this.pictureBox.Size = new Size((int)((float)this.pictureBox.Image.Size.Width * ratio), (int)((float)this.pictureBox.Image.Size.Height * ratio));
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            if (this._activeRect != null)
            {
                this._activeRect.MoveContext(this.zoomRatio);

                if (_cusAreaPanel != null)
                {
                    Rectangle r = _activeRect.GetRect();

                    _cusAreaPanel.Location = new Point((int)((float)r.X * zoomRatio), (int)((float)r.Y * zoomRatio));
                    _cusAreaPanel.Size = new Size((int)((float)r.Width * zoomRatio), (int)((float)r.Height * zoomRatio));
                    _cusOptContext.context.Move(_activeRect.GetRect(zoomRatio));

                    if (_cusForm != null)
                    {
                        _cusForm.SetZoomRatio(zoomRatio);
                    }
                }
            }
        }

        /// <summary>
        /// 放大操作
        /// </summary>
        public void ZoomIn()
        {
            if (this.zoomRatio > 2f)
            {
                return;
            }

            this.zoomRatio *= 1.1f;

            this.SetZoomRatio(this.zoomRatio);
        }

        /// <summary>
        /// 缩小操作
        /// </summary>
        public void ZoomOut()
        {
            if (this.zoomRatio < 0.2f)
            {
                return;
            }

            this.zoomRatio /= 1.1f;

            this.SetZoomRatio(this.zoomRatio);
        }

        /// <summary>
        /// 逆时针旋转图片
        /// </summary>
        public void UnClockRotate()
        {
            TemplateInfoGenerater.Instance.UnClockRotate(this.currentPageIndex);

            this.imagesList[this.currentPageIndex].Dispose();

            this.imagesList[this.currentPageIndex] = FileHelper.GetImage(this.imageFilesList[this.currentPageIndex]);
            this.pictureBox.Image = this.imagesList[this.currentPageIndex];

            if (this.imageFilesList.Count > 1)
            {
                this.ShowTips("已对页面进行校正，请使用“上一页/下一页”切换到别的页面进行校正操作，确保所有的页面都调成水平。");
            }
        }

        /// <summary>
        /// 顺时针旋转图片
        /// </summary>
        public void ClockRotate()
        {
            TemplateInfoGenerater.Instance.ClockRotate(this.currentPageIndex);

            this.imagesList[this.currentPageIndex].Dispose();

            this.imagesList[this.currentPageIndex] = FileHelper.GetImage(this.imageFilesList[this.currentPageIndex]);
            this.pictureBox.Image = this.imagesList[this.currentPageIndex];

            if (this.imageFilesList.Count > 1)
            {
                this.ShowTips("已对页面进行校正，请使用“上一页/下一页”切换到别的页面进行校正操作，确保所有的页面都调成水平。");
            }
        }

        /// <summary>
        /// 保存当前对象
        /// </summary>
        private void SaveCurrentObject()
        {
            this.pages[this.currentPageIndex].activeRect = this._activeRect;
            this.pages[this.currentPageIndex].modifyObject = this.modifyObject;
            this.pages[this.currentPageIndex].numList = this.numList;
            this.pages[this.currentPageIndex].blobList = this.blobList;
            this.pages[this.currentPageIndex]._EditTemplate = this._editTemplate;
            this.pages[this.currentPageIndex].temSchoolNumType = this.temSchoolNumType;
            this.pages[this.currentPageIndex].temBarcode = this.temBarcode;
            this.pages[this.currentPageIndex].temQr = this.temQR;
            this.pages[this.currentPageIndex].temSchoolomrList = this.temSchoolomrList;
        }

        /// <summary>
        /// 恢复当前对象
        /// </summary>
        private void RestoreCurrentObject()
        {
            this._activeRect = this.pages[this.currentPageIndex].activeRect;
            this.modifyObject = this.pages[this.currentPageIndex].modifyObject;
            this.numList = this.pages[this.currentPageIndex].numList;
            this.blobList = this.pages[this.currentPageIndex].blobList;
            this._editTemplate = this.pages[this.currentPageIndex]._EditTemplate;
            this.temSchoolNumType = this.pages[this.currentPageIndex].temSchoolNumType;
            this.temBarcode = this.pages[this.currentPageIndex].temBarcode;
            this.temQR = this.pages[this.currentPageIndex].temQr;
            this.temSchoolomrList = this.pages[this.currentPageIndex].temSchoolomrList;
        }

        /// <summary>
        /// 上一页操作
        /// </summary>
        public void PreviousPage()
        {
            if (this.currentPageIndex > 0)
            {
                if (this._editType != EditType.NONE)
                {
                    MessageBox.Show("正在编辑模板，不能切换页面，请先点击“完成”按钮，完成编辑操作。");

                    return;
                }
                if (this._activeRect != null)
                {
                    this._activeRect.HideContext();
                }

                this.SaveCurrentObject();

                this.currentPageIndex--;

                this.RestoreCurrentObject();

                if (this._activeRect != null)
                {
                    this._activeRect.ShowContext(this.zoomRatio);
                }

                this.pictureBox.Image = this.imagesList[this.currentPageIndex];

                this.SetZoomRatio(this.zoomRatio);
            }
        }

        /// <summary>
        /// 下一页操作
        /// </summary>
        public void NextPage()
        {
            if (this.currentPageIndex + 1 < this.imageFilesList.Count)
            {
                if (this._editType != EditType.NONE)
                {
                    MessageBox.Show("正在编辑模板，不能切换页面，请先点击“完成”按钮，完成编辑操作。");

                    return;
                }
                if (this._activeRect != null)
                {
                    this._activeRect.HideContext();
                }

                this.SaveCurrentObject();

                this.currentPageIndex++;

                this.RestoreCurrentObject();

                if (this._activeRect != null)
                {
                    this._activeRect.ShowContext(this.zoomRatio);
                }

                this.pictureBox.Image = this.imagesList[this.currentPageIndex];

                this.SetZoomRatio(this.zoomRatio);
            }
        }

        /// <summary>
        /// 设置图片文件集
        /// </summary>
        /// <param name="imageFiles">图片文件路径列表</param>
        /// <param name="size">页大小</param>
        /// <param name="omrType">识别类型</param>
        /// <param name="isDoubleSide">是否双面</param>
        public void SetImageFiles(List<string> imageFiles, PageSize size, OmrType omrType, bool isDoubleSide)
        {
            this.imageFilesList = imageFiles;
            this.pageSize = size;
            this.omrType = omrType;
            this.pages = new List<ImagePage>();

            for (int i = 0; i < this.imageFilesList.Count; i++)
            {
                this.pages.Add(new ImagePage());
            }

            this.currentPageIndex = 0;

            try
            {
                TemplateInfoGenerater.Instance.SetRecognizeImage(this.imageFilesList.ToArray());
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message);
            }

            this._templateInfo.isDoubleSide = new bool?(isDoubleSide);
            this._templateInfo.imgSourceType = ScanGlobalInfo.scanImgSourceType;
            this._templateInfo.pages = new Page[this.imageFilesList.Count];
            this.imagesList = new List<Image>();

            for (int j = 0; j < this.imageFilesList.Count; j++)
            {
                this._templateInfo.pages[j] = new Page
                {
                    fileName = Path.GetFileName(this.imageFilesList[j]),
                    Size = this.pageSize,
                    pageIndex = j,
                    omrType = omrType
                };

                this.imagesList.Add(FileHelper.GetImage(this.imageFilesList[j]));
            }

            this.pictureBox.Image = this.imagesList[0];
        }

        /// <summary>
        /// 满画布显示
        /// </summary>
        public void FitScreen()
        {
            float num = (float)base.Parent.Width / (float)this.pictureBox.Image.Size.Width;

            if (this.pictureBox.Image.Size.Width > this.pictureBox.Image.Size.Height)
            {
                num *= 2f;
            }

            this.SetZoomRatio(num);
        }

        /// <summary>
        /// 添加开始扫描事件头
        /// </summary>
        /// <param name="hdr">事件头</param>
        public void AddStartScanEventHandler(EventHandler hdr)
        {
            this._startScanEventHandler = hdr;
        }

        /// <summary>
        /// 打开模板文件
        /// </summary>
        /// <param name="templateFile">模板文件路径</param>
        public void OpenTemplateFile(string templateFile)
        {
            this._templateInfo = SerializerHelper.DeseriXmlModel<TemplateInfo>(templateFile);

            string dir = Path.GetDirectoryName(templateFile);
            List<string> list = (from i in this._templateInfo.pages
                                 select dir + "\\" + i.fileName).ToList<string>();
            string str = Guid.NewGuid().ToString(),
                text = Path.GetTempPath() + str;

            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }

            this.imageFilesList = new List<string>();

            foreach (string current in list)
            {
                string text2 = text + "\\" + Path.GetFileName(current);

                File.Copy(current, text2, true);
                this.imageFilesList.Add(text2);
            }

            TemplateInfoGenerater.Instance.SetRecognizeImage(this.imageFilesList.ToArray());

            this.imagesList = new List<Image>();

            foreach (string current2 in this.imageFilesList)
            {
                this.imagesList.Add(FileHelper.GetImage(current2));
            }

            this.pages = new List<ImagePage>();

            for (int j = 0; j < this.imageFilesList.Count; j++)
            {
                this.pages.Add(new ImagePage());
            }

            if (_templateInfo != null && _templateInfo.pages != null && _templateInfo.pages.Length > 0)
            {
                foreach (Page p in _templateInfo.pages)
                {
                    if (p.HideAreaList != null && p.HideAreaList.Count > 0)
                    {
                        foreach (HideArea ha in p.HideAreaList)
                        {
                            ha.AreaID = p.HideAreaList.OrderByDescending(a => a.AreaID).FirstOrDefault().AreaID + 1;
                            ha.IsSchoolNum = false;

                            switch (p.SchoolNumType)
                            {
                                case SchoolNumberType.Omr:
                                    if (p.OmrSchoolNumBlob.region == ha.HideAreaRect)
                                    {
                                        ha.IsSchoolNum = true;
                                    }

                                    break;
                                case SchoolNumberType.QR:
                                    if (p.QRSchoolNumBlob.region == ha.HideAreaRect)
                                    {
                                        ha.IsSchoolNum = true;
                                    }

                                    break;
                                case SchoolNumberType.BarCcode:
                                    if (p.BarCodeSchoolNumBlob.region == ha.HideAreaRect)
                                    {
                                        ha.IsSchoolNum = true;
                                    }

                                    break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }


            this.pageSize = this._templateInfo.pages[0].Size;
            this.omrType = this._templateInfo.pages[0].omrType;
            this.pictureBox.Image = this.imagesList[0];
            this.currentPageIndex = 0;
            this.CurrentOP = OperationType.FINISHED;
        }

        public void ClearCustomForm()
        {
            if (CurrentOP == OperationType.SCHOOLNUMBER_OMR || CurrentOP == OperationType.OBJECTIVE_OMR)
            {
                if (_cusOptContext != null)
                {
                    _cusOptContext.HideContext();
                }
                if (_cusAreaPanel != null)
                {
                    pictureBox.Controls.Remove(_cusAreaPanel);
                }
            }
        }
    }
}