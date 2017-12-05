using System;

namespace MGY.Model
{
    /// <summary>
    /// 在线保存的模板信息
    /// </summary>
    [Serializable]
    public class YXTemplateInfo
    {
        /// <summary>
        /// 标准答案图片名称,多个用‘,’分隔
        /// </summary>
        public string ExamQAPicPath { get; set; }
        /// <summary>
        /// 试卷原卷图片名称，多个用‘,’分隔
        /// </summary>
        public string ExamPaperPicPath { get; set; }
        /// <summary>
        /// 试卷答题卡原图 ,多张图片用","分隔
        /// </summary>
        public string AnswerSheetPicPath { get; set; }
        /// <summary>
        /// 试卷答题卡xml模版地址
        /// </summary>
        public string AnswerSheetXMLPath { get; set; }
        /// <summary>
        /// 试卷答题卡xml模版,json格式存储 
        /// </summary>
        public string AnswerSheetXML { get; set; }
        /// <summary>
        /// 模板保存的数据库主键ID
        /// </summary>
        public int id { get; set; }
    }
}
