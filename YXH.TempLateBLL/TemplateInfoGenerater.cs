using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using YXH.Common.OuterInterop;
using YXH.Enum;
using YXH.Model;
using YXH.Common;

namespace YXH.TemplateBLL
{
    /// <summary>
    /// 模板信息处理
    /// </summary>
    public class TemplateInfoGenerater : IDisposable
    {
        /// <summary>
        /// 内部处理类
        /// </summary>
        public class DisplayClass
        {
            public List<CvRect> blobList { get; set; }
            public int thredhold { get; set; }
        }

        /// <summary>
        /// 客观题识别对象处理
        /// </summary>
        public class OmrProcessClass
        {
            public List<OmrObjectiveItem> omrList { get; set; }
        }

        public class CorrectClass
        {
            public TemplateInfoGenerater currentClass { get; set; }
            public int omrItemdistance { get; set; }
            public int blobarrange { get; set; }
            public int ocrarrange { get; set; }
            public List<OmrObjectiveItem> ocrerrorList { get; set; }
        }


        /// <summary>
        /// 声明当前实例
        /// </summary>
        private static TemplateInfoGenerater _instance;
        /// <summary>
        /// 旋转角度
        /// </summary>
        private double smallrotatedegree;
        /// <summary>
        /// 文件名称集合
        /// </summary>
        private string[] filename;
        /// <summary>
        /// 识别器实例
        /// </summary>
        private IntPtr recogInstance;
        /// <summary>
        /// 当前图片句柄
        /// </summary>
        private IntPtr[] CurrentImagePtr;
        /// <summary>
        /// 源图片句柄
        /// </summary>
        private IntPtr[] OriginImagePtr;
        /// <summary>
        /// 定义当前实例
        /// </summary>
        public static TemplateInfoGenerater Instance
        {
            get
            {
                if (TemplateInfoGenerater._instance == null)
                {
                    TemplateInfoGenerater._instance = new TemplateInfoGenerater();
                }

                return TemplateInfoGenerater._instance;
            }
        }


        /// <summary>
        /// 构造方法
        /// </summary>
        public TemplateInfoGenerater()
        {
            this.recogInstance = ScanlibInterop.CreateRecognizer();
        }

        /// <summary>
        /// 倾斜校正
        /// </summary>
        /// <param name="selectArea">选择的直线区域</param>
        /// <param name="CurrentPageIndex">当前页码</param>
        public void DeskewedImageByLine(CvRect selectArea, int CurrentPageIndex)
        {
            ScanlibInterop.DeskewedImageByLine(this.recogInstance, this.CurrentImagePtr[CurrentPageIndex], selectArea);
            ScanlibInterop.SaveImage(this.CurrentImagePtr[CurrentPageIndex], this.filename[CurrentPageIndex]);
        }

        /// <summary>
        /// 斑点分组
        /// </summary>
        /// <param name="rects">斑点组信息</param>
        /// <param name="sortorien">排序信息</param>
        /// <param name="threshold">临界值</param>
        /// <returns>含有斑点集合的集合</returns>
        private List<List<CvRect>> ClusterBlob(List<CvRect> rects, int sortorien, int threshold = 5)
        {
            List<List<CvRect>> list = new List<List<CvRect>>();

            using (List<CvRect>.Enumerator enumerator = rects.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    CvRect rect = enumerator.Current;
                    List<CvRect> list2 = list.Find(delegate(List<CvRect> P)
                    {
                        CvRect cvRect = P.Find((CvRect L) => this.CompareRetangleIsSameArray(rect, L, sortorien, threshold));
                        return cvRect.width > 0 && cvRect.height > 0;
                    });

                    if (list2 == null)
                    {
                        list2 = new List<CvRect>();

                        list.Add(list2);
                    }

                    list2.Add(rect);
                }
            }

            list.Sort(delegate(List<CvRect> one, List<CvRect> tow)
            {
                if (sortorien != 0)
                {
                    return one[0].x - tow[0].x;
                }

                return one[0].y - tow[0].y;
            });
            list.ForEach(delegate(List<CvRect> P)
            {
                P.Sort(delegate(CvRect one, CvRect tow)
                {
                    if (sortorien != 0)
                    {
                        return one.y - tow.y;
                    }

                    return one.x - tow.x;
                });
            });

            return list;
        }

        /// <summary>
        /// ocr信息组
        /// </summary>
        /// <param name="numList">题号列表</param>
        /// <param name="sortorien">排序信息</param>
        /// <param name="threshhold">临界值</param>
        /// <returns>具有键值对列表的列表</returns>
        private List<List<KeyValue<int, Point>>> ClusterOcr(List<KeyValue<int, Point>> numList, int sortorien, int threshhold)
        {
            List<List<KeyValue<int, Point>>> list = new List<List<KeyValue<int, Point>>>();

            for (int i = 0; i < numList.Count; i++)
            {
                List<KeyValue<int, Point>> list2 = null;

                foreach (List<KeyValue<int, Point>> current in list)
                {
                    if (current.Count > 0 && this.ComparenumIsSame(numList[i].Value, current[0].Value, sortorien, threshhold))
                    {
                        list2 = current;

                        list2.Add(numList[i]);

                        break;
                    }
                }

                if (list2 == null)
                {
                    list2 = new List<KeyValue<int, Point>>();

                    list.Add(list2);
                    list2.Add(numList[i]);
                }
            }

            list.Sort(delegate(List<KeyValue<int, Point>> one, List<KeyValue<int, Point>> tow)
            {
                if (sortorien != 0)
                {
                    return one[0].Value.X - tow[0].Value.X;
                }

                return one[0].Value.Y - tow[0].Value.Y;
            });
            list.ForEach(delegate(List<KeyValue<int, Point>> p)
            {
                p.Sort(delegate(KeyValue<int, Point> one, KeyValue<int, Point> tow)
                {
                    if (sortorien != 0)
                    {
                        return one.Value.Y - tow.Value.Y;
                    }

                    return one.Value.X - tow.Value.X;
                });
            });

            return list;
        }

