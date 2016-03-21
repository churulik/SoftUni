using System;

class CalculateFactroials
{
    static void Main()
    {
        Console.Write("Enter \"n\" intiger: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter \"x\" intiger: ");
        int x = int.Parse(Console.ReadLine());
        int factroial = 1;
        double sum = 1;
        for (int i = 1; i <=n; i++)
        {
            factroial *= i;
            sum+=(factroial/Math.Pow(x, i));
        }
        Console.WriteLine("{0:F5}", sum);
    }

}

