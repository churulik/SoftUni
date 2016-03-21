using System;
using System.Numerics;
class CatalanNumbers
{
    static void Main()
    {
        Console.Write("Enter n (1 < n < 100): ");
        int n = int.Parse(Console.ReadLine());
        BigInteger factorialTwoN = 1;
        BigInteger factorialNPlusOne = 1;
        BigInteger factorialN = 1;

        for (int i = 1; i <= n * 2 ; i++)
        {
            factorialTwoN *= i;
            if (i <= n + 1)
            {
                factorialNPlusOne *= i;
            }
            if (i <= n )
            {
                factorialN *= i;
            }
        }

        BigInteger result = factorialTwoN / (factorialNPlusOne * factorialN);
        Console.WriteLine(result);
             
           
        
    }
}
