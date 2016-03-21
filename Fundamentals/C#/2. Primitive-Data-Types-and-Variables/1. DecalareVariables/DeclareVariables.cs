using System;

class DeclareVariables
{
    static void Main()
    {
        ushort numOne = 52130;
        sbyte numTwo = -115;
        uint numThree = 4825932;
        byte numFour = 97;
        int numFive = -10000;

        Console.WriteLine(
            "{0}, {1}, {2}, {3}, {4}",
            numOne, numTwo, numThree, numFour, numFive);
    }
}