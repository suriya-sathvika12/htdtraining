using System;
using TravelLibrary;
namespace TravelConcessionApp
{
    class Program
    {
        const double TotalFare = 500;
        static void Main(string[] args)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Concession obj = new Concession();
            string result = obj.CalculateConcession(name, age, TotalFare);
            Console.WriteLine("\n--- RESULT ---");
            Console.WriteLine("Name: " + name);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
