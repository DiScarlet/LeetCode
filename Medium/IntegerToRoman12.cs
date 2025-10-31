using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IntToRoman(3749));
        }

        public static string IntToRoman(int num)
        {
            string[] romanNumeralsArr = new string[] { "IV", "XL", "CD", "M" };

            int digit;
            int powerOfTen = 0;
            string romanResult = "";
            string toAdd = "";
            bool isNotEnded = true;

            while (isNotEnded)
            {
                digit = num % 10;

                if (digit == 4)
                {
                    toAdd = romanNumeralsArr[powerOfTen];
                }
                else if (digit == 9)
                {
                    toAdd = "" + romanNumeralsArr[powerOfTen][0] + romanNumeralsArr[powerOfTen + 1][0];
                }

                else if (digit >= 5)
                {
                    toAdd = "" + romanNumeralsArr[powerOfTen][1] + GetDuplicateSymbol(romanNumeralsArr[powerOfTen][0], digit - 5);
                }
                else
                {
                    toAdd = GetDuplicateSymbol(romanNumeralsArr[powerOfTen][0], digit);
                }

                romanResult = toAdd + romanResult;

                powerOfTen++;
                num = (num - digit) / 10;
                if (num <= 0) isNotEnded = false;
            }

            return romanResult;
        }
        public static string GetDuplicateSymbol(char symbol, int amountToIterate)
        {
            string result = "";
            for (int i = 0; i < amountToIterate; i++)
            {
                result += symbol;
            }

            return result;
        }

    }
}
