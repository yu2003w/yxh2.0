namespace YXH.Enum
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// 扫描设置
        /// </summary>
        SCAN_SETTING,
        /// <summary>
        /// 水平调整
        /// </summary>
        DESKEWED_DETECTION,
        /// <summary>
        /// 标题框选
        /// </summary>
        TITLE,
        /// <summary>
        /// 考号框选
        /// </summary>
        SCHOOLNUMBER_OMR,
        /// <summary>
        /// 隐藏区域框选
        /// </summary>
        HIDEACER,
        /// <summary>
        /// 客观题区域框选
        /// </summary>
        OBJECTIVE_OMR,
        /// <summary>
        /// 主观题区域框选
        /// </summary>
        SUBJECTIVE_OMR,
        /// <summary>
        /// 完成框选
        /// </summary>
        FINISHED
    }
}
