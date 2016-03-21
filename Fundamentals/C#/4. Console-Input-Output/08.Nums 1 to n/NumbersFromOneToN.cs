using System;

class NumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int n = int.Parse(Console.ReadLine());
        if (n > 0)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            for (int i = 1; i >= n; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
