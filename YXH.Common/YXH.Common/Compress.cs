using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace YXH.Common
{
    /// <summary>
    /// 压缩处理类
    /// </summary>
    public static class Compress
    {
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="InputPath">源文件路径</param>
        /// <param name="OutPutRarFile">压缩文件路径</param>
        public static void RarFiles(string InputPath, string OutPutRarFile)
        {
            Process process = new Process();

            try
            {
                process.StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    FileName = ".\\WinRar\\rar.exe",
                    Arguments = "a -ep1 -r -eH " + OutPutRarFile + " " + InputPath,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                process.Start();

                string text = process.StandardOutput.ReadToEnd();

                if (!text.Contains("完成"))
                {
                    throw new Exception("压缩错误：" + text);
                }
            }
            finally
            {
                process.Close();
            }
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="InputFile">源文件路径</param>
        /// <param name="OutPutDir">解压后路径</param>
        public static void UnRar(string InputFile, string OutPutDir)
        {
            Process process = new Process();

            try
            {
                process.StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    FileName = ".\\WinRar\\unrar.exe",
                    Arguments = "x -y " + InputFile + " " + OutPutDir,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                process.Start();

                string text = process.StandardOutput.ReadToEnd();

                if (!text.Contains("完成"))
                {
                    throw new Exception("解压缩压缩错误：" + text);
                }
            }
            finally
            {
                process.Close();
            }
        }

        /// <summary>
        /// 压缩为zip格式
        /// </summary>
        /// <param name="files">需要压缩的文件集</param>
        /// <param name="outputzipfile">压缩文件保存路径</param>
        public static void ZipFiles(string[] files, string outputzipfile)
        {
            ZipFile zipFile = new ZipFile();

            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    zipFile.AddFile(files[i], "");
                }

                zipFile.Save(outputzipfile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                zipFile.Dispose();
            }
        }

        /// <summary>
        /// 将目录压缩为zpi文件
        /// </summary>
        /// <param name="InputDir">目录路径</param>
        /// <param name="outputzipfile">压缩文件保存路径</param>
        public static void ZipFiles(string InputDir, string outputzipfile)
        {
            ZipFile zipFile = new ZipFile();

            try
            {
                zipFile.AddDirectory(InputDir);
                zipFile.Save(outputzipfile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                zipFile.Dispose();
            }
        }

        /// <summary>
        /// 提取zip文件
        /// </summary>
        /// <param name="zipfile">zip文件路径</param>
        /// <param name="outputdir">提取文件保存路径</param>
        public static void ZipExtract(string zipfile, string outputdir)
        {
            ZipFile zipFile = new ZipFile(zipfile);

            try
            {
                zipFile.ExtractAll(outputdir, ExtractExistingFileAction.OverwriteSilently);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                zipFile.Dispose();
            }
        }

        /// <summary>
        /// 读取流中的zip文件
        /// </summary>
        /// <param name="files">文件路径集</param>
        /// <param name="byteList">字符集</param>
        /// <param name="s">流</param>
        public static void ZipFileToStream(List<string> files, List<byte[]> byteList, Stream s)
        {
            ZipFile zipFile = new ZipFile();

            for (int i = 0; i < files.Count; i++)
            {
                zipFile.AddEntry(files[i], byteList[i]);
            }

            zipFile.Save(s);
            zipFile.Dispose();
        }

        /// <summary>
        /// 读取字符集中的zip文件
        /// </summary>
        /// <param name="files">文件路径集</param>
        /// <param name="byteList">字符集</param>
        /// <returns>返回字符集</returns>
        public static byte[] ZipFileToByte(List<string> files, List<byte[]> byteList)
        {
            ZipFile zipFile = new ZipFile();

            for (int i = 0; i < files.Count; i++)
            {
                zipFile.AddEntry(files[i], byteList[i]);
            }

            MemoryStream memoryStream = new MemoryStream();

            zipFile.Save(memoryStream);

            byte[] result = memoryStream.ToArray();

            memoryStream.Close();
            memoryStream.Dispose();

            zipFile.Dispose();

            return result;
        }
    }
}
