using System;

namespace YXH.Common
{
    /// <summary>
    /// 字符串效果
    /// </summary>
    public class StringUtility
    {
        /// <summary>
        /// 设置Int默认值
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="defValue">默认的Int值</param>
        /// <returns>设置后Int值</returns>
        public static int ToInt32Default(string s, int defValue)
        {
            int result;

            try
            {
                if (string.IsNullOrEmpty(s))
                {
                    result = defValue;
                }
                else
                {
                    result = Convert.ToInt32(s);
                }
            }
            catch (Exception)
            {
                result = defValue;
            }

            return result;
        }
    }
}
