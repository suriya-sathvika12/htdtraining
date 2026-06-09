using System;
using System.Linq;

//Main Program 
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- STUDENT RESULT ---");
        Student ug = new Undergraduate("Suriya", 101, 75.5);
        Student grad = new Graduate("Harshanaa", 201, 78.0);
        Console.WriteLine($"{ug.Name} Passed: {ug.IsPassed(ug.Grade)}");
        Console.WriteLine($"{grad.Name} Passed: {grad.IsPassed(grad.Grade)}");


        Console.WriteLine("\n--- PRODUCT SORTING ---");
        Product[] products = new Product[10];
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"\nEnter details for Product {i + 1}:");
            Console.Write("Product ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());
            products[i] = new Product(id, name, price);
        }

        // Sorting - Price
        var sortedProducts = products.OrderBy(p => p.Price);
        Console.WriteLine("\nSorted Products by Price:");
        foreach (var p in sortedProducts)
        {
            Console.WriteLine($"{p.ProductId} - {p.ProductName} - {p.Price}");
        }

        Console.WriteLine("\n--- EXCEPTION HANDLING ---");
        try
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            CheckNumber(num);
            Console.WriteLine("Number is valid.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        Console.WriteLine("\n--- DELEGATE CALCULATOR ---");
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());
        Calculator calc = new Calculator();
        CalcDelegate add = calc.Add;
        CalcDelegate sub = calc.Subtract;
        CalcDelegate mul = calc.Multiply;
        Console.WriteLine("Addition: " + add(a, b));
        Console.WriteLine("Subtraction: " + sub(a, b));
        Console.WriteLine("Multiplication: " + mul(a, b));
    }

    //Program 3
    static void CheckNumber(int num)
    {
        if (num < 0)
        {
            throw new Exception("Number cannot be negative!");
        }
    }
}


//Program 1

// Abstract Class
abstract class Student
{
    public string Name;
    public int StudentId;
    public double Grade;

    public Student(string name, int id, double grade)
    {
        Name = name;
        StudentId = id;
        Grade = grade;
    }
    public abstract bool IsPassed(double grade);
}

// Undergraduate Class
class Undergraduate : Student
{
    public Undergraduate(string name, int id, double grade)
        : base(name, id, grade) { }
    public override bool IsPassed(double grade)
    {
        return grade > 70.0;
    }
}

// Graduate Class
class Graduate : Student
{
    public Graduate(string name, int id, double grade)
        : base(name, id, grade) { }
    public override bool IsPassed(double grade)
    {
        return grade > 80.0;
    }
}


//Program 2

class Product
{
    public int ProductId;
    public string ProductName;
    public double Price;

    public Product(int id, string name, double price)
    {
        ProductId = id;
        ProductName = name;
        Price = price;
    }
}


//Program 4

delegate int CalcDelegate(int x, int y);
class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
    public int Subtract(int x, int y)
    {
        return x - y;
    }
    public int Multiply(int x, int y)
    {
        return x * y;
    }
}