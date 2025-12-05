using System;
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
            int[][] arr = 
                new int[][] {
                    new int[] { 0, 1, 2, 3, 4 },
                    new int[] { 5, 6, 7, 8, 9 },
                    new int[] { 10, 11, 12, 13, 14 },
                    new int[] { 15, 16, 17, 18, 19 },
                    new int[] { 20, 21, 22, 23, 24 }
                };

            Rotate(arr);
            Print(arr);
        }

        public static void Print(int[][] arr)
        {
            foreach (var array in arr)
            {
                foreach (var item in array)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Rotate(int[][] matrix)
        {
            int left = 0, right = matrix.Length - 1;

            while(left < right)
            {
                for(int i = 0; i < right - left; i++)
                {
                    int top = left, bottom = right;

                    int temp = matrix[top][left + i];

                    matrix[top][left + i] = matrix[bottom - i][left];
                    matrix[bottom - i][left] = matrix[bottom][right - i];
                    matrix[bottom][right - i] = matrix[top + i][right];
                    matrix[top + i][right] = temp;
                }
                right--;
                left++;
            }
        }
    }
}
