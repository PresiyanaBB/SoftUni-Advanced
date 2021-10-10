using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Exam2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>();
            Stack<int> freshnessLevel = new Stack<int>();
            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>();

            int[] ingr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] fresh = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            foreach (var ing in ingr)
            {
                ingredients.Enqueue(ing);
            }
            foreach (var fr in fresh)
            {
                freshnessLevel.Push(fr);
            }

            while (true)
            {
                if (ingredients.Count == 0 || freshnessLevel.Count == 0)
                {
                    break;
                }
                else if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                }
                else if (Multiply(ingredients.Peek(),freshnessLevel.Peek()))
                {
                    if (dishes.ContainsKey(DishName(ingredients.Peek() * freshnessLevel.Peek())))
                    {
                        dishes[DishName(ingredients.Peek() * freshnessLevel.Peek())] += 1;
                    }
                    else dishes.Add(DishName(ingredients.Peek()*freshnessLevel.Peek()),1);
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                }
                else if (!Multiply(ingredients.Peek(), freshnessLevel.Peek()))
                {
                    freshnessLevel.Pop();
                    ingredients.Enqueue(ingredients.Dequeue()+5);
                }
            }
            if (dishes.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Count != 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
            }
            foreach (var item in dishes)
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
        public static string DishName(int a)
        {
            if (a == 150) return "Dipping sauce";
            else if (a == 250) return "Green salad";
            else if (a == 300) return "Chocolate cake";
            else return "Lobster";

        }
        public static bool Multiply(int a,int b)
        {
            return a * b == 150 ||
                a * b == 250 ||
                a * b == 300 ||
                a * b == 400;
        }
    }
}
