using System.Runtime.InteropServices;

namespace YXH.Twain.Structure
{
    /// <summary>
    /// 中间驱动确认信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct TwIdentity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id;
        /// <summary>
        /// 版本信息
        /// </summary>
        public TwVersion Version;
        /// <summary>
        /// 主要协议
        /// </summary>
        public short ProtocolMajor;
        /// <summary>
        /// 次要协议
        /// </summary>
        public short ProtocolMinor;
        /// <summary>
        /// 支持组
        /// </summary>
        public int SupportedGroups;
        /// <summary>
        /// 制造商
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
        public string Manufacturer;
        /// <summary>
        /// 产品族
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
        public string ProductFamily;
        /// <summary>
        /// 产品名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
        public string ProductName;
    }
}
