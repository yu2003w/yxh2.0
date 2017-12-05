using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YXH.Model
{
    public class TemplateSave
    {
        /// <summary>
        /// 考试科目ID
        /// </summary>
        public int CSID { get; set; }

        /// <summary>
        /// 模板文件的xml文件名称
        /// </summary>
        public string AnswerSheetXmlPath { get; set; }

        public TemplateInfo TemplateInfo { get; set; }
    }
}
