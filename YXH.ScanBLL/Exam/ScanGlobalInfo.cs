using System.Collections.Generic;
using YXH.Enum;
using YXH.Model;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 所有扫描信息
    /// </summary>
    public static class ScanGlobalInfo
    {
        /// <summary>
        /// 扫描模式
        /// </summary>
        public static ScanMode? ScanMode = null;
        /// <summary>
        /// 本地扫描模式
        /// </summary>
        public static string ScanMachineModel = "";

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public static UserInfo loginUser = new UserInfo() { data = new Teacher() };
        /// <summary>
        /// 文件头
        /// </summary>
        public static string FileBatchHead { get; set; }
        /// <summary>
        /// 本地扫描ID
        /// </summary>
        public static string LocalScanID { get; set; }
        /// <summary>
        /// 考试类型
        /// </summary>
        public static ExamType ExamType { get; set; }
        /// <summary>
        /// 状态指示扫描仪是否正在运转
        /// </summary>
        public static bool IsScaning { get; set; }
        /// <summary>
        /// 考试信息
        /// </summary>
        public static ExamInfo ExamInfo { get; set; }

        /// <summary>
        /// 模板信息
        /// </summary>
        public static ZKTemplateInfo TemplateInfo { get; set; }

        /// <summary>
        /// 考试组信息
        /// </summary>
        public static ExamGroup ExamGroup { get; set; }
        /// <summary>
        /// 考试年级信息
        /// </summary>
        public static ExamGrade ExamGrade { get; set; }

        /// <summary>
        /// 当天扫描数量
        /// </summary>
        public static int ScannedCountInDays { get; set; }

        /// <summary>
        /// 忽略条形码长度为0
        /// </summary>
        public static bool IsIgnoreBarcodePrexZero { get; set; }

        /// <summary>
        /// 是否显示高级设置
        /// </summary>
        public static bool IsShowAdvancedSetting { get; set; }

        /// <summary>
        /// 是否打开考试扫描
        /// </summary>
        public static bool isOpenTestScan { get; set; }

        /// <summary>
        /// 是否根据图片创建模板文件
        /// </summary>
        public static bool isOpenCreateTpByImg { get; set; }

        /// <summary>
        /// 扫描源文件类型
        /// </summary>
        public static ImgSourceType scanImgSourceType { get; set; }

        /// <summary>
        /// 重新确定值
        /// </summary>
        public static double RecoSureValue { get; set; }

        /// <summary>
        /// 不重新确定值
        /// </summary>
        public static double RecoNotSureValue { get; set; }

        /// <summary>
        /// omr 错误策略
        /// </summary>
        public static OmrErrorStrategy omrErrorStrategy { get; set; }

        /// <summary>
        /// 当前正在进行的科目ID
        /// </summary>
        public static int CurrentSubject { get; set; }
    }
}
