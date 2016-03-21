using System; 

class CalculateNK
{
    static void Main()
    {
        Console.Write("Enter two integer: n and k (1 < k < n < 100). First enter \"n\": ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Now enter \"k\" (1 < k < n): ");
        int k = int.Parse(Console.ReadLine());
        int factorialN = 1;
        int factorialK = 1;
        for (int i = 1; i <= n; i++)
        {
            factorialN *= i;
            if (i <= k)
            {
                factorialK *= i;
            }
        }
        Console.WriteLine(factorialN / factorialK);
    }
}

