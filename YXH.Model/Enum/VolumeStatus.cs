namespace YXH.Enum
{
    /// <summary>
    /// 试卷状态
    /// </summary>
    public enum VolumeStatus
    {
        /// <summary>
        /// 已上传
        /// </summary>
        Finished,
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 考号不可识别
        /// </summary>
        Ambiguous,
        /// <summary>
        /// 重号
        /// </summary>
        Duplicate,
        /// <summary>
        /// 错号
        /// </summary>
        ErrZkzh,
        /// <summary>
        /// 页不可定位
        /// </summary>
        ErrorPage,
        /// <summary>
        /// 缺页
        /// </summary>
        MissingPage,
        /// <summary>
        /// 客观题存疑
        /// </summary>
        ErrOmr,
        /// <summary>
        /// 后台处理客观题存疑
        /// </summary>
        ManualHandleomr,
        /// <summary>
        /// 重叠卷
        /// </summary>
        VolumnOverlap,
        /// <summary>
        /// 原图加载失败
        /// </summary>
        LoadingFailed
    }
}
