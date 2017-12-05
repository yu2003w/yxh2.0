using System.Collections.Generic;
using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 上传原卷
    /// </summary>
    public class UploadMeta
    {
        /// <summary>
        /// 文件列表
        /// </summary>
        private List<string> _fileList;
        /// <summary>
        /// 完成数量
        /// </summary>
        private int completedCount;
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 文件列表
        /// </summary>
        public List<string> FileList
        {
            get
            {
                if (this._fileList == null)
                {
                    this._fileList = new List<string>();
                }

                return this._fileList;
            }
            set
            {
                this._fileList = value;
            }
        }

        /// <summary>
        /// 完成数量
        /// </summary>
        public int CompletedCount
        {
            get
            {
                return this.completedCount;
            }
            set
            {
                this.completedCount = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public UploadMeta()
        {
            this.completedCount = 0;
            this._fileList = new List<string>();
        }
    }
}