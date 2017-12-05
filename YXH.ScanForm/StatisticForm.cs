using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using YXH.Common;
using YXH.Common.Form;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.ScanForm
{
    /// <summary>
    /// 静态处理窗体
    /// </summary>
    public partial class StatisticForm : Form
    {        
        /// <summary>
        /// 构造方法
        /// </summary>
        public StatisticForm()
        {
            InitializeComponent();

            this.BindStatisticInfo();
        }

        /// <summary>
        /// 绑定静态信息
        /// </summary>
        public void BindStatisticInfo()
        {
            this.lblStudentCount.Text = ScanGlobalInfo.ExamInfo.StudentExamInfoList.Count.ToString();
            this.lblScannedStudentCount.Text = ScanGlobalInfo.ExamInfo.ScanRecordList.Count.ToString();
            List<StudentInfo> dataToExport = StatisticsBLL.GenerateDataFromScanRecord(ScanGlobalInfo.ExamInfo.ScanRecordList, StatisDataMode.All);
            this.lblErrorExamPaperCount.Text = StatisticsBLL.FilterDataByMode(dataToExport, StatisDataMode.Abnormal).Count.ToString();
            this.lblZkzhErrorNum.Text = StatisticsBLL.FilterDataByMode(dataToExport, StatisDataMode.ZkzhNotMatch).Count.ToString();
            this.lblOmrErrorManualSaveNum.Text = StatisticsBLL.FilterDataByMode(dataToExport, StatisDataMode.OmrManualSave).Count.ToString();
        }

        /// <summary>
        /// 导出文件到Excel
        /// </summary>
        /// <typeparam name="T">导出对象</typeparam>
        /// <param name="curStaticsData">导出对象的静态实例</param>
        private void ExportFileToExcel<T>(StaticsData<T> curStaticsData)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出" + curStaticsData.SheetName;
            saveFileDialog.FileName = curStaticsData.FileName;
            saveFileDialog.InitialDirectory = PathHelper.LocalExamDataDir;

            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
            {
                FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);

                if (curStaticsData.ExportToExcel(fileInfo.FullName))
                {
                    Process.Start(fileInfo.Directory.FullName);
                }
            }
        }

        /// <summary>
        /// 显示DataView窗体
        /// </summary>
        /// <typeparam name="T">显示对象</typeparam>
        /// <param name="curStaticsData">当前静态对象</param>
        private void ShowDataViewForm<T>(StaticsData<T> curStaticsData)
        {
            DataGridViewShowForm dataGridViewShowForm = new DataGridViewShowForm();

            dataGridViewShowForm.SetDataSource(curStaticsData.DataSource);
            dataGridViewShowForm.SetColumnTextAndVisible(curStaticsData.ColumnInfo);
            dataGridViewShowForm.Show_Title = curStaticsData.SheetName;

            DataGridViewShowForm expr_4E = dataGridViewShowForm;

            expr_4E.Exportedhandle = (EventHandler)Delegate.Combine(expr_4E.Exportedhandle, new EventHandler(delegate(object obj, EventArgs args)
            {
                this.ExportFileToExcel<T>(curStaticsData);
            }));

            dataGridViewShowForm.ShowDialog();
        }

        /// <summary>
        /// 客观题异常已处理后查看按钮点击事件
        /// </summary>
        private void btn_CheckOmrManualSave_Click(object sender, EventArgs e)
        {
            this.btn_CheckOmrManualSave.Enabled = false;

            StaticsData<StudentInfo> curStaticsData = StatisticsBLL.ExportPaperInfo(StatisDataMode.OmrManualSave);

            this.ShowDataViewForm<StudentInfo>(curStaticsData);

            this.btn_CheckOmrManualSave.Enabled = true;
        }

        /// <summary>
        /// 考号异常已处理后查看按钮点击事件
        /// </summary>
        private void btn_CheckZkzhError_Click(object sender, EventArgs e)
        {
            this.btn_CheckZkzhError.Enabled = false;

            StaticsData<StudentInfo> curStaticsData = StatisticsBLL.ExportPaperInfo(StatisDataMode.ZkzhNotMatch);

            this.ShowDataViewForm<StudentInfo>(curStaticsData);

            this.btn_CheckZkzhError.Enabled = true;
        }

        /// <summary>
        /// 已扫份数后查看按钮点击事件
        /// </summary>
        private void btn_ScanRecord_Click(object sender, EventArgs e)
        {
            this.btnExamPaperImage.Enabled = false;

            StaticsData<StudentInfo> curStaticsData = StatisticsBLL.ExportPaperInfo(StatisDataMode.All);

            this.ShowDataViewForm<StudentInfo>(curStaticsData);

            this.btnExamPaperImage.Enabled = true;
        }

        /// <summary>
        /// 待处理异常卷后查看按钮点击事件
        /// </summary>
        private void btnErrorPaper_Click(object sender, EventArgs e)
        {
            this.btnErrorPaper.Enabled = false;

            StaticsData<StudentInfo> curStaticsData = StatisticsBLL.ExportPaperInfo(StatisDataMode.Abnormal);

            this.ShowDataViewForm<StudentInfo>(curStaticsData);

            this.btnErrorPaper.Enabled = true;
        }

        /// <summary>
        /// 缺考人数后查看按钮点击事件
        /// </summary>
        private void btnAbsentStudent_Click(object sender, EventArgs e)
        {
            this.btnAbsentStudent.Enabled = false;
            this.btnAbsentStudent.Enabled = true;
        }

        /// <summary>
        /// 报名人数后查看按钮点击事件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;

            StaticsData<StudentInfo> curStaticsData = StatisticsBLL.ExportStudent();

            this.ShowDataViewForm<StudentInfo>(curStaticsData);

            this.button1.Enabled = true;
        }

        /// <summary>
        /// 图片保存目录按钮点击事件
        /// </summary>
        private void btnExamPaperImage_Click(object sender, EventArgs e)
        {
            Process.Start(PathHelper.LocalVolumneImgDir);
        }

        /// <summary>
        /// 查看日志按钮点击事件
        /// </summary>
        private void link_CheckLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string text = Path.Combine(Application.StartupPath, "Logs\\");

            if (Directory.Exists(text))
            {
                Process.Start(text);
            }
        }

        /// <summary>
        /// 扫描记录保存目录按钮点击事件
        /// </summary>
        private void btn_CheckSrFolder_Click(object sender, EventArgs e)
        {
            Process.Start(PathHelper.LocalExamDataDir);
        }

        /// <summary>
        /// 获取导出数据列表
        /// </summary>
        /// <returns>导出数据列表</returns>
        private List<StaticsData<StudentInfo>> GetExportDataList()
        {
            List<StaticsData<StudentInfo>> list = new List<StaticsData<StudentInfo>>();

            if (this.ckbEnrollment.Checked)
            {
                StaticsData<StudentInfo> item = StatisticsBLL.ExportStudent();

                list.Add(item);
            }
            if (this.ckbScanRecord.Checked)
            {
                StaticsData<StudentInfo> item3 = StatisticsBLL.ExportPaperInfo(StatisDataMode.All);

                list.Add(item3);
            }
            if (this.ckbIncorrect.Checked)
            {
                StaticsData<StudentInfo> item4 = StatisticsBLL.ExportPaperInfo(StatisDataMode.Abnormal);

                list.Add(item4);
            }
            if (this.cb_zkzhErrorNum.Checked)
            {
                StaticsData<StudentInfo> item5 = StatisticsBLL.ExportPaperInfo(StatisDataMode.ZkzhNotMatch);

                list.Add(item5);
            }
            if (this.cb_OmrErrorSave.Checked)
            {
                StaticsData<StudentInfo> item6 = StatisticsBLL.ExportPaperInfo(StatisDataMode.OmrManualSave);

                list.Add(item6);
            }

            return list;
        }

        /// <summary>
        /// 批量导出按钮点击事件
        /// </summary>
        private void btn_SelectedToExport_Click(object sender, EventArgs e)
        {
            this.btn_SelectedToExport.Enabled = false;

            IList<string> ckbList = new List<string>();
            int num = 0;

            foreach (Control control in this.panel1.Controls)
            {
                if (control is CheckBox && ((CheckBox)control).Checked)
                {
                    num++;
                }
            }

            if (num == 0)
            {
                MessageBox.Show("请至少勾选一个要导出的结果");

                this.btn_SelectedToExport.Enabled = true;

                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "批量导出";
            saveFileDialog.FileName = ScanGlobalInfo.ExamInfo.ExamName + "扫描统计数据（合并批量导出）";
            saveFileDialog.InitialDirectory = PathHelper.LocalExamDataDir;

            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
            {
                FileInfo curInfo = new FileInfo(saveFileDialog.FileName);
                FormProgress frmProgress = new FormProgress();

                frmProgress.ProgressMaxValue = num + 1;

                Thread trd = new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(0, "正在获取数据...");
                        }));

                        List<StaticsData<StudentInfo>> exportDataList = this.GetExportDataList();

                        int cnt = 0,
                            total = exportDataList.Count;

                        using (List<StaticsData<StudentInfo>>.Enumerator enumerator2 = exportDataList.GetEnumerator())
                        {
                            while (enumerator2.MoveNext())
                            {
                                StaticsData<StudentInfo> data = enumerator2.Current;

                                this.Invoke(new MethodInvoker(delegate
                                {
                                    frmProgress.SetProgress(cnt, string.Format("正在导出{0}...{1}/{2}", data.SheetName, cnt, total));
                                    Application.DoEvents();
                                }));

                                string text = Path.Combine(curInfo.Directory.FullName, data.FileName + ".xls");

                                if (data.ExportToExcel(text))
                                {
                                    ckbList.Add(text);
                                }

                                cnt++;
                            }
                        }

                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.SetProgress(total, string.Format("正在合并Excel表", new object[0]));
                            Application.DoEvents();
                        }));
                        FileHelper.CombineExcels(ckbList, curInfo.FullName);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.Close();
                            frmProgress.SetProgress(total, "批量导出完成");
                        }));

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (ThreadAbortException)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.Close();
                            MessageBox.Show("导出终止", "提示");

                            this.Cursor = Cursors.Arrow;
                        }));

                        this.DialogResult = DialogResult.Cancel;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteFatalLog(ex.Message, ex);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            frmProgress.Close();
                            this.Cursor = Cursors.Arrow;
                            MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }));

                        this.DialogResult = DialogResult.Cancel;
                    }
                }));

                FormProgress expr_186 = frmProgress;

                expr_186.Cancelhandle = (EventHandler)Delegate.Combine(expr_186.Cancelhandle, new EventHandler(delegate(object obj, EventArgs args)
                {
                    trd.Abort();
                }));

                trd.Start();
                frmProgress.ShowDialog();

                if (base.DialogResult == DialogResult.OK)
                {
                    Process.Start(curInfo.Directory.FullName);
                }
            }

            this.btn_SelectedToExport.Enabled = true;
        }
    }
}
