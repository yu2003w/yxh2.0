using System;
using System.IO;
using YXH.Common;
using YXH.Model;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 扫描统计处理
    /// </summary>
    public class ScanStatisticsBLL
    {
        /// <summary>
        /// 获取扫描统计信息
        /// </summary>
        /// <returns>统计信息</returns>
        public static ScanStatistics GetScanStatistics()
        {
            ScanStatistics result = null;

            if (ScanGlobalInfo.ExamInfo != null && File.Exists(PathHelper.ScanStatisticsPath))
            {
                try
                {
                    result = FileHelper.DeseriXmlModel<ScanStatistics>(PathHelper.ScanStatisticsPath);

                    return result;
                }
                catch (Exception ex)
                {
                    result = new ScanStatistics();

                    LogHelper.WriteFatalLog(ex.Message, ex);

                    return result;
                }
            }
            else
            {
                result = new ScanStatistics();
            }

            return result;
        }

        /// <summary>
        /// 设置扫描统计信息
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="timeSpan">时间间隔</param>
        public static void SetScanStatistics(int count, TimeSpan timeSpan)
        {
            if (count <= 0 || timeSpan.TotalMinutes < 0.01)
            {
                return;
            }

            double num = (double)count / timeSpan.TotalMinutes;

            if (double.IsInfinity(num) || double.IsNaN(num))
            {
                return;
            }

            ScanStatistics scanStatistics = new ScanStatistics()
            {
                ScanSpeed = Math.Round(num, 0)
            };

            FileHelper.SeriXmlModel<ScanStatistics>(PathHelper.ScanStatisticsPath, scanStatistics);
        }
    }
}
