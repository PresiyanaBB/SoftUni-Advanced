using System;
using System.Collections.Generic;
using System.Linq;

namespace StackQueue9
{
    class Program
    {
        //it removes top of the stack and its not a queue
        static void Main(string[] args)
        {
            int commandCount = int.Parse(Console.ReadLine());
            Dictionary<int, string[]> dic = new Dictionary<int, string[]>();
            Stack<string> stack = new Stack<string>();
            Stack<string> removedLetters = new Stack<string>();
            int numForDic = 0;
            string[] command;
            for (int i = 0; i < commandCount; i++)
            {
                command = Console.ReadLine().Split();
                if (command[0] != "4" && command[0] != "3") { dic.Add(numForDic, command); numForDic++; }


                    if (command[0] == "1")
                {
                    foreach (var item in command[1].Reverse())
                    {
                        stack.Push(item.ToString());
                    }
                }
                else if (command[0] == "2")
                {
                    for (int j = 0; j < int.Parse(command[1]); j++)
                    {
                        removedLetters.Push(stack.Pop());
                    }
                }
                else if (command[0] == "3")
                {
                    Console.WriteLine(stack.ElementAt(int.Parse(command[1]) - 1).ToString());
                }
                else
                {
                    if (dic[dic.Count - 1][0].ToString() == "1")
                    {
                        foreach (var item in dic[dic.Count - 1][1])
                        {
                            stack.Pop();
                        }
                        dic.Remove(dic.Count - 1);
                    }
                    else if (dic[dic.Count - 1][0].ToString() == "2")
                    {
                        for (int j = 0; j < int.Parse(dic[dic.Count - 1][1]); j++)
                        {
                            stack.Push(removedLetters.Pop());
                        }
                        dic.Remove(dic.Count - 1);
                    }
                }
            }
        }
    }
}
