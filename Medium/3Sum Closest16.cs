using System;
using System.Collections.Generic;
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
            Console.WriteLine(ThreeSumClosest(new int[] { -100, -98, -2, -1 }, -101));
        }
        public static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);

            int len = nums.Length;

            if (len < 3)
                throw new ArgumentException("The array length must be >= 3");

            int lInd = 0, mInd = lInd + 1, rInd = len - 1;
            int lVal = nums[lInd], mVal = nums[mInd], rVal = nums[rInd];
            int sum = lVal + mVal + rVal;
            int delta = GetTotalDelta(sum, target);

            for (; lInd < len - 2; lInd++)
            {
                mInd = lInd + 1;
                rInd = len - 1;
                while (mInd < rInd)
                {
                    lVal = nums[lInd];
                    mVal = nums[mInd];
                    rVal = nums[rInd];

                    int curSum = lVal + mVal + rVal;

                    if (curSum == target)
                        return curSum;
                    if (curSum > target)
                    {
                        rInd--;
                        int curDelta = curSum - target; // shows the length between target and sum with the corresponding sign
                        if (curDelta < delta)
                        {
                            delta = curDelta;
                            sum = curSum;
                        }
                    }
                    else
                    {
                        mInd++;
                        int curDelta = target - curSum; // shows the length between target and sum with the corresponding sign

                        if (curDelta < delta)
                        {
                            delta = curDelta;
                            sum = curSum;
                        }
                    }
                }
            }

            return sum;
        }

        public static int GetTotalDelta(int sum, int target) // is always more than 0. shows real length between sum and target
        {
            if ((target >= 0 && sum >= 0) || (target < 0 && sum < 0))
            {
                return Math.Abs(target - sum);
            }
            if (target >= 0 && sum < 0)
            {
                return target - sum;
            }
            else
            {
                return sum - target;
            }
        }
    }
}
