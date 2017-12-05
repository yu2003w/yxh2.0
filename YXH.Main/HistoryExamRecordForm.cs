using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.Form;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;
using YXH.ScanForm;

namespace YXH.Main
{
    /// <summary>
    /// 历史试卷记录
    /// </summary>
    public partial class HistoryExamRecordForm : Form
    {
        /// <summary>
        /// 考试信息绑定
        /// </summary>
        private class ExamInfoBind
        {
            /// <summary>
            /// 考试ID
            /// </summary>
            public long ExamId { get; set; }
            /// <summary>
            /// 考试名称
            /// </summary>
            public HistoryExamRecordForm.ExamShow ExamName { get; set; }
            /// <summary>
            /// 考试标题
            /// </summary>
            public string SubjectName { get; set; }
            /// <summary>
            /// 考试类型
            /// </summary>
            public string ExamType { get; set; }
            /// <summary>
            /// 扫描完成时间
            /// </summary>
            public string ScanFinishTime { get; set; }
            /// <summary>
            /// 上传材料
            /// </summary>
            public string UploadMaterials { get; set; }
            /// <summary>
            /// 扫描统计
            /// </summary>
            public string ScanStatis { get; set; }

            /// <summary>
            /// 考试信息绑定
            /// </summary>
            public ExamInfoBind()
            {
                this.ExamName = new HistoryExamRecordForm.ExamShow();
            }
        }

        /// <summary>
        /// 考试信息显示
        /// </summary>
        private class ExamShow
        {
            /// <summary>
            /// 考试信息
            /// </summary>
            public ExamInfo curExam { get; set; }

            /// <summary>
            /// 将类型转换为String
            /// </summary>
            /// <returns>转换结果</returns>
            public override string ToString()
            {
                base.ToString();

                return this.curExam.ExamName;
            }
        }

        /// <summary>
        /// 状态检查事件头
        /// </summary>
        /// <param name="obj">调用对象</param>
        /// <param name="nextOpStatus">下一个状态</param>
        public delegate void StateChangeHandle(object obj, OperateStatus nextOpStatus);
        /// <summary>
        /// 历史考试记录状态改变事件头
        /// </summary>
        public event HistoryExamRecordForm.StateChangeHandle opStateChange;
        /// <summary>
        /// 当前考试信息列表
        /// </summary>
        private List<ExamInfo> _curExamInfoList;

        /// <summary>
        /// 当前考试信息列表
        /// </summary>
        public List<ExamInfo> CurExamInfoList
        {
            get
            {
                if (this._curExamInfoList == null)
                {
                    this._curExamInfoList = new List<ExamInfo>();
                }

                return this._curExamInfoList;
            }
            set
            {
                this.CurExamInfoList.Clear();
                this.CurExamInfoList.AddRange(value);
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public HistoryExamRecordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 更新相关静态信息
        /// </summary>
        public void UpdateStaticsRelatedInfo()
        {
            FormProgress frmProgress = new FormProgress();
            Thread trd = new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(10, "正在获取学生列表...");
                        }));

                        StudentExamInfoResponse seiResponse = new BaseDisposeBLL().StudentExamInfo_GetList();
                        IList<StudentExamInfo> seiList = (seiResponse.Success) ? seiResponse.Data : null;

