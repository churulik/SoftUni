using System;

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the min integer: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Enter the max integer: ");
        int max = int.Parse(Console.ReadLine());
        Random rnd = new Random();    
        for (int i = 0; i < n; i++)
        {
            int rndNumbers = rnd.Next(min, max);
            Console.Write(rndNumbers + " ");
        }
        Console.WriteLine();
       
    }
}
