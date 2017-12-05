namespace YXH.Model.Request
{
    /// <summary>
    /// 登录用户的信息
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 租用名称
        /// </summary>
        public string tenancyName { get; set; }
        /// <summary>
        /// 用户名或邮件地址
        /// </summary>
        public string usernameOrEmailAddress { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
    }
}
