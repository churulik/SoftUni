using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Int32.Parse(Console.ReadLine());
        Console.Write("Enter a bit: ");
        int p = Int32.Parse(Console.ReadLine());
        int nRightP = n >> p;
        int bit = nRightP & 1;
        Console.WriteLine(bit);        
    }
}
