using System;

class OddAndEvenProduct
{
    static void Main()
    {
        Console.Write("Enter integers (given in a single line, separated by a space): ");
        string[] numbers = Console.ReadLine().Split();
        int oddProduct = 1;
        int evenProduct = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % 2 == 0)
            {
                oddProduct *= Convert.ToInt32(numbers[i]);
            }
            else
            {
                evenProduct *= Convert.ToInt32(numbers[i]);
            }
            
        }
        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = " + oddProduct);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd product = " + oddProduct);
            Console.WriteLine("even product = " + evenProduct);
        }
    }
}
