using System;
using YXH.Model;
using YXH.Model.Request;
using System.Collections.Generic;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 用户登录处理
    /// </summary>
    public partial class BaseDisposeBLL
    {
        /// <summary>
        /// 获取登录用户权限
        /// </summary>
        /// <returns>是否有操作权限</returns>
        public PermissionResponse User_GetPermission()
        {
            PermissionResponse pr = _dalFactory.User_GetUserPermission();
            PermissionConstant pc = new PermissionConstant(true);
            List<string> pcList = new List<string>();

            if (pr.Success)
            {
                if (pr.Data.Count > 0)
                {
                    foreach (string p in pr.Data)
                    {
                        foreach (string b in pc.perList)
                        {
                            if (b.Equals(p))
                            {
                                switch (b)
                                {
                                    case PermissionConstant.ORG_OWNER:
                                        pcList.Add(PermissionConstant.ORG_OWNER);

                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }

                if (pcList.Count > 0)
                {
                    ScanGlobalInfo.loginUser.data.roles = pcList;
                }
            }

            return pr;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="LoginModel">登录信息</param>
        /// <returns>用户登录信息</returns>
        public UserInfo User_Login(LoginModel lModel)
        {
            try
            {
                UserInfo uiModel = _dalFactory.User_UserLogin(lModel); //调用登录接口

                if (uiModel.Success)
                {
                    ScanGlobalInfo.loginUser.data.orgid = uiModel.data.orgid;
                    ScanGlobalInfo.loginUser.data.orgname = uiModel.data.orgname;
                    ScanGlobalInfo.loginUser.Data = uiModel.Data;
                    ScanGlobalInfo.loginUser.data.uname = uiModel.data.uname;
                    ScanGlobalInfo.loginUser.data.UID = uiModel.data.UID;
                }

                return uiModel;
            }
            catch (Exception ex)
            {
                _dalFactory.System_SaveErrorLog(ex, "用户信息处理");

                throw ex;
            }
        }
    }
}
