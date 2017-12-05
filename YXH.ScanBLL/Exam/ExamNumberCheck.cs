using System;
using System.Collections.Generic;
using YXH.Common;
using YXH.Common.OuterInterop;
using YXH.Enum;
using YXH.Model;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 考试编号检查
    /// </summary>
    public class ExamNumberCheck : PaperScan
    {
        /// <summary>
        /// 当前字典
        /// </summary>
        private Dictionary<int, List<VolumnDataRow>> _correctDic;
        /// <summary>
        /// 异常字典
        /// </summary>
        private Dictionary<int, List<VolumnDataRow>> _myIncorrectDic;
        /// <summary>
        /// 卷状态
        /// </summary>
        public override VolumeStatus VolumeStatus
        {
            get
            {
                return this.volumeStatus;
            }
            set
            {
                this.volumeStatus = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="currentExamPaper">当前试卷</param>
        /// <param name="templateInfo">模板信息</param>
        /// <param name="correctDic">正常试卷字典</param>
        /// <param name="myIncorrectDic">异常试卷字典</param>
        public ExamNumberCheck(CurrentExamPaper currentExamPaper, TemplateInfo templateInfo, Dictionary<int, List<VolumnDataRow>> correctDic, Dictionary<int, List<VolumnDataRow>> myIncorrectDic)
        {
            base.CurrentExamPaper = currentExamPaper;
            base.TemplateInfo = templateInfo;
            this._correctDic = correctDic;
            this._myIncorrectDic = myIncorrectDic;
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        public override void DoScan()
        {
            string text = string.Empty;

            if (base.TemplateInfo.pages[0].SchoolNumType == SchoolNumberType.BarCcode && base.TemplateInfo.pages[0].BarCodeSchoolNumBlob != null)
            {
                Rectangle region = default(Rectangle);
                bool isHorizontal = base.TemplateInfo.pages[0].BarCodeSchoolNumBlob.isHorizontal;
                CvRect region2 = base.TemplateInfo.pages[0].BarCodeSchoolNumBlob.region;

                region.X = region2.x;
                region.Y = region2.y;
                region.Height = region2.height;
                region.Width = region2.width;

                string filename = PathHelper.LocalVolumneImgDir + base.CurrentExamPaper.VolumnDataRow.Data.ImagePath[0];

                text = ZxingBarCodeHelper.Instance.ReadBarCode(filename, region, isHorizontal);

                if (string.IsNullOrEmpty(text))
                {
                    text = AsposeBarCodeHelper.Instance.ReadBarCode(filename, region, isHorizontal);
                }

                text = this.RemoveNotNumber(text, ScanGlobalInfo.IsIgnoreBarcodePrexZero);
            }
            else if (base.TemplateInfo.pages[0].SchoolNumType == SchoolNumberType.QR && base.TemplateInfo.pages[0].QRSchoolNumBlob != null)
            {
                Rectangle region3 = default(Rectangle);
                CvRect region4 = base.TemplateInfo.pages[0].QRSchoolNumBlob.region;

                region3.X = region4.x;
                region3.Y = region4.y;
                region3.Height = region4.height;
                region3.Width = region4.width;

                string filename2 = PathHelper.LocalVolumneImgDir + base.CurrentExamPaper.VolumnDataRow.Data.ImagePath[0];

                text = ZxingBarCodeHelper.Instance.ReadQRCode(filename2, region3);
                text = this.RemoveNotNumber(text, ScanGlobalInfo.IsIgnoreBarcodePrexZero);
            }
            else
            {
                IntPtr ptr = ScanlibInterop.RecognizeStudentID(base.CurrentExamPaper.Scanner, base.TemplateInfo.pages[0].OmrSchoolNumBlob.OmrSchoolNumberString, 0);

                text = Marshal.PtrToStringAnsi(ptr);

                if (!string.IsNullOrEmpty(text))
                {
                    text = ScanResultHelper.ConvertScanResultToOmrString(text, false).Replace(",", "");
                }
            }

            bool flag = false;

            if (string.IsNullOrEmpty(text))
            {
                this.VolumeStatus = VolumeStatus.ErrZkzh;
                base.CurrentExamPaper.IsOK = false;

                base.CurrentExamPaper.VolumnDataRow.Data.Status.Add(this.VolumeStatus);

                text = "";
                flag = true;
            }
            else if (text.Contains("-") || text.Contains("?"))
            {
                this.VolumeStatus = VolumeStatus.Ambiguous;
                base.CurrentExamPaper.IsOK = false;

                base.CurrentExamPaper.VolumnDataRow.Data.Status.Add(this.VolumeStatus);

                flag = true;
            }
            else if (this.CheckZkzhDuplicate(text))
            {
                this.VolumeStatus = VolumeStatus.Duplicate;
                base.CurrentExamPaper.IsOK = false;

                base.CurrentExamPaper.VolumnDataRow.Data.Status.Add(this.VolumeStatus);

                flag = true;
            }
            if (flag)
            {
                string key = "0_" + 1;

                if (!base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints.ContainsKey(key))
                {
                    base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints.Add(key, new List<int>());
                }

                base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints[key].Add(0);
            }

            base.CurrentExamPaper.VolumnDataRow.Data.Zkzh = text;
            base.CurrentExamPaper.VolumnDataRow.Data.Zkzh_origin = text;
        }

        /// <summary>
        /// 检查准考证号是否重复
        /// </summary>
        /// <param name="scannedZkzh">扫描到的准考证号</param>
        /// <returns>重复状态</returns>
        private bool CheckZkzhDuplicate(string scannedZkzh)
        {
            bool result = false;

            foreach (int current in this._correctDic.Keys)
            {
                List<VolumnDataRow> correctPaper = this._correctDic[current];
                List<VolumnDataRow> list = (from r in correctPaper
                                            where r.Zkzh.Equals(scannedZkzh)
                                            select r).ToList<VolumnDataRow>();

                if (list.Count > 0)
                {
                    result = true;
                }

                list.ForEach(delegate(VolumnDataRow i)
                {
                    correctPaper.Remove(i);

                    i.ErrorStatusList = new List<ErrorStatus>
					{
						ErrorStatus.StudentInfoError
					};
                    i.Data.Status = new List<VolumeStatus>
					{
						VolumeStatus.Duplicate
					};

                    ScanRecordHelper.Instance.UpdateScanRecordStatus(i.Data);
                });

                this._myIncorrectDic[current].AddRange(list);
            }

            foreach (int current2 in this._myIncorrectDic.Keys)
            {
                List<VolumnDataRow> source = this._myIncorrectDic[current2];
                List<VolumnDataRow> list2 = (from r in source
                                             where r.Zkzh.Equals(scannedZkzh)
                                             select r).ToList<VolumnDataRow>();

                if (list2.Count > 0)
                {
                    result = true;
                }

                list2.ForEach(delegate(VolumnDataRow i)
                {
                    if (!i.Data.Status.Contains(VolumeStatus.Duplicate))
                    {
                        i.Data.Status.Add(VolumeStatus.Duplicate);
                    }
                    if (!i.ErrorStatusList.Contains(ErrorStatus.StudentInfoError))
                    {
                        i.ErrorStatusList.Add(ErrorStatus.StudentInfoError);
                    }

                    ScanRecordHelper.Instance.UpdateScanRecordStatus(i.Data);
                });
            }

            return result;
        }

        /// <summary>
        /// 移除非数字的字符
        /// </summary>
        /// <param name="key">需要检查的对象</param>
        /// <param name="isIgnorePrexZero">是否忽略0</param>
        /// <returns>处理后的字符</returns>
        private string RemoveNotNumber(string key, bool isIgnorePrexZero = false)
        {
            if (!string.IsNullOrEmpty(key))
            {
                key = Regex.Replace(key, "[^\\d]*", "");
            }
            else
            {
                key = "";
            }
            if (isIgnorePrexZero)
            {
                key = key.Trim().TrimStart(new char[]
				{
					'0'
				});
            }

            return key;
        }
    }
}
