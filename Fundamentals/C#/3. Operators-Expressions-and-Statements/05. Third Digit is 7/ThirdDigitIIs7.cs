using System;

class ThirdDigitIs7
{
    static void Main()
    {
        Console.Write("Enter a numbuer to check if the the third digit is 7: ");
        int number = Int32.Parse(Console.ReadLine());
        int numberDivide = number / 100;
        Console.WriteLine(Math.Abs (numberDivide) % 10 == 7);
    }
}
