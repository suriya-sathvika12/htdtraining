using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    //Employee Class 
    class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
    }

    //Nested Struct
    struct DateOfBirth
    {
        public int Day;
        public int Month;
        public int Year;
    }

    struct EmployeeStruct
    {
        public string Name;
        public DateOfBirth Dob;
    }

    static List<Employee> employees = new List<Employee>();

    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\n--- Main Menu --- ");
            Console.WriteLine("1. Employee Management System");
            Console.WriteLine("2. Nested Struct Program");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-------------------------");
            Console.Write("Enter your choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EmployeeMenu();
                    break;

                case 2:
                    NestedStructProgram();
                    break;

                case 3:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 3);
    }

    //Program 1 - Employee Management Menu 
    static void EmployeeMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n--- Employee Management Menu ---");
            Console.WriteLine("1. Add New Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee Details");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("------------------------------");
            Console.Write("Enter your choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;

                case 2:
                    ViewEmployees();
                    break;

                case 3:
                    SearchEmployee();
                    break;

                case 4:
                    UpdateEmployee();
                    break;

                case 5:
                    DeleteEmployee();
                    break;

                case 6:
                    Console.WriteLine("Returning to main menu...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 6);
    }

    //CRUD Methods

    static void AddEmployee()
    {
        Employee emp = new Employee();

        Console.Write("Enter ID: ");
        emp.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        emp.Name = Console.ReadLine();

        Console.Write("Enter Department: ");
        emp.Department = Console.ReadLine();

        Console.Write("Enter Salary: ");
        emp.Salary = Convert.ToDouble(Console.ReadLine());

        employees.Add(emp);
        Console.WriteLine("Employee added successfully!");
    }

    static void ViewEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        Console.WriteLine("\n--- Employee List ---");
        foreach (var emp in employees)
        {
            Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}");
        }
    }

    static void SearchEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var emp = employees.FirstOrDefault(e => e.Id == id);

        if (emp != null)
        {
            Console.WriteLine($"Found: {emp.Id}, {emp.Name}, {emp.Department}, {emp.Salary}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    static void UpdateEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var emp = employees.FirstOrDefault(e => e.Id == id);

        if (emp != null)
        {
            Console.Write("Enter new Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter new Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter new Salary: ");
            emp.Salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Updated successfully!");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var emp = employees.FirstOrDefault(e => e.Id == id);

        if (emp != null)
        {
            employees.Remove(emp);
            Console.WriteLine("Deleted successfully!");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    //Program 2 - Nested Struct Method 
    static void NestedStructProgram()
    {
        EmployeeStruct[] emp = new EmployeeStruct[2];

        for (int i = 0; i < emp.Length; i++)
        {
            Console.Write("Name of the employee: ");
            emp[i].Name = Console.ReadLine();

            Console.Write("Input day of birth: ");
            emp[i].Dob.Day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input month of birth: ");
            emp[i].Dob.Month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input year of birth: ");
            emp[i].Dob.Year = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("\n--- Employee Details ---");

        foreach (var e in emp)
        {
            Console.WriteLine($"Name: {e.Name}");
            Console.WriteLine($"DOB: {e.Dob.Day}/{e.Dob.Month}/{e.Dob.Year}");
            Console.WriteLine();
        }
    }
}
