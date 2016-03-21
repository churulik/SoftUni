using System;

class ModifyBit
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Int32.Parse(Console.ReadLine());       
        Console.Write("Enter a bit postion: ");
        int p = Int32.Parse(Console.ReadLine());
        Console.Write("Enter a bit value (0 or 1): ");
        int v = Int32.Parse(Console.ReadLine());
        Console.WriteLine("The number in binary code is " + Convert.ToString(n, 2).PadLeft(16, '0'));
        int mask = 1 << p;
        Console.WriteLine("The number with the bit value in binary code is " + Convert.ToString(mask, 2).PadLeft(16, '0'));
        if (v == 0)
        {
            n = n & ~mask;
        }
        else
        {
            n = n | mask;
        }
        Console.WriteLine("The new number is " + n);
        Console.WriteLine("The new binary code is " + Convert.ToString (n, 2).PadLeft (16, '0'));
    }
}
