using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using YXH.Enum;
using YXH.Model;

namespace YXH.ScanBLL
{
    public static class ScanResultHelper
    {
        /// <summary>
        /// 样品验证
        /// </summary>
        private static string patternToValidate = "(1,)";
        /// <summary>
        /// 样品匹配
        /// </summary>
        private static string patternToMatch = "(2,)";

        /// <summary>
        /// 转化当前扫描结果到omr字符串
        /// </summary>
        /// <param name="scanResult">扫描结果</param>
        /// <param name="isLetter">是否为字母</param>
        /// <returns>转换结果</returns>
        public static string ConvertScanResultToOmrString(string scanResult, bool isLetter)
        {
            string arg_05_0 = string.Empty;

            scanResult = scanResult.Replace(';', ',');
            scanResult = scanResult.TrimStart(new char[]
			{
				'['
			}).TrimEnd(new char[]
			{
				']'
			});

            string[] separator = new string[]
            {
				"]["
			},
            array = scanResult.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Regex regex = new Regex(ScanResultHelper.patternToValidate);
            Regex regex2 = new Regex(ScanResultHelper.patternToMatch);
            StringBuilder stringBuilder = new StringBuilder();
            string[] array2 = array;

            for (int i = 0; i < array2.Length; i++)
            {
                string input = array2[i];

                if (regex2.Match(input).Success)
                {
                    MatchCollection matchCollection = regex2.Matches(input);

                    foreach (Match match in matchCollection)
                    {
                        if (isLetter)
                        {
                            stringBuilder.Append((char)(match.Index / 2 % 26 + 65));
                        }
                        else
                        {
                            if (matchCollection.Count != 1)
                            {
                                stringBuilder.Append("-");

                                break;
                            }

                            stringBuilder.Append(match.Index / 2);
                        }
                    }

                    stringBuilder.Append(",");
                }
                else
                {
                    if (regex.Match(input).Success)
                    {
                        MatchCollection matchCollection2 = regex.Matches(input);
                        IEnumerator enumerator2 = matchCollection2.GetEnumerator();

                        while (enumerator2.MoveNext())
                        {
                            Match match2 = (Match)enumerator2.Current;

                            if (!isLetter)
                            {
                                if (matchCollection2.Count != 1)
                                {
                                    stringBuilder.Append("-");

                                    break;
                                }

                                stringBuilder.Append(match2.Index / 2);
                            }
                        }

                        goto IL_1C9;
                    }

                    stringBuilder.Append("-,");
                }

            IL_1C9: ;
            }

            return stringBuilder.ToString().TrimEnd(new char[]
			{
				','
			});
        }

        /// <summary>
        /// 转化Omr扫描结果到Omr项目列表
        /// </summary>
        /// <param name="scanResult">扫描结果</param>
        /// <param name="curOmrObjItem">客观题对象数组</param>
        /// <returns>Omr对象列表</returns>
        public static List<OmrItem> ConvertOmrScanResultToOmrItemList(string scanResult, OmrObjectiveItem[] curOmrObjItem)
        {
            List<OmrItem> list = new List<OmrItem>();

            foreach (OmrObjectiveItem current in from n in curOmrObjItem
                                                 orderby n.num
                                                 select n)
            {
                list.Add(new OmrItem
                {
                    ObjectiveID = current.num.number,
                    Answer = "-",
                    type = OmrValueType.Empty
                });
            }

            list = (from i in list
                    orderby i.ObjectiveID
                    select i).ToList<OmrItem>();

            if (!string.IsNullOrEmpty(scanResult))
            {
                string arg_BA_0 = string.Empty;

                scanResult = scanResult.Replace(';', ',');
                scanResult = scanResult.TrimStart(new char[]
				{
					'['
				}).TrimEnd(new char[]
				{
					']'
				});

                string[] separator = new string[]
				{
					"]["
				},
                array = scanResult.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                Regex regex = new Regex(ScanResultHelper.patternToValidate);
                Regex regex2 = new Regex(ScanResultHelper.patternToMatch);

                for (int j = 0; j < array.Length; j++)
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    if (regex2.Match(array[j]).Success)
                    {
                        MatchCollection matchCollection = regex2.Matches(array[j]);

                        foreach (Match match in matchCollection)
                        {
                            stringBuilder.Append((char)(match.Index / 2 % 26 + 65));
                        }

                        list[j].type = OmrValueType.Confirm;
                        list[j].Answer = stringBuilder.ToString();
                    }
                    else if (regex.Match(array[j]).Success)
                    {
                        MatchCollection matchCollection2 = regex.Matches(array[j]);

                        foreach (Match match2 in matchCollection2)
                        {
                            stringBuilder.Append((char)(match2.Index / 2 % 26 + 65));
                        }

                        list[j].type = OmrValueType.NotConfirm;
                        list[j].Answer = stringBuilder.ToString();
                    }
                }
            }

            return list;
        }
    }
}
