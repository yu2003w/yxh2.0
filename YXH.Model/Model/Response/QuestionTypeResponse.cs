using System.Collections.Generic;
using YXH.HttpHelper.Response;

namespace YXH.Model
{
    /// <summary>
    /// 模板试题类型api返回接收类
    /// </summary>
    public class QuestionTypeResponse : ApiResponse<List<QuestType>>
    {
        /// <summary>
        /// 有返回包装的构造方法
        /// </summary>
        /// <param name="qtList">试题类型泛型</param>
        public QuestionTypeResponse(List<QuestType> qtList)
            : base(qtList)
        {
        }

        /// <summary>
        /// 基础构造方法
        /// </summary>
        public QuestionTypeResponse()
        {
        }
    }
}
