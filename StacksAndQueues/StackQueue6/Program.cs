using System;
using System.Collections.Generic;
using System.Linq;

namespace StackQueue6
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            var firstLine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var secondLines = Console.ReadLine();
            foreach (var item in firstLine)
            {
                queue.Enqueue(item);
            }
            while (queue.Count != 0)
            {
                if (secondLines == "Play")
                {
                    queue.Dequeue();
                }
                else if (secondLines.StartsWith("Add"))
                {
                    if (queue.Contains(secondLines.Substring(4)))
                    {
                        Console.WriteLine($"{secondLines.Substring(4)} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(secondLines.Substring(4));
                    }
                }
                else if (secondLines == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }

                secondLines = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