        /// <summary>
        /// 检查客观题识别排列
        /// </summary>
        /// <param name="numList">题号列表</param>
        /// <param name="blobList">斑点列表</param>
        /// <returns>检查结果</returns>
        public int CheckObjectiveOmrArrange(List<KeyValue<int, Point>> numList, List<CvRect> blobList)
        {
            int arg_0C_0 = blobList[0].height;
            List<List<CvRect>> list = this.ClusterBlob(blobList, 0, 5);
            int height = list[0][0].height,
                arg_3C_0 = list[0][0].width;
            List<List<KeyValue<int, Point>>> list2 = this.ClusterOcr(numList, 0, (int)((double)height * 0.6));
            List<KeyValue<int, Point>> list3 = list2[0];
            int y = list3[0].Value.Y;
            List<CvRect> list4 = list[0];
            int num = 2147483647;

            for (int i = 0; i < list.Count; i++)
            {
                int num2 = Math.Abs(list[i][0].y - y);

                if (num2 < num)
                {
                    list4 = list[i];
                    num = num2;
                }
            }

            int num3 = list3[0].Value.Y - 1,
                num4 = list3[0].Value.Y + height + 1;

            if ((num3 <= list4[0].y && list4[0].y <= num4) || (num3 <= list4[0].y + list4[0].height && list4[0].y + list4[0].height <= num4))
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// 检查斑点项大小
        /// </summary>
        /// <param name="blobList">斑点列表</param>
        /// <param name="thredhold">临界值</param>
        /// <returns>处理后的斑点</returns>
        public CvRect CheckBlobItemSize(List<CvRect> blobList, int thredhold = 3)
        {
            TemplateInfoGenerater.DisplayClass displayClass = new TemplateInfoGenerater.DisplayClass();

            displayClass.blobList = blobList;
            displayClass.thredhold = thredhold;

            List<KeyValue<CvRect, int>> list = new List<KeyValue<CvRect, int>>();

            for (int i = 0; i < displayClass.blobList.Count; i++)
            {
                KeyValue<CvRect, int> keyValue = list.Find(delegate(KeyValue<CvRect, int> P)
                {
                    int num = Math.Abs(P.Key.width - displayClass.blobList[i].width);
                    int num2 = Math.Abs(P.Key.height - displayClass.blobList[i].height);
                    return num <= displayClass.thredhold && num2 <= displayClass.thredhold;
                });

                if (keyValue == null)
                {
                    list.Add(new KeyValue<CvRect, int>(displayClass.blobList[i], 1));
                }
                else
                {
                    keyValue.Value++;
                }
            }

            KeyValue<CvRect, int> keyValue2 = list[0];

            for (int j = 1; j < list.Count; j++)
            {
                if (keyValue2.Value < list[j].Value)
                {
                    keyValue2 = list[j];
                }
            }

            return keyValue2.Key;
        }

        /// <summary>
        /// 检查识别内容/斑点间距
        /// </summary>
        /// <param name="numList">题号列表</param>
        /// <param name="blobList">斑点列表</param>
        /// <param name="sortorien">排序编号</param>
        /// <param name="threshhold">临界值</param>
        /// <returns>间距值</returns>
        public int CheckOcrBlobDistance(List<KeyValue<int, Point>> numList, List<CvRect> blobList, int sortorien, int threshhold = 3)
        {
            List<KeyValue<int, int>> list = new List<KeyValue<int, int>>();

            for (int i = 0; i < numList.Count; i++)
            {
                int num = -1,
                    num2 = -1;

                for (int j = 0; j < blobList.Count; j++)
                {
                    Point point = default(Point);

                    if (sortorien == 0)
                    {
                        point.Y = (blobList[j].y + blobList[j].y + blobList[j].height) / 2;
                        point.X = blobList[j].x;
                    }
                    else
                    {
                        point.X = (blobList[j].x + blobList[j].x + blobList[j].width) / 2;
                        point.Y = blobList[j].y;
                    }

                    int num3 = Math.Abs(numList[i].Value.X - point.X),
                        num4 = Math.Abs(numList[i].Value.Y - point.Y);

                    if (num == -1)
                    {
                        num = num3;
                    }
                    if (num2 == -1)
                    {
                        num2 = num4;
                    }
                    if (num + num2 > num3 + num4)
                    {
                        num = num3;
                        num2 = num4;
                    }
                }

                int comparevalue = (sortorien == 0) ? num : num2;
                KeyValue<int, int> keyValue = list.Find(delegate(KeyValue<int, int> P)
                {
                    int num5 = Math.Abs(comparevalue - P.Key);
                    return num5 < threshhold;
                });

                if (keyValue == null)
                {
                    list.Add(new KeyValue<int, int>(comparevalue, 1));
                }
                else
                {
                    keyValue.Value++;
                }
            }

            KeyValue<int, int> keyValue2 = list[0];

            for (int k = 1; k < list.Count; k++)
            {
                if (keyValue2.Value < list[k].Value)
                {
                    keyValue2 = list[k];
                }
            }

            return keyValue2.Key;
        }

        /// <summary>
        /// 检查斑点项间距
        /// </summary>
        /// <param name="blobList">斑点列表</param>
        /// <param name="sortorient">排序位置</param>
        /// <param name="thredhold">临界值</param>
        /// <returns>间距值</returns>
        public int CheckBlobItemDistance(List<CvRect> blobList, int sortorient, int thredhold = 3)
        {
            List<KeyValue<int, int>> list = new List<KeyValue<int, int>>();
            List<List<CvRect>> list2 = this.ClusterBlob(blobList, sortorient, 5);

            for (int i = 0; i < list2.Count; i++)
            {
                for (int j = 0; j < list2[i].Count - 1; j++)
                {
                    int xydistance = (sortorient == 0) ? (list2[i][j + 1].x - list2[i][j].x - list2[i][j].width) : (list2[i][j + 1].y - list2[i][j].y - list2[i][j].height);
                    KeyValue<int, int> keyValue = list.Find((KeyValue<int, int> P) => Math.Abs(xydistance - P.Key) <= thredhold);

                    if (keyValue == null)
                    {
                        list.Add(new KeyValue<int, int>(xydistance, 1));
                    }
                    else
                    {
                        keyValue.Value++;
                    }
                }
            }

            KeyValue<int, int> keyValue2 = list[0];

            for (int k = 1; k < list.Count; k++)
            {
                if (keyValue2.Value < list[k].Value)
                {
                    keyValue2 = list[k];
                }
            }

            return keyValue2.Key;
        }

        /// <summary>
        /// 比较两点是否重复（相同）
        /// </summary>
        /// <param name="one">点1</param>
        /// <param name="tow">点2</param>
        /// <param name="sortorien">排序信息</param>
        /// <param name="threshold">临界值</param>
        /// <returns>相同状态</returns>
        private bool ComparenumIsSame(Point one, Point tow, int sortorien, int threshold = 5)
        {
            int num = (sortorien == 0) ? Math.Abs(one.Y - tow.Y) : Math.Abs(one.X - tow.X);

            return num <= threshold;
        }

        /// <summary>
        /// 构造客观题识别列表
        /// </summary>
        /// <param name="ocrList">题号列表</param>
        /// <param name="blobList">斑点列表</param>
        /// <param name="sortorien">排序位置</param>
        /// <returns>客观题识别列表</returns>
        public List<OmrObjectiveItem> ComposeObjectiveOmrList(List<KeyValue<int, Point>> ocrList, List<CvRect> blobList, int sortorien)
        {
            TemplateInfoGenerater.OmrProcessClass displayClass = new TemplateInfoGenerater.OmrProcessClass();
            int num = (sortorien == 0) ? ((int)((double)blobList[0].height * 0.5)) : ((int)((double)blobList[0].width * 0.5)),
                num2 = (sortorien == 0) ? blobList[0].width : blobList[0].height;
            List<List<CvRect>> list = this.ClusterBlob(blobList, sortorien, num);
            List<List<KeyValue<int, Point>>> list2 = this.ClusterOcr(ocrList, sortorien, num);
            List<KeyValue<int, int>> list3 = new List<KeyValue<int, int>>();

            displayClass.omrList = new List<OmrObjectiveItem>();

            for (int i2 = 0; i2 < list2.Count; i2++)
            {
                int blobrow = -1,
                    num3 = 2147483647,
                    num4 = (sortorien == 0) ? list2[i2][0].Value.Y : list2[i2][0].Value.X,
                    num5 = 0,
                    num6 = 0;

                for (int j2 = 0; j2 < list.Count; j2++)
                {
                    num5 = ((sortorien == 0) ? list[j2][0].y : list[j2][0].x);
                    num6 = Math.Abs(num4 - num5);

                    if (num6 < num3)
                    {
                        num3 = num6;
                        blobrow = j2;
                    }
                }

                KeyValue<int, int> keyValue = list3.Find((KeyValue<int, int> P) => P.Key == blobrow);

                if (keyValue != null)
                {
                    int num7 = (sortorien == 0) ? list2[keyValue.Value][0].Value.Y : list2[keyValue.Value][0].Value.X,
                        num8 = Math.Abs(num7 - num5);

                    if (num8 > num6)
                    {
                        list3.Remove(keyValue);
                        list3.Add(new KeyValue<int, int>(blobrow, i2));
                    }
                }
                else
                {
                    list3.Add(new KeyValue<int, int>(blobrow, i2));
                }
            }
            for (int j = 0; j < list.Count; j++)
            {
                if (list3.Find((KeyValue<int, int> P) => P.Key == j) == null)
                {
                    list3.Add(new KeyValue<int, int>(j, -1));
                }
            }
            for (int k = 0; k < list3.Count; k++)
            {
                List<KeyValue<int, Point>> list4 = new List<KeyValue<int, Point>>();

                if (list3[k].Value != -1)
                {
                    list4 = list2[list3[k].Value];
                }

                List<CvRect> list5 = list[list3[k].Key];
                List<List<CvRect>> list6 = new List<List<CvRect>>();
                List<KeyValue<int, int>> split = new List<KeyValue<int, int>>();

                if (list5.Count >= 4)
                {
                    int num9 = (sortorien == 0) ? Math.Abs(list5[0].x - list5[1].x) : Math.Abs(list5[0].y - list5[1].y),
                        num10 = 0;

                    for (int l = 1; l < list5.Count - 1; l++)
                    {
                        num10++;

                        int num11 = (sortorien == 0) ? Math.Abs(list5[l].x - list5[l + 1].x) : Math.Abs(list5[l].y - list5[l + 1].y);

                        if (num11 >= num9 + num2 && num10 >= 2)
                        {
                            num10 = 0;

                            if (sortorien == 0)
                            {
                                split.Add(new KeyValue<int, int>(-1, list5[l].x + list5[l].width + 5));
                            }
                            else
                            {
                                split.Add(new KeyValue<int, int>(-1, list5[l].y + list5[l].height + 5));
                            }
                        }
                    }
                    for (int m = 0; m < list4.Count; m++)
                    {
                        if (sortorien == 0)
                        {
                            split.Add(new KeyValue<int, int>(m, list4[m].Value.X));
                        }
                        else
                        {
                            split.Add(new KeyValue<int, int>(m, list4[m].Value.Y));
                        }
                    }

                    if (split.Count == 0)
                    {
                        if (sortorien == 0)
                        {
                            split.Add(new KeyValue<int, int>(-1, list5[0].x - list5[0].width / 2));
                        }
                        else
                        {
                            split.Add(new KeyValue<int, int>(-1, list5[0].y - list5[0].height / 2));
                        }
                    }

                    split.Sort((KeyValue<int, int> one, KeyValue<int, int> tow) => one.Value - tow.Value);

                    for (int h = 0; h < split.Count; h++)
                    {
                        List<CvRect> list7 = new List<CvRect>();

                        if (h == split.Count - 1)
                        {
                            if (sortorien == 0)
                            {
                                list7 = list5.FindAll((CvRect p) => p.x > split[h].Value);
                            }
                            else
                            {
                                list7 = list5.FindAll((CvRect p) => p.y > split[h].Value);
                            }
                            if (list7.Count >= 2)
                            {
                                this.RemoveBlankSplitBlobs(list7, sortorien, num2);
                                list6.Add(list7);
                            }
                        }
                        if (h == 0)
                        {
                            if (sortorien == 0)
                            {
                                list7 = list5.FindAll((CvRect p) => p.x < split[h].Value);
                            }
                            else
                            {
                                list7 = list5.FindAll((CvRect p) => p.y < split[h].Value);
                            }
                            if (list7.Count >= 2)
                            {
                                this.RemoveBlankSplitBlobs(list7, sortorien, num2);
                                list6.Add(list7);
                            }
                        }
                        if (0 < h && h <= split.Count - 1)
                        {
                            if (sortorien == 0)
                            {
                                list7 = list5.FindAll((CvRect p) => p.x > split[h - 1].Value && p.x < split[h].Value);
                            }
                            else
                            {
                                list7 = list5.FindAll((CvRect p) => p.y > split[h - 1].Value && p.y < split[h].Value);
                            }
                            if (list7.Count >= 2)
                            {
                                this.RemoveBlankSplitBlobs(list7, sortorien, num2);
                                list6.Add(list7);
                            }
                        }
                    }
                }
                else
                {
                    if (list3[k].Value != -1)
                    {
                        split.Add(new KeyValue<int, int>(0, (sortorien == 0) ? list4[0].Value.X : list4[0].Value.Y));
                    }
                    else
                    {
                        split.Add(new KeyValue<int, int>(-1, (sortorien == 0) ? list5[0].x : list5[0].y));
                    }

                    list6.Add(list5);
                }

                for (int n = 0; n < list6.Count; n++)
                {
                    int num12 = (sortorien == 0) ? list6[n][0].x : list6[n][0].y,
                        num13 = (sortorien == 0) ? list6[n][list6[n].Count - 1].x : list6[n][list6[n].Count - 1].y;
                    bool flag = false;

                    for (int num14 = 0; num14 < split.Count; num14++)
                    {
                        if (split[num14].Key != -1)
                        {
                            int value = split[num14].Value,
                                num15;

                            if (num14 == split.Count - 1)
                            {
                                num15 = num13;
                            }
                            else
                            {
                                num15 = split[num14 + 1].Value;
                            }

                            int number = list4[split[num14].Key].Key;
                            Point pos = list4[split[num14].Key].Value;

                            if (value <= num12 && num15 >= num13 && displayClass.omrList.Find((OmrObjectiveItem p) => p.num.number == number && p.num.pos == pos) == null)
                            {
                                OmrObjectiveItem item = new OmrObjectiveItem(new Num(number, pos), list6[n].ToArray());

                                displayClass.omrList.Add(item);

                                flag = true;
                            }
                        }
                    }

                    if (!flag)
                    {
                        Num num16 = new Num();

                        num16.number = -1;

                        if (displayClass.omrList.Count > 0)
                        {
                            OmrObjectiveItem omrObjectiveItem = displayClass.omrList[0];
                            int x = (sortorien == 0) ? (list6[n][0].x - (omrObjectiveItem.ItemRects[0].x - omrObjectiveItem.num.pos.X)) : (list6[n][0].x + list6[n][0].width / 2),
                                y = (sortorien == 0) ? list6[n][0].y : (list6[n][0].y - (omrObjectiveItem.ItemRects[0].y - omrObjectiveItem.num.pos.Y));

                            num16.pos = new Point(x, y);
                        }
                        else
                        {
                            int x2 = (sortorien == 0) ? (list6[n][0].x - list6[n][0].width / 2) : (list6[n][0].x + list6[n][0].width / 2),
                                y2 = (sortorien == 0) ? list6[n][0].y : (list6[n][0].y - list6[n][0].height);

                            num16.pos = new Point(x2, y2);
                        }

                        OmrObjectiveItem omrObjectiveItem2 = new OmrObjectiveItem(num16, list6[n].ToArray());

                        omrObjectiveItem2.OcrDoubt = true;

                        displayClass.omrList.Add(omrObjectiveItem2);
                    }
                }
            }

            List<List<OmrObjectiveItem>> list8 = new List<List<OmrObjectiveItem>>();

            for (int i = 0; i < displayClass.omrList.Count; i++)
            {
                List<OmrObjectiveItem> list9 = list8.Find(delegate(List<OmrObjectiveItem> P)
                {
                    OmrObjectiveItem omrObjectiveItem3 = P.Find(z => z.num.number == displayClass.omrList[i].num.number);

                    return omrObjectiveItem3 != null && omrObjectiveItem3 != displayClass.omrList[i];
                });

                if (list9 == null)
                {
                    list8.Add(new List<OmrObjectiveItem>
                    {
                        displayClass.omrList[i]
                    });
                }
                else
                {
                    list9.Add(displayClass.omrList[i]);
                }
            }

            list8.ForEach(delegate(List<OmrObjectiveItem> P)
            {
                if (P.Count >= 2)
                {
                    P.ForEach(delegate(OmrObjectiveItem K)
                    {
                        K.OcrDoubt = true;
                    });
                }
            });
            displayClass.omrList.RemoveAll((OmrObjectiveItem p) => p.ItemRects.Length == 0);

            return displayClass.omrList;
        }

        /// <summary>
        /// 检查ocr识别排列
        /// </summary>
        /// <param name="ocrList">题号识别列表</param>
        /// <param name="blobarrange">斑点排列</param>
        /// <param name="threshold">临界值</param>
        /// <param name="ocrarrange">识别排列</param>
        /// <param name="omrobedistance">项间距</param>
        private void CheckOcrArrange(List<OmrObjectiveItem> ocrList, int blobarrange, int threshold, ref int ocrarrange, ref int omrobedistance)
        {
            List<KeyValue<OmrObjectiveItem, OmrObjectiveItem>>[] array = new List<KeyValue<OmrObjectiveItem, OmrObjectiveItem>>[]
			{
				new List<KeyValue<OmrObjectiveItem, OmrObjectiveItem>>(),
				new List<KeyValue<OmrObjectiveItem, OmrObjectiveItem>>()
			};

            for (int i = 0; i < ocrList.Count - 1; i++)
            {
                OmrObjectiveItem omrObjectiveItem = ocrList[i];
                int number = omrObjectiveItem.num.number,
                    arg_64_0 = omrObjectiveItem.num.pos.X,
                    arg_75_0 = omrObjectiveItem.num.pos.Y,
                    townum = number + 1;
                OmrObjectiveItem omrObjectiveItem2 = ocrList.Find((OmrObjectiveItem p) => p.num.number == townum);

                if (omrObjectiveItem2 != null)
                {
                    if (this.ComparenumIsSame(omrObjectiveItem.num.pos, omrObjectiveItem2.num.pos, 0, threshold))
                    {
                        array[0].Add(new KeyValue<OmrObjectiveItem, OmrObjectiveItem>(omrObjectiveItem, omrObjectiveItem2));
                    }
                    else if (this.ComparenumIsSame(omrObjectiveItem.num.pos, omrObjectiveItem2.num.pos, 1, threshold))
                    {
                        array[1].Add(new KeyValue<OmrObjectiveItem, OmrObjectiveItem>(omrObjectiveItem, omrObjectiveItem2));
                    }
                }
            }

            List<KeyValue<int, int>> list = new List<KeyValue<int, int>>();

            if (array[0].Count == 0 && array[1].Count == 0)
            {
                ocrarrange = -1;
                omrobedistance = -1;

                return;
            }
            if (array[0].Count > array[1].Count)
            {
                ocrarrange = 0;
            }
            else
            {
                ocrarrange = 1;
            }

            foreach (KeyValue<OmrObjectiveItem, OmrObjectiveItem> current in array[ocrarrange])
            {
                OmrObjectiveItem key = current.Key;
                OmrObjectiveItem value = current.Value;
                int distance = this.CaculateObjectOmrItemDistance(key, value, ocrarrange, blobarrange);
                KeyValue<int, int> keyValue = list.Find(delegate(KeyValue<int, int> P)
                {
                    int num = Math.Abs(distance - P.Key);
                    return num < threshold;
                });

                if (keyValue == null)
                {
                    list.Add(new KeyValue<int, int>(distance, 1));
                }
                else
                {
                    keyValue.Value++;
                }
            }

            KeyValue<int, int> keyValue2 = list[0];

            for (int j = 1; j < list.Count; j++)
            {
                if (keyValue2.Value < list[j].Value)
                {
                    keyValue2 = list[j];
                }
            }

            omrobedistance = keyValue2.Key;
        }

        /// <summary>
        /// 计算识别项间距
        /// </summary>
        /// <param name="one">识别项1</param>
        /// <param name="tow">识别项2</param>
        /// <param name="ocrarrange">题号识别排列</param>
        /// <param name="blobarrange">斑点排列</param>
        /// <returns>间距值</returns>
        private int CaculateObjectOmrItemDistance(OmrObjectiveItem one, OmrObjectiveItem tow, int ocrarrange, int blobarrange)
        {
            OmrObjectiveItem omrObjectiveItem,
                omrObjectiveItem2;

            if (ocrarrange == 0)
            {
                if (one.ItemRects[0].x < tow.ItemRects[0].x)
                {
                    omrObjectiveItem = one;
                    omrObjectiveItem2 = tow;
                }
                else
                {
                    omrObjectiveItem = tow;
                    omrObjectiveItem2 = one;
                }

                return (blobarrange == 0) ? (omrObjectiveItem2.ItemRects[0].x - omrObjectiveItem.ItemRects[omrObjectiveItem.ItemRects.Length - 1].right) : (omrObjectiveItem2.ItemRects[0].x - omrObjectiveItem.ItemRects[0].right);
            }
            if (one.ItemRects[0].y < tow.ItemRects[0].y)
            {
                omrObjectiveItem = one;
                omrObjectiveItem2 = tow;
            }
            else
            {
                omrObjectiveItem = tow;
                omrObjectiveItem2 = one;
            }

            return (blobarrange == 0) ? (omrObjectiveItem2.ItemRects[0].y - omrObjectiveItem.ItemRects[0].bottom) : (omrObjectiveItem2.ItemRects[0].y - omrObjectiveItem.ItemRects[omrObjectiveItem.ItemRects.Length - 1].bottom);
        }

        /// <summary>
        /// 修正客观题识别列表
        /// </summary>
        /// <param name="originresult">客观题识别列表</param>
        /// <param name="blobdistance">斑点间距</param>
        /// <param name="omrItemdistance">项间距</param>
        /// <param name="ocrblobdistance">题号与斑点间距</param>
        /// <param name="blobarrange">斑点排列</param>
        /// <param name="ocrarrange">题号排列</param>
        /// <param name="threshold">临界值</param>
        private void CorrectObjectiveOmrOcrList(List<OmrObjectiveItem> originresult, int blobdistance, int omrItemdistance, int ocrblobdistance, int blobarrange, int ocrarrange, int threshold = 3)
        {
            TemplateInfoGenerater.CorrectClass correctClass = new TemplateInfoGenerater.CorrectClass();

            correctClass.omrItemdistance = omrItemdistance;
            correctClass.blobarrange = blobarrange;
            correctClass.ocrarrange = ocrarrange;
            correctClass.currentClass = this;

            if (correctClass.ocrarrange == -1 || correctClass.blobarrange == -1)
            {
                return;
            }

            correctClass.ocrerrorList = originresult.FindAll((OmrObjectiveItem p) => p.OcrDoubt);

            if (correctClass.ocrarrange == 0)
            {
                correctClass.ocrerrorList.Sort((OmrObjectiveItem one, OmrObjectiveItem tow) => one.ItemRects[0].x - tow.ItemRects[0].x);
            }
            else
            {
                correctClass.ocrerrorList.Sort((OmrObjectiveItem one, OmrObjectiveItem tow) => one.ItemRects[0].y - tow.ItemRects[0].y);
            }

            List<List<OmrObjectiveItem>> list = new List<List<OmrObjectiveItem>>();

            for (int i = 0; i < correctClass.ocrerrorList.Count; i++)
            {
                List<OmrObjectiveItem> list2 = list.Find((List<OmrObjectiveItem> P) => correctClass.currentClass.FindLinjinItem(P, correctClass.ocrerrorList[i], correctClass.ocrarrange, correctClass.blobarrange, correctClass.omrItemdistance, 3) != null);

                if (list2 == null)
                {
                    list.Add(new List<OmrObjectiveItem>
                    {
                        correctClass.ocrerrorList[i]
                    });
                }
                else if (!list2.Contains(correctClass.ocrerrorList[i]))
                {
                    list2.Add(correctClass.ocrerrorList[i]);
                }
            }

            list.ForEach(delegate(List<OmrObjectiveItem> P)
            {
                if (correctClass.ocrarrange == 0)
                {
                    P.Sort((OmrObjectiveItem one, OmrObjectiveItem tow) => one.ItemRects[0].x - tow.ItemRects[0].x);
                    return;
                }
                P.Sort((OmrObjectiveItem one, OmrObjectiveItem tow) => one.ItemRects[0].y - tow.ItemRects[0].y);
            });

            List<OmrObjectiveItem> findlist = originresult.FindAll((OmrObjectiveItem P) => !P.OcrDoubt);

            for (int l = 0; l < list.Count; l++)
            {
                OmrObjectiveItem finditem = list[l][0],
                    omrObjectiveItem = this.FindLinjinItem(findlist, finditem, correctClass.ocrarrange, correctClass.blobarrange, correctClass.omrItemdistance, 3);

                if (omrObjectiveItem != null)
                {
                    list[l].Add(omrObjectiveItem);
                }
                else if (list[l].Count > 1)
                {
                    OmrObjectiveItem finditem2 = list[l][list[l].Count - 1];

                    omrObjectiveItem = this.FindLinjinItem(findlist, finditem2, correctClass.ocrarrange, correctClass.blobarrange, correctClass.omrItemdistance, 3);

                    if (omrObjectiveItem != null)
                    {
                        list[l].Add(omrObjectiveItem);
                    }
                }
            }

            list.ForEach(delegate(List<OmrObjectiveItem> P)
            {
                if (correctClass.ocrarrange == 0)
                {
                    P.Sort((OmrObjectiveItem one, OmrObjectiveItem tow) => one.ItemRects[0].x - tow.ItemRects[0].x);

                    return;
                }

                P.Sort((OmrObjectiveItem one, OmrObjectiveItem tow) => one.ItemRects[0].y - tow.ItemRects[0].y);
            });

            foreach (List<OmrObjectiveItem> current in list)
            {
                if (current.Count != 1)
                {
                    OmrObjectiveItem omrObjectiveItem2 = current[0],
                        omrObjectiveItem3 = current[current.Count - 1];

                    if (!omrObjectiveItem2.OcrDoubt)
                    {
                        for (int j = 1; j < current.Count; j++)
                        {
                            if (current[j].OcrDoubt)
                            {
                                int num = omrObjectiveItem2.num.number + j;

                                if (current[j].num.number > 0 && current[j].num.number == num)
                                {
                                    current[j].OcrDoubt = false;
                                }
                                else
                                {
                                    current[j].num.number = num;

                                    if (correctClass.blobarrange == 0)
                                    {
                                        current[j].num.pos = new Point(current[j].ItemRects[0].x - ocrblobdistance, current[j].ItemRects[0].y);
                                    }
                                    else
                                    {
                                        current[j].num.pos = new Point(current[j].ItemRects[0].x, current[j].ItemRects[0].y - ocrblobdistance);
                                    }
                                }
                            }
                        }
                    }
                    else if (!omrObjectiveItem3.OcrDoubt)
                    {
                        int k = current.Count - 2,
                            num2 = 1;

                        while (k >= 0)
                        {
                            if (current[k].OcrDoubt)
                            {
                                int num3 = omrObjectiveItem3.num.number - num2;

                                if (current[k].num.number > 0 && current[k].num.number == num3)
                                {
                                    current[k].OcrDoubt = false;
                                }
                                else
                                {
                                    current[k].num.number = num3;

                                    if (correctClass.blobarrange == 0)
                                    {
                                        current[k].num.pos = new Point(current[k].ItemRects[0].x - ocrblobdistance, current[k].ItemRects[0].y);
                                    }
                                    else
                                    {
                                        current[k].num.pos = new Point(current[k].ItemRects[0].x, current[k].ItemRects[0].y - ocrblobdistance);
                                    }
                                }
                            }

                            k--;
                            num2++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 发现临近项
        /// </summary>
        /// <param name="findlist">项列表</param>
        /// <param name="finditem">发现项</param>
        /// <param name="ocrarrange">题号排列</param>
        /// <param name="blobarrange">斑点排列</param>
        /// <param name="omrItemdistance">项件间距</param>
        /// <param name="threshold">临界值</param>
        /// <returns>发现的项</returns>
        private OmrObjectiveItem FindLinjinItem(List<OmrObjectiveItem> findlist, OmrObjectiveItem finditem, int ocrarrange, int blobarrange, int omrItemdistance, int threshold = 3)
        {
            return findlist.Find(delegate(OmrObjectiveItem L)
            {
                if (L == finditem)
                {
                    return false;
                }
                if (ocrarrange == 0)
                {
                    int y = finditem.ItemRects[0].y,
                        bottom = finditem.ItemRects[finditem.ItemRects.Length - 1].bottom,
                        y2 = L.ItemRects[0].y,
                        bottom2 = L.ItemRects[L.ItemRects.Length - 1].bottom;

                    if (bottom2 < y || y2 > bottom)
                    {
                        return false;
                    }
                }
                else
                {
                    int x = finditem.ItemRects[0].x,
                        right = finditem.ItemRects[finditem.ItemRects.Length - 1].right,
                        x2 = L.ItemRects[0].x,
                        right2 = L.ItemRects[L.ItemRects.Length - 1].right;

                    if (right2 < x || x2 > right)
                    {
                        return false;
                    }
                }

                return this.CaculateObjectOmrItemDistance(finditem, L, ocrarrange, blobarrange) - omrItemdistance <= threshold;
            });
        }

        /// <summary>
        /// 移除空白的分割斑点
        /// </summary>
        /// <param name="list">斑点列表</param>
        /// <param name="sortorien">斑点排序</param>
        /// <param name="blobthreshold">斑点临界值</param>
        private void RemoveBlankSplitBlobs(List<CvRect> list, int sortorien, int blobthreshold)
        {
            int num = (sortorien == 0) ? Math.Abs(list[0].x - list[1].x) : Math.Abs(list[0].y - list[1].y),
                num2 = -1;

            for (int i = 1; i < list.Count - 1; i++)
            {
                int num3 = (sortorien == 0) ? Math.Abs(list[i].x - list[i + 1].x) : Math.Abs(list[i].y - list[i + 1].y);

                if (num3 >= num + blobthreshold)
                {
                    num2 = i + 1;

                    break;
                }
            }
            if (num2 != -1)
            {
                list.RemoveRange(num2, list.Count - num2);
            }
        }

        /// <summary>
        /// 构造考号
        /// </summary>
        /// <param name="blobList">斑点列表</param>
        /// <returns>学号信息</returns>
        public OmrSchoolNumber ComposeSchoolNumberOmrList(List<CvRect> blobList)
        {
            if (blobList.Count == 0)
            {
                throw new BlobException("项识别数为0");
            }

            int threshold = (int)((double)blobList[0].width * 0.5);
            List<List<CvRect>> list = this.ClusterBlob(blobList, 1, threshold);
            List<int> list2 = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Count < 10)
                {
                    list2.Add(i);
                }
                else if (list[i].Count > 10)
                {
                    throw new BlobException("存在项数大于10的列");
                }
            }
            if (list2.Count > 0)
            {
                int num = (int)((double)blobList[0].height * 0.5);
                List<List<CvRect>> list3 = this.ClusterBlob(blobList, 0, num);

                for (int j = 0; j < list3.Count; j++)
                {
                    if (list3[j].Count >= 1)
                    {
                        for (int k = 0; k < list2.Count; k++)
                        {
                            bool flag = false;
                            List<CvRect> list4 = list[k];

                            for (int l = 0; l < list3[j].Count; l++)
                            {
                                for (int m = 0; m < list4.Count; m++)
                                {
                                    if (list3[j][l].x == list4[m].x && list3[j][l].y == list4[m].y)
                                    {
                                        flag = true;
                                    }
                                }
                            }
                            if (!flag)
                            {
                                list4.Add(new CvRect(list4[0].x, list3[j][0].y, list3[j][0].width, list3[j][0].height));
                            }
                        }
                    }
                }
                if (list3.Count < 10)
                {
                    int num2 = list3[1][0].y - (list3[0][0].y + list3[0][0].height),
                        height = list3[0][0].height,
                        width = list3[0][0].width;

                    for (int n = 1; n < list3.Count - 1; n++)
                    {
                        int num3 = Math.Abs(list3[n + 1][0].y - (list3[n][0].y + list3[n][0].height));

                        if (num2 > num3)
                        {
                            num2 = num3;
                        }
                    }
                    for (int num4 = 0; num4 < list3.Count - 1; num4++)
                    {
                        int num5 = Math.Abs(list3[num4 + 1][0].y - (list3[num4][0].y + list3[num4][0].height));

                        if (Math.Abs(num2 - num5) > num)
                        {
                            int num6 = (int)Math.Round(Convert.ToDouble(num5 - height) / (double)(num2 + height)),
                                num7 = list3[num4][0].y + list3[num4][0].height;

                            for (int num8 = 0; num8 < num6; num8++)
                            {
                                for (int num9 = 0; num9 < list.Count; num9++)
                                {
                                    CvRect item = new CvRect(list[num9][0].x, num7 + num2, width, height);

                                    list[num9].Add(item);
                                }

                                num7 += num2 + height;
                            }
                        }
                    }
                }
            }

            OmrSchoolNumber omrSchoolNumber = new OmrSchoolNumber();

            for (int num10 = 0; num10 < list.Count; num10++)
            {
                omrSchoolNumber.omrs.Add(list[num10].ToArray());
            }

            return omrSchoolNumber;
        }

        /// <summary>
        /// 比较矩形是相同的
        /// </summary>
        /// <param name="one">矩形1</param>
        /// <param name="tow">矩形2</param>
        /// <param name="sortorien">排序序列</param>
        /// <param name="threshold">临界值</param>
        /// <returns>比较结果</returns>
        private bool CompareRetangleIsSameArray(CvRect one, CvRect tow, int sortorien, int threshold = 5)
        {
            int num = (sortorien == 0) ? Math.Abs(one.y - tow.y) : Math.Abs(one.x - tow.x),
                num2 = Math.Abs(one.width - tow.width),
                num3 = Math.Abs(one.height - tow.height);

            return num <= threshold && (num2 <= threshold || num3 <= threshold);
        }

        /// <summary>
        /// 重置当前识别结果
        /// </summary>
        private void Reset()
        {
            this.smallrotatedegree = 0.0;

            if (this.CurrentImagePtr != null && this.CurrentImagePtr.Length > 0)
            {
                for (int i = 0; i < this.CurrentImagePtr.Length; i++)
                {
                    if (this.CurrentImagePtr[i] != IntPtr.Zero)
                    {
                        ScanlibInterop.ReleaseImage(this.CurrentImagePtr[i]);

                        this.CurrentImagePtr[i] = IntPtr.Zero;
                    }
                }
            }
            if (this.OriginImagePtr != null && this.OriginImagePtr.Length > 0)
            {
                for (int j = 0; j < this.OriginImagePtr.Length; j++)
                {
                    if (this.OriginImagePtr[j] != IntPtr.Zero)
                    {
                        ScanlibInterop.ReleaseImage(this.OriginImagePtr[j]);

                        this.OriginImagePtr[j] = IntPtr.Zero;
                    }
                }
            }
        }

        /// <summary>
        /// 释放当前资源
        /// </summary>
        public void Dispose()
        {
            this.Reset();
        }

        /// <summary>
        /// 设置识别图像
        /// </summary>
        /// <param name="filename">图像路径数组</param>
        public void SetRecognizeImage(string[] filename)
        {
            this.Reset();

            this.CurrentImagePtr = new IntPtr[filename.Length];
            this.OriginImagePtr = new IntPtr[filename.Length];
            this.filename = filename;

            for (int i = 0; i < filename.Length; i++)
            {
                this.CurrentImagePtr[i] = ScanlibInterop.ReadImage(filename[i]);
                this.OriginImagePtr[i] = ScanlibInterop.ReadImage(filename[i]);

                if (this.CurrentImagePtr[i] == IntPtr.Zero)
                {
                    throw new IOException("加载图片" + filename[i] + "异常");
                }
            }
        }

        /// <summary>
        /// 识别斑点
        /// </summary>
        /// <param name="selectArea">选中区域</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="blobArrayStr">自定义的斑点坐标字符串</param>
        /// <param name="type">识别类型，0为自动识别，1为自定义识别</param>
        /// <returns>斑点列表</returns>
        public List<CvRect> FindBlobs(CvRect selectArea, int pageIndex, string blobArrayStr, int type)
        {
            if (selectArea.width == 0 || selectArea.height == 0)
            {
                throw new ArgumentException("框选区域不正确");
            }
            if (this.CurrentImagePtr[pageIndex] == IntPtr.Zero)
            {
                throw new ArgumentException("被识别图像句柄为空");
            }

            List<CvRect> list = new List<CvRect>();
            string text = string.Empty;

            if (type == 0)
            {
                text = Marshal.PtrToStringAnsi(ScanlibInterop.BlobDetect(this.recogInstance, this.CurrentImagePtr[pageIndex], selectArea, 100, 2000));
            }
            else
            {
                text = blobArrayStr;
            }
            if (string.IsNullOrEmpty(text))
            {
                return list;
            }

            string[] blobItemArray = text.Split(new char[]
			{
				';'
			});

            for (int i = 0; i < blobItemArray.Length; i++)
            {
                string text2 = blobItemArray[i];

                if (text2 != string.Empty)
                {
                    string[] array3 = text2.Split(new char[]
					{
						','
					});
                    int x = int.Parse(array3[0]) + selectArea.x,
                        y = int.Parse(array3[1]) + selectArea.y,
                        num = int.Parse(array3[2]),
                        num2 = int.Parse(array3[3]);

                    Console.WriteLine(num * num2);

                    list.Add(new CvRect(x, y, num, num2));
                }
            }

            return list;
        }

        /// <summary>
        /// 识别括号
        /// </summary>
        /// <param name="selectArea">选中区域</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="blobArrayStr">自定义的斑点集合字符串</param>
        /// <param name="type">识别类型，0为自动识别，1为识别自定义的字符串</param>
        /// <returns>括号列表</returns>
        public List<CvRect> FindBracket(CvRect selectArea, int pageIndex, string blobArrayStr, int type)
        {
            if (selectArea.width == 0 || selectArea.height == 0)
            {
                throw new ArgumentException("框选区域不正确");
            }
            if (this.CurrentImagePtr[pageIndex] == IntPtr.Zero)
            {
                throw new ArgumentException("被识别图像句柄为空");
            }

            List<CvRect> list = new List<CvRect>();
            string text = string.Empty;

            if (type == 0)
            {
                text = Marshal.PtrToStringAnsi(ScanlibInterop.BracketsDetect(this.recogInstance, this.CurrentImagePtr[pageIndex], selectArea, 30, 500));
            }
            else
            {
                text = blobArrayStr;
            }
            if (string.IsNullOrEmpty(text))
            {
                return list;
            }

            string[] array = text.Split(new char[]
			{
				';'
			}),
            array2 = array;

            for (int i = 0; i < array2.Length; i++)
            {
                string text2 = array2[i];

                if (text2 != string.Empty)
                {
                    string[] array3 = text2.Split(new char[]
					{
						','
					});
                    int x = int.Parse(array3[0]) + selectArea.x,
                        y = int.Parse(array3[1]) + selectArea.y,
                        num = int.Parse(array3[2]),
                        num2 = int.Parse(array3[3]);

                    Console.WriteLine(num * num2);

                    list.Add(new CvRect(x, y, num, num2));
                }
            }

            return list;
        }

        /// <summary>
        /// 获取标题匹配
        /// </summary>
        /// <param name="selectArea">选中区域</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns>匹配区域</returns>
        public CvRect GetTitleMatch(CvRect selectArea, int pageindex)
        {
            if (selectArea.width == 0 || selectArea.height == 0)
            {
                throw new ArgumentException("框选区域不正确");
            }
            if (this.CurrentImagePtr == null || this.CurrentImagePtr[pageindex] == IntPtr.Zero)
            {
                throw new ArgumentException("被识别图像句柄为空");
            }

            return ScanlibInterop.ReduceRectArea(this.CurrentImagePtr[pageindex], selectArea);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        public bool SaveImage(string filename, int pageindex)
        {
            return ScanlibInterop.SaveImage(this.CurrentImagePtr[pageindex], filename);
        }

        /// <summary>
        /// 考号区域识别
        /// </summary>
        /// <param name="rect">考号区域</param>
        /// <param name="pageindex">当前页码</param>
        /// <param name="omrType">识别类型</param>
        /// <param name="blobArrayStr">手动定义区域项目字符串</param>
        /// <param name="type">识别类型，0为自动识别，1为自定义识别</param>
        /// <returns>自定义考号信息</returns>
        public OmrSchoolNumber GetSchoolNumberOmr(CvRect rect, int pageindex, OmrType omrType, string blobArrayStr, int type)
        {
            if (rect.width == 0 || rect.height == 0)
            {
                throw new ArgumentException("框选区域不正确");
            }
            if (this.CurrentImagePtr[pageindex] == IntPtr.Zero)
            {
                throw new ArgumentException("被识别图像句柄为空");
            }

            List<CvRect> list = (omrType == OmrType.Rect) ? this.FindBlobs(rect, pageindex, blobArrayStr, type) : this.FindBracket(rect, pageindex, blobArrayStr, type);

            if (list.Count == 0)
            {
                return null;
            }

            OmrSchoolNumber result;

            try
            {
                OmrSchoolNumber omrSchoolNumber = this.ComposeSchoolNumberOmrList(list);
                int count = 0;
                bool flag = false;

                omrSchoolNumber.omrs.ForEach(delegate(CvRect[] p)
                {
                    count += p.Length;

                    if (p.Length >= 7)
                    {
                        flag = true;
                    }
                });

                if (flag && count >= 20)
                {
                    result = omrSchoolNumber;
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// 获取斑点和题号识别
        /// </summary>
        /// <param name="selectArea">选中区域</param>
        /// <param name="pageindex">当前页码</param>
        /// <param name="numList">题号列表</param>
        /// <param name="blobList">斑点列表</param>
        public void GetBlobAndOcr(CvRect selectArea, int pageindex, ref List<KeyValue<int, Point>> numList, ref List<CvRect> blobList)
        {
            if (selectArea.width == 0 || selectArea.height == 0)
            {
                throw new ArgumentException("框选区域不正确");
            }
            if (this.CurrentImagePtr[pageindex] == IntPtr.Zero)
            {
                throw new ArgumentException("被识别图像句柄为空");
            }

            ScanlibInterop.RecognizeImage(this.recogInstance, this.CurrentImagePtr[pageindex], selectArea, 0);

            string text = Marshal.PtrToStringAnsi(ScanlibInterop.GetOCRResult(this.recogInstance)),
                text2 = Marshal.PtrToStringAnsi(ScanlibInterop.GetOptionBlobs(this.recogInstance, this.CurrentImagePtr[pageindex], selectArea));

            if (string.IsNullOrEmpty(text))
            {
                throw new OCRException("OCR识别数为0");
            }
            if (string.IsNullOrEmpty(text2))
            {
                throw new BlobException("项识别数为0");
            }

            numList.Clear();

            string[] array = text.Split(new char[]
			{
				';'
			}),
            array2 = array;

            for (int i = 0; i < array2.Length; i++)
            {
                string text3 = array2[i];

                if (text3 != string.Empty)
                {
                    string[] array3 = text3.Split(new char[]
					{
						','
					});
                    string s = array3[0];
                    int num = int.Parse(array3[1]),
                        num2 = int.Parse(array3[2]);

                    if (num >= 0 && num2 >= 0)
                    {
                        int x = num + selectArea.x,
                            y = num2 + selectArea.y;

                        numList.Add(new KeyValue<int, Point>(int.Parse(s), new Point(x, y)));
                    }
                }
            }

            blobList.Clear();

            string[] array4 = text2.Split(new char[]
			{
				';'
			}),
            array5 = array4;

            for (int j = 0; j < array5.Length; j++)
            {
                string text4 = array5[j];

                if (text4 != string.Empty)
                {
                    string[] array6 = text4.Split(new char[]
					{
						','
					});
                    int num3 = int.Parse(array6[0]) + selectArea.x,
                        num4 = int.Parse(array6[1]) + selectArea.y,
                        num5 = int.Parse(array6[2]),
                        num6 = int.Parse(array6[3]);

                    Console.WriteLine(string.Concat(new object[]
					{
						num3,
						",",
						num4,
						",",
						num5,
						",",
						num6,
						",",
						num5 * num6
					}));
                    blobList.Add(new CvRect(num3, num4, num5, num6));
                }
            }
        }

        /// <summary>
        /// 获取斑点项间距
        /// </summary>
        /// <param name="omrList">识别列表</param>
        /// <param name="sortorient">排序号</param>
        /// <param name="thredhold">临界值</param>
        /// <returns>间距值</returns>
        private int GetBlobItemDistance(List<OmrObjectiveItem> omrList, int sortorient, int thredhold = 3)
        {
            List<KeyValue<int, int>> list = new List<KeyValue<int, int>>();

            for (int i = 0; i < omrList.Count; i++)
            {
                if (omrList[i].ItemRects.Length >= 2)
                {
                    int xydistance = (sortorient == 0) ? (omrList[i].ItemRects[1].x - omrList[i].ItemRects[0].x - omrList[i].ItemRects[0].width) : (omrList[i].ItemRects[1].y - omrList[i].ItemRects[0].y - omrList[i].ItemRects[0].height);
                    KeyValue<int, int> keyValue = list.Find((KeyValue<int, int> P) => Math.Abs(xydistance - P.Key) <= thredhold);

                    if (keyValue == null)
                    {
                        list.Add(new KeyValue<int, int>(xydistance, 1));
                    }
                    else
                    {
                        keyValue.Value++;
                    }
                }
            }

            KeyValue<int, int> keyValue2 = list[0];

            for (int j = 1; j < list.Count; j++)
            {
                if (keyValue2.Value < list[j].Value)
                {
                    keyValue2 = list[j];
                }
            }

            return keyValue2.Key;
        }

        /// <summary>
        /// 获取客观题的识别结果
        /// </summary>
        /// <param name="selectArea">客观题选中区域</param>
        /// <param name="numberGroupStr">客观题的题号字符串</param>
        /// <param name="blobGroupStr">客观题的斑点字符串</param>
        /// <returns>返回识别结果</returns>
        public OmrObjective GetOmrObjective(CvRect selectArea, string numberGroupStr, string blobGroupStr)
        {
            if (selectArea.width == 0 || selectArea.height == 0)
            {
                throw new ArgumentException("框选区域不正确");
            }

            return ComputeOmrObjective(selectArea, numberGroupStr, blobGroupStr);
        }

        /// <summary>
        /// 计算客观题识别区
        /// </summary>
        /// <param name="selectArea">选中区域</param>
        /// <param name="text">题号字符串</param>
        /// <param name="text2">斑点字符串</param>
        /// <returns>返回识别实体</returns>
        private OmrObjective ComputeOmrObjective(CvRect selectArea, string text, string text2)
        {
            OmrObjective omrObjective = new OmrObjective();
            List<KeyValue<int, Point>> numList = new List<KeyValue<int, Point>>();
            List<CvRect> list = new List<CvRect>();

            if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(text2))
            {
                throw new BlobException("项识别数为0");
            }
            if (!string.IsNullOrEmpty(text))
            {
                string[] array = text.Split(new char[]
				{
					';'
				});

                for (int i = 0; i < array.Length; i++)
                {
                    string text3 = array[i];

                    if (text3 != string.Empty)
                    {
                        string[] array3 = text3.Split(new char[]
						{
							','
						});
                        string s = array3[0];
                        int num = int.Parse(array3[1]),
                            num2 = int.Parse(array3[2]);

                        if (num >= 0 && num2 >= 0)
                        {
                            int x = num + selectArea.x,
                                y = num2 + selectArea.y,
                                num3 = int.Parse(s);

                            if (num3 > 0)
                            {
                                numList.Add(new KeyValue<int, Point>(num3, new Point(x, y)));
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(text2))
            {
                string[] array4 = text2.Split(new char[]
				{
					';'
				}),
                array5 = array4;

                for (int j = 0; j < array5.Length; j++)
                {
                    string text4 = array5[j];

                    if (text4 != string.Empty)
                    {
                        string[] array6 = text4.Split(new char[]
						{
							','
						});
                        int num4 = int.Parse(array6[0]) + selectArea.x,
                            num5 = int.Parse(array6[1]) + selectArea.y,
                            num6 = int.Parse(array6[2]),
                            num7 = int.Parse(array6[3]);

                        Console.WriteLine(string.Concat(new object[]
						{
							num4,
							",",
							num5,
							",",
							num6,
							",",
							num7,
							",",
							num6 * num7
						}));
                        list.Add(new CvRect(num4, num5, num6, num7));
                    }
                }
            }
            if (!string.IsNullOrEmpty(text) && string.IsNullOrEmpty(text2))
            {
                omrObjective.ItemBlobSort = -1;
                omrObjective.ItemBlobDistance = -1;
                omrObjective.OcrSort = -1;
                omrObjective.ItemDistance = -1;
                omrObjective.OcrBlobDistance = -1;
                omrObjective.region = selectArea;
                omrObjective.objectiveItems = null;
                omrObjective.originnumList = numList;

                return omrObjective;
            }
            if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
            {
                omrObjective.ItemBlobSort = -1;
                omrObjective.ItemBlobDistance = -1;
                omrObjective.OcrSort = -1;
                omrObjective.ItemDistance = -1;
                omrObjective.OcrBlobDistance = -1;
                omrObjective.region = selectArea;
                omrObjective.objectiveItems = null;
                omrObjective.originblobList = list;

                return omrObjective;
            }

            CvRect blobrect = this.CheckBlobItemSize(list, 3);

            list.RemoveAll(delegate(CvRect p)
            {
                if (Math.Abs(p.width - blobrect.width) > blobrect.width / 3)
                {
                    return true;
                }
                if (Math.Abs(p.height - blobrect.height) > blobrect.height / 3)
                {
                    return true;
                }

                for (int k = 0; k < numList.Count; k++)
                {
                    KeyValue<int, Point> keyValue = numList[k];

                    if (this.CheckPosInRect(keyValue.Value, p))
                    {
                        return true;
                    }
                }

                return false;
            });

            int num8 = this.CheckObjectiveOmrArrange(numList, list);
            List<OmrObjectiveItem> list2 = this.ComposeObjectiveOmrList(numList, list, num8);
            int num9 = 0,
                num10 = 0;

            this.CheckOcrArrange(list2, num8, 3, ref num9, ref num10);

            int blobItemDistance = this.GetBlobItemDistance(list2, num8, 3),
                num11 = this.CheckOcrBlobDistance(numList, list, num8, 3);

            this.CorrectObjectiveOmrOcrList(list2, blobItemDistance, num10, num11, num8, num9, 3);
            list2.Sort((OmrObjectiveItem one, OmrObjectiveItem tow) => one.num.number - tow.num.number);

            omrObjective.ItemBlobSort = num8;
            omrObjective.ItemBlobDistance = blobItemDistance;
            omrObjective.OcrSort = num9;
            omrObjective.ItemDistance = num10;
            omrObjective.OcrBlobDistance = num11;
            omrObjective.originblobList = list;
            omrObjective.originnumList = numList;
            omrObjective.region = selectArea;
            omrObjective.objectiveItems = list2.ToArray();

            return omrObjective;
        }

        /// <summary>
        /// 获得客观题omr识别列表
        /// </summary>
        /// <param name="selectArea">选中区域</param>
        /// <param name="pageindex">当前页码</param>
        /// <param name="omrtype">识别类型</param>
        /// <returns>识别结果</returns>
        public OmrObjective GetOmrObjective(CvRect selectArea, int pageindex, OmrType omrtype)
        {
            if (selectArea.width == 0 || selectArea.height == 0)
            {
                throw new ArgumentException("框选区域不正确");
            }
            if (this.CurrentImagePtr[pageindex] == IntPtr.Zero)
            {
                throw new ArgumentException("被识别图像句柄为空");
            }

            ScanlibInterop.RecognizeImage(this.recogInstance, this.CurrentImagePtr[pageindex], selectArea, (int)omrtype);
            string text = Marshal.PtrToStringAnsi(ScanlibInterop.GetOCRResult(this.recogInstance)),
                text2 = Marshal.PtrToStringAnsi(ScanlibInterop.GetOptionBlobs(this.recogInstance, this.CurrentImagePtr[pageindex], selectArea));

            return ComputeOmrObjective(selectArea, text, text2);
        }

        /// <summary>
        /// 检查坐标是否在矩形中
        /// </summary>
        /// <param name="pos">坐标点</param>
        /// <param name="zone">矩形区域</param>
        /// <returns>检查结果</returns>
        public bool CheckPosInRect(Point pos, CvRect zone)
        {
            return pos.X >= zone.x && pos.Y >= zone.y && pos.X <= zone.x + zone.width && pos.Y <= zone.y + zone.height;
        }

        /// <summary>
        /// 检查矩形是否包含在另一矩形中
        /// </summary>
        /// <param name="selectArea">选中矩形</param>
        /// <param name="zone">参照矩形</param>
        /// <param name="issurround">是否包含</param>
        /// <returns>包含状态</returns>
        public bool CheckRectInRect(CvRect selectArea, CvRect zone, bool issurround = true)
        {
            if (selectArea.width == 0 || selectArea.height == 0)
            {
                return false;
            }
            if (issurround)
            {
                return selectArea.x >= zone.x && selectArea.y >= zone.y && selectArea.x + selectArea.width <= zone.x + zone.width && selectArea.y + selectArea.height <= zone.y + zone.height;
            }

            return this.CheckPosInRect(new Point(selectArea.x, selectArea.y), zone) || this.CheckPosInRect(new Point(selectArea.x, selectArea.bottom), zone) || this.CheckPosInRect(new Point(selectArea.right, selectArea.y), zone) || this.CheckPosInRect(new Point(selectArea.right, selectArea.bottom), zone);
        }

        /// <summary>
        /// 顺时针旋转
        /// </summary>
        /// <param name="pageindex">页码</param>
        public void ClockRotate(int pageindex)
        {
            this.smallrotatedegree -= 0.2;

            if (this.smallrotatedegree == 0.0)
            {
                ScanlibInterop.SaveImage(this.OriginImagePtr[pageindex], this.filename[pageindex]);
                ScanlibInterop.ReleaseImage(this.CurrentImagePtr[pageindex]);

                this.CurrentImagePtr[pageindex] = ScanlibInterop.ReadImage(this.filename[pageindex]);

                return;
            }

            IntPtr imgptr = ScanlibInterop.RotateImageArbitraryDegree(this.OriginImagePtr[pageindex], this.smallrotatedegree);

            ScanlibInterop.SaveImage(imgptr, this.filename[pageindex]);
            ScanlibInterop.ReleaseImage(this.CurrentImagePtr[pageindex]);

            this.CurrentImagePtr[pageindex] = ScanlibInterop.ReadImage(this.filename[pageindex]);
        }

        /// <summary>
        /// 逆时针旋转
        /// </summary>
        /// <param name="pageindex">页码</param>
        public void UnClockRotate(int pageindex)
        {
            this.smallrotatedegree += 0.2;

            if (this.smallrotatedegree == 0.0)
            {
                ScanlibInterop.SaveImage(this.OriginImagePtr[pageindex], this.filename[pageindex]);
                ScanlibInterop.ReleaseImage(this.CurrentImagePtr[pageindex]);

                this.CurrentImagePtr[pageindex] = ScanlibInterop.ReadImage(this.filename[pageindex]);

                return;
            }

            IntPtr imgptr = ScanlibInterop.RotateImageArbitraryDegree(this.OriginImagePtr[pageindex], this.smallrotatedegree);

            ScanlibInterop.SaveImage(imgptr, this.filename[pageindex]);
            ScanlibInterop.ReleaseImage(this.CurrentImagePtr[pageindex]);

            this.CurrentImagePtr[pageindex] = ScanlibInterop.ReadImage(this.filename[pageindex]);
        }

        /// <summary>
        /// 更新矩形参数
        /// </summary>
        /// <param name="rectheight">矩形高度</param>
        /// <param name="rectwid">矩形宽度</param>
        /// <returns>更新结果</returns>
        public bool UpdateRectParam(int rectheight, int rectwid)
        {
            bool flag = ScanlibInterop.SetOptionHeight(this.recogInstance, rectheight);

            if (flag)
            {
                flag = ScanlibInterop.SetOptionWidth(this.recogInstance, rectwid);
            }

            return flag;
        }
    }
}
