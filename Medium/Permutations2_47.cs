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
            int[] array = new int[] { 1, 1, 2 };
            Print(PermuteUnique(array));
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

        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
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
                if (i != 0)
                    if (numsToUse[i - 1] != numsToUse[i])
                    {
                        current.Add(numsToUse[i]);
                        numsToUse.RemoveAt(i);
                        PermuteTopDown(result, current, numsToUse);
                        numsToUse.Insert(i, current[current.Count - 1]);
                        current.RemoveAt(current.Count - 1); 
                    }
                if (i == 0)
                {
                    current.Add(numsToUse[i]);
                    numsToUse.RemoveAt(i);
                    PermuteTopDown(result, current, numsToUse);
                    numsToUse.Insert(i, current[current.Count - 1]);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
    }
}
