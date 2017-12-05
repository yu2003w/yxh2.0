using System.Collections.Generic;
using ZKEMC.Model;

namespace ZKEMC.Scanner.IDAL
{
    /// <summary>
    /// 学校集合信息接口
    /// </summary>
    public interface ISchoolListInfoDAL
    {
        /// <summary>
        /// 获取联考学校信息
        /// </summary>
        /// <param name="examid">考试ID</param>
        /// <returns>联考学校列表</returns>
        IList<UnionExamSchoolInfo> GetUnionExamSchoolInfo(long examid);
    }
}
