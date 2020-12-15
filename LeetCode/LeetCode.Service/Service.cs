using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Service
{
    public partial class Service
    {
        #region 
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var s = l1.next;
            return l1;
        }
        #endregion

        /// <summary>
        /// 删除排序数组中的重复项
        /// 给定一个排序数组，你需要在 原地 删除重复出现的元素，使得每个元素只出现一次，返回移除后数组的新长度。
        /// 不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。
        /// </summary>
        /// https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
