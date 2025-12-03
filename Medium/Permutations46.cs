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
            int[] array = new int[] { 1, 2, 3, 4 };
            Print(Permute(array));
        }

        public static void Print(IList<IList<int>> collection)
        {
            foreach (var list in collection)
            {
                foreach (var item in list)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            PermuteTopDown(result, new List<int>(), nums.ToList());
            return result;
        }

        public static void PermuteTopDown(IList<IList<int>> result, IList<int> current, IList<int> numsToUse)
        {
            if (numsToUse.Count == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = 0; i < numsToUse.Count; i++)
            {
                var nextCurrent = new List<int>(current) { numsToUse[i] };
                var nextNumsToUse = new List<int>(numsToUse);
                nextNumsToUse.RemoveAt(i);
                PermuteTopDown(result, nextCurrent, nextNumsToUse);
            }
        }
    }
}
