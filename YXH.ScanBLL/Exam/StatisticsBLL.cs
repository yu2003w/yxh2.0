using System.Collections.Generic;
using YXH.Enum;
using YXH.Model;
using System.Linq;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 静态信息处理
    /// </summary>
    public class StatisticsBLL
    {
        /// <summary>
        /// 导出学生
        /// </summary>
        /// <returns>静态学生列表</returns>
        public static StaticsData<StudentInfo> ExportStudent()
        {
            List<StudentInfo> srcList = (from s in ScanGlobalInfo.ExamInfo.StudentExamInfoList
                                         orderby s.ExamCode
                                         select new StudentInfo
                                         {
                                             StudentName = s.StuName,
                                             Schoolnumber = s.ExamCode
                                         }).ToList<StudentInfo>();
            string[] properties = new string[]
			{
				"StudentName",
				"Schoolnumber"
			},
            fieldNames = new string[]
			{
				"学生姓名",
				"准考证号"
			};

            return new StaticsData<StudentInfo>(srcList, properties, fieldNames)
            {
                SheetName = "考生详情表",
                FileName = ScanGlobalInfo.ExamInfo.ExamName + "考生详情表"
            };
        }

        /// <summary>
        /// 导出考卷信息
        /// </summary>
        /// <param name="targetMode">目标模式</param>
        /// <returns>静态学生信息列表</returns>
        public static StaticsData<StudentInfo> ExportPaperInfo(StatisDataMode targetMode)
        {
            List<StudentInfo> list = new List<StudentInfo>();

            list = StatisticsBLL.GenerateDataFromScanRecord(ScanGlobalInfo.ExamInfo.ScanRecordList, targetMode);
            list = (from p in list
                    orderby p.Schoolnumber
                    select p).ToList<StudentInfo>();

            string[] properties = new string[0],
                fieldNames = new string[0];
            string text = "统计数据";

            switch (targetMode)
            {
                case StatisDataMode.All:
                    properties = new string[]
				{
					"ExamId",
					"ExamName",
					"Room",
					"ExamSeatNumber",
					"BatchID",
					"Error",
					"Error_Origin",
					"StudentName",
					"Schoolnumber",
					"Schoolnumber_Origin",
					"Omr",
					"Omr_origin",
					"ImageName",
					"ScanTime"
				};
                    fieldNames = new string[]
				{
					"考试编号",
					"考试名称",
					"考场",
					"座位号",
					"扫描批次号",
					"当前状态",
					"初始识别状态",
					"学生姓名",
					"匹配考号",
					"考号识别结果",
					"客观题答案",
					"客观题识别结果",
					"图片名称",
					"扫描时间"
				};
                    text = "扫描记录详情";

                    break;
                case StatisDataMode.Abnormal:
                    properties = new string[]
				{
					"ExamId",
					"ExamName",
					"Room",
					"ExamSeatNumber",
					"BatchID",
					"Error",
					"Error_Origin",
					"StudentName",
					"Schoolnumber",
					"Schoolnumber_Origin",
					"Omr",
					"Omr_origin",
					"ImageName",
					"ScanTime"
				};
                    fieldNames = new string[]
				{
					"考试编号",
					"考试名称",
					"考场",
					"座位号",
					"扫描批次号",
					"当前状态",
					"初始识别状态",
					"学生姓名",
					"匹配考号",
					"考号识别结果",
					"客观题答案",
					"客观题识别结果",
					"图片名称",
					"扫描时间"
				};
                    text = "异常卷详情";

                    break;
                case StatisDataMode.ZkzhNotMatch:
                    properties = new string[]
				{
					"ExamId",
					"ExamName",
					"Room",
					"ExamSeatNumber",
					"Error",
					"Error_Origin",
					"StudentName",
					"Schoolnumber",
					"Schoolnumber_Origin",
					"SchoolNumberErrorType",
					"ImageName",
					"ScanTime"
				};
                    fieldNames = new string[]
				{
					"考试编号",
					"考试名称",
					"考场",
					"座位号",
					"当前状态",
					"初始识别状态",
					"学生姓名",
					"匹配考号",
					"考号识别",
					"异常分析",
					"图片名称",
					"扫描时间"
				};
                    text = "考号异常卷已处理详情";

                    break;
                case StatisDataMode.OmrManualSave:
                    properties = new string[]
				{
					"ExamId",
					"ExamName",
					"Room",
					"ExamSeatNumber",
					"Error",
					"Error_Origin",
					"StudentName",
					"Schoolnumber_MatchStatus",
					"Omr",
					"Omr_origin",
					"OMr_ErrorType",
					"ImageName",
					"ScanTime"
				};
                    fieldNames = new string[]
				{
					"考试编号",
					"考试名称",
					"考场",
					"座位号",
					"当前状态",
					"初始识别状态",
					"学生姓名",
					"匹配考号",
					"客观题答案",
					"客观题识别",
					"异常分析",
					"图片名称",
					"扫描时间"
				};
                    text = "客观题异常卷已处理详情";

                    break;
            }

            return new StaticsData<StudentInfo>(list, properties, fieldNames)
            {
                SheetName = text,
                FileName = ScanGlobalInfo.ExamInfo.ExamName + text
            };
        }

        /// <summary>
        /// 生成扫描记录数据
        /// </summary>
        /// <param name="scanreccord">扫描记录</param>
        /// <param name="mode">静态数据模式</param>
        /// <returns>学生信息列表</returns>
        public static List<StudentInfo> GenerateDataFromScanRecord(SynchronizedCollection<ScanRecord> scanreccord, StatisDataMode mode = StatisDataMode.All)
        {
            List<StudentExamInfo> studentExamInfoList = ScanGlobalInfo.ExamInfo.StudentExamInfoList;
            List<StudentInfo> list = new List<StudentInfo>();

            for (int i = 0; i < scanreccord.Count; i++)
            {
                ScanRecord record = scanreccord[i];
                StudentInfo studentInfo = new StudentInfo();

                studentInfo.ExamId = record.ExamId;
                studentInfo.ExamName = record.BatchNo;

                StudentExamInfo studentExamInfo = null;

                if (!(record.EsId > 0))
                {
                    studentExamInfo = studentExamInfoList.Find((StudentExamInfo p) => p.ID == record.EsId);
                }
                else if (!string.IsNullOrEmpty(record.Zkzh))
                {
                    studentExamInfo = studentExamInfoList.Find((StudentExamInfo p) => p.ExamCode.ToString() == record.Zkzh);
                }
                if (studentExamInfo != null)
                {
                    studentInfo.StudentName = studentExamInfo.StuName;
                }
                if (string.IsNullOrEmpty(record.Zkzh))
                {
                    record.Zkzh = "";
                }
                if (string.IsNullOrEmpty(record.Zkzh_origin))
                {
                    record.Zkzh_origin = "";
                }

                studentInfo.Schoolnumber = record.Zkzh;
                studentInfo.Schoolnumber_Origin = record.Zkzh_origin;

                if (string.IsNullOrEmpty(record.Zkzh_origin) || record.Zkzh.Trim().TrimStart(new char[]
				{
					'0'
				}) != record.Zkzh_origin.Trim().TrimStart(new char[]
				{
					'0'
				}) || record.Zkzh_origin.Contains("-") || record.VolumnStatus.Contains("4"))
                {
                    studentInfo.IsSchoolNumberError = "是";

                    if (string.IsNullOrEmpty(record.Zkzh_origin) || record.Zkzh_origin.Contains("-"))
                    {
                        studentInfo.SchoolNumberErrorType = "考号不可识别";
                    }
                    else
                    {
                        studentInfo.SchoolNumberErrorType = "错号";
                    }
                }
                else
                {
                    studentInfo.IsSchoolNumberError = "否";
                    studentInfo.SchoolNumberErrorType = "考号正确";
                }
                if (!string.IsNullOrEmpty(record.OmrStr2))
                {
                    studentInfo.Omr = record.OmrStr.Trim();
                    studentInfo.Omr_origin = record.OmrStr2.Trim().Replace(' ', ',').Trim();

                    if (record.modified)
                    {
                        studentInfo.Omr_ManualSave = "是";

                        if (studentInfo.Omr_origin.Contains("-"))
                        {
                            studentInfo.OMr_ErrorType = "空填涂";
                        }
                        else
                        {
                            studentInfo.OMr_ErrorType = "模糊填涂";
                        }
                    }
                    else
                    {
                        studentInfo.Omr_ManualSave = "否";
                    }
                }

                studentInfo.ScanTime = record.ScanTime.ToString();
                studentInfo.VolumnStatus = record.VolumnStatus;
                studentInfo.VolumnStatus_Origin = record.VolumnStatus_origin;
                studentInfo.Error = StatisticsBLL.ChangeStatusStringCodeToText(record.VolumnStatus);
                studentInfo.Error_Origin = StatisticsBLL.ChangeStatusStringCodeToText(record.VolumnStatus_origin);
                studentInfo.ImageName = record.Files;
                studentInfo.BatchID = record.BatchID;

                list.Add(studentInfo);
            }

            return StatisticsBLL.FilterDataByMode(list, mode);
        }

        /// <summary>
        /// 根据模式过滤数据
        /// </summary>
        /// <param name="dataToExport">导出数据</param>
        /// <param name="mode">模式</param>
        /// <returns>学生信息列表</returns>
        public static List<StudentInfo> FilterDataByMode(List<StudentInfo> dataToExport, StatisDataMode mode)
        {
            switch (mode)
            {
                case StatisDataMode.Normal:
                    dataToExport = dataToExport.FindAll((StudentInfo p) => p.VolumnStatus.Contains("0") || p.VolumnStatus.Contains("1"));

                    break;
                case StatisDataMode.Abnormal:
                    dataToExport = dataToExport.FindAll((StudentInfo p) => !p.VolumnStatus.Contains("0") && !p.VolumnStatus.Contains("1"));

                    break;
                case StatisDataMode.ZkzhNotMatch:
                    dataToExport = dataToExport.FindAll((StudentInfo p) => p.IsSchoolNumberError == "是" && (!p.VolumnStatus.Contains("2") && !p.VolumnStatus.Contains("3")) && !p.VolumnStatus.Contains("4")).ToList<StudentInfo>();

                    break;
                case StatisDataMode.OmrManualSave:
                    dataToExport = dataToExport.FindAll((StudentInfo p) => p.Omr_ManualSave == "是").ToList<StudentInfo>();

                    break;
            }

            return dataToExport;
        }

        /// <summary>
        /// 根据文本改变状态字符编码
        /// </summary>
        /// <param name="statusText">状态文本</param>
        /// <returns>状态字符串</returns>
        private static string ChangeStatusStringCodeToText(string statusText)
        {
            if (!string.IsNullOrEmpty(statusText))
            {
                statusText = statusText.Replace("0", "已上传").Replace("1", "正常").Replace("2", "考号不可识别").Replace("3", "重号").Replace("4", "错号").Replace("5", "页不可定位").Replace("6", "缺页").Replace("7", "客观题存疑").Replace("8", "后台处理客观题存疑").Replace("9", "重叠卷").Replace("10", "原图加载失败");
            }
            else
            {
                statusText = "未记录";
            }
            return statusText;
        }
    }

}

