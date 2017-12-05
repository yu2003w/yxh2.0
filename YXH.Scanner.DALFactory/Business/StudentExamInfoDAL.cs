using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;
using YXH.HttpHelper.Response;
using YXH.Model;
using YXH.HttpHelper;

namespace YXH.Scanner.DALFactory
{
    /// <summary>
    /// 学生考试信息交互类
    /// </summary>
    public partial class BaseFactory
    {
        /// <summary>
        /// 保存学生考试信息
        /// </summary>
        /// <param name="sipisModelList">信息列表</param>
        /// <param name="egid">考试组id</param>
        /// <param name="csid">考试学生id</param>
        /// <returns>保存结果</returns>
        public ApiResponse Student_SaveExamInfoByEgidAndCsid(List<StudentItemPaperInfo> sipiModelList, int egid, int csid)
        {
            HttpWebResponse hwr;

            try
            {
                StudentItemPaperSave sipsModel = new StudentItemPaperSave() { sipisModelList = sipiModelList };
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.STUDENT_SAVE_EXAMINFO_BY_EGID_AND_CSID, egid, csid)
                   , JsonConvert.SerializeObject(sipsModel), 300000, string.Empty, Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = (ex.Response as HttpWebResponse);
            }

            string jsonStr = HttpWebResponseUtility.GetHttpResponsStr(hwr);
            ApiResponse ar = JsonConvert.DeserializeObject<ApiResponse>(jsonStr);

            System_SaveResponseErrorLog(ar.Error, "保存学生考试信息");

            return ar;
        }

        /// <summary>
        /// 根据年级和考试组信息获取学生信息
        /// </summary>
        /// <param name="egid">考试组ID</param>
        /// <param name="gradeCode">年级ID</param>
        /// <returns>返回学生信息</returns>
        public StudentExamInfoResponse Student_GetExamInfosByEgidAndGradeCode(int egid, int gradeCode)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(string.Format(ApiRouterConstant.STUDENT_GET_EXAMINFO_BY_EGID_AND_GRADECODE, egid, gradeCode), string.Empty, 30000, string.Empty, Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = (ex.Response as HttpWebResponse);
            }

            StudentExamInfoResponse seiResponse = JsonConvert.DeserializeObject<StudentExamInfoResponse>(HttpWebResponseUtility.GetHttpResponsStr(hwr));

            System_SaveResponseErrorLog(seiResponse.Error, "根据年级和考试组信息获取学生信息");

            return seiResponse;
        }
    }
}
