using System;
using System.Collections.Generic;
using YXH.Common.OuterInterop;
using YXH.Enum;
using YXH.Model;
using System.Linq;
using System.Runtime.InteropServices;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 答案检查
    /// </summary>
    public class AnswerCheck : PaperScan
    {
        /// <summary>
        /// 分页信息
        /// </summary>
        private Page[] _pages;

        /// <summary>
        /// 卷状态
        /// </summary>
        public override VolumeStatus VolumeStatus
        {
            get
            {
                return VolumeStatus.ErrOmr;
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
        /// <param name="pages">分页信息</param>
        public AnswerCheck(CurrentExamPaper currentExamPaper, Page[] pages)
        {
            base.CurrentExamPaper = currentExamPaper;
            this._pages = pages;
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        public override void DoScan()
        {
            List<OmrItem> list = new List<OmrItem>();

            for (int i = 0; i < this._pages.Length; i++)
            {
                if (this._pages[i].OmrObjectives != null)
                {
                    for (int j = 0; j < this._pages[i].OmrObjectives.Length; j++)
                    {
                        string omrObjectiveString = this._pages[i].OmrObjectives[j].OmrObjectiveString;
                        IntPtr ptr = ScanlibInterop.Recognize(base.CurrentExamPaper.Scanner, omrObjectiveString, this._pages[i].pageIndex);
                        string scanResult = Marshal.PtrToStringAnsi(ptr);
                        List<OmrItem> omrItemList = new List<OmrItem>();

                        omrItemList = ScanResultHelper.ConvertOmrScanResultToOmrItemList(scanResult, this._pages[i].OmrObjectives[j].objectiveItems);

                        if (omrItemList.Exists((OmrItem p) => p.type != OmrValueType.Confirm))
                        {
                            base.CurrentExamPaper.IsOK = false;

                            if (!base.CurrentExamPaper.VolumnDataRow.Data.Status.Contains(this.VolumeStatus))
                            {
                                base.CurrentExamPaper.VolumnDataRow.Data.Status.Add(this.VolumeStatus);
                            }

                            string key = i + "_" + 2;

                            if (!base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints.ContainsKey(key))
                            {
                                base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints.Add(key, new List<int>());
                            }

                            base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints[key].Add(j);
                        }

                        for (int k = 0; k < omrItemList.Count; k++)
                        {
                            list.Add(omrItemList[k]);
                        }
                    }
                }
            }

            string text = "";

            list = (from p in list
                    orderby p.ObjectiveID
                    select p).ToList<OmrItem>();

            foreach (OmrItem current in list)
            {
                text += current.Answer.ToString().Trim();
                text += ",";
            }

            text = text.TrimEnd(new char[]
			{
				','
			});
            base.CurrentExamPaper.VolumnDataRow.Data.Omr = text;
            base.CurrentExamPaper.VolumnDataRow.Data.Omrs = base.CurrentExamPaper.VolumnDataRow.Data.Omr.Split(new char[]
			{
				',',
				';',
				'|'
			});
            base.CurrentExamPaper.VolumnDataRow.Data.OmrItemList = list;
            bool enable = false;

            if (ScanGlobalInfo.omrErrorStrategy == OmrErrorStrategy.AutoSetToNormal)
            {
                enable = true;
            }
            if (this.IsSetToNormalAutomatically(list, enable))
            {
                if (base.CurrentExamPaper.VolumnDataRow.Data.Status.Contains(this.VolumeStatus))
                {
                    base.CurrentExamPaper.VolumnDataRow.Data.Status.Remove(this.VolumeStatus);
                }
                if (base.CurrentExamPaper.VolumnDataRow.Data.Status.Count == 0)
                {
                    base.CurrentExamPaper.IsOK = true;
                }
            }
        }

        /// <summary>
        /// 是否自动设置正确答案
        /// </summary>
        /// <param name="answerList">答案列表</param>
        /// <param name="enable">许可状态</param>
        /// <returns>设置结果</returns>
        private bool IsSetToNormalAutomatically(List<OmrItem> answerList, bool enable = true)
        {
            if (answerList != null && enable)
            {
                List<OmrItem> list = answerList.FindAll((OmrItem p) => p.type == OmrValueType.Confirm).ToList<OmrItem>(),
                    list2 = answerList.FindAll((OmrItem p) => p.type == OmrValueType.NotConfirm).ToList<OmrItem>(),
                    list3 = answerList.FindAll((OmrItem p) => p.type == OmrValueType.Empty).ToList<OmrItem>();

                if (list2 != null && list2.Count != 0)
                {
                    return false;
                }
                if (list == null || list.Count == 0)
                {
                    return false;
                }
                if (list3 != null && list3.Count <= 5 && (double)list3.Count <= (double)answerList.Count * 0.2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
