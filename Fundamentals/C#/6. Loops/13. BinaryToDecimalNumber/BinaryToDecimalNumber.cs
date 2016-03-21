using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        string binary = Console.ReadLine();
        long decimalNum = 0;
        for (int i = 0; i < binary.Length; i++)
        {
            if (binary [i] == '1')
            {
                double power = binary.Length - 1 - i;
                decimalNum += (long)Math.Pow(2, power);
            }
        }
        Console.WriteLine(decimalNum);
    }
}
