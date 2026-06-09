using System;

namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Program 1
            Console.WriteLine("Check Equal or Not");
            Console.Write("Input 1st number:");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Input 2st number:");
            int num2 = int.Parse(Console.ReadLine());
            if (num1 == num2)
                Console.WriteLine($"{num1} and {num2} are equal");
            else
                Console.WriteLine($"{num1} and {num2} are not equal");

            // Program 2
            Console.WriteLine("Positive or Negative");
            Console.Write("Test Data: ");
            int num= int.Parse(Console.ReadLine());
            if (num > 0)
                Console.WriteLine($"{num} is a positive number");
            else if (num < 0)
                Console.WriteLine($"{num} is a negative number ");
            else
                Console.WriteLine($"{num} is a zero");

            // Program 3
            Console.WriteLine("Arithmetic Operations");
            Console.WriteLine("Input First number:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Operation (+ , - , *, /): ");
            char op = Console.ReadLine()[0];
            Console.WriteLine("Input Second number: ");
            double b = double.Parse(Console.ReadLine());

            double result = 0;
            switch (op)
            {
                case '+': result = a + b; break;
                case '-': result = a - b; break;
                case '*': result = a * b; break;
                case '/':
                    if (b != 0) 
                        result = a / b;
                    else 
                        Console.WriteLine("Cannot divide by zero!"); 
                        break;
                default:
                    Console.WriteLine("Invalid operator! ");
                    break;
            }
            Console.WriteLine($"{a} {op} {b} = {result}");

            // Program 4
            Console.WriteLine("Multiplication");
            Console.WriteLine("Enter the number");
            int tableNum = int.Parse(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{tableNum} {i} = {tableNum * i}");
            }

            // Program 5
            Console.WriteLine("Sum or Triple Sum");
            Console.WriteLine("Enter first integer: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second integer: ");
            int y = int.Parse(Console.ReadLine());
            int sum;
            if (x == y)
            {
                sum = 3 * (x + y);
                Console.WriteLine($"Both values are equal, so triple of their sum = {sum}");
            }
            else
            {
                sum = x + y;
                Console.WriteLine($"Sum of {x} and {y} = {sum}");
            }
            Console.ReadLine();
        }
    }
}
