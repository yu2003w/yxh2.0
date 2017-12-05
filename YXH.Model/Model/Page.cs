using System;
using System.Collections.Generic;
using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 页数据
    /// </summary>
    [Serializable]
    public class Page
    {
        /// <summary>
        /// 页索引
        /// </summary>
        public int pageIndex;
        /// <summary>
        /// 识别类型
        /// </summary>
        public OmrType omrType;
        /// <summary>
        /// 页大小
        /// </summary>
        public PageSize Size;
        /// <summary>
        /// 文件名
        /// </summary>
        public string fileName;
        /// <summary>
        /// 本地标题区域
        /// </summary>
        public TitleLocal localRegion;
        /// <summary>
        /// 考号类型
        /// </summary>
        public SchoolNumberType SchoolNumType;
        /// <summary>
        /// 考号斑点
        /// </summary>
        public OmrSchoolNumber OmrSchoolNumBlob;
        /// <summary>
        /// 二维码考号斑点
        /// </summary>
        public QRSchoolNumber QRSchoolNumBlob;
        /// <summary>
        /// 条形码考号斑点
        /// </summary>
        public BarCodeSchoolNumber BarCodeSchoolNumBlob;
        /// <summary>
        /// 客观题组
        /// </summary>
        public OmrObjective[] OmrObjectives;
        /// <summary>
        /// 主观题列表
        /// </summary>
        public List<OmrSubjective> OmrSubjectiveList;
        /// <summary>
        /// 隐藏区域
        /// </summary>
        public List<HideArea> HideAreaList ;
    }
}
