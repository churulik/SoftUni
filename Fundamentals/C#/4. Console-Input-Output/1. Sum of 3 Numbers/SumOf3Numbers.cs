using System;

class SumOf3Numbers
{
    static void Main()
    {
        Console.Write("ENter number a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter number b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter number c: ");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("The sum of the numbers is {0}", a + b + c);
    }
}

