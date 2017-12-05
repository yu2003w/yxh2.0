using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using YXH.Common;
using YXH.Model;
using System.Linq;
using Microsoft.International.Converters.PinYinConverter;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 学生考试信息处理
    /// </summary>
    public partial class BaseDisposeBLL
    {
        /// <summary>
        /// 显示处理内部类
        /// </summary>
        private class DisplayClass
        {
            /// <summary>
            /// 学生姓名
            /// </summary>
            public List<string> name { get; set; }
            /// <summary>
            /// 姓名拼音对称列表
            /// </summary>
            public List<List<char>> pinyins { get; set; }
            /// <summary>
            /// 处理到的字符位置
            /// </summary>
            public int i { get; set; }
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <returns>学生信息列表</returns>
        public StudentExamInfoResponse StudentExamInfo_GetList()
        {
            StudentExamInfoResponse seiResponse = _dalFactory.Student_GetExamInfosByEgidAndGradeCode(ScanGlobalInfo.ExamGroup.Id, ScanGlobalInfo.ExamInfo.GradeCode);

            if (seiResponse.Success)
            {
                if (seiResponse.Data != null)
                {
                    foreach (StudentExamInfo seiModel in seiResponse.Data)
                    {
                        List<List<char>> stuNameCharPinYinList = new List<List<char>>();
                        List<string> stuNamePinYinList = new List<string>();

                        try
                        {
                            string strName = seiModel.StuName.ToString().Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(" ", "");

                            for (int j = 0; j < strName.Length; j++)
                            {
                                ChineseChar chineseChar = new ChineseChar(strName.ToString()[j]);
                                ReadOnlyCollection<string> pinyins = chineseChar.Pinyins;
                                List<char> stuNameCharFastPinYinCharList = new List<char>();

                                foreach (string stuNameCharPinYin in pinyins)
                                {
                                    if (!string.IsNullOrEmpty(stuNameCharPinYin) && !stuNameCharFastPinYinCharList.Contains(stuNameCharPinYin[0]))
                                    {
                                        stuNameCharFastPinYinCharList.Add(stuNameCharPinYin[0]);
                                    }
                                }

                                stuNameCharPinYinList.Add(stuNameCharFastPinYinCharList);
                            }

                            this.DiguiPinyin(stuNamePinYinList, stuNameCharPinYinList, 0);

                            seiModel.StudentNamePinYin = string.Join(",", stuNamePinYinList.ToArray());
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteFatalLog(ex.Message, ex);

                            seiModel.StudentNamePinYin = "000";
                        }
                    }
                }
            }

            seiResponse.Data = (from i in seiResponse.Data
                                  orderby i.StudentNamePinYin
                                  select i).ToList<StudentExamInfo>();

            return seiResponse;
        }

        /// <summary>
        /// 递归处理拼音
        /// </summary>
        /// <param name="name">学生姓名列表</param>
        /// <param name="pinyins">堆成拼音列表</param>
        /// <param name="i">执行次数</param>
        private void DiguiPinyin(List<string> name, List<List<char>> pinyins, int i)
        {
            DisplayClass dc = new DisplayClass();

            dc.name = name;
            dc.pinyins = pinyins;
            dc.i = i;

            if (dc.i == 0)
            {
                for (int k = 0; k < dc.pinyins[0].Count; k++)
                {
                    if (!dc.name.Contains(dc.pinyins[0][k].ToString()))
                    {
                        dc.name.Add(dc.pinyins[0][k].ToString());
                        if (dc.pinyins.Count > 1)
                        {
                            this.DiguiPinyin(dc.name, dc.pinyins, 1);
                        }
                    }
                }
                return;
            }
            int j;
            for (j = 0; j < dc.pinyins[dc.i].Count; j++)
            {
                dc.name.ForEach(delegate(string P)
                {
                    if (P.Length == dc.i)
                    {
                        P += dc.pinyins[dc.i][j].ToString();
                        if (!dc.name.Contains(P))
                        {
                            dc.name.Add(P);
                        }
                    }
                });
            }
            dc.name.RemoveAll((string P) => P.Length == dc.i);
            if (dc.pinyins.Count > dc.i + 1)
            {
                this.DiguiPinyin(dc.name, dc.pinyins, dc.i + 1);
            }
        }
    }
}
