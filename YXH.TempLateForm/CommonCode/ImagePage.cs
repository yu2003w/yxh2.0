using System.Collections.Generic;
using System.Drawing;
using YXH.Enum;
using YXH.Model;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 图片分页处理
    /// </summary>
    public class ImagePage
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int pageIndex;
        /// <summary>
        /// 框选区域矩形
        /// </summary>
        public ResizableRectangle activeRect;
        /// <summary>
        /// 修改对象
        /// </summary>
        public object modifyObject;
        /// <summary>
        /// 题号集合
        /// </summary>
        public List<KeyValue<int, Point>> numList = new List<KeyValue<int, Point>>();
        /// <summary>
        /// 斑点列表
        /// </summary>
        public List<CvRect> blobList = new List<CvRect>();
        /// <summary>
        /// 编辑模板数组
        /// </summary>
        public OmrArray _EditTemplate;
        /// <summary>
        /// 学号类型
        /// </summary>
        public SchoolNumberType temSchoolNumType;
        /// <summary>
        /// 识别的学校编号
        /// </summary>
        public OmrSchoolNumber temSchoolomrList;
        /// <summary>
        /// 条码考号
        /// </summary>
        public BarCodeSchoolNumber temBarcode;
        /// <summary>
        /// 二维码考号
        /// </summary>
        public QRSchoolNumber temQr;
    }
}
