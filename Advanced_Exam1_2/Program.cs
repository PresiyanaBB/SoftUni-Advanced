using System;
using System.Linq;
using System.Collections.Generic;

namespace Advanced_Exam1_2
{
    class Program
    {
        static int armour;
        static void Main(string[] args)
        {
            armour = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int armyRow = 0;
            int armyCol = 0;

            char[][] matrix = new char[size][];
            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToArray();
                matrix[row] = input.ToArray();
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                    if (input[col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }
            while (true)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = line[0];
                int orcRow = int.Parse(line[1]);
                int orcCol = int.Parse(line[2]);

                matrix[orcRow][orcCol] = 'O';
                matrix[armyRow][armyCol] = '-';
                armour--;

                if (command == "up")
                {
                    if (IsntInside(matrix, armyRow - 1, armyCol)) { continue; }
                    armyRow--;
                    HittedPlace(matrix,armyRow,armyCol);
                }
                else if (command == "down")
                {
                    if(IsntInside(matrix, armyRow+1, armyCol)) { continue; }
                    armyRow++;
                    HittedPlace(matrix, armyRow, armyCol);
                }
                else if (command == "left")
                {
                    if(IsntInside(matrix, armyRow, armyCol-1)) { continue; }
                    armyCol--;
                    HittedPlace(matrix,armyRow,armyCol);
                }
                else if (command == "right")
                {
                    if (IsntInside(matrix, armyRow, armyCol + 1)) { continue; }
                    armyCol++;
                    HittedPlace(matrix, armyRow, armyCol);
                }
            }
                
        }

        private static bool IsntInside(char[][] matrix, int row, int col)
        {
            if (armour <= 0 && matrix[row][col] != 'M')
            {
                matrix[row][col] = 'X';
                Console.WriteLine($"The army was defeated at {row};{col}.");
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix[row].Length; c++)
                    {
                        Console.Write(matrix[r][c]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }

            return row >= matrix.GetLength(0) ||
                col >= matrix[row].Length ||
                row < 0 ||
                col < 0;
        }

        private static void HittedPlace(char[][] matrix,int row,int col)
        {
            if (armour <= 0 && matrix[row][col] != 'M')
            {
                matrix[row][col] = 'X';
                Console.WriteLine($"The army was defeated at {row};{col}.");
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix[row].Length; c++)
                    {
                        Console.Write(matrix[r][c]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
            if (matrix[row][col] == 'O')
            {
                armour -= 2;
                matrix[row][col] = '-';
            }
            else if (matrix[row][col] == 'M')
            {
                matrix[row][col] = '-';
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armour}");
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix[row].Length; c++)
                    {
                        Console.Write(matrix[r][c]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
            if (armour <= 0)
            {
                matrix[row][col] = 'X';
                Console.WriteLine($"The army was defeated at {row};{col}.");
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix[row].Length; c++)
                    {
                        Console.Write(matrix[r][c]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
            return;
        }
    }
}
