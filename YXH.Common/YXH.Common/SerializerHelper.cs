using MsgPack;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace YXH.Common
{
    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public class SerializerHelper
    {
        /// <summary>
        /// 将xml反序列化为对象类
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="path">xml文件路径</param>
        /// <returns>装载后的对象类型</returns>
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
        /// 将对象序列化为xml
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="outputPath">xml文件输出路径</param>
        /// <param name="model">需要序列化的对象</param>
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
        /// 包装对象
        /// </summary>
        /// <typeparam name="T">需哟啊包装的对象类型</typeparam>
        /// <param name="model">需要包装的对象</param>
        /// <returns>包装后的字符集</returns>
        public static byte[] SeriMsgPack<T>(T model) where T : class
        {
            ObjectPacker objectPacker = new ObjectPacker();
            return objectPacker.Pack(model);
        }

        /// <summary>
        /// 拆包对象
        /// </summary>
        /// <typeparam name="T">需要拆包的对象类型</typeparam>
        /// <param name="o">源字符集</param>
        /// <returns>拆包后的对象</returns>
        public static T DeseriMsgPack<T>(byte[] o) where T : class
        {
            ObjectPacker objectPacker = new ObjectPacker();
            return objectPacker.Unpack<T>(o);
        }

        /// <summary>
        /// 序列化对象为json
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 反序列化json为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns>目标对象</returns>
        public static T DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
