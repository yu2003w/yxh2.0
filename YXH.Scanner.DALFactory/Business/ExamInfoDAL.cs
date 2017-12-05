using Newtonsoft.Json;
using System.Net;
using System.Text;
using YXH.Model;
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
        /// 删除试卷数据
        /// </summary>
        /// <param name="csID">学生考试科目ID</param>
        /// <param name="batchNum">批次编号</param>
        /// <returns>Api请求结果</returns>
        public ApiResponse ExamInfo_DeletePaperByCsIDAndBatchNum(int csID, int batchNum)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreateDeleteResponse(string.Format(ApiRouterConstant.EXAMINFO_DELETE_PAPER_BY_CSID_AND_BATCHNUM, csID, batchNum), 30000, string.Empty, null, Encoding.GetEncoding("UTF-8"), string.Empty);
            }
            catch (WebException ex)
            {
                hwr = (ex.Response as HttpWebResponse);
            }

            ApiResponse ar = JsonConvert.DeserializeObject<ApiResponse>(HttpWebResponseUtility.GetHttpResponsStr(hwr));

            System_SaveResponseErrorLog(ar.Error, "根据csID和batchNum删除所有考卷文件名称");

            return ar;
        }

        /// <summary>
        /// 获取所有考卷名称
        /// </summary>
        /// <param name="csID">csID</param>
        /// <returns>api返回结果</returns>
        public StudentPaperResponse ExamInfo_GetAllPaperByCsID(int csID)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreateGetHttpResponse(string.Format(ApiRouterConstant.EXAMINFO_GETALLPAPER_BY_CSID, csID), 30000
                    , string.Empty, null);
            }
            catch (WebException ex)
            {
                hwr = (ex.Response as HttpWebResponse);
            }

            string responseJsonStr = HttpWebResponseUtility.GetHttpResponsStr(hwr);

            StudentPaperResponse eiResponse = JsonConvert.DeserializeObject<StudentPaperResponse>(responseJsonStr);

            System_SaveResponseErrorLog(eiResponse.Error, "根据csID获取所有考卷文件名称");

            return eiResponse;
        }
    }
}
