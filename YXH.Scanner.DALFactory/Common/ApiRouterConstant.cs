namespace YXH.Scanner.DALFactory
{
    public class ApiRouterConstant
    {
        #region 系统操作

        /// <summary>
        /// 保存日志
        /// </summary>
        internal const string LOG_SAVE = "";

        #endregion

        #region 用户操作

        /// <summary>
        /// 用户登录
        /// </summary>
        internal const string USER_LOGIN = "login";
        /// <summary>
        /// 获取用户权限
        /// </summary>
        internal const string USER_PERMISSION = "getPermissions";

        #endregion

        #region 考试信息

        /// <summary>
        /// 根据阅卷状态获取考试组
        /// </summary>
        internal const string EXAMGROUP_GET_BY_MARKING_AND_STATUS = "getExams/{0}";
        /// <summary>
        /// 根据考试组ID和阅卷状态获取年级信息
        /// </summary>
        internal const string EXAMGRADE_GET_BY_EGID_AND_STATUS = "getExamGrades/{0}/{1}";
        /// <summary>
        /// 根据考试组、模板状态、学历类型、年级编码获取当前科目列表
        /// </summary>
        internal const string EXAMINFO_GET_BY_EGID_AND_TEMPLATESTATUS_AND_GRADECODE = "exam/subject/status/{0}/{1}/{2}/{3}";
        /// <summary>
        /// 根据CSID获取所有试卷
        /// </summary>
        internal const string EXAMINFO_GETALLPAPER_BY_CSID = "exam/papers/{0}";
        /// <summary>
        /// 根据CSID删除所有信息
        /// </summary>
        internal const string EXAMINFO_DELETE_PAPER_BY_CSID_AND_BATCHNUM = "/delete/papers/{0}/{1}";

        #endregion

        #region 模板信息

        /// <summary>
        /// 保存模板信息
        /// </summary>
        internal const string TEMPLATE_SAVE = "saveExamTemplate/{0}";
        /// <summary>
        /// 根据csid获取模板信息
        /// </summary>
        internal const string TEMPLATE_GET_BY_CSID = "getExamTemplate/{0}";

        #endregion

        #region 考试结果

        /// <summary>
        /// 根据egid和csid保存学生考试信息
        /// </summary>
        internal const string STUDENT_SAVE_EXAMINFO_BY_EGID_AND_CSID = "save/answers/{0}/{1}";

        /// <summary>
        /// 根据考试组id和年级获取学生考试信息
        /// </summary>
        internal const string STUDENT_GET_EXAMINFO_BY_EGID_AND_GRADECODE = "getStudentsInfo/{0}/{1}";

        #endregion

        #region 资料上传

        /// <summary>
        /// 试卷原图信息保存接口
        /// </summary>
        internal const string MATERIALS_SAVE_EXAMPAPER_PICPATH = "";

        /// <summary>
        /// 空白答题卡信息保存接口
        /// </summary>
        internal const string MATERIALS_SAVE_EXAM_QA_PICPATH = "";
        #endregion
    }
}
