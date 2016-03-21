using System;

class ExchangeIfGreater
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b number: ");
        double b = double.Parse(Console.ReadLine());
        double c;
        if (a > b)
        {
            c = b;
            b = a;
            a = c;
            Console.WriteLine("Result: {0} {1}", a, b);
        }
        else
        {
            Console.WriteLine("Result: {0} {1}", a, b);
        }
        
    }
}

