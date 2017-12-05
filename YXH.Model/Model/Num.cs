using System;
using System.Drawing;

namespace YXH.Model
{
    /// <summary>
    /// 题号定义
    /// </summary>
    public class Num : IComparable<Num>
    {
        /// <summary>
        /// 当前题号
        /// </summary>
        public int number;
        /// <summary>
        /// 当前题号显示的坐标点
        /// </summary>
        public Point pos;

        /// <summary>
        /// 构造方法
        /// </summary>
        public Num() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="num">编号</param>
        /// <param name="p">编号所在点</param>
        public Num(int num, Point p)
        {
            this.number = num;
            this.pos = p;
        }

        /// <summary>
        /// 比较编号
        /// </summary>
        /// <param name="obj">比较对象</param>
        /// <returns>相对值</returns>
        public int CompareTo(Num obj)
        {
            return this.number.CompareTo(obj.number);
        }
    }
}
