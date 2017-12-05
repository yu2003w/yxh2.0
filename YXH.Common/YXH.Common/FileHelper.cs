using Aspose.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Xml;
using System.Xml.Serialization;

namespace YXH.Common
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 数据对象锁
        /// </summary>
        public static object LockDataObj = new object();

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sourceFile">源文件路径（带有文件名）</param>
        /// <param name="targetDirectory">目标文件路径</param>
        /// <param name="targeFileName">目标文件名称</param>
        /// <param name="isOverWrite">是否覆盖已有同名文件</param>
        public static void Copy(string sourceFile, string targetDirectory, string targeFileName, bool isOverWrite)
        {
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string destFileName = Path.Combine(targetDirectory, targeFileName);

            File.Copy(sourceFile, destFileName, isOverWrite);
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="di">目录信息</param>
        /// <returns>返回操作状态</returns>
        public static bool DeleteDir(DirectoryInfo di)
        {
            bool result;

            try
            {
                di.Delete(true);

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 验证指定的文件是否存在
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>验证结果</returns>
        public static bool ExistsFile(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// 删除目录或目录文件
        /// </summary>
        /// <param name="dir">目录路径</param>
        /// <param name="delSelf">是否删除当前目录</param>
        /// <returns>返回操作状态</returns>
        public static bool DeleteDir(string dir, bool delSelf)
        {
            bool result;

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);

                if (delSelf)
                {
                    result = FileHelper.DeleteDir(directoryInfo);
                }
                else
                {
                    FileInfo[] files = directoryInfo.GetFiles();

                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fileInfo = files[i];

                        fileInfo.Delete();
                    }

                    DirectoryInfo[] directories = directoryInfo.GetDirectories();

                    for (int j = 0; j < directories.Length; j++)
                    {
                        DirectoryInfo di = directories[j];

                        FileHelper.DeleteDir(di);
                    }

                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 将xml文件反序列化为实体类
        /// </summary>
        /// <typeparam name="T">实体对象类型</typeparam>
        /// <param name="path">xml文件路径</param>
        /// <returns>返回装载后的实体类</returns>
        public static T DeseriXmlModel<T>(string path) where T : class
        {
            Type typeFromHandle = typeof(T);
            FileStream fileStream = null;
            T result;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeFromHandle);
                fileStream = new FileStream(path, FileMode.Open);
                T t = xmlSerializer.Deserialize(fileStream) as T;

                fileStream.Close();

                result = t;
            }
            catch (Exception ex)
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }

                throw ex;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }

            return result;
        }

        /// <summary>
        /// 将实体类序列化为xml文件，并保存
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="outputPath">xml文件保存目录路径</param>
        /// <param name="model">接收到的实体</param>
        public static void SeriXmlModel<T>(string outputPath, T model) where T : class
        {
            Type typeFromHandle = typeof(T);
            FileStream fileStream = null;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeFromHandle);
                fileStream = new FileStream(outputPath, FileMode.Create);

                xmlSerializer.Serialize(fileStream, model);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message, ex);
                throw ex;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
        }

        /// <summary>
        /// 将对象序列化为xml文件并保存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">需要序列化的对象</param>
        /// <param name="outputPath">xml文件保存目录</param>
        public static void SerializeToXml<T>(T obj, string outputPath)
        {
            lock (FileHelper.LockDataObj)
            {
                DataContractSerializer dataContractSerializer = new DataContractSerializer(obj.GetType());

                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    dataContractSerializer.WriteObject(fileStream, obj);
                }
            }
        }

        /// <summary>
        /// 将指定文件反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="fileName">xml文件名</param>
        /// <returns>返回反序列化后的对象实体</returns>
        public static T DeserializeFromXml<T>(string fileName)
        {
            T result;

            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    using (XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas()))
                    {
                        DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(T));
                        result = (T)((object)dataContractSerializer.ReadObject(xmlDictionaryReader, true));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 获取Image文件
        /// </summary>
        /// <param name="file">需要获取文件的路径</param>
        /// <returns>返回获取文件的位图</returns>
        public static Bitmap GetImage(string file)
        {
            if (File.Exists(file))
            {
                Bitmap result = null;

                using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    int num = (int)fileStream.Length;
                    byte[] buffer = new byte[num];

                    fileStream.Read(buffer, 0, num);

                    result = (Bitmap)Image.FromStream(new MemoryStream(buffer), true);

                    fileStream.Close();
                }

                return result;
            }

            return null;
        }

        /// <summary>
        /// 将指定数据集转化为Excel文件并保存
        /// </summary>
        /// <param name="workBookPath">Excel文件的保存路径</param>
        /// <param name="sheetName">Excel文件中的Sheet名称</param>
        /// <param name="data">需要转化保存的数据集</param>
        /// <param name="columnNames">表格中的列名</param>
        /// <param name="propertyNames">所有者名称</param>
        public static void ExportListToExcel(string workBookPath, string sheetName, ICollection data, string[] columnNames, string[] propertyNames)
        {
            Workbook workbook = new Workbook();

            workbook.Worksheets.Clear();

            Worksheet worksheet = workbook.Worksheets.Add(sheetName);

            worksheet.Cells.ImportArray(columnNames, 0, 0, false);
            worksheet.Cells.ImportCustomObjects(data, propertyNames, false, 1, 0, data.Count, true, "yyyy-MM-dd", false);
            worksheet.AutoFitColumns();

            workbook.Save(workBookPath);
        }

        /// <summary>
        /// 合并Excel
        /// </summary>
        /// <param name="excelPaths">需要合并的Excel文件路径列表</param>
        /// <param name="workBookPath">合并后的文件存储路径</param>
        public static void CombineExcels(IList<string> excelPaths, string workBookPath)
        {
            Workbook workbook = new Workbook();

            workbook.Worksheets.Clear();

            foreach (string current in excelPaths)
            {
                Workbook secondWorkbook = new Workbook(current);

                workbook.Combine(secondWorkbook);
            }

            workbook.Save(workBookPath);
        }

        /// <summary>
        /// 复制指定文件
        /// </summary>
        /// <param name="srcDirectory">源文件所在的目录名</param>
        /// <param name="fileName">文件名</param>
        /// <returns>复制后的文件名（包含目录）</returns>
        public static string CopyFileToMyDocuments(string srcDirectory, string fileName)
        {

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                text2,
                text = text2 = Path.Combine(folderPath, fileName),
                fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2),
                extension = Path.GetExtension(text2),
                directoryName = Path.GetDirectoryName(text2);
            int num = 1;

            while (File.Exists(text))
            {
                string str = string.Format("{0}({1})", fileNameWithoutExtension, num++);
                text = Path.Combine(directoryName, str + extension);
            }

            File.Copy(Path.Combine(srcDirectory, fileName), text, true);

            return text;
        }

        /// <summary>
        /// 判断是否有写入权限
        /// </summary>
        /// <param name="dir">需要判断的目录名</param>
        /// <returns>返回写入权限类型</returns>
        public static bool HasWritePermission(string dir)
        {
            bool flag = false,
                flag2 = false;
            DirectorySecurity directorySecurity = null;

            try
            {
                directorySecurity = Directory.GetAccessControl(dir);
            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception("DirectoryNotFoundException");
            }

            if (directorySecurity == null)
            {
                return false;
            }

            AuthorizationRuleCollection accessRules = directorySecurity.GetAccessRules(true, true, typeof(SecurityIdentifier));

            if (accessRules == null)
            {
                return false;
            }

            foreach (FileSystemAccessRule fileSystemAccessRule in accessRules)
            {
                if ((FileSystemRights.Write & fileSystemAccessRule.FileSystemRights) == FileSystemRights.Write)
                {
                    if (fileSystemAccessRule.AccessControlType == AccessControlType.Allow)
                    {
                        flag = true;
                    }
                    else if (fileSystemAccessRule.AccessControlType == AccessControlType.Deny)
                    {
                        flag2 = true;
                    }
                }
            }
            return flag && !flag2;
        }

        /// <summary>
        /// 创建本地应用程序数据目录
        /// </summary>
        /// <returns>返回目录路径</returns>
        public static string CreateLocalAppDataLocation()
        {
            string appDataDir = ConfigurationHelper.GetSetting("AppDataDirName"),
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                text = string.Empty;

            text = string.IsNullOrWhiteSpace(appDataDir) ? Path.Combine(folderPath, "ZKKJ") : Path.Combine(folderPath, appDataDir);

            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }

            return text;
        }

        /// <summary>
        /// 创建临时目录
        /// </summary>
        /// <returns>返回目录路径</returns>
        public static string CreateTempDirectory()
        {
            string path = Guid.NewGuid().ToString(),
                text = Path.Combine(Path.GetTempPath(), path);

            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }

            return text;
        }
    }
}
