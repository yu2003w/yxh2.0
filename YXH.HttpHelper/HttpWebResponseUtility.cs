using System;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.Configuration;
using YXH.Common;
using System.Security.Cryptography;

namespace YXH.HttpHelper
{
    /// <summary>  
    /// 有关HTTP请求的辅助类  
    /// </summary>  
    public class HttpWebResponseUtility
    {
        private static readonly string _defaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36";
        private static string _apiAddress = string.Empty;
        private static string _token = string.Empty;
        private static object _lockObj = new object();

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">下载文件的地址</param>
        /// <param name="path">保存文件的本地地址</param>
        public static void HttpDownloadFile(string url, string path)
        {
            Stream stream = new FileStream(path, FileMode.Create);

            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;

                httpWebRequest.KeepAlive = false;
                httpWebRequest.ProtocolVersion = HttpVersion.Version11;

                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream responseStream = httpWebResponse.GetResponseStream();
                byte[] array = new byte[1024];

                for (int i = responseStream.Read(array, 0, array.Length); i > 0; i = responseStream.Read(array, 0, array.Length))
                {
                    stream.Write(array, 0, i);
                }

                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                }
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
        }

        /// <summary>
        /// 验证网络上的文件是否存在
        /// </summary>
        /// <param name="url">文件在网络上的地址</param>
        /// <returns>存在返回true，不存在返回false，其它情况进行异常处理 WebException</returns>
        public static bool HttpCheckFileExist(string url)
        {
            bool result = false;

            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;

                httpWebRequest.KeepAlive = false;
                httpWebRequest.ProtocolVersion = HttpVersion.Version11;

                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                }

                result = true;
            }
            catch (WebException ex)
            {
                HttpWebResponse httpWebResponse = ex.Response as HttpWebResponse;

                if (httpWebResponse.StatusCode != HttpStatusCode.NotFound)
                {
                    throw ex;
                }

                result = false;
            }

            return result;
        }

        /// <summary>
        /// 检测key是否在Config文件中存在
        /// </summary>
        /// <param name="key">需要检测的Key</param>
        /// <returns>存在true，不存在false</returns>
        private static bool ExistsAppSettingKey(string key)
        {
            foreach (string item in ConfigurationManager.AppSettings.AllKeys)
            {
                if (item.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取config设置
        /// </summary>
        /// <param name="key">config配置的key</param>
        /// <returns>返回获取到的配置值</returns>
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 检查是否已设置基础api地址
        /// </summary>
        private static void CheckBaseUrl(string url)
        {
            if (ExistsAppSettingKey("IsTestApp"))
            {
                if (ExistsAppSettingKey("TestBaseUrl"))
                {
                    _apiAddress = GetSetting("TestBaseUrl");
                }
                else
                {
                    throw new ArgumentNullException("未设置服务器地址");
                }
            }
            else
            {
                if (ExistsAppSettingKey("BaseUrl"))
                {
                    _apiAddress = GetSetting("BaseUrl") + url;
                }
                else
                {
                    throw new ArgumentNullException("未设置服务器地址");
                }
            }
        }

        /// <summary>
        /// 读取HTTPWebResponse流信息
        /// </summary>
        /// <param name="hwr">HTTPWebResponse</param>
        /// <returns>返回读取的流字符串</returns>
        public static string GetHttpResponsStr(HttpWebResponse hwr)
        {
            string result = string.Empty;

            if (hwr != null)
            {
                using (StreamReader sr = new StreamReader(hwr.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

        /// <summary>
        /// 组合Token
        /// </summary>
        /// <param name="token">token字符串</param>
        public static void AssemblyToken()
        {
            byte[] formData = Encoding.Default.GetBytes(GlobalInfo.LoginPassWord);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] outPut = md5.ComputeHash(formData);
            string targetData = string.Empty;

            foreach (byte charByte in outPut)
            {
                targetData += charByte.ToString("x2");
            }

            byte[] baseBytes = Encoding.Default.GetBytes(string.Format("{0}:{1}", GlobalInfo.LoginUserName, targetData));
            _token = Convert.ToBase64String(baseBytes);

        }

        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns>请求结果</returns>  
        public static HttpWebResponse CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieCollection cookies)
        {
            lock (_lockObj)
            {
                CheckBaseUrl(url);

                if (string.IsNullOrEmpty(_apiAddress))
                {
                    throw new ArgumentNullException("url");
                }

                GC.Collect();

                HttpWebRequest request = WebRequest.Create(_apiAddress) as HttpWebRequest;

                request.Method = "GET";
                request.UserAgent = _defaultUserAgent;
                request.KeepAlive = false;


                AssemblyToken();

                request.Headers.Add("token", _token);

                if (!string.IsNullOrEmpty(userAgent))
                {
                    request.UserAgent = userAgent;
                }
                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                if (cookies != null)
                {
                    request.CookieContainer = new CookieContainer();
                    request.CookieContainer.Add(cookies);
                }

                return request.GetResponse() as HttpWebResponse;
            }
        }

        /// <summary>
        /// 创建Delete方式的Http请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="userAgent">用户浏览器信息</param>
        /// <param name="cookies">用户Cookies信息</param>
        /// <param name="requestEncoding">请求编码格式</param>
        /// <param name="requestJson">请求的json字符串</param>
        /// <returns></returns>
        public static HttpWebResponse CreateDeleteResponse(string url, int? timeout, string userAgent, CookieCollection cookies, Encoding requestEncoding, string requestJson)
        {
            lock (_lockObj)
            {
                CheckBaseUrl(url);

                if (string.IsNullOrEmpty(_apiAddress))
                {
                    throw new ArgumentNullException("url");
                }

                HttpWebRequest request = null;

                GC.Collect();

                //如果是发送HTTPS请求  
                if (_apiAddress.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(_apiAddress) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = WebRequest.Create(_apiAddress) as HttpWebRequest;
                }

                request.Method = "DELETE";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.KeepAlive = false;

                AssemblyToken();

                request.Headers.Add("token", _token);

                if (!string.IsNullOrEmpty(userAgent))
                {
                    request.UserAgent = userAgent;
                }
                else
                {
                    request.UserAgent = _defaultUserAgent;
                }
                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                if (cookies != null)
                {
                    request.CookieContainer = new CookieContainer();

                    request.CookieContainer.Add(cookies);
                }

                byte[] data = requestEncoding.GetBytes(requestJson);

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                return request.GetResponse() as HttpWebResponse;
            }
        }

        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns>请求到的数据</returns>  
        public static HttpWebResponse CreatePostHttpResponse(string url, string requestJson, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            lock (_lockObj)
            {
                CheckBaseUrl(url);

                if (string.IsNullOrEmpty(_apiAddress))
                {
                    throw new ArgumentNullException("url");
                }
                if (requestEncoding == null)
                {
                    throw new ArgumentNullException("requestEncoding");
                }

                HttpWebRequest request = null;

                GC.Collect();

                //如果是发送HTTPS请求  
                if (_apiAddress.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(_apiAddress) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = WebRequest.Create(_apiAddress) as HttpWebRequest;
                }

                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.KeepAlive = false;


                AssemblyToken();

                request.Headers.Add("token", _token);

                if (!string.IsNullOrEmpty(userAgent))
                {
                    request.UserAgent = userAgent;
                }
                else
                {
                    request.UserAgent = _defaultUserAgent;
                }
                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                if (cookies != null)
                {
                    request.CookieContainer = new CookieContainer();

                    request.CookieContainer.Add(cookies);
                }

                byte[] data = requestEncoding.GetBytes(requestJson);

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                return request.GetResponse() as HttpWebResponse;
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
    }
}