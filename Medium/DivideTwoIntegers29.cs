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
            Console.WriteLine(Divide(2147483647, 2));
        }
        public static int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException();

            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            bool isPositive = (dividend >= 0 && divisor > 0) || (dividend < 0 && divisor < 0) ? true : false;

            int dividendAbs = Math.Abs(dividend);
            int divisorAbs = Math.Abs(divisor);

            int result = Math.Max(Int32.MinValue, Math.Min(Int32.MaxValue, DivideModV2(dividendAbs, divisorAbs)));
            if (isPositive)
            {
                return result;
            }
            else
            {
                return -result;
            }    
        }

        public static int DivideModV2(int dividend, int divisor)
        {
            int quotient = 0;

            while (dividend >= divisor)
            {
                int currentDivisor = divisor;
                int currentMultiplyer = 1;

                while (dividend >= currentDivisor)
                {
                    dividend -= currentDivisor;
                    quotient += currentMultiplyer;
                    currentDivisor += currentDivisor;
                    currentMultiplyer += currentMultiplyer;
                }
            }

            return quotient;
        }

        public static int DivideModV1(int dividend, int divisor)
        {
            int quotient = 0;

            while (dividend >= divisor)
            {
                dividend -= divisor;
                quotient++;
            }

            return quotient;
        }
    }
}