                        ScanGlobalInfo.ExamInfo.StudentExamInfoList.Clear();
                        ScanGlobalInfo.ExamInfo.StudentExamInfoList.AddRange(seiList);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(40, "正在获取扫描记录信息...");
                        }));
                        Invoke(new MethodInvoker(delegate
                            {
                                frmProgress.SetProgress(100, "完成");
                                frmProgress.Close();
                            }));

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (ThreadAbortException)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.Close();
                            MessageBox.Show("保存终止", "提示");

                            this.Cursor = Cursors.Arrow;
                        }));

                        this.DialogResult = DialogResult.Cancel;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteFatalLog(ex.Message, ex);

                        this.Invoke(new MethodInvoker(delegate
                        {
                            this.Cursor = Cursors.Arrow;

                            frmProgress.Close();
                            MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }));

                        this.DialogResult = DialogResult.Cancel;
                    }
                }));

            FormProgress expr_51 = frmProgress;

            expr_51.Cancelhandle = (EventHandler)Delegate.Combine(expr_51.Cancelhandle, new EventHandler(delegate(object obj, EventArgs args)
            {
                trd.Abort();
            }));

            trd.Start();
            frmProgress.ShowDialog();

            if (base.DialogResult != DialogResult.Cancel)
            {
                new StatisticForm
                {
                    Text = string.Format("扫描统计 考试名称：{0}", ScanGlobalInfo.ExamInfo.ExamName)
                }.ShowDialog();
            }
        }

        /// <summary>
        /// 历史考试列表单元格点击事件
        /// </summary>
        private void dg_HistoryExam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HistoryExamRecordForm.ExamShow examShow = (HistoryExamRecordForm.ExamShow)this.dg_HistoryExam.Rows[e.RowIndex].Cells["examname"].Value;

            if (e.ColumnIndex == this.dg_HistoryExam.Columns["uploadmaterials"].Index)
            {
                ScanGlobalInfo.ExamInfo = examShow.curExam;
                ScanGlobalInfo.ExamType = examShow.curExam.ExamType;

                if (this.opStateChange != null)
                {
                    this.opStateChange(new object(), OperateStatus.ReUploadMaterials);

                    return;
                }
            }
            else if (e.ColumnIndex == this.dg_HistoryExam.Columns["scanstatis"].Index)
            {
                ScanGlobalInfo.ExamInfo = examShow.curExam;
                ScanGlobalInfo.ExamType = examShow.curExam.ExamType;

                this.UpdateStaticsRelatedInfo();
            }
        }

        /// <summary>
        /// 更新标签状态
        /// </summary>
        /// <param name="num">考试数量</param>
        private void UpdateLblStatis(int num)
        {
            this.lbl_statis.Text = string.Format("已完成{0}场考试", num);
        }

        /// <summary>
        /// 更新DataGrid数据
        /// </summary>
        /// <param name="examid">考试ID</param>
        private void UpdateDataGrid(string examid = "")
        {
            this.dg_HistoryExam.Visible = false;

            FormProgress frmProgress = new FormProgress();
            List<HistoryExamRecordForm.ExamInfoBind> dataResult = new List<HistoryExamRecordForm.ExamInfoBind>();
            Thread trd = new Thread(new ThreadStart(delegate
            {
                try
                {
                    frmProgress.SetProgress(20, "正在获取已结束扫描的考试记录...");

                    List<ExamInfo> list = new List<ExamInfo>();

                    if (examid == "" || this.CurExamInfoList.Count == 0)
                    {
                        list = new BaseDisposeBLL().GetSchoolExamList(ScanGlobalInfo.loginUser.data.orgid, true);
                        this.CurExamInfoList = list;
                    }
                    else
                    {
                        list.Clear();
                        list.AddRange(this.CurExamInfoList);
                    }

                    frmProgress.SetProgress(60, "正在更新列表...");

                    if (list != null)
                    {
                        if (examid != "")
                        {
                            long id = long.Parse(examid);
                            ExamInfo examInfo = list.Find((ExamInfo p) => p.ID == id);

                            if (examInfo == null)
                            {
                                list.Clear();
                            }
                            else
                            {
                                list.Clear();
                                list.Add(examInfo);
                            }
                        }
                        foreach (ExamInfo current in list)
                        {
                            HistoryExamRecordForm.ExamInfoBind examInfoBind = new HistoryExamRecordForm.ExamInfoBind();

                            examInfoBind.ExamId = current.ID;
                            examInfoBind.ExamName.curExam = current;
                            examInfoBind.SubjectName = current.GradeName + current.SubjectName + current.SubjectType;

                            switch (current.ExamType)
                            {
                                case ExamType.MidTerm:
                                    examInfoBind.ExamType = "期中";

                                    break;
                                case ExamType.Examination:
                                    examInfoBind.ExamType = "期末";

                                    break;
                                case ExamType.MonthExam:
                                    examInfoBind.ExamType = "月考";

                                    break;
                                case ExamType.Contest:
                                    examInfoBind.ExamType = "竞赛";

                                    break;
                                case ExamType.Normal:
                                    examInfoBind.ExamType = "普通";

                                    break;
                            }

                            examInfoBind.ScanFinishTime = current.ScanFinishTime.ToString();
                            examInfoBind.UploadMaterials = "上传资料";
                            examInfoBind.ScanStatis = "查看";

                            dataResult.Add(examInfoBind);
                        }
                    }

                    this.Invoke(new MethodInvoker(delegate
                    {
                        if (dataResult.Count == 0)
                        {
                            this.panel_BodyBack.Visible = true;
                            this.lbl_ShowReuslt.Text = "已结束扫描的考试记录为空！";
                        }

                        frmProgress.Close();
                    }));
                }
                catch (ThreadAbortException)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.panel_BodyBack.Visible = true;
                        this.lbl_ShowReuslt.Text = "列表更新被取消，请稍后再试！";

                        frmProgress.Close();
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        frmProgress.Close();

                        this.panel_BodyBack.Visible = true;
                        this.lbl_ShowReuslt.Text = "列表更新失败，请稍后再试！";

                        MessageBox.Show(ex.Message, "更新失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }));
                }
            }));

            trd.Start();
            frmProgress.ShowDialog();
            this.UpdateLblStatis(dataResult.Count);

            if (dataResult.Count > 0)
            {
                this.dg_HistoryExam.BringToFront();

                this.dg_HistoryExam.Visible = true;
                this.dg_HistoryExam.DataSource = (from p in dataResult
                                                  orderby p.ExamId descending
                                                  select p).ToList<HistoryExamRecordForm.ExamInfoBind>();

                return;
            }

            this.dg_HistoryExam.Visible = false;
            this.panel_BodyBack.Visible = true;

            this.panel_BodyBack.BringToFront();
        }

        /// <summary>
        /// 搜索按钮点击事件
        /// </summary>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            string text = this.tb_CheckExamId.Text.ToString().Trim();

            try
            {
                if (text != "")
                {
                    this.UpdateDataGrid(long.Parse(text).ToString());
                }
                else
                {
                    this.UpdateDataGrid("");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的考试ID！");
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void HistoryExamRecordForm_Load(object sender, EventArgs e)
        {
            this.dg_HistoryExam.Visible = false;
            this.panel_BodyBack.Visible = false;

            this.UpdateLblStatis(0);
        }

        /// <summary>
        /// 窗体展示事件
        /// </summary>
        private void HistoryExamRecordForm_Shown(object sender, EventArgs e)
        {
            this.UpdateDataGrid("");
        }
    }
}
