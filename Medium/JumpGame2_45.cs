using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            int[] array = new int[] { 2, 0 };
            Console.WriteLine(Jump(array));
        }

        public static int Jump(int[] nums)
        {
            if(nums.Length == 1) 
                return 0;
            return JumpBottomUp(nums);
        }

       /* public static int JumpTopDown(int[] nums, int stack, int curInd)
        {
            int minSteps = -1;

            if (curInd == nums.Length - 1)
                return stack;

            for (int i = 1; i <= nums[curInd]; i++)
            {
                int curSteps;
                if (curInd + i < nums.Length)
                    curSteps = JumpTopDown(nums, stack + 1, curInd + i);
                else
                    break;

                if ((minSteps == -1 || minSteps > curSteps) && curSteps != -1)
                    minSteps = curSteps;
            }

            return minSteps;
        }*/

        public static int JumpBottomUp(int[] nums)
        {
            int jumps = 0, nextInd = 0, nextMaxSteps = -1, curDiff = 0;

            for(int i = 0; i < nums.Length;)
            {
                for(int j = nums[i]; j >= 1; j--)
                {
                    if (i + j >= nums.Length - 1)
                        return ++jumps;

                    int curNextMaxSteps = nums[i + j] - curDiff;

                    if(curNextMaxSteps > nextMaxSteps)
                    {
                        nextMaxSteps = curNextMaxSteps;
                        nextInd = i + j;
                    }
                    curDiff++;
                }
                i = nextInd;
                jumps++;
                nextMaxSteps = -1;
                curDiff = 0;
            }

            return jumps;
        }
    }
}
