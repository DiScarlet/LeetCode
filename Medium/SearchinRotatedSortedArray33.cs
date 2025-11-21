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
            int[] nums = { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
            int target = 25;
            Console.WriteLine(Search(nums, target));
        }

        public static void Print(int[] nums)
        {
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        public static int GetFirstMinInd(int[] nums)
        {
            int length = nums.Length;
            if (nums[0] < nums[length - 1])
                return 0;

            int mediumInd = length / 2;
            int borderInd = length - 1;

            while (true)
            {
                if (mediumInd == borderInd)
                    return mediumInd;

                int mediumVal = nums[mediumInd];
                int borderVal = nums[borderInd];
                int newLen = borderInd - mediumInd + 1;

                if (mediumVal < borderVal)
                {
                    borderInd = mediumInd;
                    mediumInd -= newLen / 2;
                    //if (nums[mediumInd] > nums[borderInd])
                    if (nums[mediumInd] > nums[borderInd] && borderInd - 1 == mediumInd)
                         //return borderInd;
                        return borderInd;
                }
                else
                {
                    mediumInd += newLen / 2;
                }
            }
        }

        public static int GetTargetIndBinarySearch(int[] nums, int start, int end, int target)
        {
            int length = end - start + 1;

            if (length == 1)
                return nums[start] == target ? start : -1;

            int mediumInd = length / 2 + start;
            int borderInd = start;
            if (target > nums[mediumInd])
            {
                borderInd = end;
            }
            else if(target < nums[mediumInd])
            {
                (borderInd, mediumInd) = (mediumInd, start);
            }
            else
            {
                return mediumInd;
            }

            while (true)
            {
                int mediumVal = nums[mediumInd];
                if (mediumVal == target)
                    return mediumInd;
                if (mediumInd == borderInd)
                    return -1;
                int newLength = borderInd - mediumInd + 1;
                if(target > mediumVal)
                {
                    mediumInd += newLength / 2;
                    if (mediumInd > end)
                        return -1;
                }
                else if(target < mediumVal)
                {
                    int oldMedium = mediumInd;
                     mediumInd -= newLength / 2;
                    if (mediumInd < start)
                        return -1;
                    borderInd = oldMedium;
                }
            }
        }

        public static int Search(int[] nums, int target)
        {
            int minInd = GetFirstMinInd(nums);

            int startInd = 0;
            int endInd = nums.Length - 1;
            bool full = true;

            if (minInd != 0)
            {
                if (target > nums[endInd])
                    endInd = minInd - 1;
                else if (target < nums[endInd])
                    startInd = minInd;
                else
                    return endInd;
                full = false;
            }

            int targetInd = -1;

            targetInd = GetTargetIndBinarySearch(nums, startInd, endInd, target);

            return targetInd;
        }
    }
}
