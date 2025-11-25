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
            char[][] board = new char[][]
            {
                   new char[] { '.', '2', '.', '.', '.', '5', '.', '.', '.' },
                   new char[] { '.', '.', '.', '.', '.', '4', '.', '.', '.' },
                   new char[] { '.', '.', '.', '9', '.', '.', '7', '.', '.' },
                   new char[] { '.', '.', '8', '.', '.', '.', '.', '.', '.' },
                   new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                   new char[] { '.', '.', '.', '.', '7', '4', '3', '.', '9' },
                   new char[] { '.', '.', '.', '.', '.', '.', '9', '.', '.' },
                   new char[] { '.', '7', '.', '.', '6', '.', '.', '.', '5' },
                   new char[] { '3', '.', '.', '7', '.', '.', '.', '.', '.' }
            };

            Console.WriteLine(IsValidSudoku(board));
        }

        public static bool IsValidSudoku(char[][] board)
        {
            int totalLen = board.Length;
            for (int row = 0; row < totalLen; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    char rowItemV = board[row][col];
                    char colItemV = board[col][row];

                    if (rowItemV != '.')
                    {
                        bool rowRes = CheckIfRowContains(board[row], col);
                        if (rowRes)
                            return false;
                    }
                    if (colItemV != '.')
                    {
                        bool colRes = CheckIfColContains(board, row, col);
                        if (colRes)
                            return false;
                    }
                }
            }

            for (int row = 0; row < totalLen; row += 3)
            {
                for (int col = 0; col < board[row].Length; col += 3)
                {
                    if (!CheckMiniSquareValidity(board, row, col))
                        return false;
                }
            }

            return true;
        }

        public static bool CheckIfRowContains(char[] array, int targetInd)
        {
            int len = array.Length;
            if (targetInd == len - 1)
                return false;

            char targetV = array[targetInd];
            for (int i = targetInd + 1; i < len; i++)
            {
                if (array[i] != '.')
                {
                    if (array[i] == targetV)
                        return true;
                }
            }
            return false;
        }

        public static bool CheckIfColContains(char[][] arr, int colInd, int rowInd)
        {
            if (rowInd == arr.Length - 1)
                return false;
            char target = arr[rowInd][colInd];

            for (int row = rowInd + 1; row < arr.Length; row++)
            {
                char val = arr[row][colInd];

                if (val != '.')
                {
                    if (val == target)
                        return true;
                }
            }
            return false;
        }

        public static bool CheckMiniSquareValidity(char[][] arr, int sqRow, int sqCol)
        {
            const int miniRowLen = 3;
            const int miniColLen = 3;

            HashSet<char> square = new HashSet<char>();

            for (int itemRow = sqRow; itemRow < sqRow + miniRowLen; itemRow++)
            {
                for (int itemCol = sqCol; itemCol < sqCol + miniColLen; itemCol++)
                {
                    char item = arr[itemRow][itemCol];

                    if (item != '.')
                    {
                        if (square.Contains(item))
                            return false;
                        square.Add(item);
                    }
                }
            }
            return true;
        }
    }
}
