using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            string dirs = "/a/./b/../../c/";
            Console.WriteLine(SimplifyPath2(dirs));
        }

        public static string SimplifyPath1(string path)
        {
            IList<string> result = new List<string> { };
            string[] directories = path.Split('/');

            for (int i = 0; i < directories.Length; i++)
            {
                string dir = directories[i];
                if (dir != "")
                {
                    if (dir == ".")
                        continue;
                    else if (dir == "..")
                    {
                        if (result.Count > 1)
                            result.RemoveAt(result.Count - 1);
                    }
                    else
                        result.Add(dir + "/");
                }
            }

            if(result.Count > 1) 
                result[result.Count - 1] = result[result.Count - 1].Remove(result[result.Count - 1].Length - 1, 1);

            return string.Join("", result);
        }

        public static string SimplifyPath2(string path)
        {
            IList<string> result = new List<string> { };
            string[] directories = path.Split('/');

            for (int i = 0; i < directories.Length; i++)
            {
                string dir = directories[i];
                if (dir != "")
                {
                    if (dir == ".")
                        continue;
                    else if (dir == "..")
                    {
                        if (result.Count > 0)
                            result.RemoveAt(result.Count - 1);
                    }
                    else
                        result.Add(dir);
                }
            }

            return string.Join("/", result).Insert(0, "/");
        }
    }
}
