using System.IO;

namespace YXH.Common
{
    /// <summary>
    /// 硬盘操作帮助
    /// </summary>
    public static class HardDiskHelpler
    {
        /// <summary>
        /// 获取硬盘剩余空间
        /// </summary>
        /// <param name="str_HardDiskName">需要获取的盘符</param>
        /// <returns>空间大小</returns>
        public static long GetHardDiskFreeSpace(string str_HardDiskName)
        {
            long result = 0L;

            str_HardDiskName = str_HardDiskName.ToUpper() + ":\\";

            DriveInfo[] drives = DriveInfo.GetDrives(),
                array = drives;

            for (int i = 0; i < array.Length; i++)
            {
                DriveInfo driveInfo = array[i];

                if (driveInfo.Name == str_HardDiskName)
                {
                    result = driveInfo.TotalFreeSpace / 1048576L;
                }
            }

            return result;
        }

        /// <summary>
        /// 获取硬盘空间
        /// </summary>
        /// <param name="str_HardDiskName">盘符</param>
        /// <returns>空间大小</returns>
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            long result = 0L;

            str_HardDiskName = str_HardDiskName.ToUpper() + ":\\";

            DriveInfo[] drives = DriveInfo.GetDrives(),
                array = drives;

            for (int i = 0; i < array.Length; i++)
            {
                DriveInfo driveInfo = array[i];

                if (driveInfo.Name == str_HardDiskName)
                {
                    result = driveInfo.TotalSize / 1048576L;
                }
            }

            return result;
        }

        /// <summary>
        /// 根据文件路径获取盘符
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>盘符</returns>
        public static string GetHardDiskNameFromFilePath(string filepath)
        {
            return Path.GetFullPath(filepath).Substring(0, 1).ToUpper();
        }
    }
}
