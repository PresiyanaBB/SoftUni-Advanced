using System;
using System.Linq;

namespace MultidimensionalArrays
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

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if ((matrix[row,col] == matrix[row,col+1]) && (matrix[row+1,col] == matrix[row+1,col+1]) &&
                        (matrix[row, col] == matrix[row+1, col + 1]))
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
