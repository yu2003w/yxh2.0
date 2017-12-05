namespace YXH.Enum
{
    /// <summary>
    /// 操作状态
    /// </summary>
    public enum OperateStatus
    {
        MainPage,   //主操作界面
        SubjectList,    //考试列表
        SubjectOperate, //科目操作
        TemplateMake,   //模板制作
        CheckTemplate,  //查看模板
        ScanOperate,    //扫描操作
        UploadMaterials,    //上传资料（原卷，标准答案等）
        ReUploadMaterials,  //重新上传资料
        Statistics, //查看统计
        ScanFinish, //完成扫描
        ScannerSetting, //扫描仪设置
        CheckUploadFiles,   //检查上传文件列表
        HistoryExamRecord,  //历史考试统计
        SystemSetting,  //系统设置
        Logout  //退出系统
    }
}
