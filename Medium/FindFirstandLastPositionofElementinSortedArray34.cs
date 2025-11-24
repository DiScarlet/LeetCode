using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            int[] nums = { 0, 0, 0, 0, 1, 1, 2, 3, 3, 3, 3, 4, 4, 6, 6, 7, 7, 7, 8 };
            int target = 4;
            Print(SearchRange(nums, target));
        }

        public static void Print(int[] nums)
        {
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            int length = nums.Length;
            if(length == 0)
                return new int[] { -1, -1 };
            if(length == 1)
                return nums[0] == target ? new int[] { 0, 0 } : new int[] { -1, -1 };
            int borderL = (length / 2) - 1 >= 0 ? 0 : (length / 2) - 1;
            int borderR = length - 1;
            int middleI = borderL + (borderR - borderL + 1) / 2;

            if (nums[borderL] == target)
            {
                return FindMinMax(nums, target, borderL);
            }
            else if (nums[middleI] > target) 
            {
                borderL = 0;
                borderR = length / 2;
                middleI = (borderR - borderL + 1) / 2;
            }

            int oldLen = borderR - borderL + 1;
            while (true)
            {
                int middleV = nums[middleI];

                if (middleV == target)
                    return FindMinMax(nums, target, middleI);

                int middleIOld = middleI;
                if (middleV < target)
                {
                    middleI += (borderR - middleI + 1) / 2;
                    borderL = middleIOld;
                }
                else if(middleV > target)
                {
                    middleI -= (middleI - borderL + 1) / 2;
                    borderR = middleIOld;
                }

                int newLen = borderR - borderL + 1;
                if (middleI > borderR || middleI < borderL || borderL >= borderR || oldLen == newLen)
                {
                    return new int[] { -1, -1 };
                }
                oldLen = newLen;
            }
        }

        public static int[] FindMinMax(int[] nums, int target, int indofTarget)
        {
            int bMinL = 0, bMinR = indofTarget, mMinI = (bMinR - bMinL + 1) / 2;
            int bMaxL = indofTarget, bMaxR = nums.Length - 1, mMaxI = bMaxL + (bMaxR - bMaxL + 1) / 2;
            bool stopMin = false, stopMax = false;
            int[] result = new int[] { -1, -1 };
            while(!stopMin || !stopMax)
            {   
                if (!stopMin)
                {
                    int mMinV = nums[mMinI];
                    int mMinOld = mMinI;
                    if (mMinV < target)
                    { 
                        mMinI += (bMinR - mMinI + 1) / 2;
                        bMinL = mMinOld;
                    }
                    else if(mMinV > target || (bMinL > bMinR && result[0] == -1))
                    {
                        stopMin = true;
                    }
                    else if(mMinV == target)
                    {
                        if (mMinI == 0)
                        {
                            result[0] = mMinI;
                            stopMin = true;
                        }
                        else if (mMinI != 0 && nums[mMinI - 1] != target )
                        {
                            result[0] = mMinI;
                            stopMin = true;
                        }
                        else
                        {
                            mMinI -= (mMinI - bMinL + 1) / 2;
                            bMinR = mMinOld;
                        }
                    }
                }

                if(!stopMax)
                {
                    int mMaxV = nums[mMaxI];
                    int mMaxOld = mMaxI;
                    if (mMaxV > target)
                    {
                        mMaxI -= (mMaxI - bMaxL + 1) / 2;
                        bMaxR = mMaxOld;
                    }
                    else if(mMaxV < target || (bMinL > bMinR && result[0] == -1))
                    {
                        stopMax = true;
                    }
                    else if (mMaxV == target)
                    {
                        if(mMaxI == nums.Length - 1)
                        {
                            result[1] = mMaxI;
                            stopMax = true;
                        }
                        else if(mMaxI != nums.Length - 1 && nums[mMaxI + 1] != target)
                        {
                            result[1] = mMaxI;
                            stopMax = true;
                        }
                        else
                        {
                            mMaxI += (bMaxR - mMaxI + 1) / 2;
                            bMaxL = mMaxOld;
                        }
                    }
                }
            }
            return result;
        }
    }
}
