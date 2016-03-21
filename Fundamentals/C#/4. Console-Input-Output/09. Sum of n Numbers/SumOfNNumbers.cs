using System;

class SumOfNNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a number and after that enter more numbers: ");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            double nums = double.Parse(Console.ReadLine());
            sum = sum + nums;
        }
        Console.WriteLine("The sum of the numbers is: {0}", sum);
    }
}   

