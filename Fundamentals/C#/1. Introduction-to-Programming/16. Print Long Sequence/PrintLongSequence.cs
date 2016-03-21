using System;

class PrintLongSequence
{
    static void Main()
    {
     for (int i = 2; i <= 1000; i++)
        {
        int val = i % 2 == 1 ? i * -1 : i;
        Console.WriteLine(val);
        }
    
    }
}

