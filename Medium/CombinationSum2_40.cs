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
            Print(CombinationSum2(new int[] { }, 27));
        }

        public static void Print(IList<IList<int>> res)
        {
            foreach (var list in res)
            {
                foreach (var item in list)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> result = new List<IList<int>>();
            return Backtrack(candidates, new List<int>(), 0, 0, target, result);

        }
        public static IList<IList<int>> Backtrack(int[] candidates, List<int> current, int start, int sum, int target, IList<IList<int>> result)
        {
            if (sum == target)
            {
                result.Add(new List<int>(current));
                return result;
            }

            for(int i = start ; i < candidates.Length; i++)
            {
                int candidate = candidates[i];

                if(i != 0)
                {
                    if (candidate == candidates[i - 1] && i > start)
                        continue;
                }

                current.Add(candidate);
                Backtrack(candidates, current, i + 1, sum + candidate, target, result);
                current.RemoveAt(current.Count - 1);
            }
            return result;
        }
    }
}
