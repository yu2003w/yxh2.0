using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using YXH.Common;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.ScanForm
{
    /// <summary>
    /// 搜索学生信息
    /// </summary>
    public partial class FormSearchStuInfo : Form
    {
        /// <summary>
        /// 遗漏数量
        /// </summary>
        private int _leakCount;
        /// <summary>
        /// 选中批次ID
        /// </summary>
        private int _selectedBatchId = -1;
        /// <summary>
        /// 选中批次索引
        /// </summary>
        private int _selectedBatchIndex = -1;
        /// <summary>
        /// 选中批次ID
        /// </summary>
        public int SelectedBatchId
        {
            get
            {
                return this._selectedBatchId;
            }
            set
            {
                this._selectedBatchId = value;
            }
        }
        /// <summary>
        /// 选中批次索引
        /// </summary>
        public int SelectedBatchIndex
        {
            get
            {
                return this._selectedBatchIndex;
            }
            set
            {
                this._selectedBatchIndex = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public FormSearchStuInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FormSearchStuInfo_Load(object sender, EventArgs e)
        {
            this.IntiaScanRecordGrid();
        }

        /// <summary>
        /// 改变学生编码字符串到文本
        /// </summary>
        /// <param name="statusText">学生编码字符串</param>
        /// <returns>目标文本</returns>
        private string ChangeStatusStringCodeToText(string statusText)
        {
            statusText = statusText.Replace("0", "已上传").Replace("1", "正常").Replace("2", "考号不可识别").Replace("3", "重号").Replace("4", "错号").Replace("5", "页不可定位").Replace("6", "缺页").Replace("7", "客观题存疑").Replace("8", "后台处理客观题存疑").Replace("9", "重叠卷").Replace("10", "原图加载失败");

            return statusText;
        }

        /// <summary>
        /// 初始化扫描结果列表
        /// </summary>
        /// <returns>执行结果</returns>
        public bool IntiaScanRecordGrid()
        {
            try
            {
                List<StudentExamInfo> studentExamInfoList = ScanGlobalInfo.ExamInfo.StudentExamInfoList;
                SynchronizedCollection<ScanRecord> scanRecordList = ScanGlobalInfo.ExamInfo.ScanRecordList;

                this.trlUser.ClearNodes();
                this.trlUser.BeginUpdate();

                for (int i = 0; i < scanRecordList.Count; i++)
                {
                    ScanRecord record = scanRecordList[i];

                    record.VolumnStatus.Split(new char[]
					{
						','
					}, StringSplitOptions.RemoveEmptyEntries);

                    string text = "空",
                        text2 = "000";
                    StudentExamInfo studentExamInfo = null;

                    if (!(record.EsId>0))
                    {
                        studentExamInfo = studentExamInfoList.Find((StudentExamInfo p) => p.ID == record.EsId);
                    }
                    else if (!string.IsNullOrEmpty(record.Zkzh))
                    {
                        studentExamInfo = studentExamInfoList.Find((StudentExamInfo p) => p.ExamCode.ToString() == record.Zkzh);
                    }
                    if (studentExamInfo != null)
                    {
                        text = studentExamInfo.StuName;
                        text2 = studentExamInfo.StudentNamePinYin;
                    }

                    this.trlUser.AppendNode(new object[]
					{
						text,
						record.Zkzh,
						record.BatchID,
						record.BatchIndex,
						record.EsId,
						this.ChangeStatusStringCodeToText(record.VolumnStatus),
						text2,
						record.VolumnStatus
					}, null);
                }

                this.trlUser.EndUpdate();

                this.lblSearchTotal.Text = string.Format("合计{0}份", this.trlUser.Nodes.Count);
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);

                return false;
            }

            return true;
        }

        /// <summary>
        /// 用户树形列表双击事件
        /// </summary>
        private void trlUser_DoubleClick(object sender, EventArgs e)
        {
            if (this.trlUser.FocusedNode != null)
            {
                this.SelectedBatchId = (int)this.trlUser.FocusedNode.GetValue(this.trcBatchId.AbsoluteIndex);
                this.SelectedBatchIndex = (int)this.trlUser.FocusedNode.GetValue(this.trcBatchIndex.AbsoluteIndex);
                base.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 姓名文本框文本改变事件
        /// </summary>
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            this._leakCount = 0;

            TreeListNode treeListNode = null;

            this.trlUser.BeginUpdate();

            if (!string.IsNullOrEmpty(this.txtSearchName.Text))
            {
                IEnumerator enumerator = this.trlUser.Nodes.GetEnumerator();

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

                goto IL_112;

            }

            foreach (TreeListNode treeListNode3 in this.trlUser.Nodes)
            {
                this._leakCount++;

                treeListNode3.Visible = true;
            }

        IL_112:

            this.trlUser.EndUpdate();
            this.trlUser.SetFocusedNode(treeListNode);

            this.lblSearchTotal.Text = string.Format("合计{0}份", this._leakCount);
        }

        /// <summary>
        /// 学号文本框文本改变事件
        /// </summary>
        private void txtSearchSchoolnumber_TextChanged(object sender, EventArgs e)
        {
            this._leakCount = 0;

            TreeListNode treeListNode = null;

            this.trlUser.BeginUpdate();

            if (!string.IsNullOrEmpty(this.txtSearchSchoolnumber.Text))
            {
                IEnumerator enumerator = this.trlUser.Nodes.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    TreeListNode treeListNode2 = (TreeListNode)enumerator.Current;
                    string text = (string)treeListNode2.GetValue(this.trcSchoolNumber.AbsoluteIndex);

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

                goto IL_112;
            }

            foreach (TreeListNode treeListNode3 in this.trlUser.Nodes)
            {
                this._leakCount++;

                treeListNode3.Visible = true;
            }

        IL_112:

            this.trlUser.EndUpdate();
            this.trlUser.SetFocusedNode(treeListNode);

            this.lblSearchTotal.Text = string.Format("合计{0}份", this._leakCount);
        }

        /// <summary>
        /// 拼音文本框文本改变事件
        /// </summary>
        private void txtSearchPingyin_TextChanged(object sender, EventArgs e)
        {
            this._leakCount = 0;

            TreeListNode treeListNode = null;

            this.trlUser.BeginUpdate();

            if (!string.IsNullOrEmpty(this.txtSearchPingyin.Text))
            {
                IEnumerator enumerator = this.trlUser.Nodes.GetEnumerator();

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

                goto IL_148;
            }

            foreach (TreeListNode treeListNode3 in this.trlUser.Nodes)
            {
                this._leakCount++;

                treeListNode3.Visible = true;
            }

        IL_148:

            this.trlUser.EndUpdate();
            this.trlUser.SetFocusedNode(treeListNode);

            this.lblSearchTotal.Text = string.Format("合计{0}份", this._leakCount);
        }

        /// <summary>
        /// 搜索相关文本框按键按下事件
        /// </summary>
        private void txtSearchEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.trlUser.Focus();
                }

                return;
            }
            if (((TextBox)sender).Text == string.Empty)
            {
                MessageBox.Show("请输入搜索关键字", "提示");

                return;
            }
            if (this._leakCount > 1 && MessageBox.Show("列表存在多个考生，是否匹配第一项", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
            {
                return;
            }

            this.trlUser_DoubleClick(null, null);

            ((TextBox)sender).Focus();
        }
    }
}
