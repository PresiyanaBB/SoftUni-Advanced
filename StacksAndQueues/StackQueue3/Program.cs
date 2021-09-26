using System;
using System.Collections.Generic;

namespace StackQueue3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string[] separator;
            int lines = int.Parse(Console.ReadLine());
            int maxMin;
            for (int i = 0; i < lines; i++)
            {
                separator = Console.ReadLine().Split();
                if (separator[0] == "1")
                {
                    stack.Push(int.Parse(separator[1]));
                }
                else if (separator[0] == "2")
                {
                    stack.Pop();
                }
                else if (separator[0] == "3")
                {
                    maxMin = 0;
                    foreach (var item in stack)
                    {
                        if (item > maxMin) maxMin = item;
                    }
                    if (stack.Count != 0) Console.WriteLine(maxMin.ToString());
                }
                else
                {
                    maxMin = 109;
                    foreach (var item in stack)
                    {
                        if (item < maxMin) maxMin = item;
                    }
                    if (stack.Count != 0) Console.WriteLine(maxMin.ToString());
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
