using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // 1. Remove character at given position
    static string RemoveCharacter(string str, int position)
    {
        if (position < 0 || position >= str.Length)
        {
            return "Invalid position";
        }
        return str.Remove(position, 1);
    }

    // 2. Exchange first and last characters
    static string SwapFirstLast(string str)
    {
        if (str.Length <= 1)
        {
            return str;
        }
        char first = str[0];
        char last = str[str.Length - 1];
        string middle = str.Substring(1, str.Length - 2);
        return last + middle + first;
    }

    // 3. Sort stack in descending order
    static Stack<int> SortStackDescending(Stack<int> stack)
    {
        List<int> list = new List<int>(stack);
        list.Sort();
        list.Reverse();
        return new Stack<int>(list);
    }

    static void Main()
    {
        //Program 1
        Console.WriteLine("Enter a string:");
        string input1 = Console.ReadLine();
        Console.WriteLine("Enter position to remove:");
        int pos = Convert.ToInt32(Console.ReadLine());
        string result1 = RemoveCharacter(input1, pos);
        Console.WriteLine("Result: " + result1);


        //Program 2
        Console.WriteLine("\nEnter a string to swap first and last characters:");
        string input2 = Console.ReadLine();
        string result2 = SwapFirstLast(input2);
        Console.WriteLine("Result: " + result2);


        //Program 3
        Console.WriteLine("\nEnter number of elements in stack:");
        int n = Convert.ToInt32(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            stack.Push(num);
        }
        Stack<int> sortedStack = SortStackDescending(stack);
        Console.WriteLine("Stack elements in descending order:");
        foreach (int item in sortedStack.Reverse())
        {
            Console.Write(item + " ");
        }
    }
}
