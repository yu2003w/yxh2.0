using System.Collections.Generic;
using YXH.Common.OuterInterop;
using YXH.Enum;
using YXH.Model;

namespace YXH.ScanBLL
{
    public class TitleCheck : PaperScan
    {
        /// <summary>
        /// 卷状态
        /// </summary>
        public override VolumeStatus VolumeStatus
        {
            get
            {
                return VolumeStatus.ErrorPage;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="currentExamPaper">当前试卷信息</param>
        /// <param name="templateInfo">模板信息</param>
        public TitleCheck(CurrentExamPaper currentExamPaper, TemplateInfo templateInfo)
        {
            base.CurrentExamPaper = currentExamPaper;
            base.TemplateInfo = templateInfo;
        }

        /// <summary>
        /// 开始扫描
        /// </summary>
        public override void DoScan()
        {
            if (!ScanlibInterop.MatchTitle(base.CurrentExamPaper.Scanner))
            {
                base.CurrentExamPaper.IsOK = false;

                base.CurrentExamPaper.VolumnDataRow.Data.Status.Add(this.VolumeStatus);

                string key = "0_" + 0;

                if (!base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints.ContainsKey(key))
                {
                    base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints.Add(key, new List<int>());
                }

                base.CurrentExamPaper.VolumnDataRow.Data.ErrorMarkPoints[key].Add(0);
            }
        }
    }
}
