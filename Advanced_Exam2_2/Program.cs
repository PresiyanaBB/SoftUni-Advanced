using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Exam2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[][] matrix = new string[size][];
            int myTokens = 0;
            int oponentsToken = 0;

            for (int row = 0; row < size; row++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                matrix[row] = elements;
                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row][col] = elements[col];
                }
            }

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "Gong")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                if (IsntInside(matrix, row, col))
                {
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    continue;
                }
                if (command[0] == "Find")
                {
                    if (matrix[row][col] == "T")
                    {
                        myTokens++;
                        matrix[row][col] = "-";
                    }
                }
                else if (command[0] == "Opponent")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (IsntInside(matrix,row,col))
                        {
                            continue;
                        }
                        if (matrix[row][col] == "T")
                        {
                            oponentsToken++;
                            matrix[row][col] = "-";
                        }
                        if (command[3] == "up") row--;
                        else if (command[3] == "down") row++;
                        else if (command[3] == "left") col--;
                        else if (command[3] == "right") col++;
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentsToken}");
        }

        private static bool IsntInside(string[][] matrix, int row, int col)
        {
            return row >= matrix.GetLength(0) ||
                col >= matrix[row].Length ||
                row < 0 ||
                col < 0;
        }
    }
}
