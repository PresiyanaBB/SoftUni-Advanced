using System;
using System.Collections.Generic;
using System.Linq;

namespace StackQueue4
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int allFood = int.Parse(Console.ReadLine());
            var customers = Console.ReadLine().Split();
            int maxOrder = 0;
            foreach (var item in customers)
            {
                queue.Enqueue(int.Parse(item));
            }
            maxOrder = queue.Max();
            for (int i = 0; i < customers.Length; i++)
            {
                if (queue.Peek() <= allFood)
                {
                    allFood -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine(maxOrder);
                    Console.WriteLine("Orders left: " + string.Join(" ", queue));
                    break;
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(maxOrder);
                Console.WriteLine("Orders complete");
            }
        }
            
    }
}
