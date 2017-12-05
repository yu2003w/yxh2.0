using System;
using System.Collections.Generic;

namespace YXH.Model
{
    /// <summary>
    /// 资源记录
    /// </summary>
    public class ResourceRecord
    {
        /// <summary>
        /// 考试ID
        /// </summary>
        public long examid;
        /// <summary>
        /// 模板文件ID
        /// </summary>
        public string tpId = "";
        /// <summary>
        /// 类型
        /// </summary>
        public int type;
        /// <summary>
        /// 资源名称
        /// </summary>
        public string resName = "";
        /// <summary>
        /// 资源路径
        /// </summary>
        public string resPath = "";
        /// <summary>
        /// 资源名称集字符串
        /// </summary>
        public string resNames = "";
        /// <summary>
        /// 创建者
        /// </summary>
        public string creator = "";
        /// <summary>
        /// 资源状态
        /// </summary>
        public string resStatus = "";
        /// <summary>
        /// 根目录
        /// </summary>
        public string RootPath
        {
            get
            {
                string result = "";

                if (!string.IsNullOrEmpty(this.resPath) && this.resPath.StartsWith("TplFile"))
                {
                    result = this.resPath.Replace("TplFile/", "file/tf/");
                }

                return result;
            }
        }
        /// <summary>
        /// 金山服务完整的文件压缩密钥
        /// </summary>
        public string ksFullFileZipKey
        {
            get
            {
                string result = "",
                    arg_0C_0 = this.RootPath;

                if (!string.IsNullOrEmpty(this.resPath) && !string.IsNullOrEmpty(this.resName) && this.resPath.StartsWith("TplFile"))
                {
                    result = this.resPath.Replace("TplFile/", "file/tf/") + this.resName;
                }

                return result;
            }
        }
        /// <summary>
        /// 图片文件名称集合
        /// </summary>
        public List<string> ImgFileNames
        {
            get
            {
                List<string> list = new List<string>();
                string arg_0C_0 = this.RootPath;

                if (!string.IsNullOrEmpty(this.resNames))
                {
                    string[] array = this.resNames.Split(new char[]
					{
						';'
					}, StringSplitOptions.RemoveEmptyEntries),
                    array2 = array;

                    for (int i = 0; i < array2.Length; i++)
                    {
                        string item = array2[i];

                        list.Add(item);
                    }
                }

                return list;
            }
        }
    }
}
