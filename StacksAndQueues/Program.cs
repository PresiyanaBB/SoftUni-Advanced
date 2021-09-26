using System;
using System.Collections.Generic;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            var firstLine = Console.ReadLine().Split();
            //n-count , s-pop , x-contain
            int n = int.Parse(firstLine[0]);
            int s = int.Parse(firstLine[1]);
            int x = int.Parse(firstLine[2]);
            var secondLine = Console.ReadLine().Split();

            for (int i = 0; i < n - s; i++)
            {
                stack.Push(int.Parse(secondLine[i]));
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                int test = stack.Peek();
                foreach (var item in stack)
                {
                    if (item < test)
                    {
                        test = item;
                    }
                }

                Console.WriteLine(test.ToString());
            }
        }
    }
}
