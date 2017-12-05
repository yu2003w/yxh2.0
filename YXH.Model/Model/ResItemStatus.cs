using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 源项目状态
    /// </summary>
    public class ResItemStatus
    {
        /// <summary>
        /// 说明
        /// </summary>
        private string description = "未标记";
        /// <summary>
        /// 试卷状态
        /// </summary>
        public PaperResourceStatus paperStatus { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string DeScription
        {
            get
            {
                return this.description;
            }
        }
        /// <summary>
        /// 状态编码
        /// </summary>
        public string StatusCode
        {
            get
            {
                string result = "";

                switch (this.paperStatus)
                {
                    case PaperResourceStatus.Complete:
                        result = "0001";

                        break;
                    case PaperResourceStatus.InComplete:
                        result = "0002";

                        break;
                    case PaperResourceStatus.WrongPaper:
                        result = "0003";

                        break;
                    case PaperResourceStatus.Finished:
                        result = "0004";

                        break;
                    case PaperResourceStatus.Unclear:
                        result = "0005";

                        break;
                    case PaperResourceStatus.WrongSubject:
                        result = "0006";

                        break;
                }

                return result;
            }
        }

        /// <summary>
        /// 源项目状态
        /// </summary>
        /// <param name="status">试卷源状态</param>
        public ResItemStatus(PaperResourceStatus status)
        {
            this.paperStatus = status;

            this.UpdateDescription(this.paperStatus);
        }

        /// <summary>
        /// 源项目状态
        /// </summary>
        /// <param name="statusCode">状态编码</param>
        public ResItemStatus(string statusCode)
        {
            string key;

            switch (key = statusCode.Trim())
            {
                case "0001":
                    this.paperStatus = PaperResourceStatus.Complete;

                    goto IL_EA;
                case "0002":
                    this.paperStatus = PaperResourceStatus.InComplete;

                    goto IL_EA;
                case "0003":
                    this.paperStatus = PaperResourceStatus.WrongPaper;

                    goto IL_EA;
                case "0004":
                    this.paperStatus = PaperResourceStatus.Finished;

                    goto IL_EA;
                case "0005":
                    this.paperStatus = PaperResourceStatus.Unclear;

                    goto IL_EA;
                case "0006":
                    this.paperStatus = PaperResourceStatus.WrongSubject;

                    goto IL_EA;
            }

            this.paperStatus = PaperResourceStatus.None;

        IL_EA:
            this.UpdateDescription(this.paperStatus);
        }

        /// <summary>
        /// 源项目状态
        /// </summary>
        public ResItemStatus()
        {
            this.description = "未标记";
            this.paperStatus = PaperResourceStatus.None;
        }

        /// <summary>
        /// 转换为字符串方法
        /// </summary>
        /// <returns>结果字符串</returns>
        public override string ToString()
        {
            return this.DeScription;
        }

        /// <summary>
        /// 更新明细
        /// </summary>
        /// <param name="status">状态</param>
        private void UpdateDescription(PaperResourceStatus status)
        {
            switch (status)
            {
                case PaperResourceStatus.None:
                    this.description = "未标记";

                    return;
                case PaperResourceStatus.Complete:
                    this.description = "待切割完整原卷";

                    return;
                case PaperResourceStatus.InComplete:
                    this.description = "原卷不完整";

                    return;
                case PaperResourceStatus.WrongPaper:
                    this.description = "不是原卷";

                    return;
                case PaperResourceStatus.Finished:
                    this.description = "已切割原卷";

                    return;
                case PaperResourceStatus.Unclear:
                    this.description = "原卷不清晰";

                    return;
                case PaperResourceStatus.WrongSubject:
                    this.description = "非本科目原卷";

                    return;
                default:

                    return;
            }
        }
    }
}