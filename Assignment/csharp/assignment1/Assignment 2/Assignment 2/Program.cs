using System;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Program 1
            int num;
            Console.Write("Enter a digit :");
            num = int.Parse(Console.ReadLine());
            for (int i = 0; i < 4; i++)
            {
                Console.Write(num + " ");   
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write(num);
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write(num);
            }
            Console.WriteLine();

            // Program 2
            Console.Write("Enter day number :");
            int day = int.Parse(Console.ReadLine());
            String[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            if (day >= 1 && day <= 7)
                Console.WriteLine(days[day - 1]);
            else
                Console.WriteLine("Invalid day number");
            Console.WriteLine();

            // Arrays
            // Program 3
            Console.WriteLine("Average value");
            int[] arr = { 10, 20, 30, 40, 50 };
            int arrSum = 0, arrMin = arr[0], arrMax = arr[0];
            for (int i = 0; i < arr . Length; i++)
            {
                arrSum += arr[i];
                if (arr[i] < arrMin)
                    arrMin = arr[i];
                if (arr[i] > arrMax)
                    arrMax = arr[i];
            }
            Console.WriteLine("Array Elements : 10 20 30 40 50");
            Console.WriteLine("Average :" + (double)arrSum / arr.Length);
            Console.WriteLine("Minimum :" + arrMin);
            Console.WriteLine("Maximum :" + arrMax);
            Console.WriteLine();

            // Program 4
            Console.WriteLine("Marks");
            int[] marks = new int[10];
            int total = 0, minMark, maxMark;
            Console.WriteLine("Enter 10 marks: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Mark" + (i + 1) + " : ");
                marks[i] = int.Parse(Console.ReadLine());
                total += marks[i];
            }
            minMark = marks[0];
            maxMark = marks[0];
            for (int i = 1; i < 10; i++)
            {
                if (marks[i] < minMark) minMark = marks[i];
                if (marks[i] > maxMark) maxMark = marks[i];
            }
            Console.WriteLine("Total: " + total);
            Console.WriteLine("Average: " + (double)total / 10);
            Console.WriteLine("Minimum Mark: " + minMark);
            Console.WriteLine("Maximum Mark: " + maxMark);

            int[] asc = new int[10];
            for (int i = 0; i < 10; i++)
                asc[i] = marks[i];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9 - i; j++)
                    if (asc[j] > asc[j + 1])
                    {
                        int temp = asc[j];
                        asc[j] = asc[j + 1];
                        asc[j + 1] = temp;
                    }
            Console.WriteLine("Ascending Order :");
            for (int  i = 0; i < asc.Length; i++)
                Console.Write(asc[i] + " ");
            Console.WriteLine();
            Console.WriteLine("Descending Order :");
            for (int i = asc.Length - 1;i >= 0; i--)
                Console.Write(asc[i] + " ");
            Console.WriteLine();
            Console.WriteLine();

            // Program 5
            Console.WriteLine("Copy Elements");
            int[] original = new int[5];
            Console.WriteLine("Enter 5 values: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Value" + (i + 1)+ " : ");
                original[i] = int.Parse(Console.ReadLine());
            }
            int[] copy = new int[original.Length];
            for (int i = 0; i < original.Length; i++)
                copy[i] = original[i];
            Console.Write("Original Array :");
            for (int i = 0; i < original.Length; i++)
                Console.Write(original[i] + " ");
            Console.WriteLine();
            Console.Write("Copied Array :");
            for (int i = 0; i < copy.Length; i++)
                Console.Write(copy[i] + " ");
            Console.WriteLine();

            // Strings
            // Program 6

            Console.WriteLine("Word Length");
            Console.Write("Enter a word:");
            string word = Console.ReadLine();
            Console.WriteLine("Length: " + word.Length);
            Console.WriteLine();

            // Program 7
            Console.WriteLine("Reverse word");
            Console.WriteLine("Enter a word to reverse: ");
            string w = Console.ReadLine();
            string reversed = " ";
            for (int i = w.Length - 1; i >= 0; i--)
                reversed += w[i];
            Console.WriteLine("Reversed:" + reversed);
            Console.WriteLine();

            // Program 8
            Console.WriteLine("Same words");
            Console.Write("Enter first word: ");
            string word1 = Console.ReadLine();
            Console.Write("Enter second word: ");
            string word2 = Console.ReadLine();
            if (string.Equals(word1, word2, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Both words are same");
            else
                Console.WriteLine("Words are different");
        }
    }
}
