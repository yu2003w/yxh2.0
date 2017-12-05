using System.Collections.Generic;

namespace YXH.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// 默认的构造函数
        /// </summary>
        public Teacher() { }

        /// <summary>
        /// 主键
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// 登陆人员类型
        /// </summary>
        public string orgtype { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        public string orgname { get; set; }

        /// <summary>
        /// 学校ID
        /// </summary>
        public string orgid { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string uname { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public List<string> roles { get; set; }
    }
}
