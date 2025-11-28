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
            //Console.WriteLine(123456789 * 987654321);
            Console.WriteLine(Multiply("123456789", "987654321")); 
        }

        public static string Multiply(string num1, string num2)
        {
            string result = "";
            if (num1 == "0" || num2 == "0")
                return "0";
            for(int i = num2.Length - 1;  i >= 0; i--)
            {
                string partial = MultiplyByDigit(num1, num2[i] - 48);
                int ind = i;
                partial += new string('0', num2.Length - 1 - i);
                result = AddStrings(result, partial);
            }
            return result;
        }

        public static string MultiplyByDigit(string num1, int multiplyer)
        {
            int carry = 0;
            StringBuilder result = new StringBuilder();
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int digit = num1[i] - '0';
                int curMultRes = digit * multiplyer + carry;

                carry = curMultRes / 10;
                int digitToAdd = curMultRes % 10;

                result.Insert(0, digitToAdd);
            }
            if (carry > 0)
                result.Insert(0, carry.ToString());

            return result.ToString();
        }


        public static string AddStrings(string a, string b)
        {
            StringBuilder result = new StringBuilder();
            int carry = 0;
            int i = a.Length - 1, j = b.Length - 1;
            while (i >= 0 || j >= 0 || carry > 0)
            {
                int digit1 = i >= 0 ? a[i] - '0' : 0;
                int digit2 = j >= 0 ? b[j] - '0' : 0;
                int sum = digit1 + digit2 + carry;
                carry = sum / 10;
                result.Insert(0, sum % 10);
                i--;
                j--;
            }
            return result.ToString();
        }
    }
}
