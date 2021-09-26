using System;
using System.Collections.Generic;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            var firstLine = Console.ReadLine().Split();
            //n-count , s-pop , x-contain
            int n = int.Parse(firstLine[0]);
            int s = int.Parse(firstLine[1]);
            int x = int.Parse(firstLine[2]);
            var secondLine = Console.ReadLine().Split();

            for (int i = 0; i < n ; i++)
            {
                queue.Enqueue(int.Parse(secondLine[i]));
            }
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                int test = queue.Peek();
                foreach (var item in queue)
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

