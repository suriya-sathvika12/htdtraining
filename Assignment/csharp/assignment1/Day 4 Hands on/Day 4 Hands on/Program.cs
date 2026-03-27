using System;

namespace Day4Handson
{
    class Box
    {
        public int length;
        public int breadth;

        // Overloading * operator to scale the box
        public static Box operator *(Box box, int factor)
        {
            Box temp = new Box();
            temp.length = box.length * factor;
            temp.breadth = box.breadth * factor;
            return temp;
        }
    }

    internal class OperatorOverloading
    {
        static void Main()
        {
            Box b1 = new Box();
            b1.length = 4;
            b1.breadth = 3;

            Box b2 = b1 * 2;

            Console.WriteLine($"Original Box: Length = {b1.length}, Breadth = {b1.breadth}");
            Console.WriteLine($"Scaled Box: Length = {b2.length}, Breadth = {b2.breadth}");

            Console.Read();
        }
    }
}
