using System;

class OddEvenIntegers
{
    static void Main()
    {
        Console.Write("Enter a number to check if it's odd or even: ");
        int number = int.Parse (Console.ReadLine ());
        Console.WriteLine("Odd? {0}", number % 2 != 0);
    }
}
