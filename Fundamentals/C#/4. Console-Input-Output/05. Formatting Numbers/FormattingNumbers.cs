using System;

class FormattingNumbers
{
    static void Main()
    {
        Console.Write("Eneter a number (range between 0-500): ");
        uint a = uint.Parse(Console.ReadLine());      
        Console.Write("Enter second number (with reminder): ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter third number (with reminder): ");
        double c = double.Parse(Console.ReadLine());
        string binaryA = Convert.ToString(a, 2);

        Console.WriteLine("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|", a, binaryA.PadLeft(10, '0'), b, c);
    }
}
