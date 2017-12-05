using System.Drawing;

namespace YXH.Model
{
    /// <summary>
    /// 识别信息数组实体
    /// </summary>
    public class OmrArray
    {
        /// <summary>
        /// 矩形源区域
        /// </summary>
        private CvRect _originSelectRegion;
        /// <summary>
        /// 选择区域
        /// </summary>
        private CvRect _SelectRegion;
        /// <summary>
        /// 编号
        /// </summary>
        public Num num;
        /// <summary>
        /// 项数组
        /// </summary>
        public CvRect[] Items;
        /// <summary>
        /// 源编号
        /// </summary>
        private Num _originnum;
        /// <summary>
        /// 源项目
        /// </summary>
        private CvRect[] _originItems;
        /// <summary>
        /// 项间距
        /// </summary>
        public int Itemdistance;
        /// <summary>
        /// 项大小
        /// </summary>
        public CvRect ItemSize;
        /// <summary>
        /// 选择区域
        /// </summary>
        public CvRect SelectRegion
        {
            get
            {
                return this._SelectRegion;
            }
        }
        /// <summary>
        /// 项矩形区域
        /// </summary>
        public CvRect ItemRectRegion
        {
            get
            {
                CvRect result = new CvRect(this.Items[0].x, this.Items[0].y, this.Items[this.Items.Length - 1].right - this.Items[0].x, this.Items[this.Items.Length - 1].bottom - this.Items[0].y);

                return result;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="num">编号</param>
        /// <param name="items">项信息数组</param>
        public OmrArray(Num num, CvRect[] items)
        {
            if (num != null)
            {
                this.num = new Num(num.number, new Point(num.pos.X, num.pos.Y));
                this._originnum = new Num(num.number, new Point(num.pos.X, num.pos.Y));
            }
            if (items != null)
            {
                this.Items = new CvRect[items.Length];
                this._originItems = new CvRect[items.Length];

                items.CopyTo(this.Items, 0);
                items.CopyTo(this._originItems, 0);
            }
            if (num != null)
            {
                this._SelectRegion.x = num.pos.X - 5;
                this._SelectRegion.y = num.pos.Y - 5;
                this._SelectRegion.width = this._SelectRegion.width + 45;
                this._SelectRegion.height = this._SelectRegion.height + 35;
            }
            else
            {
                this._SelectRegion.x = items[0].x;
                this._SelectRegion.y = items[0].y;
            }
            if (this.Items != null)
            {
                CvRect[] items2 = this.Items;

                for (int i = 0; i < items2.Length; i++)
                {
                    CvRect cvRect = items2[i];

                    if (this._SelectRegion.x >= cvRect.x)
                    {
                        this._SelectRegion.x = cvRect.x - 10;
                    }
                    if (this._SelectRegion.y >= cvRect.y)
                    {
                        this._SelectRegion.y = cvRect.y - 10;
                    }
                    if (this._SelectRegion.y + this._SelectRegion.height <= cvRect.y + cvRect.height)
                    {
                        this._SelectRegion.height = cvRect.y + cvRect.height - this._SelectRegion.y + 5;
                    }
                    if (this._SelectRegion.x + this._SelectRegion.width <= cvRect.x + cvRect.width)
                    {
                        this._SelectRegion.width = cvRect.x + cvRect.width - this._SelectRegion.x + 5;
                    }
                }
            }

            this._originSelectRegion = this._SelectRegion;
        }

        /// <summary>
        /// 移动对象
        /// </summary>
        /// <param name="downPoint">移动前坐标</param>
        /// <param name="MovePoint">移动后坐标</param>
        public void Move(Point downPoint, Point MovePoint)
        {
            int num = MovePoint.X - downPoint.X;
            int num2 = MovePoint.Y - downPoint.Y;
            this._SelectRegion.x = this._originSelectRegion.x + num;
            this._SelectRegion.y = this._originSelectRegion.y + num2;

            if (this.Items != null)
            {
                for (int i = 0; i < this.Items.Length; i++)
                {
                    this.Items[i].x = this._originItems[i].x + num;
                    this.Items[i].y = this._originItems[i].y + num2;
                }
            }
            if (this.num != null)
            {
                this.num.pos.X = this._originnum.pos.X + num;
                this.num.pos.Y = this._originnum.pos.Y + num2;
            }
        }
    }
}
