using Newtonsoft.Json;
using System.Net;
using System.Text;
using YXH.Model;
using YXH.HttpHelper;

namespace YXH.Scanner.DALFactory
{
    /// <summary>
    /// 考试组信息数据
    /// </summary>
    public partial class BaseFactory
    {
        /// <summary>
        /// 获取考试科目信息
        /// </summary>
        /// <param name="egID">考试组ID</param>
        /// <param name="templateStatus">模板状态</param>
        /// <param name="gradeCode">年级编码</param>
        /// <param name="markingStatus">阅卷状态</param>
        /// <returns>考试信息</returns>
        public ExamInfoResponse ExamInfo_GetList(int egID, int templateStatus, int gradeCode, string markingStatus)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreateGetHttpResponse(string.Format(ApiRouterConstant.EXAMINFO_GET_BY_EGID_AND_TEMPLATESTATUS_AND_GRADECODE, egID, templateStatus, gradeCode, markingStatus), 30000, string.Empty, null);
            }
            catch (WebException ex)
            {
                hwr = (ex.Response as HttpWebResponse);
            }

            string jsonStr = HttpWebResponseUtility.GetHttpResponsStr(hwr);
            ExamInfoResponse eiResponse = JsonConvert.DeserializeObject<ExamInfoResponse>(jsonStr);

            System_SaveResponseErrorLog(eiResponse.Error, "根据考试组获取考试信息");

            return eiResponse;
        }

        /// <summary>
        /// 根据考试状态获取考试组信息
        /// </summary>
        /// <param name="markingStatus">当前需要查询的考试状态</param>
        /// <returns>返回查询单到的考试组列表</returns>
        public ExamGroupResponse ExamGroup_GetList(string markingStatus)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.EXAMGROUP_GET_BY_MARKING_AND_STATUS, markingStatus), string.Empty, 30000, string.Empty, Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = ex.Response as HttpWebResponse;
            }

            string jsonStr = HttpWebResponseUtility.GetHttpResponsStr(hwr);
            ExamGroupResponse egResponse = (hwr == null) ? null : JsonConvert.DeserializeObject<ExamGroupResponse>(jsonStr);

            System_SaveResponseErrorLog(egResponse.Error, "获取考试组列表");

            return egResponse;
        }
    }
}
