using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Enter a coefficient: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter second coefficient: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter third coefficient: ");
        double c = double.Parse(Console.ReadLine());

        double discriminant = (b * b) - 4 * a * c;

        if (discriminant < 0)
        {
            Console.WriteLine("There are no real roots.");
        }
        else
        {
            double x1 = (-b - (Math.Sqrt(discriminant))) / (2 * a);
            double x2 = (-b + (Math.Sqrt(discriminant))) / (2 * a);
            Console.WriteLine(x1 == x2 ? "x1 = x2 = {0}" : "x1 = {0}, x2 = {1}", x1, x2);
        }  
    }
}

