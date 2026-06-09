using System;
class ReportFactory
{
    public static IReport GetReport(string type)
    {
        switch (type.ToLower())
        {
            case "chart":
                return new ChartReport();

            case "tabular":
                return new TabularReport();

            case "summary":
                return new SummaryReport();

            default:
                throw new ArgumentException("Invalid report type");
        }
    }
}
