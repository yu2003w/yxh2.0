using System;
using System.IO;
using YXH.Common;
using YXH.Model;

namespace YXH.ScanBLL
{
    public class ScanInfoInDaysBLL
    {
        /// <summary>
        /// 获取当天已扫描数量
        /// </summary>
        public static void GetScannedCountInDays()
        {
            ScanInfoInDays scanInfoInDays = new ScanInfoInDays();

            if (File.Exists(GlobalInfo.LocalDataLocation + "\\Config\\ScanInfoInDays.xml"))
            {
                try
                {
                    scanInfoInDays = FileHelper.DeseriXmlModel<ScanInfoInDays>(GlobalInfo.LocalDataLocation + "\\Config\\ScanInfoInDays.xml");

                    if (scanInfoInDays.ScanDate.Date == DateTime.Today.Date)
                    {
                        ScanGlobalInfo.ScannedCountInDays = scanInfoInDays.ScannedCount;
                    }
                }
                catch (Exception ex)
                {
                    scanInfoInDays.ScannedCount = 0;
                    scanInfoInDays.ScanDate = DateTime.Today;

                    LogHelper.WriteFatalLog(ex.Message, ex);
                }
            }

            FileHelper.SeriXmlModel<ScanInfoInDays>(GlobalInfo.LocalDataLocation + "\\Config\\ScanInfoInDays.xml", scanInfoInDays);
        }

        /// <summary>
        /// 设置当天已扫描数量
        /// </summary>
        public static void SetScannedCountInDays()
        {
            ScanInfoInDays scanInfoInDays = new ScanInfoInDays();

            if (File.Exists(GlobalInfo.LocalDataLocation + "\\Config\\ScanInfoInDays.xml"))
            {
                scanInfoInDays.ScannedCount = ScanGlobalInfo.ScannedCountInDays;
                scanInfoInDays.ScanDate = DateTime.Today;
            }

            FileHelper.SeriXmlModel<ScanInfoInDays>(GlobalInfo.LocalDataLocation + "\\Config\\ScanInfoInDays.xml", scanInfoInDays);
        }
    }
}
