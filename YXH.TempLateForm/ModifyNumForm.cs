using System;
using System.Drawing;
using System.Windows.Forms;
using YXH.Model;

namespace YXH.TemplateForm
{
    public partial class ModifyNumForm : Form
    {
        /// <summary>
        /// 排列方式
        /// </summary>
        private int arrange;
        /// <summary>
        /// 识别项间距
        /// </summary>
        private int ocrdistance;
        /// <summary>
        /// 项间距
        /// </summary>
        private int itemdistance;
        /// <summary>
        /// 操作类型
        /// </summary>
        private int OpType;
        /// <summary>
        /// 题号位置
        /// </summary>
        private Point numPos;
        /// <summary>
        /// 项内容
        /// </summary>
        private CvRect itemSize;
        /// <summary>
        /// 题号
        /// </summary>
        private Num _Num;
        /// <summary>
        /// 项列表
        /// </summary>
        private CvRect[] _Items;
        /// <summary>
        /// 题号
        /// </summary>
        public Num Num
        {
            get
            {
                return this._Num;
            }
        }
        /// <summary>
        /// 项数量
        /// </summary>
        public int ItemCount
        {
            get
            {
                return int.Parse(this.txtItemCount.Text);
            }
        }
        /// <summary>
        /// 项列表
        /// </summary>
        public CvRect[] Items
        {
            get
            {
                return this._Items;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="pos">题号位置</param>
        /// <param name="OpType">操作类型</param>
        public ModifyNumForm(Point pos, int OpType = 1)
        {
            this.InitializeComponent();
            this.OpType = OpType;
            this.numPos = pos;
            this.txtItemCount.Enabled = false;
            this.rdHarrange.Enabled = false;
            this.rdVarrange.Enabled = false;
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.OpType == 0)
            {
                this._Items = new CvRect[this.ItemCount];

                for (int i = 0; i < this.ItemCount; i++)
                {
                    if (this.arrange == 0)
                    {
                        this._Items[i].x = this.itemSize.x + i * (this.itemSize.width + this.itemdistance);
                        this._Items[i].y = this.itemSize.y;
                        this._Items[i].width = this.itemSize.width;
                        this._Items[i].height = this.itemSize.height;
                    }
                    else
                    {
                        this._Items[i].x = this.itemSize.x;
                        this._Items[i].y = this.itemSize.y + i * (this.itemSize.height + this.itemdistance);
                        this._Items[i].width = this.itemSize.width;
                        this._Items[i].height = this.itemSize.height;
                    }
                }
            }

            this._Num = new Num();

            if (this.OpType == 0)
            {
                int x = (this.arrange == 0) ? (this._Items[0].x - this.ocrdistance) : this._Items[0].x;
                int y = (this.arrange == 0) ? this._Items[0].y : (this._Items[0].y - this.ocrdistance);
                this._Num.number = int.Parse(this.txtNum.Text);
                this._Num.pos = new Point(x, y);
            }
            else
            {
                this._Num.number = int.Parse(this.txtNum.Text);
                this._Num.pos = this.numPos;
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
        /// 竖排单选按钮选中修改状态改变事件
        /// </summary>
        private void rdVarrange_CheckedChanged(object sender, EventArgs e)
        {
            this.arrange = 1;
        }

        /// <summary>
        /// 横排单选按钮选中修改状态改变事件
        /// </summary>
        private void rdHarrange_CheckedChanged(object sender, EventArgs e)
        {
            this.arrange = 0;
        }
    }
}
