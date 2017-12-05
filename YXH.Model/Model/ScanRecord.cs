using System;

namespace YXH.Model
{
    /// <summary>
    /// 扫描记录
    /// </summary>
    [Serializable]
    public class ScanRecord
    {
        /// <summary>
        /// 考试ID
        /// </summary>
        public long ExamId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int EsId { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public string Classid { get; set; }
        /// <summary>
        /// 扫描时间
        /// </summary>
        public DateTime ScanTime { get; set; }
        /// <summary>
        /// 批次编号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 文件组
        /// </summary>
        public string Files { get; set; }
        /// <summary>
        /// 识别标记信息
        /// </summary>
        public string OmrStr { get; set; }
        /// <summary>
        /// 准考证号
        /// </summary>
        public string Zkzh { get; set; }
        /// <summary>
        /// 卷标状态
        /// </summary>
        public string VolumnStatus { get; set; }
        /// <summary>
        /// 唯一编码GUID
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 识别信息2
        /// </summary>
        public string OmrStr2 { get; set; }
        /// <summary>
        /// 记录板源标记
        /// </summary>
        public string Zkzh_origin { get; set; }
        /// <summary>
        /// 卷标状态源标记
        /// </summary>
        public string VolumnStatus_origin { get; set; }
        /// <summary>
        /// 扫描编码
        /// </summary>
        public string ScanID { get; set; }
        /// <summary>
        /// 移出部分
        /// </summary>
        public int cliped { get; set; }
        /// <summary>
        /// 是否重新扫描
        /// </summary>
        public bool rescanned { get; set; }
        /// <summary>
        /// 是否修改的
        /// </summary>
        public bool modified { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否双面
        /// </summary>
        public bool IsB { get; set; }
        /// <summary>
        /// 是否快速扫描
        /// </summary>
        public bool Isqk { get; set; }
        /// <summary>
        /// 是否手动选择文件
        /// </summary>
        public string ManualOpFlag { get; set; }
        /// <summary>
        /// 批次ID
        /// </summary>
        public int BatchID { get; set; }
        /// <summary>
        /// 批次索引
        /// </summary>
        public int BatchIndex { get; set; }
    }
}
