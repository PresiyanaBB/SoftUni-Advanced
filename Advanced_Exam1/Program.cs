using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> plates = new Stack<int>();
            Queue<int> guests = new Queue<int>();
            var guestCapaity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var plateCapaity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int leftovers = 0;
            int thisGuest;

            foreach (var guest in guestCapaity)
            {
                guests.Enqueue(guest);
            }
            foreach (var plate in plateCapaity)
            {
                plates.Push(plate);
            }

            while (true)
            {
                if (!guests.Any() || !plates.Any())
                {
                    break;
                }
                thisGuest = guests.Peek() - plates.Pop();
                if (thisGuest > 0)
                {
                    while (thisGuest > 0 && plates.Any())
                    {
                        thisGuest -= plates.Pop();
                    }
                    leftovers += thisGuest * (-1);
                }
                else if (thisGuest < 0)
                {
                    leftovers += thisGuest * (-1);
                }
                guests.Dequeue();
            }

            if (guests.Any())
            {
                Console.Write("Guests: ");
                Console.Write(string.Join(" ", guests));
            }
            if (plates.Any())
            {
                Console.Write("Plates: ");
                Console.Write(string.Join(" ", plates));
            }
            Console.WriteLine();
            Console.WriteLine($"Wasted grams of food: {leftovers}");
        }
    }
}
