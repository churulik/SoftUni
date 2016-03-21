using System;

class DivideBy7And5
{
    static void Main()
    {
        Console.Write("Enter a number to check if it is divide (without remainder) by 7 and 5: ");
        int number = Int32.Parse(Console.ReadLine());
        Console.WriteLine(number % 7 == 0 && number % 5 == 0 && number !=0 ? "Divided by 7 and 5?: True" : "Divided by 7 and 5?: False");
    }
}

