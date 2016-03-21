using System;

class NullValuesArithmetic
{
    static void Main(string[] args)
    {
        int? valueNull = null;
        Console.WriteLine("The null value of null is -> " + valueNull);
        valueNull = 5;
        Console.WriteLine("Nullable value of 5 is -> " + valueNull);

        double? valueDouble = null;
        Console.WriteLine("The null value of null is  -> " + valueDouble);
        valueDouble = 5.5;
        Console.WriteLine("Nullable value of 5.5 is -> " + valueDouble);
    }
}

