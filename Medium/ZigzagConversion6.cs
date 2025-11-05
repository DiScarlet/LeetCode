using System;
using System.Collections.Generic;
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
            string word = "PAYPALISHIRING";
            Console.WriteLine(ConvertMethod2(word, 3));
        }

        public static string ConvertMethod1(string s, int numRows)
        {
            if (s.Length == 0 || s.Length == 1 || s.Length <= numRows || numRows == 1)
                return s;

            char?[,] zigZag = CreateZigZagMatrix(s, numRows);
            return GetWordFromMatrix(zigZag);
        }

        public static int GetColumnsAmount(string s, int rows)
        {
            int len = s.Length;

            int singles = rows - 2;
            int fullCol = len / (rows + singles);
            int totalCol = fullCol + singles * fullCol;
            int remainder = len - (fullCol * rows + fullCol * singles);
            if (remainder > 0)
            {
                totalCol += remainder > rows ? (1 + remainder - rows) : 1;
            }

            return totalCol;
        }
        public static char?[,] CreateZigZagMatrix(string s, int rows)
        {
            int len = s.Length;

            int singles = rows - 2;
            int totalCol = GetColumnsAmount(s, rows);
            char?[,] zigZag = new char?[rows, totalCol];
            int counter = 0;

            for (int i = 0; i < totalCol && counter < len; i++)
            {
                int rowIndSingle = i % (singles + 1);
                if (rowIndSingle == 0)
                {
                    for(int j = 0; j < rows && counter < len; j++)
                    {
                        zigZag[j, i] = s[counter];
                        counter++;
                    }
                }
                else
                {
                    zigZag[rows - rowIndSingle - 1, i] = s[counter];
                    counter++;
                }
            }

            return zigZag;
        }

        public static string GetWordFromMatrix(char?[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char? symbol in matrix)
            {
                if(symbol != null)
                {
                    sb.Append(symbol);
                }
            }
            return sb.ToString();
        }

        public static string ConvertMethod2(string s, int rowsNum)
        {
            if (s.Length == 0 || s.Length == 1 || s.Length <= rowsNum || rowsNum == 1)
                return s;

            StringBuilder[] stringBuilders = new StringBuilder[rowsNum];

            for (int i = 0; i < stringBuilders.Length; i++)
            {
                stringBuilders[i] = new StringBuilder();
            }

            bool goingDown = false;
            int coulmnNumber = 0;
            for (int i = 0; i < s.Length; i++)
            {
                stringBuilders[coulmnNumber].Append(s[i]);

                if(i % (2 * rowsNum - 2) == 0 || i % (rowsNum - 1) == 0)
                {
                    goingDown = !goingDown;
                }

                coulmnNumber += goingDown ? 1 : -1;
            }

            StringBuilder result = new StringBuilder();
            foreach(var row in stringBuilders)
            {
                result.Append(row);
            }

            return result.ToString();
        }
    }
}
