using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine(UniquePaths(51, 9));
        }

        public static int UniquePaths(int m, int n)
        {
            Dictionary<(int, int), int> dict = new Dictionary<(int, int), int> ();
            return GetPascalNumber(m + n - 1, n, dict);
        }

        public static int GetPascalNumber(int m, int n, Dictionary<(int, int), int> dict)
        {
            if (m == 1 || n == 1 || m == n)
                return 1;

            int first, second;
            if (dict.ContainsKey((m - 1, n - 1)))
                first = dict[(m - 1, n - 1)];
            else
            {
                first = GetPascalNumber(m - 1, n - 1, dict);
                dict[(m - 1, n - 1)] = first;
            }

            if (dict.ContainsKey((m - 1, n)))
                second = dict[(m - 1, n)];
            else
            {
                second = GetPascalNumber(m - 1, n, dict);
                dict[(m - 1, n)] = second;
            }

            return first + second;
        }
    }
}
