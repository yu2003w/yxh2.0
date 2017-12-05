using YXH.Enum;
using YXH.Model;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 纸扫描
    /// </summary>
    public abstract class PaperScan
    {
        /// <summary>
        /// 容量状态
        /// </summary>
        protected VolumeStatus volumeStatus;
        /// <summary>
        /// 当前试卷纸类型
        /// </summary>
        public CurrentExamPaper CurrentExamPaper { get; set; }
        /// <summary>
        /// 容量状态
        /// </summary>
        public virtual VolumeStatus VolumeStatus
        {
            get
            {
                return this.volumeStatus;
            }
            set
            {
                this.volumeStatus = value;
            }
        }
        /// <summary>
        /// 模板信息
        /// </summary>
        protected TemplateInfo TemplateInfo { get; set; }

        /// <summary>
        /// 开始扫描
        /// </summary>
        public abstract void DoScan();
    }
}
