using System;
using System.Linq;
using System.Collections.Generic;

namespace MultiArrays_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];

            for (int row = 0; row < size; row++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            var coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < coordinates.Length; i++)
            {
                var bomb = coordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (matrix[bomb[0],bomb[1]] <= 0)
                {
                    continue;
                }

                if (IsInside(matrix,bomb[0] - 1,bomb[1]))
                {
                    matrix[bomb[0] - 1, bomb[1]] -= matrix[bomb[0], bomb[1]];
                }
                if (IsInside(matrix,bomb[0] - 1,bomb[1] + 1))
                {
                    matrix[bomb[0] - 1, bomb[1]+1] -= matrix[bomb[0], bomb[1]];
                }
                if (IsInside(matrix,bomb[0],bomb[1] + 1))
                {
                    matrix[bomb[0], bomb[1]+1] -= matrix[bomb[0], bomb[1]];
                }
                if (IsInside(matrix,bomb[0] + 1,bomb[1] + 1))
                {
                    matrix[bomb[0] + 1, bomb[1]+1] -= matrix[bomb[0], bomb[1]];
                }
                if (IsInside(matrix,bomb[0] +1,bomb[1] ))
                {
                    matrix[bomb[0]+1, bomb[1]] -= matrix[bomb[0], bomb[1]];
                }
                if (IsInside(matrix,bomb[0]+1,bomb[1] - 1))
                {
                    matrix[bomb[0] +1, bomb[1]-1] -= matrix[bomb[0], bomb[1]];
                }
                if (IsInside(matrix,bomb[0],bomb[1] - 1))
                {
                    matrix[bomb[0], bomb[1]-1] -= matrix[bomb[0], bomb[1]];
                }
                if (IsInside(matrix,bomb[0] -1,bomb[1] - 1))
                {
                    matrix[bomb[0] - 1, bomb[1]-1] -= matrix[bomb[0], bomb[1]];
                }
                matrix[bomb[0], bomb[1]] = int.MinValue;
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] == int.MinValue)
                    {
                        matrix[row, col] = 0;
                    }
                    if (matrix[row,col] > 0)
                    {
                        sum += matrix[row, col];
                        aliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }

        public static bool IsInside(int[,] matrix,int row,int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1)
                && (matrix[row,col] != int.MinValue) && (matrix[row,col] > 0);
        }
    }
}
