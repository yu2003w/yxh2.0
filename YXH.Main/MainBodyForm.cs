using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YXH.Enum;
using YXH.ScanBLL;

namespace YXH.Main
{
    public partial class MainBodyForm : Form
    {
        /// <summary>
        /// 状态改变处理事件
        /// </summary>
        public delegate void StateChangeHandle(object obj, OperateStatus nextOpStatus);
        /// <summary>
        /// 操作状态
        /// </summary>
        private OperateStatus _curOperateStatus = OperateStatus.SubjectList;
        /// <summary>
        /// 状态改变事件声明
        /// </summary>
        public event MainBodyForm.StateChangeHandle opStateChange;
        /// <summary>
        /// 父窗体
        /// </summary>
        private MainScanForm _parentForm;

        /// <summary>
        /// 操作状态
        /// </summary>
        public OperateStatus CurOperateStatus
        {
            get
            {
                return this._curOperateStatus;
            }
            set
            {
                this._curOperateStatus = value;
            }
        }
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public MainBodyForm(MainScanForm parentForm)
        {
            InitializeComponent();

            _parentForm = parentForm;
        }

        /// <summary>
        /// 状态改变触发器事件
        /// </summary>
        public void StatusChangeTrigger(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            OperateStatus curStatus = (OperateStatus)control.Tag;
            _parentForm._tabStatus = curStatus;

            this.ManangerStatus(curStatus, false);
        }

        /// <summary>
        /// 回收所有退出的窗体
        /// </summary>
        private void DisposeAllExitForm()
        {
            if (this.panel_body.Controls.Count > 0)
            {
                foreach (Control control in this.panel_body.Controls)
                {
                    this.panel_body.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }

        /// <summary>
        /// 状态管理
        /// </summary>
        /// <param name="exam">考试信息</param>
        /// <param name="curOpStatus">当前状态</param>
        private void StateManagement(object exam, OperateStatus curOpStatus)
        {
            if (this.opStateChange != null)
            {
                if (curOpStatus == OperateStatus.SubjectOperate)
                {
                    this.opStateChange(exam, curOpStatus);
                    return;
                }
                if (curOpStatus == OperateStatus.ReUploadMaterials)
                {
                    this.opStateChange(exam, curOpStatus);
                }
            }
        }

        /// <summary>
        /// 添加窗体到Body容器
        /// </summary>
        /// <param name="targetCtrl">目标控件</param>
        /// <param name="target">父容器</param>
        private void addFormToPanelBody(Control targetCtrl, Form target)
        {
            target.TopLevel = false;
            target.FormBorderStyle = FormBorderStyle.None;
            target.Dock = DockStyle.Fill;
            targetCtrl.Controls.Clear();
            targetCtrl.Controls.Add(target);
            target.Show();
        }

        /// <summary>
        /// 管理状态
        /// </summary>
        /// <param name="curStatus">当前状态</param>
        /// <param name="isForceRefresh">是否进行焦点刷新</param>
        private void ManangerStatus(OperateStatus curStatus, bool isForceRefresh = false)
        {
            if (this._curOperateStatus != curStatus || isForceRefresh)
            {
                this.DisposeAllExitForm();
                if (curStatus != OperateStatus.SubjectList)
                {
                    switch (curStatus)
                    {
                        case OperateStatus.HistoryExamRecord:
                            {
                                HistoryExamRecordForm historyExamRecordForm = new HistoryExamRecordForm();
                                historyExamRecordForm.opStateChange += new HistoryExamRecordForm.StateChangeHandle(this.StateManagement);
                                this.addFormToPanelBody(this.panel_body, historyExamRecordForm);

                                break;
                            }
                        case OperateStatus.SystemSetting:
                            {
                                SystemSettingForm target = new SystemSettingForm();
                                this.addFormToPanelBody(this.panel_body, target);

                                break;
                            }
                    }
                }
                else
                {
                    this.ClearExitExamInfo();
                    ScanGlobalInfo.ExamType = ExamType.Normal;
                    SubjectListForm subjectListForm = new SubjectListForm();
                    subjectListForm.opStateChange += new SubjectListForm.StateChangeHandle(this.StateManagement);
                    this.addFormToPanelBody(this.panel_body, subjectListForm);

                }
            }
            this._curOperateStatus = curStatus;
        }

        /// <summary>
        /// 清理已退出的考试信息
        /// </summary>
        private void ClearExitExamInfo()
        {
            if (ScanGlobalInfo.ExamInfo != null && ScanGlobalInfo.ExamInfo.ScanRecordList != null)
            {
                ScanGlobalInfo.ExamInfo.ScanRecordList.Clear();
                ScanGlobalInfo.ExamInfo.StudentExamInfoList.Clear();
                ScanGlobalInfo.ExamInfo = null;
            }
        }

        /// <summary>
        /// 窗体解释事件
        /// </summary>
        private void MainBodyForm_Shown(object sender, EventArgs e)
        {
            this.ManangerStatus(this.CurOperateStatus, true);
        }
    }
}
