using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YXH.Common.Form;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.Main
{
    public partial class SubjectListForm : Form
    {
        /// <summary>
        /// 状态改变委托
        /// </summary>
        /// <param name="exam">考试对象</param>
        /// <param name="curOpStatus">当前状态</param>
        public delegate void StateChangeHandle(object exam, OperateStatus curOpStatus);
        /// <summary>
        /// 学校考试信息
        /// </summary>
        private BaseDisposeBLL _bdBLL;
        /// <summary>
        /// 操作状态改变事件
        /// </summary>
        public event SubjectListForm.StateChangeHandle opStateChange;

        /// <summary>
        /// 构造方法
        /// </summary>
        public SubjectListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取并绑定考试组信息
        /// </summary>
        private void GetExamGroupList()
        {
            try
            {
                FormProgress fp = new FormProgress();

                fp.Show();
                fp.SetProgress(10, "正在获取考试");

                List<ExamGroup> egList = new List<ExamGroup>();
                ExamGroupResponse egResponse = _bdBLL.ExamGroup_GetList(string.Concat(((int)MarkingStatus.NotStarted).ToString(), ",", ((int)MarkingStatus.Suspend).ToString()));

                fp.SetProgress(30, "正在检查考试信息");

                if (egResponse.Success)
                {
                    if (egResponse.Data.Count > 0)
                    {
                        fp.SetProgress(100, "获取完成");
                        fp.Close();

                        egList = egResponse.Data;
                    }
                    else
                    {
                        fp.SetProgress(100, "获取完成，没有找到考试信息");
                        fp.Close();
                        MessageBox.Show("没有获取到考试，请确认是否已创建考试。", "提示", MessageBoxButtons.OK);
                        _bdBLL.System_SaveDebugLog("没有获取到考试，请确认是否已创建考试。");

                        return;
                    }
                }
                else
                {
                    fp.SetProgress(100, "获取考试信息失败");
                    fp.Close();
                    MessageBox.Show(egResponse.Error.Message, "提示", MessageBoxButtons.OK);

                    return;
                }
                if (egList != null && egList.Count > 0)
                {
                    egList.Add(new ExamGroup()
                    {
                        Id = int.MaxValue,
                        ExamName = "请选择"
                    });
                    egList = egList.OrderByDescending(a => a.Id).ToList();

                    cbxExamGroup.DataSource = egList;
                    cbxExamGroup.ValueMember = "Id";
                    cbxExamGroup.DisplayMember = "ExamName";
                    cbxExamGroup.SelectedIndex = 0;

                    return;
                }

                MessageBox.Show("未获取到有效的考试组信息，请确认是否已新建考试组信息。", "提示", MessageBoxButtons.OK);

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取考试组信息异常" + Environment.NewLine + "详细信息:" + Environment.NewLine + ex.ToString(), "提示");
                _bdBLL.System_SaveErrorLog(ex, "窗体SubjectListForm 加载数据异常");
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initial()
        {
            this._bdBLL = new BaseDisposeBLL();

            GetExamGroupList();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void SubjectListForm_Load(object sender, EventArgs e)
        {
            this.initial();
        }

        /// <summary>
        /// 窗体大小改变事件
        /// </summary>
        private void SubjectListForm_SizeChanged(object sender, EventArgs e)
        {
            if (Width < 1020)
            {
                panel_body.Width = Width;

                return;
            }

            panel_body.Width = 1020;
            panel_body.Location = new Point((Width - panel_body.Width) / 2, panel_body.Location.Y);
        }

        /// <summary>
        /// 下拉框绘制项事件
        /// </summary>
        private void cbxExamGroup_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (cbxExamGroup.Items.Count > 0)
            {
                ExamGroup eg = ((ExamGroup)cbxExamGroup.Items[e.Index]);
                SizeF sf = e.Graphics.MeasureString(eg.ExamName, e.Font);
                float startPointX = (float)(e.Bounds.Width - sf.Width) / 2,
                    startPointY = (float)(40 - sf.Height) / 2;

                startPointX = startPointX < 0 ? 0f : startPointX;
                startPointY = startPointY < 0 ? 0f : startPointY;
                startPointY = startPointY + cbxExamGroup.ItemHeight * e.Index;

                if ((e.State & DrawItemState.Selected) != 0)    //判断当前项是否选中
                {
                    e.Graphics.DrawString(eg.ExamName, this.Font, new Pen(Color.FromArgb(95, 180, 27)).Brush, e.Bounds, StringFormat.GenericDefault);

                    return;
                }

                e.Graphics.DrawString(eg.ExamName, this.Font, new Pen(Color.Black).Brush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }

        /// <summary>
        /// 考试列表覆盖lbl点击事件
        /// </summary>
        private void lblComboBoxImage_Click(object sender, EventArgs e)
        {
            cbxExamGroup.DroppedDown = true;
        }

        /// <summary>
        /// 年级按钮鼠标点击事件
        /// </summary
        protected void pb_Click(object sender, EventArgs e)
        {
            Control curControl = (sender as Control);
            ScanGlobalInfo.ExamGrade = curControl.Tag as ExamGrade;

            foreach (Control c in panSeniorHighSchool.Controls)
            {
                ExamGrade egModel = c.Tag as ExamGrade;

                if (!egModel.Equals(ScanGlobalInfo.ExamGrade))
                {
                    c.BackgroundImage = SubjectListFormRes.GradeButton_BackImage_Normal;
                }
            }
            foreach (Control c in panCompulsoryEducation.Controls)
            {
                ExamGrade egModel = c.Tag as ExamGrade;

                if (!egModel.Equals(ScanGlobalInfo.ExamGrade))
                {
                    c.BackgroundImage = SubjectListFormRes.GradeButton_BackImage_Normal;
                }
            }

            panSubjcetRow1.Controls.Clear();
            panSubjcetRow2.Controls.Clear();
            InitSubjectPanel();
        }

        /// <summary>
        /// 年级按钮鼠标离开事件
        /// </summary>
        protected void pb_MouseLave(object sender, EventArgs e)
        {
            Control c = (sender as Control);
            ExamGrade egModel = c.Tag as ExamGrade;

            if (egModel.Equals(ScanGlobalInfo.ExamGrade))
            {
                return;
            }
            if (c.Name.Contains("lbl"))
            {
                c.Parent.BackgroundImage = SubjectListFormRes.GradeButton_BackImage_Normal;

                return;
            }

            Panel pan = (sender as Panel);

            pan.BackgroundImage = SubjectListFormRes.GradeButton_BackImage_Normal;
        }

        /// <summary>
        /// 年级按钮鼠标移入事件
        /// </summary>
        protected void pb_MouseEnter(object sender, EventArgs e)
        {
            Control c = (sender as Control);

            if (c.Name.Contains("lbl"))
            {
                c.Parent.BackgroundImage = SubjectListFormRes.GradeButton_BackImage_Hover;

                return;
            }

            Panel pan = (sender as Panel);

            pan.BackgroundImage = SubjectListFormRes.GradeButton_BackImage_Hover;
        }

        /// <summary>
        /// 添加按钮到指定控件
        /// </summary>
        /// <param name="pan">指定控件</param>
        /// <param name="egModel">控件的数据属性</param>
        private void AddPicToPanel(Panel pan, ExamGrade egModel)
        {
            Label lblButton = new Label();

            lblButton.AutoSize = true;
            lblButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)(51))), ((int)((byte)(51))), ((int)((byte)(51))));
            lblButton.BackColor = Color.FromArgb(((int)((byte)(244))), ((int)((byte)(244))), ((int)((byte)(244))));
            lblButton.Text = egModel.GradeName.Trim();
            lblButton.Tag = egModel;
            lblButton.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lblButton.Padding = new Padding(0);
            lblButton.Margin = new Padding(0);
            lblButton.Name = string.Format("lblButton{0}", pan.Controls.Count);
            lblButton.Size = new Size(75, 15);
            lblButton.MouseEnter += new EventHandler(pb_MouseEnter);
            lblButton.Click += new EventHandler(pb_Click);

            Panel panButton = new Panel();

            panButton.Padding = new Padding(0);
            panButton.Margin = new System.Windows.Forms.Padding(0);
            panButton.Size = new Size(91, 30);
            panButton.Tag = egModel;
            panButton.Name = string.Format("panButton{0}", pan.Controls.Count);
            panButton.BackgroundImage = SubjectListFormRes.GradeButton_BackImage_Normal;
            panButton.MouseLeave += new EventHandler(pb_MouseLave);
            panButton.Click += new EventHandler(pb_Click);
            panButton.MouseEnter += new EventHandler(pb_MouseEnter);

            panButton.Controls.Add(lblButton);

            lblButton.Location = new Point((panButton.Width - lblButton.Width) / 2, (panButton.Height - lblButton.Height) / 2);

            pan.Controls.Add(panButton);

            if (pan.Controls.Count > 1)
            {
                int maxX = 0,
                    controlWidthSum = 0;
                Control lastControl = new Control();

                foreach (Control c in pan.Controls)
                {
                    if (c.Location.X > maxX)
                    {
                        maxX = c.Location.X;
                        lastControl = c;
                    }

                    controlWidthSum += c.Width;
                }

                panButton.Location = new Point((pan.Controls.Count - 1) * 18 + controlWidthSum - panButton.Width, panButton.Location.Y);
                pan.Width = (pan.Controls.Count - 1) * 18 + controlWidthSum;
            }
            else
            {
                panButton.Location = new Point(0, 0);
                pan.Size = new Size(panButton.Width, panButton.Height);
            }
        }

        /// <summary>
        /// 初始化高中年级面板
        /// </summary>
        /// <param name="eiModelList">考试列表</param>
        private void InitSeniorHighSchoolPanel(List<ExamGrade> egList)
        {
            if (panSeniorHighSchool.Controls.Count > 0)
            {
                panSeniorHighSchool.Controls.Clear();
            }

            List<ExamGrade> egBindList = egList.Where(a => a.GradeId > 9).ToList();

            if (egBindList.Count < 1)
            {
                return;
            }

            panSeniorHighSchool.Visible = true;

            foreach (ExamGrade egModel in egBindList)
            {
                if (egModel.GradeId > 9)
                {
                    AddPicToPanel(panSeniorHighSchool, egModel);

                    panSeniorHighSchool.Location = new Point((panSelectGrade.Width - panSeniorHighSchool.Width) / 2, panSeniorHighSchool.Location.Y);
                }
            }
        }

        /// <summary>
        /// 初始化义务教育面板
        /// </summary>
        /// <param name="eiModelList">考试列表</param>
        private void InitCompulsoryEducationPanel(List<ExamGrade> egList)
        {
            if (panCompulsoryEducation.Controls.Count > 0)
            {
                panCompulsoryEducation.Controls.Clear();
            }

            List<ExamGrade> egBindList = egList.Where(a => a.GradeId < 10).ToList();

            if (egBindList.Count < 1)
            {
                return;
            }

            panCompulsoryEducation.Visible = true;

            foreach (ExamGrade egModel in egBindList)
            {
                AddPicToPanel(panCompulsoryEducation, egModel);

                int panCompulsoryEducationLocationPointY = 0;

                if (panSeniorHighSchool.Visible)
                {
                    panCompulsoryEducationLocationPointY = panSeniorHighSchool.Location.Y + panSeniorHighSchool.Height + 18;
                }
                else
                {
                    panCompulsoryEducationLocationPointY = panSeniorHighSchool.Location.Y;
                }

                panCompulsoryEducation.Location = new Point((panSelectGrade.Width - panCompulsoryEducation.Width) / 2, panCompulsoryEducationLocationPointY);
            }
        }

        /// <summary>
        /// 初始化年级面板
        /// </summary>
        /// <param name="eiModelList"></param>
        private void InitGradePanel()
        {
            ExamGradeResponse egResponse = _bdBLL.ExamGrade_GetList();

            if (egResponse == null)
            {
                return;
            }

            List<ExamGrade> egList;

            if (egResponse.Success)
            {
                if (egResponse.Data == null || egResponse.Data.Count < 1)
                {
                    MessageBox.Show("未获取到任何年级信息，请确认已在考试下添加年级", "提示", MessageBoxButtons.OK);

                    return;
                }

                egList = egResponse.Data;
            }
            else
            {
                MessageBox.Show(string.Format("获取年级信息过程中出现一个错误{0}详细信息：{1}{2}", Environment.NewLine, Environment.NewLine, egResponse.Error == null ? "无" : egResponse.Error.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            panSelectGrade.Visible = true;

            InitSeniorHighSchoolPanel(egList);
            InitCompulsoryEducationPanel(egList);

            int buttomLocation = 0;

            foreach (Control c in panSelectGrade.Controls)
            {
                if ((c.Location.Y + c.Height) > buttomLocation)
                {
                    buttomLocation = c.Location.Y + c.Height;
                }
            }

            panSelectGrade.Size = new Size(panSelectGrade.Width, buttomLocation);
        }

        /// <summary>
        /// 科目区域鼠标移入事件
        /// </summary>
        protected void pan_MouseEnter(object sender, EventArgs e)
        {
            Control c = (sender as Control);

            if (c.Name.Contains("lbl"))
            {
                c.Parent.BackgroundImage = SubjectListFormRes.SubjectButton_BackImage_Hover;

                return;
            }

            Panel pan = (sender as Panel);

            pan.BackgroundImage = SubjectListFormRes.SubjectButton_BackImage_Hover;
        }

        /// <summary>
        /// 科目区域鼠标离开事件
        /// </summary>
        protected void pan_MouseLeave(object sender, EventArgs e)
        {
            Control c = (sender as Control);

            if (c.Name.Contains("lbl"))
            {
                c.Parent.BackgroundImage = SubjectListFormRes.SubjectButton_BackImage_Normal;

                return;
            }

            Panel pan = (sender as Panel);

            pan.BackgroundImage = SubjectListFormRes.SubjectButton_BackImage_Normal;
        }

        /// <summary>
        /// 科目按钮点击事件
        /// </summary>
        protected void pan_Click(object sender, EventArgs e)
        {
            ExamInfo eiModel = ((sender as Control).Tag as ExamInfo);
            ScanGlobalInfo.CurrentSubject = eiModel.SubjectID;
            this.opStateChange(eiModel, OperateStatus.SubjectOperate);
        }

        /// <summary>
        /// 添加按钮到科目行面板
        /// </summary>
        /// <param name="pan">科目行面板</param>
        /// <param name="eiModel">控件的数据属性</param>
        private void AddPicToSubjectPanel(Panel pan, ExamInfo eiModel)
        {
            Label lblButton = new Label();

            lblButton.AutoSize = true;
            lblButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            lblButton.BackColor = Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            lblButton.Text = eiModel.SubjectName.Trim();
            lblButton.Tag = eiModel;
            lblButton.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lblButton.Padding = new Padding(0);
            lblButton.Margin = new Padding(0);
            lblButton.Name = string.Format("lblButton{0}", pan.Controls.Count);
            lblButton.Size = new Size(100, 15);
            lblButton.MouseEnter += new EventHandler(pan_MouseEnter);
            lblButton.Click += new EventHandler(pan_Click);

            Panel panButton = new Panel();

            panButton.Padding = new Padding(0);
            panButton.Margin = new System.Windows.Forms.Padding(0);
            panButton.Size = new Size(153, 80);
            panButton.Tag = eiModel;
            panButton.Name = string.Format("panButton{0}", pan.Controls.Count);
            panButton.BackgroundImage = SubjectListFormRes.SubjectButton_BackImage_Normal;
            panButton.MouseLeave += new EventHandler(pan_MouseLeave);
            panButton.Click += new EventHandler(pan_Click);
            panButton.MouseEnter += new EventHandler(pan_MouseEnter);

            panButton.Controls.Add(lblButton);

            lblButton.Location = new Point((panButton.Width - lblButton.Width) / 2, (panButton.Height - lblButton.Height) / 2);

            pan.Controls.Add(panButton);

            if (pan.Controls.Count > 1)
            {
                int controlWidthSum = 0;

                foreach (Control c in pan.Controls)
                {
                    controlWidthSum += c.Width;
                }

                panButton.Location = new Point((pan.Controls.Count - 1) * 18 + controlWidthSum - panButton.Width, panButton.Location.Y);
                pan.Width = (pan.Controls.Count - 1) * 18 + controlWidthSum;
            }
            else
            {
                panButton.Location = new Point(0, 0);
                pan.Size = new Size(panButton.Width, panButton.Height);
            }
        }

        /// <summary>
        /// 初始化科目的行
        /// </summary>
        private void InitSubjectRow(List<ExamInfo> eiList)
        {
            panSubjcetRow1.Visible = true;

            if (eiList.Count > 5)
            {
                panSubjcetRow2.Visible = true;
            }

            int curGradeCode = ScanGlobalInfo.ExamGrade.GradeId;

            foreach (ExamInfo eiModel in eiList)
            {
                if (panSubjcetRow1.Controls.Count < 5)
                {
                    AddPicToSubjectPanel(panSubjcetRow1, eiModel);
                }
                else
                {
                    AddPicToSubjectPanel(panSubjcetRow2, eiModel);
                }
            }

            panSubjcetRow1.Location = new Point((panSelectSubject.Width - panSubjcetRow1.Width) / 2, lblSelectSubject.Location.Y + lblSelectSubject.Height + 30);

            if (eiList.Count > 5)
            {
                panSubjcetRow2.Location = new Point((panSelectSubject.Width - panSubjcetRow2.Width) / 2, panSubjcetRow1.Location.Y + panSubjcetRow1.Height + 18);
            }
        }

        /// <summary>
        /// 初始化科目面板
        /// </summary>
        private void InitSubjectPanel()
        {
            ExamInfoResponse eiResponse = _bdBLL.ExamInfo_GetList();
            List<ExamInfo> eiList;

            if (eiResponse.Success)
            {
                if (eiResponse.Data == null || eiResponse.Data.Count < 1)
                {
                    MessageBox.Show("未获取到任何科目信息，请确认已在考试下添加科目", "提示", MessageBoxButtons.OK);

                    return;
                }

                eiList = eiResponse.Data;
            }
            else
            {

                MessageBox.Show(string.Format("获取科目信息过程中出现一个错误{0}详细信息：{1}{2}", Environment.NewLine, Environment.NewLine, eiResponse.Error.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            panSelectSubject.Visible = true;

            InitSubjectRow(eiList);

            int buttomLocation = 0;

            foreach (Control c in panSelectSubject.Controls)
            {
                if ((c.Location.Y + c.Height) > buttomLocation)
                {
                    buttomLocation = c.Location.Y + c.Height;
                }
            }

            panSelectSubject.Location = new Point(panSelectSubject.Location.X, panSelectGrade.Location.Y + panSelectGrade.Height + 66);
            panSelectSubject.Size = new Size(panSelectSubject.Width, buttomLocation);
        }

        /// <summary>
        /// 初始化界面数据容器
        /// </summary>
        private void InitContainer()
        {
            panSelectGrade.Visible = false;
            panSeniorHighSchool.Visible = false;
            panSeniorHighSchool.Controls.Clear();
            panCompulsoryEducation.Visible = false;
            panCompulsoryEducation.Controls.Clear();
            panSelectSubject.Visible = false;
            panSubjcetRow1.Visible = false;
            panSubjcetRow1.Controls.Clear();
            panSubjcetRow2.Visible = false;
            panSubjcetRow2.Controls.Clear();
        }

        /// <summary>
        /// 考试列表选择项改变事件
        /// </summary>
        private void cbxExamGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScanGlobalInfo.ExamGroup = ((ExamGroup)cbxExamGroup.SelectedItem);

            lblComboBoxImage.Text = ScanGlobalInfo.ExamGroup.ExamName;

            for (int i = 0; i < 150; i++)  //保持lbl长度以保证覆盖下拉列表
            {
                if (lblComboBoxImage.Size.Width < 350)
                {
                    lblComboBoxImage.Text += " ";
                }
            }

            InitContainer();
            InitGradePanel();
        }

        /// <summary>
        /// 选择年级区域可见属性改变事件
        /// </summary>
        private void panSelectGrade_VisibleChanged(object sender, EventArgs e)
        {
            if (panSelectGrade.Visible)
            {
                lblSelectGrade.Location = new Point((panSelectGrade.Width - lblSelectGrade.Width) / 2, 0);
            }
        }

        /// <summary>
        /// 选择考试下拉列表项尺寸定义事件
        /// </summary>
        private void cbxExamGroup_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 40;
        }
    }
}
