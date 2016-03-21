using System;
class QuetesInStrings
{
    static void Main()
    {
        string unqueted = "The \"use\" of quotations causes difficulties.";
        string queted = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(unqueted);
        Console.WriteLine(queted);        
    }
}
