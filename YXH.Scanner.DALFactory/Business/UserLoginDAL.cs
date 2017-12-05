using YXH.Model;
using Newtonsoft.Json;
using System.Text;
using YXH.Model.Request;
using System.Net;
using YXH.HttpHelper;

namespace YXH.Scanner.DALFactory
{
    /// <summary>
    /// 用户登录信息处理
    /// </summary>
    public partial class BaseFactory
    {
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="token">用户登录时的Token</param>
        /// <returns>返回权限信息列表</returns>
         public PermissionResponse User_GetUserPermission()
        {
            HttpWebResponse hwr;

            try
            {
                hwr = YXH.HttpHelper.HttpWebResponseUtility.CreatePostHttpResponse(ApiRouterConstant.USER_PERMISSION, string.Empty, 30000, string.Empty, Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = ex.Response as HttpWebResponse;
            }

            string jsonStr = HttpWebResponseUtility.GetHttpResponsStr(hwr);
            PermissionResponse prModel = JsonConvert.DeserializeObject<PermissionResponse>(jsonStr);

            System_SaveResponseErrorLog(prModel.Error, "用户权限请求");

            return prModel;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginModel">登录请求信息</param>
        /// <returns>获取的当前用户信息</returns>
        public UserInfo User_UserLogin(LoginModel loginModel)
        {
            HttpWebResponse hwr;

            try
            {
                hwr = HttpWebResponseUtility.CreatePostHttpResponse(ApiRouterConstant.USER_LOGIN, JsonConvert.SerializeObject(loginModel), 30000, string.Empty,
                    Encoding.GetEncoding("UTF-8"), null);
            }
            catch (WebException ex)
            {
                hwr = ex.Response as HttpWebResponse;
            }

            string jsonStr = HttpWebResponseUtility.GetHttpResponsStr(hwr);
            UserInfo uiModel = JsonConvert.DeserializeObject<UserInfo>(jsonStr);

            System_SaveResponseErrorLog(uiModel.Error, "用户登录");

            return uiModel;
        }
    }
}
