using System;
using System.Collections.Generic;
using YXH.Model;
using System.Linq;
using System.Text;
using YXH.HttpHelper.Response;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 扫描完成处理处理
    /// </summary>
    public partial class BaseDisposeBLL
    {
        /// <summary>
        /// 当前识别项列表
        /// </summary>
        private List<OmrItem> curOmrItemList;

        /// <summary>
        /// 将扫描结果保存到数据库
        /// </summary>
        /// <returns>操作状态</returns>
        public ApiResponse Student_SaveExamInfo(List<StudentItemPaperInfo> sipiModelList)
        {
            return _dalFactory.Student_SaveExamInfoByEgidAndCsid(sipiModelList, ScanGlobalInfo.ExamGroup.Id, ScanGlobalInfo.ExamInfo.CsID);
        }
    }
}