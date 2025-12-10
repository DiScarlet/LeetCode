using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Console.WriteLine(
                string.Join(" | ",
                    Merge(new int[][] {
                        new int[] { 1, 3 },
                        new int[] { 2, 6 },
                        new int[] { 8, 10 },
                        new int[] { 15, 18 }
                    })
                    .Select(arr => $"[{arr[0]}, {arr[1]}]")
                )
            );
        }

        public static int[][] Merge(int[][] intervals)
        {
            // It's important to sort the intervals by start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> res = new List<int[]>();

            int s = intervals[0][0];
            int f = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                int[] interval = intervals[i];
                if (interval[0] <= f)
                {
                    f = Math.Max(f, interval[1]);
                }
                else
                {
                    res.Add(new int[] { s, f });
                    s = interval[0];
                    f = interval[1];
                }
            }
            res.Add(new int[] { s, f }); 
            return res.ToArray();
        }
    }
}
