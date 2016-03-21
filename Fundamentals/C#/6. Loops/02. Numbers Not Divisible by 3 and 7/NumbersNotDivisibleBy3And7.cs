using System;

class NumbersNotDivisibleBy3And7
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        uint n = uint.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 || i % 7 == 0)
            {
                continue;
            }
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}

