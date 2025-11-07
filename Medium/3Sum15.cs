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
            var result = ThreeSum(new int[] { -4, -2, -1 });
            if (result != null)
            {
                foreach (var triplet in result)
                {
                    Console.WriteLine(string.Join(", ", triplet));
                }
            }
            else
            {
                Console.WriteLine("No triplets found.");
            }
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> resultLists = new List<IList<int>>();
            Sort(nums, resultLists);

            int len = nums.Length;
            if (nums[0] >= 0 || nums[len - 1] <= 0)
                return resultLists;

            int lInd = 0, mInd = 1, rInd = len - 1;
            
            for (; nums[lInd] < 0; lInd++)
            {
                if (lInd > 0 && nums[lInd] == nums[lInd - 1])
                    continue;

                mInd = lInd + 1;
                rInd = len - 1;
                while(mInd < rInd)
                {
                    if (rInd != len - 1 && nums[rInd + 1] == nums[rInd])
                    {
                        rInd--;
                        continue;
                    }

                    int lVal = nums[lInd], mVal = nums[mInd], rVal = nums[rInd];
                    int sum = lVal + rVal + mVal;

                    if (sum == 0)
                    {
                        resultLists.Add(new List<int> { lVal, mVal, rVal });
                        rInd--;
                        mInd++;
                    }
                    else if (sum > 0)
                        rInd--;
                    else
                        mInd++;
                }
            }

            return resultLists;
        }

        public static void Sort(int[] arr, List<IList<int>> resultLists)
        {
            int zeroCounter = arr[0] == 0 ? 1 : 0;

            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                if (key == 0)
                    zeroCounter++;

                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }

            if (zeroCounter >= 3)
                resultLists.Add(new List<int> { 0, 0, 0 });
        }
    }
}
