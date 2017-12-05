using YXH.Model;
using YXH.Common;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 模板帮助类
    /// </summary>
    public class TemplateHelper
    {
        /// <summary>
        /// 将实体序列化为xml文件
        /// </summary>
        /// <param name="filePath">xml文件路径</param>
        /// <param name="info">实体类</param>
        public static void Serialize(string filePath, TemplateInfo info)
        {
            FileHelper.SeriXmlModel<TemplateInfo>(filePath, info);
        }

        /// <summary>
        /// 将xml文件序列化为模板信息实体
        /// </summary>
        /// <param name="filePath">xml文件路径</param>
        /// <returns>模板信息</returns>
        public static TemplateInfo Deserialize(string filePath)
        {
            return FileHelper.DeseriXmlModel<TemplateInfo>(filePath);
        }

        /// <summary>
        /// 获取学号的omr字符串
        /// </summary>
        /// <param name="info">omr学号信息</param>
        /// <returns>包含学号的的字符串</returns>
        public static string GetSchoolNumOmrString(OmrSchoolNumber info)
        {
            string text = string.Empty;

            foreach (CvRect[] current in info.omrs)
            {
                string text2 = "[";
                CvRect[] array = current;

                for (int i = 0; i < array.Length; i++)
                {
                    CvRect cvRect = array[i];
                    object obj = text2;

                    text2 = string.Concat(new object[]
					{
						obj,
						cvRect.x,
						",",
						cvRect.y,
						",",
						cvRect.width,
						",",
						cvRect.height,
						";"
					});
                }

                text2 += "]";
                text += text2;
            }

            return text;
        }

        /// <summary>
        /// 获取客观题的OMR字符串
        /// </summary>
        /// <param name="info">客观题信息</param>
        /// <returns>客观题信息字符串</returns>
        public static string GetObjectiveOmrString(OmrObjective info)
        {
            string text = string.Empty;
            OmrObjectiveItem[] objectiveItems = info.objectiveItems;

            for (int i = 0; i < objectiveItems.Length; i++)
            {
                OmrObjectiveItem omrObjectiveItem = objectiveItems[i];
                string text2 = "[" + omrObjectiveItem.num.number + ":";
                CvRect[] itemRects = omrObjectiveItem.ItemRects;

                for (int j = 0; j < itemRects.Length; j++)
                {
                    CvRect cvRect = itemRects[j];
                    object obj = text2;

                    text2 = string.Concat(new object[]
					{
						obj,
						cvRect.x,
						",",
						cvRect.y,
						",",
						cvRect.width,
						",",
						cvRect.height,
						";"
					});
                }

                text2 += "]";
                text += text2;
            }

            return text;
        }
    }
}
