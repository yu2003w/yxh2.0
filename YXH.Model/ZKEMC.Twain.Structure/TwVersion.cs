using System.Runtime.InteropServices;

namespace YXH.Twain.Structure
{
    /// <summary>
    /// 中间驱动版本信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct TwVersion
    {
        /// <summary>
        /// 主要的编号
        /// </summary>
        public short MajorNum;
        /// <summary>
        /// 次要的编号
        /// </summary>
        public short MinorNum;
        /// <summary>
        /// 语言
        /// </summary>
        public short Language;
        /// <summary>
        /// 国家
        /// </summary>
        public short Country;
        /// <summary>
        /// 信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
        public string Info;
    }
}
