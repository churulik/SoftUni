using System;

class ComparingFloats
{
    static void Main()
    {
        double a = 4.999999;
        double b = 4.999998;
        bool nearlyEqualAB = Math.Abs(a - b) < 0.000001;
        Console.WriteLine("4.999999 - 4.999998 are equal with eps = 0.000001 - {0}", nearlyEqualAB);

        double c = 5.00000004;
        double d = 5.00000001;
        bool nearlyEqualCD = Math.Abs(c - d) < 0.000001;
        Console.WriteLine("5.00000004 - 5.00000001 are equal with eps = 0.000001 - {0}", nearlyEqualCD);
    }
}

