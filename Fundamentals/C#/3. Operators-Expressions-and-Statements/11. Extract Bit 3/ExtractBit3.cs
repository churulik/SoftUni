using System;

class ExtractBit3
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        uint number = UInt32.Parse(Console.ReadLine());
        int p = 3;
        uint bRightA = number >> p;
        uint bit = bRightA & 1;
        Console.WriteLine(bit);
        Console.WriteLine(Convert.ToString (bit, 2).PadLeft(16,'0'));
    }
}
