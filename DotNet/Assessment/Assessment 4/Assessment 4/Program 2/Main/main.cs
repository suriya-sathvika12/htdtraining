using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter report type (chart/tabular/summary): ");
        string choice = Console.ReadLine();

        IReport report = ReportFactory.GetReport(choice);
        report.Generate();
    }
}
