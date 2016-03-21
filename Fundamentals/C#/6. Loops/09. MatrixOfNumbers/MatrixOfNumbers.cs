using System;

class MatrixOfNumbers
{
    static void Main()
    {
        Console.Write("Enter n (1 <= n <= 20): ");
        int n = int.Parse(Console.ReadLine());

        for (int row = 1; row <= n; row++)
        {
            Console.Write(row + " ");
            for (int col = row + 1; col < n + row; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}
