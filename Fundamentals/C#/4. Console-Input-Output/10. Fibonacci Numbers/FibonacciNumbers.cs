using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int a = 0;
        int b = 1;
        int c = 0;

        if (n == 1)
        {
            Console.Write(0);
        }

        else
        {
            Console.Write(0 + " ");
            for (int i = 1; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
                Console.Write(a + " ");
            }
        }
        Console.WriteLine();
     
    }
}

