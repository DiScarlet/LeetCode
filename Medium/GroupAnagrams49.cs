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
            string[] strArr = new string[] { "a" };
            Print(GroupAnagrams(strArr));
        }

        public static void Print(IList<IList<string>> result)
        {
            foreach (var anagram in result)
            {
                foreach (var word in anagram)
                {
                    Console.WriteLine(word + " ");
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            PopulateDictionary(strs, dict);
            return GetAnagrams(strs, dict);
        }

        public static void PopulateDictionary(string[] strArr, Dictionary<int, List<int>> dict)
        {
            for (int i = 0; i < strArr.Length; i++)
            {
                int sortedHash = new string(strArr[i].OrderBy(c => c).ToArray()).GetHashCode();

                if (dict.ContainsKey(sortedHash))
                    dict[sortedHash].Add(i);
                else
                    dict[sortedHash] = new List<int> { i };
            }
        }

        public static IList<IList<string>> GetAnagrams(string[] strArr, Dictionary<int, List<int>> dict)
        {
            IList<IList<string>> result = new List<IList<string>>();

            foreach (var values in dict.Values)
            {
                List<string> anagram = new List<string>();
                foreach (var value in values)
                {
                    anagram.Add(strArr[value]);
                }
                result.Add(anagram);
            }
            return result;
        }
    }
}
