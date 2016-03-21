using System;
class ProgramPrimeNumberCheck
{
    static void Main()
    {
        Console.Write("Print a number: ");
        int num = Int32.Parse(Console.ReadLine());
        // double x = Convert.ToDouble(Console.ReadLine());
        int divider = 0;
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
            {
                divider++;
            }
        }
        if (divider == 2)
        {
            Console.WriteLine("Prime? True", num);
        }
        else
        {
            Console.WriteLine("Prime? False", num);
        }
    }

}
