using System;
using System.Collections.Generic;
using System.Linq;

namespace StackQueue7
{
    class Program
    {
        static void Main(string[] args)
        {
            int circle = int.Parse(Console.ReadLine());
            TruckDrive(circle);
        }

        private static void TruckDrive(int circle)
        {
            Queue<int[]> queue = new Queue<int[]>();
            int[] input;
            int index=0;
            for (int i = 0; i < circle; i++)
            {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(input);
            }
            while (true)
            {
                int sum = 0;
                foreach (var item in queue)
                {
                    int first = item[0];
                    int second = item[1];
                    sum += first;
                    sum -= second;
                    if (sum<0)
                    {
                        int[] el = queue.Dequeue();
                        queue.Enqueue(el);
                        index++;
                        break;
                    }
                }
                if (sum >= 0)
                {
                    Console.WriteLine(index.ToString());
                    break;
                }
            }
        }
    }
}
