using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            int[][] matrix = new int[][] {
                new int[] { 1 },
                //new int[] { 5 },
               // new int[] { 9, 10, 11, 12 }
            };

            foreach(int number in SpiralOrder(matrix))
            {
                Console.WriteLine(number);
            }
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            int left = 0, right = matrix[0].Length - 1, top = 0, bottom = matrix.Length - 1;
            IList<int> result = new List<int>();

            if (matrix.Length == 1 && matrix[0].Length == 1)
                result.Add(matrix[0][0]);

            while (left < right || top < bottom)
            {
                if (left < right)
                {
                    for (int hor = left; hor <= right; hor++)
                    {
                        result.Add(matrix[top][hor]);
                    }
                    if (top >= bottom)
                        break;
                    top++;
                }
                if (top < bottom)
                {
                    for (int ver = top; ver <= bottom; ver++)
                    {
                        result.Add(matrix[ver][right]);
                    }
                    if (right <= left)
                        break;
                    right--;
                }

                if (left < right)
                {
                    for (int hor = right; hor >= left; hor--)
                    {
                        result.Add(matrix[bottom][hor]);
                    }
                    if (top >= bottom)
                        break;
                    bottom--;
                }
                if (top < bottom)
                {
                    for (int ver = bottom; ver >= top; ver--)
                    {
                        result.Add(matrix[ver][left]);
                    }
                    if (right <= left)
                        break;
                    left++;
                }
            }

            return result;
        }
    }
}
