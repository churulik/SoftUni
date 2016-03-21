using System;

class MultiplicationSign
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        double c = double.Parse(Console.ReadLine());
        if (a > 0 && b > 0 && c > 0 || 
            a > 0 && b < 0 && c < 0 ||
            a < 0 && b > 0 && c < 0 ||
            a < 0 && b < 0 && c > 0)
        {
            Console.WriteLine("Result: +");
        }
        else if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine("Result: 0");
        }
        else
        {
            Console.WriteLine("Result: -");
        }
        
    }
}

