using System.Collections.Generic;

namespace YXH.Model
{
    /// <summary>
    /// 有客户端权限的权限类型枚举
    /// </summary>
    public class PermissionConstant
    {
        /// <summary>
        /// 权限的常量列表
        /// </summary>
        public List<string> perList;

        /// <summary>
        /// 构造方法
        /// </summary>
        public PermissionConstant(bool showList)
        {
            perList = new List<string>(){
                ORG_OWNER
                //SCAN_MAKETEMPLATE,
                //SCAN_UPDATESTUDENTPAPER
            };
        }

        public const string ORG_OWNER = "校长";

        ///// <summary>
        ///// 有扫描和上传学生试卷权限
        ///// </summary>
        //public const string SCAN_UPDATESTUDENTPAPER = "Scan.UpdateStudentPaper";
        ///// <summary>
        ///// 有制作模板权限
        ///// </summary>
        //public const string SCAN_MAKETEMPLATE = "Scan.MakeTemplate";
    }
}
