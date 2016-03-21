using System;

namespace _02.FractionCalculator
{
    class Calculator
    {
        static void Main(string[] args)
        {

            var fraction1 = new Fraction(22, 7);
            var fraction2 = new Fraction(40, 4);

            var addition = fraction1 + fraction2;

            Console.WriteLine(addition.Numerator);
            Console.WriteLine(addition.Denominator);
            Console.WriteLine(addition);
            
            var subtraction = fraction1 - fraction2;

            Console.WriteLine(subtraction.Numerator);
            Console.WriteLine(subtraction.Denominator);
            Console.WriteLine(subtraction);
        }
    }
}
