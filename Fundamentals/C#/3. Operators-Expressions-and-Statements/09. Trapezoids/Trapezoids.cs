using System;

class Trapezoids
{
    static void Main()
    {
        Console.Write("Enter the a side: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the b side: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the height: ");
        double h = Convert.ToDouble(Console.ReadLine());
        double area = (a + b) / 2 * h;
        Console.WriteLine("The trapezoid area is: {0}", area);
    }
}

