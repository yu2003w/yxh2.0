using System;

namespace YXH.Model
{
    /// <summary>
    /// 本机配置
    /// </summary>
    [Serializable]
    public class MachineConfig
    {
        /// <summary>
        /// 扫描账户名称
        /// </summary>
        public string ScanAccountName { get; set; }

        /// <summary>
        /// 扫描账户密码
        /// </summary>
        public string ScanAccountPsw { get; set; }

        /// <summary>
        /// 扫描客户端唯一编号
        /// </summary>
        public string ScanID { get; set; }
    }

}
