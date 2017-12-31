using Newtonsoft.Json;
using System.Net;
using System.Text;
using YXH.Model;
using YXH.HttpHelper.Response;
using YXH.HttpHelper;

namespace YXH.Scanner.DALFactory
{
    /// <summary>
    /// 模板及扫描记录信息操作
    /// </summary>
    public partial class BaseFactory
    {
        /// <summary>
        /// 根据csid获取在线模板信息
        /// </summary>
        /// <param name="csid">csid</param>
        /// <returns>返回得到的模板信息</returns>
        public TemplateInfoResponse TemplateInfo_GetByCsid(int csid)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.TEMPLATE_GET_BY_CSID, csid), string.Empty, 30000, string.Empty, Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = (ex.Response as HttpWebResponse);
            }

            string jsonStr = HttpWebResponseUtility.GetHttpResponsStr(hwr);
            TemplateInfoResponse tiResponse = JsonConvert.DeserializeObject<TemplateInfoResponse>(jsonStr);

            System_SaveResponseErrorLog(tiResponse.Error, "获取模板信息");

            return tiResponse;
        }

        /// <summary>
        /// 保存模板文件信息
        /// </summary>
        /// <param name="tempInfoModel">模板文件信息</param>
        /// <param name="xmlServerPath">对应的xml文档地址</param>
        /// <param name="csid">映射的csid</param>
        /// <returns>操作结果</returns>
        public ApiResponse TamplateInfo_Save(TemplateSave tempInfoModel)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.TEMPLATE_SAVE, tempInfoModel.CSID)
                   , JsonConvert.SerializeObject(tempInfoModel), 30000, string.Empty, Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = (ex.Response as HttpWebResponse);
            }

            ApiResponse ar = JsonConvert.DeserializeObject<ApiResponse>(HttpWebResponseUtility.GetHttpResponsStr(hwr));

            System_SaveResponseErrorLog(ar.Error, "保存模板信息");

            return ar;
        }
    }
}
