using YXH.Model;
using YXH.Enum;
using System.Collections.Generic;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 年级信息处理
    /// </summary>
    public partial class BaseDisposeBLL
    {
        /// <summary>
        /// 获取班级信息
        /// </summary>
        /// <returns>考试组下班级信息列表</returns>
        public ExamGradeResponse ExamGrade_GetList()
        {
            if (ScanGlobalInfo.ExamGroup.Id == int.MaxValue)
            {
                return null;
            }

            ExamGradeResponse egResponse = _dalFactory.ExamGrade_GetList(ScanGlobalInfo.ExamGroup.Id, ((int)MarkingStatus.NotStarted).ToString());

            if (egResponse.Success)
            {
                if (egResponse.Data == null)
                {
                    egResponse.Data = new List<ExamGrade>();
                }
            }
            else
            {
                return egResponse;
            }

            ExamGradeResponse egResForSuspend = _dalFactory.ExamGrade_GetList(ScanGlobalInfo.ExamGroup.Id, ((int)MarkingStatus.Suspend).ToString());

            if (egResForSuspend.Success)
            {
                if (egResForSuspend.Data != null && egResForSuspend.Data.Count > 0)
                {
                    egResponse.Data.AddRange(egResForSuspend.Data);
                }
            }
            else
            {
                return egResForSuspend;
            }

            return egResponse;
        }
    }
}
