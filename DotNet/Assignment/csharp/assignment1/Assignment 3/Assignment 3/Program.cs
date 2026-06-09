using System;
class Program
{
    static void Main(string[] args)
    {
        // Accounts
        Accounts acc = new Accounts(101, "Suriya", "Savings", 5000);
        acc.UpdateBalance('D', 2000); 
        acc.UpdateBalance('W', 1000); 
        acc.ShowData();

        // Student 
        Student stu = new Student(1, "Keerthi", "BSc", 3, "CSE");
        stu.DisplayData();
        stu.GetMarks();
        stu.DisplayResult();

        // SaleDetails 
        SaleDetails sale = new SaleDetails(201, 501, 100.0, 5, "31-03-2026");
        sale.Sales();
        SaleDetails.ShowData(sale);

        Console.ReadLine();
    }
}
// Program 1
class Accounts
{
    int accNo;
    string custName;
    string accType;
    double balance;

    public Accounts(int accNo, string custName, string accType, double balance)
    {
        this.accNo = accNo;
        this.custName = custName;
        this.accType = accType;
        this.balance = balance;
    }

    public void Credit(double amount)
    {
        balance += amount;
        Console.WriteLine("Amount Deposited: " + amount);
    }

    public void Debit(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine("Amount Withdrawn: " + amount);
        }
        else
        {
            Console.WriteLine("Insufficient Balance!");
        }
    }

    public void UpdateBalance(char transType, double amount)
    {
        if (transType == 'D' || transType == 'd')
        {
            Credit(amount);
        }
        else if (transType == 'W' || transType == 'w')
        {
            Debit(amount);
        }
        else
        {
            Console.WriteLine("Invalid Transaction Type");
        }
    }

    public void ShowData()
    {
        Console.WriteLine("\n--- Account Details ---");
        Console.WriteLine("Account No: " + accNo);
        Console.WriteLine("Customer Name: " + custName);
        Console.WriteLine("Account Type: " + accType);
        Console.WriteLine("Balance: " + balance);
    }
}


// Program 2
class Student
{
    int rollNo;
    string name;
    string studentClass;
    int sem;
    string branch;
    int[] marks = new int[5];

    public Student(int rollNo, string name, string studentClass, int sem, string branch)
    {
        this.rollNo = rollNo;
        this.name = name;
        this.studentClass = studentClass;
        this.sem = sem;
        this.branch = branch;
    }

    public void GetMarks()
    {
        Console.WriteLine("\nEnter marks for 5 subjects:");
        for (int i = 0; i < 5; i++)
        {
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    public void DisplayResult()
    {
        int total = 0;
        bool fail = false;

        for (int i = 0; i < 5; i++)
        {
            if (marks[i] < 35)
                fail = true;

            total += marks[i];
        }

        double avg = total / 5.0;
        Console.WriteLine("Average Marks: " + avg);

        if (fail)
            Console.WriteLine("Result: Failed (One subject < 35)");
        else if (avg < 50)
            Console.WriteLine("Result: Failed (Average < 50)");
        else
            Console.WriteLine("Result: Passed");
    }
    public void DisplayData()
    {
        Console.WriteLine("\n--- Student Details ---");
        Console.WriteLine("Roll No: " + rollNo);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Class: " + studentClass);
        Console.WriteLine("Semester: " + sem);
        Console.WriteLine("Branch: " + branch);
    }
}


// Program 3
class SaleDetails
{
    int salesNo;
    int productNo;
    double price;
    int qty;
    string dateOfSale;
    double totalAmount;

    public SaleDetails(int salesNo, int productNo, double price, int qty, string dateOfSale)
    {
        this.salesNo = salesNo;
        this.productNo = productNo;
        this.price = price;
        this.qty = qty;
        this.dateOfSale = dateOfSale;
    }

    public void Sales()
    {
        totalAmount = qty * price;
    }

    public static void ShowData(SaleDetails s)
    {
        Console.WriteLine("\n--- Sale Details ---");
        Console.WriteLine("Sales No: " + s.salesNo);
        Console.WriteLine("Product No: " + s.productNo);
        Console.WriteLine("Price: " + s.price);
        Console.WriteLine("Quantity: " + s.qty);
        Console.WriteLine("Date of Sale: " + s.dateOfSale);
        Console.WriteLine("Total Amount: " + s.totalAmount);
    }
}
