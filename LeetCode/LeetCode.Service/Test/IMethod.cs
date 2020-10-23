using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Service.Test
{
    public interface IMethod
    {
        void run();
        /// <summary>
        /// 向数据库添加数据
        /// </summary>
        void AddData();
    }
}
