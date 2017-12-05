using System;
using System.Windows.Forms;
using YXH.Common;
using YXH.Enum;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 模板设置
    /// </summary>
    public partial class TemplateSettingForm : Form
    {
        /// <summary>
        /// 矩形高度
        /// </summary>
        private const int RECT_HEIHGT = 20;
        /// <summary>
        /// 矩形宽度
        /// </summary>
        private const int RECT_WIDTH = 30;
        /// <summary>
        /// 当前识别类型
        /// </summary>
        public OmrType CurOmrType
        {
            get
            {
                if (!this.rbRect.Checked)
                {
                    return OmrType.Bracket;
                }

                return OmrType.Rect;
            }
            set
            {
                switch (value)
                {
                    case OmrType.Rect:
                        this.rbRect.Checked = true;
                        this.rbBracket.Checked = false;

                        return;
                    case OmrType.Bracket:
                        this.rbRect.Checked = false;
                        this.rbBracket.Checked = true;

                        return;
                    default:
                        this.rbRect.Checked = true;
                        this.rbBracket.Checked = false;

                        return;
                }
            }
        }
        /// <summary>
        /// 矩形高度
        /// </summary>
        public int RectHeight
        {
            get
            {
                int result = 30;

                try
                {
                    result = Convert.ToInt32(this.tb_RectHeight.Text.ToString().Trim());
                }
                catch (Exception ex)
                {
                    result = 20;

                    LogHelper.WriteFatalLog(ex.Message, ex);
                }

                return result;
            }
            set
            {
                this.tb_RectHeight.Text = value.ToString();
            }
        }
        /// <summary>
        /// 矩形宽度
        /// </summary>
        public int RectWid
        {
            get
            {
                int result = 30;

                try
                {
                    result = Convert.ToInt32(this.tb_RectWid.Text.ToString().Trim());
                }
                catch (Exception ex)
                {
                    result = 30;

                    LogHelper.WriteFatalLog(ex.Message, ex);
                }

                return result;
            }
            set
            {
                this.tb_RectWid.Text = value.ToString();
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public TemplateSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 方框单选按钮状态改变事件
        /// </summary>
        private void rbRect_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbRect.Checked)
            {
                this.gb_RectIno.Enabled = true;

                return;
            }

            this.gb_RectIno.Enabled = false;
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string value = this.tb_RectHeight.Text.ToString().Trim();

                Convert.ToInt32(value);

                string value2 = this.tb_RectWid.Text.ToString().Trim();

                Convert.ToInt32(value2);

                base.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show("请根据客观题填涂框的大小输入相应的整数!");

                this.tb_RectHeight.Text = 20.ToString();
                this.tb_RectWid.Text = 30.ToString();
            }
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }
    }
}
