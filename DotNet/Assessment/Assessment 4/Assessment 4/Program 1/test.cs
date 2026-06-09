using System;
class Distance
{
    public int Kilometer;
    public Distance(int km)
    {
        Kilometer = km;
    }
    public static Distance Add(Distance d1, Distance d2)
    {
        return new Distance(d1.Kilometer + d2.Kilometer);
    }
    public void Display()
    {
        Console.WriteLine("Distance: " + Kilometer + " km");
    }
}
class test
{
    static void Main(string[] args)
    {
        Console.Write("Enter first distance: ");
        int km1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second distance: ");
        int km2 = Convert.ToInt32(Console.ReadLine());
        Distance d1 = new Distance(km1);
        Distance d2 = new Distance(km2);
        Distance d3 = Distance.Add(d1, d2);
        Console.WriteLine("\nResult:");
        d3.Display();
    }
}