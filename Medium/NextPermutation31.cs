using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            int[] nums = { 1, 3, 2 };
            NextPermutation(nums);
            Print(nums);
        }

        public static void Print(int[] nums)
        {
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        public static void NextPermutation(int[] nums)
        {
            int length = nums.Length;

            bool wasSorted = false;
            for (int i = length - 1; i > 0; i--)
            {
                int current = nums[i];
                int precurrent = nums[i - 1];
                if(precurrent < current)
                {
                    wasSorted = true;
                    (nums[i - 1], nums[FindIndOfNextBiggest(nums, i - 1)]) = (nums[FindIndOfNextBiggest(nums, i - 1)], nums[i - 1]);
                    Array.Sort(nums, i, length - i);
                    break;
                }
            }

            if(!wasSorted)
                Array.Reverse(nums);
        }

        public static int FindIndOfNextBiggest(int[] nums, int startInd)
        {
            int comparable = nums[startInd];
            int biggerInd = startInd + 1;

            int i = startInd + 1;
            for (; i < nums.Length; i++)
            {
                int current = nums[i];
                if (current < nums[biggerInd] && current > comparable)
                {
                    biggerInd = i;
                }
            }

            return biggerInd;
        }
    }
}
