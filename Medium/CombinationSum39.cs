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
            Print(CombinationSum(new int[] { 2, 3, 4, 6, 7 }, 7));
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

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            GetCombinations(0, new List<int>(), 0);
            void GetCombinations(int ind, List<int> current, int sum)
            {
                if(sum == target)
                {
                    result.Add(new List<int>(current));
                    return;
                }
                if(sum > target || ind >= candidates.Length)
                {
                    return;
                }

                current.Add(candidates[ind]);
                GetCombinations(ind, current, sum + candidates[ind]);
                current.RemoveAt(current.Count - 1);
                GetCombinations(ind + 1, current, sum);

                return;
            }
            return result;
        }
    }
}
