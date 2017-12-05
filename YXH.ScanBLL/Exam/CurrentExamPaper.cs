using System;
using System.Collections.Generic;
using YXH.Model;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 当前试卷
    /// </summary>
    public class CurrentExamPaper : ExamPaper
    {
        /// <summary>
        /// 卷数据行
        /// </summary>
        private VolumnDataRow _volumnDataRow;
        /// <summary>
        /// 扫描纸信息
        /// </summary>
        public PaperScan PaperScan { get; set; }
        /// <summary>
        /// 扫描器句柄
        /// </summary>
        public IntPtr Scanner { get; set; }
        /// <summary>
        /// 扫描纸列表
        /// </summary>
        public List<PaperScan> PaperScanList { get; set; }
        /// <summary>
        /// 卷数据行
        /// </summary>
        public VolumnDataRow VolumnDataRow
        {
            get
            {
                if (this._volumnDataRow == null)
                {
                    this._volumnDataRow = new VolumnDataRow();
                }
                return this._volumnDataRow;
            }
            set
            {
                this._volumnDataRow = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="scanner">扫描句柄</param>
        public CurrentExamPaper(IntPtr scanner)
        {
            this.PaperScanList = new List<PaperScan>();
            base.IsOK = true;
            this.Scanner = scanner;
            this.VolumnDataRow.Data = new ExaminationPaper
            {
                Guid = Guid.NewGuid(),
                Omr = string.Empty,
                Omrs = new string[0],
                ScanTime = DateTime.Now,
                ScanID = ScanGlobalInfo.LocalScanID
            };
        }

        /// <summary>
        /// 请求扫描
        /// </summary>
        public void RequestScan()
        {
            this.PaperScan.DoScan();
        }
    }
}
