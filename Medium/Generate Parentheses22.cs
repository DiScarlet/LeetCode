using System;
using System.Collections.Generic;
using System.Data;
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
            int n = 4;
            List<string> result = new List<string>();
            Print(GetValidParenthesis("", n, n, result, n));
        }

        public static void Print(IList<string> result)
        {
            int counter = 0;
            foreach (var item in result)
            {
                Console.WriteLine(++counter + item);
            }
        }
        public static IList<string> GenerateParenthesis(int n)
        {
            //n handling
            if (n < 1)
                throw new ArgumentOutOfRangeException();
            List<string> result = new List<string>();

            return GetValidParenthesis("", n, n, result, n);
        }
        public static IList<string> GetValidParenthesis(string currentSq, int leftOpen, int leftClose, List<string> result, int n)
        {
            if (leftOpen > 0)
                GetValidParenthesis(currentSq + "(", leftOpen - 1, leftClose, result, n);
            if (leftClose > 0 && leftClose > leftOpen)
                GetValidParenthesis(currentSq + ")", leftOpen, leftClose - 1, result, n);
            if (leftOpen == 0 && leftClose == 0)
                result.Add(currentSq);

            return result;
        }
    }
}
