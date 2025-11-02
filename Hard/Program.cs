using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            int[] nums1 = new int[0] { };
            int[] nums2 = new int[2] {2, 3 };
            Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
        }
        public static double? FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length, len2 = nums2.Length;

            if (len1 > len2)
                return FindMedianSortedArrays(nums2, nums1);
            if (len1 == 0)
            {
                if (len2 == 0)
                    throw new InvalidOperationException("Input arrays are empty.");
                else
                    return len2 % 2 == 1 ? nums2[len2 / 2] : (nums2[len2 / 2 - 1] + nums2[len2 / 2]) / 2.0;
            }

            int left = 0, right = len1;

            int maxL1, maxL2, minR1, minR2;

            while (left <= right)
            {

                int pointer1 = (left + right) / 2;
                int pointer2 = (len1 + len2 + 1) / 2 - pointer1;

                maxL1 = (pointer1 == 0) ? int.MinValue : nums1[pointer1 - 1];
                minR1 = (pointer1 == len1) ? int.MaxValue : nums1[pointer1];
                maxL2 = (pointer2 == 0) ? int.MinValue : nums2[pointer2 - 1];
                minR2 = (pointer2 == len2) ? int.MaxValue : nums2[pointer2];

                if (maxL1 <= minR2 && maxL2 <= minR1)
                {
                    int maxL = maxL1 > maxL2 ? maxL1 : maxL2;
                    int minR = minR1 < minR2 ? minR1 : minR2;

                    return (len1 + len2) % 2 == 1 ? maxL : (maxL + minR) / 2.0;
                }
                else
                {
                    if (maxL1 > minR2)
                        right = pointer1 - 1;
                    else left = pointer1 + 1;
                }
            }

            throw new InvalidOperationException("Input arrays not sorted or invalid.");
        }
    }
}
