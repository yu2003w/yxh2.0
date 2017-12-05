using Newtonsoft.Json;
using System.Net;
using System.Text;
using YXH.HttpHelper.Response;
using YXH.HttpHelper;

namespace YXH.Scanner.DALFactory
{
    /// <summary>
    /// 考试信息数据
    /// </summary>
    public partial class BaseFactory
    {
        /// <summary>
        /// 保存原卷数据
        /// </summary>
        /// <param name="csID">学生考试科目ID</param>
        /// <param name="fileName">原卷文件名，多个用','分隔</param>
        /// <returns>Api请求结果</returns>
        public ApiResponse Materials_SaveExamPaperPicPath(int csID, string fileName)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.MATERIALS_SAVE_EXAMPAPER_PICPATH, csID, fileName)
                    , string.Empty, 30000, string.Empty, Encoding.GetEncoding("UTF-8"), null);

            }
            catch (WebException ex)
            {
                hwr = (ex.Response as HttpWebResponse);
            }

            ApiResponse ar = JsonConvert.DeserializeObject<ApiResponse>(HttpWebResponseUtility.GetHttpResponsStr(hwr));

            System_SaveResponseErrorLog(ar.Error, "保存试卷原图");

            return ar;
        }


        /// <summary>
        /// 保存空白答题卡数据
        /// </summary>
        /// <param name="csID">学生考试科目ID</param>
        /// <param name="fileName">空白答题卡文件名，多个用','分隔</param>
        /// <returns>获得的考试列表</returns>
        public ApiResponse Materials_SaveExapQAPicPath(int csid, string fileNames)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.MATERIALS_SAVE_EXAM_QA_PICPATH, csid, fileNames)
                    , string.Empty, 30000, string.Empty, Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = ex.Response as HttpWebResponse;
            }

            ApiResponse ar = JsonConvert.DeserializeObject<ApiResponse>(HttpWebResponseUtility.GetHttpResponsStr(hwr));

            System_SaveResponseErrorLog(ar.Error, "上传空白答题卡");

            return ar;
        }
    }
}
