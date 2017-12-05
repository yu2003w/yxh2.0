namespace YXH.Model
{
    /// <summary>
    /// 键值对类型
    /// </summary>
    /// <typeparam name="T1">键</typeparam>
    /// <typeparam name="T2">值</typeparam>
    public class KeyValue<T1, T2>
    {
        /// <summary>
        /// 键
        /// </summary>
        private T1 key;
        /// <summary>
        /// 值
        /// </summary>
        private T2 value;
        /// <summary>
        /// 键
        /// </summary>
        public T1 Key
        {
            get
            {
                return this.key;
            }
        }
        /// <summary>
        /// 值
        /// </summary>
        public T2 Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public KeyValue(T1 Key, T2 Value)
        {
            this.key = Key;
            this.value = Value;
        }
    }
}
