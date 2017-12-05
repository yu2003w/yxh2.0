using YXH.Common.OuterInterop;
using YXH.Enum;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 页序号检查
    /// </summary>
    public class PageNumCheck : PaperScan
    {
        /// <summary>
        /// 卷状态
        /// </summary>
        public override VolumeStatus VolumeStatus
        {
            get
            {
                return VolumeStatus.MissingPage;
            }
            set
            {
                this.volumeStatus = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="currentExamPaper">当前试卷纸</param>
        public PageNumCheck(CurrentExamPaper currentExamPaper)
        {
            base.CurrentExamPaper = currentExamPaper;
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        public override void DoScan()
        {
            if (!ScanlibInterop.ReadyToScan(base.CurrentExamPaper.Scanner))
            {
                base.CurrentExamPaper.IsOK = false;

                base.CurrentExamPaper.VolumnDataRow.Data.Status.Add(this.VolumeStatus);
            }
        }
    }
}
