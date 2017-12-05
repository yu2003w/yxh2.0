using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.ScanForm
{
    /// <summary>
    /// 漏扫检查
    /// </summary>
    public partial class FormLeakCheck : Form
    {
        /// <summary>
        /// 漏扫检查数据绑定类
        /// </summary>
        private class LeakChkdataBind
        {
            /// <summary>
            /// 准考证号
            /// </summary>
            public string zkzh { get; set; }

            /// <summary>
            /// 学生姓名
            /// </summary>
            public string studentname { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string userid { get; set; }

            /// <summary>
            /// 结果
            /// </summary>
            public string result { get; set; }
        }

        /// <summary>
        /// 业务请求类实例
        /// </summary>
        private BaseDisposeBLL _bdBll = new BaseDisposeBLL();

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="IsEndExam">是否已结束考试</param>
        public FormLeakCheck(bool IsEndExam)
        {
            InitializeComponent();

            int arg_1B_0 = ScanGlobalInfo.ExamInfo.ScanRecordList.Count,
                count = ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count;
            List<StudentExamInfo> studentExamInfoList = ScanGlobalInfo.ExamInfo.StudentExamInfoList;
            SynchronizedCollection<ScanRecord> scanRecordList = ScanGlobalInfo.ExamInfo.ScanRecordList;
            List<string> list = new List<string>();

            foreach (ScanRecord current in scanRecordList)
            {
                if (!string.IsNullOrEmpty(current.Zkzh))
                {
                    list.Add(current.Zkzh.ToString());
                }
            }

            List<FormLeakCheck.LeakChkdataBind> list2 = new List<FormLeakCheck.LeakChkdataBind>();

            foreach (StudentExamInfo current2 in studentExamInfoList)
            {
                if (!list.Contains(current2.ExamCode.ToString()))
                {
                    list2.Add(new FormLeakCheck.LeakChkdataBind
                    {
                        zkzh = current2.ExamCode.ToString(),
                        studentname = current2.StuName,

                        userid = current2.ID.ToString()
                    });
                }
            }

            if (IsEndExam)
            {
                using (List<FormLeakCheck.LeakChkdataBind>.Enumerator enumerator3 = list2.GetEnumerator())
                {
                    while (enumerator3.MoveNext())
                    {
                        FormLeakCheck.LeakChkdataBind current3 = enumerator3.Current;

                        if (string.IsNullOrEmpty(current3.result))
                        {
                            current3.result = "缺考";
                        }
                    }

                    goto IL_1D7;
                }
            }

            this.ColNotScanReason.Visible = false;
            this.pnlBottom.Height = 0;

        IL_1D7:

            list2 = (from i in list2
                     orderby i.zkzh
                     select i).ToList<FormLeakCheck.LeakChkdataBind>();

            this.grvSource.DataSource = list2;
            this.label1.Text = string.Format("一共:{0} 已扫:{1},未扫:{2}", count, count - list2.Count<FormLeakCheck.LeakChkdataBind>(), list2.Count<FormLeakCheck.LeakChkdataBind>());
        }

        /// <summary>
        /// 设置试卷扫描状态
        /// </summary>
        /// <param name="userID">学生ID</param>
        /// <param name="paperStatus">扫描状态</param>
        private void SetPaperStatus(int userID, int paperStatus)
        {
            foreach (StudentExamInfo seiModel in ScanGlobalInfo.ExamInfo.StudentExamInfoList)
            {
                if (seiModel.ID == userID)
                {
                    seiModel.PaperStatus = paperStatus;
                }
            }
        }

        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存设置?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                List<string> list = new List<string>();

                try
                {
                    for (int i = 0; i < this.grvSource.Rows.Count; i++)
                    {
                        object value = this.grvSource.Rows[i].Cells["ColNotScanReason"].Value;
                        int userid = int.Parse(((List<FormLeakCheck.LeakChkdataBind>)this.grvSource.DataSource)[i].userid);

                        if (value == null || string.IsNullOrEmpty(value.ToString()))
                        {
                            SetPaperStatus(userid, 0);
                        }
                        else if (value.ToString() == "人工阅卷")
                        {
                            SetPaperStatus(userid, 3);
                        }
                        else if (value.ToString() == "缺考")
                        {
                            SetPaperStatus(userid, 1);
                        }
                    }

                    base.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("设置试卷状态出现错误，请稍后重试", "错误");
                    _bdBll.System_SaveErrorLog(ex, "设置考卷状态出现错误");
                }
            }
        }
    }
}
