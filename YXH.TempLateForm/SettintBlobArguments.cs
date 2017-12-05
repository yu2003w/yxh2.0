using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YXH.Enum;

namespace YXH.TemplateForm
{
    public partial class SettintBlobArguments : Form
    {
        /// <summary>
        /// 父级窗口变量声明
        /// </summary>
        private CustomForm _parentForm;
        /// <summary>
        /// 父级窗口变量交互
        /// </summary>
        public CustomForm ParentForm
        {
            get { return _parentForm; }
            set { _parentForm = value; }
        }
        /// <summary>
        /// 斑点列表
        /// </summary>
        private List<string> _blobAttributeList;
        /// <summary>
        /// 父级窗口变量交互
        /// </summary>
        public List<string> BlobAttributeList
        {
            get { return _blobAttributeList; }
            set { _blobAttributeList = value; }
        }
        /// <summary>
        /// 当前选中项的索引
        /// </summary>
        private int _selectedItemIndex;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="pBlobAttribute">当前所有斑点集合</param>
        /// <param name="pIndex">选中项索引</param>
        public SettintBlobArguments(List<string> pBlobAttribute, int pIndex, OperationType type)
        {
            InitializeComponent();

            MinimizeBox = false;
            MaximizeBox = false;

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

            _blobAttributeList = pBlobAttribute;
            _selectedItemIndex = pIndex;

            InitFormData();
        }

        /// <summary>
        /// 绑定窗体上的数据
        /// </summary>
        private void BindFormData()
        {
            string bindStr = _blobAttributeList[_selectedItemIndex];
            string[] attributeArray = bindStr.Split(',');
            cbxTestlatsArgumentList.SelectedIndex = _selectedItemIndex;

            txtTestlatsAreaX.Text = attributeArray[0];
            txtTestlatsAreaY.Text = attributeArray[1];
            txtOptionsNumber.Text = attributeArray[2];
            txtItemsNumber.Text = attributeArray[3];
            txtBlobWidth.Text = attributeArray[5];
            txtBlobHorizontalSpacing.Text = attributeArray[6];
            txtBlobHeight.Text = attributeArray[7];
            txtBlobVerticalInterval.Text = attributeArray[8];
            txtStartQid.Text = attributeArray[9];
        }

        /// <summary>
        /// 绑定界面上的数据
        /// </summary>
        private void InitFormData()
        {
            cbxTestlatsArgumentList.Items.Clear();

            foreach (string item in _blobAttributeList)
            {
                string[] itemAtts = item.Split(',');

                cbxTestlatsArgumentList.Items.Add(string.Format("{0}-{1}", itemAtts[itemAtts.Length - 2], itemAtts[itemAtts.Length - 1]));
            }

            BindFormData();
        }

        /// <summary>
        /// 调整指定数组的参数
        /// </summary>
        private void AdjustArgument()
        {
            _parentForm.Refresh_Adjust(_blobAttributeList, _selectedItemIndex);
        }

        /// <summary>
        /// 减法按钮点击事件
        /// </summary>
        private void btnMinus_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name;
            int argumentIndex = -1;

            switch (name)
            {
                case "btnTestlatsAreaXMinus":
                    argumentIndex = 0;

                    break;
                case "btnTestlatsAreaYMinus":
                    argumentIndex = 1;

                    break;
                case "btnBlobWidthMinus":
                    argumentIndex = 5;

                    break;
                case "btnBlobHorizontalSpacingMinus":
                    argumentIndex = 6;

                    break;
                case "btnBlobHeightMinus":
                    argumentIndex = 7;

                    break;
                case "btnBlobVerticalIntervalMinus":
                    argumentIndex = 8;

                    break;
                case "btnOptionsNumberMinus":
                    argumentIndex = 2;

                    break;
                case "btnItemsNumberMinus":
                    argumentIndex = 3;

                    break;
            }

            ComputeOperation(argumentIndex, false);
        }

        /// <summary>
        /// 计算加减值改变
        /// </summary>
        private void ComputeOperation(int argumentIndex, bool isPlus)
        {
            List<string> argumentArray = _blobAttributeList[_selectedItemIndex].Split(',').ToList();

            if (isPlus)
            {
                argumentArray[argumentIndex] = (float.Parse(argumentArray[argumentIndex]) + 1f).ToString();
            }
            else
            {
                argumentArray[argumentIndex] = (float.Parse(argumentArray[argumentIndex]) - 1f).ToString();
            }

            string newItem = string.Empty;

            foreach (string item in argumentArray)
            {
                newItem += item + ",";
            }

            _blobAttributeList[_selectedItemIndex] = newItem.TrimEnd(',');

            InitFormData();
            AdjustArgument();
        }

        /// <summary>
        /// 加法按钮点击事件
        /// </summary>
        private void btnPlus_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name;
            int argumentIndex = -1;

            switch (name)
            {
                case "btnTestlatsAreaXPlus":
                    argumentIndex = 0;

                    break;
                case "btnTestlatsAreaYPlus":
                    argumentIndex = 1;

                    break;
                case "btnOptionsNumberPlus":
                    argumentIndex = 2;

                    break;
                case "btnItemsNumberPlus":
                    argumentIndex = 3;

                    break;
                case "btnBlobWidthPlus":
                    argumentIndex = 5;

                    break;
                case "btnBlobHorizontalSpacingPlus":
                    argumentIndex = 6;

                    break;
                case "btnBlobHeightPlus":
                    argumentIndex = 7;

                    break;
                case "btnBlobVerticalIntervalPlus":
                    argumentIndex = 8;

                    break;
            }

            if (argumentIndex < 0)
            {
                MessageBox.Show("无效的操作");

                return;
            }

            ComputeOperation(argumentIndex, true);
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        /// <summary>~
        /// 取消按钮点击事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 下拉文本框改变事件
        /// </summary>
        private void cbxTestlatsArgumentList_TextChanged(object sender, EventArgs e)
        {
            _selectedItemIndex = ((ComboBox)sender).SelectedIndex;
            BindFormData();
        }
    }
}
