using System;
using System.Collections;
using System.Collections.Generic;
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
            Console.WriteLine(MyPow(2, -2));
        }

        public static double MyPowV1(double x, int n)
        { 
            if (n == 0)
            {
                return 1.0;
            }
            double oldX = x;
            bool isPowNegative = n < 0 ? true : false;
            if (isPowNegative)
                n = - n;
            for (; n > 1; n--)
            {
                x *= oldX;
            }
            if (isPowNegative)
                x = 1 / x;
            return x;
        } // slow implementation


        public static double MyPow(double x, int n)
        {
            Dictionary<int, double> dict = new Dictionary<int, double>();

            dict[0] = 1;
            dict[1] = x;

            return n < 0 ? 1 / MyPowTopDown(x, n, dict) : MyPowTopDown(x, n, dict);
        }
        public static double MyPowTopDown(double x, int n, Dictionary<int, double> dict)
        {
            if (!dict.ContainsKey(n))
            {
                int newN = n / 2;
                double half = MyPowTopDown(x, newN, dict);
                dict[n] = half * half * (n % 2 == 0 ? 1 : x);
            }

            return dict[n];
        }
       /* public static int GetElementOfFibonaci(int n, Dictionary<int, int> dict)
        {
            if (n == 1)
                return 0;
            if (n == 2)
                return 1;

            if(!dict.ContainsKey(n))
                dict[n] =  GetElementOfFibonaci(n - 2, dict) + GetElementOfFibonaci(n - 1, dict);

            return dict[n];
        }*///same problem
    }
}
