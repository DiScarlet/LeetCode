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
            Console.WriteLine(MaxAreaMethod1(new int[] { 1, 2, 3 }));
            Console.WriteLine(MaxAreaMethod2(new int[] { 1, 2, 3 }));
        }

        public static int MaxAreaMethod1(int[] height)
        {
            int maxArea = 0;
            int len = height.Length;
            if (len == 0 || len == 1)
                return 0;

            for (int i = 0; i < len - 1; i++)
            {
                if (height[i] * (len - 1) > maxArea)
                    for (int j = len - 1; j > i; j--)
                    {
                        int h = height[i] < height[j] ? height[i] : height[j];
                        int w = j - i;

                        if (h < 0)
                            return 0;

                        int currentArea = h * w;

                        if (currentArea > maxArea)
                            maxArea = currentArea;
                    }
            }

            return maxArea;
        }

        public static int MaxAreaMethod2(int[] height)
        {
            int maxArea = 0;
            int len = height.Length;
            if (len == 0 || len == 1)
                return 0;

            for (int left = 0, right = len - 1; left < right;)
            {
                int w = right - left;
                int h;

                if (height[left] > height[right])
                {
                    h = height[right];
                    right--;
                }
                else
                {
                    h = height[left];
                    left++;
                }

                int curArea = w * h;
                if (curArea > maxArea)
                    maxArea = curArea;
            }
            return maxArea;
        }
    }
}
