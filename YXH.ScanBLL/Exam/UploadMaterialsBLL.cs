using YXH.HttpHelper.Response;
using YXH.Model;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 上传重要资料类
    /// </summary>
    public partial class BaseDisposeBLL
    {
        /// <summary>
        /// 保存模板信息到数据库
        /// </summary>
        /// <param name="tempInfoModel">模板信息</param>
        /// <param name="xmlFileServicePath">xml文件路径</param>
        /// <returns>操作结果</returns>
        public ApiResponse SaveTemplateData(TemplateInfo tempInfoModel, string xmlFileServicePath)
        {
            TemplateSave tsModel = new TemplateSave()
            {
                CSID = ScanGlobalInfo.ExamInfo.CsID
                ,
                AnswerSheetXmlPath = xmlFileServicePath,
                TemplateInfo = tempInfoModel
            };

            return _dalFactory.TamplateInfo_Save(tsModel);
        }

        /// <summary>
        /// 获取模板制作时需要的题类型
        /// </summary>
        /// <returns></returns>
        public QuestionTypeResponse GetTemplateQuestionType()
        {
            return _dalFactory.Tamplate_Question_Type_Get();
        }

        /// <summary>
        /// 保存原卷信息到数据库
        /// </summary>
        /// <param name="fileNames">原卷的文件名，多个用‘,’分隔</param>
        /// <returns>保存结果</returns>
        public ApiResponse Materials_SaveExamPaperPicPath(string fileNames)
        {
            return _dalFactory.Materials_SaveExamPaperPicPath(ScanGlobalInfo.ExamInfo.CsID, fileNames);
        }


        /// <summary>
        /// 保存标准答案信息到数据库
        /// </summary>
        /// <param name="fileNames">标准答案的文件名，多个用‘,’分隔</param>
        /// <returns>保存结果</returns>
        public ApiResponse Materials_SaveExapQAPicPath(string fileNames)
        {
            return _dalFactory.Materials_SaveExapQAPicPath(ScanGlobalInfo.ExamInfo.CsID, fileNames);
        }
    }
}
