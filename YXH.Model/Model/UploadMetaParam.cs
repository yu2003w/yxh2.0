using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// s上传元参数
    /// </summary>
    public class UploadMetaParam
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        private long _timeout = -1L;
        /// <summary>
        /// 当前上传类型
        /// </summary>
        public UploadType CurType;
        /// <summary>
        /// 是否重试
        /// </summary>
        public bool IsTryAgain { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public long TimeOut
        {
            get
            {
                return this._timeout;
            }
            set
            {
                this._timeout = value;
            }
        }
        /// <summary>
        /// 是否结束写入
        /// </summary>
        public bool IsOverWrite { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        public UploadMetaParam()
        {
            this._timeout = -1L;
            this.IsTryAgain = false;
            this.IsOverWrite = true;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="timeout">超时时间</param>
        /// <param name="istryagain">是否重试</param>
        /// <param name="curtype">上传类型</param>
        public UploadMetaParam(long timeout, bool istryagain, UploadType curtype = UploadType.StudentRecord)
        {
            this._timeout = timeout;
            this.IsTryAgain = istryagain;
            this.CurType = curtype;
            this.IsOverWrite = true;
        }
    }
}