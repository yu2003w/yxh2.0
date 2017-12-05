namespace YXH.ScanBLL
{
    /// <summary>
    /// 批次数据行
    /// </summary>
    public class BatchDataRow
    {
        /// <summary>
        /// 批次编号
        /// </summary>
        private int _batchindex;
        /// <summary>
        /// 总数
        /// </summary>
        private int _total;
        /// <summary>
        /// 异常数量
        /// </summary>
        private int _abnormalnum;
        /// <summary>
        /// 批次编号
        /// </summary>
        public int BatchIndex
        {
            get
            {
                return this._batchindex;
            }
            set
            {
                this._batchindex = value;
            }
        }
        /// <summary>
        /// 批次总数
        /// </summary>
        public int BatchTotal
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        /// <summary>
        /// 异常数量
        /// </summary>
        public int AbnormalNum
        {
            get
            {
                return this._abnormalnum;
            }
            set
            {
                this._abnormalnum = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public BatchDataRow()
        {
            this._total = 0;
            this._batchindex = 0;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">批次索引</param>
        /// <param name="total">本批次总数</param>
        /// <param name="abnormalnum">异常数量</param>
        public BatchDataRow(int index, int total, int abnormalnum)
        {
            this._total = total;
            this._batchindex = index;
            this._abnormalnum = abnormalnum;
        }

        /// <summary>
        /// 转换为字符串方法
        /// </summary>
        /// <returns>转换后的字符串</returns>
        public override string ToString()
        {
            base.ToString();

            string arg = "(" + this.BatchIndex + ")";
            string arg2 = "(" + this.BatchTotal + ")";
            string arg3 = "(" + this._abnormalnum + ")";

            return string.Format(" 批次{0,-6}试卷数{1,-8}异常{2,-8}", arg, arg2, arg3);
        }
    }
}