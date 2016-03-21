using System;

class FourDigitNumber
{
    static void Main()
    {
        Console.Write("Print 4 digits (the first digit cannot be 0): ");
        int num = Int32.Parse(Console.ReadLine());
        int a = num / 1000;
        int b = num / 100 % 10;
        int c = num / 10 % 10;
        int d = num % 10;
        Console.WriteLine("The sum of the 4 digits is {0}", a + b + c + d);
        Console.WriteLine("The digits in reversed order is " + d + c + b + a);
        Console.WriteLine("The last digits in first position are " + d + a + b + c);
        Console.WriteLine("Exchange of the second and third digits " + a + c + b + d);
    }
}
