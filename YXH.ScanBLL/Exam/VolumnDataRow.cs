using System.Collections.Generic;
using YXH.Enum;
using YXH.Model;
using System.Linq;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 卷标数据行
    /// </summary>
    public class VolumnDataRow
    {
        /// <summary>
        /// 刷新控制文本委托定义
        /// </summary>
        public delegate void RefreshControlText();
        /// <summary>
        /// 刷新卷标文本委托
        /// </summary>
        public VolumnDataRow.RefreshControlText RefreshVoulumText;
        /// <summary>
        /// 试卷纸张
        /// </summary>
        private ExaminationPaper _data;
        /// <summary>
        /// 错误状态列表
        /// </summary>
        private List<ErrorStatus> _ErrorStatus;
        /// <summary>
        /// 状态合并字符串
        /// </summary>
        private string _StatusConcatString;
        /// <summary>
        /// 试卷纸张数据
        /// </summary>
        public ExaminationPaper Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;

                this.RefreshText();
            }
        }

        /// <summary>
        /// 试卷已处理的错误
        /// </summary>
        public List<ErrorStatus> HistoryErrorStatusList { get; set; }
        /// <summary>
        /// 错误状态列表
        /// </summary>
        public List<ErrorStatus> ErrorStatusList
        {
            get
            {
                if (this._ErrorStatus == null)
                {
                    this._ErrorStatus = new List<ErrorStatus>();
                }

                return this._ErrorStatus;
            }
            set
            {
                this._ErrorStatus = value;
            }
        }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName
        {
            get
            {
                return this.Data.StudentName;
            }
        }
        /// <summary>
        /// 准号证号
        /// </summary>
        public string Zkzh
        {
            get
            {
                return this.Data.Zkzh;
            }
            set
            {
                this.Data.Zkzh = value;

                this.RefreshText();
            }
        }
        /// <summary>
        /// 状态合并字符串
        /// </summary>
        public string StatusConcatString
        {
            get
            {
                return this._StatusConcatString;
            }
            set
            {
                this._StatusConcatString = value;
            }
        }

        /// <summary>
        /// 刷新文本
        /// </summary>
        public void RefreshText()
        {
            string text = string.Empty;

            for (int i = 0; i < this.Data.Status.Count<VolumeStatus>(); i++)
            {
                text += (int)this.Data.Status[i];

                if (i < this.Data.Status.Count<VolumeStatus>() - 1)
                {
                    text += ",";
                }
            }

            text = "[" + text + "]";
            text = text.Replace("0", "已上传").Replace("1", "正常").Replace("2", "考号不可识别").Replace("3", "重号").Replace("4", "错号").Replace("5", "页不可定位").Replace("6", "缺页").Replace("7", "客观题存疑").Replace("8", "后台处理客观题存疑").Replace("9", "重叠卷").Replace("10", "原图加载失败");

            string arg_11C_0 = string.Empty;

            if (ScanGlobalInfo.ScanMode == ScanMode.Room && !string.IsNullOrEmpty(this.Data.Room))
            {
                arg_11C_0 = "[" + this.Data.Room + "]";
            }

            this._StatusConcatString = text;

            string nodeName = string.Format(" {0,-8}{1,-13}{2,-10}", text, this.Data.Zkzh, this.Data.StudentName);

            this.NodeName = nodeName;

            if (this.RefreshVoulumText != null)
            {
                this.RefreshVoulumText();
            }
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns>NodeName字符串</returns>
        public override string ToString()
        {
            base.ToString();
            return this.NodeName;
        }
    }
}
