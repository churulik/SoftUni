using System;

class DecimalToBinaryNum
{
    static void Main()
    {
        long decNumber = long.Parse (Console.ReadLine());
        string binNumber = "";
        while (decNumber > 0)
        {
            int digit = (int) decNumber % 2;
            decNumber /= 2;
            binNumber = digit + binNumber;
        }
        Console.WriteLine(binNumber);
    }
}
    

