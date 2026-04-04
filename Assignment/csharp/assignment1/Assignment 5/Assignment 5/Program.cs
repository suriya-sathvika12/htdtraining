using System;

//Program 1
// Custom Exception
public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}

public class BankAccount
{
    private double balance;

    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }
    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");
        balance += amount;
        Console.WriteLine("Deposited: " + amount);
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdraw amount must be positive.");

        if (amount > balance)
            throw new InsufficientBalanceException("Insufficient balance for withdrawal!");

        balance -= amount;
        Console.WriteLine("Withdrawn: " + amount);
    }

    public void ShowBalance()
    {
        Console.WriteLine("Current Balance: " + balance);
    }
}

//Program 2

// Custom Exception
public class InvalidMarksException : Exception
{
    public InvalidMarksException(string message) : base(message)
    {
    }
}

public class Scholarship
{
    public double Merit(int marks, double fees)
    {
        if (marks >= 70 && marks <= 80)
        {
            return fees * 0.20;
        }
        else if (marks > 80 && marks <= 90)
        {
            return fees * 0.30;
        }
        else if (marks > 90)
        {
            return fees * 0.50;
        }
        else
        {
            throw new InvalidMarksException("Marks not eligible for scholarship!");
        }
    }
}

//Program 3

public class Books
{
    public string BookName { get; set; }
    public string AuthorName { get; set; }

    public Books(string bookName, string authorName)
    {
        BookName = bookName;
        AuthorName = authorName;
    }

    public void Display()
    {
        Console.WriteLine("Book: " + BookName + ", Author: " + AuthorName);
    }
}

public class BookShelf
{
    private Books[] bookList = new Books[5];

    // Indexer
    public Books this[int index]
    {
        get { return bookList[index]; }
        set { bookList[index] = value; }
    }

    public void DisplayBooks()
    {
        Console.WriteLine("\nBooks in Shelf:");
        for (int i = 0; i < bookList.Length; i++)
        {
            if (bookList[i] != null)
                bookList[i].Display();
        }
    }
}

// Main Class
//Banking System

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- BANK SYSTEM ---");

        try
        {
            BankAccount acc = new BankAccount(1000);

            acc.Deposit(500);
            acc.Withdraw(300);
            acc.ShowBalance();

            // This will throw exception
            acc.Withdraw(2000);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Custom Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception: " + ex.Message);
        }

        //Scholarship
        Console.WriteLine("\n--- SCHOLARSHIP ---");
        Scholarship s = new Scholarship();
        try
        {
            double amount = s.Merit(85, 10000);
            Console.WriteLine("Scholarship Amount: " + amount);

            // This will throw exception
            s.Merit(60, 10000);
        }
        catch (InvalidMarksException ex)
        {
            Console.WriteLine("Custom Exception: " + ex.Message);
        }

        //Books
        Console.WriteLine("\n--- BOOK SHELF ---");

        BookShelf shelf = new BookShelf();

        shelf[0] = new Books("C# Basics", "John");
        shelf[1] = new Books("OOP Concepts", "Smith");
        shelf[2] = new Books("Data Structures", "David");
        shelf[3] = new Books("Algorithms", "Thomas");
        shelf[4] = new Books("DotNet Guide", "James");

        shelf.DisplayBooks();
    }
}
