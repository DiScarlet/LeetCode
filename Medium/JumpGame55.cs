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
            int[] array = new int[] { 3, 2, 1, 0, 4 };
            Console.WriteLine(CanJump(array));
        }

        public static bool CanJump(int[] nums)
        {
            if (nums[0] == 0 && nums.Length == 1)
                return true;

            List<int> result = FindValueInArray(0, nums);

            if (result.Count == 0)
                return true;
            if (result[0] == 0)
                return false;

            foreach (var index in result)
            {
                if (CanJumpOverInd(index, nums) == false)
                    return false;
            }
            return true;
        }

        public static bool CanJumpOverInd(int index, int[] array)
        {
            int lengthBetween = 1;

            if (index == array.Length - 1)
                return true;

            for (int i = index - 1; i >= 0; i--)
            {
                if (lengthBetween < array[i])
                    return true;
                lengthBetween++;
            }
            return false;
        }

        public static List<int> FindValueInArray(int value, int[] array)
        {
            List<int> result = new List<int>();
            int ind = 0;

            foreach (int item in array)
            {
                if (value == item)
                    result.Add(ind);
                ind++;
            }
            return result;
        }
    }
}
