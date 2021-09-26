using System;
using System.Collections.Generic;
using System.Linq;

namespace StackQueue8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Reverse();
            Stack<string> stack = new Stack<string>();
            Stack<string> stack2 = new Stack<string>();

            foreach (var item in input)
            {
                stack.Push(item.ToString());
            }

            int count = stack.Count;

            for (int i = 0; i < count; i++)
            {
                if (stack.Peek() == "{" || stack.Peek() == "[" || stack.Peek() == "(")
                {
                    stack2.Push(stack.Pop());
                }
                else
                {
                    if (stack.Peek() == "}")
                    {
                        if (stack2.Any()&&stack2.Peek() == "{" ) { stack.Pop(); stack2.Pop(); }
                        else break;
                    }
                    else if (stack.Peek() == "]")
                    {
                        if (stack2.Any() && stack2.Peek() == "[") { stack.Pop(); stack2.Pop(); }
                        else break;
                    }
                    else if (stack.Peek() == ")")
                    {
                        if (stack2.Any() && stack2.Peek() == "(" ) { stack.Pop(); stack2.Pop(); }
                        else break;
                    }
                    else break;
                }
            }
            if (stack.Any() || stack2.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
