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
            int[] nums1 = new int[3] { 11, 12, 13};
            int[] nums2 = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(LongestPalindromeCenterPointers("babad"));
        }
        public static string LongestPalindromeTwoSidePointers(string s)
        {
            if (s.Length == 1)
                return s;

            int left = 0, right = s.Length - 1;
            string longestPalindrome = String.Empty;

            while (left < s.Length)
            {
                if (right - left > longestPalindrome.Length)
                {
                    while (right > left)
                    {
                        if (s[right] == s[left])
                            if (right - left + 1 > longestPalindrome.Length)
                            {
                                string pal1 = s.Substring(left, (right - left + 1) / 2);
                                int startInd2 = left + (int)Math.Ceiling((right - left + 1) / 2.0);
                                string pal2 = s.Substring(startInd2, right - startInd2 + 1);

                                if (pal1 == new string(pal2.Reverse().ToArray()))
                                {
                                    longestPalindrome = s.Substring(left, right - left + 1);
                                    break;
                                }
                            }
                        right--;
                    }
                }
                else
                    break;

                left++;
                right = s.Length - 1;
            }

            return longestPalindrome == String.Empty ? s[0].ToString() : longestPalindrome;
        }

        public static string LongestPalindromeCenterPointers(string s)
        {
            int len = s.Length;

            if (len == 1 || len == 0)
                return s;

            string maxPal = "";

            for(int i = 0; i < len; i++)
            {
                int oddLen = GetMaxLength(s, i, i);
                int evenLen = GetMaxLength(s, i, i + 1);

                int curMax = oddLen > evenLen ? oddLen : evenLen;

                if(curMax > maxPal.Length)
                {
                    maxPal = oddLen > evenLen ? s.Substring(i - curMax / 2, curMax) : s.Substring(i - curMax / 2 + 1, curMax);
                }
                if (curMax == len)
                    break;
            }

            return maxPal;
        }

        public static int GetMaxLength(string s, int left, int right)
        {
            while(left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }
    }
}
