using Newtonsoft.Json;
using System.Net;
using System.Text;
using YXH.Model;
using YXH.HttpHelper;

namespace YXH.Scanner.DALFactory
{
    /// <summary>
    /// 考试信息数据
    /// </summary>
    public partial class BaseFactory
    {
        /// <summary>
        /// 获取年级信息
        /// </summary>
        /// <param name="egID">考试组ID</param>
        /// <param name="markingStatus">阅卷状态</param>
        /// <returns>年级信息</returns>
        public ExamGradeResponse ExamGrade_GetList(int egID, string markingStatus)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.EXAMGRADE_GET_BY_EGID_AND_STATUS, egID, markingStatus), string.Empty, 30000, string.Empty, Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = ex.Response as HttpWebResponse;
            }

            ExamGradeResponse egResponse = (hwr == null) ? null : JsonConvert.DeserializeObject<ExamGradeResponse>(HttpWebResponseUtility.GetHttpResponsStr(hwr));

            System_SaveResponseErrorLog(egResponse.Error, "获取年级列表");

            return egResponse;
        }
    }
}
