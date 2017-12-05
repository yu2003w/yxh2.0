using Aliyun.OSS;
using Aliyun.OSS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YXH.Common
{
    /// <summary>
    /// 阿里云处理管理
    /// </summary>
    public class ALiProgressManager
    {
        private static Dictionary<int, object> _lookObj = new Dictionary<int, object>();
        private static object _lookScanOjb = new object();

        /// <summary>
        /// 初始化OSS客户端
        /// </summary>
        /// <returns>客户端实例</returns>
        public static OssClient InitClient(out string bucketName)
        {
            string endPoint = "oss-cn-hangzhou.aliyuncs.com",
                isTestSetting = ConfigurationHelper.GetSetting("IsTestApp"),
                accessKeyId = string.Empty,
                accessKeySecret = string.Empty;

            bucketName = string.Empty;

            if (string.IsNullOrEmpty(isTestSetting) || Convert.ToBoolean(isTestSetting))
            {
                //测试环境
                accessKeyId = "LTAIRf0qaQSS6Y2x";
                accessKeySecret = "IaPIEYKXxtZ5k6XynMPhFPfLoqnXAn";
                bucketName = "ustudypaper";
            }
            else if (!Convert.ToBoolean(isTestSetting))
            {
                //正式环境
                accessKeyId = "";
                accessKeySecret = "";
                bucketName = "";
            }

            return new OssClient(endPoint, accessKeyId, accessKeySecret);
        }

        /// <summary>
        /// 获取指定前缀的文件信息
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <returns>文件集合</returns>
        public static IEnumerable<string> CheckObjectWithPrefix(string prefix)
        {
            List<string> list = new List<string>();
            string buckName = string.Empty;
            OssClient client = InitClient(out buckName);

            try
            {
                ObjectListing result = null;
                string nextMarker = string.Empty;

                do
                {
                    var listObjectsRequest = new ListObjectsRequest(buckName)
                    {
                        Marker = nextMarker,
                        MaxKeys = 1000,
                        Prefix = prefix
                    };

                    result = client.ListObjects(listObjectsRequest);

                    list.AddRange(result.ObjectSummaries.Select(m => m.Key));

                    nextMarker = result.NextMarker;
                } while (result.IsTruncated);

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取Oss上的文件
        /// </summary>
        /// <returns>返回已上传的文件列表</returns>
        public static List<string> Oss_GetFileNameList()
        {
            try
            {
                string buckName = string.Empty;
                OssClient client = InitClient(out buckName);

                List<string> fileKeyList = new List<string>();
                ObjectListing oListing = client.ListObjects(buckName);

                foreach (OssObjectSummary summary in oListing.ObjectSummaries)
                {
                    fileKeyList.Add(summary.Key);
                }

                return fileKeyList;
            }
            catch (Exception)
            {
                throw new Exception("从服务器获取数据过程中出现意外，请检查网络是否已断开！");
            }
        }

        /// <summary>
        /// 删除指定的文件集合
        /// </summary>
        /// <param name="delFileList">需要删除的文件集合</param>
        public static void Oss_DeleteFilesByList(List<string> delFileList)
        {
            try
            {
                if (delFileList != null && delFileList.Count > 0)
                {
                    string buckName = string.Empty;
                    OssClient client = InitClient(out buckName);
                    DeleteObjectsRequest doRequest = new DeleteObjectsRequest(buckName, delFileList, false);
                    client.DeleteObjects(doRequest);
                }
            }
            catch (OssException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 线程池上传到阿里云时只给出成功或者失败的状态
        /// </summary>
        /// <param name="objectPath">待上传对象的磁盘存储路径</param>
        /// <param name="objectName">待上传对象的名称</param>
        /// <returns>上传结果</returns>
        public static bool PutObjectByScan(string objectPath, string objectName)
        {
            lock (_lookScanOjb)
            {
                if (!FileHelper.ExistsFile(objectPath))
                {
                    return false;
                }

                try
                {
                    GC.Collect();

                    string buckName = string.Empty;
                    OssClient client = InitClient(out buckName);
                    FileStream objStream = new FileStream(objectPath, System.IO.FileMode.OpenOrCreate);   //定义文件流
                    ObjectMetadata objMetadata = new ObjectMetadata(); //定义 object 描述
                    PutObjectResult putResult = client.PutObject(buckName, objectName, objStream, objMetadata);    //执行 put 请求，并且返回对象的MD5摘要。

                    objStream.Dispose();

                    if (!string.IsNullOrEmpty(putResult.ETag))
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 进行对象存储
        /// </summary>
        /// <param name="bucketName">bucket名称</param>
        public static string Oss_PutObject(string objectPath, string objectName)
        {
            lock (_lookObj)
            {
                if (!FileHelper.ExistsFile(objectPath))
                {
                    throw new Exception(string.Format("需要上传的文件{0},在指定的路径{1}未找到！{2}请确认文件是否已被移动或删除！", objectName, objectPath, Environment.NewLine));
                }

                try
                {
                    GC.Collect();

                    string buckName = string.Empty;
                    OssClient client = InitClient(out buckName);
                    FileStream objStream = new FileStream(objectPath, System.IO.FileMode.OpenOrCreate);   //定义文件流
                    ObjectMetadata objMetadata = new ObjectMetadata(); //定义 object 描述
                    PutObjectResult putResult = client.PutObject(buckName, objectName, objStream, objMetadata);    //执行 put 请求，并且返回对象的MD5摘要。

                    objStream.Dispose();

                    return putResult.ETag;
                }
                catch (Exception ex)
                {
                    throw new Exception("上传过程出现错误，请查看网络是否已断开！");
                }
            }
        }

        /// <summary>
        /// 验证指定的文件是否存在
        /// </summary>
        /// <param name="key">文件名称</param>
        /// <returns>是存在</returns>
        public static bool Oss_ExistObject(string key)
        {
            try
            {
                string buckName = string.Empty;
                OssClient client = InitClient(out buckName);

                return client.DoesObjectExist(buckName, key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从指定的OSS存储空间中获取指定的文件
        /// </summary>
        /// <param name="bucketName">要获取的文件所在的存储空间的名称</param>
        /// <param name="key">要获取的文件的名称</param>
        /// <param name="fileToDownload">文件保存的本地路径</param>
        public static void Oss_GetObject(string key, string fileToDownload)
        {
            try
            {
                string buckName = string.Empty;
                OssClient client = InitClient(out buckName);
                OssObject obj = client.GetObject(buckName, key);

                using (Stream requestStream = obj.Content)
                {
                    byte[] buf = new byte[1024];
                    FileStream fs = File.Create(Path.Combine(fileToDownload, key));
                    int len = 0;

                    while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                    {
                        fs.Write(buf, 0, len);
                    }

                    fs.Close();
                    fs.Dispose();
                }

                obj.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("指定下载的文件在服务器上未找到", ex);
            }
        }
    }
}
