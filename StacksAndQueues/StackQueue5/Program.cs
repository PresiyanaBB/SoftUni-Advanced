using System;
using System.Collections.Generic;
using System.Linq;

namespace StackQueue5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int racks = 1;

            for (int i = 0; i < firstLine.Length; i++)
            {
                stack.Push(firstLine[i]);
            }
            for (int i = 0; i < firstLine.Length; i++)
            {
                if (stack.Peek() + sum > capacity)
                {
                    sum = 0;
                    racks += 1;
                    sum += stack.Pop();
                }
                else
                {
                    sum += stack.Pop();
                }
            }
            Console.WriteLine(racks.ToString());
        }
    }
}
