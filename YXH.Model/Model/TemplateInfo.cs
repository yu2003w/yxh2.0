using System;
using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 模板信息
    /// </summary>
    [Serializable]
    public class TemplateInfo
    {
        /// <summary>
        /// 是否双面
        /// </summary>
        public bool? isDoubleSide;
        /// <summary>
        /// 源图片类型
        /// </summary>
        public ImgSourceType imgSourceType;

        /// <summary>
        /// 页数据
        /// </summary>
        public Page[] pages;
    }
}
