namespace YXH.Model
{
    /// <summary>
    /// 保存客观题答案Model
    /// </summary>
    public class ObjectItem
    {
        /// <summary>
        /// 客观题题号
        /// </summary>
        public int questNum { get; set; }
        /// <summary>
        /// 扫描的学生客观题答案,二进制表示多选 1.A，2.B,4.C,8.D,16.E,32.F
        /// </summary>
        public int answerHas { get; set; }

        /// <summary>
        /// 选中项字母
        /// </summary>
        public string stuObjectAnswer { get; set; }
    }
}
