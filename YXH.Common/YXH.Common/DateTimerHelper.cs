using System;

namespace YXH.Common
{
    /// <summary>
    /// 事件类型处理帮助类
    /// </summary>
    public static class DateTimerHelper
    {
        /// <summary>
        /// 事件差计算
        /// </summary>
        /// <param name="dtStart">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns>返回差值（秒）</returns>
        public static long dateSecondsDiff(DateTime dtStart, DateTime dtEnd)
        {
            if (DateTime.Compare(dtStart, dtEnd) > 0)
            {
                return 0L;
            }

            TimeSpan ts = new TimeSpan(dtStart.Ticks);
            TimeSpan timeSpan = new TimeSpan(dtEnd.Ticks);
            TimeSpan timeSpan2 = timeSpan.Subtract(ts).Duration();

            return (long)(timeSpan2.Days * 24 * 60 * 60 + timeSpan2.Hours * 60 * 60 + timeSpan2.Minutes * 60 + timeSpan2.Seconds);
        }
    }
}
