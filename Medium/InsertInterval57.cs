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

        }
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int start = -1, end = -1;
            int a = newInterval[0], b = newInterval[1];
            IList<int[]> resList = new List<int[]>();
            bool mergedInserted = false;

            for (int i = 0; i < intervals.Length; i++)
            {
                if (intervals[i][1] < a)
                {
                    resList.Add(intervals[i]);
                }

                else if (intervals[i][0] <= b && intervals[i][1] >= a)
                {
                    if (start == -1)
                        start = i;
                    end = i;
                }

                else if (intervals[i][0] > b)
                {
                    if (!mergedInserted)
                    {
                        if (start != -1 && end != -1)
                        {
                            resList.Add(new int[] { Math.Min(a, intervals[start][0]), Math.Max(b, intervals[end][1]) });
                        }
                        else
                        {
                            resList.Add(new int[] { a, b });
                        }
                        mergedInserted = true;
                    }
                    resList.Add(intervals[i]);
                }
            }

            if (!mergedInserted)
            {
                if (start != -1 && end != -1)
                    resList.Add(new int[] { Math.Min(a, intervals[start][0]), Math.Max(b, intervals[end][1]) });
                else
                    resList.Add(new int[] { a, b });
            }

            return resList.ToArray();
        }
    }
}
