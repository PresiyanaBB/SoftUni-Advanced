using System;
using System.Linq;

namespace MultiArrays_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            while (true)
            {
                string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (text[0] == "END")
                {
                    break;
                }

                if (text[0] != "swap" || text.Length != 5 || (int.Parse(text[1]) > matrix.GetLength(0))
                    || (int.Parse(text[3]) > matrix.GetLength(0)) || (int.Parse(text[2]) > matrix.GetLength(1))
                    || (int.Parse(text[4]) > matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                else
                {
                    string swapped;
                    swapped = matrix[int.Parse(text[1]), int.Parse(text[2])];
                    matrix[int.Parse(text[1]), int.Parse(text[2])] = matrix[int.Parse(text[3]), int.Parse(text[4])];
                    matrix[int.Parse(text[3]), int.Parse(text[4])] = swapped;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row,col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }

        }
    }
}
