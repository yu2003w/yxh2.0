using System;
using System.Windows.Forms;
using YXH.Enum;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 考号设置
    /// </summary>
    public partial class CodeTypeSelectForm : Form
    {
        /// <summary>
        /// 考号类型
        /// </summary>
        public SchoolNumberType type
        {
            get
            {
                if (rbBarCode.Checked)
                {
                    return SchoolNumberType.BarCcode;
                }
                else if (rbQRcode.Checked)
                {
                    return SchoolNumberType.QR;
                }

                return SchoolNumberType.Omr;
            }
        }
        /// <summary>
        /// 考号二维码是否纵向粘贴
        /// </summary>
        public bool BarCodeIsHorizontal
        {
            get
            {
                return !this.chkBarCodeIsvertical.Checked;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public CodeTypeSelectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 条形码单选选中事件
        /// </summary>
        private void rbBarCode_CheckedChanged(object sender, EventArgs e)
        {
            this.chkBarCodeIsvertical.Enabled = true;
        }

        /// <summary>
        /// 二维码单选选中事件
        /// </summary>
        private void rbQRcode_CheckedChanged(object sender, EventArgs e)
        {
            this.chkBarCodeIsvertical.Enabled = false;
            this.chkBarCodeIsvertical.Checked = false;
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }
    }
}
