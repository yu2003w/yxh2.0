using System;

namespace YXH.Model
{
    /// <summary>
    /// 对应日子扫描信息
    /// </summary>
    public class ScanInfoInDays
    {
        /// <summary>
        /// 已扫描数量
        /// </summary>
        public int ScannedCount { get; set; }
        /// <summary>
        /// 扫描日期
        /// </summary>
        public DateTime ScanDate { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        public ScanInfoInDays()
        {
            this.ScannedCount = 0;
            this.ScanDate = DateTime.Today;
        }
    }
}
