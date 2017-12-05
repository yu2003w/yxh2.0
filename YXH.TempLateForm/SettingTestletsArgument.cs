using System;
using System.Windows.Forms;
using YXH.Enum;
using YXH.Model;

namespace YXH.TemplateForm
{
    public partial class SettingTestletsArgument : Form
    {
        /// <summary>
        /// 试题相关参数
        /// </summary>
        TestletsArgumentModel taModel;
        private OperationType _opType;
        /// <summary>
        /// 自定义窗体
        /// </summary>
        private CustomForm parentForm;
        /// <summary>
        /// 自定义窗体交互
        /// </summary>
        public CustomForm ParentForm
        {
            get { return parentForm; }
            set { parentForm = value; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public SettingTestletsArgument(string curMaxStartQid, OperationType type)
        {
            InitializeComponent();

            _opType = type;

            InitForm(curMaxStartQid);

            if (type == OperationType.SCHOOLNUMBER_OMR)
            {
                lblStartQid.Visible = false;
                txtStartQid.Visible = false;
            }
            else
            {
                lblStartQid.Visible = true;
                txtStartQid.Visible = true;
            }
        }

        /// <summary>
        /// 初始化窗体参数
        /// </summary>
        private void InitForm(string curMaxStartQid)
        {
            MinimizeBox = false;
            MaximizeBox = false;

            if (_opType == OperationType.OBJECTIVE_OMR)
            {
                cbxOptionsNumber.SelectedIndex = 2;
                cbxItemNumber.SelectedIndex = 4;
                cbxOptionsOrientation.SelectedIndex = 0;
            }
            else
            {
                cbxOptionsNumber.SelectedIndex = 8;
                cbxItemNumber.SelectedIndex = 9;

                cbxOptionsOrientation.SelectedIndex = 1;
            }

            txtStartQid.TabIndex = 0;
            txtStartQid.Text = curMaxStartQid;
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtStartQid.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入开始题号", "提示", MessageBoxButtons.OK);

                return;
            }

            int qid = 0;

            if (!int.TryParse(txtStartQid.Text.Trim(), out qid))
            {
                MessageBox.Show("题号格式只能为数字", "提示", MessageBoxButtons.OK);

                return;
            }

            taModel = new TestletsArgumentModel()
            {
                OptionsNumber = Convert.ToInt32(cbxOptionsNumber.SelectedItem),
                ItemNumber = Convert.ToInt32(cbxItemNumber.SelectedItem),
                ArrangementMode = cbxOptionsOrientation.SelectedItem.Equals("横向") ? (int)ArrangementModeEnum.CROSSWISE : (int)ArrangementModeEnum.LENGTHWAYS,
                StartQID = int.Parse(txtStartQid.Text),
                EndQID = int.Parse(txtStartQid.Text) + Convert.ToInt32(cbxItemNumber.SelectedItem) - 1
            };

            parentForm.Refresh_SettingArea(taModel);

            base.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            taModel = null;
            base.DialogResult = DialogResult.Cancel;
        }
    }
}