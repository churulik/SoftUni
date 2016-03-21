using System;

class NumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        uint n = uint.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}

