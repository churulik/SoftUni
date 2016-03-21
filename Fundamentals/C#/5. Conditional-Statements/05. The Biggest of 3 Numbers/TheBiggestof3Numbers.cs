using System;

class TheBiggestOf3Numbers
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        double c = double.Parse(Console.ReadLine());

        if (a > b && a > c)
        {
            Console.WriteLine(a);
        }
        else if (b > a && b > c)
        {
            Console.WriteLine(b);
        }
        else 
        {
            Console.WriteLine(c);
        }
    }
}

