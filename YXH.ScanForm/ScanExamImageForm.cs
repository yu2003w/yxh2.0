using DevExpress.XtraBars.Docking;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YXH.Common;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;
using System.Linq;

namespace YXH.ScanForm
{
    /// <summary>
    /// 扫描试卷图片窗体
    /// </summary>
    public partial class ScanExamImageForm : Form
    {
        /// <summary>
        /// 业务层的实例
        /// </summary>
        BaseDisposeBLL _bdBLL = new BaseDisposeBLL();
        /// <summary>
        /// 定义纸操作事件头委托
        /// </summary>
        /// <param name="obj">控件对象</param>
        /// <param name="curOpStatus">纸张操作类型</param>
        /// <param name="curOp">当前纸张</param>
        public delegate void PaperOperateResultHandle(object obj, PaperOperateStatus curOpStatus, BaseOperation curOp);
        /// <summary>
        /// 更新页索引显示事件头
        /// </summary>
        public EventHandler PageIndexShownUpdateHandle;
        /// <summary>
        /// 当前数据行
        /// </summary>
        private VolumnDataRow _curDataRow;
        /// <summary>
        /// 当前试卷操作状态
        /// </summary>
        private PaperOperateStatus curOperateStatus;
        /// <summary>
        /// 当前页索引
        /// </summary>
        private int _CurrentPageIndex;
        /// <summary>
        /// 遗漏数量
        /// </summary>
        private int _leakCount;
        /// <summary>
        /// 识别错误列表
        /// </summary>
        private List<TreeListNode> omrErrorList = new List<TreeListNode>();
        /// <summary>
        /// 显示比例
        /// </summary>
        private float picRatio = 0.3f;
        /// <summary>
        /// 红色区域颜色
        /// </summary>
        public static Color redRectColor = Color.FromArgb(255, 238, 107, 82);
        /// <summary>
        /// 橘色区域颜色
        /// </summary>
        public static Color orangeRectColor = Color.FromArgb(255, 247, 190, 56);
        /// <summary>
        /// 试卷状态改变事件声明
        /// </summary>
        public event ScanExamImageForm.PaperOperateResultHandle opPaperStateChange;
        /// <summary>
        /// 页索引字符串
        /// </summary>
        public string PageIndexStr
        {
            get
            {
                int num = 0,
                    num2 = 0;

                if (this._curDataRow != null)
                {
                    num2 = this._curDataRow.Data.ImagePath.Length;
                    num = this._CurrentPageIndex + 1;
                }

                return string.Format("{0}/{1}", num, num2);
            }
        }
        /// <summary>
        /// 显示正确的识别结果
        /// </summary>
        public bool ShowCorrectOMRResult { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        public ScanExamImageForm()
        {
            InitializeComponent();

            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

        }

        /// <summary>
        /// 人工标记按钮点击事件
        /// </summary>
        private void btn_ManualModifgy_Click(object sender, EventArgs e)
        {
            if (this.opPaperStateChange != null)
            {
                this._curDataRow.ErrorStatusList.Add(ErrorStatus.StudentInfoError);

                if (this.trlOmrList.Nodes.Count > 0)
                {
                    this._curDataRow.ErrorStatusList.Add(ErrorStatus.ObjectiveOmrError);
                }

                this._curDataRow.ErrorStatusList.Remove(ErrorStatus.ExamPaperInfoError);

                if (_curDataRow.HistoryErrorStatusList == null)
                {
                    _curDataRow.HistoryErrorStatusList = new List<ErrorStatus>();
                }

                _curDataRow.HistoryErrorStatusList.Add(ErrorStatus.ExamPaperInfoError);
                this._curDataRow.Data.Status.Clear();
                this._curDataRow.Data.Status.Add(VolumeStatus.ErrZkzh);
                this._curDataRow.Data.Status.Add(VolumeStatus.ErrOmr);
                this.opPaperStateChange(this._curDataRow, this.curOperateStatus, BaseOperation.Add);
            }
        }

        /// <summary>
        /// Table页切换点击事件
        /// </summary>
        private void btn_LaterDw_Click(object sender, EventArgs e)
        {
            if (this.opPaperStateChange != null)
            {
                this.opPaperStateChange(this._curDataRow, this.curOperateStatus, BaseOperation.None);
            }
        }

        /// <summary>
        /// 删除试卷错误按钮点击事件
        /// </summary>
        private void btn_DeletePaperError_Click(object sender, EventArgs e)
        {
            if (this.opPaperStateChange != null)
            {
                this.opPaperStateChange(this._curDataRow, this.curOperateStatus, BaseOperation.Delete);
            }
        }

        /// <summary>
        /// 客观题存疑保存按钮点击事件
        /// </summary>
        private void btnOmrSave_Click(object sender, EventArgs e)
        {
            if (this.opPaperStateChange != null)
            {
                LogHelper.WriteInfoLog(string.Format("客观题异常处理：保存：获取当前卷信息", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
                VolumnDataRow curDataRow = this._curDataRow;
                string text = string.Empty;

                LogHelper.WriteInfoLog(string.Format("客观题异常处理：保存：处理已选项", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));

                List<string> ormList = new List<string>();

                for (int i = 0; i < this.trlOmrList.Nodes.Count; i++)
                {
                    string displayText = this.trlOmrList.Nodes[i].GetDisplayText(this.trcAnswer.AbsoluteIndex);
                    string curAnswer = (string.IsNullOrEmpty(displayText.Trim()) ? "-" : displayText);

                    text += curAnswer;

                    ormList.Add(curAnswer);

                    if (curDataRow.Data.OmrItemList.Count <= i)
                    {
                        curDataRow.Data.OmrItemList.Add(new OmrItem() { ObjectiveID = i + 1, Answer = curAnswer, type = OmrValueType.Confirm });
                    }
                    else
                    {
                        if (curDataRow.Data.OmrItemList[i].ObjectiveID == 0)
                        {
                            curDataRow.Data.OmrItemList[i].ObjectiveID = i + 1;
                        }

                        curDataRow.Data.OmrItemList[i].Answer = curAnswer;
                        curDataRow.Data.OmrItemList[i].type = OmrValueType.Confirm;
                    }
                    if (i != this.trlOmrList.Nodes.Count - 1)
                    {
                        text += ",";
                    }
                }

                curDataRow.Data.Omrs = ormList.ToArray();

                LogHelper.WriteInfoLog(string.Format("客观题异常处理：保存：保存已选项", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
                curDataRow.Data.Omr = text;
                curDataRow.Data.ConfirmOmrIsModify = true;

                this.opPaperStateChange(curDataRow, this.curOperateStatus, BaseOperation.Update);
            }
        }

        /// <summary>
        /// 只有当前选中选项卡有图形
        /// </summary>
        /// <param name="curPage">当前选中选项卡</param>
        private void SetOnlyCurTabModifyVisiable(XtraTabPage curPage)
        {
            if (curPage != null)
            {
                this.panel_ErrorInform.Visible = true;
                this.cms_picpanel.Enabled = true;
                curPage.PageVisible = true;
                this.dpModify.Visibility = DockVisibility.Visible;

                IEnumerator enumerator = this.xtcRightDocker.TabPages.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    XtraTabPage xtraTabPage = (XtraTabPage)enumerator.Current;

                    if (xtraTabPage != curPage)
                    {
                        xtraTabPage.PageVisible = false;
                    }
                }

                return;
            }

            this.panel_ErrorInform.Visible = false;

            if (this.dpModify.Visibility != DockVisibility.Hidden)
            {
                this.dpModify.Visibility = DockVisibility.Hidden;
            }
        }

        /// <summary>
        /// 当前窗体加载事件
        /// </summary>
        private void ScanExamImageForm_Load(object sender, EventArgs e)
        {
            this.btn_LaterDw_PEtab.Click += new EventHandler(this.btn_LaterDw_Click);
            this.btn_LaterDw_ZkzhTab.Click += new EventHandler(this.btn_LaterDw_Click);
            this.btn_LaterDw_OmrTab.Click += new EventHandler(this.btn_LaterDw_Click);
            this.btn_DeletePaperError.Click += new EventHandler(this.btn_DeletePaperError_Click);

            this.SetOnlyCurTabModifyVisiable(null);

            this.panel_ErrorInform.Parent = this.picFront;
            this.panel_ErrorInform.BackColor = Color.Transparent;
            this.lbl_ErrorDetails.Parent = this.panel_ErrorInform;
            this.lbl_ErrorDetails.BackColor = Color.Transparent;
            this.label7.Parent = this.panel_ErrorInform;
            this.label7.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 图形框点击事件
        /// </summary>
        private void picFront_Click(object sender, EventArgs e)
        {
            int num = (int)((float)((MouseEventArgs)e).X / this.picRatio),
                num2 = (int)((float)((MouseEventArgs)e).Y / this.picRatio);

            foreach (TreeListNode current in this.omrErrorList)
            {
                current.GetDisplayText(this.trcAnswer.AbsoluteIndex).Trim();

                List<bool> list = (List<bool>)current.GetValue(this.trcCheckStatus.AbsoluteIndex);
                List<Rectangle> list2 = (List<Rectangle>)current.GetValue(this.trcRect.AbsoluteIndex);

                for (int i = 0; i < list2.Count; i++)
                {
                    if (num > list2[i].X && num < list2[i].Right && num2 > list2[i].Y && num2 < list2[i].Bottom)
                    {
                        current.SetValue(this.trcModifyStatus, 1);

                        list[i] = !list[i];

                        string text = string.Empty;

                        for (int j = 0; j < list.Count; j++)
                        {
                            if (list[j])
                            {
                                text += (char)(65 + j);
                            }
                        }

                        current.SetValue(this.trcAnswer, text);

                        this.trlOmrList.SetFocusedNode(current);
                        this.picFront.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// 图片框绘制事件
        /// </summary>
        private void picFront_Paint(object sender, PaintEventArgs e)
        {
            if (this.omrErrorList.Count > 0)
            {
                Pen pen = new Pen(ScanExamImageForm.redRectColor, 2f),
                    pen2 = new Pen(Brushes.Blue, 2f),
                    pen3 = new Pen(ScanExamImageForm.orangeRectColor, 2f);

                foreach (TreeListNode current in this.omrErrorList)
                {
                    int num = Convert.ToInt32(current.GetValue(this.trcPageindex.AbsoluteIndex));

                    if (num == this._CurrentPageIndex)
                    {
                        List<Rectangle> list = (List<Rectangle>)current.GetValue(this.trcRect.AbsoluteIndex);
                        int num2 = Convert.ToInt32(current.GetValue(this.trcModifyStatus.AbsoluteIndex));
                        string text = current.GetDisplayText(this.trcAnswer.AbsoluteIndex).Trim();
                        OmrValueType omrValueType = (OmrValueType)current.GetValue(this.trcOmrValType.AbsoluteIndex);
                        Font font = new Font("MS Gothic", (float)(list[0].Height + 4) * this.picRatio, FontStyle.Bold);
                        Rectangle[] array = new Rectangle[list.Count];

                        for (int i = 0; i < list.Count; i++)
                        {
                            array[i] = new Rectangle((int)((float)list[i].X * this.picRatio), (int)((float)list[i].Y * this.picRatio), (int)((float)list[i].Width * this.picRatio), (int)((float)list[i].Height * this.picRatio));
                        }

                        if (num2 == 0)
                        {
                            if (omrValueType == OmrValueType.Empty)
                            {
                                e.Graphics.DrawRectangles(pen, array);
                            }
                            else
                            {
                                for (int j = 0; j < text.Length; j++)
                                {
                                    int num3 = (int)(text[j] - 'A');
                                    float x = (float)(array[num3].X + Math.Abs(array[num3].Width - array[num3].Height) / 2 - 1),
                                        y = (float)(array[num3].Y - 2);

                                    e.Graphics.DrawString(text[j].ToString(), font, Brushes.Orange, x, y);
                                }

                                e.Graphics.DrawRectangles(pen3, array);
                            }
                        }
                        else if (num2 == 1)
                        {
                            for (int k = 0; k < text.Length; k++)
                            {
                                int num4 = (int)(text[k] - 'A');
                                float x2 = (float)(array[num4].X + Math.Abs(array[num4].Width - array[num4].Height) / 2 - 1),
                                    y2 = (float)(array[num4].Y - 2);

                                e.Graphics.DrawString(text[k].ToString(), font, Brushes.Blue, x2, y2);
                            }

                            e.Graphics.DrawRectangles(pen2, array);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 图片框双击事件
        /// </summary>
        private void picFront_DoubleClick(object sender, EventArgs e)
        {
            if (this.picFront.Image != null)
            {
                if (this.picRatio != 0.5f)
                {
                    this.picRatio = 0.5f;
                }
                else
                {
                    this.picRatio = 0.3f;
                }

                this.picFront.Size = new Size((int)((float)this.picFront.Image.Width * this.picRatio), (int)((float)this.picFront.Image.Size.Height * this.picRatio));
            }
        }

        /// <summary>
        /// 图片框鼠标按下事件
        /// </summary>
        private void picFront_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.picFront.Tag = e.Location;
                this.picFront.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 图片框鼠标移动事件
        /// </summary>
        private void picFront_MouseMove(object sender, MouseEventArgs e)
        {
            this.picFront.Cursor = Cursors.Default;

            if (e.Button == MouseButtons.Left && this.picFront.Tag != null)
            {
                this.picFront.Cursor = Cursors.NoMove2D;

                Point point = (Point)this.picFront.Tag;
                int num = 10;

                if (e.Location.X < point.X)
                {
                    int num2 = (point.X - e.Location.X) / num,
                        num3 = this.pnlpic.HorizontalScroll.Value + num2;

                    if (num3 > this.pnlpic.HorizontalScroll.Maximum)
                    {
                        this.pnlpic.HorizontalScroll.Value = this.pnlpic.HorizontalScroll.Maximum;
                    }
                    else
                    {
                        this.pnlpic.HorizontalScroll.Value = num3;
                    }
                }
                else
                {
                    int num4 = (e.Location.X - point.X) / num,
                        num5 = this.pnlpic.HorizontalScroll.Value - num4;

                    if (num5 < this.pnlpic.HorizontalScroll.Minimum)
                    {
                        this.pnlpic.HorizontalScroll.Value = this.pnlpic.HorizontalScroll.Minimum;
                    }
                    else
                    {
                        this.pnlpic.HorizontalScroll.Value = num5;
                    }
                }
                if (e.Location.Y < point.Y)
                {
                    int num6 = (point.Y - e.Location.Y) / num,
                        num7 = this.pnlpic.VerticalScroll.Value + num6;

                    if (num7 > this.pnlpic.VerticalScroll.Maximum)
                    {
                        this.pnlpic.VerticalScroll.Value = this.pnlpic.VerticalScroll.Maximum;

                        return;
                    }

                    this.pnlpic.VerticalScroll.Value = num7;

                    return;
                }
                else
                {
                    int num8 = (e.Location.Y - point.Y) / num,
                        num9 = this.pnlpic.VerticalScroll.Value - num8;

                    if (num9 < this.pnlpic.VerticalScroll.Minimum)
                    {
                        this.pnlpic.VerticalScroll.Value = this.pnlpic.VerticalScroll.Minimum;

                        return;
                    }

                    this.pnlpic.VerticalScroll.Value = num9;
                }
            }
        }

        /// <summary>
        /// 当前图片信息按钮点击事件
        /// </summary>
        private void btn_cmsCurrentImageInfo_Click(object sender, EventArgs e)
        {
            string text = "批次中序号：{0} \n图像尺寸：{1}X{2} \n";

            text += "班级：{3}\n";
            text += "考场：{4}\n";

            int num = 0,
                num2 = 0;

            if (this.picFront.Image != null)
            {
                Image image = this.picFront.Image;

                num = image.Width;
                num2 = image.Height;
            }

            VolumnDataRow curDataRow = this._curDataRow;

            if (curDataRow != null)
            {
                MessageBox.Show(string.Format(text, new object[]
				{
					curDataRow.Data.Index,
					num,
					num2,
					curDataRow.Data.Classname,
					curDataRow.Data.Room
				}), "图像信息");
            }
        }

        /// <summary>
        /// 复制试卷图片按钮点击事件
        /// </summary>
        private void btn_cmsCopyImages_Click(object sender, EventArgs e)
        {
            VolumnDataRow curDataRow = this._curDataRow;

            if (curDataRow != null)
            {
                StringCollection stringCollection = new StringCollection();

                for (int i = 0; i < curDataRow.Data.ImagePath.Length; i++)
                {
                    stringCollection.Add(Path.GetFullPath(PathHelper.LocalVolumneImgDir) + curDataRow.Data.ImagePath[i]);
                }

                Clipboard.SetFileDropList(stringCollection);
                MessageBox.Show("已复制到粘贴板", "提示");
            }
        }

        /// <summary>
        /// 更新图片框
        /// </summary>
        /// <param name="img">目标图片</param>
        public void UpdatePicBox(Bitmap img)
        {
            if (img == null && this.picFront.Image != null)
            {
                this.picFront.Image.Dispose();

                this.picFront.Image = null;

                return;
            }
            if (this.picFront.Image != null && img != null)
            {
                this.picFront.Image.Dispose();

                this.picFront.Image = null;
            }

            this.picFront.Image = img;

            if (this.picRatio < 1.2f && this.picFront.Image != null)
            {
                this.picRatio *= 1f;
                this.picFront.Size = new Size((int)((float)this.picFront.Image.Size.Width * this.picRatio), (int)((float)this.picFront.Image.Size.Height * this.picRatio));
            }
        }

        /// <summary>
        /// 设置当前卷数据行
        /// </summary>
        /// <param name="curRow">当前卷数据行</param>
        public void SetCurVolumnRow(VolumnDataRow curRow)
        {
            if (curRow != null)
            {
                string[] imagePath = curRow.Data.ImagePath;

                this._curDataRow = curRow;
                this._curDataRow.RefreshText();

                for (int i = 0; i < imagePath.Length; i++)
                {
                    this._curDataRow.Data.ImagePath[i] = imagePath[i];
                }

                if (imagePath != null && imagePath.Length > 0)
                {
                    Bitmap image = FileHelper.GetImage(PathHelper.LocalVolumneImgDir + imagePath[0]);

                    this._CurrentPageIndex = 0;
                    this.UpdatePicBox(image);

                    if (this.picFront.Image == null)
                    {
                        throw new Exception("学生试卷原图加载失败！请确认学生试卷原图本地已保存成功。");
                    }
                }
            }
            else
            {
                this._curDataRow = null;

                this.UpdatePicBox(null);
                this.omrErrorList.Clear();
                this.picFront_Paint(null, null);
                this.SetOnlyCurTabModifyVisiable(null);
            }
            if (this.PageIndexShownUpdateHandle != null)
            {
                this.PageIndexShownUpdateHandle(null, null);
            }

            this.omrErrorList.Clear();
        }

        /// <summary>
        /// 调整图片按钮点击事件
        /// </summary>
        private void btn_cmsAdjustImage_Click(object sender, EventArgs e)
        {
            VolumnDataRow curDataRow = this._curDataRow;

            if (curDataRow != null)
            {
                FormAdjustScanImg formAdjustScanImg = new FormAdjustScanImg();

                formAdjustScanImg.VolData = curDataRow;

                if (formAdjustScanImg.ShowDialog() == DialogResult.OK)
                {
                    this.SetCurVolumnRow(this._curDataRow);
                }

                formAdjustScanImg.Dispose();

                return;
            }

            MessageBox.Show("没有调整卷", "提示");
        }

        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        private void btn_Delete_zkzh_Click(object sender, EventArgs e)
        {
            if (this.opPaperStateChange != null)
            {
                this.opPaperStateChange(this._curDataRow, this.curOperateStatus, BaseOperation.Delete);
            }
        }

        /// <summary>
        /// 搜索名称文本改变事件
        /// </summary>
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            this._leakCount = 0;

            TreeListNode treeListNode = null;

            this.trlLeakUser.BeginUpdate();

            if (!string.IsNullOrEmpty(this.txtSearchName.Text))
            {
                IEnumerator enumerator = this.trlLeakUser.Nodes.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    TreeListNode treeListNode2 = (TreeListNode)enumerator.Current;
                    string text = (string)treeListNode2.GetValue(this.trcName.AbsoluteIndex);

                    if (!text.StartsWith(this.txtSearchName.Text))
                    {
                        treeListNode2.Visible = false;
                    }
                    else
                    {
                        this._leakCount++;

                        if (treeListNode == null)
                        {
                            treeListNode = treeListNode2;
                        }

                        treeListNode2.Visible = true;
                    }
                }

                goto IL_136;
            }

        IL_136:

            this.trlLeakUser.EndUpdate();
            this.trlLeakUser.SetFocusedNode(treeListNode);

            this.lblSearchTotal.Text = "共 " + this._leakCount + " 份";
        }

        /// <summary>
        /// 处理考号异常时 3 个文本框回车事件（考号/姓名/姓名首字母拼音）
        /// </summary>
        private void txtSearchEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.trlLeakUser.Focus();
                }

                return;
            }
            if (((TextBox)sender).Text == string.Empty)
            {
                MessageBox.Show("请输入搜索关键字", "提示");

                return;
            }
            if (this._leakCount > 1 && MessageBox.Show("列表存在多个同名考生，是否匹配第一项", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
            {
                return;
            }

            this.trlLeakUser_DoubleClick(null, null);
            ((TextBox)sender).Focus();
        }

        /// <summary>
        /// 搜索学号框文本改变事件
        /// </summary>
        private void txtSearchSchoolnumber_TextChanged(object sender, EventArgs e)
        {
            this._leakCount = 0;

            TreeListNode treeListNode = null;

            this.trlLeakUser.BeginUpdate();

            if (!string.IsNullOrEmpty(this.txtSearchSchoolnumber.Text))
            {
                IEnumerator enumerator = this.trlLeakUser.Nodes.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    TreeListNode treeListNode2 = (TreeListNode)enumerator.Current;
                    string text = (string)treeListNode2.GetValue(this.trcExamCode.AbsoluteIndex);

                    if (!text.StartsWith(this.txtSearchSchoolnumber.Text))
                    {
                        treeListNode2.Visible = false;
                    }
                    else
                    {
                        this._leakCount++;

                        if (treeListNode == null)
                        {
                            treeListNode = treeListNode2;
                        }

                        treeListNode2.Visible = true;
                    }
                }

                goto IL_136;
            }

        IL_136:

            this.trlLeakUser.EndUpdate();
            this.trlLeakUser.SetFocusedNode(treeListNode);

            this.lblSearchTotal.Text = "共 " + this._leakCount + " 份";
        }

        /// <summary>
        /// 搜索拼音框文本改变事件
        /// </summary>
        private void txtSearchPingyin_TextChanged(object sender, EventArgs e)
        {
            this._leakCount = 0;

            TreeListNode treeListNode = null;

            this.trlLeakUser.BeginUpdate();

            if (!string.IsNullOrEmpty(this.txtSearchPingyin.Text))
            {
                IEnumerator enumerator = this.trlLeakUser.Nodes.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    TreeListNode treeListNode2 = (TreeListNode)enumerator.Current;
                    string text = (string)treeListNode2.GetValue(this.trcpingying.AbsoluteIndex);
                    List<string> list = new List<string>();

                    list.AddRange(text.Split(new char[]
						{
							','
						}));

                    if (list.Find((string P) => P.StartsWith(this.txtSearchPingyin.Text.ToUpper())) == null)
                    {
                        treeListNode2.Visible = false;
                    }
                    else
                    {
                        this._leakCount++;

                        if (treeListNode == null)
                        {
                            treeListNode = treeListNode2;
                        }

                        treeListNode2.Visible = true;
                    }
                }

                goto IL_16E;
            }

        IL_16E:

            this.trlLeakUser.EndUpdate();
            this.trlLeakUser.SetFocusedNode(treeListNode);

            this.lblSearchTotal.Text = "共 " + this._leakCount + " 份";
        }

        /// <summary>
        /// 树形列表的节点焦点改变事件
        /// </summary>
        private void trlLeakUser_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                string str = (string)e.Node.GetValue(this.trcClassName.AbsoluteIndex),
                    text = (string)e.Node.GetValue(this.trcRoom.AbsoluteIndex);

                this.ricLeakInfo.Text = " 班级：" + str + (string.IsNullOrEmpty(text) ? string.Empty : (" 考场：" + text));

                return;
            }

            this.ricLeakInfo.Text = string.Empty;
        }

        /// <summary>
        /// 学生信息双击事件
        /// </summary>
        private void trlLeakUser_DoubleClick(object sender, EventArgs e)
        {
            if (this.opPaperStateChange != null && this.trlLeakUser.FocusedNode != null)
            {
                string userid = this.trlLeakUser.FocusedNode.GetValue(this.trcUserID.AbsoluteIndex).ToString(),
                    zkzh = this.trlLeakUser.FocusedNode.GetValue(this.trcExamCode.AbsoluteIndex).ToString(),
                    classid = this.trlLeakUser.FocusedNode.GetValue(this.trcClassid.AbsoluteIndex).ToString(),
                    studentName = this.trlLeakUser.FocusedNode.GetValue(this.trcName.AbsoluteIndex).ToString(),
                    classname = (string)this.trlLeakUser.FocusedNode.GetValue(this.trcClassName.AbsoluteIndex),
                    room = (string)this.trlLeakUser.FocusedNode.GetValue(this.trcRoom.AbsoluteIndex);
                VolumnDataRow curDataRow = this._curDataRow;

                curDataRow.Data.Status.Remove(VolumeStatus.ErrZkzh);
                curDataRow.Data.Userid = int.Parse(userid);
                curDataRow.Data.Zkzh = zkzh;
                curDataRow.Data.StudentName = studentName;
                curDataRow.Data.Classid = classid;
                curDataRow.Data.Room = room;
                curDataRow.Data.Classname = classname;

                this.opPaperStateChange(curDataRow, this.curOperateStatus, BaseOperation.Update);
            }
        }

        /// <summary>
        /// 树形列表的按键长按事件
        /// </summary>
        private void trlLeakUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.trlLeakUser_DoubleClick(null, null);
                this.txtSearchName.Focus();
            }
        }

        /// <summary>
        /// 识别信息树形列表的节点焦点改变事件
        /// </summary>
        private void trlOmrList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            int num = Convert.ToInt32(e.Node.GetValue(this.trcItemCount.AbsoluteIndex));

            Convert.ToBoolean(e.Node.GetValue(this.trcMultiSelect.AbsoluteIndex));
            this.trcOmrAnswer.BeginUpdate();

            this.trcOmrAnswer.Mask.EditMask = string.Concat(new object[]
			{
				"[A-",
				(char)(64 + num),
				"]{0,",
				num,
				"}"
			});

            this.trcOmrAnswer.EndUpdate();
        }

        /// <summary>
        /// 识别信息属性列表自定义绘制节点事件
        /// </summary>
        private void trlOmrList_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            if (this._curDataRow != null)
            {
                VolumnDataRow curDataRow = this._curDataRow;

                if (curDataRow != null && curDataRow.Data.Status.Contains(VolumeStatus.ErrOmr))
                {
                    int num = Convert.ToInt32(e.Node.GetValue(this.trcModifyStatus.AbsoluteIndex));
                    OmrValueType omrValueType = (OmrValueType)e.Node.GetValue(this.trcOmrValType.AbsoluteIndex);

                    if (num == 0)
                    {
                        if (omrValueType == OmrValueType.NotConfirm)
                        {
                            e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
                        }
                        if (e.ImageIndex > -1)
                        {
                            Image image = (sender as TreeList).Painter.IndicatorImages.Images[e.ImageIndex];
                            int x = e.Bounds.Left + (e.Bounds.Width - image.Width) / 2,
                                y = e.Bounds.Top + (e.Bounds.Height - image.Height) / 2;

                            e.Graphics.DrawImage(image, new Point(x, y));
                        }

                        e.Handled = true;

                        return;
                    }
                }
            }

            e.Handled = false;
        }

        /// <summary>
        /// 左放大事件
        /// </summary>
        private void btnLeftZoom_Click(object sender, EventArgs e)
        {
            if (this.picFront.Image != null && this.picRatio < 1.2f)
            {
                this.picRatio *= 1.13345f;
                this.picFront.Size = new Size((int)((float)this.picFront.Image.Size.Width * this.picRatio), (int)((float)this.picFront.Image.Size.Height * this.picRatio));
            }
        }

        /// <summary>
        /// 左缩小事件
        /// </summary>
        private void btnLeftSmall_Click(object sender, EventArgs e)
        {
            if (this.picFront.Image != null && this.picRatio > 0.25f)
            {
                this.picRatio *= 0.90234f;
                this.picFront.Size = new Size((int)((float)this.picFront.Image.Size.Width * this.picRatio), (int)((float)this.picFront.Image.Size.Height * this.picRatio));
            }
        }

        /// <summary>
        /// 上一页事件
        /// </summary>
        private void btnPrePage_Click(object sender, EventArgs e)
        {
            VolumnDataRow curDataRow = this._curDataRow;

            if (curDataRow != null && this._CurrentPageIndex - 1 >= 0)
            {
                this._CurrentPageIndex--;

                Bitmap image = FileHelper.GetImage(PathHelper.LocalVolumneImgDir + curDataRow.Data.ImagePath[this._CurrentPageIndex]);

                this.UpdatePicBox(image);
            }
        }

        /// <summary>
        /// 下一页事件
        /// </summary>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            VolumnDataRow curDataRow = this._curDataRow;

            if (curDataRow != null && this._CurrentPageIndex + 1 < curDataRow.Data.ImagePath.Length)
            {
                this._CurrentPageIndex++;

                Bitmap image = FileHelper.GetImage(PathHelper.LocalVolumneImgDir + curDataRow.Data.ImagePath[this._CurrentPageIndex]);

                this.UpdatePicBox(image);
            }
        }

        /// <summary>
        /// 处理操作
        /// </summary>
        /// <param name="type">操作类型</param>
        public void PicOperate(int type)
        {
            switch (type)
            {
                case 0:
                    this.btnLeftZoom_Click(null, null);

                    break;
                case 1:
                    this.btnLeftSmall_Click(null, null);

                    break;
                case 2:
                    this.btnPrePage_Click(null, null);

                    break;
                case 3:
                    this.btnNextPage_Click(null, null);

                    break;
            }

            if (this.PageIndexShownUpdateHandle != null)
            {
                this.PageIndexShownUpdateHandle(null, null);
            }
        }

        /// <summary>
        /// 显示识别校正数据
        /// </summary>
        /// <returns>操作结果</returns>
        private bool ShowMORCorrectData()
        {
            if (this._curDataRow != null)
            {
                this.omrErrorList.Clear();

                string omr = this._curDataRow.Data.Omr;

                if (string.IsNullOrEmpty(omr.Trim()))
                {
                    return true;
                }

                string[] array = omr.Split(new char[]
				{
					',',
					';',
					'|'
				}, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < this.trlOmrList.Nodes.Count; i++)
                {
                    Convert.ToInt32(this.trlOmrList.Nodes[i].GetValue(this.trcObjectNum.AbsoluteIndex));
                    Convert.ToInt32(this.trlOmrList.Nodes[i].GetValue(this.trcItemCount.AbsoluteIndex));

                    List<bool> list = (List<bool>)this.trlOmrList.Nodes[i].GetValue(this.trcCheckStatus.AbsoluteIndex);

                    if (array[i] == "-" || array[i] == "?")
                    {
                        array[i] = string.Empty;
                    }

                    this.omrErrorList.Add(this.trlOmrList.Nodes[i]);
                    this.trlOmrList.Nodes[i].SetValue(this.trcModifyStatus, 1);
                    this.trlOmrList.Nodes[i].SetValue(this.trcAnswer.AbsoluteIndex, array[i]);
                    this.trlOmrList.Nodes[i].SetValue(this.trcOmrValType, OmrValueType.Confirm);

                    for (int j = 0; j < list.Count; j++)
                    {
                        list[j] = false;

                        for (int k = 0; k < array[i].Length; k++)
                        {
                            if (j == (int)(array[i][k] - 'A'))
                            {
                                list[j] = true;
                            }
                        }
                    }

                    this.trlOmrList.Nodes[i].SetValue(this.trcCheckStatus.AbsoluteIndex, list);
                }
            }

            return true;
        }

        /// <summary>
        /// 焦点到下一个识别编辑
        /// </summary>
        /// <returns>操作状态</returns>
        private bool FocusNextOmrEdit()
        {
            bool result = false,
                flag = false;

            for (int i = 0; i < this.trlOmrList.Nodes.Count; i++)
            {
                if ((OmrValueType)this.trlOmrList.Nodes[i].GetValue(this.trcOmrValType.AbsoluteIndex) == OmrValueType.Empty)
                {
                    flag = true;

                    break;
                }
            }
            for (int j = 0; j < this.trlOmrList.Nodes.Count; j++)
            {
                int num = Convert.ToInt32(this.trlOmrList.Nodes[j].GetValue(this.trcPageindex.AbsoluteIndex)),
                    num2 = Convert.ToInt32(this.trlOmrList.Nodes[j].GetValue(this.trcModifyStatus.AbsoluteIndex));
                List<Rectangle> list = (List<Rectangle>)this.trlOmrList.Nodes[j].GetValue(this.trcRect.AbsoluteIndex);
                OmrValueType omrValueType = (OmrValueType)this.trlOmrList.Nodes[j].GetValue(this.trcOmrValType.AbsoluteIndex);

                if (num2 == 0 && (!flag || omrValueType != OmrValueType.NotConfirm))
                {
                    if (num > this._CurrentPageIndex)
                    {
                        this.btnNextPage_Click(null, null);
                    }
                    else if (num < this._CurrentPageIndex)
                    {
                        this.btnPrePage_Click(null, null);
                    }

                    int num3 = (int)((float)list[0].X * this.picRatio),
                        num4 = (int)((float)list[list.Count - 1].Y * this.picRatio);

                    this.trlOmrList.FocusedNode = this.trlOmrList.Nodes[j];
                    this.pnlpic.VerticalScroll.Value = (this.pnlpic.VerticalScroll.Maximum - this.pnlpic.VerticalScroll.LargeChange) * num4 / this.picFront.Height;
                    this.pnlpic.HorizontalScroll.Value = (this.pnlpic.HorizontalScroll.Maximum - this.pnlpic.HorizontalScroll.LargeChange) * num3 / this.picFront.Width;

                    result = true;

                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 显示识别错误数据
        /// </summary>
        /// <returns>操作结果</returns>
        private bool ShowOMRerrorData()
        {
            if (this._curDataRow != null)
            {
                this.trlOmrList.Focus();
                this.trlOmrList.BeginUpdate();

                string omr = this._curDataRow.Data.Omr;

                if (string.IsNullOrEmpty(omr.Trim()))
                {
                    for (int i = 0; i < this.trlOmrList.Nodes.Count; i++)
                    {
                        this.trlOmrList.Nodes[i].SetValue(this.trcModifyStatus, 0);
                        this.trlOmrList.Nodes[i].SetValue(this.trcOmrValType, OmrValueType.Empty);
                        this.trlOmrList.Nodes[i].SetValue(this.trcAnswer.AbsoluteIndex, string.Empty);
                        this.omrErrorList.Add(this.trlOmrList.Nodes[i]);

                        List<bool> list = (List<bool>)this.trlOmrList.Nodes[i].GetValue(this.trcCheckStatus.AbsoluteIndex);

                        for (int j = 0; j < list.Count; j++)
                        {
                            list[j] = false;
                        }
                    }
                }
                else
                {
                    string[] array = omr.Split(new char[]
					{
						',',
						';',
						'|'
					}, StringSplitOptions.RemoveEmptyEntries);

                    if (array.Length < this.trlOmrList.Nodes.Count)
                    {
                        MessageBox.Show("模板已修改，请先重新识别再查看该异常卷！", "数据异常提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return false;
                    }

                    for (int k = 0; k < this.trlOmrList.Nodes.Count; k++)
                    {
                        int objectiveID = Convert.ToInt32(this.trlOmrList.Nodes[k].GetValue(this.trcObjectNum.AbsoluteIndex));

                        Convert.ToInt32(this.trlOmrList.Nodes[k].GetValue(this.trcItemCount.AbsoluteIndex));

                        List<bool> list2 = (List<bool>)this.trlOmrList.Nodes[k].GetValue(this.trcCheckStatus.AbsoluteIndex);

                        if (array[k] != "-" && array[k] != "?")
                        {
                            OmrItem omrItem = this._curDataRow.Data.OmrItemList.Find((OmrItem p) => p.ObjectiveID == objectiveID);

                            if (omrItem != null && omrItem.type == OmrValueType.NotConfirm)
                            {
                                this.omrErrorList.Add(this.trlOmrList.Nodes[k]);
                                this.trlOmrList.Nodes[k].SetValue(this.trcAnswer.AbsoluteIndex, omrItem.Answer.ToString().Trim());
                                this.trlOmrList.Nodes[k].SetValue(this.trcModifyStatus, 0);
                                this.trlOmrList.Nodes[k].SetValue(this.trcOmrValType, OmrValueType.NotConfirm);
                            }
                            else
                            {
                                this.trlOmrList.Nodes[k].SetValue(this.trcModifyStatus, -1);
                                this.trlOmrList.Nodes[k].SetValue(this.trcAnswer.AbsoluteIndex, array[k]);
                                this.trlOmrList.Nodes[k].SetValue(this.trcOmrValType, OmrValueType.Confirm);
                            }
                        }
                        else
                        {
                            this.omrErrorList.Add(this.trlOmrList.Nodes[k]);
                            this.trlOmrList.Nodes[k].SetValue(this.trcAnswer.AbsoluteIndex, string.Empty);
                            this.trlOmrList.Nodes[k].SetValue(this.trcModifyStatus, 0);
                            this.trlOmrList.Nodes[k].SetValue(this.trcOmrValType, OmrValueType.Empty);
                        }

                        for (int l = 0; l < list2.Count; l++)
                        {
                            list2[l] = false;
                        }

                        this.trlOmrList.Nodes[k].SetValue(this.trcCheckStatus.AbsoluteIndex, list2);
                    }
                }

                this.trlOmrList.EndUpdate();
                this.FocusNextOmrEdit();
            }

            return true;
        }

        /// <summary>
        /// 处理考号错误
        /// </summary>
        /// <param name="curRow">当前数据行</param>
        private void DealWithZkzhEror(VolumnDataRow curRow)
        {
            if (this.trlLeakUser.Nodes.Count > 0)
            {
                this.trlLeakUser.FocusedNode = this.trlLeakUser.Nodes[0];

                if (curRow != null && (curRow.Data.Status.Contains(VolumeStatus.Ambiguous) || curRow.Data.Status.Contains(VolumeStatus.Duplicate) || curRow.Data.Status.Contains(VolumeStatus.ErrorPage) || curRow.Data.Status.Contains(VolumeStatus.ErrZkzh)))
                {
                    this.txtSearchSchoolnumber.Text = string.Empty;
                    this.txtSearchName.Text = string.Empty;
                    this.txtSearchPingyin.Text = string.Empty;
                    this.pnlpic.HorizontalScroll.Value = 0;
                    this.pnlpic.VerticalScroll.Value = 0;
                    this.tabZkzhModify.PageVisible = true;
                    this.tabOmrModify.PageVisible = false;
                    this.picRatio = 0.5f;
                    this.picFront.Size = new Size((int)((float)this.picFront.Image.Width * this.picRatio), (int)((float)this.picFront.Image.Size.Height * this.picRatio));

                    if (curRow.Data.Status.Contains(VolumeStatus.Duplicate))
                    {
                        this.txtSearchSchoolnumber.Text = curRow.Zkzh;

                        this.txtSearchSchoolnumber.Focus();

                        return;
                    }

                    this.txtSearchName.Focus();
                }
            }
        }

        /// <summary>
        /// 错误操作状态管理
        /// </summary>
        /// <param name="curState">当前装填</param>
        public void ErrorOperateStatusManager(PaperOperateStatus curState)
        {
            if (this._curDataRow != null)
            {
                this.lbl_ErrorDetails.Text = string.Format("批次位置:{0} 错误类型：{1} 考号识别结果：{2}", this._curDataRow.Data.Index, this._curDataRow.StatusConcatString, this._curDataRow.Data.Zkzh);
            }
            switch (curState)
            {
                case PaperOperateStatus.Normal:
                    if (this.ShowCorrectOMRResult)
                    {
                        this.ShowMORCorrectData();
                    }
                    this.cms_picpanel.Enabled = true;

                    this.SetOnlyCurTabModifyVisiable(null);

                    goto IL_16D;
                case PaperOperateStatus.Omr:
                    if (this.ShowOMRerrorData())
                    {
                        this.SetOnlyCurTabModifyVisiable(this.tabOmrModify);

                        goto IL_16D;
                    }

                    this.SetOnlyCurTabModifyVisiable(null);

                    goto IL_16D;
                case PaperOperateStatus.Zkzh:
                    this.omrErrorList.Clear();
                    this.picFront.Invalidate();
                    this.DealWithZkzhEror(this._curDataRow);
                    this.SetOnlyCurTabModifyVisiable(this.tabZkzhModify);

                    goto IL_16D;
                case PaperOperateStatus.PaperError:
                    this.omrErrorList.Clear();
                    this.picFront.Invalidate();

                    this.tabErrorPaperManager.PageEnabled = true;

                    this.SetOnlyCurTabModifyVisiable(this.tabErrorPaperManager);

                    goto IL_16D;
                case PaperOperateStatus.LaterDealWith:
                    MessageBox.Show("这里需要根据具体的错误类型显示页面");

                    goto IL_16D;
                case PaperOperateStatus.Empty:
                    this.UpdatePicBox(null);
                    this.omrErrorList.Clear();
                    this.picFront_Paint(null, null);
                    this.SetOnlyCurTabModifyVisiable(null);

                    this._curDataRow = null;
                    this.cms_picpanel.Enabled = false;

                    goto IL_16D;
            }

            this.SetOnlyCurTabModifyVisiable(null);

        IL_16D:

            this.curOperateStatus = curState;
        }

        /// <summary>
        /// 刷新遗漏列表
        /// </summary>
        /// <returns>操作状态</returns>
        public bool RefreshLeakGrid()
        {
            try
            {
                int num = 0;
                List<string> list = new List<string>();

                foreach (ScanRecord current in ScanGlobalInfo.ExamInfo.ScanRecordList)
                {
                    if (!(current.EsId > 0))
                    {
                        list.Add(current.EsId.ToString());
                    }
                }

                this.trlLeakUser.BeginUpdate();

                if (this.trlLeakUser.Nodes != null)
                {
                    for (int i = 0; i < this.trlLeakUser.Nodes.Count; i++)
                    {
                        TreeListNode treeListNode = this.trlLeakUser.Nodes[i];
                        string item = treeListNode.GetValue(this.trcUserID).ToString();

                        if (!list.Contains(item))
                        {
                            treeListNode.Visible = true;
                            num++;
                        }
                        else
                        {
                            treeListNode.Visible = false;
                        }
                    }
                }

                this.trlLeakUser.EndUpdate();

                this.lblSearchTotal.Text = "共 " + num + " 份";
            }
            catch (Exception ex)
            {
                _bdBLL.System_SaveErrorLog(ex, "刷新学生列表出错；界面：ScanExamImageForm");

                return false;
            }

            return true;
        }

        /// <summary>
        /// 初始化遗漏列表
        /// </summary>
        /// <returns>操作结果</returns>
        public bool IntiaLeakGrid()
        {
            try
            {
                List<StudentExamInfo> studentExamInfoList = ScanGlobalInfo.ExamInfo.StudentExamInfoList;

                this.trlLeakUser.BeginUpdate();

                foreach (StudentExamInfo current in studentExamInfoList)
                {
                    this.trlLeakUser.AppendNode(new object[]
					{
						current.StuName,
                        current.Room,
                        current.ClassName,
                        current.ID,
                        current.ClassId,
                        current.StudentNamePinYin,
                        current.ExamCode
					}, null);
                }

                this.trlLeakUser.EndUpdate();
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);

                return false;
            }

            return true;
        }

        /// <summary>
        /// 初始化识别列表
        /// </summary>
        /// <param name="curTemplate">当前模板信息</param>
        /// <returns>操作结果</returns>
        public bool InitialOmrGrid(TemplateInfo curTemplate)
        {
            try
            {
                if (curTemplate == null)
                {
                    bool result = false;

                    return result;
                }

                List<OmrBindItem> list = new List<OmrBindItem>();
                Page[] pages = LoadTplFLoadTemplateFile.CurTemplateInfo.pages,
                    array = pages;

                for (int m = 0; m < array.Length; m++)
                {
                    Page page = array[m];

                    if (page != null && page.OmrObjectives != null)
                    {
                        OmrObjective[] omrObjectives = page.OmrObjectives;

                        for (int j = 0; j < omrObjectives.Length; j++)
                        {
                            OmrObjective omrObjective = omrObjectives[j];

                            if (omrObjective != null && omrObjective.objectiveItems != null)
                            {
                                OmrObjectiveItem[] objectiveItems = omrObjective.objectiveItems;

                                for (int k = 0; k < objectiveItems.Length; k++)
                                {
                                    OmrObjectiveItem omrObjectiveItem = objectiveItems[k];

                                    OmrBindItem omrBindItem = new OmrBindItem();

                                    list.Add(omrBindItem);

                                    omrBindItem.ObjectiveID = omrObjectiveItem.num.number;
                                    omrBindItem.pageindex = page.pageIndex;
                                    omrBindItem.ItemCount = omrObjectiveItem.ItemRects.Length;
                                    omrBindItem.ModifyStatus = -1;
                                    omrBindItem.MultiSelect = true;
                                    omrBindItem.omrValType = OmrValueType.Empty;
                                    omrBindItem.Answer = "";

                                    CvRect[] itemRects = omrObjectiveItem.ItemRects;

                                    for (int l = 0; l < itemRects.Length; l++)
                                    {
                                        CvRect cvRect = itemRects[l];
                                        Rectangle item = default(Rectangle);

                                        item.X = cvRect.x;
                                        item.Y = cvRect.y;
                                        item.Width = cvRect.width;
                                        item.Height = cvRect.height;

                                        omrBindItem.Rects.Add(item);
                                        omrBindItem.CheckStatus.Add(false);
                                    }
                                }
                            }
                        }
                    }
                }

                list = (from i in list
                        orderby i.ObjectiveID
                        select i).ToList<OmrBindItem>();

                foreach (OmrBindItem current in list)
                {
                    this.trlOmrList.AppendNode(new object[]
					{
						current.ObjectiveID,
						current.Answer,
						current.ItemCount,
						current.pageindex,
						current.Rects,
						current.MultiSelect,
						current.ModifyStatus,
						current.CheckStatus,
						current.omrValType
					}, null);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);

                bool result = false;

                return result;
            }

            return true;
        }
    }
}
