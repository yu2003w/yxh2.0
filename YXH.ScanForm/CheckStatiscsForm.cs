using System;
using System.Drawing;
using System.Windows.Forms;
using YXH.Common;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.ScanForm
{
    /// <summary>
    /// 检查静态窗体
    /// </summary>
    public partial class CheckStatiscsForm : Form
    {
        /// <summary>
        /// 自动大小形式
        /// </summary>
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        /// <summary>
        /// 构造方法
        /// </summary>
        public CheckStatiscsForm()
        {
            InitializeComponent();

            this.lbl_DailyScan.Text = ScanGlobalInfo.ScannedCountInDays.ToString();
            ScanStatistics scanStatistics = ScanStatisticsBLL.GetScanStatistics();
            this.lblScanSpeed.Text = scanStatistics.ScanSpeed + "张/分钟";
            this.lblIncorrectCount.Text = ErrorPageManangerBLL.GetIncorrectPaperCount().ToString() + "张";
        }

        /// <summary>
        /// 添加窗体到控件
        /// </summary>
        /// <param name="targetCrl">目标控件</param>
        /// <param name="target">目标窗体</param>
        private void addFormToCrl(Control targetCrl, Form target)
        {
            target.TopLevel = false;
            target.FormBorderStyle = FormBorderStyle.None;

            targetCrl.Controls.Add(target);

            target.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 检查窗体调整大小事件
        /// </summary>
        private void Check_statisticForm_Resize(object sender, EventArgs e)
        {
            int num = base.Height / 3,
                num2 = num - this.panelLeft_Top.Height;
            this.panelLeft_Top.Height = num;
            this.panelLeft_mid.Height = num;
            this.panelLeft_footer.Height = num;
            this.panel1.Height += num2;

            this.asc.controlAutoSize(this.panelLeft_Top);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void CheckStatiscsForm_Load(object sender, EventArgs e)
        {
            Form form = new StatisticForm();

            this.addFormToCrl(this.splitContainer1.Panel2, form);
            form.Show();

            base.Resize += new EventHandler(this.Check_statisticForm_Resize);
            this.panel2.Parent = this.picBox_DailyComoplete;
            this.panel2.BackColor = Color.Transparent;
            this.lbl_DailyScan.Parent = this.panel2;
            this.lbl_DailyScan.BackColor = Color.Transparent;
        }
    }
}
