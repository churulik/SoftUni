using System;

class NumberComparer
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        double firstNum = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        double secondNum = double.Parse(Console.ReadLine());        
        Console.WriteLine("Greter is: " + Math.Max(firstNum, secondNum));             
    }
}

