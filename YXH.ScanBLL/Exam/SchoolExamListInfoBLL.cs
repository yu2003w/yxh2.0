using System;
using System.Collections.Generic;
using YXH.Enum;
using YXH.Model;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 学校考试列表信息
    /// </summary>
    public partial class BaseDisposeBLL
    {
        /// <summary>
        /// 根据考试组ID和状态获取当前考试
        /// </summary>
        /// <returns>考试信息</returns>
        public ExamInfoResponse ExamInfo_GetList()
        {
            ExamInfoResponse eiResponse = _dalFactory.ExamInfo_GetList(ScanGlobalInfo.ExamGroup.Id, ((int)TemplateState.All), ScanGlobalInfo.ExamGrade.GradeId, ((int)MarkingStatus.NotStarted).ToString());

            if (eiResponse.Success)
            {
                if (eiResponse.Data == null)
                {
                    eiResponse.Data = new List<ExamInfo>();
                }
            }
            else
            {
                return eiResponse;
            }

            ExamInfoResponse eiResForSuspend = _dalFactory.ExamInfo_GetList(ScanGlobalInfo.ExamGroup.Id, ((int)TemplateState.All), ScanGlobalInfo.ExamGrade.GradeId, ((int)MarkingStatus.Suspend).ToString());

            if (eiResForSuspend.Success)
            {
                if (eiResForSuspend.Data != null && eiResForSuspend.Data.Count > 0)
                {
                    eiResponse.Data.AddRange(eiResForSuspend.Data);
                }
            }
            else
            {
                return eiResForSuspend;
            }

            if (eiResponse.Success && eiResponse.Data != null)
            {
                foreach (ExamInfo eiModel in eiResponse.Data)
                {
                    eiModel.School = ScanGlobalInfo.loginUser.data.orgid;
                }
            }

            return eiResponse;
        }

        /// <summary>
        /// 获取当前未开始阅卷考试组信息
        /// </summary>
        /// <returns>考试组api返回信息</returns>
        public ExamGroupResponse ExamGroup_GetList(string markingStatus)
        {
            string[] statusArray = markingStatus.Split(',');
            ExamGroupResponse egResponse = new ExamGroupResponse();

            foreach (string status in statusArray)
            {
                ExamGroupResponse eiResForSuspend = _dalFactory.ExamGroup_GetList(status);

                if (eiResForSuspend.Success)
                {
                    if (egResponse.Data == null)
                    {
                        egResponse.Data = new List<ExamGroup>();
                    }

                    egResponse.Data.AddRange(eiResForSuspend.Data);

                    egResponse.Success = true;
                }
                else
                {
                    egResponse.Success = false;

                    return egResponse;
                }
            }

            return egResponse;
        }

        /// <summary>
        /// 获取学校考试信息列表
        /// </summary>
        /// <param name="schoolId">学校ID</param>
        /// <param name="isFinish">是否完成</param>
        /// <returns>考试信息列表</returns>
        public List<ExamInfo> GetSchoolExamList(string schoolId, bool isFinish)
        {
            //List<ExamInfo> list = new List<ExamInfo>();
            //IList<ExamInfo> shoolExamListInfoBySchoolId = this.GetShoolExamListInfoBySchoolId(schoolId, isFinish);

            //if (shoolExamListInfoBySchoolId != null)
            //{
            //    list.AddRange(shoolExamListInfoBySchoolId);
            //}

            //return list;

            throw new Exception("函数 GetSchoolExamList 未完成");
        }
    }
}
