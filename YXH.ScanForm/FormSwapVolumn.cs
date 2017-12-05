using System;
using System.Windows.Forms;

namespace YXH.ScanForm
{
    /// <summary>
    /// 试卷页面调换
    /// </summary>
    public partial class FormSwapVolumn : Form
    {
        /// <summary>
        /// 试卷页数
        /// </summary>
        public int PageCount;
        /// <summary>
        /// 第一页
        /// </summary>
        public int FirstPage;
        /// <summary>
        /// 第二页
        /// </summary>
        public int SecondPage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public FormSwapVolumn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFirst.Text) || string.IsNullOrEmpty(this.txtSecond.Text))
            {
                MessageBox.Show("页码不能为空", "提示");

                return;
            }
            try
            {
                this.SecondPage = int.Parse(this.txtSecond.Text);

                if (this.SecondPage > this.PageCount || this.SecondPage < 1 || this.SecondPage == this.FirstPage)
                {
                    MessageBox.Show("页码范围不正确", "提示");

                    return;
                }
            }
            catch
            {
                MessageBox.Show("请输入有效数字", "提示");

                return;
            }

            base.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        private void FormSwapVolumn_Load(object sender, EventArgs e)
        {
            this.txtFirst.Text = this.FirstPage.ToString();
        }
    }
}
