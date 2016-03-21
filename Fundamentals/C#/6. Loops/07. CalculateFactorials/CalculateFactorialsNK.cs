using System;
using System.Numerics;
class CalculateFactorialsNK
{
    static void Main()
    {
        Console.Write("Enter two integer: n and k (1 < k < n < 100). First enter \"n\": ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Now enter \"k\" (1 < k < n): ");
        int k = int.Parse(Console.ReadLine());
        BigInteger factorialN = 1;
        BigInteger factorialK = 1;       
        for (int i = 1; i <= n; i++)
        {
            factorialN *= i;
            if (i <= k)
            {
                factorialK *= i;
            }
        }        
        int nMinusK = n - k;
        BigInteger factorialNK = 1;
        for (int i = 1; i <= nMinusK; i++)
		{
			 factorialNK *= i;
		}
        Console.WriteLine(factorialN / (factorialK * factorialNK));
    }
}

