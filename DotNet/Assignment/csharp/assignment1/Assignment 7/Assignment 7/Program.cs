using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Employee class
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }

    static void Main(string[] args)
    {
        // 1. Numbers and their squares
        Console.WriteLine("Numbers and their squares (square > 20)");

        List<int> numbers = new List<int> { 7, 2, 30 };

        var result1 = numbers
            .Select(n => new { Number = n, Square = n * n })
            .Where(x => x.Square > 20);
        foreach (var item in result1)
        {
            Console.WriteLine(item.Number + " - " + item.Square);
        }

        // 2. Words starting with 'a' and ending with 'm'
        Console.WriteLine("\nWords starting with 'a' and ending with 'm'");

        List<string> words = new List<string> { "mum", "amsterdam", "bloom" };
        var result2 = words
            .Where(w => w.StartsWith("a") && w.EndsWith("m"));
        foreach (var word in result2)
        {
            Console.WriteLine(word);
        }

        // 3. Employee Data
        Console.WriteLine("\nEmployee Operations");

        List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, EmpName = "Rahul", EmpCity = "Bangalore", EmpSalary = 50000 },
            new Employee { EmpId = 2, EmpName = "Anita", EmpCity = "Hyderabad", EmpSalary = 40000 },
            new Employee { EmpId = 3, EmpName = "Kiran", EmpCity = "Bangalore", EmpSalary = 60000 },
            new Employee { EmpId = 4, EmpName = "Meena", EmpCity = "Chennai", EmpSalary = 30000 }
        };

        // a. Display all employees
        Console.WriteLine("\nAll Employees:");
        foreach (var emp in employees)
        {
            PrintEmployee(emp);
        }

        // b. Salary > 45000
        Console.WriteLine("\nEmployees with Salary > 45000:");
        var highSalary = employees.Where(e => e.EmpSalary > 45000);
        foreach (var emp in highSalary)
        {
            PrintEmployee(emp);
        }

        // c. Employees from Bangalore
        Console.WriteLine("\nEmployees from Bangalore:");
        var bangaloreEmp = employees.Where(e => e.EmpCity == "Bangalore");
        foreach (var emp in bangaloreEmp)
        {
            PrintEmployee(emp);
        }

        // d. Sort by name ascending
        Console.WriteLine("\nEmployees sorted by Name (Ascending):");
        var sortedEmp = employees.OrderBy(e => e.EmpName);
        foreach (var emp in sortedEmp)
        {
            PrintEmployee(emp);
        }
    }
    // Helper method to print employee details
    static void PrintEmployee(Employee emp)
    {
        Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
    }
}